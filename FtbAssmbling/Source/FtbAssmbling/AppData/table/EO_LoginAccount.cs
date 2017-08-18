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
    /// &lt;EOLA&gt;登入帳號{LoginAccount}
    /// </summary>
    public interface EO_LoginAccount : INsTable
    {
        /// <summary>
        /// [DIRECT]*登入者Id{LoginAccountId}：【PK&lt;EOE&gt;】
        /// </summary> 
        NsColumn EOLA_LoginAccountId { get; }
        /// <summary>
        /// [DIRECT]登入失敗次數{FailureCount:INT}：【3】
        /// </summary> 
        NsColumn EOLA_FailureCount { get; }
        /// <summary>
        /// [DIRECT]失敗停權日期{FailureDate:D}：【2006/09/19 13:20:20】
        /// </summary> 
        NsColumn EOLA_FailureDate { get; }
        /// <summary>
        /// [DIRECT]帳號啟用{IsEnable:1,IsEnableName_XX}：○{T}啟用 ○{F}停用
        /// </summary> 
        NsColumn EOLA_IsEnable { get; }
        /// <summary>
        /// [DIRECT]帳號啟用{IsEnable:1,IsEnableName_XX}：○{T}啟用 ○{F}停用
        /// </summary> 
        NsColumn EOLA_IsEnableName_XX { get; }
        /// <summary>
        /// [DIRECT]最後登入日期{LastLoginDate:D}：【2006/09/19 13:20:20】
        /// </summary> 
        NsColumn EOLA_LastLoginDate { get; }
        /// <summary>
        /// [DIRECT]*登入帳號{LoginAccount:50}：【Administrator】
        /// </summary> 
        NsColumn EOLA_LoginAccount { get; }
        /// <summary>
        /// [DIRECT]*登入密碼{LoginPassword:20}：【XYXCDE】
        /// </summary> 
        NsColumn EOLA_LoginPassword { get; }
        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        NsColumn EOLA_UserEmail_XX { get; }
        /// <summary>
        /// [DIRECT]#標準姓名{EmployeeStandardName_XX}：【林勝文 組長】&lt;br/&gt;
        /// </summary> 
        NsColumn EOLA_UserName_XX { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class EO_LoginAccountNsTable : NsTable, EO_LoginAccount
        {
            public NsColumn EOLA_LoginAccountId
            {
                  get { return this["EOLA_LoginAccountId"]; }
            }
            public NsColumn EOLA_FailureCount
            {
                  get { return this["EOLA_FailureCount"]; }
            }
            public NsColumn EOLA_FailureDate
            {
                  get { return this["EOLA_FailureDate"]; }
            }
            public NsColumn EOLA_IsEnable
            {
                  get { return this["EOLA_IsEnable"]; }
            }
            public NsColumn EOLA_IsEnableName_XX
            {
                  get { return this["EOLA_IsEnableName_XX"]; }
            }
            public NsColumn EOLA_LastLoginDate
            {
                  get { return this["EOLA_LastLoginDate"]; }
            }
            public NsColumn EOLA_LoginAccount
            {
                  get { return this["EOLA_LoginAccount"]; }
            }
            public NsColumn EOLA_LoginPassword
            {
                  get { return this["EOLA_LoginPassword"]; }
            }
            public NsColumn EOLA_UserEmail_XX
            {
                  get { return this["EOLA_UserEmail_XX"]; }
            }
            public NsColumn EOLA_UserName_XX
            {
                  get { return this["EOLA_UserName_XX"]; }
            }
        }
    }
}
