using System;
using System.Collections;
using System.Data;
using System.Linq;
using ftd.data;
using ftd.nsql;
using ftd.service;
using ftd.nsql.provider;
namespace ftd.dataaccess
{
    /// <summary>
    /// &lt;EOD&gt;部門{Department}
    /// </summary>
    public partial class EoDepartmentProvider
    {
        protected override void onSchemaLoaded()
        {
            addTypedCalcHandler()
                .setColumns(AppDataName.EOD_ChildCount_XX, AppDataName.EOD_BrotherCount_XX)
                .setReferences(AppDataName.EOD_DepartmentId, AppDataName.EOD_ParentId)
                .setHandler(dt =>
                {
                    var pks = dt.Select(x => x.EOD_DepartmentId).Union(dt.Select(x => x.EOD_ParentId)).Distinct().ToArray();
                    var qry = new NsDbQuery();
                    qry.setSelect(s =>
                    {
                        var t1 = s.from<EO_Department>();
                        s.Where = t1.EOD_ParentId.batchin(pks.toConstReq1());
                        s.select(t1.EOD_ParentId.isnull("@").As("ID"), NSQL.count().As("TheCount"));
                        s.groupBy(t1.EOD_ParentId);
                    });
                    var dt1 = qry.queryData();
                    var keys = dt1.Rows.Cast<DataRow>().Select(x => new {ID = x.getString("ID"), TheCount = x.getInt("TheCount").Value }).ToDictionary(x=> x.ID);                    

                    foreach (var row in dt)
                    {
                        //ChildCount
                        {
                            var row1 = keys.findKey(row.EOD_DepartmentId);
                            if (row1 != null)
                                row.EOD_ChildCount_XX = row1.TheCount;
                            else
                                row.EOD_ChildCount_XX = 0;
                        }
                        //BrotherCount
                        {
                            
                            var row1 = keys.findKey(row.EOD_ParentId.nullOrEmptyAs("@"));
                            if (row1 != null)
                                row.EOD_BrotherCount_XX = row1.TheCount;
                            else
                                row.EOD_BrotherCount_XX = 0;
                        }
                    }
                });            

            addTypedSqlHandler()
                .setColumns(AppDataName.EOD_DepartmentTypeName_XX)
                .setHandler(
                    t1 => t1.EOD_DepartmentType.decode("A", "部門", "B", "群組", t1.EOD_DepartmentType)
                );                   

            addTypedCalcHandler()
                .setColumns(AppDataName.EOD_EmployeeCount_XX)
                .setHandler( dt => {
                    link_EOD_EmployeeCount_XX(dt);
                });

            addTypedSqlHandler()
                .setColumns(AppDataName.EOD_DepartmentObjectName_XX)
                .setHandler(
                    t1 => (t1.PrimaryKey == null).istrue("", "[" + t1.EOD_DepartmentTypeName_XX + "]" + t1.EOD_DepartmentName)
                );           

            addTypedCalcHandler()
                .setColumns(AppDataName.EOD_CU_IsVirtualVisible_XX)
                .setReferences(AppDataName.EOD_DepartmentType, AppDataName.EOD_VirtualType)
                .setHandler(dt => {
                    link_EOD_CU_IsVirtualVisible_XX(dt);
                });

            addTypedCalcHandler()
                .setColumns(AppDataName.EOD_DepartmentFullName_XX)
                .setReferences(AppDataName.EOD_ParentId, AppDataName.EOD_DepartmentName)
                .setHandler( dt => {
                    link_EOD_DepartmentFullName_XX(dt);
                });

            addTypedCalcHandler()
                .setColumns(AppDataName.EOD_DepartmentFullNameII_XX)
                .setReferences(AppDataName.EOD_DepartmentName, AppDataName.EOD_DepartmentFullName_XX)
                .setHandler(dt => {
                    foreach (var row in dt)
                    {
                        row.EOD_DepartmentFullNameII_XX = row.EOD_DepartmentCode.isNullOrEmpty() ? row.EOD_DepartmentFullName_XX : row.EOD_DepartmentCode + "-" + row.EOD_DepartmentFullName_XX;
                    }
                });

            addTypedCalcHandler()
                .setColumns(AppDataName.EOD_IsDeleteable_XX)
                .setReferences(AppDataName.EOD_DepartmentType, AppDataName.EOD_ChildCount_XX, AppDataName.EOD_EmployeeCount_XX)
                .setHandler( dt => {
                    foreach (var row in dt)
                    {
                        if (row.EOD_DepartmentType == "A")
                            row.EOD_IsDeleteable_XX = (row.EOD_ChildCount_XX == 0 && row.EOD_EmployeeCount_XX == 0) ? "T" : "F";
                        if (row.EOD_DepartmentType == "B")
                            row.EOD_IsDeleteable_XX = (row.EOD_ChildCount_XX == 0) ? "T" : "F";
                    }                
                });

            addTypedCalcHandler()
                .setColumns(AppDataName.EOD_ScopeLevelNo_XX, AppDataName.EOD_ScopeTreeLeftNo_XX, AppDataName.EOD_ScopeTreeRightNo_XX)
                .setReferences(AppDataName.EOD_ParentId)
                .setHandler( dt => {
                    //向上展開樹
                    var dta = FtdDataHelper.TableTree.getTreeUpExpand(
                        dt,
                        dt1 =>
                        {
                            //Find All Parent
                            var pks = dt1.Select(x => x.EOD_ParentId).Distinct().ToArray();
                            var dt2 = NsDmHelper.EO_Department.wherepks(pks).query();
                            return dt2;
                        }
                        , (dt1, dt2) =>
                        {
                            var rows = dt1.Where(x => dt2.findByPrimaryKey(x.EOD_DepartmentId) != null).ToArray();
                            rows.forEach(x => dt1.Rows.Remove(x));
                        }
                    );                   

                    //樹系代號計算
                    FtdDataHelper.TableTree.calcTreeNo(dta, "X_TreeNo1", "X_TreeNo2", "X_Level"
                        , dt1 => dt1.Where(x => x.EOD_ParentId.isNullOrEmpty()).OrderBy(x => x.EOD_SortNo)
                        , (dt1, row1) => 
                        { 
                            var pk = ((EO_DepartmentRow)row1).EOD_DepartmentId; 
                            return dt1.Where(x => x.EOD_ParentId == pk).OrderBy(x=>x.EOD_SortNo); 
                        }
                    );

                    foreach (var row in dt)
                    {
                        var rowa = dta.findByPrimaryKey(row.EOD_DepartmentId);
                        if (rowa == null)
                        {
                            row.EOD_ScopeLevelNo_XX = null;
                            row.EOD_ScopeTreeLeftNo_XX = null;
                            row.EOD_ScopeTreeRightNo_XX = null;
                        }
                        else
                        {
                            row.EOD_ScopeLevelNo_XX = rowa.getInt("X_Level").Value;
                            row.EOD_ScopeTreeLeftNo_XX = rowa.getInt("X_TreeNo1").Value;
                            row.EOD_ScopeTreeRightNo_XX = rowa.getInt("X_TreeNo2").Value;
                        }
                    }
                });

            base.onSchemaLoaded();
        }       

