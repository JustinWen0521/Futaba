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
    /// &lt;CRC&gt;課程{Course}
    /// </summary>
    public partial class CrCourseProvider : NsTpDmTypedTableProvider<CR_Course,CR_CourseDataTable>
    {
        protected override void onSchemaLoaded()
        {
            //已報名人數
            addTypedCalcHandler()
                .setColumns(AppDataName.CRC_RegisterQty_XX)
                .setHandler(dt =>
                {
                    link_CRCL_RegisterQty_XX(dt);
                });
        }

        private void link_CRCL_RegisterQty_XX(CR_CourseDataTable dt)
        {
            var pks = dt.getPrimaryKeys();

            var qrydb = new NsDbQuery();
            qrydb.setSelect(s =>
            {
                var t1 = s.from<CR_Registration>();
                var t2 = s.join<CR_Class>().on(t => t.CRCL_ClassId == t1.CRR_ClassId);
                var t3 = s.join<CR_Course>().on(t => t.CRC_CourseId == t2.CRCL_CourseId);

                s.select(t3.CRC_CourseId, NSQL.count().As("UserCount"));
                s.Where = t3.CRC_CourseId.batchin(pks.toConstReq1());
                s.groupBy(s.Selects[0]);
            });

            var dt2 = qrydb.queryData();
            dt2.Constraints.Add("PK", dt2.Columns[0], true);

            FtdDataHelper.linkTable(dt, dt2, new FtdDataHelper.LinkInfo(AppDataName.CRC_CourseId, AppDataName.CRC_RegisterQty_XX, "UserCount", 0));
        }
    }
}
