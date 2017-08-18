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
    /// {T}&lt;EOFPS&gt;程式功能授權{FunPermSet}
    /// </summary>
    [Serializable]
    public partial class EoFunPermSetProvider : NsTpDmTypedTableProvider<EO_FunPermSet,EO_FunPermSetDataTable>
    {
    }
}
