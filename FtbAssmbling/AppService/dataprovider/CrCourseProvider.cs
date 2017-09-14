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
    /// &lt;CRC&gt;課程{Course}
    /// </summary>
    [Serializable]
    public partial class CrCourseProvider : NsTpDmTypedTableProvider<CR_Course,CR_CourseDataTable>
    {
    }
}
