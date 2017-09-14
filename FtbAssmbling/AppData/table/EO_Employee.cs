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
    /// &lt;EOE&gt;人員{Employee}
    /// </summary>
    public interface EO_Employee : INsTable
    {
        /// <summary>
        /// [DIRECT]*人員ID{EmployeeId}：【PK&lt;EOE&gt;】
        /// </summary> 
        NsColumn EOE_EmployeeId { get; }
        /// <summary>
        /// [DIRECT]*通訊住址{CAddress:50} 【高雄市 海邊路119巷37號】
        /// </summary> 
        NsColumn EOE_CAddress { get; }
        /// <summary>
        /// [DIRECT]#人員是否為目前登入者{CU_IsLoginUser_XX}：○{T}是 ○{F}不是
        /// </summary> 
        NsColumn EOE_CU_IsLoginUser_XX { get; }
        /// <summary>
        /// [DIRECT]*郵遞區號{CZip:10} 【71804】
        /// </summary> 
        NsColumn EOE_CZip { get; }
        /// <summary>
        /// [DIRECT]部門代號{DepartmentCode:50}：【AB0913】&lt;br/&gt;
        /// </summary> 
        NsColumn EOE_DepartmentCode_XX { get; }
        /// <summary>
        /// #完整部門名稱{DepartmentFullName_XX}：【市政府\資訊中心】&lt;br/&gt;
        /// </summary> 
        NsColumn EOE_DepartmentFullName_XX { get; }
        /// <summary>
        /// [DIRECT]*部門{DepartmentId, DepartmentName_XX}：【&lt;EOD&gt;,資訊中心】
        /// </summary> 
        NsColumn EOE_DepartmentId { get; }
        /// <summary>
        /// [DIRECT]*部門名稱{DepartmentName:50}：【資訊中心】&lt;br/&gt;
        /// </summary> 
        NsColumn EOE_DepartmentName_XX { get; }
        /// <summary>
        /// [DIRECT]人員編號{EmployeeCode:20}：【EA001】
        /// </summary> 
        NsColumn EOE_EmployeeCode { get; }
        /// <summary>
        /// [DIRECT]*Email{EmployeeEmail:50}：【shengwen@mail2000.com.tw】
        /// </summary> 
        NsColumn EOE_EmployeeEmail { get; }
        /// <summary>
        /// [DIRECT]#完整姓名{EmployeeFullName_XX}：【市政府-林勝文 組長】
        /// </summary> 
        NsColumn EOE_EmployeeFullName_XX { get; }
        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】
        /// </summary> 
        NsColumn EOE_EmployeeName { get; }
        /// <summary>
        /// [DIRECT]#搜尋用名稱 {EmployeeSearchName_XX}：【林勝文 組長 (shengwen@mail2000.com.tw)】
        /// </summary> 
        NsColumn EOE_EmployeeSearchName_XX { get; }
        /// <summary>
        /// [DIRECT]身分証字號{EmployeeSid:20}：【R122322555】
        /// </summary> 
        NsColumn EOE_EmployeeSid { get; }
        /// <summary>
        /// [DIRECT]#標準姓名{EmployeeStandardName_XX}：【林勝文 組長】
        /// </summary> 
        NsColumn EOE_EmployeeStandardName_XX { get; }
        /// <summary>
        /// [DIRECT]職稱代號 {TitleCode:20}：【A312】&lt;br/&gt;
        /// </summary> 
        NsColumn EOE_EmployeeTitleCode_XX { get; }
        /// <summary>
        /// [DIRECT]*職稱{EmployeeTitleId, EmployeeTitleName_XX, EmployeeTitleCode_XX}：【&lt;EOET&gt;,主任,B01】
        /// </summary> 
        NsColumn EOE_EmployeeTitleId { get; }
        /// <summary>
        /// [DIRECT]*職稱名稱{TitleName:20}：【組長】&lt;br/&gt;
        /// </summary> 
        NsColumn EOE_EmployeeTitleName_XX { get; }
        /// <summary>
        /// [DIRECT]是否啟用【T：是 / F：否】
        /// </summary> 
        NsColumn EOE_Enabled { get; }
        /// <summary>
        /// [DIRECT]*任職日期{EntryDate:D}：【2006/09/19】
        /// </summary> 
        NsColumn EOE_EntryDate { get; }
        /// <summary>
        /// [DIRECT]#是否離職{IsLeave_XX}：○{T}是 ○{F}不是
        /// </summary> 
        NsColumn EOE_IsLeave_XX { get; }
        /// <summary>
        /// [DIRECT]離職日期{LeaveDate:D}：【2006/10/19】(※填此日期代表已離職，否則為在職)
        /// </summary> 
        NsColumn EOE_LeaveDate { get; }
        /// <summary>
        /// [DIRECT]*登入帳號{LoginAccount:50}：【Administrator】&lt;br/&gt;
        /// </summary> 
        NsColumn EOE_LoginAccount_XX { get; }
        /// <summary>
        /// [DIRECT]*登入密碼{LoginPassword:20}：【XYXCDE】&lt;br/&gt;
        /// </summary> 
        NsColumn EOE_LoginPassword_XX { get; }
        /// <summary>
        /// [DIRECT]個人圖片{PersonalImage:50}：【XXXXXX00-00011.GIF】
        /// </summary> 
        NsColumn EOE_PersonalImage { get; }
        /// <summary>
        /// [DIRECT]聯絡電話1{Phone1:20}：【06-5951579】
        /// </summary> 
        NsColumn EOE_Phone1 { get; }
        /// <summary>
        /// [DIRECT]聯絡電話2{Phone2:20}：【0913670599】
        /// </summary> 
        NsColumn EOE_Phone2 { get; }
        /// <summary>
        /// [DIRECT]備註{Remark:100}：【此員工表現良好】
        /// </summary> 
        NsColumn EOE_Remark { get; }
        /// <summary>
        /// [DIRECT]性別{Sex:1,SexName_XX}：○{Name}男 ○{Name_U}女
        /// </summary> 
        NsColumn EOE_Sex { get; }
        /// <summary>
        /// [DIRECT]性別{Sex:1,SexName_XX}：○{Name}男 ○{Name_U}女
        /// </summary> 
        NsColumn EOE_SexName_XX { get; }
        /// <summary>
        /// [DIRECT]簽名檔：{Signature:100}：【我很笨但我很溫柔】
        /// </summary> 
        NsColumn EOE_Signature { get; }
        /// <summary>
        /// [DIRECT]*簡訊通知號碼{SmsNumber:20}：【0913670599】
        /// </summary> 
        NsColumn EOE_SmsNumber { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class EO_EmployeeNsTable : NsTable, EO_Employee
        {
            public NsColumn EOE_EmployeeId
            {
                  get { return this["EOE_EmployeeId"]; }
            }
            public NsColumn EOE_CAddress
            {
                  get { return this["EOE_CAddress"]; }
            }
            public NsColumn EOE_CU_IsLoginUser_XX
            {
                  get { return this["EOE_CU_IsLoginUser_XX"]; }
            }
            public NsColumn EOE_CZip
            {
                  get { return this["EOE_CZip"]; }
            }
            public NsColumn EOE_DepartmentCode_XX
            {
                  get { return this["EOE_DepartmentCode_XX"]; }
            }
            public NsColumn EOE_DepartmentFullName_XX
            {
                  get { return this["EOE_DepartmentFullName_XX"]; }
            }
            public NsColumn EOE_DepartmentId
            {
                  get { return this["EOE_DepartmentId"]; }
            }
            public NsColumn EOE_DepartmentName_XX
            {
                  get { return this["EOE_DepartmentName_XX"]; }
            }
            public NsColumn EOE_EmployeeCode
            {
                  get { return this["EOE_EmployeeCode"]; }
            }
            public NsColumn EOE_EmployeeEmail
            {
                  get { return this["EOE_EmployeeEmail"]; }
            }
            public NsColumn EOE_EmployeeFullName_XX
            {
                  get { return this["EOE_EmployeeFullName_XX"]; }
            }
            public NsColumn EOE_EmployeeName
            {
                  get { return this["EOE_EmployeeName"]; }
            }
            public NsColumn EOE_EmployeeSearchName_XX
            {
                  get { return this["EOE_EmployeeSearchName_XX"]; }
            }
            public NsColumn EOE_EmployeeSid
            {
                  get { return this["EOE_EmployeeSid"]; }
            }
            public NsColumn EOE_EmployeeStandardName_XX
            {
                  get { return this["EOE_EmployeeStandardName_XX"]; }
            }
            public NsColumn EOE_EmployeeTitleCode_XX
            {
                  get { return this["EOE_EmployeeTitleCode_XX"]; }
            }
            public NsColumn EOE_EmployeeTitleId
            {
                  get { return this["EOE_EmployeeTitleId"]; }
            }
            public NsColumn EOE_EmployeeTitleName_XX
            {
                  get { return this["EOE_EmployeeTitleName_XX"]; }
            }
            public NsColumn EOE_Enabled
            {
                  get { return this["EOE_Enabled"]; }
            }
            public NsColumn EOE_EntryDate
            {
                  get { return this["EOE_EntryDate"]; }
            }
            public NsColumn EOE_IsLeave_XX
            {
                  get { return this["EOE_IsLeave_XX"]; }
            }
            public NsColumn EOE_LeaveDate
            {
                  get { return this["EOE_LeaveDate"]; }
            }
            public NsColumn EOE_LoginAccount_XX
            {
                  get { return this["EOE_LoginAccount_XX"]; }
            }
            public NsColumn EOE_LoginPassword_XX
            {
                  get { return this["EOE_LoginPassword_XX"]; }
            }
            public NsColumn EOE_PersonalImage
            {
                  get { return this["EOE_PersonalImage"]; }
            }
            public NsColumn EOE_Phone1
            {
                  get { return this["EOE_Phone1"]; }
            }
            public NsColumn EOE_Phone2
            {
                  get { return this["EOE_Phone2"]; }
            }
            public NsColumn EOE_Remark
            {
                  get { return this["EOE_Remark"]; }
            }
            public NsColumn EOE_Sex
            {
                  get { return this["EOE_Sex"]; }
            }
            public NsColumn EOE_SexName_XX
            {
                  get { return this["EOE_SexName_XX"]; }
            }
            public NsColumn EOE_Signature
            {
                  get { return this["EOE_Signature"]; }
            }
            public NsColumn EOE_SmsNumber
            {
                  get { return this["EOE_SmsNumber"]; }
            }
        }
    }
}
