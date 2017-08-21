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
    /// {T}組立機臺主檔Log {AL_AssmblingLog}
    /// </summary>
    public interface AL_AssmblingLog : INsTable
    {
        /// <summary>
        /// *組立機臺主檔LogID {DTN_NID}：【】
        /// </summary> 
        NsColumn ALAL_AssmblingLogId { get; }
        /// <summary>
        /// *後工程組立ID {DTN_NID}：【】
        /// </summary> 
        NsColumn ALAL_AssmblingId { get; }
        /// <summary>
        /// *建立日期 {DTN_DATETIME_19}：【】
        /// </summary> 
        NsColumn ALAL_CreateDate { get; }
        /// <summary>
        /// *建立者ID {DTN_NID}：【】
        /// </summary> 
        NsColumn ALAL_CreatorId { get; }
        /// <summary>
        /// *人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        NsColumn ALAL_CreatorName_XX { get; }
        /// <summary>
        /// *有效日期 {DTN_DATETIME_19}：【】
        /// </summary> 
        NsColumn ALAL_EffectDate { get; }
        /// <summary>
        /// *失效日期 {DTN_DATETIME_19}：【】
        /// </summary> 
        NsColumn ALAL_InvalidDate { get; }
        /// <summary>
        /// *機臺編碼 {DTN_NVARCHAR10}：【】
        /// </summary> 
        NsColumn ALAL_MCID { get; }
        /// <summary>
        /// *行位置 {DTN_INTEGER}：【】
        /// </summary> 
        NsColumn ALAL_SEQCol { get; }
        /// <summary>
        /// *列位置 {DTN_INTEGER}：【】
        /// </summary> 
        NsColumn ALAL_SEQRow { get; }
        /// <summary>
        /// *異動日期 {DTN_DATETIME_19}：【】
        /// </summary> 
        NsColumn ALAL_UpdateDate { get; }
        /// <summary>
        /// *異動者ID {DTN_NVARCHAR1}：【】
        /// </summary> 
        NsColumn ALAL_UpdaterId { get; }
        /// <summary>
        /// *人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        NsColumn ALAL_UpdaterName_XX { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class AL_AssmblingLogNsTable : NsTable, AL_AssmblingLog
        {
            public NsColumn ALAL_AssmblingLogId
            {
                  get { return this["ALAL_AssmblingLogId"]; }
            }
            public NsColumn ALAL_AssmblingId
            {
                  get { return this["ALAL_AssmblingId"]; }
            }
            public NsColumn ALAL_CreateDate
            {
                  get { return this["ALAL_CreateDate"]; }
            }
            public NsColumn ALAL_CreatorId
            {
                  get { return this["ALAL_CreatorId"]; }
            }
            public NsColumn ALAL_CreatorName_XX
            {
                  get { return this["ALAL_CreatorName_XX"]; }
            }
            public NsColumn ALAL_EffectDate
            {
                  get { return this["ALAL_EffectDate"]; }
            }
            public NsColumn ALAL_InvalidDate
            {
                  get { return this["ALAL_InvalidDate"]; }
            }
            public NsColumn ALAL_MCID
            {
                  get { return this["ALAL_MCID"]; }
            }
            public NsColumn ALAL_SEQCol
            {
                  get { return this["ALAL_SEQCol"]; }
            }
            public NsColumn ALAL_SEQRow
            {
                  get { return this["ALAL_SEQRow"]; }
            }
            public NsColumn ALAL_UpdateDate
            {
                  get { return this["ALAL_UpdateDate"]; }
            }
            public NsColumn ALAL_UpdaterId
            {
                  get { return this["ALAL_UpdaterId"]; }
            }
            public NsColumn ALAL_UpdaterName_XX
            {
                  get { return this["ALAL_UpdaterName_XX"]; }
            }
        }
    }
}
