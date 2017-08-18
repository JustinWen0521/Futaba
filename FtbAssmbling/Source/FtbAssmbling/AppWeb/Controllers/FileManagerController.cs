using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ftd.nsql;
using ftd.data;
using ftd.mvc.Extensions;
using ftd.service;

namespace ftd.mvc.Controllers
{
    public class FileManagerController : AppBaseController
    {
        //支援圖檔格式
        private const string IMAGE_EXT = "GIF|JPG|JPEG|BMP|PNG|TIF|TIFF|GPEG";

        #region //一般檔案上傳
        [HttpPost]
        public ActionResult Upload(string sys, string objectId, string groupCode, HttpPostedFileBase file)
        {
            //if (Request.Files == null || Request.Files.Count == 0)
            //    return Json(new { Result = "ERROR", Message = "檔案內為空" });

            //HttpPostedFileBase file = Request.Files[0] as HttpPostedFileBase;
            if (file == null || file.ContentLength == 0)
            {
                return Json(new { Result = "ERROR", Message = "檔案內為空" });
            }

            switch (sys.ToUpper())
            {
                case "UL":
                    return saveFileUL(objectId, groupCode, file);
                case "UB":
                    return saveFileUB(objectId, groupCode, file);
                case "UF":
                    return saveFileUF(objectId, groupCode, file);
                case "UM":
                    return saveFileUM(objectId, groupCode, file);
                case "UN":
                    return saveFileUN(objectId, groupCode, file);
                case "UR":
                    return saveFileUR(objectId, groupCode, file);
                case "UV":
                    return saveFileUV(objectId, groupCode, file);
                case "US":
                    return saveFileUS(objectId, groupCode, file);
                case "SY":
                    return saveFileSY(objectId, groupCode, file);
                default:
                    return Json(new { Result = "ERROR", Message = "系統別錯誤" });
            }
        }

        //儲存檔案 - 土地
        private ActionResult saveFileUL(string objId, string groupCode, HttpPostedFileBase file)
        {
            return Json(new { Result = "OK", Message = "上傳成功" }); 
        }

        //儲存檔案 - 建物
        private ActionResult saveFileUB(string objId, string groupCode, HttpPostedFileBase file)
        {
            return Json(new { Result = "OK", Message = "上傳成功" }); 
        }

        //儲存檔案 - 土地改良物
        private ActionResult saveFileUF(string objId, string groupCode, HttpPostedFileBase file)
        {
            return Json(new { Result = "OK", Message = "上傳成功" });
        }

        //儲存檔案 - 動產
        private ActionResult saveFileUM(string objId, string groupCode, HttpPostedFileBase file)
        {
            return Json(new { Result = "OK", Message = "上傳成功" });
        }

        //儲存檔案 - 非消耗
        private ActionResult saveFileUN(string objId, string groupCode, HttpPostedFileBase file)
        {
            return Json(new { Result = "OK", Message = "上傳成功" });
        }

        //儲存檔案 - 權利
        private ActionResult saveFileUR(string objId, string groupCode, HttpPostedFileBase file)
        {
            return Json(new { Result = "OK", Message = "上傳成功" });
        }

        //儲存檔案 - 有價證券
        private ActionResult saveFileUV(string objId, string groupCode, HttpPostedFileBase file)
        {
            return Json(new { Result = "OK", Message = "上傳成功" });
        }

        //儲存檔案 - 電腦軟體
        private ActionResult saveFileUS(string objId, string groupCode, HttpPostedFileBase file)
        {
            return Json(new { Result = "OK", Message = "上傳成功" });
        }

