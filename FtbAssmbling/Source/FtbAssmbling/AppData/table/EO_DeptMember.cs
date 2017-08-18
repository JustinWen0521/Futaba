using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using ftd.nsql;
using ftd.service;
using ftd.data.nstable;
namespace ftd.data
{
    /// <summary>
    /// &lt;EODM&gt;部門成員{DeptMember}
    /// </summary>
    public interface EO_DeptMember : INsTable
    {
        /// <summary>
        /// [DIRECT]*PrimaryKey{DeptMemberId}：【PK&lt;EODM&gt;】
        /// </summary> 
        NsColumn EODM_DeptMemberId { get; }
        /// <summary>
        /// [DIRECT]部門代號{DepartmentCode:50}：【AB0913】&lt;br/&gt;
        /// </summary> 
        NsColumn EODM_DeptCode_XX { get; }
        /// <summary>
        /// [DIRECT]*部門Id{DeptId}：【&lt;EOD&gt;】
        /// </summary> 
        NsColumn EODM_DeptId { get; }
        /// <summary>
        /// [DIRECT]*部門名稱{DepartmentName:50}：【資訊中心】&lt;br/&gt;
        /// </summary> 
        NsColumn EODM_DeptName_XX { get; }
        /// <summary>
        /// [DIRECT]*部門類型{DepartmentType:1,DepartmentTypeName_XX}：○{Name}正式部門 ○{Name_U}會員群組&lt;br/&gt;
        /// </summary> 
        NsColumn EODM_DeptType_XX { get; }
        /// <summary>
        /// [DIRECT]*部門類型{DepartmentType:1,DepartmentTypeName_XX}：○{Name}部門 ○{Name_U}群組&lt;br/&gt;
        /// </summary> 
        NsColumn EODM_DeptTypeName_XX { get; }
        /// <summary>
        /// [DIRECT]人員編號{EmployeeCode:20}：【EA001】&lt;br/&gt;
        /// </summary> 
        NsColumn EODM_EmpCode_XX { get; }
        /// <summary>
        /// [DIRECT]*部門{DepartmentId, DepartmentName_XX}：【&lt;EOD&gt;,資訊中心】&lt;br/&gt;
        /// </summary> 
        NsColumn EODM_EmpDeptId_XX { get; }
        /// <summary>
        /// [DIRECT]*部門{DepartmentId, DepartmentName_XX}：【&lt;EOD&gt;,資訊中心】&lt;br/&gt;
        /// </summary> 
        NsColumn EODM_EmpDeptName_XX { get; }
        /// <summary>
        /// [DIRECT]*Email{EmployeeEmail:50}：【shengwen@mail2000.com.tw】&lt;br/&gt;
        /// </summary> 
        NsColumn EODM_EmpEmail_XX { get; }
        /// <summary>
        /// [DIRECT]#完整姓名{EmployeeFullName_XX}：【市政府-林勝文 組長】&lt;br/&gt;
        /// </summary> 
        NsColumn EODM_EmpFullName_XX { get; }
        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        NsColumn EODM_EmpName_XX { get; }
        /// <summary>
        /// [DIRECT]性別{Sex:1,SexName_XX}：○{Name}男 ○{Name_U}女&lt;br/&gt;
        /// </summary> 
        NsColumn EODM_EmpSex_XX { get; }
        /// <summary>
        /// [DIRECT]性別{Sex:1,SexName_XX}：○{Name}男 ○{Name_U}女&lt;br/&gt;
        /// </summary> 
        NsColumn EODM_EmpSexName_XX { get; }
        /// <summary>
        /// [DIRECT]身分証字號{EmployeeSid:20}：【R122322555】&lt;br/&gt;
        /// </summary> 
        NsColumn EODM_EmpSid_XX { get; }
        /// <summary>
        /// [DIRECT]*職稱{EmployeeTitleId, EmployeeTitleName_XX, EmployeeTitleCode_XX}：【&lt;EOET&gt;,主任,B01】&lt;br/&gt;
        /// </summary> 
        NsColumn EODM_EmpTitleId_XX { get; }
        /// <summary>
        /// [DIRECT]*職稱{EmployeeTitleId, EmployeeTitleName_XX, EmployeeTitleCode_XX}：【&lt;EOET&gt;,主任,B01】&lt;br/&gt;
        /// </summary> 
        NsColumn EODM_EmpTitleName_XX { get; }
        /// <summary>
        /// [DIRECT]部門代號{DepartmentCode:50}：【AB0913】&lt;br/&gt;
        /// </summary> 
        NsColumn EODM_M_DepCode_XX { get; }
        /// <summary>
        /// [DIRECT]*部門名稱{DepartmentName:50}：【資訊中心】&lt;br/&gt;
        /// </summary> 
        NsColumn EODM_M_DeptName_XX { get; }
        /// <summary>
        /// [DIRECT]*部門類型{DepartmentType:1,DepartmentTypeName_XX}：○{Name}正式部門 ○{Name_U}會員群組&lt;br/&gt;
        /// </summary> 
        NsColumn EODM_M_DeptType_XX { get; }
        /// <summary>
        /// [DIRECT]*部門類型{DepartmentType:1,DepartmentTypeName_XX}：○{Name}部門 ○{Name_U}群組&lt;br/&gt;
        /// </summary> 
        NsColumn EODM_M_DeptTypeName_XX { get; }
        /// <summary>
        /// [DIRECT]*成員Id{MemberId}：【&lt;EOD|EOE&gt;】
        /// </summary> 
        NsColumn EODM_MemberId { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class EO_DeptMemberNsTable : NsTable, EO_DeptMember
        {
            public NsColumn EODM_DeptMemberId
            {
                  get { return this["EODM_DeptMemberId"]; }
            }
            public NsColumn EODM_DeptCode_XX
            {
                  get { return this["EODM_DeptCode_XX"]; }
            }
            public NsColumn EODM_DeptId
            {
                  get { return this["EODM_DeptId"]; }
            }
            public NsColumn EODM_DeptName_XX
            {
                  get { return this["EODM_DeptName_XX"]; }
            }
            public NsColumn EODM_DeptType_XX
            {
                  get { return this["EODM_DeptType_XX"]; }
            }
            public NsColumn EODM_DeptTypeName_XX
            {
                  get { return this["EODM_DeptTypeName_XX"]; }
            }
            public NsColumn EODM_EmpCode_XX
            {
                  get { return this["EODM_EmpCode_XX"]; }
            }
            public NsColumn EODM_EmpDeptId_XX
            {
                  get { return this["EODM_EmpDeptId_XX"]; }
            }
            public NsColumn EODM_EmpDeptName_XX
            {
                  get { return this["EODM_EmpDeptName_XX"]; }
            }
            public NsColumn EODM_EmpEmail_XX
            {
                  get { return this["EODM_EmpEmail_XX"]; }
            }
            public NsColumn EODM_EmpFullName_XX
            {
                  get { return this["EODM_EmpFullName_XX"]; }
            }
            public NsColumn EODM_EmpName_XX
            {
                  get { return this["EODM_EmpName_XX"]; }
            }
            public NsColumn EODM_EmpSex_XX
            {
                  get { return this["EODM_EmpSex_XX"]; }
            }
            public NsColumn EODM_EmpSexName_XX
            {
                  get { return this["EODM_EmpSexName_XX"]; }
            }
            public NsColumn EODM_EmpSid_XX
            {
                  get { return this["EODM_EmpSid_XX"]; }
            }
            public NsColumn EODM_EmpTitleId_XX
            {
                  get { return this["EODM_EmpTitleId_XX"]; }
            }
            public NsColumn EODM_EmpTitleName_XX
            {
                  get { return this["EODM_EmpTitleName_XX"]; }
            }
            public NsColumn EODM_M_DepCode_XX
            {
                  get { return this["EODM_M_DepCode_XX"]; }
            }
            public NsColumn EODM_M_DeptName_XX
            {
                  get { return this["EODM_M_DeptName_XX"]; }
            }
            public NsColumn EODM_M_DeptType_XX
            {
                  get { return this["EODM_M_DeptType_XX"]; }
            }
            public NsColumn EODM_M_DeptTypeName_XX
            {
                  get { return this["EODM_M_DeptTypeName_XX"]; }
            }
            public NsColumn EODM_MemberId
            {
                  get { return this["EODM_MemberId"]; }
            }
        }
    }
}
