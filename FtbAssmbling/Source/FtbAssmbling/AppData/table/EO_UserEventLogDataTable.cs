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
    /// 
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class EO_UserEventLogDataTable : FtdTypedDataTable<EO_UserEventLogRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public EO_UserEventLogDataTable() : base("EO_UserEventLog")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new EO_UserEventLogDataTable();
            return getTableSchema(xs, dt, "EOUEL");
        }

        [DebuggerNonUserCodeAttribute()]
        protected EO_UserEventLogDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// [DIRECT]*事件檔紀錄ID{UserEventLogId}：【PK&lt;EPUEL&gt;】
        /// </summary> 
        public DataColumn EOUEL_UserEventLogIdColumn;

        /// <summary>
        /// [DIRECT]*事件日期{EventDate:D}：【2007/11/12 13:14】
        /// </summary> 
        public DataColumn EOUEL_EventDateColumn;

        /// <summary>
        /// [DIRECT]查看的物件Id{ObjectId }：【KEY】
        /// </summary> 
        public DataColumn EOUEL_ObjectIdColumn;

        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;*工作名稱{TaskName:50}：【資料回收程式】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOUEL_ObjectName_XXColumn;

        /// <summary>
        /// [DIRECT]來源IP{SourceId }：【168.95.1.1】
        /// </summary> 
        public DataColumn EOUEL_SourceIPColumn;

        /// <summary>
        /// [DIRECT]*事件代碼{EventCode:50}：【KM_LOGIN】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOUEL_UserEventCode_XXColumn;

        /// <summary>
        /// [DIRECT]*事件Id{UserEventId}：【KEY&lt;EPUE&gt;】
        /// </summary> 
        public DataColumn EOUEL_UserEventIdColumn;

        /// <summary>
        /// [DIRECT]*事件類型{KindName:50}：【登入系統】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOUEL_UserEventName_XXColumn;

        /// <summary>
        /// [DIRECT]*人員{UserId}：【KEY&lt;EOE,ENM,KCG&gt;】
        /// </summary> 
        public DataColumn EOUEL_UserIdColumn;

        /// <summary>
        /// [DIRECT]#完整姓名{EmployeeFullName_XX}：【市政府-林勝文 組長】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOUEL_UserName_XXColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public EO_UserEventLogRow findByPrimaryKey(String EOUEL_UserEventLogId)
        {
            return (EO_UserEventLogRow)(Rows.Find(new object[] { EOUEL_UserEventLogId }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new EO_UserEventLogDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            EOUEL_UserEventLogIdColumn = Columns["EOUEL_UserEventLogId"];
            EOUEL_EventDateColumn = Columns["EOUEL_EventDate"];
            EOUEL_ObjectIdColumn = Columns["EOUEL_ObjectId"];
            EOUEL_ObjectName_XXColumn = Columns["EOUEL_ObjectName_XX"];
            EOUEL_SourceIPColumn = Columns["EOUEL_SourceIP"];
            EOUEL_UserEventCode_XXColumn = Columns["EOUEL_UserEventCode_XX"];
            EOUEL_UserEventIdColumn = Columns["EOUEL_UserEventId"];
            EOUEL_UserEventName_XXColumn = Columns["EOUEL_UserEventName_XX"];
            EOUEL_UserIdColumn = Columns["EOUEL_UserId"];
            EOUEL_UserName_XXColumn = Columns["EOUEL_UserName_XX"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            EOUEL_UserEventLogIdColumn = new DataColumn("EOUEL_UserEventLogId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOUEL_UserEventLogIdColumn);
            EOUEL_UserEventLogIdColumn.AllowDBNull = false;

            EOUEL_EventDateColumn = new DataColumn("EOUEL_EventDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(EOUEL_EventDateColumn);

            EOUEL_ObjectIdColumn = new DataColumn("EOUEL_ObjectId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOUEL_ObjectIdColumn);

            EOUEL_ObjectName_XXColumn = new DataColumn("EOUEL_ObjectName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOUEL_ObjectName_XXColumn);

            EOUEL_SourceIPColumn = new DataColumn("EOUEL_SourceIP", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOUEL_SourceIPColumn);

            EOUEL_UserEventCode_XXColumn = new DataColumn("EOUEL_UserEventCode_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOUEL_UserEventCode_XXColumn);

            EOUEL_UserEventIdColumn = new DataColumn("EOUEL_UserEventId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOUEL_UserEventIdColumn);

            EOUEL_UserEventName_XXColumn = new DataColumn("EOUEL_UserEventName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOUEL_UserEventName_XXColumn);

            EOUEL_UserIdColumn = new DataColumn("EOUEL_UserId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOUEL_UserIdColumn);

            EOUEL_UserName_XXColumn = new DataColumn("EOUEL_UserName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOUEL_UserName_XXColumn);

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { EOUEL_UserEventLogIdColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new EO_UserEventLogRow(builder);
        }

    }

    ///<summary>
    ///  
    ///</summary>
    public class EO_UserEventLogRow : FtdDataRow
    {
        private EO_UserEventLogDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal EO_UserEventLogRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((EO_UserEventLogDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public EO_UserEventLogDataTable TypeTable
        {
            get { return (EO_UserEventLogDataTable)Table; }
        }

        ///<summary>
        ///[DIRECT]*事件檔紀錄ID{UserEventLogId}：【PK&lt;EPUEL&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOUEL_UserEventLogId
        {
            get { return getAttrGetString(this[theTable.EOUEL_UserEventLogIdColumn]); }
            set { this[theTable.EOUEL_UserEventLogIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*事件日期{EventDate:D}：【2007/11/12 13:14】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? EOUEL_EventDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.EOUEL_EventDateColumn]); }
            set { this[this.theTable.EOUEL_EventDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///[DIRECT]查看的物件Id{ObjectId }：【KEY】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOUEL_ObjectId
        {
            get { return getAttrGetString(this[theTable.EOUEL_ObjectIdColumn]); }
            set { this[theTable.EOUEL_ObjectIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;*工作名稱{TaskName:50}：【資料回收程式】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOUEL_ObjectName_XX
        {
            get { return getAttrGetString(this[theTable.EOUEL_ObjectName_XXColumn]); }
            set { this[theTable.EOUEL_ObjectName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]來源IP{SourceId }：【168.95.1.1】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOUEL_SourceIP
        {
            get { return getAttrGetString(this[theTable.EOUEL_SourceIPColumn]); }
            set { this[theTable.EOUEL_SourceIPColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*事件代碼{EventCode:50}：【KM_LOGIN】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOUEL_UserEventCode_XX
        {
            get { return getAttrGetString(this[theTable.EOUEL_UserEventCode_XXColumn]); }
            set { this[theTable.EOUEL_UserEventCode_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*事件Id{UserEventId}：【KEY&lt;EPUE&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOUEL_UserEventId
        {
            get { return getAttrGetString(this[theTable.EOUEL_UserEventIdColumn]); }
            set { this[theTable.EOUEL_UserEventIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*事件類型{KindName:50}：【登入系統】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOUEL_UserEventName_XX
        {
            get { return getAttrGetString(this[theTable.EOUEL_UserEventName_XXColumn]); }
            set { this[theTable.EOUEL_UserEventName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*人員{UserId}：【KEY&lt;EOE,ENM,KCG&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOUEL_UserId
        {
            get { return getAttrGetString(this[theTable.EOUEL_UserIdColumn]); }
            set { this[theTable.EOUEL_UserIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]#完整姓名{EmployeeFullName_XX}：【市政府-林勝文 組長】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOUEL_UserName_XX
        {
            get { return getAttrGetString(this[theTable.EOUEL_UserName_XXColumn]); }
            set { this[theTable.EOUEL_UserName_XXColumn] = getAttrSetString(value); }
        }

    }
}
