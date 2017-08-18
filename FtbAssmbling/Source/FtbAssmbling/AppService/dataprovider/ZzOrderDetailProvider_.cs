using ftd.data;
using ftd.nsql;
using ftd.service;
using ftd.nsql.provider;
namespace ftd.dataaccess
{
    /// <summary>
    /// &lt;ZZOD&gt;訂單明細{ZZ_OrderDetail}
    /// </summary>
    public partial class ZzOrderDetailProvider 
    {
        protected override void onSchemaLoaded()
        {
            addTypedSqlHandler()
                .setColumns(AppDataName.ZZOD_Amount_XX)
                .setHandler(
                    t1 => t1.ZZOD_Qty.isnull(0) * t1.ZZOD_UnitPrice.isnull(0)
                );
        }
    }
}
