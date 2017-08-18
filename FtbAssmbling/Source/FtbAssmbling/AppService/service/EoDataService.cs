using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ftd.data;
using ftd.nsql;
using ftd.service;
using ftd;
using ftd.query.model;
using ftd.dataaccess;

namespace ftd.service
{
    /// <summary>
    /// 
    /// </summary>
    public partial class EoDataService : FtdServiceBase
    {
        public static readonly EoDataService Instance;

        static EoDataService()
        {            
            FtdCreatorService.Instance.createObject<EoDataService>(ref Instance);
        }

        #region [EO_Department]
        public EO_DepartmentDataTable EoDepartment_getList(EoDepartmentQryModel qm)
        {
            var dt = NsDmHelper.EO_Department
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.EOD_DepartmentCode == qm.Q_DepartmentCode.toConstOpt1()
                    & t.EOD_DepartmentName.contains(qm.Q_DepartmentName.toConstOpt1())
                )
                .query();

            return dt;
        }

        public EO_DepartmentDataTable EoDepartment_create(int rowCount = 1)
        {
            var dt = new EO_DepartmentDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                dt.addTypedRow(row);
            }
            return dt;
        }

        public EO_DepartmentDataTable EoDepartment_getById(string id)
        {
            var row = NsDmHelper.EO_Department
                .selectAll(t => t.AllExt)
                .wherepk(id)
                .query();

            return row;
        }

        public EO_DepartmentDataTable EoDepartment_getByUniqueKey(String departmentCode)
        {
            var row = NsDmHelper.EO_Department
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.EOD_DepartmentCode == departmentCode.toConstReq1()
                )
                .query();

            return row;
        }

        public bool EoDepartment_checkDuplicate(string id, String departmentCode)
        {
            var row = NsDmHelper.EO_Department
                .where(t =>
                    t.EOD_DepartmentId != id.toConstReq1()
                    & t.EOD_DepartmentCode == departmentCode.toConstReq1()
                )
                .queryFirst();

            return (row != null);
        }

        public bool EoDepartment_deleteBatch(string[] ids)
        {
            var dt = NsDmHelper.EO_Department
                .wherepks(ids)
                .query();

            if (dt == null || dt.Count == 0)
                return false;

            foreach (var row in dt)
            {
                row.Delete();
            }
            dt.ns_update();
            return true;
        }
        #endregion

        #region [EO_Employee]
        public EO_EmployeeDataTable EoEmployee_getList(EoEmployeeQryModel qm)
        {
            string[] empIds = null;
            //有指定群組
            if (!qm.Q_DepartmentCode_XX.isNullOrEmpty())
            {
                var dtDeptMember = NsDmHelper.EO_DeptMember
                    .select(t => t.EODM_MemberId)
                    .where(t => t.EODM_DeptCode_XX == qm.Q_DepartmentCode_XX.toConstReq1())
                    .query();

                empIds = dtDeptMember.Select(x => x.EODM_MemberId).Distinct().ToArray();
            }

            var dt = NsDmHelper.EO_Employee
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.EOE_EmployeeCode == qm.Q_EmployeeCode.toConstOpt1()
                    & t.EOE_LoginAccount_XX == qm.Q_LoginAccount_XX.toConstOpt1()
                    //& t.EOE_IsOrganManager == qm.Q_IsOrganManager.toConstOpt1()
                    //& t.EOE_IsManager == qm.Q_IsManager.toConstOpt1()
                    //& t.EOE_IsDeptMgr == qm.Q_IsDeptMgr.toConstOpt1()
                    //& t.EOE_OrganId == qm.Q_EnterOrgId.toConstOpt1()
                    & t.EOE_EmployeeTitleCode_XX == qm.Q_EmployeeTitleCode_XX.toConstOpt1()
                    & t.EOE_Enabled == qm.Q_Enabled.toConstOpt1()
                    & t.EOE_EmployeeName.contains(qm.Q_EmployeeName.toConstOpt1())
                    & t.EOE_EmployeeId.batchin(empIds.toConstOpt1())
                )
                .query();

            return dt;
        }

        public EO_EmployeeDataTable EoEmployee_create(int rowCount = 1)
        {
            var dt = new EO_EmployeeDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                dt.addTypedRow(row);
            }
            return dt;
        }

        public EO_EmployeeDataTable EoEmployee_getById(string id)
        {
            var row = NsDmHelper.EO_Employee
                .selectAll(t => t.AllExt)
                .wherepk(id)
                .query();

            return row;
        }

        public EO_EmployeeDataTable EoEmployee_getByUniqueKey(String departmentId, String employeeCode)
        {
            var row = NsDmHelper.EO_Employee
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.EOE_DepartmentId == departmentId.toConstReq1()
                    & t.EOE_EmployeeCode == employeeCode.toConstReq1()
                )
                .query();

            return row;
        }

        public bool EoEmployee_checkDuplicate(string id, String departmentId, String employeeCode)
        {
            var row = NsDmHelper.EO_Employee
                .where(t =>
                    t.EOE_EmployeeId != id.toConstReq1()
                    //& t.EOE_DepartmentId == departmentId.toConstReq1()
                    & t.EOE_EmployeeCode == employeeCode.toConstReq1()
                )
                .queryFirst();

            return (row != null);
        }

        public bool EoEmployee_deleteBatch(string[] ids)
        {
            var dt = NsDmHelper.EO_Employee
                .wherepks(ids)
                .query();

            if (dt == null || dt.Count == 0)
                return false;

            foreach (var row in dt)
            {
                row.Delete();
            }
            dt.ns_update();
            return true;
        }
        #endregion

        #region [EO_EmployeeTitle]
        public EO_EmployeeTitleDataTable EoEmployeeTitle_getList(EoEmployeeTitleQryModel qm)
        {
            var dt = NsDmHelper.EO_EmployeeTitle
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.EOET_TitleCode == qm.Q_TitleCode.toConstOpt1()
                    & t.EOET_TitleName.contains(qm.Q_TitleName.toConstOpt1())
                )
                .query();

            return dt;
        }

        public EO_EmployeeTitleDataTable EoEmployeeTitle_create(int rowCount = 1)
        {
            var dt = new EO_EmployeeTitleDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                dt.addTypedRow(row);
            }
            return dt;
        }

        public EO_EmployeeTitleDataTable EoEmployeeTitle_getById(string id)
        {
            var row = NsDmHelper.EO_EmployeeTitle
                .selectAll(t => t.AllExt)
                .wherepk(id)
                .query();

            return row;
        }

        public EO_EmployeeTitleDataTable EoEmployeeTitle_getByUniqueKey(string titleCode)
        {
            var row = NsDmHelper.EO_EmployeeTitle
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.EOET_TitleCode == titleCode.toConstReq1()
                )
                .query();

            return row;
        }

        public bool EoEmployeeTitle_checkDuplicate(string id, string titleCode)
        {
            var row = NsDmHelper.EO_EmployeeTitle
                .where(t =>
                    t.EOET_EmployeeTitleId != id.toConstReq1()
                    & t.EOET_TitleCode == titleCode.toConstReq1()
                )
                .queryFirst();

            return (row != null);
        }

        public bool EoEmployeeTitle_deleteBatch(string[] ids)
        {
            var dt = NsDmHelper.EO_EmployeeTitle
                .wherepks(ids)
                .query();

            if (dt == null || dt.Count == 0)
                return false;

            foreach (var row in dt)
            {
                row.Delete();
            }
            dt.ns_update();
            return true;
        }


        public int EoEmployeeTitle_getListOrderMax()
        {
            var EmployeeTitle = NsDmHelper.EO_EmployeeTitle
                .select(t => t.EOET_ListOrder)
                .orderby(t=>t.EOET_ListOrder.Desc)
                .queryFirst();

            return (int)EmployeeTitle.EOET_ListOrder+1;
        }

        #endregion

        #region [EO_LoginAccount]
        public EO_LoginAccountDataTable EoLoginAccount_getList(String loginAccount, String userEmail_XX, String userName_XX)
        {
            var dt = NsDmHelper.EO_LoginAccount
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.EOLA_LoginAccount == loginAccount.toConstOpt1()
                    & t.EOLA_UserEmail_XX == userEmail_XX.toConstOpt1()
                    & t.EOLA_UserName_XX == userName_XX.toConstOpt1()
                )
                .query();

            return dt;
        }

        public EO_LoginAccountDataTable EoLoginAccount_create(int rowCount = 1)
        {
            var dt = new EO_LoginAccountDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                dt.addTypedRow(row);
            }
            return dt;
        }

        public EO_LoginAccountDataTable EoLoginAccount_getById(string id)
        {
            var row = NsDmHelper.EO_LoginAccount
                .selectAll(t => t.AllExt)
                .wherepk(id)
                .query();

            return row;
        }

        public EO_LoginAccountDataTable EoLoginAccount_getByUniqueKey(String loginAccount, String userEmail_XX)
        {
            var row = NsDmHelper.EO_LoginAccount
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.EOLA_LoginAccount == loginAccount.toConstReq1()
                    & t.EOLA_UserEmail_XX == userEmail_XX.toConstReq1()
                )
                .query();

            return row;
        }

        public bool EoLoginAccount_checkDuplicate(string id, String loginAccount, String userEmail_XX)
        {
            var row = NsDmHelper.EO_LoginAccount
                .where(t =>
                    t.EOLA_LoginAccountId != id.toConstReq1()
                    & t.EOLA_LoginAccount == loginAccount.toConstReq1()
                    & t.EOLA_UserEmail_XX == userEmail_XX.toConstReq1()
                )
                .queryFirst();

            return (row != null);
        }

        public bool EoLoginAccount_deleteBatch(string[] ids)
        {
            var dt = NsDmHelper.EO_LoginAccount
                .wherepks(ids)
                .query();

            if (dt == null || dt.Count == 0)
                return false;

            foreach (var row in dt)
            {
                row.Delete();
            }
            dt.ns_update();
            return true;
        }
        #endregion

        #region [EO_MenuStruct]
        public EO_MenuStructDataTable EoMenuStruct_getList(EoMenuStructQryModel qm)
        {
            if (!qm.Q_Code.isNullOrEmpty())
                qm.Q_Code = qm.Q_Code.ToUpper();

            var dt = NsDmHelper.EO_MenuStruct
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.EOMS_ClickMode == qm.Q_ClickMode.toConstOpt1()
                    & t.EOMS_NodeType_XX == qm.Q_NodeType_XX.toConstOpt1()
                    & t.EOMS_Viewable == qm.Q_Viewable.toConstOpt1()
                    & t.EOMS_Name.contains(qm.Q_Name.toConstOpt1())
                    & t.EOMS_Code.contains(qm.Q_Code.toConstOpt1())
                )
                .query();

            return dt;
        }

        public EO_MenuStructDataTable EoMenuStruct_create(int rowCount = 1)
        {
            var dt = new EO_MenuStructDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                dt.addTypedRow(row);
            }
            return dt;
        }

        public EO_MenuStructDataTable EoMenuStruct_getById(string id)
        {
            var row = NsDmHelper.EO_MenuStruct
                .selectAll(t => t.AllExt)
                .wherepk(id)
                .query();

            return row;
        }

        public EO_MenuStructDataTable EoMenuStruct_getByUniqueKey(string code)
        {
            var row = NsDmHelper.EO_MenuStruct
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.EOMS_Code == code.toConstReq1()
                )
                .query();

            return row;
        }

        public bool EoMenuStruct_checkDuplicate(string id, string code)
        {
            var row = NsDmHelper.EO_MenuStruct
                .where(t =>
                    t.EOMS_NodeId != id.toConstReq1()
                    & t.EOMS_Code == code.toConstReq1()
                )
                .queryFirst();

            return (row != null);
        }

        public bool EoMenuStruct_deleteBatch(string[] ids)
        {
            var dt = NsDmHelper.EO_MenuStruct
                .wherepks(ids)
                .query();

            if (dt == null || dt.Count == 0)
                return false;

            foreach (var row in dt)
            {
                row.Delete();
            }
            dt.ns_update();
            return true;
        }
        #endregion

        #region [EO_Permission]
        public EO_PermissionDataTable EoPermission_getList(EoPermissionQryModel qm)
        {
            var dt = NsDmHelper.EO_Permission
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.EOP_PermissionCode == qm.Q_PermissionCode.toConstOpt1()
                    & t.EOP_PermissionName == qm.Q_PermissionName.toConstOpt1()
                )
                .query();

            return dt;
        }

        public EO_PermissionDataTable EoPermission_create(int rowCount = 1)
        {
            var dt = new EO_PermissionDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                dt.addTypedRow(row);
            }
            return dt;
        }

        public EO_PermissionDataTable EoPermission_getById(string id)
        {
            var row = NsDmHelper.EO_Permission
                .selectAll(t => t.AllExt)
                .wherepk(id)
                .query();

            return row;
        }

        public EO_PermissionDataTable EoPermission_getByUniqueKey(String permissionCode)
        {
            var row = NsDmHelper.EO_Permission
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.EOP_PermissionCode == permissionCode.toConstReq1()
                )
                .query();

            return row;
        }

        public bool EoPermission_checkDuplicate(string id, String permissionCode)
        {
            var row = NsDmHelper.EO_Permission
                .where(t =>
                    t.EOP_PermissionId != id.toConstReq1()
                    & t.EOP_PermissionCode == permissionCode.toConstReq1()
                )
                .queryFirst();

            return (row != null);
        }

        public bool EoPermission_deleteBatch(string[] ids)
        {
            var dt = NsDmHelper.EO_Permission
                .wherepks(ids)
                .query();

            if (dt == null || dt.Count == 0)
                return false;

            foreach (var row in dt)
            {
                row.Delete();
            }
            dt.ns_update();
            return true;
        }
        #endregion

        #region [EO_PermissionSetting]
        public EO_PermissionSettingDataTable EoPermissionSetting_getList(EoPermissionSettingQryModel qm)
        {
            var dt = NsDmHelper.EO_PermissionSetting
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.EOPS_IsEveryOneAllow_XX == qm.Q_IsEveryOneAllow_XX.toConstOpt1()
                    & t.EOPS_IsObjectNeed_XX == qm.Q_IsObjectNeed_XX.toConstOpt1()
                    & t.EOPS_ObjectId == qm.Q_ObjectId.toConstOpt1()
                    & t.EOPS_PermissionId == qm.Q_PermissionId.toConstOpt1()
                    & t.EOPS_PermissionCode_XX == qm.Q_PermissionCode_XX.toConstOpt1()
                    & t.EOPS_PermissionUserId == qm.Q_PermissionUserId.toConstOpt1()
                    & t.EOPS_ObjectName_XX.contains(qm.Q_ObjectName_XX.toConstOpt1())
                    & t.EOPS_PermissionName_XX.contains(qm.Q_PermissionName_XX.toConstOpt1())
                    & t.EOPS_PermissionUserName_XX.contains(qm.Q_PermissionUserName_XX.toConstOpt1())
                )
                .query();

            return dt;
        }

        public EO_PermissionSettingDataTable EoPermissionSetting_create(int rowCount = 1)
        {
            var dt = new EO_PermissionSettingDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                dt.addTypedRow(row);
            }
            return dt;
        }

        public EO_PermissionSettingDataTable EoPermissionSetting_createByUserId(string userId, int rowCount = 1)
        {
            var dt = new EO_PermissionSettingDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                row.EOPS_PermissionUserId = userId;
                dt.addTypedRow(row);
            }
            return dt;
        }

        public EO_PermissionSettingDataTable EoPermissionSetting_getById(string id)
        {
            var row = NsDmHelper.EO_PermissionSetting
                .selectAll(t => t.AllExt)
                .wherepk(id)
                .query();

            return row;
        }

        public bool EoPermissionSetting_deleteBatch(string[] ids)
        {
            var dt = NsDmHelper.EO_PermissionSetting
                .wherepks(ids)
                .query();

            if (dt == null || dt.Count == 0)
                return false;

            foreach (var row in dt)
            {
                row.Delete();
            }
            dt.ns_update();
            return true;
        }

        public bool EoPermissionSetting_checkDuplicate(string id, string userId, string permissionId)
        {
            var row = NsDmHelper.EO_PermissionSetting
                .where(t =>
                    t.EOPS_PermissionSettingId != id.toConstReq1()
                    & t.EOPS_PermissionUserId == userId.toConstReq1()
                    & t.EOPS_PermissionId == permissionId.toConstReq1()
                )
                .queryFirst();

            return (row != null);
        }
        #endregion

        #region [EO_MenuPerm]
        public EO_MenuPermDataTable EoMenuPerm_getList(EoMenuPermQryModel qm)
        {
            var dt = NsDmHelper.EO_MenuPerm
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.EOMP_MenuId == qm.Q_MenuId.toConstOpt1()
                    & t.EOMP_TargetKind == qm.Q_TargetKind.toConstOpt1()
                    & t.EOMP_ViewKind == qm.Q_ViewKind.toConstOpt1()
                    & t.EOMP_TargetName_XX.contains(qm.Q_TargetName_XX.toConstOpt1())
                )
                .query();

            return dt;
        }

        public EO_MenuPermDataTable EoMenuPerm_create(int rowCount = 1)
        {
            var dt = new EO_MenuPermDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                dt.addTypedRow(row);
            }
            return dt;
        }

        public EO_MenuPermDataTable EoMenuPerm_getById(string id)
        {
            var row = NsDmHelper.EO_MenuPerm
                .selectAll(t => t.AllExt)
                .wherepk(id)
                .query();

            return row;
        }

        public bool EoMenuPerm_checkDuplicate(string id, string menuId, string targetId, string viewKind)
        {
            var row = NsDmHelper.EO_MenuPerm
                .where(t =>
                    t.EOMP_MenuPermId != id.toConstReq1()
                    & t.EOMP_MenuId == menuId.toConstReq1()
                    & t.EOMP_TargetId == targetId.toConstReq1()
                    & t.EOMP_ViewKind == viewKind.toConstReq1()
                )
                .queryFirst();

            return (row != null);
        }

        public bool EoMenuPerm_deleteBatch(string[] ids)
        {
            var dt = NsDmHelper.EO_MenuPerm
                .wherepks(ids)
                .query();

            if (dt == null || dt.Count == 0)
                return false;

            var dtDetail = NsDmHelper.EO_MenuPermSet
                .where(t => t.EOMPS_MenuPermId.@in(ids.toConstReq1()))
                .query();

            dt.forEach(x => x.Delete());
            dtDetail.forEach(x => x.Delete());

            var scope = new FdbTransScope(FdbTransScopeOption.RequiresNew);
            using (scope.Use)
            {
                dt.ns_update();
                dtDetail.ns_update();
                scope.complete();
            }

            return true;
        }

        public string EoMenuPerm_updatePermSet(EO_MenuPermRow row, List<string> lstItemNos, Dictionary<string, List<string>> dicFuns)
        {
            //程式功能清單
            var dtMenuFun = NsDmHelper.EO_MenuFun
                .selectAll()
                .query();

            //程式授權
            var dtMenuPermSet = NsDmHelper.EO_MenuPermSet
                .selectAll()
                .where(t => t.EOMPS_MenuPermId == row.EOMP_MenuPermId)
                .query();

            var menuPermSetIds = dtMenuPermSet.Select(x => x.EOMPS_MenuPermSetId).ToArray();

            //程式功能授權
            var dtFunPermSet = NsDmHelper.EO_FunPermSet
                .selectAll(t => t.AllExt)
                .where(t => t.EOFPS_MenuPermSetId.batchin(menuPermSetIds.toConstReq1()))
                .query();

            List<string> cmds = null;

            foreach (var itemNo in lstItemNos)
            {
                var menuPermSet = dtMenuPermSet.Where(x => x.EOMPS_MenuItemNo == itemNo).FirstOrDefault();
                if (menuPermSet == null)
                {
                    menuPermSet = dtMenuPermSet.newTypedRow();
                    menuPermSet.ns_AssignNewId();
                    menuPermSet.EOMPS_MenuItemNo = itemNo;
                    menuPermSet.EOMPS_MenuPermId = row.EOMP_MenuPermId;
                    dtMenuPermSet.addTypedRow(menuPermSet);
                }

                //程式功能
                if (!dicFuns.Keys.Contains(itemNo))
                    continue;

                cmds = dicFuns[itemNo];
                foreach (var cmd in cmds)
                {
                    var menuFun = dtMenuFun.Where(x => x.EOMF_ItemNo == itemNo & x.EOMF_FunctionCode == cmd).FirstOrDefault();
                    if (menuFun == null)
                        continue;

                    var funPermSet = dtFunPermSet.Where(x =>
                            x.EOFPS_MenuPermSetId == menuPermSet.EOMPS_MenuPermSetId
                            & x.EOFPS_FunctionCode_XX == cmd
                        ).FirstOrDefault();

                    if (funPermSet == null)
                    {
                        funPermSet = dtFunPermSet.newTypedRow();
                        funPermSet.ns_AssignNewId();
                        funPermSet.EOFPS_MenuFunId = menuFun.EOMF_MenuFunId;
                        funPermSet.EOFPS_MenuPermSetId = menuPermSet.EOMPS_MenuPermSetId;
                        funPermSet.EOFPS_MenuItemNo_XX = itemNo;
                        funPermSet.EOFPS_FunctionCode_XX = menuFun.EOMF_FunctionCode;
                        funPermSet.EOFPS_FunctionName_XX = menuFun.EOMF_FunctionName;
                        dtFunPermSet.addTypedRow(funPermSet);
                    }
                }
            }

            //刪除不存在者
            var keyMenus = lstItemNos.Select(x => row.EOMP_MenuPermId + "#" + x).ToArray();
            var delMenus = dtMenuPermSet.Where(x => !(x.EOMPS_MenuPermId + "#" + x.EOMPS_MenuItemNo).inAny(keyMenus)).ToArray();
            delMenus.forEach(x => x.Delete());

            var keyFuns = new List<string>();
            foreach (var key in dicFuns.Keys)
            {
                var funs = dicFuns[key].Select(x => key + "#" + x).ToArray();
                keyFuns.AddRange(funs);                
            }
            var delFuns = dtFunPermSet.Where(x => !(x.EOFPS_MenuItemNo_XX + "#" + x.EOFPS_FunctionCode_XX).inAny(keyFuns)).ToArray();
            delFuns.forEach(x => x.Delete());

            var scope = new FdbTransScope(FdbTransScopeOption.RequiresNew);
            using (scope.Use)
            {
                dtMenuPermSet.ns_update();
                dtFunPermSet.ns_update();
                scope.complete();
            }

            return "OK";
        }
        #endregion

        #region [EO_MenuPermSet]
        public EO_MenuPermSetDataTable EoMenuPermSet_getList(string MenuPermId)
        {
            var dt = NsDmHelper.EO_MenuPermSet
                .selectAll(t => t.AllExt)
                .where(t =>t.EOMPS_MenuPermId == MenuPermId.toConstReq1())
                .query();
            return dt;
        }

        public EO_MenuPermSetDataTable EoMenuPermSet_getById(string id)
        {
           var dt = NsDmHelper.EO_MenuPermSet
                .selectAll(t => t.AllExt)
                .wherepk(id)
                .query();
            return dt;
        }

        public EO_MenuPermSetDataTable EoMenuPermSet_getByMenuPerId(string menuPermId)
        {
            var dt = NsDmHelper.EO_MenuPermSet
                 .selectAll(t => t.AllExt)
                 .where(t => t.EOMPS_MenuPermId == menuPermId.toConstReq1())
                 .query();
            return dt;
        }
        #endregion

        #region [EO_UserEvent]
        public EO_UserEventDataTable EoUserEvent_getList(EoUserEventQryModel qm)
        {
            var dt = NsDmHelper.EO_UserEvent
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.EOUE_EventCode == qm.Q_EventCode.toConstOpt1()
                    & t.EOUE_KindName == qm.Q_KindName.toConstOpt1()
                    & t.EOUE_Description == qm.Q_Description.toConstOpt1()
                )
                .query();

            return dt;
        }

        public EO_UserEventDataTable EoUserEvent_create(int rowCount = 1)
        {
            var dt = new EO_UserEventDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                dt.addTypedRow(row);
            }
            return dt;
        }

        public EO_UserEventDataTable EoUserEvent_getById(string id)
        {
            var row = NsDmHelper.EO_UserEvent
                .selectAll(t => t.AllExt)
                .wherepk(id)
                .query();

            return row;
        }

        public EO_UserEventDataTable EoUserEvent_getByUniqueKey(string eventCode)
        {
            var row = NsDmHelper.EO_UserEvent
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.EOUE_EventCode == eventCode.toConstReq1()
                )
                .query();

            return row;
        }

        public bool EoUserEvent_checkDuplicate(string id, string eventCode)
        {
            var row = NsDmHelper.EO_UserEvent
                .where(t =>
                    t.EOUE_UserEventId != id.toConstReq1()
                    & t.EOUE_EventCode == eventCode.toConstReq1()
                )
                .queryFirst();

            return (row != null);
        }

        public bool EoUserEvent_deleteBatch(string[] ids)
        {
            var dt = NsDmHelper.EO_UserEvent
                .wherepks(ids)
                .query();

            if (dt == null || dt.Count == 0)
                return false;

            foreach (var row in dt)
            {
                row.Delete();
            }
            dt.ns_update();
            return true;
        }
        #endregion

        #region [EO_UserEventLog]
        public EO_UserEventLogDataTable EoUserEventLog_getList(EoUserEventLogQryModel qm)
        {
            DateTime? dateFrom = null;
            DateTime? dateTo = null;
            if (qm.Q_EventDateFrom.HasValue)
                dateFrom = qm.Q_EventDateFrom.Value.Date;
            else
                dateFrom = DateTime.Today;

            if (qm.Q_EventDateTo.HasValue)
                dateTo = qm.Q_EventDateTo.Value.Date.AddDays(1);
            else
                dateTo = DateTime.Today.AddDays(1);

            var dt = NsDmHelper.EO_UserEventLog
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.EOUEL_EventDate >= dateFrom.toConstReq1()
                    & t.EOUEL_EventDate < dateTo.toConstReq1()
                    & t.EOUEL_UserEventCode_XX == qm.Q_UserEventCode_XX.toConstOpt1()
                    & t.EOUEL_UserEventName_XX.contains(qm.Q_UserEventName_XX.toConstOpt1())
                    & t.EOUEL_UserName_XX.contains(qm.Q_UserName_XX.toConstOpt1())
                )
                .query();

            return dt;
        }

        public EO_UserEventLogDataTable EoUserEventLog_create(int rowCount = 1)
        {
            var dt = new EO_UserEventLogDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                dt.addTypedRow(row);
            }
            return dt;
        }

        public EO_UserEventLogDataTable EoUserEventLog_getById(string id)
        {
            var row = NsDmHelper.EO_UserEventLog
                .selectAll(t => t.AllExt)
                .wherepk(id)
                .query();

            return row;
        }

        public bool EoUserEventLog_deleteBatch(string[] ids)
        {
            var dt = NsDmHelper.EO_UserEventLog
                .wherepks(ids)
                .query();

            if (dt == null || dt.Count == 0)
                return false;

            foreach (var row in dt)
            {
                row.Delete();
            }
            dt.ns_update();
            return true;
        }
        #endregion

        #region [EO_DeptMember]
        public EO_DeptMemberDataTable EoDeptMember_getList(EoDeptMemberQryModel qm)
        {
            var dt = NsDmHelper.EO_DeptMember
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.EODM_MemberId == qm.Q_MemberId.toConstOpt1()
                    & t.EODM_DeptId == qm.Q_DeptId.toConstOpt1()
                )
                .query();

            return dt;
        }

        public EO_DeptMemberDataTable EoDeptMember_create(int rowCount = 1)
        {
            var dt = new EO_DeptMemberDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                dt.addTypedRow(row);
            }
            return dt;
        }

        public EO_DeptMemberDataTable EoDeptMember_createByDeptId(string deptId, int rowCount = 1)
        {
            var dt = new EO_DeptMemberDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                row.EODM_DeptId = deptId;
                dt.addTypedRow(row);
            }
            return dt;
        }

        public EO_DeptMemberDataTable EoDeptMember_createByMemberId(string memberId, int rowCount = 1)
        {
            var dt = new EO_DeptMemberDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                row.EODM_MemberId = memberId;
                dt.addTypedRow(row);
            }
            return dt;
        }

        public EO_DeptMemberDataTable EoDeptMember_getById(string id)
        {
            var row = NsDmHelper.EO_DeptMember
                .selectAll(t => t.AllExt)
                .wherepk(id)
                .query();

            return row;
        }

        public EO_DeptMemberDataTable EoDeptMember_getByDeptId(string deptId)
        {
            var row = NsDmHelper.EO_DeptMember
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.EODM_DeptId == deptId.toConstReq1()
                )
                .query();

            return row;
        }

        public EO_DeptMemberDataTable EoDeptMember_getByMemberId(string memberId)
        {
            var row = NsDmHelper.EO_DeptMember
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.EODM_MemberId == memberId.toConstReq1()
                )
                .query();

            return row;
        }

        public bool EoDeptMember_deleteBatch(string[] ids)
        {
            var dt = NsDmHelper.EO_DeptMember
                .wherepks(ids)
                .query();

            if (dt == null || dt.Count == 0)
                return false;

            foreach (var row in dt)
            {
                row.Delete();
            }
            dt.ns_update();
            return true;
        }

        public bool EoDeptMember_checkDuplicate(string id, string departmentId, string memberId)
        {
            var row = NsDmHelper.EO_DeptMember
                .where(t =>
                    t.EODM_DeptMemberId != id.toConstReq1()
                    & t.EODM_DeptId == departmentId.toConstReq1()
                    & t.EODM_MemberId == memberId.toConstReq1()
                )
                .queryFirst();

            return (row != null);
        }
        #endregion

        #region [EO_MenuFun]
        public EO_MenuFunDataTable EoMenuFun_getList(EoMenuFunQryModel qm)
        {
            var dt = NsDmHelper.EO_MenuFun
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.EOMF_FunctionCode == qm.Q_FunctionCode.toConstOpt1()
                    & t.EOMF_ItemNo == qm.Q_ItemNo.toConstOpt1()
                    & t.EOMF_ToolbarLevel == qm.Q_ToolbarLevel.toConstOpt1()
                    & t.EOMF_FunctionName.contains(qm.Q_FunctionName.toConstOpt1())
                )
                .orderby(t => new[]{
                    t.EOMF_ItemNo.Asc, 
                    t.EOMF_SeqNo.Asc
                })
                .query();

            return dt;
        }

        public EO_MenuFunDataTable EoMenuFun_create(int rowCount = 1)
        {
            var dt = new EO_MenuFunDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                dt.addTypedRow(row);
            }
            return dt;
        }

        public EO_MenuFunDataTable EoMenuFun_createWithItemNo(string itemNo, int rowCount = 1)
        {
            var dt = new EO_MenuFunDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                row.EOMF_ItemNo = itemNo;
                dt.addTypedRow(row);
            }
            return dt;
        }

        public string EoMenuFun_addDefaultFunctions(string itemNo)
        {
            string[] cmdCodes = new string[] { "QUERY", "CREATE", "UPDATE", "DELETE" };
            string[] cmdNames = new string[] { "查詢", "新增", "修改", "刪除" };
            string[] toolbarLevel = new string[] { "F", "T", "R", "R" };

            var dt = NsDmHelper.EO_MenuFun
                .selectAll()
                .where(t =>
                    t.EOMF_ItemNo == itemNo.toConstReq1()
                    & t.EOMF_FunctionCode.@in(cmdCodes.toConstReq1())
                ).query();

            for (int i = 0; i < cmdCodes.Length; i++)
	        {
                var row = dt.Where(x => x.EOMF_FunctionCode == cmdCodes[i]).FirstOrDefault();
                if (row != null)
                    continue;

                row = dt.newTypedRow();
                row.ns_AssignNewId();
                row.EOMF_FunctionCode = cmdCodes[i];
                row.EOMF_FunctionName = cmdNames[i];
                row.EOMF_ToolbarLevel = toolbarLevel[i];
                row.EOMF_ItemNo = itemNo;
                row.EOMF_SeqNo = i + 1;
                dt.addTypedRow(row);
	        }
            dt.ns_update();
            return "OK";
        }

        public EO_MenuFunDataTable EoMenuFun_getById(string id)
        {
            var row = NsDmHelper.EO_MenuFun
                .selectAll(t => t.AllExt)
                .wherepk(id)
                .query();

            return row;
        }

        public EO_MenuFunDataTable EoMenuFun_getByUniqueKey(string itemNo, string functionCode)
        {
            var row = NsDmHelper.EO_MenuFun
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.EOMF_ItemNo == itemNo.toConstReq1()
                    & t.EOMF_FunctionCode == functionCode.toConstReq1()
                )
                .query();

            return row;
        }

        public bool EoMenuFun_checkDuplicate(string id, string itemNo, string functionCode)
        {
            var row = NsDmHelper.EO_MenuFun
                .where(t =>
                    t.EOMF_MenuFunId != id.toConstReq1()
                    & t.EOMF_ItemNo == itemNo.toConstReq1()
                    & t.EOMF_FunctionCode == functionCode.toConstReq1()
                )
                .queryFirst();

            return (row != null);
        }

        public bool EoMenuFun_deleteBatch(string[] ids)
        {
            var dt = NsDmHelper.EO_MenuFun
                .wherepks(ids)
                .query();

            if (dt == null || dt.Count == 0)
                return false;

            var funIds = dt.Select(x => x.EOMF_MenuFunId).ToArray();
            var dtFunPermSet = NsDmHelper.EO_FunPermSet
                .select()
                .where(t => t.EOFPS_MenuFunId.@in(funIds.toConstReq1()))
                .query();

            dtFunPermSet.forEach(x => x.Delete());
            dt.forEach(x => x.Delete());

            var scope = new FdbTransScope(FdbTransScopeOption.RequiresNew);
            using (scope.Use)
            {
                dtFunPermSet.ns_update();
                dt.ns_update();
                scope.complete();
            }
            return true;
        }
        #endregion

        #region [EO_FunPermSet]
        public EO_FunPermSetDataTable EoFunPermSet_getList(EoFunPermSetQryModel qm)
        {
            var dt = NsDmHelper.EO_FunPermSet
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.EOFPS_FunctionCode_XX == qm.Q_FunctionCode_XX.toConstOpt1()
                    & t.EOFPS_MenuItemNo_XX == qm.Q_MenuItemNo_XX.toConstOpt1()
                    & t.EOFPS_FunctionName_XX.contains(qm.Q_FunctionName_XX.toConstOpt1())
                    & t.EOFPS_MenuItemNoName_XX.contains(qm.Q_MenuItemNoName_XX.toConstOpt1())
                )
                .query();

            return dt;
        }

        public EO_FunPermSetDataTable EoFunPermSet_create(int rowCount = 1)
        {
            var dt = new EO_FunPermSetDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                dt.addTypedRow(row);
            }
            return dt;
        }

        public EO_FunPermSetDataTable EoFunPermSet_getById(string id)
        {
            var row = NsDmHelper.EO_FunPermSet
                .selectAll(t => t.AllExt)
                .wherepk(id)
                .query();

            return row;
        }

        public EO_FunPermSetDataTable EoFunPermSet_getByMenuPermSetIds(string[] menuPermSetIds)
        {
            var row = NsDmHelper.EO_FunPermSet
                .selectAll(t => t.AllExt)
                .where(t => t.EOFPS_MenuPermSetId.batchin(menuPermSetIds.toConstReq1()))
                .query();

            return row;
        }

        public EO_FunPermSetDataTable EoFunPermSet_getByUniqueKey(string menuFunId, string menuPermSetId)
        {
            var row = NsDmHelper.EO_FunPermSet
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.EOFPS_MenuFunId == menuFunId.toConstReq1()
                    & t.EOFPS_MenuPermSetId == menuPermSetId.toConstReq1()
                )
                .query();

            return row;
        }

        public bool EoFunPermSet_checkDuplicate(string id, string menuFunId, string menuPermSetId)
        {
            var row = NsDmHelper.EO_FunPermSet
                .where(t =>
                    t.EOFPS_FunPermSetId != id.toConstReq1()
                    & t.EOFPS_MenuFunId == menuFunId.toConstReq1()
                    & t.EOFPS_MenuPermSetId == menuPermSetId.toConstReq1()
                )
                .queryFirst();

            return (row != null);
        }

        public bool EoFunPermSet_deleteBatch(string[] ids)
        {
            var dt = NsDmHelper.EO_FunPermSet
                .wherepks(ids)
                .query();

            if (dt == null || dt.Count == 0)
                return false;

            foreach (var row in dt)
            {
                row.Delete();
            }
            dt.ns_update();
            return true;
        }
        #endregion

    }
}
