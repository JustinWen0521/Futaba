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
    public class EoDepartmentController : AppBaseController
    {
        // GET: /EoDepartment/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /EoDepartment/CodeQuery
        public ActionResult CodeQuery(FormCollection collection)
        {
            var qm = new EoDepartmentQryModel();
            var bln = this.TryUpdateModel(qm);
            ViewBag.RequestKey = qm.RequestKey;
            return View();
        }

        // GET: /EoDepartment/CodeQuery_Multi
        public ActionResult CodeQuery_Multi(FormCollection collection) //string Value, string Name, string Ownership)
        {
            var qm = new EoDepartmentQryModel();
            var isOK = this.TryUpdateModel(qm);
            ViewBag.RequestKey = qm.RequestKey;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CodeQuery_Multi(FormCollection collection, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            //查詢參數
            var token = collection["__RequestVerificationToken"];
            var qm = new EoDepartmentQryModel();
            var isOK = this.TryUpdateModel(qm);

            var dt = EoDataService.Instance.EoDepartment_getList(qm);
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

        // POST: /EoDepartment/List
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult List(FormCollection collection, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            //查詢參數
            var para = new EoDepartmentQryModel();
            var isOK = this.TryUpdateModel(para);
            var token = collection["__RequestVerificationToken"];

            var dt = EoDataService.Instance.EoDepartment_getList(para);

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

        // GET: /EoDepartment/Edit/123
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(string id)
        //{
        //    var viewMode = "update";
        //    EO_DepartmentRow row = null;
        //    if (id.isNullOrEmpty())
        //    {
        //        var dt = new EO_DepartmentDataTable();
        //        row = dt.newTypedRow();
        //        row.ns_AssignNewId();
        //        row.EOD_DepartmentType = "B";
        //        row.EOD_VirtualType = "A";
        //        dt.addTypedRow(row);
        //        viewMode = "create";
        //    }
        //    else
        //    {
        //        row = EoDataService.Instance.EoDepartment_getById(id).FirstRow;
        //        viewMode = "update";
        //    }
        //    ViewBag.ViewMode = viewMode;
        //    return View(row);
        //}

        // POST: /EoDepartment/Edit/123
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection)
        {
            var token = collection["__RequestVerificationToken"];
            var mode = collection["ViewMode"];
            var id = collection[AppDataName.EOD_DepartmentId];
            var msgOK = "OK";

            EO_DepartmentDataTable dt = null;
            EO_DepartmentRow row = null;
            try
            {
                if (mode.equalIgnoreCase("create"))
                {
                    dt = new EO_DepartmentDataTable();
                    row = dt.newTypedRow();
                    row.ns_AssignNewId();
                    dt.addTypedRow(row);
                    msgOK = FtdStatus.InsertSuccess.ToString();
                }
                else
                {
                    //找出該筆資料
                    dt = EoDataService.Instance.EoDepartment_getById(id);
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

                if (row.EOD_DepartmentId.isNullOrEmpty())
                {
                    lstError.Add("群組ID不能為空");
                }
                if (row.EOD_DepartmentCode.isNullOrEmpty())
                {
                    lstError.Add("群組代號不能為空");
                }
                if (row.EOD_DepartmentName.isNullOrEmpty())
                {
                    lstError.Add("群組名稱不能為空");
                }
                if (!row.EOD_SortNo.HasValue)
                {
                    lstError.Add("排序不能為空");
                }
                //回傳錯誤訊息
                if (lstError.Count > 0)
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = string.Join("<br/>", lstError.ToArray()) });
                }
                //檢查鍵值是否重覆
                if (EoDataService.Instance.EoDepartment_checkDuplicate(row.EOD_DepartmentId, row.EOD_DepartmentCode))
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = "群組代號已存在" });
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

        // POST: /EoDepartment/Delete/123
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(FormCollection collection)
        {
            //var token = collection["__RequestVerificationToken"];
            var id = collection[AppDataName.EOD_DepartmentId];

            var row = EoDataService.Instance.EoDepartment_getById(id).FirstRow;
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
