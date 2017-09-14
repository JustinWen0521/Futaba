using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ftd.query.model
{
    /// <summary>
    /// EO_DeptMember
    /// </summary>
    public class EoDeptMemberQryModel : AppQryModel
    {
        public EoDeptMemberQryModel()
        {
        }

        public string Q_DeptMemberId { get; set; }
        public string Q_DeptId { get; set; }
        public string Q_DeptName_XX { get; set; }
        public string Q_DeptType_XX { get; set; }
        public string Q_DeptTypeName_XX { get; set; }
        public string Q_MemberId { get; set; }
        public string Q_EmpName_XX { get; set; }
        public string Q_EmpFullName_XX { get; set; }
        public string Q_EmpTitleId_XX { get; set; }
        public string Q_EmpTitleName_XX { get; set; }
        public string Q_EmpDeptId_XX { get; set; }
        public string Q_EmpDeptName_XX { get; set; }
        public string Q_EmpEmail_XX { get; set; }
        public string Q_EmpSex_XX { get; set; }
        public string Q_EmpSexName_XX { get; set; }
        public string Q_EmpSid_XX { get; set; }
        public string Q_M_DeptName_XX { get; set; }
        public string Q_M_DepCode_XX { get; set; }
        public string Q_M_DeptType_XX { get; set; }
        public string Q_M_DeptTypeName_XX { get; set; }

    }
}
