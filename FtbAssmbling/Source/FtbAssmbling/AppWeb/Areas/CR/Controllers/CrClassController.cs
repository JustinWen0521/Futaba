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
    public class CrClassController : AppBaseController
    {
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

            var courseId = qm.Q_CourseId;
            CR_ClassDataTable dt = null;
            if (!courseId.isNullOrEmpty())
            {
                dt = CrDataService.Instance.CrClass_getListByCourseId(courseId);
            }
            else
            {
                dt = CrDataService.Instance.CrClass_getList(qm);
            }

            //排序
            var dtSorted = dt.sort(jtSorting);

            if (Request.IsAjaxRequest())
            {
                return converToJTableSource(dtSorted, jtStartIndex, jtPageSize);
            }
            else
            {
                return View(dt);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AvalibleList(FormCollection collection, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            //查詢參數
            var qm = new CrRegistrationQryModel();
            var isOK = this.TryUpdateModel(qm);
            var token = collection["__RequestVerificationToken"];

            var courseId = qm.Q_CourseId;
            var theDate = DateTime.Today.toTwFormat("D");
            var dt = NsDmHelper.CR_Class
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.CRCL_CourseEnable_XX == "Y"
                    & t.CRCL_RegisterStartDate_XX <= theDate
                    & t.CRCL_RegisterEndDate_XX >= theDate
                ).query();

            //排序
            var dtSorted = dt.sort(jtSorting);

            if (Request.IsAjaxRequest())
            {
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
        //    CR_ClassRow row = null;
        //    if (id.isNullOrEmpty())
        //    {
        //        row = CrDataService.Instance.CrClass_create().FirstRow;
        //        viewMode = "create";
        //    }
        //    else
        //    {
        //        row = CrDataService.Instance.CrClass_getById(id).FirstRow;
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
            var id = collection[AppDataName.CRCL_ClassId];
            var msgOK = "OK";

            CR_ClassDataTable dt = null;
            CR_ClassRow row = null;
            try
            {
                if (mode.equalIgnoreCase("create"))
                {
                    dt = CrDataService.Instance.CrClass_create();
                    msgOK = FtdStatus.InsertSuccess.ToString();
                }
                else
                {
                    //找出該筆資料
                    dt = CrDataService.Instance.CrClass_getById(id);
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
                if (row.CRCL_ClassId.isNullOrEmpty())
                {
                    lstError.Add("班別ID不能為空");
                }
                if (row.CRCL_CourseId.isNullOrEmpty())
                {
                    lstError.Add("課程ID不能為空");
                }
                if (row.CRCL_Code.isNullOrEmpty())
                {
                    lstError.Add("班別代號不能為空");
                }
                if (!row.CRCL_LimitQty.HasValue)
                {
                    lstError.Add("人數限制不能為空");
                }
                if (row.CRCL_ClassDate.isNullOrEmpty())
                {
                    lstError.Add("上課日期不能為空");
                }
                if (row.CRCL_ClassTime.isNullOrEmpty())
                {
                    lstError.Add("上課時間不能為空");
                }
                if (row.CRCL_Place.isNullOrEmpty())
                {
                    lstError.Add("上課地點不能為空");
                }
                if (row.CRCL_Address.isNullOrEmpty())
                {
                    lstError.Add("地址不能為空");
                }
                //回傳錯誤訊息
                if (lstError.Count > 0)
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = string.Join("<br/>", lstError.ToArray()) });
                }
                //檢查鍵值是否重覆
                if (CrDataService.Instance.CrClass_cehckDuplicate(row.CRCL_ClassId, row.CRCL_CourseId, row.CRCL_Code))
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
            var id = collection[AppDataName.CRCL_ClassId];

            try
            {
                var result = CrDataService.Instance.CrClass_deleteBatch(new[] { id });
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
