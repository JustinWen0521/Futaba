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
    /// &lt;EOET&gt;人員職稱{EmployeeTitle}
    /// </summary>
    [Serializable]
    public partial class EoEmployeeTitleProvider : NsTpDmTypedTableProvider<EO_EmployeeTitle,EO_EmployeeTitleDataTable>
    {
    }
}
