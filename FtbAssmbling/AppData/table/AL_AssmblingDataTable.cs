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
    /// {T}組立機臺主檔 {AL_Assmbling}
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class AL_AssmblingDataTable : FtdTypedDataTable<AL_AssmblingRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public AL_AssmblingDataTable() : base("AL_Assmbling")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new AL_AssmblingDataTable();
            return getTableSchema(xs, dt, "ALA");
        }

        [DebuggerNonUserCodeAttribute()]
        protected AL_AssmblingDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// *後工程組立ID {DTN_NID}：【】
        /// </summary> 
        public DataColumn ALA_AssmblingIdColumn;

        /// <summary>
        /// *建立日期 {DTN_DATETIME_19}：【】
        /// </summary> 
        public DataColumn ALA_CreateDateColumn;

        /// <summary>
        /// *建立者ID {DTN_NID}：【】
        /// </summary> 
        public DataColumn ALA_CreatorIdColumn;

        /// <summary>
        /// *人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        public DataColumn ALA_CreatorName_XXColumn;

        /// <summary>
        /// *工程代碼 {DTN_NVARCHAR20}：【】
        /// </summary> 
        public DataColumn ALA_MCCodeColumn;

        /// <summary>
        /// *機臺編碼 {DTN_NVARCHAR10}：【】
        /// </summary> 
        public DataColumn ALA_MCIDColumn;

        /// <summary>
        /// *工程描述 {DTN_NVARCHAR50}：【】
        /// </summary> 
        public DataColumn ALA_MCNameColumn;

        /// <summary>
        /// *行位置 {DTN_INTEGER}：【】
        /// </summary> 
        public DataColumn ALA_SEQColColumn;

        /// <summary>
        /// *列位置 {DTN_INTEGER}：【】
        /// </summary> 
        public DataColumn ALA_SEQRowColumn;

        /// <summary>
        /// *異動日期 {DTN_DATETIME_19}：【】
        /// </summary> 
        public DataColumn ALA_UpdateDateColumn;

        /// <summary>
        /// *異動者ID {DTN_NVARCHAR1}：【】
        /// </summary> 
        public DataColumn ALA_UpdaterIdColumn;

        /// <summary>
        /// *人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        public DataColumn ALA_UpdaterName_XXColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public AL_AssmblingRow findByPrimaryKey(String ALA_AssmblingId)
        {
            return (AL_AssmblingRow)(Rows.Find(new object[] { ALA_AssmblingId }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new AL_AssmblingDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            ALA_AssmblingIdColumn = Columns["ALA_AssmblingId"];
            ALA_CreateDateColumn = Columns["ALA_CreateDate"];
            ALA_CreatorIdColumn = Columns["ALA_CreatorId"];
            ALA_CreatorName_XXColumn = Columns["ALA_CreatorName_XX"];
            ALA_MCCodeColumn = Columns["ALA_MCCode"];
            ALA_MCIDColumn = Columns["ALA_MCID"];
            ALA_MCNameColumn = Columns["ALA_MCName"];
            ALA_SEQColColumn = Columns["ALA_SEQCol"];
            ALA_SEQRowColumn = Columns["ALA_SEQRow"];
            ALA_UpdateDateColumn = Columns["ALA_UpdateDate"];
            ALA_UpdaterIdColumn = Columns["ALA_UpdaterId"];
            ALA_UpdaterName_XXColumn = Columns["ALA_UpdaterName_XX"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            ALA_AssmblingIdColumn = new DataColumn("ALA_AssmblingId", typeof(String), null, MappingType.Attribute);
            Columns.Add(ALA_AssmblingIdColumn);
            ALA_AssmblingIdColumn.AllowDBNull = false;

            ALA_CreateDateColumn = new DataColumn("ALA_CreateDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(ALA_CreateDateColumn);

            ALA_CreatorIdColumn = new DataColumn("ALA_CreatorId", typeof(String), null, MappingType.Attribute);
            Columns.Add(ALA_CreatorIdColumn);

            ALA_CreatorName_XXColumn = new DataColumn("ALA_CreatorName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(ALA_CreatorName_XXColumn);

            ALA_MCCodeColumn = new DataColumn("ALA_MCCode", typeof(String), null, MappingType.Attribute);
            Columns.Add(ALA_MCCodeColumn);

            ALA_MCIDColumn = new DataColumn("ALA_MCID", typeof(String), null, MappingType.Attribute);
            Columns.Add(ALA_MCIDColumn);

            ALA_MCNameColumn = new DataColumn("ALA_MCName", typeof(String), null, MappingType.Attribute);
            Columns.Add(ALA_MCNameColumn);

            ALA_SEQColColumn = new DataColumn("ALA_SEQCol", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(ALA_SEQColColumn);

            ALA_SEQRowColumn = new DataColumn("ALA_SEQRow", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(ALA_SEQRowColumn);

            ALA_UpdateDateColumn = new DataColumn("ALA_UpdateDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(ALA_UpdateDateColumn);

            ALA_UpdaterIdColumn = new DataColumn("ALA_UpdaterId", typeof(String), null, MappingType.Attribute);
            Columns.Add(ALA_UpdaterIdColumn);

            ALA_UpdaterName_XXColumn = new DataColumn("ALA_UpdaterName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(ALA_UpdaterName_XXColumn);

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { ALA_AssmblingIdColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new AL_AssmblingRow(builder);
        }

    }

    ///<summary>
    ///{T}組立機臺主檔 {AL_Assmbling}  
    ///</summary>
    public class AL_AssmblingRow : FtdDataRow
    {
        private AL_AssmblingDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal AL_AssmblingRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((AL_AssmblingDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public AL_AssmblingDataTable TypeTable
        {
            get { return (AL_AssmblingDataTable)Table; }
        }

        ///<summary>
        ///*後工程組立ID {DTN_NID}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ALA_AssmblingId
        {
            get { return getAttrGetString(this[theTable.ALA_AssmblingIdColumn]); }
            set { this[theTable.ALA_AssmblingIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///*建立日期 {DTN_DATETIME_19}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? ALA_CreateDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.ALA_CreateDateColumn]); }
            set { this[this.theTable.ALA_CreateDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///*建立者ID {DTN_NID}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ALA_CreatorId
        {
            get { return getAttrGetString(this[theTable.ALA_CreatorIdColumn]); }
            set { this[theTable.ALA_CreatorIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ALA_CreatorName_XX
        {
            get { return getAttrGetString(this[theTable.ALA_CreatorName_XXColumn]); }
            set { this[theTable.ALA_CreatorName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///*工程代碼 {DTN_NVARCHAR20}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ALA_MCCode
        {
            get { return getAttrGetString(this[theTable.ALA_MCCodeColumn]); }
            set { this[theTable.ALA_MCCodeColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///*機臺編碼 {DTN_NVARCHAR10}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ALA_MCID
        {
            get { return getAttrGetString(this[theTable.ALA_MCIDColumn]); }
            set { this[theTable.ALA_MCIDColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///*工程描述 {DTN_NVARCHAR50}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ALA_MCName
        {
            get { return getAttrGetString(this[theTable.ALA_MCNameColumn]); }
            set { this[theTable.ALA_MCNameColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///*行位置 {DTN_INTEGER}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? ALA_SEQCol
        {
            get { return getAttrGetValue<Int32>(this[theTable.ALA_SEQColColumn]); }
            set { this[this.theTable.ALA_SEQColColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///*列位置 {DTN_INTEGER}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? ALA_SEQRow
        {
            get { return getAttrGetValue<Int32>(this[theTable.ALA_SEQRowColumn]); }
            set { this[this.theTable.ALA_SEQRowColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///*異動日期 {DTN_DATETIME_19}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? ALA_UpdateDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.ALA_UpdateDateColumn]); }
            set { this[this.theTable.ALA_UpdateDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///*異動者ID {DTN_NVARCHAR1}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ALA_UpdaterId
        {
            get { return getAttrGetString(this[theTable.ALA_UpdaterIdColumn]); }
            set { this[theTable.ALA_UpdaterIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ALA_UpdaterName_XX
        {
            get { return getAttrGetString(this[theTable.ALA_UpdaterName_XXColumn]); }
            set { this[theTable.ALA_UpdaterName_XXColumn] = getAttrSetString(value); }
        }

    }
}
