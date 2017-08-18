using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ftd.data
{
    /// <summary>
    /// {T}&lt;EOMS&gt;功能表/功能結構 {MenuStruct}
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class EO_MenuStructDataTable : FtdTypedDataTable<EO_MenuStructRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public EO_MenuStructDataTable() : base("EO_MenuStruct")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new EO_MenuStructDataTable();
            return getTableSchema(xs, dt, "EOMS");
        }

        [DebuggerNonUserCodeAttribute()]
        protected EO_MenuStructDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// [DIRECT]*功能ID{NodeId}：【PK】
        /// </summary> 
        public DataColumn EOMS_NodeIdColumn;

        /// <summary>
        /// #兄弟節點數量{BrotherCount_XX:N}：【5】
        /// </summary> 
        public DataColumn EOMS_BrotherCount_XXColumn;

        /// <summary>
        /// #子結點數量{ChildCount_XX:INT}：【1】
        /// </summary> 
        public DataColumn EOMS_ChildCount_XXColumn;

        /// <summary>
        /// [DIRECT]點選模式{ClickMode}：○{U}網址 ○{A}視窗代碼 {X}○其他
        /// </summary> 
        public DataColumn EOMS_ClickModeColumn;

        /// <summary>
        /// [DIRECT]點選模式{ClickMode}：○{U}網址 ○{A}視窗代碼 {X}○其他
        /// </summary> 
        public DataColumn EOMS_ClickModeName_XXColumn;

        /// <summary>
        /// [DIRECT]功能表代碼{Code:20}：【AB0001】
        /// </summary> 
        public DataColumn EOMS_CodeColumn;

        /// <summary>
        /// [DIRECT]自訂參數1 (Action){CustAttr1:20}：【】
        /// </summary> 
        public DataColumn EOMS_CustAttr1Column;

        /// <summary>
        /// [DIRECT]自訂參數2 (Controller){CustAttr2:20}：【】
        /// </summary> 
        public DataColumn EOMS_CustAttr2Column;

        /// <summary>
        /// [DIRECT]自訂參數3 (Area){CustAttr3:20}：【】
        /// </summary> 
        public DataColumn EOMS_CustAttr3Column;

        /// <summary>
        /// #階層號碼{LevelNo_XX:INT}：【10】
        /// </summary> 
        public DataColumn EOMS_LevelNo_XXColumn;

        /// <summary>
        /// #單一站台{MatchSiteId_XX}：【KEY&lt;EOSS&gt;】ex.若有多個符合只列出第一個
        /// </summary> 
        public DataColumn EOMS_MatchSiteId_XXColumn;

        /// <summary>
        /// [DIRECT]功能表名稱{Name:20}：【主檔維護】
        /// </summary> 
        public DataColumn EOMS_NameColumn;

        /// <summary>
        /// *節點類型{NodeType_XX}：○{A}功能表 ○{B}目錄 ○{C}功能
        /// </summary> 
        public DataColumn EOMS_NodeType_XXColumn;

        /// <summary>
        /// [DIRECT]*備註{Note:100}：【HelloWorld】
        /// </summary> 
        public DataColumn EOMS_NoteColumn;

        /// <summary>
        /// [DIRECT]功能表代碼{Code:20}：【AB0001】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOMS_ParentCode_XXColumn;

        /// <summary>
        /// [DIRECT]*父節點ID{ParentId}：【KEY&lt;EOMF&gt;】
        /// </summary> 
        public DataColumn EOMS_ParentIdColumn;

        /// <summary>
        /// [DIRECT]功能表名稱{Name:20}：【主檔維護】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOMS_ParentName_XXColumn;

        /// <summary>
        /// #節點歸屬的根結點Id{RootId_XX}：【KEY&lt;EOMS&gt;】※節點歸屬的根結點
        /// </summary> 
        public DataColumn EOMS_RootId_XXColumn;

        /// <summary>
        /// [DIRECT]排序順序{SortNo:INT}：【1】※Brother之間的排序順位，由1起始編號。
        /// </summary> 
        public DataColumn EOMS_SortNoColumn;

        /// <summary>
        /// #樹系號碼-左{TreeLeftNo_XX:INT}：【10】
        /// </summary> 
        public DataColumn EOMS_TreeLeftNo_XXColumn;

        /// <summary>
        /// #樹系號碼-右{TreeRightNo_XX:INT}：【10】
        /// </summary> 
        public DataColumn EOMS_TreeRightNo_XXColumn;

        /// <summary>
        /// [DIRECT]網址{Url:100}：【http://www.google.com.tw】
        /// </summary> 
        public DataColumn EOMS_UrlColumn;

        /// <summary>
        /// [DIRECT]網址Tareget{UrlTarget:20}：【_blank】
        /// </summary> 
        public DataColumn EOMS_UrlTargetColumn;

        /// <summary>
        /// [DIRECT]顯示於功能表{Viewable}：○{Y}是 ○{N}否
        /// </summary> 
        public DataColumn EOMS_ViewableColumn;

        /// <summary>
        /// [DIRECT]視窗{WinClass:50}：【EoMenuListWindow】
        /// </summary> 
        public DataColumn EOMS_WinClassColumn;

        /// <summary>
        /// [DIRECT]視窗參數{WinParam:100}：【Name=123&amp;Name_U=456】
        /// </summary> 
        public DataColumn EOMS_WinParamColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public EO_MenuStructRow findByPrimaryKey(String EOMS_NodeId)
        {
            return (EO_MenuStructRow)(Rows.Find(new object[] { EOMS_NodeId }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new EO_MenuStructDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            EOMS_NodeIdColumn = Columns["EOMS_NodeId"];
            EOMS_BrotherCount_XXColumn = Columns["EOMS_BrotherCount_XX"];
            EOMS_ChildCount_XXColumn = Columns["EOMS_ChildCount_XX"];
            EOMS_ClickModeColumn = Columns["EOMS_ClickMode"];
            EOMS_ClickModeName_XXColumn = Columns["EOMS_ClickModeName_XX"];
            EOMS_CodeColumn = Columns["EOMS_Code"];
            EOMS_CustAttr1Column = Columns["EOMS_CustAttr1"];
            EOMS_CustAttr2Column = Columns["EOMS_CustAttr2"];
            EOMS_CustAttr3Column = Columns["EOMS_CustAttr3"];
            EOMS_LevelNo_XXColumn = Columns["EOMS_LevelNo_XX"];
            EOMS_MatchSiteId_XXColumn = Columns["EOMS_MatchSiteId_XX"];
            EOMS_NameColumn = Columns["EOMS_Name"];
            EOMS_NodeType_XXColumn = Columns["EOMS_NodeType_XX"];
            EOMS_NoteColumn = Columns["EOMS_Note"];
            EOMS_ParentCode_XXColumn = Columns["EOMS_ParentCode_XX"];
            EOMS_ParentIdColumn = Columns["EOMS_ParentId"];
            EOMS_ParentName_XXColumn = Columns["EOMS_ParentName_XX"];
            EOMS_RootId_XXColumn = Columns["EOMS_RootId_XX"];
            EOMS_SortNoColumn = Columns["EOMS_SortNo"];
            EOMS_TreeLeftNo_XXColumn = Columns["EOMS_TreeLeftNo_XX"];
            EOMS_TreeRightNo_XXColumn = Columns["EOMS_TreeRightNo_XX"];
            EOMS_UrlColumn = Columns["EOMS_Url"];
            EOMS_UrlTargetColumn = Columns["EOMS_UrlTarget"];
            EOMS_ViewableColumn = Columns["EOMS_Viewable"];
            EOMS_WinClassColumn = Columns["EOMS_WinClass"];
            EOMS_WinParamColumn = Columns["EOMS_WinParam"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            EOMS_NodeIdColumn = new DataColumn("EOMS_NodeId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMS_NodeIdColumn);
            EOMS_NodeIdColumn.AllowDBNull = false;

            EOMS_BrotherCount_XXColumn = new DataColumn("EOMS_BrotherCount_XX", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(EOMS_BrotherCount_XXColumn);

            EOMS_ChildCount_XXColumn = new DataColumn("EOMS_ChildCount_XX", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(EOMS_ChildCount_XXColumn);

            EOMS_ClickModeColumn = new DataColumn("EOMS_ClickMode", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMS_ClickModeColumn);
            EOMS_ClickModeColumn.DefaultValue = "A";

            EOMS_ClickModeName_XXColumn = new DataColumn("EOMS_ClickModeName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMS_ClickModeName_XXColumn);

            EOMS_CodeColumn = new DataColumn("EOMS_Code", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMS_CodeColumn);

            EOMS_CustAttr1Column = new DataColumn("EOMS_CustAttr1", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMS_CustAttr1Column);

            EOMS_CustAttr2Column = new DataColumn("EOMS_CustAttr2", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMS_CustAttr2Column);

            EOMS_CustAttr3Column = new DataColumn("EOMS_CustAttr3", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMS_CustAttr3Column);

            EOMS_LevelNo_XXColumn = new DataColumn("EOMS_LevelNo_XX", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(EOMS_LevelNo_XXColumn);

            EOMS_MatchSiteId_XXColumn = new DataColumn("EOMS_MatchSiteId_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMS_MatchSiteId_XXColumn);

            EOMS_NameColumn = new DataColumn("EOMS_Name", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMS_NameColumn);

            EOMS_NodeType_XXColumn = new DataColumn("EOMS_NodeType_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMS_NodeType_XXColumn);

            EOMS_NoteColumn = new DataColumn("EOMS_Note", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMS_NoteColumn);

            EOMS_ParentCode_XXColumn = new DataColumn("EOMS_ParentCode_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMS_ParentCode_XXColumn);

            EOMS_ParentIdColumn = new DataColumn("EOMS_ParentId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMS_ParentIdColumn);

            EOMS_ParentName_XXColumn = new DataColumn("EOMS_ParentName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMS_ParentName_XXColumn);

            EOMS_RootId_XXColumn = new DataColumn("EOMS_RootId_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMS_RootId_XXColumn);

            EOMS_SortNoColumn = new DataColumn("EOMS_SortNo", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(EOMS_SortNoColumn);

            EOMS_TreeLeftNo_XXColumn = new DataColumn("EOMS_TreeLeftNo_XX", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(EOMS_TreeLeftNo_XXColumn);

            EOMS_TreeRightNo_XXColumn = new DataColumn("EOMS_TreeRightNo_XX", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(EOMS_TreeRightNo_XXColumn);

            EOMS_UrlColumn = new DataColumn("EOMS_Url", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMS_UrlColumn);

            EOMS_UrlTargetColumn = new DataColumn("EOMS_UrlTarget", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMS_UrlTargetColumn);

            EOMS_ViewableColumn = new DataColumn("EOMS_Viewable", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMS_ViewableColumn);
            EOMS_ViewableColumn.DefaultValue = "Y";

            EOMS_WinClassColumn = new DataColumn("EOMS_WinClass", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMS_WinClassColumn);

            EOMS_WinParamColumn = new DataColumn("EOMS_WinParam", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMS_WinParamColumn);

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { EOMS_NodeIdColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new EO_MenuStructRow(builder);
        }

    }

    ///<summary>
    ///{T}&lt;EOMS&gt;功能表/功能結構 {MenuStruct}  
    ///</summary>
    public class EO_MenuStructRow : FtdDataRow
    {
        private EO_MenuStructDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal EO_MenuStructRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((EO_MenuStructDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public EO_MenuStructDataTable TypeTable
        {
            get { return (EO_MenuStructDataTable)Table; }
        }

        ///<summary>
        ///[DIRECT]*功能ID{NodeId}：【PK】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMS_NodeId
        {
            get { return getAttrGetString(this[theTable.EOMS_NodeIdColumn]); }
            set { this[theTable.EOMS_NodeIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///#兄弟節點數量{BrotherCount_XX:N}：【5】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? EOMS_BrotherCount_XX
        {
            get { return getAttrGetValue<Int32>(this[theTable.EOMS_BrotherCount_XXColumn]); }
            set { this[this.theTable.EOMS_BrotherCount_XXColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///#子結點數量{ChildCount_XX:INT}：【1】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? EOMS_ChildCount_XX
        {
            get { return getAttrGetValue<Int32>(this[theTable.EOMS_ChildCount_XXColumn]); }
            set { this[this.theTable.EOMS_ChildCount_XXColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///[DIRECT]點選模式{ClickMode}：○{U}網址 ○{A}視窗代碼 {X}○其他  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMS_ClickMode
        {
            get { return getAttrGetString(this[theTable.EOMS_ClickModeColumn]); }
            set { this[theTable.EOMS_ClickModeColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]點選模式{ClickMode}：○{U}網址 ○{A}視窗代碼 {X}○其他  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMS_ClickModeName_XX
        {
            get { return getAttrGetString(this[theTable.EOMS_ClickModeName_XXColumn]); }
            set { this[theTable.EOMS_ClickModeName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]功能表代碼{Code:20}：【AB0001】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMS_Code
        {
            get { return getAttrGetString(this[theTable.EOMS_CodeColumn]); }
            set { this[theTable.EOMS_CodeColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]自訂參數1 (Action){CustAttr1:20}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMS_CustAttr1
        {
            get { return getAttrGetString(this[theTable.EOMS_CustAttr1Column]); }
            set { this[theTable.EOMS_CustAttr1Column] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]自訂參數2 (Controller){CustAttr2:20}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMS_CustAttr2
        {
            get { return getAttrGetString(this[theTable.EOMS_CustAttr2Column]); }
            set { this[theTable.EOMS_CustAttr2Column] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]自訂參數3 (Area){CustAttr3:20}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMS_CustAttr3
        {
            get { return getAttrGetString(this[theTable.EOMS_CustAttr3Column]); }
            set { this[theTable.EOMS_CustAttr3Column] = getAttrSetString(value); }
        }

        ///<summary>
        ///#階層號碼{LevelNo_XX:INT}：【10】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? EOMS_LevelNo_XX
        {
            get { return getAttrGetValue<Int32>(this[theTable.EOMS_LevelNo_XXColumn]); }
            set { this[this.theTable.EOMS_LevelNo_XXColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///#單一站台{MatchSiteId_XX}：【KEY&lt;EOSS&gt;】ex.若有多個符合只列出第一個  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMS_MatchSiteId_XX
        {
            get { return getAttrGetString(this[theTable.EOMS_MatchSiteId_XXColumn]); }
            set { this[theTable.EOMS_MatchSiteId_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]功能表名稱{Name:20}：【主檔維護】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMS_Name
        {
            get { return getAttrGetString(this[theTable.EOMS_NameColumn]); }
            set { this[theTable.EOMS_NameColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///*節點類型{NodeType_XX}：○{A}功能表 ○{B}目錄 ○{C}功能  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMS_NodeType_XX
        {
            get { return getAttrGetString(this[theTable.EOMS_NodeType_XXColumn]); }
            set { this[theTable.EOMS_NodeType_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*備註{Note:100}：【HelloWorld】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMS_Note
        {
            get { return getAttrGetString(this[theTable.EOMS_NoteColumn]); }
            set { this[theTable.EOMS_NoteColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]功能表代碼{Code:20}：【AB0001】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMS_ParentCode_XX
        {
            get { return getAttrGetString(this[theTable.EOMS_ParentCode_XXColumn]); }
            set { this[theTable.EOMS_ParentCode_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*父節點ID{ParentId}：【KEY&lt;EOMF&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMS_ParentId
        {
            get { return getAttrGetString(this[theTable.EOMS_ParentIdColumn]); }
            set { this[theTable.EOMS_ParentIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]功能表名稱{Name:20}：【主檔維護】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMS_ParentName_XX
        {
            get { return getAttrGetString(this[theTable.EOMS_ParentName_XXColumn]); }
            set { this[theTable.EOMS_ParentName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///#節點歸屬的根結點Id{RootId_XX}：【KEY&lt;EOMS&gt;】※節點歸屬的根結點  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMS_RootId_XX
        {
            get { return getAttrGetString(this[theTable.EOMS_RootId_XXColumn]); }
            set { this[theTable.EOMS_RootId_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]排序順序{SortNo:INT}：【1】※Brother之間的排序順位，由1起始編號。  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? EOMS_SortNo
        {
            get { return getAttrGetValue<Int32>(this[theTable.EOMS_SortNoColumn]); }
            set { this[this.theTable.EOMS_SortNoColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///#樹系號碼-左{TreeLeftNo_XX:INT}：【10】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? EOMS_TreeLeftNo_XX
        {
            get { return getAttrGetValue<Int32>(this[theTable.EOMS_TreeLeftNo_XXColumn]); }
            set { this[this.theTable.EOMS_TreeLeftNo_XXColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///#樹系號碼-右{TreeRightNo_XX:INT}：【10】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? EOMS_TreeRightNo_XX
        {
            get { return getAttrGetValue<Int32>(this[theTable.EOMS_TreeRightNo_XXColumn]); }
            set { this[this.theTable.EOMS_TreeRightNo_XXColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///[DIRECT]網址{Url:100}：【http://www.google.com.tw】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMS_Url
        {
            get { return getAttrGetString(this[theTable.EOMS_UrlColumn]); }
            set { this[theTable.EOMS_UrlColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]網址Tareget{UrlTarget:20}：【_blank】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMS_UrlTarget
        {
            get { return getAttrGetString(this[theTable.EOMS_UrlTargetColumn]); }
            set { this[theTable.EOMS_UrlTargetColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]顯示於功能表{Viewable}：○{Y}是 ○{N}否  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMS_Viewable
        {
            get { return getAttrGetString(this[theTable.EOMS_ViewableColumn]); }
            set { this[theTable.EOMS_ViewableColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]視窗{WinClass:50}：【EoMenuListWindow】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMS_WinClass
        {
            get { return getAttrGetString(this[theTable.EOMS_WinClassColumn]); }
            set { this[theTable.EOMS_WinClassColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]視窗參數{WinParam:100}：【Name=123&amp;Name_U=456】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMS_WinParam
        {
            get { return getAttrGetString(this[theTable.EOMS_WinParamColumn]); }
            set { this[theTable.EOMS_WinParamColumn] = getAttrSetString(value); }
        }

    }
}
