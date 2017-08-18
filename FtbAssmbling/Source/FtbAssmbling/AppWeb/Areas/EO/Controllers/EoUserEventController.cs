using System;
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

namespace ftd.mvc.Areas.EO.Controllers
{
    public class EoUserEventController : AppBaseController
    {
        // GET: /EoUserEvent/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /EoUserEvent/CodeQuery
        public ActionResult CodeQuery(string RequestKey)
        {
            ViewBag.RequestKey = RequestKey;
            return View();
        }

        // POST: /EoUserEvent/List
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult List(FormCollection collection, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            //查詢參數
            var qm = new EoUserEventQryModel();
            var isOK = this.TryUpdateModel(qm);
            var token = collection["__RequestVerificationToken"];

            var dt = EoDataService.Instance.EoUserEvent_getList(qm);

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

        // GET: /EoUserEvent/Edit/123
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(string id)
        {
            var viewMode = "update";
            EO_UserEventRow row = null;
            if (id.isNullOrEmpty())
            {
                row = EoDataService.Instance.EoUserEvent_create().FirstRow;
                viewMode = "create";
            }
            else
            {
                row = EoDataService.Instance.EoUserEvent_getById(id).FirstRow;
                viewMode = "update";
            }
            ViewBag.ViewMode = viewMode;
            return View(row);
        }

        // POST: /EoUserEvent/Edit/123
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection)
        {
            var token = collection["__RequestVerificationToken"];
            var mode = collection["ViewMode"];
            var id = collection[AppDataName.EOUE_UserEventId];
            var msgOK = "OK";

            EO_UserEventDataTable dt = null;
            EO_UserEventRow row = null;
            try
            {
                if (mode.equalIgnoreCase("create"))
                {
                    dt = new EO_UserEventDataTable();
                    row = dt.newTypedRow();
                    row.ns_AssignNewId();
                    dt.addTypedRow(row);
                    msgOK = FtdStatus.InsertSuccess.ToString();
                }
                else
                {
                    //找出該筆資料
                    dt = EoDataService.Instance.EoUserEvent_getById(id);
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

                if (row.EOUE_UserEventId.isNullOrEmpty())
                {
                    lstError.Add("事件ID不能為空");
                }
                if (row.EOUE_Description.isNullOrEmpty())
                {
                    lstError.Add("事件描述不能為空");
                }
                if (row.EOUE_EventCode.isNullOrEmpty())
                {
                    lstError.Add("事件代號不能為空");
                }
                if (row.EOUE_KindName.isNullOrEmpty())
                {
                    lstError.Add("事件類型不能為空");
                }
                //回傳錯誤訊息
                if (lstError.Count > 0)
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = string.Join("<br/>", lstError.ToArray()) });
                }
                //檢查鍵值是否重覆
                if (EoDataService.Instance.EoUserEvent_checkDuplicate(row.EOUE_UserEventId, row.EOUE_EventCode))
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = "事件代號已存在" });
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

        // POST: /EoUserEvent/Delete/123
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(FormCollection collection)
        {
            //var token = collection["__RequestVerificationToken"];
            var id = collection[AppDataName.EOUE_UserEventId];

            var row = EoDataService.Instance.EoUserEvent_getById(id).FirstRow;
            if (row == null)
            {
                return Json(new { Result = jTable_ERROR_CODE, Message = "資料不存在" });
            }

            try
            {
                row.Delete();
                row.ns_update();
                return Json(new { Result = jTable_SUCCESS_CODE });
            }
            catch (Exception ex)
            {
                return Json(new { Result = jTable_ERROR_CODE, Message = ex.Message });
            }
        }

    }
}
