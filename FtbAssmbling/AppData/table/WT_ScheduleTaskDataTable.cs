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
    /// &lt;WTST&gt;排程工作{ScheduleTask}
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class WT_ScheduleTaskDataTable : FtdTypedDataTable<WT_ScheduleTaskRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public WT_ScheduleTaskDataTable() : base("WT_ScheduleTask")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new WT_ScheduleTaskDataTable();
            return getTableSchema(xs, dt, "WTST");
        }

        [DebuggerNonUserCodeAttribute()]
        protected WT_ScheduleTaskDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// [DIRECT]*排程工作ID{ScheduleTaskId}：【PK&lt;WTST&gt;】
        /// </summary> 
        public DataColumn WTST_ScheduleTaskIdColumn;

        /// <summary>
        /// [DIRECT]*工作描述{Descripton:200}：【回收暫存檔案資料】
        /// </summary> 
        public DataColumn WTST_DescriptionColumn;

        /// <summary>
        /// [DIRECT]*執行起始日期{ExecuteBeginDate:D}：【2008/04/01 12:30:40】
        /// </summary> 
        public DataColumn WTST_ExecuteBeginDateColumn;

        /// <summary>
        /// [DIRECT]*執行結束日期{ExecuteEndDate:D}：【2008/04/01 12:30:50】
        /// </summary> 
        public DataColumn WTST_ExecuteEndDateColumn;

        /// <summary>
        /// [DIRECT]*執行例外{ExecuteException:1000}：【資料庫無法開啟】
        /// </summary> 
        public DataColumn WTST_ExecuteExceptionColumn;

        /// <summary>
        /// #執行時間(秒){ExecuteSeconds_XX}：【10】
        /// </summary> 
        public DataColumn WTST_ExecuteSeconds_XXColumn;

        /// <summary>
        /// [DIRECT]*執行結果{ExecuteState:1,ExecuteStateName_XX}：○{Name}成功 ○{Name_U}失敗
        /// </summary> 
        public DataColumn WTST_ExecuteStateColumn;

        /// <summary>
        /// [DIRECT]*執行結果{ExecuteState:1,ExecuteStateName_XX}：○{Name}成功 ○{Name_U}失敗
        /// </summary> 
        public DataColumn WTST_ExecuteStateName_XXColumn;

        /// <summary>
        /// [DIRECT]*是否啟用{IsEnable:1,IsEnableName_XX}：○{Name}啟用 ○{Name_U}不啟用
        /// </summary> 
        public DataColumn WTST_IsEnableColumn;

        /// <summary>
        /// [DIRECT]*是否啟用{IsEnable:1,IsEnableName_XX}：○{Name}啟用 ○{Name_U}不啟用
        /// </summary> 
        public DataColumn WTST_IsEnableName_XXColumn;

        /// <summary>
        /// [DIRECT]*物件類型{ObjectTypeName:100}：【sys.service.HcCareScheduleNotifyTask,AppService】
        /// </summary> 
        public DataColumn WTST_ObjectTypeNameColumn;

        /// <summary>
        /// [DIRECT]*物件參數{Parameters:100}：【DAILYREPORT AreaId】
        /// </summary> 
        public DataColumn WTST_ParametersColumn;

        /// <summary>
        /// [DIRECT]*工作名稱{TaskName:50}：【資料回收程式】
        /// </summary> 
        public DataColumn WTST_TaskNameColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public WT_ScheduleTaskRow findByPrimaryKey(String WTST_ScheduleTaskId)
        {
            return (WT_ScheduleTaskRow)(Rows.Find(new object[] { WTST_ScheduleTaskId }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new WT_ScheduleTaskDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            WTST_ScheduleTaskIdColumn = Columns["WTST_ScheduleTaskId"];
            WTST_DescriptionColumn = Columns["WTST_Description"];
            WTST_ExecuteBeginDateColumn = Columns["WTST_ExecuteBeginDate"];
            WTST_ExecuteEndDateColumn = Columns["WTST_ExecuteEndDate"];
            WTST_ExecuteExceptionColumn = Columns["WTST_ExecuteException"];
            WTST_ExecuteSeconds_XXColumn = Columns["WTST_ExecuteSeconds_XX"];
            WTST_ExecuteStateColumn = Columns["WTST_ExecuteState"];
            WTST_ExecuteStateName_XXColumn = Columns["WTST_ExecuteStateName_XX"];
            WTST_IsEnableColumn = Columns["WTST_IsEnable"];
            WTST_IsEnableName_XXColumn = Columns["WTST_IsEnableName_XX"];
            WTST_ObjectTypeNameColumn = Columns["WTST_ObjectTypeName"];
            WTST_ParametersColumn = Columns["WTST_Parameters"];
            WTST_TaskNameColumn = Columns["WTST_TaskName"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            WTST_ScheduleTaskIdColumn = new DataColumn("WTST_ScheduleTaskId", typeof(String), null, MappingType.Attribute);
            Columns.Add(WTST_ScheduleTaskIdColumn);
            WTST_ScheduleTaskIdColumn.AllowDBNull = false;

            WTST_DescriptionColumn = new DataColumn("WTST_Description", typeof(String), null, MappingType.Attribute);
            Columns.Add(WTST_DescriptionColumn);

            WTST_ExecuteBeginDateColumn = new DataColumn("WTST_ExecuteBeginDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(WTST_ExecuteBeginDateColumn);

            WTST_ExecuteEndDateColumn = new DataColumn("WTST_ExecuteEndDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(WTST_ExecuteEndDateColumn);

            WTST_ExecuteExceptionColumn = new DataColumn("WTST_ExecuteException", typeof(String), null, MappingType.Attribute);
            Columns.Add(WTST_ExecuteExceptionColumn);

            WTST_ExecuteSeconds_XXColumn = new DataColumn("WTST_ExecuteSeconds_XX", typeof(Decimal), null, MappingType.Attribute);
            Columns.Add(WTST_ExecuteSeconds_XXColumn);

            WTST_ExecuteStateColumn = new DataColumn("WTST_ExecuteState", typeof(String), null, MappingType.Attribute);
            Columns.Add(WTST_ExecuteStateColumn);

            WTST_ExecuteStateName_XXColumn = new DataColumn("WTST_ExecuteStateName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(WTST_ExecuteStateName_XXColumn);

            WTST_IsEnableColumn = new DataColumn("WTST_IsEnable", typeof(String), null, MappingType.Attribute);
            Columns.Add(WTST_IsEnableColumn);

            WTST_IsEnableName_XXColumn = new DataColumn("WTST_IsEnableName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(WTST_IsEnableName_XXColumn);

            WTST_ObjectTypeNameColumn = new DataColumn("WTST_ObjectTypeName", typeof(String), null, MappingType.Attribute);
            Columns.Add(WTST_ObjectTypeNameColumn);

            WTST_ParametersColumn = new DataColumn("WTST_Parameters", typeof(String), null, MappingType.Attribute);
            Columns.Add(WTST_ParametersColumn);

            WTST_TaskNameColumn = new DataColumn("WTST_TaskName", typeof(String), null, MappingType.Attribute);
            Columns.Add(WTST_TaskNameColumn);

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { WTST_ScheduleTaskIdColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new WT_ScheduleTaskRow(builder);
        }

    }

    ///<summary>
    ///&lt;WTST&gt;排程工作{ScheduleTask}  
    ///</summary>
    public class WT_ScheduleTaskRow : FtdDataRow
    {
        private WT_ScheduleTaskDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal WT_ScheduleTaskRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((WT_ScheduleTaskDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public WT_ScheduleTaskDataTable TypeTable
        {
            get { return (WT_ScheduleTaskDataTable)Table; }
        }

        ///<summary>
        ///[DIRECT]*排程工作ID{ScheduleTaskId}：【PK&lt;WTST&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string WTST_ScheduleTaskId
        {
            get { return getAttrGetString(this[theTable.WTST_ScheduleTaskIdColumn]); }
            set { this[theTable.WTST_ScheduleTaskIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*工作描述{Descripton:200}：【回收暫存檔案資料】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string WTST_Description
        {
            get { return getAttrGetString(this[theTable.WTST_DescriptionColumn]); }
            set { this[theTable.WTST_DescriptionColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*執行起始日期{ExecuteBeginDate:D}：【2008/04/01 12:30:40】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? WTST_ExecuteBeginDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.WTST_ExecuteBeginDateColumn]); }
            set { this[this.theTable.WTST_ExecuteBeginDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///[DIRECT]*執行結束日期{ExecuteEndDate:D}：【2008/04/01 12:30:50】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? WTST_ExecuteEndDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.WTST_ExecuteEndDateColumn]); }
            set { this[this.theTable.WTST_ExecuteEndDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///[DIRECT]*執行例外{ExecuteException:1000}：【資料庫無法開啟】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string WTST_ExecuteException
        {
            get { return getAttrGetString(this[theTable.WTST_ExecuteExceptionColumn]); }
            set { this[theTable.WTST_ExecuteExceptionColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///#執行時間(秒){ExecuteSeconds_XX}：【10】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Decimal? WTST_ExecuteSeconds_XX
        {
            get { return getAttrGetValue<Decimal>(this[theTable.WTST_ExecuteSeconds_XXColumn]); }
            set { this[this.theTable.WTST_ExecuteSeconds_XXColumn] = getAttrSetValue<Decimal>(value); }
        }

        ///<summary>
        ///[DIRECT]*執行結果{ExecuteState:1,ExecuteStateName_XX}：○{Name}成功 ○{Name_U}失敗  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string WTST_ExecuteState
        {
            get { return getAttrGetString(this[theTable.WTST_ExecuteStateColumn]); }
            set { this[theTable.WTST_ExecuteStateColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*執行結果{ExecuteState:1,ExecuteStateName_XX}：○{Name}成功 ○{Name_U}失敗  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string WTST_ExecuteStateName_XX
        {
            get { return getAttrGetString(this[theTable.WTST_ExecuteStateName_XXColumn]); }
            set { this[theTable.WTST_ExecuteStateName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*是否啟用{IsEnable:1,IsEnableName_XX}：○{Name}啟用 ○{Name_U}不啟用  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string WTST_IsEnable
        {
            get { return getAttrGetString(this[theTable.WTST_IsEnableColumn]); }
            set { this[theTable.WTST_IsEnableColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*是否啟用{IsEnable:1,IsEnableName_XX}：○{Name}啟用 ○{Name_U}不啟用  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string WTST_IsEnableName_XX
        {
            get { return getAttrGetString(this[theTable.WTST_IsEnableName_XXColumn]); }
            set { this[theTable.WTST_IsEnableName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*物件類型{ObjectTypeName:100}：【sys.service.HcCareScheduleNotifyTask,AppService】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string WTST_ObjectTypeName
        {
            get { return getAttrGetString(this[theTable.WTST_ObjectTypeNameColumn]); }
            set { this[theTable.WTST_ObjectTypeNameColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*物件參數{Parameters:100}：【DAILYREPORT AreaId】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string WTST_Parameters
        {
            get { return getAttrGetString(this[theTable.WTST_ParametersColumn]); }
            set { this[theTable.WTST_ParametersColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*工作名稱{TaskName:50}：【資料回收程式】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string WTST_TaskName
        {
            get { return getAttrGetString(this[theTable.WTST_TaskNameColumn]); }
            set { this[theTable.WTST_TaskNameColumn] = getAttrSetString(value); }
        }

    }
}
