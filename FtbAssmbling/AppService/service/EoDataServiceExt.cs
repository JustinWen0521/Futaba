using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Linq;
using ftd.data;
using ftd.nsql;
using ftd.service;
using System.Web;
using ftd.web;
using ftd.query.model;

namespace ftd.service
{
    /// <summary>
    /// EoMenuService
    /// </summary>
    public partial class EoDataService : FtdServiceBase
    {
        #region [EO_Permission]
        /// <summary>
        /// 取得給使用者的權限
        /// </summary>        
        public EO_PermissionDataTable queryPermissionForUsers(string[] userIds, string[] extendFieldNames)
        {
            var qrydb = new NsDbQuery();
            DataTable dt1 = null;
            {
                //人員所擁有的權限
                qrydb.setSelect(s =>
                {

                    var t1 = s.from<EO_PermissionSetting>();
                    var t2 = s.join<EO_Permission>()
                        .on(t => t.EOP_PermissionId == t1.EOPS_PermissionId);
                    s.select(t2.EOP_PermissionId);
                    s.Where = t1.EOPS_PermissionUserId.batchin(userIds.toConstReq1())
                        & t2.EOP_IsObjectNeed == "N"
                        & t2.EOP_IsEveryOneAllow == "N";
                });
                dt1 = qrydb.queryData();
            }

            {
                //EveryOne都可以有的權限
                qrydb.setSelect(s =>
                {
                    var t1 = s.from<EO_Permission>();
                    s.select(t1.EOP_PermissionId);
                    s.Where = t1.EOP_IsObjectNeed == "N"
                        & t1.EOP_IsEveryOneAllow == "Y";
                });
                qrydb.fillData(dt1);
            }

            {
                var pks = FtdDataHelper.getDistinctArray<string>(dt1, dt1.Columns[0]);
                var qry = new NsDmQuery();
                var t1 = qry.from<EO_Permission>();
                qry.selectAll(extendFieldNames);
                qry.Where = t1.EOP_PermissionId.batchin(pks.toConstReq1());
                var dt = (EO_PermissionDataTable)qry.queryData();
                return dt;
            }
        }

        #endregion

        #region [EO_PermissionSetting]
        public EO_PermissionSettingRow queryPermissionSettingByPermIdUserId(string permId, string userId, string[] extendFieldNames)
        {
            var qry = new NsDmQuery();
            var t1 = qry.from<EO_PermissionSetting>();
            qry.selectAll(extendFieldNames);
            qry.Where = t1.EOPS_PermissionId == permId.toConstReq1()
                & t1.EOPS_PermissionUserId == userId.toConstReq1();
            var dt = ((EO_PermissionSettingDataTable)qry.queryData());
            return dt.FirstRow;
        }

        /// <summary>
        /// 查詢物件所屬權限
        /// </summary>
        public EO_PermissionSettingDataTable queryPermissionSettingsByObjectIdsPermId(string[] objectIds, string permissionCode, string[] extendFieldNames)
        {
            var qry = new NsDmQuery();
            var t1 = qry.from<EO_PermissionSetting>();
            qry.selectAll(extendFieldNames);
            qry.Where = t1.EOPS_PermissionCode_XX == permissionCode.toConstReq1()
                & t1.EOPS_ObjectId.batchin(objectIds.toConstReq1());
            var dt = ((EO_PermissionSettingDataTable)qry.queryData());
            return dt;
        }

        public EO_PermissionSettingDataTable queryPermissionSettingsBy(string[] objectIds, string[] permCodes, string[] extendFieldNames)
        {
            var qry = new NsDmQuery();
            var t1 = qry.from<EO_PermissionSetting>();
            qry.selectAll(extendFieldNames);
            qry.Where = t1.EOPS_ObjectId.batchin(objectIds.toConstReq1())
                & t1.EOPS_PermissionCode_XX.@in(permCodes.toConstReq1());
            var dt = (EO_PermissionSettingDataTable)qry.queryData();
            return dt;
        }

