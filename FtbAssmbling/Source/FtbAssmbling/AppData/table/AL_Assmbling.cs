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
    /// {T}組立機臺主檔 {AL_Assmbling}
    /// </summary>
    public interface AL_Assmbling : INsTable
    {
        /// <summary>
        /// *後工程組立ID {DTN_NID}：【】
        /// </summary> 
        NsColumn ALA_AssmblingId { get; }
        /// <summary>
        /// *建立日期 {DTN_DATETIME_19}：【】
        /// </summary> 
        NsColumn ALA_CreateDate { get; }
        /// <summary>
        /// *建立者ID {DTN_NID}：【】
        /// </summary> 
        NsColumn ALA_CreatorId { get; }
        /// <summary>
        /// *人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        NsColumn ALA_CreatorName_XX { get; }
        /// <summary>
        /// *工程代碼 {DTN_NVARCHAR20}：【】
        /// </summary> 
        NsColumn ALA_MCCode { get; }
        /// <summary>
        /// *機臺編碼 {DTN_NVARCHAR10}：【】
        /// </summary> 
        NsColumn ALA_MCID { get; }
        /// <summary>
        /// *工程描述 {DTN_NVARCHAR50}：【】
        /// </summary> 
        NsColumn ALA_MCName { get; }
        /// <summary>
        /// *行位置 {DTN_INTEGER}：【】
        /// </summary> 
        NsColumn ALA_SEQCol { get; }
        /// <summary>
        /// *列位置 {DTN_INTEGER}：【】
        /// </summary> 
        NsColumn ALA_SEQRow { get; }
        /// <summary>
        /// *異動日期 {DTN_DATETIME_19}：【】
        /// </summary> 
        NsColumn ALA_UpdateDate { get; }
        /// <summary>
        /// *異動者ID {DTN_NVARCHAR1}：【】
        /// </summary> 
        NsColumn ALA_UpdaterId { get; }
        /// <summary>
        /// *人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        NsColumn ALA_UpdaterName_XX { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class AL_AssmblingNsTable : NsTable, AL_Assmbling
        {
            public NsColumn ALA_AssmblingId
            {
                  get { return this["ALA_AssmblingId"]; }
            }
            public NsColumn ALA_CreateDate
            {
                  get { return this["ALA_CreateDate"]; }
            }
            public NsColumn ALA_CreatorId
            {
                  get { return this["ALA_CreatorId"]; }
            }
            public NsColumn ALA_CreatorName_XX
            {
                  get { return this["ALA_CreatorName_XX"]; }
            }
            public NsColumn ALA_MCCode
            {
                  get { return this["ALA_MCCode"]; }
            }
            public NsColumn ALA_MCID
            {
                  get { return this["ALA_MCID"]; }
            }
            public NsColumn ALA_MCName
            {
                  get { return this["ALA_MCName"]; }
            }
            public NsColumn ALA_SEQCol
            {
                  get { return this["ALA_SEQCol"]; }
            }
            public NsColumn ALA_SEQRow
            {
                  get { return this["ALA_SEQRow"]; }
            }
            public NsColumn ALA_UpdateDate
            {
                  get { return this["ALA_UpdateDate"]; }
            }
            public NsColumn ALA_UpdaterId
            {
                  get { return this["ALA_UpdaterId"]; }
            }
            public NsColumn ALA_UpdaterName_XX
            {
                  get { return this["ALA_UpdaterName_XX"]; }
            }
        }
    }
}
