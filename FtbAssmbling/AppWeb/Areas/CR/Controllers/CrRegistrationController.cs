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
using ftd.web;

namespace ftd.mvc.Areas.CR.Controllers
{
    public class CrRegistrationController : AppBaseController
    {
        public ActionResult Index()
        {
            var qm = new CrRegistrationQryModel();
            qm.Q_CourseEnable = "Y";
            return View(qm);
        }

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

            var classId = qm.Q_ClassId;
            CR_RegistrationDataTable dt = null;
            if (!classId.isNullOrEmpty())
            {
                dt = CrDataService.Instance.CrRegistration_getListByClassId(classId);
            }
            else
            {
                dt = CrDataService.Instance.CrRegistration_getList(qm);
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

        //[ValidateAntiForgeryToken]
        public ActionResult Edit(string id, string classId)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection)
        {
            var token = collection["__RequestVerificationToken"];
            var mode = collection["ViewMode"];
            var id = collection[AppDataName.CRR_RegistrationId];
            var msg = "報名成功";

            CR_RegistrationDataTable dt = null;
            CR_RegistrationRow row = null;
            try
            {
                if (mode.equalIgnoreCase("create"))
                {
                    dt = CrDataService.Instance.CrRegistration_create();
                    msg = "報名成功";
                }
                else
                {
                    //找出該筆資料
                    dt = CrDataService.Instance.CrRegistration_getById(id);
                    if (dt == null || dt.Count == 0)
                    {
                        return Json(new { Result = jTable_ERROR_CODE, Message = "資料不存在" });
                    }
                    msg = "修改成功";
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
                if (row.CRR_CourseId_XX.isNullOrEmpty())
                {
                    lstError.Add("課程ID不能為空");
                }
                if (row.CRR_ClassId.isNullOrEmpty())
                {
                    lstError.Add("班別ID不能為空");
                }
                //if (row.CRR_CitizenId.isNullOrEmpty())
                //{
                //    lstError.Add("身分證不能為空");
                //}
                if (row.CRR_Name.isNullOrEmpty())
                {
                    lstError.Add("姓名不能為空");
                }
                if (row.CRR_OrganName.isNullOrEmpty())
                {
                    lstError.Add("單位名稱不能為空");
                }
                //if (row.CRR_FoodKind.isNullOrEmpty())
                //{
                //    lstError.Add("葷素不能為空");
                //}
                if (row.CRR_Tel.isNullOrEmpty())
                {
                    lstError.Add("聯絡電話不能為空");
                }

                //回傳錯誤訊息
                if (lstError.Count > 0)
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = string.Join("<br/>", lstError.ToArray()) });
                }

                //身分證驗證
                if (!row.CRR_CitizenId.isNullOrEmpty() && !row.CRR_CitizenId.verifyAsTwCitizenId())
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = "請輸入有效的身分證字號。" });
                }

                //檢查鍵值是否重覆
                if (CrDataService.Instance.CrRegistration_cehckDuplicate(row.CRR_RegistrationId, row.CRR_CourseId_XX, AppUserSession.User.LoginAccount, row.CRR_Name))
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = "同課程已報名。若要改報不同班別，請先取消原報名資料。" });
                }
                #endregion

                dt.ns_update();
                dt.AcceptChanges();
                return Json(new { Result = jTable_SUCCESS_CODE, Message = msg }); 
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
            var id = collection[AppDataName.CRR_RegistrationId];

            try
            {
                var result = CrDataService.Instance.CrRegistration_deleteBatch(new[] { id });
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

        //學員本人的報名清單
        public ActionResult UserList(FormCollection collection)
        {
            var qm = new CrRegistrationQryModel();
            var bln = this.TryUpdateModel(qm);
            qm.Q_CreatorCode_XX = AppUserSession.User.LoginAccount;
            ViewBag.RequestKey = qm.RequestKey;
            return View(qm);
        }

        //學員本人的報名清單
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserList(FormCollection collection, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            //查詢參數
            var qm = new CrRegistrationQryModel();
            var isOK = this.TryUpdateModel(qm);
            var token = collection["__RequestVerificationToken"];

            var theDate = DateTime.Today.toTwFormat("D");
            var classId = qm.Q_ClassId;
            var dt = NsDmHelper.CR_Registration
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.CRR_RegisterStartDate_XX <= theDate.toConstReq1()
                    & t.CRR_RegisterEndDate_XX >= theDate.toConstReq1()
                    & t.CRR_CreatorCode_XX == qm.Q_CreatorCode_XX.toConstReq1()
                    & t.CRR_Name == qm.Q_Name.toConstReq1()
                )
                .query();
            
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
    }
}
