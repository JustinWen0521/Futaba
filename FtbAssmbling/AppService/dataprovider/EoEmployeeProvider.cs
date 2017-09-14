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
    /// &lt;EOE&gt;人員{Employee}
    /// </summary>
    [Serializable]
    public partial class EoEmployeeProvider : NsTpDmTypedTableProvider<EO_Employee,EO_EmployeeDataTable>
    {
    }
}
