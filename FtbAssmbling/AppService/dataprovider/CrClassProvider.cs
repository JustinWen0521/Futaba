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
    /// &lt;CRCL&gt;班別{Class}
    /// </summary>
    [Serializable]
    public partial class CrClassProvider : NsTpDmTypedTableProvider<CR_Class,CR_ClassDataTable>
    {
    }
}