        //儲存檔案 - 系統
        private ActionResult saveFileSY(string objId, string groupCode, HttpPostedFileBase file)
        {
            try
            {
                //var downSizeWidth = 1024; //int.Parse(FtdConfigService.Instance.getAppSettingValue("DownSizeWidth", "1024"));
                //var donwSizeFormat = FtdConfigService.Instance.getAppSettingValue("DonwSizeFormat", IMAGE_EXT).Split('|').Select(x => x.ToUpper()).ToArray();

                //var fileName = file.FileName;
                //var inputStream = file.InputStream;
                //var fileSize = file.ContentLength;
                //var fileType = file.ContentType; //getContentTypeForFileName(fileName);
                //byte[] rawData = inputStream.getBytes();
                //string ext = System.IO.Path.GetExtension(fileName).Replace(".", "");

                //if (donwSizeFormat.Contains(ext.ToUpper()))
                //{
                //    //圖檔-->縮圖
                //    rawData = Help.DownSize(rawData, downSizeWidth, ext);
                //}
                //else
                //{
                //    //非圖檔-->壓縮成 zip
                //    rawData = Help.ZipFile(rawData, fileName);
                //    fileName = fileName + ".zip";
                //}

                //var dt = new SY_AttachFileDataTable();
                //var row = dt.newTypedRow();
                //row.ns_AssignNewId();
                //row.SYAF_ObjectId = objId;
                //row.SYAF_FileName = fileName;
                //row.SYAF_FileType = file.ContentType;
                //row.SYAF_FileSize = rawData.Length;
                //row.SYAF_RawData = rawData;
                //dt.Rows.Add(row);
                //dt.ns_update();

                //if (fileName.EndsWith(".zip"))
                //    fileName = fileName.Remove(fileName.Length - 4);

                //var fileInfo = new
                //{
                //    FileId = row.SYAF_AttachFileId,
                //    GroupCode = row.SYAF_GroupCode,
                //    FileName = fileName,
                //    FileType = row.SYAF_FileType,
                //    FileSize = row.SYAF_FileSize
                //};
                //return Json(new { Result = "OK", Message = "上傳成功", File = fileInfo });
                return Json(new { Result = "OK", Message = "上傳成功" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = "存檔失敗" });
            }
        }
        #endregion

        #region //圖檔上傳
        [HttpPost]
        public ActionResult UploadImage(string sys, string objectId, string groupCode, string fileName, string base64)
        {
            if (base64.isNullOrEmpty())
                return Json(new { Result = "ERROR", Message = "檔案內為空" });
            
            if (fileName.isNullOrEmpty())
                return Json(new { Result = "ERROR", Message = "無法辨識檔案類型" });

            switch (sys.ToUpper())
            {
                case "UL":
                    return saveImageUL(objectId, groupCode, fileName, base64);
                case "UB":
                    return saveImageUB(objectId, groupCode, fileName, base64);
                case "UF":
                    return saveImageUF(objectId, groupCode, fileName, base64);
                case "UM":
                    return saveImageUM(objectId, groupCode, fileName, base64);
                case "UN":
                    return saveImageUN(objectId, groupCode, fileName, base64);
                case "UR":
                    return saveImageUR(objectId, groupCode, fileName, base64);
                case "UV":
                    return saveImageUV(objectId, groupCode, fileName, base64);
                case "US":
                    return saveImageUS(objectId, groupCode, fileName, base64);
                case "SY":
                    return saveImageSY(objectId, groupCode, fileName, base64);
                default:
                    return Json(new { Result = "ERROR", Message = "系統別錯誤" });
            }
        }

        //儲存圖檔 - 土地
        private ActionResult saveImageUL(string objId, string groupCode, string fileName, string base64)
        {
            return Json(new { Result = "OK", Message = "上傳成功" });
        }

        //儲存圖檔 - 建物
        private ActionResult saveImageUB(string objId, string groupCode, string fileName, string base64)
        {
            return Json(new { Result = "OK", Message = "上傳成功" });
        }

        //儲存圖檔 - 土地改良物
        private ActionResult saveImageUF(string objId, string groupCode, string fileName, string base64)
        {
            return Json(new { Result = "OK", Message = "上傳成功" });
        }

        //儲存圖檔 - 動產
        private ActionResult saveImageUM(string objId, string groupCode, string fileName, string base64)
        {
            return Json(new { Result = "OK", Message = "上傳成功" });
        }

        //儲存圖檔 - 非消耗
        private ActionResult saveImageUN(string objId, string groupCode, string fileName, string base64)
        {
            return Json(new { Result = "OK", Message = "上傳成功" });
        }

        //儲存圖檔 - 權利
        private ActionResult saveImageUR(string objId, string groupCode, string fileName, string base64)
        {
            return Json(new { Result = "OK", Message = "上傳成功" });
        }

        //儲存圖檔 - 有價證券
        private ActionResult saveImageUV(string objId, string groupCode, string fileName, string base64)
        {
            return Json(new { Result = "OK", Message = "上傳成功" });
        }

        //儲存圖檔 - 電腦軟體
        private ActionResult saveImageUS(string objId, string groupCode, string fileName, string base64)
        {
            return Json(new { Result = "OK", Message = "上傳成功" });
        }

