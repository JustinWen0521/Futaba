using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ftd.query.model
{
    /// <summary>
    /// EO_Department
    /// </summary>
    public class EoDepartmentQryModel : AppQryModel
    {
        public EoDepartmentQryModel()
        {
        }

        public string Q_DepartmentId { get; set; }
        public string Q_DepartmentCode { get; set; }
        public string Q_DepartmentName { get; set; }
        public string Q_DepartmentFullName_XX { get; set; }
        public string Q_DepartmentFullNameII_XX { get; set; }
        public string Q_DepartmentType { get; set; }
        public string Q_DepartmentTypeName_XX { get; set; }
        public string Q_ParentId { get; set; }
        public string Q_ParentCode_XX { get; set; }
        public string Q_ParentName_XX { get; set; }
        public string Q_ParentFullName_XX { get; set; }
    }
}