        /// <summary>
        /// 取得指定物件新權限設定所必須的改變
        /// </summary>        
        public EO_PermissionSettingDataTable infoObjectNewPermissionSettings(string objectId, string permissionCode, List<string> newUserIds)
        {
            var qry = new NsDmQuery();
            var dt1 = queryPermissionSettingsByObjectIdsPermId(new string[] { objectId }, permissionCode, new string[] { });

            var oldUserIds = new List<string>();
            {
                foreach (var row1 in dt1.TypeRows)
                    oldUserIds.Add(row1.EOPS_PermissionUserId);
            }

            var t1 = qry.from<EO_Permission>();
            qry.Where = t1.EOP_PermissionCode == permissionCode.toConstReq1();
            var rowp = ((EO_PermissionDataTable)qry.queryData()).FirstRow;

            //新人員不存在者新增
            foreach (var userid in newUserIds)
            {
                if (!oldUserIds.Contains(userid))
                {
                    var row1 = dt1.newTypedRow();
                    row1.ns_AssignNewId();
                    row1.EOPS_PermissionUserId = userid;
                    row1.EOPS_PermissionId = rowp.EOP_PermissionId;
                    row1.EOPS_ObjectId = objectId;
                    dt1.addTypedRow(row1);
                }
            }

            //舊人員不存在者刪除  
            foreach (var userid in oldUserIds)
            {
                if (!newUserIds.Contains(userid))
                {
                    dt1.Rows[oldUserIds.IndexOf(userid)].Delete();
                }
            }
            return dt1;
        }

        /// <summary>
        /// 查詢指定使用者的權限清單
        /// 如果使用者為人員的話，會包含其所屬部門權限
        /// </summary>
        public EO_PermissionSettingDataTable queryPermissionSettingsForUserId(string userId, string[] extendFieldNames)
        {
            //取得人員與其所屬群組代號
            List<string> userIds = new List<string>();
            var qry = new NsDbQuery();
            qry.setSelect(s3 =>
            {
                var t11 = s3.from<EO_PermissionSetting>();
                s3.select(t11.EOPS_PermissionSettingId);
                s3.Where = qry.inquery(t11.EOPS_PermissionUserId,
                    s2 =>
                    {
                        s2.fromEmpty(AppDataName.EO);
                        s2.select(userId.toConst().As("UserId"));
                        s2.Where = userId.toConstReq1() != "";
                        s2.union(s =>
                        {
                            var t1 = s.from<EO_DeptMember>();
                            s.select(t1.EODM_DeptId);
                            s.Where = t1.EODM_MemberId == userId.toConstReq(userId.StartsWith("EOE_"))
                                ;
                            s.groupBy(t1.EODM_DeptId);
                        });
                    });
            });

            var keys = qry.queryKeys<string>();
            var dt = NsDmHelper.EO_PermissionSetting
                .selectAll(extendFieldNames)
                .where(t0 => t0.EOPS_PermissionSettingId.batchin(keys.toConstReq1()))
                .query();
            return dt;
        }
        #endregion

        /// <summary>
        /// 查詢功能表的所有功能項目(不含目錄)
        /// </summary> 
        public List<FtdXmlMenuNode> queryMenuFunctions(string menuId, params string[] extAttrNames)
        {
            //var rowm = NsDmHelper.EO_Menu.wherepk(menuId).selectAll(t => t.EOM_FileFullName_XX).queryFirst();

            //var xmlmenu = new FtdXmlMenu();
            //xmlmenu.loadXmlMenu(rowm.EOM_FileFullName_XX);

            var xmlmenu = getMenu(menuId);

            var r = xmlmenu.selectNodes(
                node => node.ChildNodes.Count == 0
            );
            return r;
        }

