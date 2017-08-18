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
    /// {T}組立機臺主檔Log {AL_AssmblingLog}
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class AL_AssmblingLogDataTable : FtdTypedDataTable<AL_AssmblingLogRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public AL_AssmblingLogDataTable() : base("AL_AssmblingLog")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new AL_AssmblingLogDataTable();
            return getTableSchema(xs, dt, "ALAL");
        }

        [DebuggerNonUserCodeAttribute()]
        protected AL_AssmblingLogDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// *組立機臺主檔LogID {DTN_NID}：【】
        /// </summary> 
        public DataColumn ALAL_AssmblingLogIdColumn;

        /// <summary>
        /// *建立日期 {DTN_DATETIME_19}：【】
        /// </summary> 
        public DataColumn ALAL_CreateDateColumn;

        /// <summary>
        /// *建立者ID {DTN_NID}：【】
        /// </summary> 
        public DataColumn ALAL_CreatorIdColumn;

        /// <summary>
        /// *人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        public DataColumn ALAL_CreatorName_XXColumn;

        /// <summary>
        /// *有效日期 {DTN_DATETIME_19}：【】
        /// </summary> 
        public DataColumn ALAL_EffectDateColumn;

        /// <summary>
        /// *失效日期 {DTN_DATETIME_19}：【】
        /// </summary> 
        public DataColumn ALAL_InvalidDateColumn;

        /// <summary>
        /// *機臺編碼 {DTN_NVARCHAR10}：【】
        /// </summary> 
        public DataColumn ALAL_MCIDColumn;

        /// <summary>
        /// *行位置 {DTN_INTEGER}：【】
        /// </summary> 
        public DataColumn ALAL_SEQColColumn;

        /// <summary>
        /// *列位置 {DTN_INTEGER}：【】
        /// </summary> 
        public DataColumn ALAL_SEQRowColumn;

        /// <summary>
        /// *異動日期 {DTN_DATETIME_19}：【】
        /// </summary> 
        public DataColumn ALAL_UpdateDateColumn;

        /// <summary>
        /// *異動者ID {DTN_NVARCHAR1}：【】
        /// </summary> 
        public DataColumn ALAL_UpdaterIdColumn;

        /// <summary>
        /// *人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        public DataColumn ALAL_UpdaterName_XXColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public AL_AssmblingLogRow findByPrimaryKey(String ALAL_AssmblingLogId)
        {
            return (AL_AssmblingLogRow)(Rows.Find(new object[] { ALAL_AssmblingLogId }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new AL_AssmblingLogDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            ALAL_AssmblingLogIdColumn = Columns["ALAL_AssmblingLogId"];
            ALAL_CreateDateColumn = Columns["ALAL_CreateDate"];
            ALAL_CreatorIdColumn = Columns["ALAL_CreatorId"];
            ALAL_CreatorName_XXColumn = Columns["ALAL_CreatorName_XX"];
            ALAL_EffectDateColumn = Columns["ALAL_EffectDate"];
            ALAL_InvalidDateColumn = Columns["ALAL_InvalidDate"];
            ALAL_MCIDColumn = Columns["ALAL_MCID"];
            ALAL_SEQColColumn = Columns["ALAL_SEQCol"];
            ALAL_SEQRowColumn = Columns["ALAL_SEQRow"];
            ALAL_UpdateDateColumn = Columns["ALAL_UpdateDate"];
            ALAL_UpdaterIdColumn = Columns["ALAL_UpdaterId"];
            ALAL_UpdaterName_XXColumn = Columns["ALAL_UpdaterName_XX"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            ALAL_AssmblingLogIdColumn = new DataColumn("ALAL_AssmblingLogId", typeof(String), null, MappingType.Attribute);
            Columns.Add(ALAL_AssmblingLogIdColumn);
            ALAL_AssmblingLogIdColumn.AllowDBNull = false;

            ALAL_CreateDateColumn = new DataColumn("ALAL_CreateDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(ALAL_CreateDateColumn);

            ALAL_CreatorIdColumn = new DataColumn("ALAL_CreatorId", typeof(String), null, MappingType.Attribute);
            Columns.Add(ALAL_CreatorIdColumn);

            ALAL_CreatorName_XXColumn = new DataColumn("ALAL_CreatorName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(ALAL_CreatorName_XXColumn);

            ALAL_EffectDateColumn = new DataColumn("ALAL_EffectDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(ALAL_EffectDateColumn);

            ALAL_InvalidDateColumn = new DataColumn("ALAL_InvalidDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(ALAL_InvalidDateColumn);

            ALAL_MCIDColumn = new DataColumn("ALAL_MCID", typeof(String), null, MappingType.Attribute);
            Columns.Add(ALAL_MCIDColumn);

            ALAL_SEQColColumn = new DataColumn("ALAL_SEQCol", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(ALAL_SEQColColumn);

            ALAL_SEQRowColumn = new DataColumn("ALAL_SEQRow", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(ALAL_SEQRowColumn);

            ALAL_UpdateDateColumn = new DataColumn("ALAL_UpdateDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(ALAL_UpdateDateColumn);

            ALAL_UpdaterIdColumn = new DataColumn("ALAL_UpdaterId", typeof(String), null, MappingType.Attribute);
            Columns.Add(ALAL_UpdaterIdColumn);

            ALAL_UpdaterName_XXColumn = new DataColumn("ALAL_UpdaterName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(ALAL_UpdaterName_XXColumn);

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { ALAL_AssmblingLogIdColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new AL_AssmblingLogRow(builder);
        }

    }

    ///<summary>
    ///{T}組立機臺主檔Log {AL_AssmblingLog}  
    ///</summary>
    public class AL_AssmblingLogRow : FtdDataRow
    {
        private AL_AssmblingLogDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal AL_AssmblingLogRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((AL_AssmblingLogDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public AL_AssmblingLogDataTable TypeTable
        {
            get { return (AL_AssmblingLogDataTable)Table; }
        }

        ///<summary>
        ///*組立機臺主檔LogID {DTN_NID}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ALAL_AssmblingLogId
        {
            get { return getAttrGetString(this[theTable.ALAL_AssmblingLogIdColumn]); }
            set { this[theTable.ALAL_AssmblingLogIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///*建立日期 {DTN_DATETIME_19}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? ALAL_CreateDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.ALAL_CreateDateColumn]); }
            set { this[this.theTable.ALAL_CreateDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///*建立者ID {DTN_NID}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ALAL_CreatorId
        {
            get { return getAttrGetString(this[theTable.ALAL_CreatorIdColumn]); }
            set { this[theTable.ALAL_CreatorIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ALAL_CreatorName_XX
        {
            get { return getAttrGetString(this[theTable.ALAL_CreatorName_XXColumn]); }
            set { this[theTable.ALAL_CreatorName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///*有效日期 {DTN_DATETIME_19}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? ALAL_EffectDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.ALAL_EffectDateColumn]); }
            set { this[this.theTable.ALAL_EffectDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///*失效日期 {DTN_DATETIME_19}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? ALAL_InvalidDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.ALAL_InvalidDateColumn]); }
            set { this[this.theTable.ALAL_InvalidDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///*機臺編碼 {DTN_NVARCHAR10}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ALAL_MCID
        {
            get { return getAttrGetString(this[theTable.ALAL_MCIDColumn]); }
            set { this[theTable.ALAL_MCIDColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///*行位置 {DTN_INTEGER}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? ALAL_SEQCol
        {
            get { return getAttrGetValue<Int32>(this[theTable.ALAL_SEQColColumn]); }
            set { this[this.theTable.ALAL_SEQColColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///*列位置 {DTN_INTEGER}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? ALAL_SEQRow
        {
            get { return getAttrGetValue<Int32>(this[theTable.ALAL_SEQRowColumn]); }
            set { this[this.theTable.ALAL_SEQRowColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///*異動日期 {DTN_DATETIME_19}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? ALAL_UpdateDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.ALAL_UpdateDateColumn]); }
            set { this[this.theTable.ALAL_UpdateDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///*異動者ID {DTN_NVARCHAR1}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ALAL_UpdaterId
        {
            get { return getAttrGetString(this[theTable.ALAL_UpdaterIdColumn]); }
            set { this[theTable.ALAL_UpdaterIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ALAL_UpdaterName_XX
        {
            get { return getAttrGetString(this[theTable.ALAL_UpdaterName_XXColumn]); }
            set { this[theTable.ALAL_UpdaterName_XXColumn] = getAttrSetString(value); }
        }

    }
}
