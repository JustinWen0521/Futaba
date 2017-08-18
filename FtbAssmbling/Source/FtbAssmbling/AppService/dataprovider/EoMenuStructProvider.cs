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
    /// {T}&lt;EOMS&gt;功能表/功能結構 {MenuStruct}
    /// </summary>
    [Serializable]
    public partial class EoMenuStructProvider : NsTpDmTypedTableProvider<EO_MenuStruct,EO_MenuStructDataTable>
    {
    }
}
