using ftd.data;
using ftd.nsql;
using ftd.service;
using ftd.nsql.provider;

namespace ftd.dataaccess
{
    /// <summary>
    /// &lt;WTST&gt;訂單{ScheduleTask}
    /// </summary>
    public partial class ZzOrderProvider
    {
        protected override void onSchemaLoaded()
        {
            addTypedCalcHandler()
                .setColumns(AppDataName.ZZO_OrderAmount_XX)
                .setHandler(dt =>
                {
                    link_ZZO_OrderAmount_XX(dt);
                });
        }

        private void link_ZZO_OrderAmount_XX(ZZ_OrderDataTable dt)
        {
            var pks = dt.getPrimaryKeys();

            var qrydb = new NsDbQuery();
            qrydb.setSelect(s =>
            {
                var t1 = s.from<ZZ_OrderDetail>();

                s.select(
                    t1.ZZOD_OrderId, 
                    (t1.ZZOD_Qty.isnull(0) * t1.ZZOD_UnitPrice.isnull(0)).sum().As("Amt")
                );

                s.Where = t1.ZZOD_OrderId.batchin(pks.toConstReq1());

                s.groupBy(s.Selects[0]);
            });
            var dt2 = qrydb.queryData();

            dt2.Constraints.Add("PK", dt2.Columns[0], true);

            FtdDataHelper.linkTable(dt, dt2, new FtdDataHelper.LinkInfo(AppDataName.ZZO_OrderId, AppDataName.ZZO_OrderAmount_XX, "Amt", 0));
        }
    }
}