        //儲存圖檔 - 系統
        private ActionResult saveImageSY(string objId, string groupCode, string fileName, string base64)
        {
            try
            {
                //var downSizeWidth = 1024; //int.Parse(FtdConfigService.Instance.getAppSettingValue("DownSizeWidth", "1024"));
                //var donwSizeFormat = FtdConfigService.Instance.getAppSettingValue("DonwSizeFormat", IMAGE_EXT).Split('|').Select(x => x.ToUpper()).ToArray();

                //byte[] rawData = Convert.FromBase64String(base64);
                //var fileType = getContentTypeForFileName(fileName);
                //var fileSize = rawData.Length;
                //string ext = System.IO.Path.GetExtension(fileName).Replace(".", "");

                //if (donwSizeFormat.Contains(ext.ToUpper()))
                //{
                //    //圖檔-->縮圖
                //    rawData = Help.DownSize(rawData, downSizeWidth, ext);
                //}
                //else
                //{
                //    //非圖檔-->壓縮成 zip
                //    rawData = Help.ZipFile(rawData, fileName);
                //    fileName = fileName + ".zip";
                //}

                //var dt = new SY_AttachFileDataTable();
                //var row = dt.newTypedRow();
                //row.ns_AssignNewId();
                //row.SYAF_ObjectId = objId;
                //row.SYAF_FileName = fileName;
                //row.SYAF_FileType = fileType;
                //row.SYAF_FileSize = rawData.Length;
                //row.SYAF_RawData = rawData;
                //dt.Rows.Add(row);
                //dt.ns_update();

                //var fileInfo = new
                //{ 
                //    FileId = row.SYAF_AttachFileId, 
                //    GroupCode = row.SYAF_GroupCode,
                //    FileName = row.SYAF_FileName,
                //    FileType = row.SYAF_FileType,
                //    FileSize = row.SYAF_FileSize
                //};
                //return Json(new { Result = "OK", Message = "上傳成功", File = fileInfo });
                return Json(new { Result = "OK", Message = "上傳成功" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = "存檔失敗" });
            }
        }
        #endregion

        #region //取得指定物件所屬檔案清單
        public ActionResult GetFileList(string sys, string objectId, string groupCode)
        {
            switch (sys.ToUpper())
            {
                case "UL":
                    return getFileListUL(objectId, groupCode);
                case "UB":
                    return getFileListUB(objectId, groupCode);
                case "UF":
                    return getFileListUF(objectId, groupCode);
                case "UM":
                    return getFileListUM(objectId, groupCode);
                case "UN":
                    return getFileListUN(objectId, groupCode);
                case "UR":
                    return getFileListUR(objectId, groupCode);
                case "UV":
                    return getFileListUV(objectId, groupCode);
                case "US":
                    return getFileListUS(objectId, groupCode);
                case "SY":
                    return getFileListSY(objectId, groupCode);
                default:
                    return Json(new { Result = "ERROR", Message = "系統別錯誤" });
            }
        }

        //取得指定物件所屬檔案清單 - 土地
        private ActionResult getFileListUL(string objId, string groupCode)
        {
            //var qry = new NsDbQuery();
            //qry.setSelect(s =>
            //{
            //    var t1 = s.from<UL_AttachFile>();

            //    s.select(
            //        t1.ULAF_AttachfileId.As("FileId"),
            //        t1.ULAF_Block.As("GroupCode"),
            //        t1.ULAF_Fname.As("FileName"),
            //        t1.ULAF_Ftype.As("FileType"),
            //        t1.ULAF_Fsize.As("FileSize")
            //    );

            //    s.Where = t1.ULAF_MasterId == objId.toConstReq1();

            //    s.orderBy(
            //        t1.ULAF_Block.Asc,
            //        t1.ULAF_Fname.Asc
            //    );
            //});
            //var dt = qry.queryData();

            //foreach (DataRow row in dt.Rows)
            //{
            //    var fileName = row["FileName"].ToString();
            //    if (fileName.EndsWith(".zip"))
            //        fileName = fileName.Remove(fileName.Length - 4);

            //    row["FileName"] = fileName;
            //}
            //dt.AcceptChanges();

            //var list = dt.toDictionaryList();
            //var jsonData = new
            //{
            //    Result = "OK",
            //    Files = list,
            //    Count = list.Count
            //};
            //return Json(jsonData);
            return Json(new { Result = "OK", Message = "無檔案" });
        }

