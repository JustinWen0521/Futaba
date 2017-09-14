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
    /// &lt;WTSD&gt;排程日期{ScheduleDate}
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class WT_ScheduleDateDataTable : FtdTypedDataTable<WT_ScheduleDateRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public WT_ScheduleDateDataTable() : base("WT_ScheduleDate")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new WT_ScheduleDateDataTable();
            return getTableSchema(xs, dt, "WTSD");
        }

        [DebuggerNonUserCodeAttribute()]
        protected WT_ScheduleDateDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// [DIRECT]*排程日期ID{ScheduleDateId}：【PK&lt;WTSD&gt;】
        /// </summary> 
        public DataColumn WTSD_ScheduleDateIdColumn;

        /// <summary>
        /// [DIRECT]*日期描述{Description:50}：【每天06:30分執行】
        /// </summary> 
        public DataColumn WTSD_DescriptionColumn;

        /// <summary>
        /// [DIRECT]*每天-小時{INT}：【0~24】
        /// </summary> 
        public DataColumn WTSD_EveryDayHourColumn;

        /// <summary>
        /// [DIRECT]*每天-分鐘{INT}：【0~59】
        /// </summary> 
        public DataColumn WTSD_EveryDayMiniuteColumn;

        /// <summary>
        /// [DIRECT]*是否啟用{IsEnable:1,IsEnableName_XX}：Y：啟用 N：不啟用
        /// </summary> 
        public DataColumn WTSD_IsEnableColumn;

        /// <summary>
        /// [DIRECT]*是否啟用{IsEnable:1,IsEnableName_XX}：Y：啟用 N：不啟用
        /// </summary> 
        public DataColumn WTSD_IsEnableName_XXColumn;

        /// <summary>
        /// [DIRECT]超過排程日期{getCurrentScheduleTime()}多少分鐘，仍視為到期的。
        /// </summary> 
        public DataColumn WTSD_MoreMinuteColumn;

        /// <summary>
        /// [DIRECT]*物件參數{Parameters:4000}：【0ZW0sIFZlcnNpb249Mi4wLjAuMCwgQ3V==】
        /// </summary> 
        public DataColumn WTSD_ParametersColumn;

        /// <summary>
        /// [DIRECT]*週期類型{1}：【A：每天 / B：每小時】
        /// </summary> 
        public DataColumn WTSD_PeriodTypeColumn;

        /// <summary>
        /// [DIRECT]*排程工作ID{ScheduleTaskId}：【KEY&lt;WTST&gt;】
        /// </summary> 
        public DataColumn WTSD_ScheduleTaskIdColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public WT_ScheduleDateRow findByPrimaryKey(String WTSD_ScheduleDateId)
        {
            return (WT_ScheduleDateRow)(Rows.Find(new object[] { WTSD_ScheduleDateId }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new WT_ScheduleDateDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            WTSD_ScheduleDateIdColumn = Columns["WTSD_ScheduleDateId"];
            WTSD_DescriptionColumn = Columns["WTSD_Description"];
            WTSD_EveryDayHourColumn = Columns["WTSD_EveryDayHour"];
            WTSD_EveryDayMiniuteColumn = Columns["WTSD_EveryDayMiniute"];
            WTSD_IsEnableColumn = Columns["WTSD_IsEnable"];
            WTSD_IsEnableName_XXColumn = Columns["WTSD_IsEnableName_XX"];
            WTSD_MoreMinuteColumn = Columns["WTSD_MoreMinute"];
            WTSD_ParametersColumn = Columns["WTSD_Parameters"];
            WTSD_PeriodTypeColumn = Columns["WTSD_PeriodType"];
            WTSD_ScheduleTaskIdColumn = Columns["WTSD_ScheduleTaskId"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            WTSD_ScheduleDateIdColumn = new DataColumn("WTSD_ScheduleDateId", typeof(String), null, MappingType.Attribute);
            Columns.Add(WTSD_ScheduleDateIdColumn);
            WTSD_ScheduleDateIdColumn.AllowDBNull = false;

            WTSD_DescriptionColumn = new DataColumn("WTSD_Description", typeof(String), null, MappingType.Attribute);
            Columns.Add(WTSD_DescriptionColumn);

            WTSD_EveryDayHourColumn = new DataColumn("WTSD_EveryDayHour", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(WTSD_EveryDayHourColumn);

            WTSD_EveryDayMiniuteColumn = new DataColumn("WTSD_EveryDayMiniute", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(WTSD_EveryDayMiniuteColumn);

            WTSD_IsEnableColumn = new DataColumn("WTSD_IsEnable", typeof(String), null, MappingType.Attribute);
            Columns.Add(WTSD_IsEnableColumn);

            WTSD_IsEnableName_XXColumn = new DataColumn("WTSD_IsEnableName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(WTSD_IsEnableName_XXColumn);

            WTSD_MoreMinuteColumn = new DataColumn("WTSD_MoreMinute", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(WTSD_MoreMinuteColumn);
            WTSD_MoreMinuteColumn.DefaultValue = "5";

            WTSD_ParametersColumn = new DataColumn("WTSD_Parameters", typeof(String), null, MappingType.Attribute);
            Columns.Add(WTSD_ParametersColumn);

            WTSD_PeriodTypeColumn = new DataColumn("WTSD_PeriodType", typeof(String), null, MappingType.Attribute);
            Columns.Add(WTSD_PeriodTypeColumn);

            WTSD_ScheduleTaskIdColumn = new DataColumn("WTSD_ScheduleTaskId", typeof(String), null, MappingType.Attribute);
            Columns.Add(WTSD_ScheduleTaskIdColumn);

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { WTSD_ScheduleDateIdColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new WT_ScheduleDateRow(builder);
        }

    }

    ///<summary>
    ///&lt;WTSD&gt;排程日期{ScheduleDate}  
    ///</summary>
    public class WT_ScheduleDateRow : FtdDataRow
    {
        private WT_ScheduleDateDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal WT_ScheduleDateRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((WT_ScheduleDateDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public WT_ScheduleDateDataTable TypeTable
        {
            get { return (WT_ScheduleDateDataTable)Table; }
        }

        ///<summary>
        ///[DIRECT]*排程日期ID{ScheduleDateId}：【PK&lt;WTSD&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string WTSD_ScheduleDateId
        {
            get { return getAttrGetString(this[theTable.WTSD_ScheduleDateIdColumn]); }
            set { this[theTable.WTSD_ScheduleDateIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*日期描述{Description:50}：【每天06:30分執行】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string WTSD_Description
        {
            get { return getAttrGetString(this[theTable.WTSD_DescriptionColumn]); }
            set { this[theTable.WTSD_DescriptionColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*每天-小時{INT}：【0~24】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? WTSD_EveryDayHour
        {
            get { return getAttrGetValue<Int32>(this[theTable.WTSD_EveryDayHourColumn]); }
            set { this[this.theTable.WTSD_EveryDayHourColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///[DIRECT]*每天-分鐘{INT}：【0~59】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? WTSD_EveryDayMiniute
        {
            get { return getAttrGetValue<Int32>(this[theTable.WTSD_EveryDayMiniuteColumn]); }
            set { this[this.theTable.WTSD_EveryDayMiniuteColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///[DIRECT]*是否啟用{IsEnable:1,IsEnableName_XX}：Y：啟用 N：不啟用  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string WTSD_IsEnable
        {
            get { return getAttrGetString(this[theTable.WTSD_IsEnableColumn]); }
            set { this[theTable.WTSD_IsEnableColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*是否啟用{IsEnable:1,IsEnableName_XX}：Y：啟用 N：不啟用  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string WTSD_IsEnableName_XX
        {
            get { return getAttrGetString(this[theTable.WTSD_IsEnableName_XXColumn]); }
            set { this[theTable.WTSD_IsEnableName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]超過排程日期{getCurrentScheduleTime()}多少分鐘，仍視為到期的。  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? WTSD_MoreMinute
        {
            get { return getAttrGetValue<Int32>(this[theTable.WTSD_MoreMinuteColumn]); }
            set { this[this.theTable.WTSD_MoreMinuteColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///[DIRECT]*物件參數{Parameters:4000}：【0ZW0sIFZlcnNpb249Mi4wLjAuMCwgQ3V==】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string WTSD_Parameters
        {
            get { return getAttrGetString(this[theTable.WTSD_ParametersColumn]); }
            set { this[theTable.WTSD_ParametersColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*週期類型{1}：【A：每天 / B：每小時】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string WTSD_PeriodType
        {
            get { return getAttrGetString(this[theTable.WTSD_PeriodTypeColumn]); }
            set { this[theTable.WTSD_PeriodTypeColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*排程工作ID{ScheduleTaskId}：【KEY&lt;WTST&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string WTSD_ScheduleTaskId
        {
            get { return getAttrGetString(this[theTable.WTSD_ScheduleTaskIdColumn]); }
            set { this[theTable.WTSD_ScheduleTaskIdColumn] = getAttrSetString(value); }
        }

    }
}
