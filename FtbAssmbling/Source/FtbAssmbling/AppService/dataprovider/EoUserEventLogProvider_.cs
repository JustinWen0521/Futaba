using ftd.data;
using ftd.nsql;
namespace ftd.dataaccess
{
    /// <summary>
    /// &lt;EPUEL&gt;網站使用者事件檔紀錄
    /// </summary>
    public partial class EoUserEventLogProvider
    {
        protected override void onSchemaLoaded()
        {  
            //addTypedCalcHandler()
            //    .setColumns(AppDataName.EOUEL_ObjectName_XX)
            //    .setHandler(
            //    dt =>{}
            //);

            base.onSchemaLoaded();
        }

    }
}
