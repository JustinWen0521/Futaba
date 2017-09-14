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
    /// &lt;AST&gt;測試 {TMP1}
    /// </summary>
    public partial class AsTmp1Provider : NsTpDmTypedTableProvider<AS_Tmp1,AS_Tmp1DataTable>
    {
        protected override void onSchemaLoaded()
        {
            addDataMap(AppDataName.AS_Tmp1, "TMP1");
            addDataMap(AppDataName.AST_TITM, "TITM");
            addDataMap(AppDataName.AST_TQTY, "TQTY");

        }
    }
}
