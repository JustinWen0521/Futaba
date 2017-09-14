using ftd.data;
using ftd.nsql;
namespace ftd.dataaccess
{
    /// <summary>
    /// &lt;WTSD&gt;排程日期{ScheduleDate}
    /// </summary>
    public partial class WtScheduleDateProvider
    {
        protected override void onSchemaLoaded()
        {
            //addTypedSqlHandler()
            //    .setColumns(AppDataName.WTSD_IsEnableName_XX)
            //    .setHandler(
            //        t => t.WTSD_IsEnable.decode("A", "啟用","B", "停止", t.WTSD_IsEnable)
            //    );

            base.onSchemaLoaded();
        }
    }
}
