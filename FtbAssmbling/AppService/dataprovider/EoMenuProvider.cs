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
    /// &lt;EOM&gt; 功能表定義{Menu}
    /// </summary>
    [Serializable]
    public partial class EoMenuProvider : NsTpDmTypedTableProvider<EO_Menu,EO_MenuDataTable>
    {
    }
}
