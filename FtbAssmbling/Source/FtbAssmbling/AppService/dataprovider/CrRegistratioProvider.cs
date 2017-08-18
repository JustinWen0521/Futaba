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
    /// &lt;CRR&gt;報名{Registratio}
    /// </summary>
    [Serializable]
    public partial class CrRegistratioProvider : NsTpDmTypedTableProvider<CR_Registration,CR_RegistrationDataTable>
    {
    }
}
