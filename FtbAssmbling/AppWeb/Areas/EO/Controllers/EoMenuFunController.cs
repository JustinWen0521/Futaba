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

namespace ftd.mvc.Areas.EO.Controllers
{
    public class EoMenuFunController : AppBaseController
    {
        //// GET: /EoMenuFun/
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: /EoMenuFun/CodeQuery
        public ActionResult CodeQuery(FormCollection collection)
        {
            var qm = new EoMenuFunQryModel();
            var bln = this.TryUpdateModel(qm);
            ViewBag.RequestKey = qm.RequestKey;
            return View();
        }

        // POST: /EoMenuFun/List
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult List(FormCollection collection, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            //查詢參數
            var qm = new EoMenuFunQryModel();
            var isOK = this.TryUpdateModel(qm);
            var token = collection["__RequestVerificationToken"];

            var dt = EoDataService.Instance.EoMenuFun_getList(qm);

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

        //// GET: /EoMenuFun/Edit/123
        ////[ValidateAntiForgeryToken]
        //public ActionResult Edit(string id)
        //{
        //    var viewMode = "update";
        //    EO_MenuFunRow row = null;
        //    if (id.isNullOrEmpty())
        //    {
        //        row = EoDataService.Instance.EoMenuFun_create().FirstRow;
        //        viewMode = "create";
        //    }
        //    else
        //    {
        //        row = EoDataService.Instance.EoMenuFun_getById(id).FirstRow;
        //        viewMode = "update";
        //    }
        //    ViewBag.ViewMode = viewMode;
        //    return View(row);
        //}

        // POST: /EoMenuFun/Edit/123
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection)
        {
            var token = collection["__RequestVerificationToken"];
            var mode = collection["ViewMode"];
            var id = collection[AppDataName.EOMF_MenuFunId];
            var msgOK = "OK";

            EO_MenuFunDataTable dt = null;
            EO_MenuFunRow row = null;
            try
            {
                if (mode.equalIgnoreCase("create"))
                {
                    dt = EoDataService.Instance.EoMenuFun_create();
                    msgOK = FtdStatus.InsertSuccess.ToString();
                }
                else
                {
                    //找出該筆資料
                    dt = EoDataService.Instance.EoMenuFun_getById(id);
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

                if (row.EOMF_MenuFunId.isNullOrEmpty())
                {
                    lstError.Add("程式功能清單ID不能為空");
                }
                if (row.EOMF_ItemNo.isNullOrEmpty())
                {
                    lstError.Add("程式代號不能為空");
                }
                if (row.EOMF_FunctionCode.isNullOrEmpty())
                {
                    lstError.Add("功能代號不能為空");
                }
                if (row.EOMF_FunctionName.isNullOrEmpty())
                {
                    lstError.Add("功能名稱不能為空");
                }
                if (!row.EOMF_SeqNo.HasValue)
                {
                    lstError.Add("排序不能為空");
                }
                //回傳錯誤訊息
                if (lstError.Count > 0)
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = string.Join("<br/>", lstError.ToArray()) });
                }
                //檢查鍵值是否重覆
                if (EoDataService.Instance.EoMenuFun_checkDuplicate(row.EOMF_MenuFunId, row.EOMF_ItemNo, row.EOMF_FunctionCode))
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = "相同鍵值的資料已存在" });
                }
                #endregion

                row.EOMF_FunctionCode = row.EOMF_FunctionCode.ToUpper();
                dt.ns_update();
                dt.AcceptChanges();
                return Json(new { Result = msgOK }); 
            }
            catch (Exception ex)
            {
                return Json(new { Result = jTable_ERROR_CODE, Message = ex.Message });
            }
        }

        // POST: /EoMenuFun/Delete/123
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(FormCollection collection)
        {
            //var token = collection["__RequestVerificationToken"];
            var id = collection[AppDataName.EOMF_MenuFunId];

            try
            {
                var result = EoDataService.Instance.EoMenuFun_deleteBatch(new[] { id });
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

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AddDefault(string itemNo)
        {
            try
            {
                EoDataService.Instance.EoMenuFun_addDefaultFunctions(itemNo);
                return Json(new { Result = jTable_SUCCESS_CODE });
            }
            catch (Exception ex)
            {
                return Json(new { Result = jTable_ERROR_CODE, Message = ex.Message });
            }
        }
    }
}
