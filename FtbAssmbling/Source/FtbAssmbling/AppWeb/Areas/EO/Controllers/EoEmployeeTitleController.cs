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
    public class EoEmployeeTitleController : AppBaseController
    {
        // GET: /EoEmployeeTitle/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /EoEmployeeTitle/CodeQuery
        public ActionResult CodeQuery(string RequestKey)
        {
            ViewBag.RequestKey = RequestKey;
            return View();
        }

        // POST: /EoEmployeeTitle/List
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult List(FormCollection collection, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            //查詢參數
            var para = new EoEmployeeTitleQryModel();
            var isOK = this.TryUpdateModel(para);
            var token = collection["__RequestVerificationToken"];

            var dt = EoDataService.Instance.EoEmployeeTitle_getList(para);

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

        // GET: /EoEmployeeTitle/Edit/123
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(string id)
        //{
        //    var viewMode = "update";
        //    EO_EmployeeTitleRow row = null;
        //    if (id.isNullOrEmpty())
        //    {
        //        var dt = new EO_EmployeeTitleDataTable();
        //        row = dt.newTypedRow();
        //        row.ns_AssignNewId();
        //        dt.addTypedRow(row);
        //        viewMode = "create";
        //    }
        //    else
        //    {
        //        row = EoDataService.Instance.EoEmployeeTitle_getById(id).FirstRow;
        //        viewMode = "update";
        //    }
        //    ViewBag.ViewMode = viewMode;
        //    return View(row);
        //}

        // POST: /EoEmployeeTitle/Edit/123
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection)
        {
            var token = collection["__RequestVerificationToken"];
            var mode = collection["ViewMode"];
            var id = collection[AppDataName.EOET_EmployeeTitleId];
            var msgOK = "OK";

            EO_EmployeeTitleDataTable dt = null;
            EO_EmployeeTitleRow row = null;
            try
            {
                if (mode.equalIgnoreCase("create"))
                {
                    dt = EoDataService.Instance.EoEmployeeTitle_create();
                    msgOK = FtdStatus.InsertSuccess.ToString();
               

                }
                else
                {
                    //找出該筆資料
                    dt = EoDataService.Instance.EoEmployeeTitle_getById(id);
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

                if (row.EOET_EmployeeTitleId.isNullOrEmpty())
                {
                    lstError.Add("職稱ID不能為空");
                }
                //if (row.EOET_TitleCode.isNullOrEmpty())
                //{
                //    lstError.Add("職稱代號不能為空");
                //}
                if (row.EOET_TitleName.isNullOrEmpty())
                {
                    lstError.Add("職稱名稱不能為空");
                }
                //if (!row.EOET_ListOrder.HasValue)
                //{
                //    lstError.Add("職稱順序不能為空");
                //}


                if (row.EOET_ListOrder.ToString() == "")
                {

                    //取得順序最大值
                    var ListOrder = EoDataService.Instance.EoEmployeeTitle_getListOrderMax();
                    row.EOET_ListOrder = ListOrder;
                    row.EOET_TitleCode = "EOET_" + ListOrder;

                }


                //回傳錯誤訊息
                if (lstError.Count > 0)
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = string.Join("<br/>", lstError.ToArray()) });
                }
                //檢查鍵值是否重覆
                if (EoDataService.Instance.EoEmployeeTitle_checkDuplicate(row.EOET_EmployeeTitleId, row.EOET_TitleCode))
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = "職稱代號已存在" });
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

        // POST: /EoEmployeeTitle/Delete/123
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(FormCollection collection)
        {
            //var token = collection["__RequestVerificationToken"];
            var id = collection[AppDataName.EOET_EmployeeTitleId];

            var row = EoDataService.Instance.EoEmployeeTitle_getById(id).FirstRow;
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
