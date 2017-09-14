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
    /// {T}程式功能清單{EO_MenuFun}
    /// </summary>
    public interface EO_MenuFun : INsTable
    {
        /// <summary>
        /// [DIRECT]*EOMF_MenupermfunId{Id}：【PK】
        /// </summary> 
        NsColumn EOMF_MenuFunId { get; }
        /// <summary>
        /// [DIRECT]*功能代號{20}
        /// </summary> 
        NsColumn EOMF_FunctionCode { get; }
        /// <summary>
        /// [DIRECT]功能說明{50}
        /// </summary> 
        NsColumn EOMF_FunctionDesc { get; }
        /// <summary>
        /// [DIRECT]功能名稱{50}
        /// </summary> 
        NsColumn EOMF_FunctionName { get; }
        /// <summary>
        /// [DIRECT]程式代號{20}
        /// </summary> 
        NsColumn EOMF_ItemNo { get; }
        /// <summary>
        /// [DIRECT]排序{INT}
        /// </summary> 
        NsColumn EOMF_SeqNo { get; }
        /// <summary>
        /// [DIRECT]工具列層級{1}【F：表單 / T：資料表 / R：資料列】
        /// </summary> 
        NsColumn EOMF_ToolbarLevel { get; }
        /// <summary>
        /// [DIRECT]工具列層級說明{1}【F：表單 / T：資料表 / R：資料列】
        /// </summary> 
        NsColumn EOMF_ToolbarLevelName_XX { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class EO_MenuFunNsTable : NsTable, EO_MenuFun
        {
            public NsColumn EOMF_MenuFunId
            {
                  get { return this["EOMF_MenuFunId"]; }
            }
            public NsColumn EOMF_FunctionCode
            {
                  get { return this["EOMF_FunctionCode"]; }
            }
            public NsColumn EOMF_FunctionDesc
            {
                  get { return this["EOMF_FunctionDesc"]; }
            }
            public NsColumn EOMF_FunctionName
            {
                  get { return this["EOMF_FunctionName"]; }
            }
            public NsColumn EOMF_ItemNo
            {
                  get { return this["EOMF_ItemNo"]; }
            }
            public NsColumn EOMF_SeqNo
            {
                  get { return this["EOMF_SeqNo"]; }
            }
            public NsColumn EOMF_ToolbarLevel
            {
                  get { return this["EOMF_ToolbarLevel"]; }
            }
            public NsColumn EOMF_ToolbarLevelName_XX
            {
                  get { return this["EOMF_ToolbarLevelName_XX"]; }
            }
        }
    }
}
