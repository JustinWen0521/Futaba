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
    /// &lt;EOLA&gt;登入帳號{LoginAccount}
    /// </summary>
    [Serializable]
    public partial class EoLoginAccountProvider : NsTpDmTypedTableProvider<EO_LoginAccount,EO_LoginAccountDataTable>
    {
    }
}
