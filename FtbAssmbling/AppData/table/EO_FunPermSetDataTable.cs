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
    /// {T}&lt;EOFPS&gt;程式功能授權{FunPermSet}
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class EO_FunPermSetDataTable : FtdTypedDataTable<EO_FunPermSetRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public EO_FunPermSetDataTable() : base("EO_FunPermSet")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new EO_FunPermSetDataTable();
            return getTableSchema(xs, dt, "EOFPS");
        }

        [DebuggerNonUserCodeAttribute()]
        protected EO_FunPermSetDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// [DIRECT]*授權功能ID{FunPermSetId}：【PK&lt;EOFPS&gt;】
        /// </summary> 
        public DataColumn EOFPS_FunPermSetIdColumn;

        /// <summary>
        /// [DIRECT]*功能代號{20}&lt;br/&gt;
        /// </summary> 
        public DataColumn EOFPS_FunctionCode_XXColumn;

        /// <summary>
        /// [DIRECT]功能名稱{50}&lt;br/&gt;
        /// </summary> 
        public DataColumn EOFPS_FunctionName_XXColumn;

        /// <summary>
        /// [DIRECT]排序{INT}&lt;br/&gt;
        /// </summary> 
        public DataColumn EOFPS_FunctionSeqNo_XXColumn;

        /// <summary>
        /// [DIRECT]*授權功能ID{MenuFunId}：【FK&lt;EOMF&gt;】
        /// </summary> 
        public DataColumn EOFPS_MenuFunIdColumn;

        /// <summary>
        /// [DIRECT]*功能表ID{MenuId}：【FK&lt;EOM&gt;】&lt;br/&gt;&lt;br/&gt;
        /// </summary> 
        public DataColumn EOFPS_MenuId_XXColumn;

        /// <summary>
        /// [DIRECT]*功能項目No{MenuItemNo:50}：【Report.1】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOFPS_MenuItemNo_XXColumn;

        /// <summary>
        /// #功能項目No{MenuItemNoName_XX}：【個人紀錄報表】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOFPS_MenuItemNoName_XXColumn;

        /// <summary>
        /// [DIRECT]*授權程式ID{MenuPermSetId}：【FK&lt;EOMPS&gt;】
        /// </summary> 
        public DataColumn EOFPS_MenuPermSetIdColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public EO_FunPermSetRow findByPrimaryKey(String EOFPS_FunPermSetId)
        {
            return (EO_FunPermSetRow)(Rows.Find(new object[] { EOFPS_FunPermSetId }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new EO_FunPermSetDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            EOFPS_FunPermSetIdColumn = Columns["EOFPS_FunPermSetId"];
            EOFPS_FunctionCode_XXColumn = Columns["EOFPS_FunctionCode_XX"];
            EOFPS_FunctionName_XXColumn = Columns["EOFPS_FunctionName_XX"];
            EOFPS_FunctionSeqNo_XXColumn = Columns["EOFPS_FunctionSeqNo_XX"];
            EOFPS_MenuFunIdColumn = Columns["EOFPS_MenuFunId"];
            EOFPS_MenuId_XXColumn = Columns["EOFPS_MenuId_XX"];
            EOFPS_MenuItemNo_XXColumn = Columns["EOFPS_MenuItemNo_XX"];
            EOFPS_MenuItemNoName_XXColumn = Columns["EOFPS_MenuItemNoName_XX"];
            EOFPS_MenuPermSetIdColumn = Columns["EOFPS_MenuPermSetId"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            EOFPS_FunPermSetIdColumn = new DataColumn("EOFPS_FunPermSetId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOFPS_FunPermSetIdColumn);
            EOFPS_FunPermSetIdColumn.AllowDBNull = false;

            EOFPS_FunctionCode_XXColumn = new DataColumn("EOFPS_FunctionCode_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOFPS_FunctionCode_XXColumn);

            EOFPS_FunctionName_XXColumn = new DataColumn("EOFPS_FunctionName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOFPS_FunctionName_XXColumn);

            EOFPS_FunctionSeqNo_XXColumn = new DataColumn("EOFPS_FunctionSeqNo_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOFPS_FunctionSeqNo_XXColumn);

            EOFPS_MenuFunIdColumn = new DataColumn("EOFPS_MenuFunId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOFPS_MenuFunIdColumn);

            EOFPS_MenuId_XXColumn = new DataColumn("EOFPS_MenuId_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOFPS_MenuId_XXColumn);

            EOFPS_MenuItemNo_XXColumn = new DataColumn("EOFPS_MenuItemNo_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOFPS_MenuItemNo_XXColumn);

            EOFPS_MenuItemNoName_XXColumn = new DataColumn("EOFPS_MenuItemNoName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOFPS_MenuItemNoName_XXColumn);

            EOFPS_MenuPermSetIdColumn = new DataColumn("EOFPS_MenuPermSetId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOFPS_MenuPermSetIdColumn);

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { EOFPS_FunPermSetIdColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new EO_FunPermSetRow(builder);
        }

    }

    ///<summary>
    ///{T}&lt;EOFPS&gt;程式功能授權{FunPermSet}  
    ///</summary>
    public class EO_FunPermSetRow : FtdDataRow
    {
        private EO_FunPermSetDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal EO_FunPermSetRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((EO_FunPermSetDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public EO_FunPermSetDataTable TypeTable
        {
            get { return (EO_FunPermSetDataTable)Table; }
        }

        ///<summary>
        ///[DIRECT]*授權功能ID{FunPermSetId}：【PK&lt;EOFPS&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOFPS_FunPermSetId
        {
            get { return getAttrGetString(this[theTable.EOFPS_FunPermSetIdColumn]); }
            set { this[theTable.EOFPS_FunPermSetIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*功能代號{20}&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOFPS_FunctionCode_XX
        {
            get { return getAttrGetString(this[theTable.EOFPS_FunctionCode_XXColumn]); }
            set { this[theTable.EOFPS_FunctionCode_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]功能名稱{50}&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOFPS_FunctionName_XX
        {
            get { return getAttrGetString(this[theTable.EOFPS_FunctionName_XXColumn]); }
            set { this[theTable.EOFPS_FunctionName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]排序{INT}&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOFPS_FunctionSeqNo_XX
        {
            get { return getAttrGetString(this[theTable.EOFPS_FunctionSeqNo_XXColumn]); }
            set { this[theTable.EOFPS_FunctionSeqNo_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*授權功能ID{MenuFunId}：【FK&lt;EOMF&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOFPS_MenuFunId
        {
            get { return getAttrGetString(this[theTable.EOFPS_MenuFunIdColumn]); }
            set { this[theTable.EOFPS_MenuFunIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*功能表ID{MenuId}：【FK&lt;EOM&gt;】&lt;br/&gt;&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOFPS_MenuId_XX
        {
            get { return getAttrGetString(this[theTable.EOFPS_MenuId_XXColumn]); }
            set { this[theTable.EOFPS_MenuId_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*功能項目No{MenuItemNo:50}：【Report.1】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOFPS_MenuItemNo_XX
        {
            get { return getAttrGetString(this[theTable.EOFPS_MenuItemNo_XXColumn]); }
            set { this[theTable.EOFPS_MenuItemNo_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///#功能項目No{MenuItemNoName_XX}：【個人紀錄報表】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOFPS_MenuItemNoName_XX
        {
            get { return getAttrGetString(this[theTable.EOFPS_MenuItemNoName_XXColumn]); }
            set { this[theTable.EOFPS_MenuItemNoName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*授權程式ID{MenuPermSetId}：【FK&lt;EOMPS&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOFPS_MenuPermSetId
        {
            get { return getAttrGetString(this[theTable.EOFPS_MenuPermSetIdColumn]); }
            set { this[theTable.EOFPS_MenuPermSetIdColumn] = getAttrSetString(value); }
        }

    }
}
