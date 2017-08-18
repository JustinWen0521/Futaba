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
    /// {T}&lt;EOMS&gt;功能表/功能結構 {MenuStruct}
    /// </summary>
    public interface EO_MenuStruct : INsTable
    {
        /// <summary>
        /// [DIRECT]*功能ID{NodeId}：【PK】
        /// </summary> 
        NsColumn EOMS_NodeId { get; }
        /// <summary>
        /// #兄弟節點數量{BrotherCount_XX:N}：【5】
        /// </summary> 
        NsColumn EOMS_BrotherCount_XX { get; }
        /// <summary>
        /// #子結點數量{ChildCount_XX:INT}：【1】
        /// </summary> 
        NsColumn EOMS_ChildCount_XX { get; }
        /// <summary>
        /// [DIRECT]點選模式{ClickMode}：○{U}網址 ○{A}視窗代碼 {X}○其他
        /// </summary> 
        NsColumn EOMS_ClickMode { get; }
        /// <summary>
        /// [DIRECT]點選模式{ClickMode}：○{U}網址 ○{A}視窗代碼 {X}○其他
        /// </summary> 
        NsColumn EOMS_ClickModeName_XX { get; }
        /// <summary>
        /// [DIRECT]功能表代碼{Code:20}：【AB0001】
        /// </summary> 
        NsColumn EOMS_Code { get; }
        /// <summary>
        /// [DIRECT]自訂參數1 (Action){CustAttr1:20}：【】
        /// </summary> 
        NsColumn EOMS_CustAttr1 { get; }
        /// <summary>
        /// [DIRECT]自訂參數2 (Controller){CustAttr2:20}：【】
        /// </summary> 
        NsColumn EOMS_CustAttr2 { get; }
        /// <summary>
        /// [DIRECT]自訂參數3 (Area){CustAttr3:20}：【】
        /// </summary> 
        NsColumn EOMS_CustAttr3 { get; }
        /// <summary>
        /// #階層號碼{LevelNo_XX:INT}：【10】
        /// </summary> 
        NsColumn EOMS_LevelNo_XX { get; }
        /// <summary>
        /// #單一站台{MatchSiteId_XX}：【KEY&lt;EOSS&gt;】ex.若有多個符合只列出第一個
        /// </summary> 
        NsColumn EOMS_MatchSiteId_XX { get; }
        /// <summary>
        /// [DIRECT]功能表名稱{Name:20}：【主檔維護】
        /// </summary> 
        NsColumn EOMS_Name { get; }
        /// <summary>
        /// *節點類型{NodeType_XX}：○{A}功能表 ○{B}目錄 ○{C}功能
        /// </summary> 
        NsColumn EOMS_NodeType_XX { get; }
        /// <summary>
        /// [DIRECT]*備註{Note:100}：【HelloWorld】
        /// </summary> 
        NsColumn EOMS_Note { get; }
        /// <summary>
        /// [DIRECT]功能表代碼{Code:20}：【AB0001】&lt;br/&gt;
        /// </summary> 
        NsColumn EOMS_ParentCode_XX { get; }
        /// <summary>
        /// [DIRECT]*父節點ID{ParentId}：【KEY&lt;EOMF&gt;】
        /// </summary> 
        NsColumn EOMS_ParentId { get; }
        /// <summary>
        /// [DIRECT]功能表名稱{Name:20}：【主檔維護】&lt;br/&gt;
        /// </summary> 
        NsColumn EOMS_ParentName_XX { get; }
        /// <summary>
        /// #節點歸屬的根結點Id{RootId_XX}：【KEY&lt;EOMS&gt;】※節點歸屬的根結點
        /// </summary> 
        NsColumn EOMS_RootId_XX { get; }
        /// <summary>
        /// [DIRECT]排序順序{SortNo:INT}：【1】※Brother之間的排序順位，由1起始編號。
        /// </summary> 
        NsColumn EOMS_SortNo { get; }
        /// <summary>
        /// #樹系號碼-左{TreeLeftNo_XX:INT}：【10】
        /// </summary> 
        NsColumn EOMS_TreeLeftNo_XX { get; }
        /// <summary>
        /// #樹系號碼-右{TreeRightNo_XX:INT}：【10】
        /// </summary> 
        NsColumn EOMS_TreeRightNo_XX { get; }
        /// <summary>
        /// [DIRECT]網址{Url:100}：【http://www.google.com.tw】
        /// </summary> 
        NsColumn EOMS_Url { get; }
        /// <summary>
        /// [DIRECT]網址Tareget{UrlTarget:20}：【_blank】
        /// </summary> 
        NsColumn EOMS_UrlTarget { get; }
        /// <summary>
        /// [DIRECT]顯示於功能表{Viewable}：○{Y}是 ○{N}否
        /// </summary> 
        NsColumn EOMS_Viewable { get; }
        /// <summary>
        /// [DIRECT]視窗{WinClass:50}：【EoMenuListWindow】
        /// </summary> 
        NsColumn EOMS_WinClass { get; }
        /// <summary>
        /// [DIRECT]視窗參數{WinParam:100}：【Name=123&amp;Name_U=456】
        /// </summary> 
        NsColumn EOMS_WinParam { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class EO_MenuStructNsTable : NsTable, EO_MenuStruct
        {
            public NsColumn EOMS_NodeId
            {
                  get { return this["EOMS_NodeId"]; }
            }
            public NsColumn EOMS_BrotherCount_XX
            {
                  get { return this["EOMS_BrotherCount_XX"]; }
            }
            public NsColumn EOMS_ChildCount_XX
            {
                  get { return this["EOMS_ChildCount_XX"]; }
            }
            public NsColumn EOMS_ClickMode
            {
                  get { return this["EOMS_ClickMode"]; }
            }
            public NsColumn EOMS_ClickModeName_XX
            {
                  get { return this["EOMS_ClickModeName_XX"]; }
            }
            public NsColumn EOMS_Code
            {
                  get { return this["EOMS_Code"]; }
            }
            public NsColumn EOMS_CustAttr1
            {
                  get { return this["EOMS_CustAttr1"]; }
            }
            public NsColumn EOMS_CustAttr2
            {
                  get { return this["EOMS_CustAttr2"]; }
            }
            public NsColumn EOMS_CustAttr3
            {
                  get { return this["EOMS_CustAttr3"]; }
            }
            public NsColumn EOMS_LevelNo_XX
            {
                  get { return this["EOMS_LevelNo_XX"]; }
            }
            public NsColumn EOMS_MatchSiteId_XX
            {
                  get { return this["EOMS_MatchSiteId_XX"]; }
            }
            public NsColumn EOMS_Name
            {
                  get { return this["EOMS_Name"]; }
            }
            public NsColumn EOMS_NodeType_XX
            {
                  get { return this["EOMS_NodeType_XX"]; }
            }
            public NsColumn EOMS_Note
            {
                  get { return this["EOMS_Note"]; }
            }
            public NsColumn EOMS_ParentCode_XX
            {
                  get { return this["EOMS_ParentCode_XX"]; }
            }
            public NsColumn EOMS_ParentId
            {
                  get { return this["EOMS_ParentId"]; }
            }
            public NsColumn EOMS_ParentName_XX
            {
                  get { return this["EOMS_ParentName_XX"]; }
            }
            public NsColumn EOMS_RootId_XX
            {
                  get { return this["EOMS_RootId_XX"]; }
            }
            public NsColumn EOMS_SortNo
            {
                  get { return this["EOMS_SortNo"]; }
            }
            public NsColumn EOMS_TreeLeftNo_XX
            {
                  get { return this["EOMS_TreeLeftNo_XX"]; }
            }
            public NsColumn EOMS_TreeRightNo_XX
            {
                  get { return this["EOMS_TreeRightNo_XX"]; }
            }
            public NsColumn EOMS_Url
            {
                  get { return this["EOMS_Url"]; }
            }
            public NsColumn EOMS_UrlTarget
            {
                  get { return this["EOMS_UrlTarget"]; }
            }
            public NsColumn EOMS_Viewable
            {
                  get { return this["EOMS_Viewable"]; }
            }
            public NsColumn EOMS_WinClass
            {
                  get { return this["EOMS_WinClass"]; }
            }
            public NsColumn EOMS_WinParam
            {
                  get { return this["EOMS_WinParam"]; }
            }
        }
    }
}
