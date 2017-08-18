using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ftd.data.log;
using ftd.service;
using ftd.mvc.Configs;
using ftd.web;
using ftd.mvc.Controllers;
using ftd.nsql;
using ftd.mvc.ViewEngine;

namespace ftd.mvc
{
    // 注意: 如需啟用 IIS6 或 IIS7 傳統模式的說明，
    // 請造訪 http://go.microsoft.com/?LinkId=9394801

    public class AppWebHostLog : FtdLog
    {
        public override string getLogFileName()
        {
            return "WebHost.txt";
        }
    }

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            #region //初始化服務
            //註冊服務鍵構子            
            FtdCreatorService.Instance.Creator = new AppObjectCreator();
            object obj = FtdWebFolderService.Instance;

            //啟動排程服務
            FtdScheduleService.Instance.loadTasks();
            
            //立即啟動送信服務
            //FtdMailService.Instance.activeTask();

            //載入共用代碼(SY_Code)
            //SyDataService.Instance.loadSyCodeToCodeTypeNames();
            //載入地址檔(SY_Address)
            //SyDataService.Instance.loadSyAddressToCodeTypeNames();

            //應用程式啟動log
            var log = new AppWebHostLog();
            log.LogContent = string.Format("Web應用程式[{0}]啟動", AppDomain.CurrentDomain.FriendlyName);
            log.post();
            #endregion 

            //線上人數
            Application["online"] = 0;   ///起始化0

            //ViewEngines.Engines.Clear();
            //ViewEngines.Engines.Add(new FwbRazorViewEngine());

            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            //this.Error += MvcApplication_Error;
        }
        
        //void MvcApplication_Error(object sender, EventArgs e)
        //{
        //    var ex = Server.GetLastError();
        //    var log = new FtdExceptionLog(ex);

        //    ////Find 錯誤來源程式
        //    //var ctx = HttpContext.Current;
        //    //var exe_path = "";
        //    //if (ctx != null
        //    //    && ctx.Request != null
        //    //    && !ctx.Request.CurrentExecutionFilePath.isNullOrEmpty())
        //    //{
        //    //    exe_path = ctx.Request.CurrentExecutionFilePath;
        //    //}

        //    ////Log記錄
        //    //var is_aspx = exe_path.ToLower().EndsWith(".aspx");
        //    //if (!is_aspx)
        //    //{
        //    //    log.LogContent = "Path:" + exe_path + "\n" + log.LogContent;
        //    //}
        //    log.post();
        //}

        //protected void Application_Error()
        //{
        //    var exception = Server.GetLastError();
        //    var httpException = exception as HttpException;
        //    Response.Clear();
        //    Server.ClearError();
        //    var routeData = new RouteData();
        //    routeData.Values["controller"] = "Errors";
        //    routeData.Values["action"] = "General";
        //    routeData.Values["exception"] = exception;
        //    Response.StatusCode = 500;
        //    if (httpException != null)
        //    {
        //        Response.StatusCode = httpException.GetHttpCode();
        //        switch (Response.StatusCode)
        //        {
        //            case 403:
        //                routeData.Values["action"] = "Http403";
        //                break;
        //            case 404:
        //                routeData.Values["action"] = "Http404";
        //                break;
        //        }
        //    }
        //    // Avoid IIS7 getting in the middle
        //    Response.TrySkipIisCustomErrors = true;
        //    IController errorsController = new ErrorsController();
        //    HttpContextWrapper wrapper = new HttpContextWrapper(Context);
        //    var rc = new RequestContext(wrapper, routeData);
        //    errorsController.Execute(rc);
        //}

        void Session_Start(object sender, EventArgs e)
        {
            #region //測試用 (如：資安掃描，移除登入並給予系統管理員權限)
            //AppLoginService.Instance.login("EOE_A413", "");
            //AppUserSession.Instance.loginUser("EOE_A413");
            #endregion

            // 在新會話啟動時運行的代碼
            Application.Lock(); //鎖定Application
            //AppUserSession.User.UserId!
            int iNum = Int32.Parse(Application["online"].ToString()) + 1;
            Application.Set("online", iNum); //修改物件的值，為自身加1
            Application.UnLock(); //解鎖物件的鎖定
            updateOnLineInfo();
        }

        void Session_End(object sender, EventArgs e)
        {
            // 在會話結束時運行的代碼。
            // 注意: 只有在 Web.config 檔中的 sessionstate 模式設置為
            // InProc 時，才會引發 Session_End 事件。如果會話模式設置為 StateServer
            // 或 SQLServer，則不會引發該事件。
            Application.Lock();
            int iNum = Int32.Parse(Application["online"].ToString()) - 1;
            Application.Set("online", iNum);
            Application.UnLock();
            updateOnLineInfo();
        }

        private void updateOnLineInfo()
        {
            try
            {
                //var count = Application["online"].ToString();
                //var machineCode = FtdConfigService.Instance.getAppSettingValue("MachineCode", "01"); //AppUserSession.User.MachineCode;
                //var dtSysParameter = NsDmHelper.SY_LogonUser.where(t => t.SYLU_Code == machineCode).query();
                //if (dtSysParameter.Count == 0)
                //{
                //    var row = dtSysParameter.newTypedRow();
                //    row.ns_AssignNewId();
                //    row.SYLU_Code = machineCode;
                //    row.SYLU_Name = "線上人數";
                //    row.SYLU_Value = count;
                //    dtSysParameter.Rows.Add(row);
                //}
                //else
                //{
                //    var row = dtSysParameter.FirstOrDefault();
                //    row.SYLU_Value = count;
                //}
                //dtSysParameter.ns_update();
            }
            catch (Exception ex)
            {
                
            }
        }

        public static void writeExceptionLog(Exception ex)
        {
            var log = new FtdExceptionLog(ex);
            log.post();
        }

        public static void writeLog(string msg)
        {
            var log = new FtdExceptionLog();
            log.LogContent = msg;
            log.post();
        }
    }
}