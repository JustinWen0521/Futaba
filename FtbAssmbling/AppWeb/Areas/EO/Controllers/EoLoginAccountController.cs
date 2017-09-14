using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ftd.data;
using ftd.nsql;
using ftd.service;
using ftd.mvc.Controllers;

namespace ftd.mvc.Areas.EO.Controllers
{
    public class EoLoginAccountController : AppBaseController
    {
        public ActionResult Index()
        {
            //查詢參數

            var dt = EoDataService.Instance.EoLoginAccount_getList(null, null, null);
            return View(dt);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            //查詢參數
            var loginAccount = collection["Q_LoginAccount"];
            var userEmail_XX = collection["Q_UserEmail_XX"];
            var userName_XX = collection["Q_UserName_XX"];

            var dt = EoDataService.Instance.EoLoginAccount_getList(loginAccount, userEmail_XX, userName_XX);
            return View(dt);
        }

        public ActionResult Details(string id)
        {
            var row = EoDataService.Instance.EoLoginAccount_getById(id).FirstRow;
            return View(row);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            EO_LoginAccountRow row = null;
            try
            {
                // TODO: Add insert logic here
                var dt = new EO_LoginAccountDataTable();
                row = dt.newTypedRow();
                row.ns_AssignNewId();
                dt.addTypedRow(row);

                //將Form sumit的資料更新至DataRow
                this.UpdateModel(row);

                //驗證欄位
                if (row.EOLA_LoginAccountId.isNullOrEmpty())
                {
                    ModelState.AddModelError(AppDataName.EOLA_LoginAccountId, "登入帳號ID不能為空");
                    return View(row);
                }
                if (row.EOLA_LoginAccount.isNullOrEmpty())
                {
                    ModelState.AddModelError(AppDataName.EOLA_LoginAccount, "登入帳號不能為空");
                    return View(row);
                }
                //檢查鍵值是否重覆
                if (EoDataService.Instance.EoLoginAccount_checkDuplicate(row.EOLA_LoginAccountId, row.EOLA_LoginAccount, row.EOLA_UserEmail_XX))
                {
                    ModelState.AddModelError("", "相同鍵值的資料已存在");
                    return View(row);
                }

                dt.ns_update();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "更新資料發生錯誤");
                return View(row);
            }
        }

        public ActionResult Edit(string id)
        {
            var row = EoDataService.Instance.EoLoginAccount_getById(id).FirstRow;
            return View(row);
        }

        //
        // POST: /EoLoginAccount/Edit/5

        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            EO_LoginAccountRow row = null;
            try
            {
                // TODO: Add update logic here
                row = EoDataService.Instance.EoLoginAccount_getById(id).FirstRow;

                if (row == null)
                {
                    return View();
                }

                //將Form sumit的資料更新至DataRow
                this.UpdateModel(row);

                //若驗證失敗-->返回頁面重新輸入
                if (!ModelState.IsValid)
                {
                    return View(row);
                }

                //驗證欄位
                if (row.EOLA_LoginAccountId.isNullOrEmpty())
                {
                    ModelState.AddModelError(AppDataName.EOLA_LoginAccountId, "登入帳號ID不能為空");
                    return View(row);
                }
                if (row.EOLA_LoginAccount.isNullOrEmpty())
                {
                    ModelState.AddModelError(AppDataName.EOLA_LoginAccount, "登入帳號不能為空");
                    return View(row);
                }
                //檢查鍵值是否重覆
                if (EoDataService.Instance.EoLoginAccount_checkDuplicate(row.EOLA_LoginAccountId, row.EOLA_LoginAccount, row.EOLA_UserEmail_XX))
                {
                    ModelState.AddModelError("", "相同鍵值的資料已存在");
                    return View(row);
                }

                row.ns_update();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "更新資料發生錯誤");
                return View(row);
            }
        }

        //
        // GET: /EoLoginAccount/Delete/5

        public ActionResult Delete(string id)
        {
            var row = EoDataService.Instance.EoLoginAccount_getById(id).FirstRow;
            return View(row);
        }

        //
        // POST: /EoLoginAccount/Delete/5

        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var row = EoDataService.Instance.EoLoginAccount_getById(id).FirstRow;
            if (row == null)
            {
                return View();
            }

            try
            {
                row.Delete();
                row.ns_update();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "刪除資料發生錯誤");
                return View(row);
            }
        }
    }
}
