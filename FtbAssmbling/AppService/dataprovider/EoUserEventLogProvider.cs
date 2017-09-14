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
    /// 
    /// </summary>
    [Serializable]
    public partial class EoUserEventLogProvider : NsTpDmTypedTableProvider<EO_UserEventLog,EO_UserEventLogDataTable>
    {
    }
}
