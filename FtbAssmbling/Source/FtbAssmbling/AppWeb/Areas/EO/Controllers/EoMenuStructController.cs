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
    public class EoMenuStructController : AppBaseController
    {
        // GET: /EoMenuStruct/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CodeQuery(string RequestKey)
        {
            ViewBag.RequestKey = RequestKey;
            return View();
        }

        // POST: /EoMenuStruct/List
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult List(FormCollection collection, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            //查詢參數
            var qm = new EoMenuStructQryModel();
            var isOK = this.TryUpdateModel(qm);
            var token = collection["__RequestVerificationToken"];

            var dt = EoDataService.Instance.EoMenuStruct_getList(qm);

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

        // GET: /EoMenuStruct/Edit/123
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(string id)
        //{
        //    var viewMode = "update";
        //    EO_MenuStructRow row = null;
        //    if (id.isNullOrEmpty())
        //    {
        //        var dt = new EO_MenuStructDataTable();
        //        row = dt.newTypedRow();
        //        row.ns_AssignNewId();
        //        dt.addTypedRow(row);
        //        viewMode = "create";
        //    }
        //    else
        //    {
        //        row = EoDataService.Instance.EoMenuStruct_getById(id).FirstRow;
        //        viewMode = "update";
        //    }
        //    ViewBag.ViewMode = viewMode;
        //    return View(row);
        //}

        // POST: /EoMenuStruct/Edit/123
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection)
        {
            var token = collection["__RequestVerificationToken"];
            var mode = collection["ViewMode"];
            var id = collection[AppDataName.EOMS_NodeId];
            var msgOK = "OK";

            EO_MenuStructDataTable dt = null;
            EO_MenuStructRow row = null;
            try
            {
                if (mode.equalIgnoreCase("create"))
                {
                    dt = new EO_MenuStructDataTable();
                    row = dt.newTypedRow();
                    row.ns_AssignNewId();
                    dt.addTypedRow(row);
                    msgOK = FtdStatus.InsertSuccess.ToString();
                }
                else
                {
                    //找出該筆資料
                    dt = EoDataService.Instance.EoMenuStruct_getById(id);
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

                if (row.EOMS_NodeId.isNullOrEmpty())
                {
                    lstError.Add("功能ID不能為空");
                }
                if (row.EOMS_Code.isNullOrEmpty())
                {
                    lstError.Add("功能代號不能為空");
                }
                if (row.EOMS_Name.isNullOrEmpty())
                {
                    lstError.Add("功能名稱不能為空");
                }
                if (row.EOMS_ClickMode.isNullOrEmpty())
                {
                    lstError.Add("點選模式不能為空");
                }
                //回傳錯誤訊息
                if (lstError.Count > 0)
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = string.Join("<br/>", lstError.ToArray()) });
                }
                //檢查鍵值是否重覆
                if (EoDataService.Instance.EoMenuStruct_checkDuplicate(row.EOMS_NodeId, row.EOMS_Code))
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = "功能表代碼已存在" });
                }
                #endregion

                row.EOMS_Code = row.EOMS_Code.ToUpper();

                dt.ns_update();
                dt.AcceptChanges();
                return Json(new { Result = msgOK }); 
            }
            catch (Exception ex)
            {
                return Json(new { Result = jTable_ERROR_CODE, Message = ex.Message });
            }
        }

        // POST: /EoMenuStruct/Delete/123
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(FormCollection collection)
        {
            //var token = collection["__RequestVerificationToken"];
            var id = collection[AppDataName.EOMS_NodeId];

            var row = EoDataService.Instance.EoMenuStruct_getById(id).FirstRow;
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
