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

namespace ftd.mvc.Areas.WT.Controllers
{
    public class WtScheduleDateController : AppBaseController
    {
        //// GET: /WtScheduleDate/
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: /WtScheduleDate/CodeQuery
        public ActionResult CodeQuery(FormCollection collection)
        {
            var qm = new WtScheduleTaskQryModel();
            var bln = this.TryUpdateModel(qm);
            ViewBag.RequestKey = qm.RequestKey;
            return View();
        }

        // POST: /WtScheduleDate/List
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult List(FormCollection collection, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            //查詢參數
            var qm = new WtScheduleTaskQryModel();
            var isOK = this.TryUpdateModel(qm);
            var token = collection["__RequestVerificationToken"];

            var dt = WtDataService.Instance.WtScheduleDate_getList(qm);

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

        //// GET: /WtScheduleDate/Edit/123
        ////[ValidateAntiForgeryToken]
        //public ActionResult Edit(string id)
        //{
        //    var viewMode = "update";
        //    WT_ScheduleDateRow row = null;
        //    if (id.isNullOrEmpty())
        //    {
        //        row = WtDataService.Instance.WtScheduleDate_create().FirstRow;
        //        viewMode = "create";
        //    }
        //    else
        //    {
        //        row = WtDataService.Instance.WtScheduleDate_getById(id).FirstRow;
        //        viewMode = "update";
        //    }
        //    ViewBag.ViewMode = viewMode;
        //    return View(row);
        //}

        // POST: /WtScheduleDate/Edit/123
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection)
        {
            var token = collection["__RequestVerificationToken"];
            var mode = collection["ViewMode"];
            var id = collection[AppDataName.WTSD_ScheduleDateId];
            var msgOK = "OK";

            WT_ScheduleDateDataTable dt = null;
            WT_ScheduleDateRow row = null;
            try
            {
                if (mode.equalIgnoreCase("create"))
                {
                    dt = WtDataService.Instance.WtScheduleDate_create();
                    msgOK = FtdStatus.InsertSuccess.ToString();
                }
                else
                {
                    //找出該筆資料
                    dt = WtDataService.Instance.WtScheduleDate_getById(id);
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

                if (row.WTSD_ScheduleDateId.isNullOrEmpty())
                {
                    lstError.Add("排程時間ID不能為空");
                }
                if (row.WTSD_ScheduleTaskId.isNullOrEmpty())
                {
                    lstError.Add("排程ID不能為空");
                }
                if (row.WTSD_PeriodType.isNullOrEmpty())
                {
                    lstError.Add("週期類型不能為空");
                }
                if (!row.WTSD_EveryDayHour.HasValue)
                {
                    lstError.Add("小時不能為空");
                }
                if (!row.WTSD_EveryDayMiniute.HasValue)
                {
                    lstError.Add("分鐘不能為空");
                }
                if (!row.WTSD_MoreMinute.HasValue)
                {
                    row.WTSD_MoreMinute = 0;
                }

                //回傳錯誤訊息
                if (lstError.Count > 0)
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = string.Join("<br/>", lstError.ToArray()) });
                }
                //檢查鍵值是否重覆
                #endregion

                var date = new FtdScheduleDate();
                date.MoreMinute = row.WTSD_MoreMinute.Value;

                switch (row.WTSD_PeriodType)
                {
                    case "A":  //每天
                        date.setEveryDay(row.WTSD_EveryDayHour.Value, row.WTSD_EveryDayMiniute.Value);
                        break;
                    case "B":  //每小時
                        date.setEveryHour(row.WTSD_EveryDayMiniute.Value);
                        break;
                    default:
                        return Json(new { Result = jTable_ERROR_CODE, Message = new NotFiniteNumberException().Message }); 
                }
                row.WTSD_Description = date.getDescription();
                row.WTSD_Parameters = FtdIoHelper.serializeAsString(date.getParameters());

                dt.ns_update();
                dt.AcceptChanges();
                return Json(new { Result = msgOK }); 
            }
            catch (Exception ex)
            {
                return Json(new { Result = jTable_ERROR_CODE, Message = ex.Message });
            }
        }

        // POST: /WtScheduleDate/Delete/123
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(FormCollection collection)
        {
            //var token = collection["__RequestVerificationToken"];
            var id = collection[AppDataName.WTSD_ScheduleDateId];

            var row = WtDataService.Instance.WtScheduleDate_getById(id).FirstRow;
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
