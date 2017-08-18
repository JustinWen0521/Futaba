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
    /// 權限主檔
    /// </summary>
    [Serializable]
    public partial class EoPermissionProvider : NsTpDmTypedTableProvider<EO_Permission,EO_PermissionDataTable>
    {
    }
}
