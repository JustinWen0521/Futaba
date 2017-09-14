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
    /// &lt;CRCL&gt;班別{Class}
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class CR_ClassDataTable : FtdTypedDataTable<CR_ClassRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public CR_ClassDataTable() : base("CR_Class")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new CR_ClassDataTable();
            return getTableSchema(xs, dt, "CRCL");
        }

        [DebuggerNonUserCodeAttribute()]
        protected CR_ClassDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// [DIRECT]*班別ID{DTN_NID}：【PK&lt;CRCL&gt;】
        /// </summary> 
        public DataColumn CRCL_ClassIdColumn;

        /// <summary>
        /// [DIRECT]*地址{DTN_NVARCHAR100}：【高雄市苓雅區四維三路2號8樓】
        /// </summary> 
        public DataColumn CRCL_AddressColumn;

        /// <summary>
        /// [DIRECT]*開班日期{DTN_NVARCHAR10}：【1041031】
        /// </summary> 
        public DataColumn CRCL_ClassDateColumn;

        /// <summary>
        /// [DIRECT]*上課時間{DTN_NVARCHAR20}：【09:00~17:00】
        /// </summary> 
        public DataColumn CRCL_ClassTimeColumn;

        /// <summary>
        /// [DIRECT]*班別代號{DTN_NVARCHAR10}：【A01】
        /// </summary> 
        public DataColumn CRCL_CodeColumn;

        /// <summary>
        /// [DIRECT]*課程代號{DTN_NVARCHAR10}：【10410001】&lt;br/&gt;
        /// </summary> 
        public DataColumn CRCL_CourseCode_XXColumn;

        /// <summary>
        /// [DIRECT]*課程描述{DTN_NVARCHAR200}：【】&lt;br/&gt;
        /// </summary> 
        public DataColumn CRCL_CourseDesc_XXColumn;

        /// <summary>
        /// [DIRECT]*是否啟用{DTN_NVARCHAR1}：【Y：是 / N：否】&lt;br/&gt;
        /// </summary> 
        public DataColumn CRCL_CourseEnable_XXColumn;

        /// <summary>
        /// [DIRECT]*是否啟用{DTN_NVARCHAR10}：【Y：是 / N：否】&lt;br/&gt;
        /// </summary> 
        public DataColumn CRCL_CourseEnableName_XXColumn;

        /// <summary>
        /// [DIRECT]*課程ID{DTN_NID}：【PK&lt;CRC&gt;】
        /// </summary> 
        public DataColumn CRCL_CourseIdColumn;

        /// <summary>
        /// [DIRECT]*課程名稱{DTN_NVARCHAR50}：【】&lt;br/&gt;
        /// </summary> 
        public DataColumn CRCL_CourseName_XXColumn;

        /// <summary>
        /// [DIRECT]*建立日期(DTN_DATETIME_19)：【】
        /// </summary> 
        public DataColumn CRCL_CreateDateColumn;

        /// <summary>
        /// [DIRECT]*建立者ID(DTN_NID)：【】
        /// </summary> 
        public DataColumn CRCL_CreatorIdColumn;

        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        public DataColumn CRCL_CreatorName_XXColumn;

        /// <summary>
        /// [DIRECT]*餐飲服務{DTN_NVARCHAR1}：【N：無 / A：餐盒 / B：茶點】
        /// </summary> 
        public DataColumn CRCL_DietServcieColumn;

        /// <summary>
        /// [DIRECT]*餐飲服務{DTN_NVARCHAR10}：【N：無 / A：餐盒 / B：茶點】
        /// </summary> 
        public DataColumn CRCL_DietServiceName_XXColumn;

        /// <summary>
        /// [DIRECT]*課程結束日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;
        /// </summary> 
        public DataColumn CRCL_EndDate_XXColumn;

        /// <summary>
        /// [DIRECT]*人數限制{DTN_INTEGER}：【40】
        /// </summary> 
        public DataColumn CRCL_LimitQtyColumn;

        /// <summary>
        /// [DIRECT]*上課地點{DTN_NVARCHAR50}：【高雄市政府資訊中心電腦教室】
        /// </summary> 
        public DataColumn CRCL_PlaceColumn;

        /// <summary>
        /// [DIRECT]*報名結束日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;
        /// </summary> 
        public DataColumn CRCL_RegisterEndDate_XXColumn;

        /// <summary>
        /// *已報名人數{DTN_INTEGER}：【35】
        /// </summary> 
        public DataColumn CRCL_RegisterQty_XXColumn;

        /// <summary>
        /// [DIRECT]*報名開始日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;
        /// </summary> 
        public DataColumn CRCL_RegisterStartDate_XXColumn;

        /// <summary>
        /// [DIRECT]*課程開始日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;
        /// </summary> 
        public DataColumn CRCL_StartDate_XXColumn;

        /// <summary>
        /// [DIRECT]*異動日期(DTN_DATETIME_19)：【】
        /// </summary> 
        public DataColumn CRCL_UpdateDateColumn;

        /// <summary>
        /// [DIRECT]*異動者ID(DTN_NID)：【】
        /// </summary> 
        public DataColumn CRCL_UpdaterIdColumn;

        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        public DataColumn CRCL_UpdaterName_XXColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public CR_ClassRow findByPrimaryKey(String CRCL_ClassId)
        {
            return (CR_ClassRow)(Rows.Find(new object[] { CRCL_ClassId }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new CR_ClassDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            CRCL_ClassIdColumn = Columns["CRCL_ClassId"];
            CRCL_AddressColumn = Columns["CRCL_Address"];
            CRCL_ClassDateColumn = Columns["CRCL_ClassDate"];
            CRCL_ClassTimeColumn = Columns["CRCL_ClassTime"];
            CRCL_CodeColumn = Columns["CRCL_Code"];
            CRCL_CourseCode_XXColumn = Columns["CRCL_CourseCode_XX"];
            CRCL_CourseDesc_XXColumn = Columns["CRCL_CourseDesc_XX"];
            CRCL_CourseEnable_XXColumn = Columns["CRCL_CourseEnable_XX"];
            CRCL_CourseEnableName_XXColumn = Columns["CRCL_CourseEnableName_XX"];
            CRCL_CourseIdColumn = Columns["CRCL_CourseId"];
            CRCL_CourseName_XXColumn = Columns["CRCL_CourseName_XX"];
            CRCL_CreateDateColumn = Columns["CRCL_CreateDate"];
            CRCL_CreatorIdColumn = Columns["CRCL_CreatorId"];
            CRCL_CreatorName_XXColumn = Columns["CRCL_CreatorName_XX"];
            CRCL_DietServcieColumn = Columns["CRCL_DietServcie"];
            CRCL_DietServiceName_XXColumn = Columns["CRCL_DietServiceName_XX"];
            CRCL_EndDate_XXColumn = Columns["CRCL_EndDate_XX"];
            CRCL_LimitQtyColumn = Columns["CRCL_LimitQty"];
            CRCL_PlaceColumn = Columns["CRCL_Place"];
            CRCL_RegisterEndDate_XXColumn = Columns["CRCL_RegisterEndDate_XX"];
            CRCL_RegisterQty_XXColumn = Columns["CRCL_RegisterQty_XX"];
            CRCL_RegisterStartDate_XXColumn = Columns["CRCL_RegisterStartDate_XX"];
            CRCL_StartDate_XXColumn = Columns["CRCL_StartDate_XX"];
            CRCL_UpdateDateColumn = Columns["CRCL_UpdateDate"];
            CRCL_UpdaterIdColumn = Columns["CRCL_UpdaterId"];
            CRCL_UpdaterName_XXColumn = Columns["CRCL_UpdaterName_XX"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            CRCL_ClassIdColumn = new DataColumn("CRCL_ClassId", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRCL_ClassIdColumn);
            CRCL_ClassIdColumn.AllowDBNull = false;

            CRCL_AddressColumn = new DataColumn("CRCL_Address", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRCL_AddressColumn);

            CRCL_ClassDateColumn = new DataColumn("CRCL_ClassDate", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRCL_ClassDateColumn);

            CRCL_ClassTimeColumn = new DataColumn("CRCL_ClassTime", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRCL_ClassTimeColumn);

            CRCL_CodeColumn = new DataColumn("CRCL_Code", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRCL_CodeColumn);

            CRCL_CourseCode_XXColumn = new DataColumn("CRCL_CourseCode_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRCL_CourseCode_XXColumn);

            CRCL_CourseDesc_XXColumn = new DataColumn("CRCL_CourseDesc_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRCL_CourseDesc_XXColumn);

            CRCL_CourseEnable_XXColumn = new DataColumn("CRCL_CourseEnable_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRCL_CourseEnable_XXColumn);

            CRCL_CourseEnableName_XXColumn = new DataColumn("CRCL_CourseEnableName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRCL_CourseEnableName_XXColumn);

            CRCL_CourseIdColumn = new DataColumn("CRCL_CourseId", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRCL_CourseIdColumn);

            CRCL_CourseName_XXColumn = new DataColumn("CRCL_CourseName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRCL_CourseName_XXColumn);

            CRCL_CreateDateColumn = new DataColumn("CRCL_CreateDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(CRCL_CreateDateColumn);

            CRCL_CreatorIdColumn = new DataColumn("CRCL_CreatorId", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRCL_CreatorIdColumn);

            CRCL_CreatorName_XXColumn = new DataColumn("CRCL_CreatorName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRCL_CreatorName_XXColumn);

            CRCL_DietServcieColumn = new DataColumn("CRCL_DietServcie", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRCL_DietServcieColumn);

            CRCL_DietServiceName_XXColumn = new DataColumn("CRCL_DietServiceName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRCL_DietServiceName_XXColumn);

            CRCL_EndDate_XXColumn = new DataColumn("CRCL_EndDate_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRCL_EndDate_XXColumn);

            CRCL_LimitQtyColumn = new DataColumn("CRCL_LimitQty", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(CRCL_LimitQtyColumn);

            CRCL_PlaceColumn = new DataColumn("CRCL_Place", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRCL_PlaceColumn);

            CRCL_RegisterEndDate_XXColumn = new DataColumn("CRCL_RegisterEndDate_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRCL_RegisterEndDate_XXColumn);

            CRCL_RegisterQty_XXColumn = new DataColumn("CRCL_RegisterQty_XX", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(CRCL_RegisterQty_XXColumn);

            CRCL_RegisterStartDate_XXColumn = new DataColumn("CRCL_RegisterStartDate_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRCL_RegisterStartDate_XXColumn);

            CRCL_StartDate_XXColumn = new DataColumn("CRCL_StartDate_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRCL_StartDate_XXColumn);

            CRCL_UpdateDateColumn = new DataColumn("CRCL_UpdateDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(CRCL_UpdateDateColumn);

            CRCL_UpdaterIdColumn = new DataColumn("CRCL_UpdaterId", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRCL_UpdaterIdColumn);

            CRCL_UpdaterName_XXColumn = new DataColumn("CRCL_UpdaterName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRCL_UpdaterName_XXColumn);

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { CRCL_ClassIdColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new CR_ClassRow(builder);
        }

    }

    ///<summary>
    ///&lt;CRCL&gt;班別{Class}  
    ///</summary>
    public class CR_ClassRow : FtdDataRow
    {
        private CR_ClassDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal CR_ClassRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((CR_ClassDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public CR_ClassDataTable TypeTable
        {
            get { return (CR_ClassDataTable)Table; }
        }

        ///<summary>
        ///[DIRECT]*班別ID{DTN_NID}：【PK&lt;CRCL&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRCL_ClassId
        {
            get { return getAttrGetString(this[theTable.CRCL_ClassIdColumn]); }
            set { this[theTable.CRCL_ClassIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*地址{DTN_NVARCHAR100}：【高雄市苓雅區四維三路2號8樓】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRCL_Address
        {
            get { return getAttrGetString(this[theTable.CRCL_AddressColumn]); }
            set { this[theTable.CRCL_AddressColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*開班日期{DTN_NVARCHAR10}：【1041031】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRCL_ClassDate
        {
            get { return getAttrGetString(this[theTable.CRCL_ClassDateColumn]); }
            set { this[theTable.CRCL_ClassDateColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*上課時間{DTN_NVARCHAR20}：【09:00~17:00】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRCL_ClassTime
        {
            get { return getAttrGetString(this[theTable.CRCL_ClassTimeColumn]); }
            set { this[theTable.CRCL_ClassTimeColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*班別代號{DTN_NVARCHAR10}：【A01】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRCL_Code
        {
            get { return getAttrGetString(this[theTable.CRCL_CodeColumn]); }
            set { this[theTable.CRCL_CodeColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*課程代號{DTN_NVARCHAR10}：【10410001】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRCL_CourseCode_XX
        {
            get { return getAttrGetString(this[theTable.CRCL_CourseCode_XXColumn]); }
            set { this[theTable.CRCL_CourseCode_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*課程描述{DTN_NVARCHAR200}：【】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRCL_CourseDesc_XX
        {
            get { return getAttrGetString(this[theTable.CRCL_CourseDesc_XXColumn]); }
            set { this[theTable.CRCL_CourseDesc_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*是否啟用{DTN_NVARCHAR1}：【Y：是 / N：否】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRCL_CourseEnable_XX
        {
            get { return getAttrGetString(this[theTable.CRCL_CourseEnable_XXColumn]); }
            set { this[theTable.CRCL_CourseEnable_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*是否啟用{DTN_NVARCHAR10}：【Y：是 / N：否】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRCL_CourseEnableName_XX
        {
            get { return getAttrGetString(this[theTable.CRCL_CourseEnableName_XXColumn]); }
            set { this[theTable.CRCL_CourseEnableName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*課程ID{DTN_NID}：【PK&lt;CRC&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRCL_CourseId
        {
            get { return getAttrGetString(this[theTable.CRCL_CourseIdColumn]); }
            set { this[theTable.CRCL_CourseIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*課程名稱{DTN_NVARCHAR50}：【】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRCL_CourseName_XX
        {
            get { return getAttrGetString(this[theTable.CRCL_CourseName_XXColumn]); }
            set { this[theTable.CRCL_CourseName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*建立日期(DTN_DATETIME_19)：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? CRCL_CreateDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.CRCL_CreateDateColumn]); }
            set { this[this.theTable.CRCL_CreateDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///[DIRECT]*建立者ID(DTN_NID)：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRCL_CreatorId
        {
            get { return getAttrGetString(this[theTable.CRCL_CreatorIdColumn]); }
            set { this[theTable.CRCL_CreatorIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRCL_CreatorName_XX
        {
            get { return getAttrGetString(this[theTable.CRCL_CreatorName_XXColumn]); }
            set { this[theTable.CRCL_CreatorName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*餐飲服務{DTN_NVARCHAR1}：【N：無 / A：餐盒 / B：茶點】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRCL_DietServcie
        {
            get { return getAttrGetString(this[theTable.CRCL_DietServcieColumn]); }
            set { this[theTable.CRCL_DietServcieColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*餐飲服務{DTN_NVARCHAR10}：【N：無 / A：餐盒 / B：茶點】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRCL_DietServiceName_XX
        {
            get { return getAttrGetString(this[theTable.CRCL_DietServiceName_XXColumn]); }
            set { this[theTable.CRCL_DietServiceName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*課程結束日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRCL_EndDate_XX
        {
            get { return getAttrGetString(this[theTable.CRCL_EndDate_XXColumn]); }
            set { this[theTable.CRCL_EndDate_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*人數限制{DTN_INTEGER}：【40】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? CRCL_LimitQty
        {
            get { return getAttrGetValue<Int32>(this[theTable.CRCL_LimitQtyColumn]); }
            set { this[this.theTable.CRCL_LimitQtyColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///[DIRECT]*上課地點{DTN_NVARCHAR50}：【高雄市政府資訊中心電腦教室】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRCL_Place
        {
            get { return getAttrGetString(this[theTable.CRCL_PlaceColumn]); }
            set { this[theTable.CRCL_PlaceColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*報名結束日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRCL_RegisterEndDate_XX
        {
            get { return getAttrGetString(this[theTable.CRCL_RegisterEndDate_XXColumn]); }
            set { this[theTable.CRCL_RegisterEndDate_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///*已報名人數{DTN_INTEGER}：【35】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? CRCL_RegisterQty_XX
        {
            get { return getAttrGetValue<Int32>(this[theTable.CRCL_RegisterQty_XXColumn]); }
            set { this[this.theTable.CRCL_RegisterQty_XXColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///[DIRECT]*報名開始日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRCL_RegisterStartDate_XX
        {
            get { return getAttrGetString(this[theTable.CRCL_RegisterStartDate_XXColumn]); }
            set { this[theTable.CRCL_RegisterStartDate_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*課程開始日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRCL_StartDate_XX
        {
            get { return getAttrGetString(this[theTable.CRCL_StartDate_XXColumn]); }
            set { this[theTable.CRCL_StartDate_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*異動日期(DTN_DATETIME_19)：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? CRCL_UpdateDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.CRCL_UpdateDateColumn]); }
            set { this[this.theTable.CRCL_UpdateDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///[DIRECT]*異動者ID(DTN_NID)：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRCL_UpdaterId
        {
            get { return getAttrGetString(this[theTable.CRCL_UpdaterIdColumn]); }
            set { this[theTable.CRCL_UpdaterIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRCL_UpdaterName_XX
        {
            get { return getAttrGetString(this[theTable.CRCL_UpdaterName_XXColumn]); }
            set { this[theTable.CRCL_UpdaterName_XXColumn] = getAttrSetString(value); }
        }

    }
}
