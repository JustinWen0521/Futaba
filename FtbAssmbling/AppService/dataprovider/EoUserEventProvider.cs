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
    /// &lt;EOUE&gt;網站使用者事件主檔{UserEvent}
    /// </summary>
    [Serializable]
    public partial class EoUserEventProvider : NsTpDmTypedTableProvider<EO_UserEvent,EO_UserEventDataTable>
    {
    }
}
