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
    /// &lt;EOET&gt;人員職稱{EmployeeTitle}
    /// </summary>
    public interface EO_EmployeeTitle : INsTable
    {
        /// <summary>
        /// [DIRECT]*職稱Id{EmployeeTitleId}：【PK&lt;EOET&gt;】
        /// </summary> 
        NsColumn EOET_EmployeeTitleId { get; }
        /// <summary>
        /// #是否正在使用中{InUse_XX,InUseName_XX}：○{T}是 ○{F}否
        /// </summary> 
        NsColumn EOET_InUse_XX { get; }
        /// <summary>
        /// #是否正在使用中{InUse_XX,InUseName_XX}：○{T}是 ○{F}否
        /// </summary> 
        NsColumn EOET_InUseName_XX { get; }
        /// <summary>
        /// [DIRECT]*職稱順序{ListOrder:INT}：【1000】
        /// </summary> 
        NsColumn EOET_ListOrder { get; }
        /// <summary>
        /// [DIRECT]職稱代號 {TitleCode:20}：【A312】
        /// </summary> 
        NsColumn EOET_TitleCode { get; }
        /// <summary>
        /// [DIRECT]*職稱名稱{TitleName:20}：【組長】
        /// </summary> 
        NsColumn EOET_TitleName { get; }
        /// <summary>
        /// #人數{UserCount_XX}：【1000】
        /// </summary> 
        NsColumn EOET_UserCount_XX { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class EO_EmployeeTitleNsTable : NsTable, EO_EmployeeTitle
        {
            public NsColumn EOET_EmployeeTitleId
            {
                  get { return this["EOET_EmployeeTitleId"]; }
            }
            public NsColumn EOET_InUse_XX
            {
                  get { return this["EOET_InUse_XX"]; }
            }
            public NsColumn EOET_InUseName_XX
            {
                  get { return this["EOET_InUseName_XX"]; }
            }
            public NsColumn EOET_ListOrder
            {
                  get { return this["EOET_ListOrder"]; }
            }
            public NsColumn EOET_TitleCode
            {
                  get { return this["EOET_TitleCode"]; }
            }
            public NsColumn EOET_TitleName
            {
                  get { return this["EOET_TitleName"]; }
            }
            public NsColumn EOET_UserCount_XX
            {
                  get { return this["EOET_UserCount_XX"]; }
            }
        }
    }
}
