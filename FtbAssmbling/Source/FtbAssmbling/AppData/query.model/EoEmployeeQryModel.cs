using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ftd.query.model
{
    /// <summary>
    /// EO_Employee
    /// </summary>
    public class EoEmployeeQryModel : AppQryModel
    {
        public EoEmployeeQryModel()
        {
        }

        public string Q_EmployeeId { get; set; }
        public string Q_EmployeeCode { get; set; }
        public string Q_EmployeeName { get; set; }
        public string Q_EmployeeFullName_XX { get; set; }
        public string Q_DepartmentId { get; set; }
        public string Q_DepartmentCode_XX { get; set; }
        public string Q_DepartmentName_XX { get; set; }
        public string Q_DepartmentFullName_XX { get; set; }
        public string Q_EmployeeTitleId { get; set; }
        public string Q_EmployeeTitleCode_XX { get; set; }
        public string Q_EmployeeTitleName_XX { get; set; }
        public string Q_Sex { get; set; }
        public string Q_SexName_XX { get; set; }
        public string Q_Phone1 { get; set; }
        public string Q_Phone2 { get; set; }
        public string Q_SmsNumber { get; set; }
        public string Q_EmployeeEmail { get; set; }
        public string Q_EmployeeSid { get; set; }
        public string Q_IsLeave_XX { get; set; }
        public string Q_IsOrganManager { get; set; }
        public string Q_LoginAccount_XX { get; set; }
        public DateTime? Q_EntryDateFrom { get; set; }
        public DateTime? Q_EntryDateTo { get; set; }
        public DateTime? Q_LeaveDateFrom { get; set; }
        public DateTime? Q_LeaveDateTo { get; set; }
        public string Q_IsManager { get; set; }
        public string Q_IsDeptMgr { get; set; }
        public string Q_Enabled { get; set; }
    }
}