        //取得指定物件所屬檔案清單 - 建物
        private ActionResult getFileListUB(string objId, string groupCode)
        {
            //var qry = new NsDbQuery();
            //qry.setSelect(s =>
            //{
            //    var t1 = s.from<UB_AttachFile>();

            //    s.select(
            //        t1.UBAF_AttachFileId.As("FileId"),
            //        t1.UBAF_Block.As("GroupCode"),
            //        t1.UBAF_Fname.As("FileName"),
            //        t1.UBAF_Ftype.As("FileType"),
            //        t1.UBAF_Fsize.As("FileSize")
            //    );

            //    s.Where = t1.UBAF_MasterId == objId.toConstReq1();

            //    s.orderBy(
            //        t1.UBAF_Block.Asc,
            //        t1.UBAF_Fname.Asc
            //    );
            //});
            //var dt = qry.queryData();

            //foreach (DataRow row in dt.Rows)
            //{
            //    var fileName = row["FileName"].ToString();
            //    if (fileName.EndsWith(".zip"))
            //        fileName = fileName.Remove(fileName.Length - 4);

            //    row["FileName"] = fileName;
            //}
            //dt.AcceptChanges();

            //var list = dt.toDictionaryList();
            //var jsonData = new
            //{
            //    Result = "OK",
            //    Files = list,
            //    Count = list.Count
            //};
            //return Json(jsonData);
            return Json(new { Result = "OK", Message = "無檔案" });
        }

        //取得指定物件所屬檔案清單 - 土地改良物
        private ActionResult getFileListUF(string objId, string groupCode)
        {
            //var qry = new NsDbQuery();
            //qry.setSelect(s =>
            //{
            //    var t1 = s.from<UF_AttachFile>();

            //    s.select(
            //        t1.UFAF_AttachfileId.As("FileId"),
            //        t1.UFAF_Block.As("GroupCode"),
            //        t1.UFAF_Fname.As("FileName"),
            //        t1.UFAF_Ftype.As("FileType"),
            //        t1.UFAF_Fsize.As("FileSize")
            //    );

            //    s.Where = t1.UFAF_MasterId == objId.toConstReq1();

            //    s.orderBy(
            //        t1.UFAF_Block.Asc,
            //        t1.UFAF_Fname.Asc
            //    );
            //});
            //var dt = qry.queryData();

            //foreach (DataRow row in dt.Rows)
            //{
            //    var fileName = row["FileName"].ToString();
            //    if (fileName.EndsWith(".zip"))
            //        fileName = fileName.Remove(fileName.Length - 4);

            //    row["FileName"] = fileName;
            //}
            //dt.AcceptChanges();

            //var list = dt.toDictionaryList();
            //var jsonData = new
            //{
            //    Result = "OK",
            //    Files = list,
            //    Count = list.Count
            //};
            //return Json(jsonData);
            return Json(new { Result = "OK", Message = "無檔案" });
        }

        //取得指定物件所屬檔案清單 - 動產
        private ActionResult getFileListUM(string objId, string groupCode)
        {
            //var qry = new NsDbQuery();
            //qry.setSelect(s =>
            //{
            //    var t1 = s.from<UM_AttachFile>();

            //    s.select(
            //        t1.UMAF_AttachFileId.As("FileId"),
            //        "".toConst().As("GroupCode"),
            //        t1.UMAF_FName.As("FileName"),
            //        t1.UMAF_FType.As("FileType"),
            //        t1.UMAF_FSize.As("FileSize")
            //    );

            //    s.Where = t1.UMAF_MovableId == objId.toConstReq1();

            //    s.orderBy(
            //        t1.UMAF_FName.Asc
            //    );
            //});
            //var dt = qry.queryData();

            //foreach (DataRow row in dt.Rows)
            //{
            //    var fileName = row["FileName"].ToString();
            //    if (fileName.EndsWith(".zip"))
            //        fileName = fileName.Remove(fileName.Length - 4);

            //    row["FileName"] = fileName;
            //}
            //dt.AcceptChanges();

            //var list = dt.toDictionaryList();
            //var jsonData = new
            //{
            //    Result = "OK",
            //    Files = list,
            //    Count = list.Count
            //};
            //return Json(jsonData);
            return Json(new { Result = "OK", Message = "無檔案" });
        }

