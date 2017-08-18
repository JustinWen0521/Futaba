using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ftd.query.model
{
    /// <summary>
    /// EO_EmployeeTitle
    /// </summary>
    public class EoEmployeeTitleQryModel : AppQryModel
    {
        public EoEmployeeTitleQryModel()
        {
        }

        public string Q_EmployeeTitleId { get; set; }
        public string Q_InUse_XX { get; set; }
        public string Q_InUseName_XX { get; set; }
        public int? Q_ListOrder { get; set; }
        public string Q_TitleCode { get; set; }
        public string Q_TitleName { get; set; }
        public int? Q_UserCount_XX { get; set; }

    }
}
