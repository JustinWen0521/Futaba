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
    /// &lt;CRC&gt;課程{Course}
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class CR_CourseDataTable : FtdTypedDataTable<CR_CourseRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public CR_CourseDataTable() : base("CR_Course")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new CR_CourseDataTable();
            return getTableSchema(xs, dt, "CRC");
        }

        [DebuggerNonUserCodeAttribute()]
        protected CR_CourseDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// [DIRECT]*課程ID{DTN_NID}：【PK&lt;CRC&gt;】
        /// </summary> 
        public DataColumn CRC_CourseIdColumn;

        /// <summary>
        /// [DIRECT]*課程代號{DTN_NVARCHAR10}：【10410001】
        /// </summary> 
        public DataColumn CRC_CodeColumn;

        /// <summary>
        /// [DIRECT]*建立日期(DTN_DATETIME_19)：【】
        /// </summary> 
        public DataColumn CRC_CreateDateColumn;

        /// <summary>
        /// [DIRECT]*建立者ID(DTN_NID)：【】
        /// </summary> 
        public DataColumn CRC_CreatorIdColumn;

        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        public DataColumn CRC_CreatorName_XXColumn;

        /// <summary>
        /// [DIRECT]*課程描述{DTN_NVARCHAR200}：【】
        /// </summary> 
        public DataColumn CRC_DescriptionColumn;

        /// <summary>
        /// [DIRECT]*課程結束日期{DTN_NVARCHAR10}：【1041031】
        /// </summary> 
        public DataColumn CRC_EndDateColumn;

        /// <summary>
        /// [DIRECT]*是否啟用{DTN_NVARCHAR1}：【Y：是 / N：否】
        /// </summary> 
        public DataColumn CRC_IsEnableColumn;

        /// <summary>
        /// [DIRECT]*是否啟用{DTN_NVARCHAR10}：【Y：是 / N：否】
        /// </summary> 
        public DataColumn CRC_IsEnableName_XXColumn;

        /// <summary>
        /// [DIRECT]*課程名稱{DTN_NVARCHAR50}：【】
        /// </summary> 
        public DataColumn CRC_NameColumn;

        /// <summary>
        /// [DIRECT]*報名結束日期{DTN_NVARCHAR10}：【1041031】
        /// </summary> 
        public DataColumn CRC_RegisterEndDateColumn;

        /// <summary>
        /// *已報名人數{RegisterQty_XX:D}：【30】
        /// </summary> 
        public DataColumn CRC_RegisterQty_XXColumn;

        /// <summary>
        /// [DIRECT]*報名開始日期{DTN_NVARCHAR10}：【1041031】
        /// </summary> 
        public DataColumn CRC_RegisterStartDateColumn;

        /// <summary>
        /// [DIRECT]*課程開始日期{DTN_NVARCHAR10}：【1041031】
        /// </summary> 
        public DataColumn CRC_StartDateColumn;

        /// <summary>
        /// [DIRECT]*異動日期(DTN_DATETIME_19)：【】
        /// </summary> 
        public DataColumn CRC_UpdateDateColumn;

        /// <summary>
        /// [DIRECT]*異動者ID(DTN_NID)：【】
        /// </summary> 
        public DataColumn CRC_UpdaterIdColumn;

        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        public DataColumn CRC_UpdaterName_XXColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public CR_CourseRow findByPrimaryKey(String CRC_CourseId)
        {
            return (CR_CourseRow)(Rows.Find(new object[] { CRC_CourseId }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new CR_CourseDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            CRC_CourseIdColumn = Columns["CRC_CourseId"];
            CRC_CodeColumn = Columns["CRC_Code"];
            CRC_CreateDateColumn = Columns["CRC_CreateDate"];
            CRC_CreatorIdColumn = Columns["CRC_CreatorId"];
            CRC_CreatorName_XXColumn = Columns["CRC_CreatorName_XX"];
            CRC_DescriptionColumn = Columns["CRC_Description"];
            CRC_EndDateColumn = Columns["CRC_EndDate"];
            CRC_IsEnableColumn = Columns["CRC_IsEnable"];
            CRC_IsEnableName_XXColumn = Columns["CRC_IsEnableName_XX"];
            CRC_NameColumn = Columns["CRC_Name"];
            CRC_RegisterEndDateColumn = Columns["CRC_RegisterEndDate"];
            CRC_RegisterQty_XXColumn = Columns["CRC_RegisterQty_XX"];
            CRC_RegisterStartDateColumn = Columns["CRC_RegisterStartDate"];
            CRC_StartDateColumn = Columns["CRC_StartDate"];
            CRC_UpdateDateColumn = Columns["CRC_UpdateDate"];
            CRC_UpdaterIdColumn = Columns["CRC_UpdaterId"];
            CRC_UpdaterName_XXColumn = Columns["CRC_UpdaterName_XX"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            CRC_CourseIdColumn = new DataColumn("CRC_CourseId", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRC_CourseIdColumn);
            CRC_CourseIdColumn.AllowDBNull = false;

            CRC_CodeColumn = new DataColumn("CRC_Code", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRC_CodeColumn);

            CRC_CreateDateColumn = new DataColumn("CRC_CreateDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(CRC_CreateDateColumn);

            CRC_CreatorIdColumn = new DataColumn("CRC_CreatorId", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRC_CreatorIdColumn);

            CRC_CreatorName_XXColumn = new DataColumn("CRC_CreatorName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRC_CreatorName_XXColumn);

            CRC_DescriptionColumn = new DataColumn("CRC_Description", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRC_DescriptionColumn);

            CRC_EndDateColumn = new DataColumn("CRC_EndDate", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRC_EndDateColumn);

            CRC_IsEnableColumn = new DataColumn("CRC_IsEnable", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRC_IsEnableColumn);

            CRC_IsEnableName_XXColumn = new DataColumn("CRC_IsEnableName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRC_IsEnableName_XXColumn);

            CRC_NameColumn = new DataColumn("CRC_Name", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRC_NameColumn);

            CRC_RegisterEndDateColumn = new DataColumn("CRC_RegisterEndDate", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRC_RegisterEndDateColumn);

            CRC_RegisterQty_XXColumn = new DataColumn("CRC_RegisterQty_XX", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(CRC_RegisterQty_XXColumn);

            CRC_RegisterStartDateColumn = new DataColumn("CRC_RegisterStartDate", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRC_RegisterStartDateColumn);

            CRC_StartDateColumn = new DataColumn("CRC_StartDate", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRC_StartDateColumn);

            CRC_UpdateDateColumn = new DataColumn("CRC_UpdateDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(CRC_UpdateDateColumn);

            CRC_UpdaterIdColumn = new DataColumn("CRC_UpdaterId", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRC_UpdaterIdColumn);

            CRC_UpdaterName_XXColumn = new DataColumn("CRC_UpdaterName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRC_UpdaterName_XXColumn);

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { CRC_CourseIdColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new CR_CourseRow(builder);
        }

    }

    ///<summary>
    ///&lt;CRC&gt;課程{Course}  
    ///</summary>
    public class CR_CourseRow : FtdDataRow
    {
        private CR_CourseDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal CR_CourseRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((CR_CourseDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public CR_CourseDataTable TypeTable
        {
            get { return (CR_CourseDataTable)Table; }
        }

        ///<summary>
        ///[DIRECT]*課程ID{DTN_NID}：【PK&lt;CRC&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRC_CourseId
        {
            get { return getAttrGetString(this[theTable.CRC_CourseIdColumn]); }
            set { this[theTable.CRC_CourseIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*課程代號{DTN_NVARCHAR10}：【10410001】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRC_Code
        {
            get { return getAttrGetString(this[theTable.CRC_CodeColumn]); }
            set { this[theTable.CRC_CodeColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*建立日期(DTN_DATETIME_19)：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? CRC_CreateDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.CRC_CreateDateColumn]); }
            set { this[this.theTable.CRC_CreateDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///[DIRECT]*建立者ID(DTN_NID)：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRC_CreatorId
        {
            get { return getAttrGetString(this[theTable.CRC_CreatorIdColumn]); }
            set { this[theTable.CRC_CreatorIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRC_CreatorName_XX
        {
            get { return getAttrGetString(this[theTable.CRC_CreatorName_XXColumn]); }
            set { this[theTable.CRC_CreatorName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*課程描述{DTN_NVARCHAR200}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRC_Description
        {
            get { return getAttrGetString(this[theTable.CRC_DescriptionColumn]); }
            set { this[theTable.CRC_DescriptionColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*課程結束日期{DTN_NVARCHAR10}：【1041031】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRC_EndDate
        {
            get { return getAttrGetString(this[theTable.CRC_EndDateColumn]); }
            set { this[theTable.CRC_EndDateColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*是否啟用{DTN_NVARCHAR1}：【Y：是 / N：否】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRC_IsEnable
        {
            get { return getAttrGetString(this[theTable.CRC_IsEnableColumn]); }
            set { this[theTable.CRC_IsEnableColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*是否啟用{DTN_NVARCHAR10}：【Y：是 / N：否】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRC_IsEnableName_XX
        {
            get { return getAttrGetString(this[theTable.CRC_IsEnableName_XXColumn]); }
            set { this[theTable.CRC_IsEnableName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*課程名稱{DTN_NVARCHAR50}：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRC_Name
        {
            get { return getAttrGetString(this[theTable.CRC_NameColumn]); }
            set { this[theTable.CRC_NameColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*報名結束日期{DTN_NVARCHAR10}：【1041031】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRC_RegisterEndDate
        {
            get { return getAttrGetString(this[theTable.CRC_RegisterEndDateColumn]); }
            set { this[theTable.CRC_RegisterEndDateColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///*已報名人數{RegisterQty_XX:D}：【30】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? CRC_RegisterQty_XX
        {
            get { return getAttrGetValue<Int32>(this[theTable.CRC_RegisterQty_XXColumn]); }
            set { this[this.theTable.CRC_RegisterQty_XXColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///[DIRECT]*報名開始日期{DTN_NVARCHAR10}：【1041031】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRC_RegisterStartDate
        {
            get { return getAttrGetString(this[theTable.CRC_RegisterStartDateColumn]); }
            set { this[theTable.CRC_RegisterStartDateColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*課程開始日期{DTN_NVARCHAR10}：【1041031】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRC_StartDate
        {
            get { return getAttrGetString(this[theTable.CRC_StartDateColumn]); }
            set { this[theTable.CRC_StartDateColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*異動日期(DTN_DATETIME_19)：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? CRC_UpdateDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.CRC_UpdateDateColumn]); }
            set { this[this.theTable.CRC_UpdateDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///[DIRECT]*異動者ID(DTN_NID)：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRC_UpdaterId
        {
            get { return getAttrGetString(this[theTable.CRC_UpdaterIdColumn]); }
            set { this[theTable.CRC_UpdaterIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRC_UpdaterName_XX
        {
            get { return getAttrGetString(this[theTable.CRC_UpdaterName_XXColumn]); }
            set { this[theTable.CRC_UpdaterName_XXColumn] = getAttrSetString(value); }
        }

    }
}