        //取得指定物件所屬檔案清單 - 非消耗
        private ActionResult getFileListUN(string objId, string groupCode)
        {
            //var qry = new NsDbQuery();
            //qry.setSelect(s =>
            //{
            //    var t1 = s.from<UN_AttachFile>();

            //    s.select(
            //        t1.UNAF_AttachFileId.As("FileId"),
            //        t1.UNAF_Block.As("GroupCode"),
            //        t1.UNAF_Fname.As("FileName"),
            //        t1.UNAF_Ftype.As("FileType"),
            //        t1.UNAF_Fsize.As("FileSize")
            //    );

            //    s.Where = t1.UNAF_MasterId == objId.toConstReq1();

            //    s.orderBy(
            //        t1.UNAF_Block.Asc,
            //        t1.UNAF_Fname.Asc
            //    );
            //});
            //var dt = qry.queryData();

            //foreach (DataRow row in dt.Rows)
            //{
            //    var fileName = row["FileName"].ToString();
            //    if (fileName.EndsWith(".zip"))
            //        fileName = fileName.Remove(fileName.Length - 4);

            //    row["FileName"] = fileName;
            //}
            //dt.AcceptChanges();

            //var list = dt.toDictionaryList();
            //var jsonData = new
            //{
            //    Result = "OK",
            //    Files = list,
            //    Count = list.Count
            //};
            //return Json(jsonData);
            return Json(new { Result = "OK", Message = "無檔案" });
        }

        //取得指定物件所屬檔案清單 - 權利
        private ActionResult getFileListUR(string objId, string groupCode)
        {
            return Json(new { Result = "OK", Message = "無檔案" });
        }

        //取得指定物件所屬檔案清單 - 有價證券
        private ActionResult getFileListUV(string objId, string groupCode)
        {
            return Json(new { Result = "OK", Message = "無檔案" });
        }

        //取得指定物件所屬檔案清單 - 電腦軟體
        private ActionResult getFileListUS(string objId, string groupCode)
        {
            //var qry = new NsDbQuery();
            //qry.setSelect(s =>
            //{
            //    var t1 = s.from<US_AttachFile>();

            //    s.select(
            //        t1.USAF_AttachFileId.As("FileId"),
            //        t1.USAF_Block.As("GroupCode"),
            //        t1.USAF_FName.As("FileName"),
            //        t1.USAF_FType.As("FileType"),
            //        t1.USAF_FSize.As("FileSize")
            //    );

            //    s.Where = t1.USAF_MasterId == objId.toConstReq1();

            //    s.orderBy(
            //        t1.USAF_Block.Asc,
            //        t1.USAF_FName.Asc
            //    );
            //});
            //var dt = qry.queryData();

            //foreach (DataRow row in dt.Rows)
            //{
            //    var fileName = row["FileName"].ToString();
            //    if (fileName.EndsWith(".zip"))
            //        fileName = fileName.Remove(fileName.Length - 4);

            //    row["FileName"] = fileName;
            //}
            //dt.AcceptChanges();

            //var list = dt.toDictionaryList();
            //var jsonData = new
            //{
            //    Result = "OK",
            //    Files = list,
            //    Count = list.Count
            //};
            //return Json(jsonData);
            return Json(new { Result = "OK", Message = "無檔案" });
        }

        //取得指定物件所屬檔案清單 - 系統
        private ActionResult getFileListSY(string objId, string groupCode)
        {
            //var qry = new NsDbQuery();
            //qry.setSelect(s =>
            //{
            //    var t1 = s.from<SY_AttachFile>();

            //    s.select(
            //        t1.SYAF_AttachFileId.As("FileId"),
            //        t1.SYAF_GroupCode.As("GroupCode"),
            //        t1.SYAF_FileName.As("FileName"),
            //        t1.SYAF_FileType.As("FileType"),
            //        t1.SYAF_FileSize.As("FileSize")
            //    );

            //    s.Where = t1.SYAF_ObjectId == objId.toConstReq1();

            //    s.orderBy(
            //        t1.SYAF_GroupCode.Asc,
            //        t1.SYAF_FileName.Asc
            //    );
            //});
            //var dt = qry.queryData();

            //foreach (DataRow row in dt.Rows)
            //{
            //    var fileName = row["FileName"].ToString();
            //    if (fileName.EndsWith(".zip"))
            //        fileName = fileName.Remove(fileName.Length - 4);

            //    row["FileName"] = fileName;
            //}
            //dt.AcceptChanges();

            //var list = dt.toDictionaryList();
            //var jsonData = new
            //{
            //    Result = "OK",
            //    Files = list,
            //    Count = list.Count
            //};
            //return Json(jsonData);
            return Json(new { Result = "OK", Message = "無檔案" });
        }
        #endregion 

