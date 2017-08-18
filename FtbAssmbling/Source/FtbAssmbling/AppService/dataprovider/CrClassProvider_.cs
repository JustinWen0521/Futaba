using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using ftd.data;
using ftd.nsql;
using ftd.nsql.provider;
namespace ftd.dataaccess
{
    /// <summary>
    /// &lt;CRCL&gt;班別{Class}
    /// </summary>
    public partial class CrClassProvider : NsTpDmTypedTableProvider<CR_Class,CR_ClassDataTable>
    {
        protected override void onSchemaLoaded()
        {
            //已報名人數
            addTypedCalcHandler()
                .setColumns(AppDataName.CRCL_RegisterQty_XX)
                .setHandler(dt =>
                {
                    link_CRCL_RegisterQty_XX(dt);
                });
        }

        private void link_CRCL_RegisterQty_XX(CR_ClassDataTable dt)
        {
            var pks = dt.getPrimaryKeys();

            var qrydb = new NsDbQuery();
            qrydb.setSelect(s =>
            {
                var t1 = s.from<CR_Registration>();
                s.select(t1.CRR_ClassId, NSQL.count().As("UserCount"));
                s.Where = t1.CRR_ClassId.batchin(pks.toConstReq1());
                s.groupBy(s.Selects[0]);
            });

            var dt2 = qrydb.queryData();
            dt2.Constraints.Add("PK", dt2.Columns[0], true);

            FtdDataHelper.linkTable(dt, dt2, new FtdDataHelper.LinkInfo(AppDataName.CRCL_ClassId, AppDataName.CRCL_RegisterQty_XX, "UserCount", 0));
        }
    }
}