        /// <summary>
        /// 查詢指定的使用者可以使用的權限清單
        /// </summary>     
        public List<string> queryUserFunctions(string usrId, string menuId)
        {
            var targetIds = new List<string>();
            //Find Use's All Target
            {
                var usrperm = FtdPermissionService.Instance.getActorPermission(usrId);
                var permCodes = usrperm.PermissionNames;
                var permIds = NsDmHelper.EO_Permission
                    .where(t => t.EOP_PermissionCode.batchin(permCodes.toConstReq1()))
                    .query()
                    .Select(x => x.EOP_PermissionId)
                    .ToArray();

                //權限Id
                targetIds.AddRange(permIds);

                var rowe = NsDmHelper.EO_Employee.wherepk(usrId).queryFirst();
                if (rowe != null)
                {
                    //人員Id
                    targetIds.Add(rowe.EOE_EmployeeId);
                    //職稱Id
                    if (!rowe.EOE_EmployeeTitleId.isNullOrEmpty())
                        targetIds.Add(rowe.EOE_EmployeeTitleId);
                    //部門Id
                    if (!rowe.EOE_DepartmentId.isNullOrEmpty())
                        targetIds.Add(rowe.EOE_DepartmentId);
                    ////機關id
                    //if (!rowe.EOE_OrganId.isNullOrEmpty())
                    //    targetIds.Add(rowe.EOE_OrganId);
                    //群組Id
                    var dt2 = NsDmHelper.EO_DeptMember.where(t => t.EODM_MemberId == usrId.toConstReq1()).query();
                    dt2.forEach(x => targetIds.Add(x.EODM_DeptId));
                }
            }

            //Find Target's All Viewable Function
            var qry = new NsDbQuery();
            qry.setSelect(s =>
            {
                var t1 = s.from<EO_MenuPerm>();
                var t2 = s.join<EO_MenuPermSet>()
                    .on(t => t1.EOMP_MenuPermId == t.EOMPS_MenuPermId);

                s.Where = t1.EOMP_MenuId == menuId.toConstReq1()
                    & t1.EOMP_TargetId.batchin(targetIds.toConstReq1());

                s.select(
                    t2.EOMPS_MenuItemNo.As("ItemNo")
                    , t1.EOMP_ViewKind.decode("A", 0, "B", 1).sum().As("Viewable") //Value == 0 代表可檢視
                );
                s.groupBy(s.Selects[0]);
                s.Having = s.Selects[1] == 0;//Value == 0 代表可檢視
            });
            var dt = qry.queryData();
            var funs = dt.Rows.Cast<DataRow>().Select(x => x.getString("ItemNo")).ToList();
            return funs;
        }


