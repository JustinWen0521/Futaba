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
    /// &lt;CRR&gt;報名{Registratio}
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class CR_RegistrationDataTable : FtdTypedDataTable<CR_RegistrationRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public CR_RegistrationDataTable() : base("CR_Registration")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new CR_RegistrationDataTable();
            return getTableSchema(xs, dt, "CRR");
        }

        [DebuggerNonUserCodeAttribute()]
        protected CR_RegistrationDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// [DIRECT]*報名ID{RegistrationId}：【PK&lt;CRR&gt;】
        /// </summary> 
        public DataColumn CRR_RegistrationIdColumn;

        /// <summary>
        /// [DIRECT]*身分證{DTN_NVARCHAR10}：【A123456789】
        /// </summary> 
        public DataColumn CRR_CitizenIdColumn;

        /// <summary>
        /// [DIRECT]*班別代號{DTN_NVARCHAR10}：【A01】&lt;br/&gt;
        /// </summary> 
        public DataColumn CRR_ClassCode_XXColumn;

        /// <summary>
        /// [DIRECT]*開班日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;
        /// </summary> 
        public DataColumn CRR_ClassDate_XXColumn;

        /// <summary>
        /// [DIRECT]*班別ID{DTN_NID}：【PK&lt;CRCL&gt;】
        /// </summary> 
        public DataColumn CRR_ClassIdColumn;

        /// <summary>
        /// [DIRECT]*上課時間{DTN_NVARCHAR20}：【09:00~17:00】&lt;br/&gt;
        /// </summary> 
        public DataColumn CRR_ClassTime_XXColumn;

        /// <summary>
        /// [DIRECT]*課程代號{DTN_NVARCHAR10}：【10410001】&lt;br/&gt;&lt;br/&gt;
        /// </summary> 
        public DataColumn CRR_CourseCode_XXColumn;

        /// <summary>
        /// [DIRECT]*課程描述{DTN_NVARCHAR200}：【】&lt;br/&gt;&lt;br/&gt;
        /// </summary> 
        public DataColumn CRR_CourseDesc_XXColumn;

        /// <summary>
        /// [DIRECT]*是否啟用{DTN_NVARCHAR1}：【Y：是 / N：否】&lt;br/&gt;&lt;br/&gt;
        /// </summary> 
        public DataColumn CRR_CourseEnable_XXColumn;

        /// <summary>
        /// [DIRECT]*是否啟用{DTN_NVARCHAR10}：【Y：是 / N：否】&lt;br/&gt;&lt;br/&gt;
        /// </summary> 
        public DataColumn CRR_CourseEnableName_XXColumn;

        /// <summary>
        /// [DIRECT]*課程ID{DTN_NID}：【PK&lt;CRC&gt;】&lt;br/&gt;
        /// </summary> 
        public DataColumn CRR_CourseId_XXColumn;

        /// <summary>
        /// [DIRECT]*課程名稱{DTN_NVARCHAR50}：【】&lt;br/&gt;&lt;br/&gt;
        /// </summary> 
        public DataColumn CRR_CourseName_XXColumn;

        /// <summary>
        /// [DIRECT]*建立日期(DTN_DATETIME_19)：【】
        /// </summary> 
        public DataColumn CRR_CreateDateColumn;

        /// <summary>
        /// [DIRECT]人員編號{EmployeeCode:20}：【EA001】&lt;br/&gt;
        /// </summary> 
        public DataColumn CRR_CreatorCode_XXColumn;

        /// <summary>
        /// [DIRECT]*建立者ID(DTN_NID)：【】
        /// </summary> 
        public DataColumn CRR_CreatorIdColumn;

        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        public DataColumn CRR_CreatorName_XXColumn;

        /// <summary>
        /// [DIRECT]*餐飲服務{DTN_NVARCHAR1}：【N：無 / A：餐盒 / B：茶點】&lt;br/&gt;
        /// </summary> 
        public DataColumn CRR_DietServcie_XXColumn;

        /// <summary>
        /// [DIRECT]*餐飲服務{DTN_NVARCHAR10}：【N：無 / A：餐盒 / B：茶點】&lt;br/&gt;
        /// </summary> 
        public DataColumn CRR_DietServiceName_XXColumn;

        /// <summary>
        /// [DIRECT]*Email{DTN_NVARCHAR50}：【user@company.com】
        /// </summary> 
        public DataColumn CRR_EmailColumn;

        /// <summary>
        /// [DIRECT]*課程結束日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;&lt;br/&gt;
        /// </summary> 
        public DataColumn CRR_EndDate_XXColumn;

        /// <summary>
        /// [DIRECT]*葷素{FoodKind:1}：【A：葷食 / B：素食】
        /// </summary> 
        public DataColumn CRR_FoodKindColumn;

        /// <summary>
        /// [DIRECT]*葷素{FoodKindName_X:1}：【A：葷食 / B：素食】
        /// </summary> 
        public DataColumn CRR_FoodKindName_XXColumn;

        /// <summary>
        /// [DIRECT]*人數限制{DTN_INTEGER}：【40】&lt;br/&gt;
        /// </summary> 
        public DataColumn CRR_LimitQty_XXColumn;

        /// <summary>
        /// [DIRECT]*姓名{DTN_NVARCHAR20}：【王小明】
        /// </summary> 
        public DataColumn CRR_NameColumn;

        /// <summary>
        /// [DIRECT]*單位名稱{OrganName:50}：【中正高中】
        /// </summary> 
        public DataColumn CRR_OrganNameColumn;

        /// <summary>
        /// [DIRECT]*報名結束日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;&lt;br/&gt;
        /// </summary> 
        public DataColumn CRR_RegisterEndDate_XXColumn;

        /// <summary>
        /// *已報名人數{DTN_INTEGER}：【35】&lt;br/&gt;
        /// </summary> 
        public DataColumn CRR_RegisterQty_XXColumn;

        /// <summary>
        /// [DIRECT]*報名開始日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;&lt;br/&gt;
        /// </summary> 
        public DataColumn CRR_RegisterStartDate_XXColumn;

        /// <summary>
        /// [DIRECT]*課程開始日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;&lt;br/&gt;
        /// </summary> 
        public DataColumn CRR_StartDate_XXColumn;

        /// <summary>
        /// [DIRECT]*聯絡電話{Tel:20}：【07-3368333#3097】
        /// </summary> 
        public DataColumn CRR_TelColumn;

        /// <summary>
        /// [DIRECT]*異動日期(DTN_DATETIME_19)：【】
        /// </summary> 
        public DataColumn CRR_UpdateDateColumn;

        /// <summary>
        /// [DIRECT]*異動者ID(DTN_NID)：【】
        /// </summary> 
        public DataColumn CRR_UpdaterIdColumn;

        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        public DataColumn CRR_UpdaterName_XXColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public CR_RegistrationRow findByPrimaryKey(String CRR_RegistrationId)
        {
            return (CR_RegistrationRow)(Rows.Find(new object[] { CRR_RegistrationId }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new CR_RegistrationDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            CRR_RegistrationIdColumn = Columns["CRR_RegistrationId"];
            CRR_CitizenIdColumn = Columns["CRR_CitizenId"];
            CRR_ClassCode_XXColumn = Columns["CRR_ClassCode_XX"];
            CRR_ClassDate_XXColumn = Columns["CRR_ClassDate_XX"];
            CRR_ClassIdColumn = Columns["CRR_ClassId"];
            CRR_ClassTime_XXColumn = Columns["CRR_ClassTime_XX"];
            CRR_CourseCode_XXColumn = Columns["CRR_CourseCode_XX"];
            CRR_CourseDesc_XXColumn = Columns["CRR_CourseDesc_XX"];
            CRR_CourseEnable_XXColumn = Columns["CRR_CourseEnable_XX"];
            CRR_CourseEnableName_XXColumn = Columns["CRR_CourseEnableName_XX"];
            CRR_CourseId_XXColumn = Columns["CRR_CourseId_XX"];
            CRR_CourseName_XXColumn = Columns["CRR_CourseName_XX"];
            CRR_CreateDateColumn = Columns["CRR_CreateDate"];
            CRR_CreatorCode_XXColumn = Columns["CRR_CreatorCode_XX"];
            CRR_CreatorIdColumn = Columns["CRR_CreatorId"];
            CRR_CreatorName_XXColumn = Columns["CRR_CreatorName_XX"];
            CRR_DietServcie_XXColumn = Columns["CRR_DietServcie_XX"];
            CRR_DietServiceName_XXColumn = Columns["CRR_DietServiceName_XX"];
            CRR_EmailColumn = Columns["CRR_Email"];
            CRR_EndDate_XXColumn = Columns["CRR_EndDate_XX"];
            CRR_FoodKindColumn = Columns["CRR_FoodKind"];
            CRR_FoodKindName_XXColumn = Columns["CRR_FoodKindName_XX"];
            CRR_LimitQty_XXColumn = Columns["CRR_LimitQty_XX"];
            CRR_NameColumn = Columns["CRR_Name"];
            CRR_OrganNameColumn = Columns["CRR_OrganName"];
            CRR_RegisterEndDate_XXColumn = Columns["CRR_RegisterEndDate_XX"];
            CRR_RegisterQty_XXColumn = Columns["CRR_RegisterQty_XX"];
            CRR_RegisterStartDate_XXColumn = Columns["CRR_RegisterStartDate_XX"];
            CRR_StartDate_XXColumn = Columns["CRR_StartDate_XX"];
            CRR_TelColumn = Columns["CRR_Tel"];
            CRR_UpdateDateColumn = Columns["CRR_UpdateDate"];
            CRR_UpdaterIdColumn = Columns["CRR_UpdaterId"];
            CRR_UpdaterName_XXColumn = Columns["CRR_UpdaterName_XX"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            CRR_RegistrationIdColumn = new DataColumn("CRR_RegistrationId", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_RegistrationIdColumn);
            CRR_RegistrationIdColumn.AllowDBNull = false;

            CRR_CitizenIdColumn = new DataColumn("CRR_CitizenId", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_CitizenIdColumn);

            CRR_ClassCode_XXColumn = new DataColumn("CRR_ClassCode_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_ClassCode_XXColumn);

            CRR_ClassDate_XXColumn = new DataColumn("CRR_ClassDate_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_ClassDate_XXColumn);

            CRR_ClassIdColumn = new DataColumn("CRR_ClassId", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_ClassIdColumn);

            CRR_ClassTime_XXColumn = new DataColumn("CRR_ClassTime_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_ClassTime_XXColumn);

            CRR_CourseCode_XXColumn = new DataColumn("CRR_CourseCode_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_CourseCode_XXColumn);

            CRR_CourseDesc_XXColumn = new DataColumn("CRR_CourseDesc_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_CourseDesc_XXColumn);

            CRR_CourseEnable_XXColumn = new DataColumn("CRR_CourseEnable_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_CourseEnable_XXColumn);

            CRR_CourseEnableName_XXColumn = new DataColumn("CRR_CourseEnableName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_CourseEnableName_XXColumn);

            CRR_CourseId_XXColumn = new DataColumn("CRR_CourseId_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_CourseId_XXColumn);

            CRR_CourseName_XXColumn = new DataColumn("CRR_CourseName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_CourseName_XXColumn);

            CRR_CreateDateColumn = new DataColumn("CRR_CreateDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(CRR_CreateDateColumn);

            CRR_CreatorCode_XXColumn = new DataColumn("CRR_CreatorCode_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_CreatorCode_XXColumn);

            CRR_CreatorIdColumn = new DataColumn("CRR_CreatorId", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_CreatorIdColumn);

            CRR_CreatorName_XXColumn = new DataColumn("CRR_CreatorName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_CreatorName_XXColumn);

            CRR_DietServcie_XXColumn = new DataColumn("CRR_DietServcie_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_DietServcie_XXColumn);

            CRR_DietServiceName_XXColumn = new DataColumn("CRR_DietServiceName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_DietServiceName_XXColumn);

            CRR_EmailColumn = new DataColumn("CRR_Email", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_EmailColumn);

            CRR_EndDate_XXColumn = new DataColumn("CRR_EndDate_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_EndDate_XXColumn);

            CRR_FoodKindColumn = new DataColumn("CRR_FoodKind", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_FoodKindColumn);

            CRR_FoodKindName_XXColumn = new DataColumn("CRR_FoodKindName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_FoodKindName_XXColumn);

            CRR_LimitQty_XXColumn = new DataColumn("CRR_LimitQty_XX", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(CRR_LimitQty_XXColumn);

            CRR_NameColumn = new DataColumn("CRR_Name", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_NameColumn);

            CRR_OrganNameColumn = new DataColumn("CRR_OrganName", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_OrganNameColumn);

            CRR_RegisterEndDate_XXColumn = new DataColumn("CRR_RegisterEndDate_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_RegisterEndDate_XXColumn);

            CRR_RegisterQty_XXColumn = new DataColumn("CRR_RegisterQty_XX", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(CRR_RegisterQty_XXColumn);

            CRR_RegisterStartDate_XXColumn = new DataColumn("CRR_RegisterStartDate_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_RegisterStartDate_XXColumn);

            CRR_StartDate_XXColumn = new DataColumn("CRR_StartDate_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_StartDate_XXColumn);

            CRR_TelColumn = new DataColumn("CRR_Tel", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_TelColumn);

            CRR_UpdateDateColumn = new DataColumn("CRR_UpdateDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(CRR_UpdateDateColumn);

            CRR_UpdaterIdColumn = new DataColumn("CRR_UpdaterId", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_UpdaterIdColumn);

            CRR_UpdaterName_XXColumn = new DataColumn("CRR_UpdaterName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(CRR_UpdaterName_XXColumn);

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { CRR_RegistrationIdColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new CR_RegistrationRow(builder);
        }

    }

    ///<summary>
    ///&lt;CRR&gt;報名{Registratio}  
    ///</summary>
    public class CR_RegistrationRow : FtdDataRow
    {
        private CR_RegistrationDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal CR_RegistrationRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((CR_RegistrationDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public CR_RegistrationDataTable TypeTable
        {
            get { return (CR_RegistrationDataTable)Table; }
        }

        ///<summary>
        ///[DIRECT]*報名ID{RegistrationId}：【PK&lt;CRR&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_RegistrationId
        {
            get { return getAttrGetString(this[theTable.CRR_RegistrationIdColumn]); }
            set { this[theTable.CRR_RegistrationIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*身分證{DTN_NVARCHAR10}：【A123456789】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_CitizenId
        {
            get { return getAttrGetString(this[theTable.CRR_CitizenIdColumn]); }
            set { this[theTable.CRR_CitizenIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*班別代號{DTN_NVARCHAR10}：【A01】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_ClassCode_XX
        {
            get { return getAttrGetString(this[theTable.CRR_ClassCode_XXColumn]); }
            set { this[theTable.CRR_ClassCode_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*開班日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_ClassDate_XX
        {
            get { return getAttrGetString(this[theTable.CRR_ClassDate_XXColumn]); }
            set { this[theTable.CRR_ClassDate_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*班別ID{DTN_NID}：【PK&lt;CRCL&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_ClassId
        {
            get { return getAttrGetString(this[theTable.CRR_ClassIdColumn]); }
            set { this[theTable.CRR_ClassIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*上課時間{DTN_NVARCHAR20}：【09:00~17:00】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_ClassTime_XX
        {
            get { return getAttrGetString(this[theTable.CRR_ClassTime_XXColumn]); }
            set { this[theTable.CRR_ClassTime_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*課程代號{DTN_NVARCHAR10}：【10410001】&lt;br/&gt;&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_CourseCode_XX
        {
            get { return getAttrGetString(this[theTable.CRR_CourseCode_XXColumn]); }
            set { this[theTable.CRR_CourseCode_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*課程描述{DTN_NVARCHAR200}：【】&lt;br/&gt;&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_CourseDesc_XX
        {
            get { return getAttrGetString(this[theTable.CRR_CourseDesc_XXColumn]); }
            set { this[theTable.CRR_CourseDesc_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*是否啟用{DTN_NVARCHAR1}：【Y：是 / N：否】&lt;br/&gt;&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_CourseEnable_XX
        {
            get { return getAttrGetString(this[theTable.CRR_CourseEnable_XXColumn]); }
            set { this[theTable.CRR_CourseEnable_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*是否啟用{DTN_NVARCHAR10}：【Y：是 / N：否】&lt;br/&gt;&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_CourseEnableName_XX
        {
            get { return getAttrGetString(this[theTable.CRR_CourseEnableName_XXColumn]); }
            set { this[theTable.CRR_CourseEnableName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*課程ID{DTN_NID}：【PK&lt;CRC&gt;】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_CourseId_XX
        {
            get { return getAttrGetString(this[theTable.CRR_CourseId_XXColumn]); }
            set { this[theTable.CRR_CourseId_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*課程名稱{DTN_NVARCHAR50}：【】&lt;br/&gt;&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_CourseName_XX
        {
            get { return getAttrGetString(this[theTable.CRR_CourseName_XXColumn]); }
            set { this[theTable.CRR_CourseName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*建立日期(DTN_DATETIME_19)：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? CRR_CreateDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.CRR_CreateDateColumn]); }
            set { this[this.theTable.CRR_CreateDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///[DIRECT]人員編號{EmployeeCode:20}：【EA001】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_CreatorCode_XX
        {
            get { return getAttrGetString(this[theTable.CRR_CreatorCode_XXColumn]); }
            set { this[theTable.CRR_CreatorCode_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*建立者ID(DTN_NID)：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_CreatorId
        {
            get { return getAttrGetString(this[theTable.CRR_CreatorIdColumn]); }
            set { this[theTable.CRR_CreatorIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_CreatorName_XX
        {
            get { return getAttrGetString(this[theTable.CRR_CreatorName_XXColumn]); }
            set { this[theTable.CRR_CreatorName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*餐飲服務{DTN_NVARCHAR1}：【N：無 / A：餐盒 / B：茶點】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_DietServcie_XX
        {
            get { return getAttrGetString(this[theTable.CRR_DietServcie_XXColumn]); }
            set { this[theTable.CRR_DietServcie_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*餐飲服務{DTN_NVARCHAR10}：【N：無 / A：餐盒 / B：茶點】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_DietServiceName_XX
        {
            get { return getAttrGetString(this[theTable.CRR_DietServiceName_XXColumn]); }
            set { this[theTable.CRR_DietServiceName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*Email{DTN_NVARCHAR50}：【user@company.com】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_Email
        {
            get { return getAttrGetString(this[theTable.CRR_EmailColumn]); }
            set { this[theTable.CRR_EmailColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*課程結束日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_EndDate_XX
        {
            get { return getAttrGetString(this[theTable.CRR_EndDate_XXColumn]); }
            set { this[theTable.CRR_EndDate_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*葷素{FoodKind:1}：【A：葷食 / B：素食】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_FoodKind
        {
            get { return getAttrGetString(this[theTable.CRR_FoodKindColumn]); }
            set { this[theTable.CRR_FoodKindColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*葷素{FoodKindName_X:1}：【A：葷食 / B：素食】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_FoodKindName_XX
        {
            get { return getAttrGetString(this[theTable.CRR_FoodKindName_XXColumn]); }
            set { this[theTable.CRR_FoodKindName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*人數限制{DTN_INTEGER}：【40】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? CRR_LimitQty_XX
        {
            get { return getAttrGetValue<Int32>(this[theTable.CRR_LimitQty_XXColumn]); }
            set { this[this.theTable.CRR_LimitQty_XXColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///[DIRECT]*姓名{DTN_NVARCHAR20}：【王小明】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_Name
        {
            get { return getAttrGetString(this[theTable.CRR_NameColumn]); }
            set { this[theTable.CRR_NameColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*單位名稱{OrganName:50}：【中正高中】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_OrganName
        {
            get { return getAttrGetString(this[theTable.CRR_OrganNameColumn]); }
            set { this[theTable.CRR_OrganNameColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*報名結束日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_RegisterEndDate_XX
        {
            get { return getAttrGetString(this[theTable.CRR_RegisterEndDate_XXColumn]); }
            set { this[theTable.CRR_RegisterEndDate_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///*已報名人數{DTN_INTEGER}：【35】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? CRR_RegisterQty_XX
        {
            get { return getAttrGetValue<Int32>(this[theTable.CRR_RegisterQty_XXColumn]); }
            set { this[this.theTable.CRR_RegisterQty_XXColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///[DIRECT]*報名開始日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_RegisterStartDate_XX
        {
            get { return getAttrGetString(this[theTable.CRR_RegisterStartDate_XXColumn]); }
            set { this[theTable.CRR_RegisterStartDate_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*課程開始日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_StartDate_XX
        {
            get { return getAttrGetString(this[theTable.CRR_StartDate_XXColumn]); }
            set { this[theTable.CRR_StartDate_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*聯絡電話{Tel:20}：【07-3368333#3097】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_Tel
        {
            get { return getAttrGetString(this[theTable.CRR_TelColumn]); }
            set { this[theTable.CRR_TelColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*異動日期(DTN_DATETIME_19)：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? CRR_UpdateDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.CRR_UpdateDateColumn]); }
            set { this[this.theTable.CRR_UpdateDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///[DIRECT]*異動者ID(DTN_NID)：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_UpdaterId
        {
            get { return getAttrGetString(this[theTable.CRR_UpdaterIdColumn]); }
            set { this[theTable.CRR_UpdaterIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string CRR_UpdaterName_XX
        {
            get { return getAttrGetString(this[theTable.CRR_UpdaterName_XXColumn]); }
            set { this[theTable.CRR_UpdaterName_XXColumn] = getAttrSetString(value); }
        }

    }
}
