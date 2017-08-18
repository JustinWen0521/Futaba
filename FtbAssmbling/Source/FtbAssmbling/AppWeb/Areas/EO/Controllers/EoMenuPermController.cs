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
    public class EoMenuPermController : AppBaseController
    {
        public ActionResult CodeQuery(FormCollection collection)
        {
            var qm = new EoMenuPermQryModel();
            var bln = this.TryUpdateModel(qm);
            ViewBag.RequestKey = qm.RequestKey;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult List(FormCollection collection, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            //查詢參數
            var qm = new EoMenuPermQryModel();
            var isOK = this.TryUpdateModel(qm);
            var token = collection["__RequestVerificationToken"];

            var dt = EoDataService.Instance.EoMenuPerm_getList(qm);

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

        ////[ValidateAntiForgeryToken]
        //public ActionResult Edit(string id)
        //{
        //    var viewMode = "update";
        //    EO_MenuPermRow row = null;
        //    if (id.isNullOrEmpty())
        //    {
        //        row = EoDataService.Instance.EoMenuPerm_create().FirstRow;
        //        viewMode = "create";
        //    }
        //    else
        //    {
        //        row = EoDataService.Instance.EoMenuPerm_getById(id).FirstRow;
        //        viewMode = "update";
        //    }
        //    ViewBag.ViewMode = viewMode;
        //    return View(row);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection)
        {
            var token = collection["__RequestVerificationToken"];
            var mode = collection["ViewMode"];
            var id = collection[AppDataName.EOMP_MenuPermId];
            var msgOK = "OK";

            EO_MenuPermDataTable dt = null;
            EO_MenuPermRow row = null;
            try
            {
                if (mode.equalIgnoreCase("create"))
                {
                    dt = EoDataService.Instance.EoMenuPerm_create();
                    msgOK = FtdStatus.InsertSuccess.ToString();
                }
                else
                {
                    //找出該筆資料
                    dt = EoDataService.Instance.EoMenuPerm_getById(id);
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

                if (row.EOMP_MenuPermId.isNullOrEmpty())
                {
                    lstError.Add("授權ID不能為空");
                }
                if (row.EOMP_MenuId.isNullOrEmpty())
                {
                    lstError.Add("功能表ID不能為空");
                }
                if (row.EOMP_TargetId.isNullOrEmpty())
                {
                    lstError.Add("授權對象ID不能為空");
                }
                if (row.EOMP_TargetKind.isNullOrEmpty())
                {
                    lstError.Add("授權類型不能為空");
                }
                if (row.EOMP_ViewKind.isNullOrEmpty())
                {
                    lstError.Add("檢視權限不能為空");
                }
                //回傳錯誤訊息
                if (lstError.Count > 0)
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = string.Join("<br/>", lstError.ToArray()) });
                }
                //檢查鍵值是否重覆
                if (EoDataService.Instance.EoMenuPerm_checkDuplicate(row.EOMP_MenuPermId, row.EOMP_MenuId, row.EOMP_TargetId, row.EOMP_ViewKind))
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = "相同鍵值的資料已存在" });
                }
                #endregion

                #region // CheckBox 有勾選者，才會 post 到後端
                List<string> lstItemNos = new List<string>();
                Dictionary<string, List<string>> dicFuns = new Dictionary<string, List<string>>();
                foreach (var key in collection.AllKeys)
                {
                    if (key.StartsWith("chk_menu_"))
                    {
                        //程式
                        lstItemNos.Add(collection[key.ToString()]);
                    }
                    else if (key.StartsWith("chk_fun_"))
                    {
                        //功能(動作)
                        var ids = key.ToString().Split('_');
                        if (ids.Length >= 3)
                        {
                            dicFuns.Add(ids[2], collection[key.ToString()].Split(',').ToList());
                        }
                    }
                }
                #endregion

                dt.ns_update();
                dt.AcceptChanges();

                //設定權限
                var result = EoDataService.Instance.EoMenuPerm_updatePermSet(row, lstItemNos, dicFuns);

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
            var id = collection[AppDataName.EOMP_MenuPermId];

            var row = EoDataService.Instance.EoMenuPerm_getById(id).FirstRow;
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
