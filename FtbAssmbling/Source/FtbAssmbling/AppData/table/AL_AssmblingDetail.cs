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
    /// {T}組立機臺明細 {AL_AssmblingDetail}
    /// </summary>
    public interface AL_AssmblingDetail : INsTable
    {
        /// <summary>
        /// *生產階段日期 {DTN_DATETIME_19}：【】
        /// </summary> 
        NsColumn ALAD_DATE { get; }
        /// <summary>
        /// *品名 {DTN_NVARCHAR20}：【】
        /// </summary> 
        NsColumn ALAD_ITEM { get; }
        /// <summary>
        /// *機臺編碼 {DTN_NVARCHAR10}：【】
        /// </summary> 
        NsColumn ALAD_MCID { get; }
        /// <summary>
        /// *生產數量 {DTN_DECIMAL}：【】
        /// </summary> 
        NsColumn ALAD_QTY { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class AL_AssmblingDetailNsTable : NsTable, AL_AssmblingDetail
        {
            public NsColumn ALAD_DATE
            {
                  get { return this["ALAD_DATE"]; }
            }
            public NsColumn ALAD_ITEM
            {
                  get { return this["ALAD_ITEM"]; }
            }
            public NsColumn ALAD_MCID
            {
                  get { return this["ALAD_MCID"]; }
            }
            public NsColumn ALAD_QTY
            {
                  get { return this["ALAD_QTY"]; }
            }
        }
    }
}
