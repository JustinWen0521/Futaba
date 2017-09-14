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
    /// &lt;AST&gt;測試 {TMP1}
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class AS_Tmp1DataTable : FtdTypedDataTable<AS_Tmp1Row>
    {
        [DebuggerNonUserCodeAttribute()]
        public AS_Tmp1DataTable() : base("AS_Tmp1")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new AS_Tmp1DataTable();
            return getTableSchema(xs, dt, "AST");
        }

        [DebuggerNonUserCodeAttribute()]
        protected AS_Tmp1DataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// [DIRECT]*TITM {DTN_NID}：【PK&lt;AST&gt;】
        /// </summary> 
        public DataColumn AST_TITMColumn;

        /// <summary>
        /// [DIRECT]* {DTN_NVARCHAR10}：【100】
        /// </summary> 
        public DataColumn AST_TQTYColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public AS_Tmp1Row findByPrimaryKey(String AST_TITM)
        {
            return (AS_Tmp1Row)(Rows.Find(new object[] { AST_TITM }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new AS_Tmp1DataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            AST_TITMColumn = Columns["AST_TITM"];
            AST_TQTYColumn = Columns["AST_TQTY"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            AST_TITMColumn = new DataColumn("AST_TITM", typeof(String), null, MappingType.Attribute);
            Columns.Add(AST_TITMColumn);
            AST_TITMColumn.AllowDBNull = false;

            AST_TQTYColumn = new DataColumn("AST_TQTY", typeof(String), null, MappingType.Attribute);
            Columns.Add(AST_TQTYColumn);

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { AST_TITMColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new AS_Tmp1Row(builder);
        }

    }

    ///<summary>
    ///&lt;AST&gt;測試 {TMP1}  
    ///</summary>
    public class AS_Tmp1Row : FtdDataRow
    {
        private AS_Tmp1DataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal AS_Tmp1Row(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((AS_Tmp1DataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public AS_Tmp1DataTable TypeTable
        {
            get { return (AS_Tmp1DataTable)Table; }
        }

        ///<summary>
        ///[DIRECT]*TITM {DTN_NID}：【PK&lt;AST&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string AST_TITM
        {
            get { return getAttrGetString(this[theTable.AST_TITMColumn]); }
            set { this[theTable.AST_TITMColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]* {DTN_NVARCHAR10}：【100】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string AST_TQTY
        {
            get { return getAttrGetString(this[theTable.AST_TQTYColumn]); }
            set { this[theTable.AST_TQTYColumn] = getAttrSetString(value); }
        }

    }
}
