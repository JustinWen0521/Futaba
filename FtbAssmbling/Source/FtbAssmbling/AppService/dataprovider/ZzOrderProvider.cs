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
    /// &lt;WTST&gt;訂單{ScheduleTask}
    /// </summary>
    [Serializable]
    public partial class ZzOrderProvider : NsTpDmTypedTableProvider<ZZ_Order,ZZ_OrderDataTable>
    {
    }
}
