using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ftd.data;
using ftd.nsql;
using ftd.service;
using ftd.query.model;
using ftd.mvc.Extensions;
using ftd.mvc.Controllers;

namespace ftd.mvc.Areas.CR.Controllers
{
    public class CrCourseController : AppBaseController
    {
        #region [ CRM010 - CR_Course 課程 ]
        public ActionResult CRM010()
        {
            var qm = new CrRegistrationQryModel();
            return View(qm);
        }

        public ActionResult CRM010Edit(string id)
        {
            var viewMode = "update";
            CR_CourseRow row = null;
            if (id.isNullOrEmpty())
            {
                row = CrDataService.Instance.CrCourse_create().FirstRow;
                viewMode = "create";
            }
            else
            {
                row = CrDataService.Instance.CrCourse_getById(id).FirstRow;
                viewMode = "update";
            }
            ViewBag.ViewMode = viewMode;
            return View(row);
        }
        #endregion

        #region [ CRM011 - CR_Class 班別 ]
        //public ActionResult CRM011()
        //{
        //    var qm = new CrRegistrationQryModel();
        //    return View(qm);
        //}

        public ActionResult CRM011Edit(string id, string courseId)
        {
            var viewMode = "update";
            CR_ClassRow row = null;
            if (id.isNullOrEmpty())
            {
                row = CrDataService.Instance.CrClass_createWithCourseId(courseId).FirstRow;
                viewMode = "create";
            }
            else
            {
                row = CrDataService.Instance.CrClass_getById(id).FirstRow;
                viewMode = "update";
            }
            ViewBag.ViewMode = viewMode;
            return View(row);
        }

        public ActionResult CRM011Copy(string classId)
        {
            var srcRow = CrDataService.Instance.CrClass_getById(classId).FirstRow;
            //if (srcRow == null)
            //{
            //    var qm = new CrRegistrationQryModel();
            //    qm.ClientMessage = "找不到來源資料";
            //}
            CR_ClassRow row = null;
            if (srcRow != null)
            {
                row = CrDataService.Instance.CrClass_create().FirstRow;
                row.CRCL_CourseId = srcRow.CRCL_CourseId;
                row.CRCL_CourseCode_XX = srcRow.CRCL_CourseCode_XX;
                row.CRCL_CourseName_XX = srcRow.CRCL_CourseName_XX;
                row.CRCL_CourseDesc_XX = srcRow.CRCL_CourseDesc_XX;
                row.CRCL_CourseEnable_XX = srcRow.CRCL_CourseEnable_XX;
                row.CRCL_CourseEnableName_XX = srcRow.CRCL_CourseEnableName_XX;
                row.CRCL_StartDate_XX = srcRow.CRCL_StartDate_XX;
                row.CRCL_EndDate_XX = srcRow.CRCL_EndDate_XX;
                //row.CRCL_Code = srcRow.CRCL_Code;
                row.CRCL_ClassDate = srcRow.CRCL_ClassDate;
                row.CRCL_ClassTime = srcRow.CRCL_ClassTime;
                row.CRCL_LimitQty = srcRow.CRCL_LimitQty;
                row.CRCL_Place = srcRow.CRCL_Place;
                row.CRCL_Address = srcRow.CRCL_Address;
                row.CRCL_RegisterQty_XX = srcRow.CRCL_RegisterQty_XX;
            }
            ViewBag.ViewMode = "create";
            return View("CRM011Edit", row);
        }
        #endregion

        #region [ CRM012 - CR_Registeration 報名資料 ]
        public ActionResult CRM012Edit(string id, string classId)
        {
            var viewMode = "update";
            CR_RegistrationRow row = null;
            if (id.isNullOrEmpty())
            {
                row = CrDataService.Instance.CrRegistration_createWithClassId(classId).FirstRow;
                viewMode = "create";
            }
            else
            {
                row = CrDataService.Instance.CrRegistration_getById(id).FirstRow;
                viewMode = "update";
            }
            ViewBag.ViewMode = viewMode;
            return View(row);
        }
        #endregion


