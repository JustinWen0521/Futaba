using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ftd.data;
using ftd.nsql;
using ftd.web;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using ftd.mvc.Extensions;
using ftd.service;

namespace ftd.mvc.Controllers
{
    public class HomeController : AppBaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = FtdConfigService.Instance.getAppSettingValue("ProductName", "");
            //ViewBag.count = GetUser();
            return View();
        }

        public ActionResult Info()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = FtdConfigService.Instance.getAppSettingValue("ProductName", ""); 

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Employee()
        {
            //EO_EmployeeDataTable dt = NsDmHelper.EO_Employee
            //    .selectAll(t => t.AllExt)
            //    .orderby(t => new[]{
            //        t.EOE_EmployeeTitleCode_XX.Asc,
            //        t.EOE_EmployeeCode.Asc
            //    })
            //    .query();

            //return View(dt);
            var row = NsDmHelper.EO_Employee
                .selectAll(t => t.AllExt)
                .queryFirst();

            return View(row);
        }

        public ActionResult Employee2()
        {
            EO_EmployeeDataTable dt = NsDmHelper.EO_Employee
                .selectAll(t => t.AllExt)
                .orderby(t => new[]{
                    t.EOE_EmployeeTitleCode_XX.Asc,
                    t.EOE_EmployeeCode.Asc
                })
                .query();

            return View(dt);
        }

        //[HttpPost]
        //public void RecordUser()
        //{
        //    //abandom Session
        //    //System.Web.HttpContext.Current.Session.Abandon();

        //    //var app = HttpContext.ApplicationInstance as HttpApplication; //MvcApplication;
        //    //var count = app.Application["online"].ToString();
        //    //var machineCode = AppUserSession.User.MachineCode;
        //    //var dtSysParameter = NsDmHelper.SY_LogonUser.where(t=>t.SYLU_Code==machineCode).query();
        //    //if (dtSysParameter.Count==0)
        //    //{
        //    //    var row = dtSysParameter.newTypedRow();
        //    //    row.ns_AssignNewId();
        //    //    row.SYLU_Code = machineCode;
        //    //    row.SYLU_Name = "線上人數";
        //    //    row.SYLU_Value = count;
        //    //    dtSysParameter.Rows.Add(row);
        //    //}
        //    //else
        //    //{
        //    //    var row = dtSysParameter.FirstOrDefault();
        //    //    row.SYLU_Value = count;
        //    //}
        //    //dtSysParameter.ns_update();
        //}

        [HttpPost]
        public void Login()
        {
            var app = HttpContext.ApplicationInstance as HttpApplication;
            // 在新會話啟動時運行的代碼
            app.Application.Lock(); //鎖定Application
            int iNum = Int32.Parse(app.Application["online"].ToString()) + 1;
            app.Application.Set("online", iNum); //修改物件的值，為自身加1
            app.Application.UnLock(); //解鎖物件的鎖定
            //RecordUser();
        }

        [HttpPost]
        public void Logout()
        {
            var app = HttpContext.ApplicationInstance as HttpApplication;
            // 在新會話啟動時運行的代碼
            app.Application.Lock(); //鎖定Application
            //AppUserSession.User.UserId!
            int iNum = Int32.Parse(app.Application["online"].ToString()) - 1;
            app.Application.Set("online", iNum); //修改物件的值，為自身加1
            app.Application.UnLock(); //解鎖物件的鎖定
            //RecordUser();
            System.Web.HttpContext.Current.Session.Abandon();
        }

        //[HttpPost]
        //public string GetUser()
        //{
        //    string msg = "";
        //    try
        //    {
        //        var app = HttpContext.ApplicationInstance as HttpApplication;//MvcApplication;
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

        //[HttpGet]
        //public JsonResult AJAX_SignNo(string Q_Code, string type)
        //{
        //    try
        //    {
        //        if (type == "1") //鄉鎮市區
        //        {
        //            string code = Q_Code.isNullOrEmpty() ? "" : Q_Code.Substring(0, 1) + "%0000";
        //            var dt = NsDmHelper.SY_Sign
        //                .select(t => new[] { t.SYS_SignNo, t.SYS_SignName })
        //                .where(t =>
        //                    t.SYS_SignNo != Q_Code
        //                    & t.SYS_SignNo.like(code)
        //                )
        //                .orderby(t => t.SYS_SignName.Asc)
        //                .query().ToList().toDictionaryList();
        //            var res = Json(dt, JsonRequestBehavior.AllowGet);
        //            return res;
        //        }
        //        else if (type == "2") //地段
        //        {
        //            var dt = NsDmHelper.SY_Sign
        //                .select(t => new[] { t.SYS_SignNo, t.SYS_SignName })
        //                .where(t =>
        //                    t.SYS_SignNo != Q_Code
        //                    & t.SYS_SignNo.substr(1, 3) == (Q_Code.isNullOrEmpty() ? "" : Q_Code.Substring(0, 3))
        //                )
        //                .orderby(t => t.SYS_SignName.Asc)
        //                .query().ToList().toDictionaryList();
        //            var res = Json(dt, JsonRequestBehavior.AllowGet);
        //            return res;
        //        }
        //        else if (type == "0") //縣市
        //        {
        //            var dt = NsDmHelper.SY_Sign
        //                .select(t => new[] { t.SYS_SignNo, t.SYS_SignName })
        //                .where(t => t.SYS_SignNo.like("%000000"))
        //                .orderby(t => t.SYS_SeqNo.Asc)
        //                .query().ToList().toDictionaryList();
        //            var res = Json(dt, JsonRequestBehavior.AllowGet);
        //            return res;
        //        }
        //        else
        //        {
        //            var dt = NsDmHelper.SY_Sign
        //                .select(t => new[] { t.SYS_SignNo, t.SYS_SignName, t.SYS_SignDesc, t.SYS_SignDescOrig1, t.SYS_SignDescOrig2, t.SYS_SignDescOrig3 })
        //                .where(t => t.SYS_SignNo == Q_Code.toConstReq1())
        //                .orderby(t => t.SYS_SignName.Asc)
        //                .query().ToList().toDictionaryList();
        //            var res = Json(dt, JsonRequestBehavior.AllowGet);
        //            return res;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Result = "ERROR", Message = ex.Message });
        //    }
        //}

        //[HttpGet]
        //public JsonResult AJAX_Data(string CodeKind, string OrgId)
        //{
        //    try
        //    {
        //        var dt = NsDmHelper.SY_Code
        //          .selectAll()
        //          .where(t =>
        //              t.SYC_CodeKind == CodeKind.toConstReq1() 
        //              & t.SYC_CodeCon3 == OrgId.toConstReq1()
        //          )
        //          .query().ToList().toDictionaryList();
        //        var res = Json(dt, JsonRequestBehavior.AllowGet);
        //        return res;

        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Result = "ERROR", Message = ex.Message });
        //    }
        //}

        //[HttpGet]
        //public JsonResult AJAX_Data1(string CodeKind)
        //{
        //    try
        //    {
        //        var dt = NsDmHelper.SY_Code
        //          .selectAll()
        //          .where(t =>
        //              t.SYC_CodeKind == CodeKind.toConstReq1()
        //              //& t.SYC_CodeCon3 == OrgId.toConstReq1()
        //          )
        //          .query().ToList().toDictionaryList();
        //        var res = Json(dt, JsonRequestBehavior.AllowGet);
        //        return res;

        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Result = "ERROR", Message = ex.Message });
        //    }
        //}

        //[HttpGet]
        //public JsonResult AJAX_Data2(string CodeKind, string Con1)
        //{
        //    try
        //    {
        //        var dt = NsDmHelper.SY_Code
        //          .selectAll()
        //          .where(t =>
        //              t.SYC_CodeKind == CodeKind.toConstReq1()
        //            & t.SYC_CodeCon1 == Con1.toConstReq1()
        //          )
        //          .query().ToList().toDictionaryList();
        //        var res = Json(dt, JsonRequestBehavior.AllowGet);
        //        return res;

        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Result = "ERROR", Message = ex.Message });
        //    }
        //}

        #region Ajax File Upload
        //public ActionResult GetFile(string id)
        //{
        //    #region back
        //    try
        //    {
        //        // Verify that the user selected a file
        //        if (true)
        //        {
        //            return Json(new { Result = "OK", FileName = "ar34@.jpg" });
        //        }
        //        else
        //        {
        //            return Json(new { Result = "ERROR", Message = "上傳之資料為NULL!" });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Result = "ERROR", Message = ex.Message });
        //    }
        //    #endregion

        //}

        //[HttpPost]
        //public JsonResult tFileUpload(HttpPostedFileBase file, string Sys, string id)
        //{
        //    try
        //    {
        //        var DownSizeWidth = int.Parse(FtdConfigService.Instance.getAppSettingValue("DownSizeWidth", "true"));
        //        var DonwSizeFormat = FtdConfigService.Instance.getAppSettingValue("DonwSizeFormat", "true").Split('|');

        //        // Verify that the user selected a file
        //        if (file != null && file.ContentLength > 0)
        //        {
        //            //存到DB
        //            var Fname = file.FileName;
        //            var Data = file.InputStream;
        //            #region test
        //            ftd.mvc.Models.FileManager manager = new Models.FileManager();
        //            #region
        //            var dt = NsDmHelper.UM_AttachFile.where(t => t.UMAF_MovableId == id).orderby(t => t.UMAF_Seq.Desc).query();
        //            if (dt.Count() >= 3)
        //            {
        //                return Json(new { Result = "上傳筆數最多為三筆!", Message = "上傳筆數最多為三筆!" });
        //            }
        //            var type = Fname.Split('.')[1];
        //            //var data = Help.DownSize(ReadFully(file.InputStream), 500, type);
        //            byte[] data = ReadFully(file.InputStream);
        //            if (DonwSizeFormat.Contains(type.ToUpper()))
        //            {
        //                data = Help.DownSize(data, DownSizeWidth, type);
        //            }
        //            else
        //            {
        //                data = Help.ZipFile(data, Fname);
        //                Fname = Fname + ".zip";
        //            }

        //            var row = dt.newTypedRow();
        //            row.ns_AssignNewId();
        //            row.UMAF_MovableId = id;
        //            row.UMAF_FName = Fname;
        //            row.UMAF_FType = file.ContentType;
        //            row.UMAF_FSize = data.Length;//file.ContentLength;
        //            row.UMAF_RawData = data;
        //            row.UMAF_Seq = dt.Count() == 0 ? 1 : dt.FirstOrDefault().UMAF_Seq + 1;
        //            dt.Rows.Add(row);
        //            dt.ns_update();
        //            #endregion
        //            //存到實體資料夾
        //            //manager.FileUpLoad(file,AppUserSession.User.OrganId);
        //            #endregion
        //            return Json(new { Result = "OK", FileName = Fname });
        //        }
        //        else
        //        {
        //            return Json(new { Result = "上傳失敗或者資料為空!", Message = "上傳失敗或者資料為空!" });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Result = ex.Message, Message = ex.Message });
        //    }
        //}

        //public byte[] ReadFully(Stream input)
        //{
        //    byte[] result;
        //    using (var streamReader = new MemoryStream())
        //    {
        //        input.CopyTo(streamReader);
        //        result = streamReader.ToArray();
        //    }
        //    return result;
        //}

        //[HttpGet]
        ////[HttpPost]
        //public ActionResult DownLoadFile(string filename, string Seq, string MovableId)
        //{
        //    if (AppUserSession.User.IsGuest)
        //        return Json(new { Result = "請依照正常管道操作!", Message = "請依照正常管道操作!" });
        //    //var path = @"D:\VS_Working\FtbApp2012_jTable\FtbApp\AppWeb\FileManagerFolder\admin\ar34@.jpg";
        //    //var file = System.IO.File.ReadAllBytes(path);
        //    //return File(file, "image/jpeg", filename);
        //    var file = NsDmHelper.UM_AttachFile.where(t => t.UMAF_MovableId == MovableId.toConstReq1()
        //        & t.UMAF_Seq == int.Parse(Seq).toConstReq1())
        //        .queryFirst();
        //    return File(file.UMAF_RawData, file.UMAF_FType, file.UMAF_FName);
        //}

        //[HttpGet]
        //public ActionResult GetBase64Image(string MovableId)
        //{
        //    if (AppUserSession.User.IsGuest)
        //        return Json(new { Result = "請依照正常管道操作!", Message = "請依照正常管道操作!" });
        //    //var file = NsDmHelper.UM_AttachFile.queryFirst();
        //    //return Json(new { base64imgage = Convert.ToBase64String(file.UMAF_RawData) }
        //    //   , JsonRequestBehavior.AllowGet);

        //    var file = NsDmHelper.UM_AttachFile.where(t => t.UMAF_MovableId == MovableId.toConstReq1()).query();
        //    List<string> ls = new List<string>();
        //    List<string> ls_Ftype = new List<string>();
        //    List<string> ls_Fname = new List<string>();
        //    List<string> ls_Seq = new List<string>();
        //    foreach (var dr in file)
        //    {
        //        ls.Add(Convert.ToBase64String(dr.UMAF_RawData));
        //        ls_Ftype.Add(dr.UMAF_FType);
        //        ls_Fname.Add(dr.UMAF_FName);
        //        ls_Seq.Add(dr.UMAF_Seq.Value.ToString());
        //    }
        //    return Json(new { base64imgage = ls, Ftype = ls_Ftype, Fname = ls_Fname, Seq = ls_Seq }
        //       , JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public JsonResult DeleteFile(string FileName, string Seq, string MovableId)
        //{
        //    try
        //    {
        //        if (AppUserSession.User.IsGuest)
        //            return Json(new { Result = "請依照正常管道操作!", Message = "請依照正常管道操作!" });
        //        int intseq = int.Parse(Seq);
        //        // Verify that the user selected a file
        //        if (FileName != "" && MovableId != "")
        //        {

        //            #region test
        //            //ftd.mvc.Models.FileManager manager = new Models.FileManager();
        //            #region
        //            var dt = NsDmHelper.UM_AttachFile.where(t => t.UMAF_MovableId == MovableId
        //                & t.UMAF_Seq == intseq.toConstReq1()).query();
        //            dt.FirstOrDefault().Delete();
        //            dt.ns_update();
        //            #endregion
        //            //存到實體資料夾
        //            //manager.DeleteFile(FileName, AppUserSession.User.OrganId);
        //            #endregion
        //            return Json(new { Result = "OK" });
        //        }
        //        else
        //        {
        //            return Json(new { Result = "刪除失敗!", Message = "刪除失敗!" });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Result = ex.Message, Message = ex.Message });
        //    }
        //}

        //public ActionResult FileUpload(string myuploader)
        //{
        //    using (CuteWebUI.MvcUploader uploader = new CuteWebUI.MvcUploader(System.Web.HttpContext.Current))
        //    {
        //        uploader.UploadUrl = Response.ApplyAppPathModifier("~/UploadHandler.ashx");
        //        //the data of the uploader will render as <input type='hidden' name='myuploader'> 
        //        uploader.Name = "myuploader";
        //        uploader.AllowedFileExtensions = "*.jpg,*.gif,*.png,*.bmp,*.zip,*.rar";
        //        //allow select multiple files
        //        uploader.MultipleFilesUpload = true;
        //        //tell uploader attach a button
        //        uploader.InsertButtonID = "uploadbutton";
        //        //prepair html code for the view
        //        ViewData["uploaderhtml"] = uploader.Render();
        //        //if it's HTTP POST:
        //        if (!string.IsNullOrEmpty(myuploader))
        //        {
        //            List<string> processedfiles = new List<string>();
        //            //for multiple files , the value is string : guid/guid/guid 
        //            foreach (string strguid in myuploader.Split('/'))
        //            {
        //                Guid fileguid = new Guid(strguid);
        //                CuteWebUI.MvcUploadFile file = uploader.GetUploadedFile(fileguid);
        //                if (file != null)
        //                {
        //                    //you should validate it here:
        //                    //now the file is in temporary directory, you need move it to target location
        //                    //file.MoveTo("~/myfolder/" + file.FileName);
        //                    processedfiles.Add(file.FileName);
        //                }
        //            }
        //            if (processedfiles.Count > 0)
        //            {
        //                ViewData["UploadedMessage"] = string.Join(",", processedfiles.ToArray()) + " have been processed.";
        //            }
        //        }
        //    }
        //    return View();
        //}

        //public ActionResult FilesUploadAjax(string guidlist, string deleteid)
        //{
        //    FileManagerProvider manager = new FileManagerProvider();
        //    string username = AppUserSession.User.UserId;//GetCurrentUserName();

        //    if (!string.IsNullOrEmpty(guidlist))
        //    {
        //        using (CuteWebUI.MvcUploader uploader = new CuteWebUI.MvcUploader(System.Web.HttpContext.Current))
        //        {
        //            foreach (string strguid in guidlist.Split('/'))
        //            {
        //                CuteWebUI.MvcUploadFile file = uploader.GetUploadedFile(new Guid(strguid));
        //                if (file == null)
        //                    continue;
        //                //savefile here
        //                manager.MoveFile(username, file.GetTempFilePath(), file.FileName, null);
        //            }
        //        }
        //    }

        //    if (!string.IsNullOrEmpty(deleteid))
        //    {
        //        FileItem file = manager.GetFileByID(username, deleteid);
        //        if (file != null)
        //        {
        //            file.Delete();
        //        }
        //    }

        //    FileItem[] files = manager.GetFiles(username);
        //    Array.Reverse(files);
        //    FileManagerJsonItem[] items = new FileManagerJsonItem[files.Length];
        //    string baseurl = Response.ApplyAppPathModifier("~/FileManagerDownload.ashx?user=" + username + "&file=");
        //    for (int i = 0; i < files.Length; i++)
        //    {
        //        FileItem file = files[i];
        //        FileManagerJsonItem item = new FileManagerJsonItem();
        //        item.FileID = file.FileID;
        //        item.FileName = file.FileName;
        //        item.Description = file.Description;
        //        item.UploadTime = file.UploadTime.ToString("yyyy-MM-dd HH:mm:ss");
        //        item.FileSize = file.FileSize;
        //        item.FileUrl = baseurl + file.FileID;
        //        items[i] = item;
        //    }
        //    JsonResult json = new JsonResult();
        //    json.Data = items;
        //    return json;
        //}

        //public class FileManagerJsonItem
        //{
        //    public string FileID;
        //    public string FileName;
        //    public int FileSize;
        //    public string Description;
        //    public string UploadTime;
        //    public string FileUrl;
        //}
        #endregion

        //public ActionResult News(string id)
        //{
        //    ViewBag.Msg = "";
        //    if (id == null || id == "")
        //    {
        //        ViewBag.Msg = "找不到該訊息!";
        //        return View();
        //    }

        //    if (AppUserSession.User.isNull())
        //    {
        //        ViewBag.Msg = "請依照方式合法登入!";
        //        return View();
        //    }

        //    if (AppUserSession.User.IsGuest)
        //    {
        //        ViewBag.Msg = "請依照方式合法登入!";
        //        return View();
        //    }

        //    try
        //    {
        //        var SyNews = NsDmHelper.SY_News.wherepk(id).queryFirst();
        //        // 因存入時有被編碼, 取出顯示時要解碼
        //        SyNews.SYN_Message = HttpUtility.HtmlDecode(SyNews.SYN_Message);

        //        if (SyNews == null)
        //        {
        //            var result = new ContentResult();
        //            result.Content = "訊息已不存在";
        //            return result;
        //        }
        //        else
        //        {
        //            return PartialView(SyNews);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var result = new ContentResult();
        //        result.Content = "顯示公告訊息發生錯誤";
        //        return result;
        //    }
        //}

        //[HttpGet]
        //public JsonResult AJAX_DoorPlate(string Q_Desc, string kind)
        //{
        //    try
        //    {
        //        if (kind == "1") //縣市
        //        {
        //            var dt = NsDmHelper.SY_Address
        //                .select(t => new object[] { t.SYA_AddressId, t.SYA_AddrName })
        //                .where(t => t.SYA_AddrKind == "1")
        //                .orderby(t => t.SYA_ZipCode.Asc)
        //                .query().ToList().toDictionaryList();
        //            var res = Json(dt, JsonRequestBehavior.AllowGet);
        //            return res;
        //        }
        //        else if (kind == "2") //鄉鎮市區
        //        {
        //            var dt = NsDmHelper.SY_Address
        //                .select(t => new object[] { t.SYA_AddressId, t.SYA_AddrName })
        //                .where(t =>
        //                    t.SYA_AddrKind == "2"
        //                    & t.SYA_Desc.like(Q_Desc + "%")
        //                )
        //                .orderby(t => t.SYA_ZipCode.Asc)
        //                .query().ToList().toDictionaryList();
        //            var res = Json(dt, JsonRequestBehavior.AllowGet);
        //            return res;
        //        }
        //        else //村里
        //        {
        //            var dt = NsDmHelper.SY_Address
        //                .select(t => new object[] { t.SYA_AddressId, t.SYA_AddrName })
        //                .where(t =>
        //                    t.SYA_AddrKind == "3"
        //                    & t.SYA_Desc.like(Q_Desc + "%")
        //                )
        //                .orderby(t => t.SYA_ZipCode.Asc)
        //                .query().ToList().toDictionaryList();
        //            var res = Json(dt, JsonRequestBehavior.AllowGet);
        //            return res;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Result = "ERROR", Message = ex.Message });
        //    }
        //}

        //[HttpGet]
        //public JsonResult AJAX_ReportField(string type)
        //{
        //    try
        //    {
        //        var dt = NsDmHelper.UT_ReportField
        //       .select(t => new object[] { t.UTRF_ReportFieldId,t.UTRF_FieldName})
        //       .where(t => t.UTRF_DataType == type.toConstReq1())
        //       .orderby(t => t.UTRF_SortNo.Asc)
        //       .query().ToList().toDictionaryList();//.toDictionaryList();
        //        var res = Json(dt, JsonRequestBehavior.AllowGet);
        //        return res;
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Result = "ERROR", Message = ex.Message });
        //    }
        //}

        //[HttpGet]
        //public string AJAX_PriceIndex(string Q_Date)
        //{
        //    try
        //    {
        //        #region //取最大基數年度
        //        var dtTemp = NsDmHelper.SY_PriceIndex.selectAll(t => t.SYPI_BaseYYY).query();
        //        string maxbaseyyy = dtTemp.Max(x => x.SYPI_BaseYYY);

        //        string year = Q_Date.isNullOrEmpty() ? "" : Q_Date.Substring(0, 3).PadLeft(3, '0');
        //        string period = Q_Date.isNullOrEmpty() ? "" : Q_Date.Substring(3, 2).PadLeft(2, '0');
        //        var dt = NsDmHelper.SY_PriceIndex
        //            .selectAll(t => t.AllPhysical)
        //            .where(t => t.SYPI_PriceYYY == year & t.SYPI_BaseYYY == maxbaseyyy
        //            )
        //            .orderby(t => t.SYPI_PriceYYY.Asc)
        //            .query();

        //        string priceIndex = string.Empty;
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            switch (period)
        //            {
        //                case "01": // 1月
        //                    priceIndex = dt.Rows[0][AppDataName.SYPI_Price01].ToString();
        //                    break;
        //                case "02": // 2月
        //                    priceIndex = dt.Rows[0][AppDataName.SYPI_Price02].ToString();
        //                    break;
        //                case "03": // 3月
        //                    priceIndex = dt.Rows[0][AppDataName.SYPI_Price03].ToString();
        //                    break;
        //                case "04": // 5月
        //                    priceIndex = dt.Rows[0][AppDataName.SYPI_Price04].ToString();
        //                    break;
        //                case "05": // 5月
        //                    priceIndex = dt.Rows[0][AppDataName.SYPI_Price05].ToString();
        //                    break;
        //                case "06": // 6月
        //                    priceIndex = dt.Rows[0][AppDataName.SYPI_Price06].ToString();
        //                    break;
        //                case "07": // 7月
        //                    priceIndex = dt.Rows[0][AppDataName.SYPI_Price07].ToString();
        //                    break;
        //                case "08": // 8月
        //                    priceIndex = dt.Rows[0][AppDataName.SYPI_Price08].ToString();
        //                    break;
        //                case "09": // 9月
        //                    priceIndex = dt.Rows[0][AppDataName.SYPI_Price09].ToString();
        //                    break;
        //                case "10": // 1-月
        //                    priceIndex = dt.Rows[0][AppDataName.SYPI_Price10].ToString();
        //                    break;
        //                case "11": // 11月
        //                    priceIndex = dt.Rows[0][AppDataName.SYPI_Price11].ToString();
        //                    break;
        //                case "12": // 12月
        //                    priceIndex = dt.Rows[0][AppDataName.SYPI_Price12].ToString();
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //        #endregion
        //        return priceIndex;
        //    }
        //    catch (Exception ex)
        //    {
        //        string errmsg = "找不到物價指數資料 : " + ex.Message;
        //        return errmsg;
        //    }
        //}

        //[HttpGet]
        //public string AJAX_BuildingTax(string Q_Id, string Q_Date)
        //{
        //    try
        //    {
        //        string year = Q_Date.isNullOrEmpty() ? "" : Q_Date.Substring(0, 3).PadLeft(3, '0');
        //        var dt = NsDmHelper.UB_Tax
        //            .selectAll(t => t.UBT_TaxPrice)
        //            .where(t => t.UBT_BuildingId == Q_Id & t.UBT_TaxYear == year
        //            )
        //            .query();

        //        string taxPrice = string.Empty;
        //        if (dt != null && dt.Rows.Count > 0)
        //            taxPrice = dt.Rows[0][AppDataName.UBT_TaxPrice].ToString();
        //        else
        //            taxPrice = "0";

        //        return taxPrice;
        //    }
        //    catch (Exception ex)
        //    {
        //        string errmsg = "找不到建物稅籍資料 : " + ex.Message;
        //        return errmsg;
        //    }
        //}

        //[HttpGet]
        //public string AJAX_PriceUnit(string Q_Id, string Q_Date)
        //{
        //    try
        //    {
        //        var dt = NsDmHelper.UL_Price
        //            .selectAll(t => t.ULPR_PriceUnit)
        //            .where(t => t.ULPR_LandId == Q_Id &
        //                t.ULPR_SuitDateS <= Q_Date &
        //                t.ULPR_SuitDateE >= Q_Date
        //            )
        //            .query();

        //        string unitPrice = string.Empty;
        //        if (dt != null && dt.Rows.Count > 0)
        //            unitPrice = dt.Rows[0][AppDataName.ULPR_PriceUnit].ToString() + "," + dt.Rows[0][AppDataName.ULPR_SuitDateS].ToString();
        //        else
        //            unitPrice = "0,";

        //        return unitPrice;
        //    }
        //    catch (Exception ex)
        //    {
        //        string errmsg = "找不到土地公告現值資料 : " + ex.Message;
        //        return errmsg;
        //    }
        //}

        //[HttpGet]
        //public string AJAX_ValueUnit(string Q_Id, string Q_Date)
        //{
        //    try
        //    {
        //        var dt = NsDmHelper.UL_Value
        //            .selectAll(t => t.ULV_ValueUnit)
        //            .where(t => t.ULV_LandId == Q_Id &
        //                t.ULV_SuitDateS <= Q_Date &
        //                t.ULV_SuitDateE >= Q_Date
        //            )
        //            .query();

        //        string unitValue = string.Empty;
        //        if (dt != null && dt.Rows.Count > 0)
        //            unitValue = dt.Rows[0][AppDataName.ULV_ValueUnit].ToString() + "," + dt.Rows[0][AppDataName.ULV_SuitDateS].ToString();
        //        else
        //            unitValue = "0," + Q_Date;

        //        return unitValue;
        //    }
        //    catch (Exception ex)
        //    {
        //        string errmsg = "找不到土地公告地價資料 : " + ex.Message;
        //        return errmsg;
        //    }
        //}

        //[HttpGet]
        //public JsonResult AJAX_KeepUnit(string OrgId)
        //{
        //    try
        //    {
        //        var dt = NsDmHelper.UM_KeepUnit
        //          .where(t =>
        //              t.UMKU_EnterOrgId == OrgId.toConstReq1())
        //          .query().ToList().toDictionaryList();
        //        var res = Json(dt, JsonRequestBehavior.AllowGet);
        //        return res;

        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Result = "ERROR", Message = ex.Message });
        //    }
        //}

        //[HttpGet]
        //public JsonResult AJAX_Employee(string OrgId)
        //{
        //    try
        //    {
        //        var dt = NsDmHelper.EO_Employee
        //          .where(t =>
        //              t.EOE_OrganId == OrgId.toConstReq1())
        //          .query().ToList().toDictionaryList();
        //        var res = Json(dt, JsonRequestBehavior.AllowGet);
        //        return res;

        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Result = "ERROR", Message = ex.Message });
        //    }
        //}
    }
}
