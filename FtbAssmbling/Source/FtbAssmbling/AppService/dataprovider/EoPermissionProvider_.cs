using ftd.data;
using ftd.nsql;
namespace ftd.dataaccess
{
    /// <summary>
    /// 
    /// </summary>
    public partial class EoPermissionProvider
    {
        protected override void onSchemaLoaded()
        {
            addTypedSqlHandler()
                .setColumns(AppDataName.EOP_IsEveryOneAllowName_XX)
                .setHandler(
                    t => t.EOP_IsEveryOneAllow.decode("Y", "是", "N", "否")
                );

            addTypedSqlHandler()
                .setColumns(AppDataName.EOP_IsObjectNeedName_XX)
                .setHandler(
                    t => t.EOP_IsObjectNeed.decode("Y", "是", "N", "否")
                ); 
            base.onSchemaLoaded();
        }       

    }
}
