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
    /// &lt;EODM&gt;部門成員{DeptMember}
    /// </summary>
    [Serializable]
    public partial class EoDeptMemberProvider : NsTpDmTypedTableProvider<EO_DeptMember,EO_DeptMemberDataTable>
    {
    }
}