        #region //下載檔案
        public ActionResult Download(string sys, string fileId)
        {
            switch (sys.ToUpper())
            {
                case "UL":
                    return downloadUL(fileId);
                case "UB":
                    return downloadUB(fileId);
                case "UF":
                    return downloadUF(fileId);
                case "UM":
                    return downloadUM(fileId);
                case "UN":
                    return downloadUN(fileId);
                case "UR":
                    return downloadUR(fileId);
                case "UV":
                    return downloadUV(fileId);
                case "US":
                    return downloadUS(fileId);
                case "SY":
                    return downloadSY(fileId);
                default:
                    return Json(new { Result = "ERROR", Message = "系統別錯誤" }, JsonRequestBehavior.AllowGet);
            }
        }

        //下載檔案 - 土地
        private ActionResult downloadUL(string fileId)
        {
            //var file = NsDmHelper.UL_AttachFile
            //    .selectAll()
            //    .wherepk(fileId)
            //    .queryFirst();

            //if (file == null)
            //    return Json(new { Result = "ERROR", Message = "檔案不存在" }, JsonRequestBehavior.AllowGet);

            //if (file.ULAF_RawData == null || file.ULAF_RawData.Length == 0)
            //    return Json(new { Result = "ERROR", Message = "檔案為空" }, JsonRequestBehavior.AllowGet);

            //var rawData = file.ULAF_RawData;
            //var fileName = file.ULAF_Fname;
            //if (fileName.EndsWith(".zip"))
            //{
            //    rawData = Help.UnZipFiles(rawData, "");
            //    fileName = fileName.Remove(fileName.Length - 4);
            //}
            //return File(rawData, file.ULAF_Ftype, fileName);
            return Json(new { Result = "ERROR", Message = "檔案不存在" }, JsonRequestBehavior.AllowGet);
        }

        //下載檔案 - 建物
        private ActionResult downloadUB(string fileId)
        {
            //var file = NsDmHelper.UB_AttachFile
            //    .selectAll()
            //    .wherepk(fileId)
            //    .queryFirst();

            //if (file == null)
            //    return Json(new { Result = "ERROR", Message = "檔案不存在" }, JsonRequestBehavior.AllowGet);

            //if (file.UBAF_RawData == null || file.UBAF_RawData.Length == 0)
            //    return Json(new { Result = "ERROR", Message = "檔案為空" }, JsonRequestBehavior.AllowGet);

            //var rawData = file.UBAF_RawData;
            //var fileName = file.UBAF_Fname;
            //if (fileName.EndsWith(".zip"))
            //{
            //    rawData = Help.UnZipFiles(rawData, "");
            //    fileName = fileName.Remove(fileName.Length - 4);
            //}
            //return File(rawData, file.UBAF_Ftype, fileName);
            return Json(new { Result = "ERROR", Message = "檔案不存在" }, JsonRequestBehavior.AllowGet);
        }

        //下載檔案 - 土地改良物
        private ActionResult downloadUF(string fileId)
        {
            //var file = NsDmHelper.UF_AttachFile
            //    .selectAll()
            //    .wherepk(fileId)
            //    .queryFirst();

            //if (file == null)
            //    return Json(new { Result = "ERROR", Message = "檔案不存在" }, JsonRequestBehavior.AllowGet);

            //if (file.UFAF_RawData == null || file.UFAF_RawData.Length == 0)
            //    return Json(new { Result = "ERROR", Message = "檔案為空" }, JsonRequestBehavior.AllowGet);

            //var rawData = file.UFAF_RawData;
            //var fileName = file.UFAF_Fname;
            //if (fileName.EndsWith(".zip"))
            //{
            //    rawData = Help.UnZipFiles(rawData, "");
            //    fileName = fileName.Remove(fileName.Length - 4);
            //}
            //return File(rawData, file.UFAF_Ftype, fileName);
            return Json(new { Result = "ERROR", Message = "檔案不存在" }, JsonRequestBehavior.AllowGet);
        }