        /// <summary>
        /// 查詢指定的使用者可以使用的權限清單
        /// </summary>     
        //private  Dictionary<string, Dictionary<string, string>> queryUserFunCmds(string usrId, string menuId)
        public Dictionary<string, Dictionary<string, string>> queryUserFunPermSet(string usrId, string menuId)
        {
            var targetIds = new List<string>();
            #region //Find Use's All Target
            {
                var usrperm = FtdPermissionService.Instance.getActorPermission(usrId);
                var permCodes = usrperm.PermissionNames;
                var permIds = NsDmHelper.EO_Permission
                    .where(t => t.EOP_PermissionCode.batchin(permCodes.toConstReq1()))
                    .query()
                    .Select(x => x.EOP_PermissionId)
                    .ToArray();

                //權限Id
                targetIds.AddRange(permIds);

                var rowe = NsDmHelper.EO_Employee.wherepk(usrId).queryFirst();
                if (rowe != null)
                {
                    //人員Id
                    targetIds.Add(rowe.EOE_EmployeeId);
                    //職稱Id
                    if (!rowe.EOE_EmployeeTitleId.isNullOrEmpty())
                        targetIds.Add(rowe.EOE_EmployeeTitleId);
                    //部門Id
                    if (!rowe.EOE_DepartmentId.isNullOrEmpty())
                        targetIds.Add(rowe.EOE_DepartmentId);
                    //群組Id
                    var dt2 = NsDmHelper.EO_DeptMember.where(t => t.EODM_MemberId == usrId.toConstReq1()).query();
                    dt2.forEach(x => targetIds.Add(x.EODM_DeptId));
                }
            }
            #endregion

            //Find Target's All Viewable Function
            var qry = new NsDbQuery();
            qry.setSelect(s =>
            {
                var t1 = s.from<EO_MenuPerm>();
                var t2 = s.join<EO_MenuPermSet>()
                    .on(t => t1.EOMP_MenuPermId == t.EOMPS_MenuPermId);

                s.Where = t1.EOMP_MenuId == menuId.toConstReq1()
                    & t1.EOMP_TargetId.batchin(targetIds.toConstReq1());

                s.select(
                    t2.EOMPS_MenuPermSetId.As("MenuPermSetId"),
                    t1.EOMP_ViewKind.decode("A", 0, "B", 1).sum().As("Viewable") //Value == 0 代表可檢視
                );

                s.groupBy(
                    s.Selects[0]
                );

                s.Having = s.Selects[1] == 0;//Value == 0 代表可檢視
            });
            var dt = qry.queryData();
            var menuPermSetIds = dt.Rows.Cast<DataRow>().Select(x => x.getString("MenuPermSetId")).ToList();

            var dtFunPermSet = NsDmHelper.EO_FunPermSet
                .selectAll(t => t.AllExt)
                .where(t => t.EOFPS_MenuPermSetId.batchin(menuPermSetIds.toConstReq1()))
                .orderby(t => new[]{
                    t.EOFPS_MenuItemNo_XX.Asc,
                    t.EOFPS_FunctionSeqNo_XX.Asc
                })
                .query();

            //var cmds = dtFunPermSet.GroupBy(x =>
            //        x.EOFPS_MenuItemNo_XX,
            //        y => new
            //        {
            //            Code = y.EOFPS_FunctionCode_XX,
            //            Name = y.EOFPS_FunctionName_XX
            //        }
            //    )
            //    .ToDictionary(x =>
            //        x.Key,
            //        y => y.ToDictionary(a => a.Code, b => b.Name)
            //    );

            Dictionary<string, Dictionary<string, string>> dicCmds = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, string> dicFuns = null;
            var itemNos = dtFunPermSet.Select(x => x.EOFPS_MenuItemNo_XX).Distinct().ToArray();
            foreach (var item in itemNos)
            {
                if (!dicCmds.Keys.Contains(item))
                {
                    dicCmds.Add(item, new Dictionary<string, string>());
                }
                dicFuns = dicCmds[item];

                var funs = dtFunPermSet.Where(x => x.EOFPS_MenuItemNo_XX == item).OrderBy(x => x.EOFPS_FunctionSeqNo_XX).ToArray();
                foreach (var fun in funs)
                {
                    if (dicFuns.Keys.Contains(fun.EOFPS_FunctionCode_XX))
                        dicFuns[fun.EOFPS_FunctionCode_XX] = fun.EOFPS_FunctionName_XX;
                    else
                        dicFuns.Add(fun.EOFPS_FunctionCode_XX, fun.EOFPS_FunctionName_XX);
                }
            }
            return dicCmds;
        }

