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
    /// &lt;EOM&gt; 功能表定義{Menu}
    /// </summary>
    public interface EO_Menu : INsTable
    {
        /// <summary>
        /// [DIRECT]*功能表ID{MenuId}：【PK&lt;EOM&gt;】
        /// </summary> 
        NsColumn EOM_MenuId { get; }
        /// <summary>
        /// #XML檔案路徑{FileFullName_XX}：【C:\001\AppMenu.xml】
        /// </summary> 
        NsColumn EOM_FileFullName_XX { get; }
        /// <summary>
        /// [DIRECT]XML檔案{FileName:50}：【~/data/AppMenu.xml】
        /// </summary> 
        NsColumn EOM_FileName { get; }
        /// <summary>
        /// [DIRECT]*功能表名稱{MenuName:20}：【首頁功能表】
        /// </summary> 
        NsColumn EOM_MenuName { get; }
        /// <summary>
        /// [DIRECT]資料庫檔案{StructId,StructName_XX}：【KEY&lt;EOMS&gt;,首頁功能表】
        /// </summary> 
        NsColumn EOM_StructId { get; }
        /// <summary>
        /// [DIRECT]功能表名稱{Name:20}：【主檔維護】&lt;br/&gt;
        /// </summary> 
        NsColumn EOM_StructName_XX { get; }
        /// <summary>
        /// [DIRECT]*結構檔案{StructSource:1}：○{F}Xml檔案 ○{D}資料庫檔案
        /// </summary> 
        NsColumn EOM_StructSource { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class EO_MenuNsTable : NsTable, EO_Menu
        {
            public NsColumn EOM_MenuId
            {
                  get { return this["EOM_MenuId"]; }
            }
            public NsColumn EOM_FileFullName_XX
            {
                  get { return this["EOM_FileFullName_XX"]; }
            }
            public NsColumn EOM_FileName
            {
                  get { return this["EOM_FileName"]; }
            }
            public NsColumn EOM_MenuName
            {
                  get { return this["EOM_MenuName"]; }
            }
            public NsColumn EOM_StructId
            {
                  get { return this["EOM_StructId"]; }
            }
            public NsColumn EOM_StructName_XX
            {
                  get { return this["EOM_StructName_XX"]; }
            }
            public NsColumn EOM_StructSource
            {
                  get { return this["EOM_StructSource"]; }
            }
        }
    }
}