        //下載檔案 - 動產
        private ActionResult downloadUM(string fileId)
        {
            //var file = NsDmHelper.UM_AttachFile
            //    .selectAll()
            //    .wherepk(fileId)
            //    .queryFirst();

            //if (file == null)
            //    return Json(new { Result = "ERROR", Message = "檔案不存在" }, JsonRequestBehavior.AllowGet);

            //if (file.UMAF_RawData == null || file.UMAF_RawData.Length == 0)
            //    return Json(new { Result = "ERROR", Message = "檔案為空" }, JsonRequestBehavior.AllowGet);

            //var rawData = file.UMAF_RawData;
            //var fileName = file.UMAF_FName;
            //if (fileName.EndsWith(".zip"))
            //{
            //    rawData = Help.UnZipFiles(rawData, "");
            //    fileName = fileName.Remove(fileName.Length - 4);
            //}
            //return File(rawData, file.UMAF_FType, fileName);
            return Json(new { Result = "ERROR", Message = "檔案不存在" }, JsonRequestBehavior.AllowGet);
        }

        //下載檔案 - 非消耗
        private ActionResult downloadUN(string fileId)
        {
            //var file = NsDmHelper.UN_AttachFile
            //    .selectAll()
            //    .wherepk(fileId)
            //    .queryFirst();

            //if (file == null)
            //    return Json(new { Result = "ERROR", Message = "檔案不存在" }, JsonRequestBehavior.AllowGet);

            //if (file.UNAF_RawData == null || file.UNAF_RawData.Length == 0)
            //    return Json(new { Result = "ERROR", Message = "檔案為空" }, JsonRequestBehavior.AllowGet);

            //var rawData = file.UNAF_RawData;
            //var fileName = file.UNAF_Fname;
            //if (fileName.EndsWith(".zip"))
            //{
            //    rawData = Help.UnZipFiles(rawData, "");
            //    fileName = fileName.Remove(fileName.Length - 4);
            //}
            //return File(rawData, file.UNAF_Ftype, fileName);
            return Json(new { Result = "ERROR", Message = "檔案不存在" }, JsonRequestBehavior.AllowGet);
        }

        //下載檔案 - 權利
        private ActionResult downloadUR(string fileId)
        {
            return Json(new { Result = "ERROR", Message = "檔案不存在" }, JsonRequestBehavior.AllowGet);
        }

        //下載檔案 - 有價證券
        private ActionResult downloadUV(string fileId)
        {
            return Json(new { Result = "ERROR", Message = "檔案不存在" }, JsonRequestBehavior.AllowGet);
        }

        //下載檔案 - 電腦軟體
        private ActionResult downloadUS(string fileId)
        {
            //var file = NsDmHelper.US_AttachFile
            //    .selectAll()
            //    .wherepk(fileId)
            //    .queryFirst();

            //if (file == null)
            //    return Json(new { Result = "ERROR", Message = "檔案不存在" }, JsonRequestBehavior.AllowGet);

            //if (file.USAF_RawData == null || file.USAF_RawData.Length == 0)
            //    return Json(new { Result = "ERROR", Message = "檔案為空" }, JsonRequestBehavior.AllowGet);

            //var rawData = file.USAF_RawData;
            //var fileName = file.USAF_FName;
            //if (fileName.EndsWith(".zip"))
            //{
            //    rawData = Help.UnZipFiles(rawData, "");
            //    fileName = fileName.Remove(fileName.Length - 4);
            //}
            //return File(rawData, file.USAF_FType, fileName);
            return Json(new { Result = "ERROR", Message = "檔案不存在" }, JsonRequestBehavior.AllowGet);
        }

