using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ftd.data;
using ftd.service;
using ftd.nsql;
using ftd.mvc.Controllers;
using ftd.query.model;

namespace ftd.mvc.Areas.EO.Controllers
{
    //[Authorize]
    public class EntOrgController : AppBaseController
    {
        #region EOM010 - EO_Department 群組
        public ActionResult EOM010()
        {
            return View();
        }

        public ActionResult EOM010Edit(string id)
        {
            var viewMode = "update";
            EO_DepartmentRow row = null;
            if (id.isNullOrEmpty())
            {
                row = EoDataService.Instance.EoDepartment_create().FirstRow;
                row.EOD_DepartmentType = "B";  //A：部門，B：群組
                row.EOD_VirtualType = "A";     //A：可見，B：不可見
                viewMode = "create";
            }
            else
            {
                row = EoDataService.Instance.EoDepartment_getById(id).FirstRow;
                viewMode = "update";
            }
            ViewBag.ViewMode = viewMode;
            return View(row);
        }

        #endregion

        #region [EOM011 - EO_DeptMember 群組成員]
        //新增群組成員-->必需指定群組id
        public ActionResult EOM011Create(string deptId)
        {
            var viewMode = "update";
            var dt = EoDataService.Instance.EoDeptMember_createByDeptId(deptId);
            var row = dt.FirstRow;
            dt.ns_linkColumns(AppDataName.EODM_DeptCode_XX, AppDataName.EODM_DeptName_XX);
            viewMode = "create";
            ViewBag.ViewMode = viewMode;
            return View("EOM011Edit", row);
        }

        public ActionResult EOM011Edit(string id)
        {
            var viewMode = "update";
            EO_DeptMemberRow row = null;
            if (id.isNullOrEmpty())
            {
                row = EoDataService.Instance.EoDeptMember_create().FirstRow;
                viewMode = "create";
            }
            else
            {
                row = EoDataService.Instance.EoDeptMember_getById(id).FirstRow;
                viewMode = "update";
            }
            ViewBag.ViewMode = viewMode;
            return View(row);
        }
        #endregion

        #region EOM020 - EO_Employee 人員
        public ActionResult EOM020()
        {
            return View();
        }

        public ActionResult EOM020Edit(string id)
        {
            var viewMode = "update";
            EO_EmployeeRow row = null;
            if (id.isNullOrEmpty())
            {
                row = EoDataService.Instance.EoEmployee_create().FirstRow;
                //row.EOE_IsOrganManager = "N";
                //row.EOE_IsManager = "N";
                //row.EOE_IsDeptMgr = "N";
                //row.EOE_Enabled = "T";
                viewMode = "create";
            }
            else
            {
                row = EoDataService.Instance.EoEmployee_getById(id).FirstRow;
                viewMode = "update";
            }
            ViewBag.ViewMode = viewMode;
            return View(row);
        }

        public ActionResult EOM020EditProfile(string id)
        {
            var viewMode = "update";
            EO_EmployeeRow row = null;
            if (id.isNullOrEmpty())
            {
                return View("NoData");
            }
            else
            {
                row = EoDataService.Instance.EoEmployee_getById(id).FirstRow;
                viewMode = "update";
            }
            ViewBag.ViewMode = viewMode;
            return View(row);
        }

        #endregion

        #region [EOM021 - EO_DeptMember 人員隸屬群組]
        //新增人員隸屬群組-->必需指定人員id
        public ActionResult EOM021Create(string memberId)
        {
            var viewMode = "update";
            var dt = EoDataService.Instance.EoDeptMember_createByMemberId(memberId);
            var row = dt.FirstRow;
            dt.ns_linkColumns(AppDataName.EODM_EmpCode_XX, AppDataName.EODM_EmpName_XX);
            viewMode = "create";
            ViewBag.ViewMode = viewMode;
            return View("EOM021Edit", row);
        }

        public ActionResult EOM021Edit(string id)
        {
            var viewMode = "update";
            EO_DeptMemberRow row = null;
            if (id.isNullOrEmpty())
            {
                row = EoDataService.Instance.EoDeptMember_create().FirstRow;
                viewMode = "create";
            }
            else
            {
                row = EoDataService.Instance.EoDeptMember_getById(id).FirstRow;
                viewMode = "update";
            }
            ViewBag.ViewMode = viewMode;
            return View(row);
        }
        #endregion

        #region [EOM022 - EO_PermissionSetting 人員授權清單]
        //新增人員授權清單-->必需指定人員id
        public ActionResult EOM022Create(string userId)
        {
            var viewMode = "update";
            var dt = EoDataService.Instance.EoPermissionSetting_createByUserId(userId);
            var row = dt.FirstRow;
            dt.ns_linkColumns(AppDataName.EOPS_PermissionUserName_XX);
            viewMode = "create";
            ViewBag.ViewMode = viewMode;
            return View("EOM022Edit", row);
        }

