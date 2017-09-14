using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ftd.query.model
{
    /// <summary>
    /// CR_Registration
    /// </summary>
    public class CrRegistrationQryModel : AppQryModel
    {
        public CrRegistrationQryModel()
        {
        }

        public string Q_RegistrationId { get; set; }
        public string Q_ClassId { get; set; }
        public string Q_CourseId { get; set; }
        public string Q_CourseCode { get; set; }
        public string Q_CourseName { get; set; }
        public string Q_CourseDesc { get; set; }
        public string Q_CourseEnable { get; set; }
        public string Q_CourseEnableName { get; set; }
        public DateTime? Q_StartDate { get; set; }
        public DateTime? Q_EndDate { get; set; }
        public string Q_ClassCode { get; set; }
        public DateTime? Q_ClassDate { get; set; }
        public string Q_ClassTime { get; set; }
        public int? Q_LimitQty { get; set; }
        public string Q_Name { get; set; }
        public string Q_CitizenId { get; set; }
        public string Q_Email { get; set; }
        public string Q_FoodKind { get; set; }
        public string Q_FoodKindName { get; set; }
        public string Q_OrganName { get; set; }
        public string Q_Tel { get; set; }

    }
}