        //下載檔案 - 系統
        private ActionResult downloadSY(string fileId)
        {
            //var file = NsDmHelper.SY_AttachFile
            //    .selectAll()
            //    .wherepk(fileId)
            //    .queryFirst();

            //if (file == null)
            //    return Json(new { Result = "ERROR", Message = "檔案不存在" }, JsonRequestBehavior.AllowGet);

            //if (file.SYAF_RawData == null || file.SYAF_RawData.Length == 0)
            //    return Json(new { Result = "ERROR", Message = "檔案為空" }, JsonRequestBehavior.AllowGet);

            //var rawData = file.SYAF_RawData;
            //var fileName = file.SYAF_FileName;
            //if (fileName.EndsWith(".zip"))
            //{
            //    rawData = Help.UnZipFiles(rawData, "");
            //    fileName = fileName.Remove(fileName.Length - 4);
            //}
            //return File(rawData, file.SYAF_FileType, fileName);
            return Json(new { Result = "ERROR", Message = "檔案不存在" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region //刪除檔案
        public ActionResult Delete(string sys, string fileId)
        {
            switch (sys.ToUpper())
            {
                case "UL":
                    return deleteUL(fileId);
                case "UB":
                    return deleteUB(fileId);
                case "UF":
                    return deleteUF(fileId);
                case "UM":
                    return deleteUM(fileId);
                case "UN":
                    return deleteUN(fileId);
                case "UR":
                    return deleteUR(fileId);
                case "UV":
                    return deleteUV(fileId);
                case "US":
                    return deleteUS(fileId);
                case "SY":
                    return deleteSY(fileId);
                default:
                    return Json(new { Result = "ERROR", Message = "系統別錯誤" });
            }
        }

        //刪除檔案 - 土地
        private ActionResult deleteUL(string fileId)
        {
            try
            {
                //var dt = NsDmHelper.UL_AttachFile
                //    .select()
                //    .wherepk(fileId)
                //    .query();

                //dt.forEach(x => x.Delete());
                //dt.ns_update();
                return Json(new { Result = "OK", Message = "刪除成功" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = "刪除失敗" });
            }
        }

        //刪除檔案 - 建物
        private ActionResult deleteUB(string fileId)
        {
            try
            {
                //var dt = NsDmHelper.UB_AttachFile
                //    .select()
                //    .wherepk(fileId)
                //    .query();

                //dt.forEach(x => x.Delete());
                //dt.ns_update();
                return Json(new { Result = "OK", Message = "刪除成功" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = "刪除失敗" });
            }
        }

        //刪除檔案 - 土地改良物
        private ActionResult deleteUF(string fileId)
        {
            try
            {
                //var dt = NsDmHelper.UF_AttachFile
                //    .select()
                //    .wherepk(fileId)
                //    .query();

                //dt.forEach(x => x.Delete());
                //dt.ns_update();
                return Json(new { Result = "OK", Message = "刪除成功" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = "刪除失敗" });
            }
        }

        //刪除檔案 - 動產
        private ActionResult deleteUM(string fileId)
        {
            try
            {
                //var dt = NsDmHelper.UM_AttachFile
                //    .select()
                //    .wherepk(fileId)
                //    .query();

                //dt.forEach(x => x.Delete());
                //dt.ns_update();
                return Json(new { Result = "OK", Message = "刪除成功" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = "刪除失敗" });
            }
        }

        //刪除檔案 - 非消耗
        private ActionResult deleteUN(string fileId)
        {
            try
            {
                //var dt = NsDmHelper.UN_AttachFile
                //    .select()
                //    .wherepk(fileId)
                //    .query();

                //dt.forEach(x => x.Delete());
                //dt.ns_update();
                return Json(new { Result = "OK", Message = "刪除成功" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = "刪除失敗" });
            }
        }

        //刪除檔案 - 權利
        private ActionResult deleteUR(string fileId)
        {
            return Json(new { Result = "OK", Message = "刪除成功" });
        }

        //刪除檔案 - 有價證券
        private ActionResult deleteUV(string fileId)
        {
            return Json(new { Result = "OK", Message = "刪除成功" });
        }

        //刪除檔案 - 電腦軟體
        private ActionResult deleteUS(string fileId)
        {
            try
            {
                //var dt = NsDmHelper.US_AttachFile
                //    .select()
                //    .wherepk(fileId)
                //    .query();

                //dt.forEach(x => x.Delete());
                //dt.ns_update();
                return Json(new { Result = "OK", Message = "刪除成功" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = "刪除失敗" });
            }
        }

        //刪除檔案 - 系統
        private ActionResult deleteSY(string fileId)
        {
            try
            {
                //var dt = NsDmHelper.SY_AttachFile
                //    .select()
                //    .wherepk(fileId)
                //    .query();

                //dt.forEach(x => x.Delete());
                //dt.ns_update();
                return Json(new { Result = "OK", Message = "刪除成功" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = "刪除失敗" });
            }
        }
        #endregion
    }
}
