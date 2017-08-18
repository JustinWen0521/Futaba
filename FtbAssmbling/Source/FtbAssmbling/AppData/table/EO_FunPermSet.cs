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
    /// {T}&lt;EOFPS&gt;程式功能授權{FunPermSet}
    /// </summary>
    public interface EO_FunPermSet : INsTable
    {
        /// <summary>
        /// [DIRECT]*授權功能ID{FunPermSetId}：【PK&lt;EOFPS&gt;】
        /// </summary> 
        NsColumn EOFPS_FunPermSetId { get; }
        /// <summary>
        /// [DIRECT]*功能代號{20}&lt;br/&gt;
        /// </summary> 
        NsColumn EOFPS_FunctionCode_XX { get; }
        /// <summary>
        /// [DIRECT]功能名稱{50}&lt;br/&gt;
        /// </summary> 
        NsColumn EOFPS_FunctionName_XX { get; }
        /// <summary>
        /// [DIRECT]排序{INT}&lt;br/&gt;
        /// </summary> 
        NsColumn EOFPS_FunctionSeqNo_XX { get; }
        /// <summary>
        /// [DIRECT]*授權功能ID{MenuFunId}：【FK&lt;EOMF&gt;】
        /// </summary> 
        NsColumn EOFPS_MenuFunId { get; }
        /// <summary>
        /// [DIRECT]*功能表ID{MenuId}：【FK&lt;EOM&gt;】&lt;br/&gt;&lt;br/&gt;
        /// </summary> 
        NsColumn EOFPS_MenuId_XX { get; }
        /// <summary>
        /// [DIRECT]*功能項目No{MenuItemNo:50}：【Report.1】&lt;br/&gt;
        /// </summary> 
        NsColumn EOFPS_MenuItemNo_XX { get; }
        /// <summary>
        /// #功能項目No{MenuItemNoName_XX}：【個人紀錄報表】&lt;br/&gt;
        /// </summary> 
        NsColumn EOFPS_MenuItemNoName_XX { get; }
        /// <summary>
        /// [DIRECT]*授權程式ID{MenuPermSetId}：【FK&lt;EOMPS&gt;】
        /// </summary> 
        NsColumn EOFPS_MenuPermSetId { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class EO_FunPermSetNsTable : NsTable, EO_FunPermSet
        {
            public NsColumn EOFPS_FunPermSetId
            {
                  get { return this["EOFPS_FunPermSetId"]; }
            }
            public NsColumn EOFPS_FunctionCode_XX
            {
                  get { return this["EOFPS_FunctionCode_XX"]; }
            }
            public NsColumn EOFPS_FunctionName_XX
            {
                  get { return this["EOFPS_FunctionName_XX"]; }
            }
            public NsColumn EOFPS_FunctionSeqNo_XX
            {
                  get { return this["EOFPS_FunctionSeqNo_XX"]; }
            }
            public NsColumn EOFPS_MenuFunId
            {
                  get { return this["EOFPS_MenuFunId"]; }
            }
            public NsColumn EOFPS_MenuId_XX
            {
                  get { return this["EOFPS_MenuId_XX"]; }
            }
            public NsColumn EOFPS_MenuItemNo_XX
            {
                  get { return this["EOFPS_MenuItemNo_XX"]; }
            }
            public NsColumn EOFPS_MenuItemNoName_XX
            {
                  get { return this["EOFPS_MenuItemNoName_XX"]; }
            }
            public NsColumn EOFPS_MenuPermSetId
            {
                  get { return this["EOFPS_MenuPermSetId"]; }
            }
        }
    }
}
