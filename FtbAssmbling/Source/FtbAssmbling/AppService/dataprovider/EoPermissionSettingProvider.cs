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
    /// &lt;EOPS&gt;權限設定表{PermissonSetting}
    /// </summary>
    [Serializable]
    public partial class EoPermissionSettingProvider : NsTpDmTypedTableProvider<EO_PermissionSetting,EO_PermissionSettingDataTable>
    {
    }
}
