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
    public class EoUserEventLogController : AppBaseController
    {
        // GET: /EoUserEventLog/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /EoUserEventLog/CodeQuery
        public ActionResult CodeQuery(string RequestKey)
        {
            ViewBag.RequestKey = RequestKey;
            return View();
        }

        // POST: /EoUserEventLog/List
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult List(FormCollection collection, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            //查詢參數
            var qm = new EoUserEventLogQryModel();
            var isOK = this.TryUpdateModel(qm);
            var token = collection["__RequestVerificationToken"];

            var dt = EoDataService.Instance.EoUserEventLog_getList(qm);

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

        // POST: /EoUserEventLog/Edit/123
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection)
        {
            var token = collection["__RequestVerificationToken"];
            var mode = collection["ViewMode"];
            var id = collection[AppDataName.EOUEL_UserEventLogId];
            var msgOK = "OK";

            EO_UserEventLogDataTable dt = null;
            EO_UserEventLogRow row = null;
            try
            {
                if (mode.equalIgnoreCase("create"))
                {
                    dt = new EO_UserEventLogDataTable();
                    row = dt.newTypedRow();
                    row.ns_AssignNewId();
                    dt.addTypedRow(row);
                    msgOK = FtdStatus.InsertSuccess.ToString();
                }
                else
                {
                    //找出該筆資料
                    dt = EoDataService.Instance.EoUserEventLog_getById(id);
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

                if (row.EOUEL_UserEventLogId.isNullOrEmpty())
                {
                    lstError.Add("事件檔紀錄ID不能為空");
                }
                if (!row.EOUEL_EventDate.HasValue)
                {
                    lstError.Add("事件日期不能為空");
                }
                if (row.EOUEL_UserEventCode_XX.isNullOrEmpty())
                {
                    lstError.Add("事件代號不能為空");
                }
                if (row.EOUEL_UserEventId.isNullOrEmpty())
                {
                    lstError.Add("事件Id不能為空");
                }
                if (row.EOUEL_UserEventName_XX.isNullOrEmpty())
                {
                    lstError.Add("事件類型不能為空");
                }
                //回傳錯誤訊息
                if (lstError.Count > 0)
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = string.Join("<br/>", lstError.ToArray()) });
                }
                //檢查鍵值是否重覆
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

        // POST: /EoUserEventLog/Delete/123
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(FormCollection collection)
        {
            //var token = collection["__RequestVerificationToken"];
            var id = collection[AppDataName.EOUEL_UserEventLogId];

            var row = EoDataService.Instance.EoUserEventLog_getById(id).FirstRow;
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