        private void link_EOD_DepartmentFullName_XX(EO_DepartmentDataTable dt)
        {
              
            var qry = new NsDbQuery();
            var col = dt.Columns.Add("LevelId_XX", typeof(string));

            //初始資料
            foreach (var row in dt)
            {
                row[col] = row.EOD_ParentId;
                row.EOD_DepartmentFullName_XX = row.EOD_DepartmentName;
            }

            //逐階計算
            while (true)
            {
                var levelpks = FtdDataHelper.getDistinctArray<string>(dt, col);
                qry.setSelect(s => {
                    var t1 = s.from<EO_Department>();
                    s.select(t1.EOD_DepartmentId, t1.EOD_DepartmentName, t1.EOD_ParentId);
                    s.Where = t1.EOD_DepartmentId.batchin(levelpks.toConstReq1());
                });
                var dt2 = qry.queryData<EO_DepartmentDataTable>();
                if (dt2.Count == 0)
                    break;
                FtdDataHelper.linkTable(
                    dt.Rows
                    , dt2
                    , col
                    , (row, row2, isLink) =>
                    {
                        if (isLink)
                        {
                            row[AppDataName.EOD_DepartmentFullName_XX] = string.Concat(row2[AppDataName.EOD_DepartmentName] , @"\", row[AppDataName.EOD_DepartmentFullName_XX]);
                            row[col] = row2[AppDataName.EOD_ParentId];
                        }
                        else
                            row[col] = "";
                    }
                );
                dt2.Clear();
            }

            dt.Columns.Remove(col);
        }

        /// <summary>
        /// #目前登入者是可否看見此群組部門{CU_IsVirtualVisible}：○{T}是 ○{F}不是※群組需為公開或是非公開，但是為其成員者。
        /// </summary>        
        private void link_EOD_CU_IsVirtualVisible_XX(EO_DepartmentDataTable dt)
        {

            var empId = NsQueryContext.getCurrentUserId();
            //NsQueryContext.getCurrentUserId()();
                //SdmService.Instance.ServiceContext[AppDdParameterName.DDPN_EOE_EmployeeId];

            //找出人員的所有部門           
            var dt1 = NsDmHelper.EO_DeptMember.where(t1 => t1.EODM_MemberId == empId.toConstReq1()).query();
            dt1.Constraints.Add("pk", dt1.EODM_DeptIdColumn, true);            

            foreach (var row in dt)
            {
                if (row.EOD_DepartmentType == "B")
                {
                    if (row.EOD_VirtualType == "A")
                    {
                        row.EOD_CU_IsVirtualVisible_XX = "T";
                    }
                    else
                    {
                        if (dt1.Rows.Find(row.EOD_DepartmentId) == null)
                            row.EOD_CU_IsVirtualVisible_XX = "F";
                        else
                            row.EOD_CU_IsVirtualVisible_XX = "T";
                    }
                }
            }
        }

        private void link_EOD_EmployeeCount_XX(EO_DepartmentDataTable dt)
        {
            var pks = dt.getPrimaryKeys();        

            var qrydb = new NsDbQuery();
            qrydb.setSelect( s => {
                var t1 = s.from<EO_DeptMember>();
                s.select(t1.EODM_DeptId, NSQL.count().As("EmpCount"));
                s.Where = t1.EODM_DeptId.batchin(pks.toConstReq1());
                s.groupBy(s.Selects[0]);
            });

            var dt2 = qrydb.queryData();
            dt2.Constraints.Add("PK", dt2.Columns[0], true);            

            FtdDataHelper.linkTable(dt, dt2, new FtdDataHelper.LinkInfo(AppDataName.EOD_DepartmentId, AppDataName.EOD_EmployeeCount_XX, "EmpCount", 0));
        }       
    }
}
