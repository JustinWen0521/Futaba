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

namespace ftd.mvc.Areas.ZZ.Controllers
{
    public class ZzOrderController : AppBaseController
    {
        public ActionResult ZZE010()
        {
            var qm = new ZzOrderQryModel();
            var today = DateTime.Today;
            qm.Q_DateFrom = new DateTime(today.Year, today.Month, 1);
            qm.Q_DateTo = qm.Q_DateFrom.Value.AddMonths(1).AddDays(-1);
            //qm.Q_DateTo = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
            return View(qm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ZZE010(FormCollection collection)
        {
            var token = collection["__RequestVerificationToken"];

            var qm = new ZzOrderQryModel();
            var bln = this.TryUpdateModel(qm);

            qm.ClientMessage = "After submit post.";
            return View(qm);
        }

        public ActionResult CodeQuery(FormCollection collection)
        {
            var qm = new ZzOrderQryModel();
            var bln = this.TryUpdateModel(qm);
            ViewBag.RequestKey = qm.RequestKey;
            return View(qm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult List(FormCollection collection, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            //查詢參數
            var qm = new ZzOrderQryModel();
            var isOK = this.TryUpdateModel(qm);
            var token = collection["__RequestVerificationToken"];

            var dt = ZzDataService.Instance.ZzOrder_getList(qm);

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
        public ActionResult ZZE010Edit(string id)
        {
            var viewMode = "update";
            ZZ_OrderRow row = null;
            if (id.isNullOrEmpty())
            {
                row = ZzDataService.Instance.ZzOrder_create().FirstRow;
                viewMode = "create";
            }
            else
            {
                row = ZzDataService.Instance.ZzOrder_getById(id).FirstRow;
                viewMode = "update";
            }
            ViewBag.ViewMode = viewMode;
            return View(row);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ZZE010Edit(FormCollection collection)
        {
            var token = collection["__RequestVerificationToken"];
            var mode = collection["ViewMode"];
            var id = collection[AppDataName.ZZO_OrderId];
            var msgOK = "OK";

            ZZ_OrderDataTable dt = null;
            ZZ_OrderRow row = null;
            try
            {
                if (mode.equalIgnoreCase("create"))
                {
                    dt = ZzDataService.Instance.ZzOrder_create();
                    msgOK = FtdStatus.InsertSuccess.ToString();
                }
                else
                {
                    //找出該筆資料
                    dt = ZzDataService.Instance.ZzOrder_getById(id);
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

                if (row.ZZO_OrderId.isNullOrEmpty())
                {
                    lstError.Add("訂單ID不能為空");
                }
                if (row.ZZO_OrderNo.isNullOrEmpty())
                {
                    lstError.Add("訂單號碼不能為空");
                }
                if (!row.ZZO_Date.HasValue)
                {
                    lstError.Add("訂單日期不能為空");
                }
                if (row.ZZO_Desc.isNullOrEmpty())
                {
                    lstError.Add("訂單說明不能為空");
                }
                if (row.ZZO_IsEnable.isNullOrEmpty())
                {
                    lstError.Add("啟用不能為空");
                }
                if (row.ZZO_IsEnableName_XX.isNullOrEmpty())
                {
                    lstError.Add("啟用不能為空");
                }
                if (!row.ZZO_OrderAmount_XX.HasValue)
                {
                    lstError.Add("訂單總金額不能為空");
                }
                //回傳錯誤訊息
                if (lstError.Count > 0)
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = string.Join("<br/>", lstError.ToArray()) });
                }
                //檢查鍵值是否重覆
                if (ZzDataService.Instance.ZzOrder_checkDuplicate(row.ZZO_OrderId, row.ZZO_OrderNo))
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = "訂單號碼已存在" });
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
            var id = collection[AppDataName.ZZO_OrderId];

            try
            {
                var result = ZzDataService.Instance.ZzOrder_deleteBatch(new[] { id });
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
