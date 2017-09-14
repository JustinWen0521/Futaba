using ftd.data;
using System.Data;
using ftd.nsql;
namespace ftd.dataaccess
{
    /// <summary>
    /// &lt;EOET&gt;人員職稱{EmployeeTitle}
    /// </summary>
    public partial class EoEmployeeTitleProvider
    {
        protected override void onSchemaLoaded()
        {
            addTypedCalcHandler()
                .setColumns(AppDataName.EOET_InUse_XX, AppDataName.EOET_InUseName_XX)
                .setReferences(AppDataName.EOET_EmployeeTitleId)
                .setHandler(dt => { 
                    link_EOET_InUse_XX(dt); 
                });

            addTypedCalcHandler()
                .setColumns(AppDataName.EOET_UserCount_XX)
                .setHandler(dt => {
                   var keys = dt.getPrimaryKeys();
                   var qry = new NsDbQuery();
                   qry.setSelect(s => {
                       var t1 = s.from<EO_Employee>();
                       s.Where = t1.EOE_EmployeeTitleId.batchin(keys.toConstReq1());                      
                       s.groupBy(t1.EOE_EmployeeTitleId);
                       s.select(t1.EOE_EmployeeTitleId, NSQL.count().As("TCount"));
                   });
                   var dt1 = qry.queryData();
                   dt1.Constraints.Add("pk", dt1.Columns[0], true);
                   foreach (var row in dt)
                   {
                       row.EOET_UserCount_XX = 0;
                       var row1 = dt1.Rows.Find(row.EOET_EmployeeTitleId);
                       if (row1 != null)
                           row.EOET_UserCount_XX = row1.getInt("TCount");
                   }
                });

            base.onSchemaLoaded();
        }

        private void link_EOET_InUse_XX(EO_EmployeeTitleDataTable dt)
        {
            var pks = dt.getPrimaryKeys();

            var qrydb = new NsDbQuery();
            qrydb.setSelect ( s => {
                var t1 = s.from<EO_Employee>();
                s.select(t1.EOE_EmployeeTitleId);
                s.Where = t1.EOE_EmployeeTitleId.batchin(pks.toConstReq1());
                s.groupBy(s.Selects[0]);                
            });
            var dt2 = qrydb.queryData();          
            dt2.Constraints.Add("PK", dt2.Columns[0], true);           

            foreach (var row in dt)
            {
                var isUse = (dt2.Rows.Find(row.EOET_EmployeeTitleId) != null);
                row.EOET_InUse_XX = isUse ? "T" : "F";
                row.EOET_InUseName_XX = isUse ? "使用中" : "未使用";
            }            
        }
    }
}