        //public List<FtdXmlMenuNode> getUserMenus(string userId)
        public FtdXmlMenu getUserMenus(string userId)
        {
            //var xmlmenu = new FtdXmlMenu();
            //xmlmenu.loadXmlMenu(HttpContext.Current.Server.MapPath("~/data/AppMainMenu.xml"));
            var menuId = "EOM_MAINMENU";
            var xmlmenu = getMenu(menuId);
            var userPermission = FtdPermissionService.Instance.getActorPermission(userId);
            var isAdmin = userPermission.containPermisson(AppPermissionName.APN_APP_SystemAdmin);
            //var isadmin =  AppUserSession.User.containsPermission(AppPermissionName.APN_APP_SystemAdmin);
            var itemNos = EoDataService.Instance.queryUserFunctions(userId, menuId);
            xmlmenu.doNodeFilter(x =>
            {
                if (x.ChildNodes.Count > 0)
                    return false;
                var isok = isAdmin || itemNos.Contains(x.Attributes["itemNo"]);
                return !isok;
            });
            return xmlmenu;

            //var xmlMenuNodes = xmlmenu.selectNodes(node => true
            //    //, new[] { "itemNo", "class", "title" }
            //);
            //return xmlMenuNodes;
        }

        public FtdXmlMenu getMenu(bool isAll = false)
        {
            return getMenu("", isAll);
        }

        public FtdXmlMenu getMenu(string menuId, bool isAll = false)
        {
            if (menuId.isNullOrEmpty())
                menuId = "EOM_MAINMENU";

            //功能表
            var menu = NsDmHelper.EO_Menu
                .selectAll()
                .where(t => t.EOM_MenuId == menuId.toConstReq1())
                .queryFirst();

            var xmlmenu = new FtdXmlMenu();

            // XML檔案
            if (menu.EOM_StructSource.equalIgnoreCase("F"))
            {
                xmlmenu.loadXmlMenu(HttpContext.Current.Server.MapPath(menu.EOM_FileName));
                return xmlmenu;
            }

            //資料庫定義--載入虛擬 XML (建立RootNode)
            xmlmenu.loadXmlMenu(HttpContext.Current.Server.MapPath("~/data/DummyMenu.xml"));

            //功能表選單
            var viewable = (isAll ? "" : "Y");
            var dtMenuStruct = NsDmHelper.EO_MenuStruct
                .selectAll(t => t.EOMS_ChildCount_XX)
                .where(t => 
                    t.EOMS_RootId_XX == menu.EOM_StructId.toConstReq1()
                    & t.EOMS_Viewable == viewable.toConstOpt1()
                )
                .query();

            int _expandNodeId = 1;

            //匿名遞迴函式
            Action<string, FtdXmlMenuNode> createFullTree = null;
            createFullTree =
                (parentId, disp_node) =>
                {
                    var childrows = dtMenuStruct.Where(x => x.EOMS_ParentId.nullOrEmptyAs("@") == parentId.nullOrEmptyAs("@")).OrderBy(x => x.EOMS_SortNo);
                    foreach (var childrow in childrows)
                    {
                        var cmenuNode = new FtdXmlMenuNode();
                        cmenuNode.Parent = disp_node;
                        disp_node.ChildNodes.Add(cmenuNode);

                        cmenuNode.Attributes.Add("id", _expandNodeId.ToString());
                        cmenuNode.Attributes.Add("itemNo", childrow.EOMS_Code);
                        cmenuNode.Attributes.Add("action", childrow.EOMS_CustAttr1);
                        cmenuNode.Attributes.Add("controller", childrow.EOMS_CustAttr2);
                        cmenuNode.Attributes.Add("area", childrow.EOMS_CustAttr3);
                        cmenuNode.Attributes.Add("parameters", childrow.EOMS_WinParam);
                        cmenuNode.Attributes.Add("title", childrow.EOMS_Name);
                        cmenuNode.Attributes.Add("clickmode", childrow.EOMS_ClickMode);
                        cmenuNode.Attributes.Add("url", childrow.EOMS_Url);
                        cmenuNode.Attributes.Add("urltarget", childrow.EOMS_UrlTarget);
                        cmenuNode.Attributes.Add("viewable", childrow.EOMS_Viewable);
                        _expandNodeId++;

                        //childNode Expand
                        createFullTree(childrow.EOMS_NodeId, cmenuNode);
                    }
                };

            createFullTree(menu.EOM_StructId, xmlmenu.RootNode);
            return xmlmenu;
        }
    }
}
