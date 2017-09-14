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
    /// &lt;EOO&gt;組織{Organization}
    /// </summary>
    public interface EO_Organization : INsTable
    {
        /// <summary>
        /// [DIRECT]*組織ID{OrganizationId}：【PK&lt;EOO&gt;】
        /// </summary> 
        NsColumn EOO_OrganizationId { get; }
        /// <summary>
        /// [DIRECT]地址{Address:100}
        /// </summary> 
        NsColumn EOO_Address { get; }
        /// <summary>
        /// [DIRECT]信用額度{Bail:INT}
        /// </summary> 
        NsColumn EOO_Bail { get; }
        /// <summary>
        /// [DIRECT]銀行帳戶{BankAccount:20}
        /// </summary> 
        NsColumn EOO_BankAccount { get; }
        /// <summary>
        /// [DIRECT]帳戶名稱{BankAccountName:50}
        /// </summary> 
        NsColumn EOO_BankAccountName { get; }
        /// <summary>
        /// [DIRECT]銀行代號{BankCode:10}
        /// </summary> 
        NsColumn EOO_BankCode { get; }
        /// <summary>
        /// [DIRECT]銀行名稱{BankName:50}
        /// </summary> 
        NsColumn EOO_BankName { get; }
        /// <summary>
        /// [DIRECT]組織代號{Code:10}：【AB0913】
        /// </summary> 
        NsColumn EOO_Code { get; }
        /// <summary>
        /// [DIRECT]聯絡人{Contact:10}
        /// </summary> 
        NsColumn EOO_Contact { get; }
        /// <summary>
        /// [DIRECT]*建立日期{CreateDate：DATETIME_19}：【yyyy/MM/dd HH:mm:ss】
        /// </summary> 
        NsColumn EOO_CreateDate { get; }
        /// <summary>
        /// [DIRECT]*建立者id{CreatorId：Id}：
        /// </summary> 
        NsColumn EOO_CreatorId { get; }
        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        NsColumn EOO_CreatorName_XX { get; }
        /// <summary>
        /// [DIRECT]Email{Email:100}
        /// </summary> 
        NsColumn EOO_Email { get; }
        /// <summary>
        /// [DIRECT]傳真{Fax:20}
        /// </summary> 
        NsColumn EOO_Fax { get; }
        /// <summary>
        /// [DIRECT]*組織名稱{FullName:50}：【永利果菜批發商行】
        /// </summary> 
        NsColumn EOO_FullName { get; }
        /// <summary>
        /// [DIRECT]電話1{Phone1:20}
        /// </summary> 
        NsColumn EOO_Phone1 { get; }
        /// <summary>
        /// [DIRECT]電話2{Phone2:20}
        /// </summary> 
        NsColumn EOO_Phone2 { get; }
        /// <summary>
        /// [DIRECT]暫停或廢止原因{Reason:50}
        /// </summary> 
        NsColumn EOO_Reason { get; }
        /// <summary>
        /// [DIRECT]登記日期{RegisterDate:D}
        /// </summary> 
        NsColumn EOO_RegisterDate { get; }
        /// <summary>
        /// [DIRECT]登記證號{RegisterNo:20}
        /// </summary> 
        NsColumn EOO_RegisterNo { get; }
        /// <summary>
        /// [DIRECT]備註{Remark:100}
        /// </summary> 
        NsColumn EOO_Remark { get; }
        /// <summary>
        /// [DIRECT]*組織簡稱{ShortName:10}：【永利行】
        /// </summary> 
        NsColumn EOO_ShortName { get; }
        /// <summary>
        /// [DIRECT]狀態{Status:1}
        /// </summary> 
        NsColumn EOO_Status { get; }
        /// <summary>
        /// [DIRECT]狀態說明{StatusName_XX:10}【A：啟用 / B：暫停 / Z：廢止】
        /// </summary> 
        NsColumn EOO_StatusName_XX { get; }
        /// <summary>
        /// [DIRECT]統一編號{UnifiedNo:10}
        /// </summary> 
        NsColumn EOO_UnifiedNo { get; }
        /// <summary>
        /// [DIRECT]*異動日期{UpdateDate：DATETIME_19}：【yyyy/MM/dd HH:mm:ss】
        /// </summary> 
        NsColumn EOO_UpdateDate { get; }
        /// <summary>
        /// [DIRECT]*異動者id{UpdaterId：Id}：
        /// </summary> 
        NsColumn EOO_UpdaterId { get; }
        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        NsColumn EOO_UpdaterName_XX { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class EO_OrganizationNsTable : NsTable, EO_Organization
        {
            public NsColumn EOO_OrganizationId
            {
                  get { return this["EOO_OrganizationId"]; }
            }
            public NsColumn EOO_Address
            {
                  get { return this["EOO_Address"]; }
            }
            public NsColumn EOO_Bail
            {
                  get { return this["EOO_Bail"]; }
            }
            public NsColumn EOO_BankAccount
            {
                  get { return this["EOO_BankAccount"]; }
            }
            public NsColumn EOO_BankAccountName
            {
                  get { return this["EOO_BankAccountName"]; }
            }
            public NsColumn EOO_BankCode
            {
                  get { return this["EOO_BankCode"]; }
            }
            public NsColumn EOO_BankName
            {
                  get { return this["EOO_BankName"]; }
            }
            public NsColumn EOO_Code
            {
                  get { return this["EOO_Code"]; }
            }
            public NsColumn EOO_Contact
            {
                  get { return this["EOO_Contact"]; }
            }
            public NsColumn EOO_CreateDate
            {
                  get { return this["EOO_CreateDate"]; }
            }
            public NsColumn EOO_CreatorId
            {
                  get { return this["EOO_CreatorId"]; }
            }
            public NsColumn EOO_CreatorName_XX
            {
                  get { return this["EOO_CreatorName_XX"]; }
            }
            public NsColumn EOO_Email
            {
                  get { return this["EOO_Email"]; }
            }
            public NsColumn EOO_Fax
            {
                  get { return this["EOO_Fax"]; }
            }
            public NsColumn EOO_FullName
            {
                  get { return this["EOO_FullName"]; }
            }
            public NsColumn EOO_Phone1
            {
                  get { return this["EOO_Phone1"]; }
            }
            public NsColumn EOO_Phone2
            {
                  get { return this["EOO_Phone2"]; }
            }
            public NsColumn EOO_Reason
            {
                  get { return this["EOO_Reason"]; }
            }
            public NsColumn EOO_RegisterDate
            {
                  get { return this["EOO_RegisterDate"]; }
            }
            public NsColumn EOO_RegisterNo
            {
                  get { return this["EOO_RegisterNo"]; }
            }
            public NsColumn EOO_Remark
            {
                  get { return this["EOO_Remark"]; }
            }
            public NsColumn EOO_ShortName
            {
                  get { return this["EOO_ShortName"]; }
            }
            public NsColumn EOO_Status
            {
                  get { return this["EOO_Status"]; }
            }
            public NsColumn EOO_StatusName_XX
            {
                  get { return this["EOO_StatusName_XX"]; }
            }
            public NsColumn EOO_UnifiedNo
            {
                  get { return this["EOO_UnifiedNo"]; }
            }
            public NsColumn EOO_UpdateDate
            {
                  get { return this["EOO_UpdateDate"]; }
            }
            public NsColumn EOO_UpdaterId
            {
                  get { return this["EOO_UpdaterId"]; }
            }
            public NsColumn EOO_UpdaterName_XX
            {
                  get { return this["EOO_UpdaterName_XX"]; }
            }
        }
    }
}
