using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.OracleClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ftd.data.log;
using ftd.mvc.Extensions;
using ftd.nsql;
using ftd.query.model;
using ftd.service;
using ftd.web;
using ftd.report;

namespace ftd.mvc.Controllers
{
    [Authorize]
    public class AppBaseController : Controller
    {
        public const string jTable_SUCCESS_CODE = "OK";
        public const string jTable_ERROR_CODE = "ERROR";

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // 取出目前執行的功能代碼-itemNo
            var _params = filterContext.HttpContext.Request.Params;
            if (_params.AllKeys.Contains("itemNo"))
            {
                var itemNo = _params["itemNo"];
                AppUserSession.Instance.CurrentFunc = itemNo == null ? "" : itemNo.ToString().Trim();
            }
            //ViewBag.count = GetUser();

            //在Action執行前執行  
            //filterContext.HttpContext.Response.Write(@"<br />Before Action execute" + "\t " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffff"));  
            getTimer(filterContext, "action").Start();
            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //在Action執行之後執行 輸出到輸出流中文字：After Action execute xxx  
            //filterContext.HttpContext.Response.Write(@"<br />After Action execute" + "\t " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffff"));  
            getTimer(filterContext, "action").Stop();
            base.OnActionExecuted(filterContext);
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            getTimer(filterContext, "render").Start();
            base.OnResultExecuting(filterContext);
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //在Result執行之後  
            //filterContext.HttpContext.Response.Write(@"<br />After ViewResult execute" + "\t " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffff"));  
            var renderTimer = getTimer(filterContext, "render");
            renderTimer.Stop();

            var actionTimer = getTimer(filterContext, "action");
            var msg = String.Format(
                        "Action({0}) '{1}/{2}', Execute: {3:c} , Render: {4:c}.",
                        filterContext.HttpContext.Request.HttpMethod,
                        filterContext.RouteData.Values["controller"],
                        filterContext.RouteData.Values["action"],
                        actionTimer.Elapsed,
                        renderTimer.Elapsed
                    );
            var log = new PerformanceLog();
            log.LogContent = msg;
            log.post();
            base.OnResultExecuted(filterContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            var ex = filterContext.Exception;
            System.Diagnostics.Trace.TraceError(ex.ToString());
            var log = new FtdExceptionLog(ex);
            log.post();
        }

        private Stopwatch getTimer(ControllerContext context, string name)
        {
            string key = "__timer__" + name;
            if (context.HttpContext.Items.Contains(key))
            {
                return (Stopwatch)context.HttpContext.Items[key];
            }

            var watch = new Stopwatch();
            context.HttpContext.Items[key] = watch;
            return watch;
        }

        //[HttpPost]
        //public string GetUser()
        //{
        //    string msg = "";
        //    try
        //    {
        //        var app = HttpContext.ApplicationInstance as HttpApplication;
        //        var count = app.Application["online"].ToString();
        //        var machineCode = AppUserSession.User.MachineCode;
        //        var dtSysParameter = NsDmHelper.SY_LogonUser.where(t => t.SYLU_Code == machineCode).query();
        //        if (dtSysParameter.Count != 0)
        //        {
        //            var row = dtSysParameter.FirstOrDefault();
        //            msg = row.SYLU_Value.ToString();
        //        }
        //        else
        //        {
        //            msg = "0";
        //        }
        //        //return Json(new { Result = "OK", Options = msg });
        //    }
        //    catch (Exception ex)
        //    {
        //        //return Json(new { Result = "ERROR", Message = ex.Message });
        //    }
        //    return msg;
        //}

        //public ActionResult DownLoadRpt(string filename, string contenttype, byte[] files, bool direct = true)
        //{
        //    //contenttype = "application/pdf";
        //    string[] data = filename.Split('.');
        //    string lastname = data.ElementAt(data.Count() - 1).ToLower();

        //    switch (lastname)
        //    {
        //        case "pdf":
        //        case "xls":
        //        case "xlsx":
        //        case "doc":
        //        case "docx":
        //        case "xml":
        //        case "txt":
        //            break;
        //        default:
        //            throw new Exception("不支援的報表輸出格式");
        //    }

        //    if (direct)
        //        return File(files, contenttype, filename);
        //    else
        //        return File(files, contenttype);
        //}

        internal FtbReportTypes ReportTypes(string RptType)
        {
            if (RptType.isNullOrEmpty())
                return FtbReportTypes.PDF;

            FtbReportTypes type;
            switch (RptType.ToLower())//副檔名
            {
                case "pdf":
                    type = FtbReportTypes.PDF;
                    break;
                case "xls":
                    type = FtbReportTypes.Xls;
                    break;
                case "doc":
                    type = FtbReportTypes.Doc;
                    break;
                default:
                    type = FtbReportTypes.PDF;
                    break;
            }
            return type;
        }

        internal static string getContentTypeForFileName(string fileName)
        {
            string ext = System.IO.Path.GetExtension(fileName);
            using (Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext))
            {
                if (registryKey == null)
                    return "application/octet-stream";
                var value = registryKey.GetValue("Content Type");
                return (value == null) ? "application/octet-stream" : value.ToString();
            }
        }

        //internal JsonResult converToJTableSource<TSource>(IEnumerable<TSource> srcData, int startIndex = 0, int pageSize = 0) where TSource : DataRow
        internal ActionResult converToJTableSource<TSource>(IEnumerable<TSource> srcData, int startIndex = 0, int pageSize = 0) where TSource : DataRow
        {
            if (srcData == null)
            {
                var list = new List<Dictionary<string, object>>();
                var jsonData = new
                {
                    Result = jTable_SUCCESS_CODE,
                    Records = list,
                    TotalRecordCount = 0
                };
                return Json(jsonData);
            }
            else
            {
                var data = pageSize > 0 ? srcData.Skip(startIndex).Take(pageSize).ToList() : srcData.ToList();
                var list = data.toDictionaryList();
                var jsonData = new
                {
                    Result = jTable_SUCCESS_CODE,
                    Records = list,
                    TotalRecordCount = srcData.Count()
                };
                //return Json(jsonData);

                var serializer = new JavaScriptSerializer();

                // For simplicity just use Int32's max value.
                // You could always read the value from the config section mentioned above.
                serializer.MaxJsonLength = Int32.MaxValue;

                var result = new ContentResult
                {
                    Content = serializer.Serialize(jsonData),
                    ContentType = "application/json"
                };
                return result;
            }
        }
    }
}