        public ActionResult CodeQuery(FormCollection collection)
        {
            var qm = new CrRegistrationQryModel();
            var bln = this.TryUpdateModel(qm);
            ViewBag.RequestKey = qm.RequestKey;
            return View(qm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult List(FormCollection collection, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            //查詢參數
            var qm = new CrRegistrationQryModel();
            var isOK = this.TryUpdateModel(qm);
            var token = collection["__RequestVerificationToken"];

            var dt = CrDataService.Instance.CrCourse_getList(qm);

            //排序
            var dtSorted = dt.sort(jtSorting);

            if (Request.IsAjaxRequest())
            {
                //var data = jtPageSize > 0 ? dtSorted.Skip(jtStartIndex).Take(jtPageSize).ToList() : dtSorted.ToList();
                //var list = data.toDictionaryList();
                //var jsonData = new
                //{
                //    Result = jTable_SUCCESS_CODE,
                //    Records = list,
                //    TotalRecordCount = dtSorted.Count()
                //};
                //return Json(jsonData);
                return converToJTableSource(dtSorted, jtStartIndex, jtPageSize);
            }
            else
            {
                return View(dt);
            }
        }

        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(string id)
        //{
        //    var viewMode = "update";
        //    CR_CourseRow row = null;
        //    if (id.isNullOrEmpty())
        //    {
        //        row = CrDataService.Instance.CrCourse_create().FirstRow;
        //        viewMode = "create";
        //    }
        //    else
        //    {
        //        row = CrDataService.Instance.CrCourse_getById(id).FirstRow;
        //        viewMode = "update";
        //    }
        //    ViewBag.ViewMode = viewMode;
        //    return View(row);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection)
        {
            var token = collection["__RequestVerificationToken"];
            var mode = collection["ViewMode"];
            var id = collection[AppDataName.CRC_CourseId];
            var msgOK = "OK";

            CR_CourseDataTable dt = null;
            CR_CourseRow row = null;
            try
            {
                if (mode.equalIgnoreCase("create"))
                {
                    dt = CrDataService.Instance.CrCourse_create();
                    msgOK = FtdStatus.InsertSuccess.ToString();
                }
                else
                {
                    //找出該筆資料
                    dt = CrDataService.Instance.CrCourse_getById(id);
                    if (dt == null || dt.Count == 0)
                    {
                        return Json(new { Result = jTable_ERROR_CODE, Message = "資料不存在" });
                    }
                    msgOK = FtdStatus.UpdateSuccess.ToString();
                }

                //將Form sumit的資料更新至DataRow
                row = dt.FirstRow;
                var isOK = this.TryUpdateModel(row);

                //若驗證失敗-->回傳錯誤訊息
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = string.Join("<br/>", ModelState.Values) });
                }

                #region //驗證欄位
                List<string> lstError = new List<string>();
                if (row.CRC_CourseId.isNullOrEmpty())
                {
                    lstError.Add("課程ID不能為空");
                }
                if (row.CRC_Code.isNullOrEmpty())
                {
                    lstError.Add("課程代號不能為空");
                }
                if (row.CRC_Name.isNullOrEmpty())
                {
                    lstError.Add("課程名稱不能為空");
                }
                if (row.CRC_IsEnable.isNullOrEmpty())
                {
                    lstError.Add("啟用不能為空");
                }

                //回傳錯誤訊息
                if (lstError.Count > 0)
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = string.Join("<br/>", lstError.ToArray()) });
                }
                //檢查鍵值是否重覆
                if (CrDataService.Instance.CrCourse_cehckDuplicate(row.CRC_CourseId, row.CRC_Code))
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = "相同鍵值的資料已存在" });
                }
                #endregion

                dt.ns_update();
                dt.AcceptChanges();
                return Json(new { Result = msgOK }); 
            }
            catch (Exception ex)
            {
                return Json(new { Result = jTable_ERROR_CODE, Message = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(FormCollection collection)
        {
            var token = collection["__RequestVerificationToken"];
            var id = collection[AppDataName.CRC_CourseId];

            try
            {
                var result = CrDataService.Instance.CrCourse_deleteBatch(new[] { id });
                if (result)
                {
                    return Json(new { Result = jTable_SUCCESS_CODE });
                }
                else
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = "刪除資料失敗" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = jTable_ERROR_CODE, Message = ex.Message });
            }
        }

    }
}
