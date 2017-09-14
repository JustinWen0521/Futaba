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
    public class ZzOrderDetailController : AppBaseController
    {
        public ActionResult Index()
        {
            var qm = new ZzOrderQryModel();
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

            ZZ_OrderDetailDataTable dt = null;
            if (!qm.Q_OrderId.isNullOrEmpty())
            {
                dt = ZzDataService.Instance.ZzOrderDetail_getListByOrderId(qm.Q_OrderId);
            }
            else
            {
                dt = ZzDataService.Instance.ZzOrderDetail_getList(qm);
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
        public ActionResult Edit(string id)
        {
            var viewMode = "update";
            ZZ_OrderDetailRow row = null;
            if (id.isNullOrEmpty())
            {
                row = ZzDataService.Instance.ZzOrderDetail_create().FirstRow;
                viewMode = "create";
            }
            else
            {
                row = ZzDataService.Instance.ZzOrderDetail_getById(id).FirstRow;
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
            var id = collection[AppDataName.ZZOD_OrderDetailId];
            var msgOK = "OK";

            ZZ_OrderDetailDataTable dt = null;
            ZZ_OrderDetailRow row = null;
            try
            {
                if (mode.equalIgnoreCase("create"))
                {
                    dt = ZzDataService.Instance.ZzOrderDetail_create();
                    msgOK = FtdStatus.InsertSuccess.ToString();
                }
                else
                {
                    //找出該筆資料
                    dt = ZzDataService.Instance.ZzOrderDetail_getById(id);
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

                if (row.ZZOD_OrderDetailId.isNullOrEmpty())
                {
                    lstError.Add("訂單明細ID不能為空");
                }
                if (row.ZZOD_OrderId.isNullOrEmpty())
                {
                    lstError.Add("訂單ID不能為空");
                }
                if (row.ZZOD_OrderNo_XX.isNullOrEmpty())
                {
                    lstError.Add("訂單號碼不能為空");
                }
                if (!row.ZZOD_OrderDate_XX.HasValue)
                {
                    lstError.Add("訂單日期不能為空");
                }
                if (row.ZZOD_OrderDesc_XX.isNullOrEmpty())
                {
                    lstError.Add("訂單說明不能為空");
                }
                if (row.ZZOD_Item.isNullOrEmpty())
                {
                    lstError.Add("品項不能為空");
                }
                if (!row.ZZOD_Qty.HasValue)
                {
                    lstError.Add("數量不能為空");
                }
                if (!row.ZZOD_UnitPrice.HasValue)
                {
                    lstError.Add("單價不能為空");
                }
                if (!row.ZZOD_Amount_XX.HasValue)
                {
                    lstError.Add("金額不能為空");
                }
                //回傳錯誤訊息
                if (lstError.Count > 0)
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = string.Join("<br/>", lstError.ToArray()) });
                }
                //檢查鍵值是否重覆
                if (ZzDataService.Instance.ZzOrderDetail_checkDuplicate(row.ZZOD_OrderDetailId, row.ZZOD_OrderId, row.ZZOD_Item))
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
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(FormCollection collection)
        {
            //var token = collection["__RequestVerificationToken"];
            var id = collection[AppDataName.ZZOD_OrderDetailId];

            try
            {
                var result = ZzDataService.Instance.ZzOrderDetail_deleteBatch(new[] { id });
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
