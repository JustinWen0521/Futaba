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
    /// {T}組立機臺主檔 {AL_Assmbling}
    /// </summary>
    [Serializable]
    public partial class AlAssmblingProvider : NsTpDmTypedTableProvider<AL_Assmbling,AL_AssmblingDataTable>
    {
    }
}
