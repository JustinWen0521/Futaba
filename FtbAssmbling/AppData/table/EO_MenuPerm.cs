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
    /// {T}&lt;EOMP&gt;功能表/授權對象{MenuPerm}
    /// </summary>
    public interface EO_MenuPerm : INsTable
    {
        /// <summary>
        /// [DIRECT]*授權對象ID{MenuPermId}：【PK&lt;EOMP&gt;】
        /// </summary> 
        NsColumn EOMP_MenuPermId { get; }
        /// <summary>
        /// [DIRECT]*功能表ID{MenuId}：【FK&lt;EOM&gt;】
        /// </summary> 
        NsColumn EOMP_MenuId { get; }
        /// <summary>
        /// [DIRECT]*授權對象代號{TargetId,TargetCode_XX}：【FK&lt;EOM|EOD|EOET&gt;，(部門)主計處】
        /// </summary> 
        NsColumn EOMP_TargetCode_XX { get; }
        /// <summary>
        /// [DIRECT]*授權對象{TargetId,TargetName_XX}：【FK&lt;EOM|EOD|EOET&gt;，(部門)主計處】
        /// </summary> 
        NsColumn EOMP_TargetId { get; }
        /// <summary>
        /// [DIRECT]*授權類型{TargetKind,TargetKindName_XX}：A：員工 / B：群組 / C：職稱 / D：權限 / E：機關
        /// </summary> 
        NsColumn EOMP_TargetKind { get; }
        /// <summary>
        /// [DIRECT]*授權類型{TargetKind,TargetKindName_XX}：A：員工 / B：群組 / C：職稱 / D：權限 / E：機關
        /// </summary> 
        NsColumn EOMP_TargetKindName_XX { get; }
        /// <summary>
        /// [DIRECT]*授權對象名稱{TargetId,TargetName_XX}：【FK&lt;EOM|EOD|EOET&gt;，(部門)主計處】
        /// </summary> 
        NsColumn EOMP_TargetName_XX { get; }
        /// <summary>
        /// [DIRECT]*檢視權限{ViewKind,ViewKindName_XX}○{Name}可檢視 ○{Name_U}不可檢視
        /// </summary> 
        NsColumn EOMP_ViewKind { get; }
        /// <summary>
        /// [DIRECT]*檢視權限{ViewKind,ViewKindName_XX}○{Name}可檢視 ○{Name_U}不可檢視
        /// </summary> 
        NsColumn EOMP_ViewKindName_XX { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class EO_MenuPermNsTable : NsTable, EO_MenuPerm
        {
            public NsColumn EOMP_MenuPermId
            {
                  get { return this["EOMP_MenuPermId"]; }
            }
            public NsColumn EOMP_MenuId
            {
                  get { return this["EOMP_MenuId"]; }
            }
            public NsColumn EOMP_TargetCode_XX
            {
                  get { return this["EOMP_TargetCode_XX"]; }
            }
            public NsColumn EOMP_TargetId
            {
                  get { return this["EOMP_TargetId"]; }
            }
            public NsColumn EOMP_TargetKind
            {
                  get { return this["EOMP_TargetKind"]; }
            }
            public NsColumn EOMP_TargetKindName_XX
            {
                  get { return this["EOMP_TargetKindName_XX"]; }
            }
            public NsColumn EOMP_TargetName_XX
            {
                  get { return this["EOMP_TargetName_XX"]; }
            }
            public NsColumn EOMP_ViewKind
            {
                  get { return this["EOMP_ViewKind"]; }
            }
            public NsColumn EOMP_ViewKindName_XX
            {
                  get { return this["EOMP_ViewKindName_XX"]; }
            }
        }
    }
}
