﻿using System;
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
using ftd.mvc.Areas.EO.Controllers;
using ftd.mvc.Controllers;

namespace ftd.mvc.Areas.EO.Controllers
{
    public class EoPermissionSettingController : AppBaseController
    {
        public ActionResult CodeQuery(FormCollection collection)
        {
            var qm = new EoPermissionSettingQryModel();
            var bln = this.TryUpdateModel(qm);
            ViewBag.RequestKey = qm.RequestKey;
            return View(qm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult List(FormCollection collection, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            //查詢參數
            var qm = new EoPermissionSettingQryModel();
            var isOK = this.TryUpdateModel(qm);
            var token = collection["__RequestVerificationToken"];

            var dt = EoDataService.Instance.EoPermissionSetting_getList(qm);

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

        ////[ValidateAntiForgeryToken]
        //public ActionResult Edit(string id)
        //{
        //    var viewMode = "update";
        //    EO_PermissionSettingRow row = null;
        //    if (id.isNullOrEmpty())
        //    {
        //        row = EoDataService.Instance.EoPermissionSetting_create().FirstRow;
        //        viewMode = "create";
        //    }
        //    else
        //    {
        //        row = EoDataService.Instance.EoPermissionSetting_getById(id).FirstRow;
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
            var id = collection[AppDataName.EOPS_PermissionSettingId];
            var msgOK = "OK";

            EO_PermissionSettingDataTable dt = null;
            EO_PermissionSettingRow row = null;
            try
            {
                if (mode.equalIgnoreCase("create"))
                {
                    dt = EoDataService.Instance.EoPermissionSetting_create();
                    msgOK = FtdStatus.InsertSuccess.ToString();
                }
                else
                {
                    //找出該筆資料
                    dt = EoDataService.Instance.EoPermissionSetting_getById(id);
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
                    var errors = ModelState.Values.Where(x => x.Errors.Count > 0).SelectMany(x => x.Errors.Select(y => y.ErrorMessage)).ToArray();
                    return Json(new { Result = jTable_ERROR_CODE, Message = string.Join("<br/>", errors) });
                }

                #region //驗證欄位
                List<string> lstError = new List<string>();

                if (row.EOPS_PermissionSettingId.isNullOrEmpty())
                {
                    lstError.Add("授權ID不能為空");
                }
                if (row.EOPS_PermissionUserId.isNullOrEmpty())
                {
                    lstError.Add("授權對象(人)ID不能為空");
                }
                if (row.EOPS_PermissionId.isNullOrEmpty())
                {
                    lstError.Add("權限ID不能為空");
                }

                //回傳錯誤訊息
                if (lstError.Count > 0)
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = string.Join("<br/>", lstError.ToArray()) });
                }
                //檢查鍵值是否重覆
                if (EoDataService.Instance.EoPermissionSetting_checkDuplicate(row.EOPS_PermissionSettingId, row.EOPS_PermissionUserId, row.EOPS_PermissionId))
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = "授權已存在" });
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
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(FormCollection collection)
        {
            //var token = collection["__RequestVerificationToken"];
            var id = collection[AppDataName.EOPS_PermissionSettingId];

            try
            {
                var result = EoDataService.Instance.EoPermissionSetting_deleteBatch(new[] { id });
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
