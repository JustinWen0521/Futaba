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
    /// {T}&lt;EOMP&gt;功能表/授權對象{MenuPerm}
    /// </summary>
    [Serializable]
    public partial class EoMenuPermProvider : NsTpDmTypedTableProvider<EO_MenuPerm,EO_MenuPermDataTable>
    {
    }
}
