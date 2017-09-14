using System.Web;
using ftd.data;
using ftd.nsql;
namespace ftd.dataaccess
{
    /// <summary>
    /// &lt;EOM&gt; 功能表定義{Menu}
    /// </summary>
    public partial class EoMenuProvider
    {
        protected override void onSchemaLoaded()
        {
            addTypedCalcHandler()
                .setColumns(AppDataName.EOM_FileFullName_XX)
                .setReferences(AppDataName.EOM_StructSource, AppDataName.EOM_FileName)
                .setHandler( dt => {
                    foreach (var row in dt)
                    {
                        if (row.EOM_StructSource == "F")
                            row.EOM_FileFullName_XX = HttpContext.Current.Server.MapPath(row.EOM_FileName);
                        else
                            row.EOM_FileFullName_XX = "";
                    }
                });

            base.onSchemaLoaded();
        }
    }
}
