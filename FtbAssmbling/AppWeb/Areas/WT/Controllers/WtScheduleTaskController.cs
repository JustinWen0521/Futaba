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
    public class WtScheduleTaskController : AppBaseController
    {
        //// GET: /WtScheduleTask/
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: /WtScheduleTask/CodeQuery
        public ActionResult CodeQuery(FormCollection collection)
        {
            var qm = new WtScheduleTaskQryModel();
            var bln = this.TryUpdateModel(qm);
            ViewBag.RequestKey = qm.RequestKey;
            return View();
        }

        // POST: /WtScheduleTask/List
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult List(FormCollection collection, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            //查詢參數
            var qm = new WtScheduleTaskQryModel();
            var isOK = this.TryUpdateModel(qm);
            var token = collection["__RequestVerificationToken"];

            var dt = WtDataService.Instance.WtScheduleTask_getList(qm);

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

        //// GET: /WtScheduleTask/Edit/123
        ////[ValidateAntiForgeryToken]
        //public ActionResult Edit(string id)
        //{
        //    var viewMode = "update";
        //    WT_ScheduleTaskRow row = null;
        //    if (id.isNullOrEmpty())
        //    {
        //        row = WtDataService.Instance.WtScheduleTask_create().FirstRow;
        //        viewMode = "create";
        //    }
        //    else
        //    {
        //        row = WtDataService.Instance.WtScheduleTask_getById(id).FirstRow;
        //        viewMode = "update";
        //    }
        //    ViewBag.ViewMode = viewMode;
        //    return View(row);
        //}

        // POST: /WtScheduleTask/Edit/123
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection)
        {
            var token = collection["__RequestVerificationToken"];
            var mode = collection["ViewMode"];
            var id = collection[AppDataName.WTST_ScheduleTaskId];
            var msgOK = "OK";

            WT_ScheduleTaskDataTable dt = null;
            WT_ScheduleTaskRow row = null;
            try
            {
                if (mode.equalIgnoreCase("create"))
                {
                    dt = WtDataService.Instance.WtScheduleTask_create();
                    msgOK = FtdStatus.InsertSuccess.ToString();
                }
                else
                {
                    //找出該筆資料
                    dt = WtDataService.Instance.WtScheduleTask_getById(id);
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

                if (row.WTST_ScheduleTaskId.isNullOrEmpty())
                {
                    lstError.Add("排程ID不能為空");
                }
                if (row.WTST_TaskName.isNullOrEmpty())
                {
                    lstError.Add("排程名稱不能為空");
                }
                if (row.WTST_ObjectTypeName.isNullOrEmpty())
                {
                    lstError.Add("物件類型不能為空");
                }
                if (row.WTST_IsEnable.isNullOrEmpty())
                {
                    lstError.Add("啟用不能為空");
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

        // POST: /WtScheduleTask/Delete/123
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(FormCollection collection)
        {
            //var token = collection["__RequestVerificationToken"];
            var id = collection[AppDataName.WTST_ScheduleTaskId];

            var row = WtDataService.Instance.WtScheduleTask_getById(id).FirstRow;
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

        [HttpPost]
        public ActionResult Reload()
        {
            FtdScheduleService.Instance.loadTasks();
            return Json(new { Result = "OK" });
        }

        [HttpPost]
        public ActionResult RunTask(string taskId)
        {
            FtdScheduleService.Instance.runTaskimmediateByPk(taskId);
            return Json(new { Result = "OK" });
        }
    }
}
