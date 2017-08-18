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
    /// {T}&lt;EOMPS&gt;功能表/授權功能{MenuPermSet}
    /// </summary>
    [Serializable]
    public partial class EoMenuPermSetProvider : NsTpDmTypedTableProvider<EO_MenuPermSet,EO_MenuPermSetDataTable>
    {
    }
}
