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
using ftd.dataaccess;
using ftd.mvc.Controllers;

namespace ftd.mvc.Areas.EO.Controllers
{
    public class EoEmployeeController : AppBaseController
    {
        public ActionResult CodeQuery(FormCollection collection)
        {
            var qm = new EoEmployeeQryModel();
            var bln = this.TryUpdateModel(qm);
            ViewBag.RequestKey = qm.RequestKey;
            return View(qm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult List(FormCollection collection, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            //查詢參數
            var para = new EoEmployeeQryModel();
            var isOK = this.TryUpdateModel(para);
            var token = collection["__RequestVerificationToken"];

            var dt = EoDataService.Instance.EoEmployee_getList(para);

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

        // GET: /EoEmployee/Edit/123
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(string id)
        //{
        //    var viewMode = "update";
        //    EO_EmployeeRow row = null;
        //    if (id.isNullOrEmpty())
        //    {
        //        var dt = new EO_EmployeeDataTable();
        //        row = dt.newTypedRow();
        //        row.ns_AssignNewId();
        //        dt.addTypedRow(row);
        //        viewMode = "create";
        //    }
        //    else
        //    {
        //        row = EoDataService.Instance.EoEmployee_getById(id).FirstRow;
        //        viewMode = "update";
        //    }
        //    ViewBag.ViewMode = viewMode;
        //    return View(row);
        //}

        // POST: /EoEmployee/Edit/123
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection)
        {
            var token = collection["__RequestVerificationToken"];
            var mode = collection["ViewMode"];
            var id = collection[AppDataName.EOE_EmployeeId];
            var msgOK = "OK";

            EO_EmployeeDataTable dt = null;
            EO_EmployeeRow row = null;
            try
            {
                if (mode.equalIgnoreCase("create"))
                {
                    dt = new EO_EmployeeDataTable();
                    row = dt.newTypedRow();
                    row.ns_AssignNewId();
                    dt.addTypedRow(row);
                    msgOK = FtdStatus.InsertSuccess.ToString();
                }
                else
                {
                    //找出該筆資料
                    dt = EoDataService.Instance.EoEmployee_getById(id);
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

                if (row.EOE_EmployeeId.isNullOrEmpty())
                {
                    lstError.Add("人員ID不能為空");
                }
                //if (row.EOE_EmployeeCode.isNullOrEmpty())
                //{
                //    lstError.Add("人員編號不能為空");
                //}
                if (row.EOE_LoginAccount_XX.isNullOrEmpty())
                {
                    lstError.Add("帳號不能為空");
                } if (row.EOE_EmployeeName.isNullOrEmpty())
                {
                    lstError.Add("人員姓名不能為空");
                }
                //if (row.EOE_DepartmentId.isNullOrEmpty())
                //{
                //    lstError.Add("部門ID不能為空");
                //}
                //if (row.EOE_EmployeeTitleId.isNullOrEmpty())
                //{
                //    lstError.Add("職稱ID不能為空");
                //}
                //回傳錯誤訊息
                if (lstError.Count > 0)
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = string.Join("<br/>", lstError.ToArray()) });
                }
                //檢查鍵值是否重覆
                if (EoDataService.Instance.EoEmployee_checkDuplicate(row.EOE_EmployeeId, row.EOE_DepartmentId, row.EOE_EmployeeCode))
                {
                    return Json(new { Result = jTable_ERROR_CODE, Message = "相同鍵值的資料已存在" });
                }
                #endregion

                //人員編號=登入帳號
                row.EOE_EmployeeCode = row.EOE_LoginAccount_XX;

                //異動 LoginAccount
                var dtLoginAccount = NsDmHelper.EO_LoginAccount
                    .selectAll(t => t.AllExt)
                    .where(t => t.EOLA_LoginAccount == row.EOE_EmployeeCode.toConstReq1())
                    .query();

                var rowLoginAccount = dtLoginAccount.FirstRow;
                if (rowLoginAccount == null)
                {
                    rowLoginAccount = dtLoginAccount.newTypedRow();
                    rowLoginAccount.EOLA_LoginAccountId = row.EOE_EmployeeId;
                    rowLoginAccount.EOLA_LoginAccount = row.EOE_EmployeeCode;
                    //預設密碼=帳號
                    rowLoginAccount.EOLA_LoginPassword = row.EOE_EmployeeCode;
                    dtLoginAccount.addTypedRow(rowLoginAccount);
                }
                else
                {
                    if (rowLoginAccount.EOLA_LoginAccountId != row.EOE_EmployeeId)
                    {
                        return Json(new { Result = jTable_ERROR_CODE, Message = "帳號已存在" });
                    }
                }
                rowLoginAccount.EOLA_IsEnable = row.EOE_Enabled;
                if (!row.EOE_LoginPassword_XX.isNullOrEmpty())
                    rowLoginAccount.EOLA_LoginPassword = row.EOE_LoginPassword_XX;

                var scope = new FdbTransScope(FdbTransScopeOption.RequiresNew);
                using (scope.Use)
                {
                    dt.ns_update();
                    dtLoginAccount.ns_update();
                    dt.AcceptChanges();
                    scope.complete();
                }
                return Json(new { Result = msgOK }); 
            }
            catch (Exception ex)
            {
                return Json(new { Result = jTable_ERROR_CODE, Message = ex.Message });
            }
        }

        // POST: /EoEmployee/Delete/123
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(FormCollection collection)
        {
            //var token = collection["__RequestVerificationToken"];
            var id = collection[AppDataName.EOE_EmployeeId];

            var row = EoDataService.Instance.EoEmployee_getById(id).FirstRow;
            if (row == null)
            {
                return Json(new { Result = jTable_ERROR_CODE, Message = "資料不存在" });
            }

            var login = NsDmHelper.EO_LoginAccount.wherepk(id).queryFirst();
            try
            {
                if (login != null)
                    login.Delete();

                row.Delete();
                var scope = new FdbTransScope(FdbTransScopeOption.RequiresNew);
                using (scope.Use)
                {
                    login.ns_update();
                    row.ns_update();
                    scope.complete();
                }

                return Json(new { Result = jTable_SUCCESS_CODE });
            }
            catch (Exception ex)
            {
                return Json(new { Result = jTable_ERROR_CODE, Message = ex.Message });
            }
        }

        //public JsonResult GetEmp(string OrgId, string IsDeptMgr, string IsEnable)
        //{
        //    var dt = NsDmHelper.EO_Employee
        //         .select(t => new object[] { t.EOE_EmployeeId, t.EOE_EmployeeName })
        //         .where(t =>
        //             t.EOE_OrganId == OrgId.toConstReq1()
        //             & t.EOE_IsDeptMgr == IsDeptMgr.toConstOpt1()
        //             & t.EOE_Enabled == IsEnable.toConstOpt1()
        //         )
        //         .orderby(t =>
        //             t.EOE_EmployeeName.Asc
        //         )
        //         .query();

        //    List<SelectListItem> ls = new List<SelectListItem>();
        //    foreach (var dr in dt)
        //        ls.Add(new SelectListItem() { Text = dr.EOE_EmployeeName, Value = dr.EOE_EmployeeId });
        //    return Json(new SelectList(ls, "Value", "Text"));
        //}
    }
}
