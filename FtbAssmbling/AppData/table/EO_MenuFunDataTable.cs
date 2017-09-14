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
    /// {T}程式功能清單{EO_MenuFun}
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class EO_MenuFunDataTable : FtdTypedDataTable<EO_MenuFunRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public EO_MenuFunDataTable() : base("EO_MenuFun")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new EO_MenuFunDataTable();
            return getTableSchema(xs, dt, "EOMF");
        }

        [DebuggerNonUserCodeAttribute()]
        protected EO_MenuFunDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// [DIRECT]*EOMF_MenupermfunId{Id}：【PK】
        /// </summary> 
        public DataColumn EOMF_MenuFunIdColumn;

        /// <summary>
        /// [DIRECT]*功能代號{20}
        /// </summary> 
        public DataColumn EOMF_FunctionCodeColumn;

        /// <summary>
        /// [DIRECT]功能說明{50}
        /// </summary> 
        public DataColumn EOMF_FunctionDescColumn;

        /// <summary>
        /// [DIRECT]功能名稱{50}
        /// </summary> 
        public DataColumn EOMF_FunctionNameColumn;

        /// <summary>
        /// [DIRECT]程式代號{20}
        /// </summary> 
        public DataColumn EOMF_ItemNoColumn;

        /// <summary>
        /// [DIRECT]排序{INT}
        /// </summary> 
        public DataColumn EOMF_SeqNoColumn;

        /// <summary>
        /// [DIRECT]工具列層級{1}【F：表單 / T：資料表 / R：資料列】
        /// </summary> 
        public DataColumn EOMF_ToolbarLevelColumn;

        /// <summary>
        /// [DIRECT]工具列層級說明{1}【F：表單 / T：資料表 / R：資料列】
        /// </summary> 
        public DataColumn EOMF_ToolbarLevelName_XXColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public EO_MenuFunRow findByPrimaryKey(String EOMF_MenuFunId)
        {
            return (EO_MenuFunRow)(Rows.Find(new object[] { EOMF_MenuFunId }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new EO_MenuFunDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            EOMF_MenuFunIdColumn = Columns["EOMF_MenuFunId"];
            EOMF_FunctionCodeColumn = Columns["EOMF_FunctionCode"];
            EOMF_FunctionDescColumn = Columns["EOMF_FunctionDesc"];
            EOMF_FunctionNameColumn = Columns["EOMF_FunctionName"];
            EOMF_ItemNoColumn = Columns["EOMF_ItemNo"];
            EOMF_SeqNoColumn = Columns["EOMF_SeqNo"];
            EOMF_ToolbarLevelColumn = Columns["EOMF_ToolbarLevel"];
            EOMF_ToolbarLevelName_XXColumn = Columns["EOMF_ToolbarLevelName_XX"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            EOMF_MenuFunIdColumn = new DataColumn("EOMF_MenuFunId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMF_MenuFunIdColumn);
            EOMF_MenuFunIdColumn.AllowDBNull = false;

            EOMF_FunctionCodeColumn = new DataColumn("EOMF_FunctionCode", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMF_FunctionCodeColumn);

            EOMF_FunctionDescColumn = new DataColumn("EOMF_FunctionDesc", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMF_FunctionDescColumn);

            EOMF_FunctionNameColumn = new DataColumn("EOMF_FunctionName", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMF_FunctionNameColumn);

            EOMF_ItemNoColumn = new DataColumn("EOMF_ItemNo", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMF_ItemNoColumn);

            EOMF_SeqNoColumn = new DataColumn("EOMF_SeqNo", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(EOMF_SeqNoColumn);

            EOMF_ToolbarLevelColumn = new DataColumn("EOMF_ToolbarLevel", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMF_ToolbarLevelColumn);
            EOMF_ToolbarLevelColumn.DefaultValue = "F";

            EOMF_ToolbarLevelName_XXColumn = new DataColumn("EOMF_ToolbarLevelName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMF_ToolbarLevelName_XXColumn);
            EOMF_ToolbarLevelName_XXColumn.DefaultValue = "F";

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { EOMF_MenuFunIdColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new EO_MenuFunRow(builder);
        }

    }

    ///<summary>
    ///{T}程式功能清單{EO_MenuFun}  
    ///</summary>
    public class EO_MenuFunRow : FtdDataRow
    {
        private EO_MenuFunDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal EO_MenuFunRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((EO_MenuFunDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public EO_MenuFunDataTable TypeTable
        {
            get { return (EO_MenuFunDataTable)Table; }
        }

        ///<summary>
        ///[DIRECT]*EOMF_MenupermfunId{Id}：【PK】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMF_MenuFunId
        {
            get { return getAttrGetString(this[theTable.EOMF_MenuFunIdColumn]); }
            set { this[theTable.EOMF_MenuFunIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*功能代號{20}  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMF_FunctionCode
        {
            get { return getAttrGetString(this[theTable.EOMF_FunctionCodeColumn]); }
            set { this[theTable.EOMF_FunctionCodeColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]功能說明{50}  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMF_FunctionDesc
        {
            get { return getAttrGetString(this[theTable.EOMF_FunctionDescColumn]); }
            set { this[theTable.EOMF_FunctionDescColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]功能名稱{50}  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMF_FunctionName
        {
            get { return getAttrGetString(this[theTable.EOMF_FunctionNameColumn]); }
            set { this[theTable.EOMF_FunctionNameColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]程式代號{20}  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMF_ItemNo
        {
            get { return getAttrGetString(this[theTable.EOMF_ItemNoColumn]); }
            set { this[theTable.EOMF_ItemNoColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]排序{INT}  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? EOMF_SeqNo
        {
            get { return getAttrGetValue<Int32>(this[theTable.EOMF_SeqNoColumn]); }
            set { this[this.theTable.EOMF_SeqNoColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///[DIRECT]工具列層級{1}【F：表單 / T：資料表 / R：資料列】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMF_ToolbarLevel
        {
            get { return getAttrGetString(this[theTable.EOMF_ToolbarLevelColumn]); }
            set { this[theTable.EOMF_ToolbarLevelColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]工具列層級說明{1}【F：表單 / T：資料表 / R：資料列】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMF_ToolbarLevelName_XX
        {
            get { return getAttrGetString(this[theTable.EOMF_ToolbarLevelName_XXColumn]); }
            set { this[theTable.EOMF_ToolbarLevelName_XXColumn] = getAttrSetString(value); }
        }

    }
}