        public ActionResult EOM022Edit(string id)
        {
            var viewMode = "update";
            EO_PermissionSettingRow row = null;
            if (id.isNullOrEmpty())
            {
                row = EoDataService.Instance.EoPermissionSetting_create().FirstRow;
                viewMode = "create";
            }
            else
            {
                row = EoDataService.Instance.EoPermissionSetting_getById(id).FirstRow;
                viewMode = "update";
            }
            ViewBag.ViewMode = viewMode;
            return View(row);
        }
        #endregion

        #region EOM030 - EO_MenuStruct 功能表維護
        public ActionResult EOM030()
        {
            return View();
        }

        public ActionResult EOM030Edit(string id)
        {
            var viewMode = "update";
            EO_MenuStructRow row = null;
            if (id.isNullOrEmpty())
            {
                row = EoDataService.Instance.EoMenuStruct_create().FirstRow;
                row.EOMS_Viewable = "Y";
                viewMode = "create";
            }
            else
            {
                row = EoDataService.Instance.EoMenuStruct_getById(id).FirstRow;
                viewMode = "update";
            }
            ViewBag.ViewMode = viewMode;
            return View(row);
        }
        #endregion

        #region [EOM031 - EO_MenuFun 程式功能清單]
        //新增程式功能鍵-->必需指定程式代號
        public ActionResult EOM031Create(string itemNo)
        {
            var viewMode = "update";
            var dt = EoDataService.Instance.EoMenuFun_createWithItemNo(itemNo);
            var row = dt.FirstRow;
            viewMode = "create";
            ViewBag.ViewMode = viewMode;
            return View("EOM031Edit", row);
        }

        public ActionResult EOM031Edit(string id)
        {
            var viewMode = "update";
            EO_MenuFunRow row = null;
            if (id.isNullOrEmpty())
            {
                row = EoDataService.Instance.EoMenuFun_create().FirstRow;
                viewMode = "create";
            }
            else
            {
                row = EoDataService.Instance.EoMenuFun_getById(id).FirstRow;
                viewMode = "update";
            }
            ViewBag.ViewMode = viewMode;
            return View(row);
        }
        #endregion

        #region EOM040 - EO_MenuPerm 功能表權限
        public ActionResult EOM040()
        {
            return View();
        }

        public ActionResult EOM040Edit(string id)
        {
            var viewMode = "update";
            EO_MenuPermRow row = null;
            if (id.isNullOrEmpty())
            {
                row = EoDataService.Instance.EoMenuPerm_create().FirstRow;
                row.EOMP_MenuId = "EOM_MAINMENU";
                viewMode = "create";
            }
            else
            {
                row = EoDataService.Instance.EoMenuPerm_getById(id).FirstRow;
                viewMode = "update";
            }

            ViewBag.ViewMode = viewMode;
            return View(row);
        }
        #endregion

        #region EOM050 - EO_EmployeeTitle 職稱
        public ActionResult EOM050()
        {
            return View();
        }

        public ActionResult EOM050Edit(string id)
        {
            var viewMode = "update";
            EO_EmployeeTitleRow row = null;
            if (id.isNullOrEmpty())
            {
                row = EoDataService.Instance.EoEmployeeTitle_create().FirstRow;
                viewMode = "create";
            }
            else
            {
                row = EoDataService.Instance.EoEmployeeTitle_getById(id).FirstRow;
                viewMode = "update";
            }
            ViewBag.ViewMode = viewMode;
            return View(row);
        }
        #endregion

        #region EOM060 - EO_Permission 權限主檔
        public ActionResult EOM060()
        {
            var qm = new EoPermissionQryModel();
            return View(qm);
        }

        public ActionResult EOM060Edit(string id)
        {
            var viewMode = "update";
            EO_PermissionRow row = null;
            if (id.isNullOrEmpty())
            {
                row = EoDataService.Instance.EoPermission_create().FirstRow;
                viewMode = "create";
            }
            else
            {
                row = EoDataService.Instance.EoPermission_getById(id).FirstRow;
                viewMode = "update";
            }
            ViewBag.ViewMode = viewMode;
            return View(row);
        }
        #endregion

        #region EOI010 - 功能授權查詢
        public ActionResult EOI010()
        {
            return View();
        }

        public PartialViewResult EOI010Partial(string userId)
        {
            ViewBag.UserId = userId;
            return PartialView("EOI010Partial");
        }
        #endregion

    }
}
