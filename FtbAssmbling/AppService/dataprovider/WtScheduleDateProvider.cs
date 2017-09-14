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
    /// &lt;WTSD&gt;排程日期{ScheduleDate}
    /// </summary>
    [Serializable]
    public partial class WtScheduleDateProvider : NsTpDmTypedTableProvider<WT_ScheduleDate,WT_ScheduleDateDataTable>
    {
    }
}
