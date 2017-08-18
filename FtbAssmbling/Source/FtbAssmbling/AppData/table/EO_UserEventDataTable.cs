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
    /// &lt;EOUE&gt;網站使用者事件主檔{UserEvent}
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class EO_UserEventDataTable : FtdTypedDataTable<EO_UserEventRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public EO_UserEventDataTable() : base("EO_UserEvent")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new EO_UserEventDataTable();
            return getTableSchema(xs, dt, "EOUE");
        }

        [DebuggerNonUserCodeAttribute()]
        protected EO_UserEventDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// [DIRECT]*事件ID{UserEventLogId}：【PK&lt;EPUE&gt;】
        /// </summary> 
        public DataColumn EOUE_UserEventIdColumn;

        /// <summary>
        /// [DIRECT]*事件描述{Description:100}：【使用者登入系統】
        /// </summary> 
        public DataColumn EOUE_DescriptionColumn;

        /// <summary>
        /// [DIRECT]*事件代碼{EventCode:50}：【KM_LOGIN】
        /// </summary> 
        public DataColumn EOUE_EventCodeColumn;

        /// <summary>
        /// [DIRECT]*事件類型{KindName:50}：【登入系統】
        /// </summary> 
        public DataColumn EOUE_KindNameColumn;

        /// <summary>
        /// [DIRECT]*列表順序 {ListOrder:INT}：【1】
        /// </summary> 
        public DataColumn EOUE_ListOrderColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public EO_UserEventRow findByPrimaryKey(String EOUE_UserEventId)
        {
            return (EO_UserEventRow)(Rows.Find(new object[] { EOUE_UserEventId }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new EO_UserEventDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            EOUE_UserEventIdColumn = Columns["EOUE_UserEventId"];
            EOUE_DescriptionColumn = Columns["EOUE_Description"];
            EOUE_EventCodeColumn = Columns["EOUE_EventCode"];
            EOUE_KindNameColumn = Columns["EOUE_KindName"];
            EOUE_ListOrderColumn = Columns["EOUE_ListOrder"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            EOUE_UserEventIdColumn = new DataColumn("EOUE_UserEventId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOUE_UserEventIdColumn);
            EOUE_UserEventIdColumn.AllowDBNull = false;

            EOUE_DescriptionColumn = new DataColumn("EOUE_Description", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOUE_DescriptionColumn);

            EOUE_EventCodeColumn = new DataColumn("EOUE_EventCode", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOUE_EventCodeColumn);

            EOUE_KindNameColumn = new DataColumn("EOUE_KindName", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOUE_KindNameColumn);

            EOUE_ListOrderColumn = new DataColumn("EOUE_ListOrder", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(EOUE_ListOrderColumn);

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { EOUE_UserEventIdColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new EO_UserEventRow(builder);
        }

    }

    ///<summary>
    ///&lt;EOUE&gt;網站使用者事件主檔{UserEvent}  
    ///</summary>
    public class EO_UserEventRow : FtdDataRow
    {
        private EO_UserEventDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal EO_UserEventRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((EO_UserEventDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public EO_UserEventDataTable TypeTable
        {
            get { return (EO_UserEventDataTable)Table; }
        }

        ///<summary>
        ///[DIRECT]*事件ID{UserEventLogId}：【PK&lt;EPUE&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOUE_UserEventId
        {
            get { return getAttrGetString(this[theTable.EOUE_UserEventIdColumn]); }
            set { this[theTable.EOUE_UserEventIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*事件描述{Description:100}：【使用者登入系統】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOUE_Description
        {
            get { return getAttrGetString(this[theTable.EOUE_DescriptionColumn]); }
            set { this[theTable.EOUE_DescriptionColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*事件代碼{EventCode:50}：【KM_LOGIN】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOUE_EventCode
        {
            get { return getAttrGetString(this[theTable.EOUE_EventCodeColumn]); }
            set { this[theTable.EOUE_EventCodeColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*事件類型{KindName:50}：【登入系統】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOUE_KindName
        {
            get { return getAttrGetString(this[theTable.EOUE_KindNameColumn]); }
            set { this[theTable.EOUE_KindNameColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*列表順序 {ListOrder:INT}：【1】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? EOUE_ListOrder
        {
            get { return getAttrGetValue<Int32>(this[theTable.EOUE_ListOrderColumn]); }
            set { this[this.theTable.EOUE_ListOrderColumn] = getAttrSetValue<Int32>(value); }
        }

    }
}
