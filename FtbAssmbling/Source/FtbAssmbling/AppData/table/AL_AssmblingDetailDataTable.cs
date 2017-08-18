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
    /// {T}組立機臺明細 {AL_AssmblingDetail}
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class AL_AssmblingDetailDataTable : FtdTypedDataTable<AL_AssmblingDetailRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public AL_AssmblingDetailDataTable() : base("AL_AssmblingDetail")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new AL_AssmblingDetailDataTable();
            return getTableSchema(xs, dt, "ALAD");
        }

        [DebuggerNonUserCodeAttribute()]
        protected AL_AssmblingDetailDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// *生產階段日期 {DTN_DATETIME_19}：【】
        /// </summary> 
        public DataColumn ALAD_DATEColumn;

        /// <summary>
        /// *品名 {DTN_NVARCHAR20}：【】
        /// </summary> 
        public DataColumn ALAD_ITEMColumn;

        /// <summary>
        /// *機臺編碼 {DTN_NVARCHAR10}：【】
        /// </summary> 
        public DataColumn ALAD_MCIDColumn;

        /// <summary>
        /// *生產數量 {DTN_DECIMAL}：【】
        /// </summary> 
        public DataColumn ALAD_QTYColumn;

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new AL_AssmblingDetailDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            ALAD_DATEColumn = Columns["ALAD_DATE"];
            ALAD_ITEMColumn = Columns["ALAD_ITEM"];
            ALAD_MCIDColumn = Columns["ALAD_MCID"];
            ALAD_QTYColumn = Columns["ALAD_QTY"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            ALAD_DATEColumn = new DataColumn("ALAD_DATE", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(ALAD_DATEColumn);

            ALAD_ITEMColumn = new DataColumn("ALAD_ITEM", typeof(String), null, MappingType.Attribute);
            Columns.Add(ALAD_ITEMColumn);

            ALAD_MCIDColumn = new DataColumn("ALAD_MCID", typeof(String), null, MappingType.Attribute);
            Columns.Add(ALAD_MCIDColumn);

            ALAD_QTYColumn = new DataColumn("ALAD_QTY", typeof(Decimal), null, MappingType.Attribute);
            Columns.Add(ALAD_QTYColumn);

            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new AL_AssmblingDetailRow(builder);
        }

    }

    ///<summary>
    ///{T}組立機臺明細 {AL_AssmblingDetail}  
    ///</summary>
    public class AL_AssmblingDetailRow : FtdDataRow
    {
        private AL_AssmblingDetailDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal AL_AssmblingDetailRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((AL_AssmblingDetailDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public AL_AssmblingDetailDataTable TypeTable
        {
            get { return (AL_AssmblingDetailDataTable)Table; }
        }

        ///<summary>
        ///*生產階段日期 {DTN_DATETIME_19}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? ALAD_DATE
        {
            get { return getAttrGetValue<DateTime>(this[theTable.ALAD_DATEColumn]); }
            set { this[this.theTable.ALAD_DATEColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///*品名 {DTN_NVARCHAR20}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ALAD_ITEM
        {
            get { return getAttrGetString(this[theTable.ALAD_ITEMColumn]); }
            set { this[theTable.ALAD_ITEMColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///*機臺編碼 {DTN_NVARCHAR10}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ALAD_MCID
        {
            get { return getAttrGetString(this[theTable.ALAD_MCIDColumn]); }
            set { this[theTable.ALAD_MCIDColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///*生產數量 {DTN_DECIMAL}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Decimal? ALAD_QTY
        {
            get { return getAttrGetValue<Decimal>(this[theTable.ALAD_QTYColumn]); }
            set { this[this.theTable.ALAD_QTYColumn] = getAttrSetValue<Decimal>(value); }
        }

    }
}
