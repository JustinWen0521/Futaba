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
    /// &lt;EOO&gt;組織{Organization}
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class EO_OrganizationDataTable : FtdTypedDataTable<EO_OrganizationRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public EO_OrganizationDataTable() : base("EO_Organization")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new EO_OrganizationDataTable();
            return getTableSchema(xs, dt, "EOO");
        }

        [DebuggerNonUserCodeAttribute()]
        protected EO_OrganizationDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// [DIRECT]*組織ID{OrganizationId}：【PK&lt;EOO&gt;】
        /// </summary> 
        public DataColumn EOO_OrganizationIdColumn;

        /// <summary>
        /// [DIRECT]地址{Address:100}
        /// </summary> 
        public DataColumn EOO_AddressColumn;

        /// <summary>
        /// [DIRECT]信用額度{Bail:INT}
        /// </summary> 
        public DataColumn EOO_BailColumn;

        /// <summary>
        /// [DIRECT]銀行帳戶{BankAccount:20}
        /// </summary> 
        public DataColumn EOO_BankAccountColumn;

        /// <summary>
        /// [DIRECT]帳戶名稱{BankAccountName:50}
        /// </summary> 
        public DataColumn EOO_BankAccountNameColumn;

        /// <summary>
        /// [DIRECT]銀行代號{BankCode:10}
        /// </summary> 
        public DataColumn EOO_BankCodeColumn;

        /// <summary>
        /// [DIRECT]銀行名稱{BankName:50}
        /// </summary> 
        public DataColumn EOO_BankNameColumn;

        /// <summary>
        /// [DIRECT]組織代號{Code:10}：【AB0913】
        /// </summary> 
        public DataColumn EOO_CodeColumn;

        /// <summary>
        /// [DIRECT]聯絡人{Contact:10}
        /// </summary> 
        public DataColumn EOO_ContactColumn;

        /// <summary>
        /// [DIRECT]*建立日期{CreateDate：DATETIME_19}：【yyyy/MM/dd HH:mm:ss】
        /// </summary> 
        public DataColumn EOO_CreateDateColumn;

        /// <summary>
        /// [DIRECT]*建立者id{CreatorId：Id}：
        /// </summary> 
        public DataColumn EOO_CreatorIdColumn;

        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOO_CreatorName_XXColumn;

        /// <summary>
        /// [DIRECT]Email{Email:100}
        /// </summary> 
        public DataColumn EOO_EmailColumn;

        /// <summary>
        /// [DIRECT]傳真{Fax:20}
        /// </summary> 
        public DataColumn EOO_FaxColumn;

        /// <summary>
        /// [DIRECT]*組織名稱{FullName:50}：【永利果菜批發商行】
        /// </summary> 
        public DataColumn EOO_FullNameColumn;

        /// <summary>
        /// [DIRECT]電話1{Phone1:20}
        /// </summary> 
        public DataColumn EOO_Phone1Column;

        /// <summary>
        /// [DIRECT]電話2{Phone2:20}
        /// </summary> 
        public DataColumn EOO_Phone2Column;

        /// <summary>
        /// [DIRECT]暫停或廢止原因{Reason:50}
        /// </summary> 
        public DataColumn EOO_ReasonColumn;

        /// <summary>
        /// [DIRECT]登記日期{RegisterDate:D}
        /// </summary> 
        public DataColumn EOO_RegisterDateColumn;

        /// <summary>
        /// [DIRECT]登記證號{RegisterNo:20}
        /// </summary> 
        public DataColumn EOO_RegisterNoColumn;

        /// <summary>
        /// [DIRECT]備註{Remark:100}
        /// </summary> 
        public DataColumn EOO_RemarkColumn;

        /// <summary>
        /// [DIRECT]*組織簡稱{ShortName:10}：【永利行】
        /// </summary> 
        public DataColumn EOO_ShortNameColumn;

        /// <summary>
        /// [DIRECT]狀態{Status:1}
        /// </summary> 
        public DataColumn EOO_StatusColumn;

        /// <summary>
        /// [DIRECT]狀態說明{StatusName_XX:10}【A：啟用 / B：暫停 / Z：廢止】
        /// </summary> 
        public DataColumn EOO_StatusName_XXColumn;

        /// <summary>
        /// [DIRECT]統一編號{UnifiedNo:10}
        /// </summary> 
        public DataColumn EOO_UnifiedNoColumn;

        /// <summary>
        /// [DIRECT]*異動日期{UpdateDate：DATETIME_19}：【yyyy/MM/dd HH:mm:ss】
        /// </summary> 
        public DataColumn EOO_UpdateDateColumn;

        /// <summary>
        /// [DIRECT]*異動者id{UpdaterId：Id}：
        /// </summary> 
        public DataColumn EOO_UpdaterIdColumn;

        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOO_UpdaterName_XXColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public EO_OrganizationRow findByPrimaryKey(String EOO_OrganizationId)
        {
            return (EO_OrganizationRow)(Rows.Find(new object[] { EOO_OrganizationId }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new EO_OrganizationDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            EOO_OrganizationIdColumn = Columns["EOO_OrganizationId"];
            EOO_AddressColumn = Columns["EOO_Address"];
            EOO_BailColumn = Columns["EOO_Bail"];
            EOO_BankAccountColumn = Columns["EOO_BankAccount"];
            EOO_BankAccountNameColumn = Columns["EOO_BankAccountName"];
            EOO_BankCodeColumn = Columns["EOO_BankCode"];
            EOO_BankNameColumn = Columns["EOO_BankName"];
            EOO_CodeColumn = Columns["EOO_Code"];
            EOO_ContactColumn = Columns["EOO_Contact"];
            EOO_CreateDateColumn = Columns["EOO_CreateDate"];
            EOO_CreatorIdColumn = Columns["EOO_CreatorId"];
            EOO_CreatorName_XXColumn = Columns["EOO_CreatorName_XX"];
            EOO_EmailColumn = Columns["EOO_Email"];
            EOO_FaxColumn = Columns["EOO_Fax"];
            EOO_FullNameColumn = Columns["EOO_FullName"];
            EOO_Phone1Column = Columns["EOO_Phone1"];
            EOO_Phone2Column = Columns["EOO_Phone2"];
            EOO_ReasonColumn = Columns["EOO_Reason"];
            EOO_RegisterDateColumn = Columns["EOO_RegisterDate"];
            EOO_RegisterNoColumn = Columns["EOO_RegisterNo"];
            EOO_RemarkColumn = Columns["EOO_Remark"];
            EOO_ShortNameColumn = Columns["EOO_ShortName"];
            EOO_StatusColumn = Columns["EOO_Status"];
            EOO_StatusName_XXColumn = Columns["EOO_StatusName_XX"];
            EOO_UnifiedNoColumn = Columns["EOO_UnifiedNo"];
            EOO_UpdateDateColumn = Columns["EOO_UpdateDate"];
            EOO_UpdaterIdColumn = Columns["EOO_UpdaterId"];
            EOO_UpdaterName_XXColumn = Columns["EOO_UpdaterName_XX"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            EOO_OrganizationIdColumn = new DataColumn("EOO_OrganizationId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOO_OrganizationIdColumn);
            EOO_OrganizationIdColumn.AllowDBNull = false;

            EOO_AddressColumn = new DataColumn("EOO_Address", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOO_AddressColumn);

            EOO_BailColumn = new DataColumn("EOO_Bail", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(EOO_BailColumn);

            EOO_BankAccountColumn = new DataColumn("EOO_BankAccount", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOO_BankAccountColumn);

            EOO_BankAccountNameColumn = new DataColumn("EOO_BankAccountName", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOO_BankAccountNameColumn);

            EOO_BankCodeColumn = new DataColumn("EOO_BankCode", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOO_BankCodeColumn);

            EOO_BankNameColumn = new DataColumn("EOO_BankName", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOO_BankNameColumn);

            EOO_CodeColumn = new DataColumn("EOO_Code", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOO_CodeColumn);

            EOO_ContactColumn = new DataColumn("EOO_Contact", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOO_ContactColumn);

            EOO_CreateDateColumn = new DataColumn("EOO_CreateDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(EOO_CreateDateColumn);

            EOO_CreatorIdColumn = new DataColumn("EOO_CreatorId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOO_CreatorIdColumn);

            EOO_CreatorName_XXColumn = new DataColumn("EOO_CreatorName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOO_CreatorName_XXColumn);

            EOO_EmailColumn = new DataColumn("EOO_Email", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOO_EmailColumn);

            EOO_FaxColumn = new DataColumn("EOO_Fax", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOO_FaxColumn);

            EOO_FullNameColumn = new DataColumn("EOO_FullName", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOO_FullNameColumn);

            EOO_Phone1Column = new DataColumn("EOO_Phone1", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOO_Phone1Column);

            EOO_Phone2Column = new DataColumn("EOO_Phone2", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOO_Phone2Column);

            EOO_ReasonColumn = new DataColumn("EOO_Reason", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOO_ReasonColumn);

            EOO_RegisterDateColumn = new DataColumn("EOO_RegisterDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(EOO_RegisterDateColumn);

            EOO_RegisterNoColumn = new DataColumn("EOO_RegisterNo", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOO_RegisterNoColumn);

            EOO_RemarkColumn = new DataColumn("EOO_Remark", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOO_RemarkColumn);

            EOO_ShortNameColumn = new DataColumn("EOO_ShortName", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOO_ShortNameColumn);

            EOO_StatusColumn = new DataColumn("EOO_Status", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOO_StatusColumn);

            EOO_StatusName_XXColumn = new DataColumn("EOO_StatusName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOO_StatusName_XXColumn);

            EOO_UnifiedNoColumn = new DataColumn("EOO_UnifiedNo", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOO_UnifiedNoColumn);

            EOO_UpdateDateColumn = new DataColumn("EOO_UpdateDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(EOO_UpdateDateColumn);

            EOO_UpdaterIdColumn = new DataColumn("EOO_UpdaterId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOO_UpdaterIdColumn);

            EOO_UpdaterName_XXColumn = new DataColumn("EOO_UpdaterName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOO_UpdaterName_XXColumn);

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { EOO_OrganizationIdColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new EO_OrganizationRow(builder);
        }

    }

    ///<summary>
    ///&lt;EOO&gt;組織{Organization}  
    ///</summary>
    public class EO_OrganizationRow : FtdDataRow
    {
        private EO_OrganizationDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal EO_OrganizationRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((EO_OrganizationDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public EO_OrganizationDataTable TypeTable
        {
            get { return (EO_OrganizationDataTable)Table; }
        }

        ///<summary>
        ///[DIRECT]*組織ID{OrganizationId}：【PK&lt;EOO&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOO_OrganizationId
        {
            get { return getAttrGetString(this[theTable.EOO_OrganizationIdColumn]); }
            set { this[theTable.EOO_OrganizationIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]地址{Address:100}  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOO_Address
        {
            get { return getAttrGetString(this[theTable.EOO_AddressColumn]); }
            set { this[theTable.EOO_AddressColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]信用額度{Bail:INT}  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? EOO_Bail
        {
            get { return getAttrGetValue<Int32>(this[theTable.EOO_BailColumn]); }
            set { this[this.theTable.EOO_BailColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///[DIRECT]銀行帳戶{BankAccount:20}  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOO_BankAccount
        {
            get { return getAttrGetString(this[theTable.EOO_BankAccountColumn]); }
            set { this[theTable.EOO_BankAccountColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]帳戶名稱{BankAccountName:50}  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOO_BankAccountName
        {
            get { return getAttrGetString(this[theTable.EOO_BankAccountNameColumn]); }
            set { this[theTable.EOO_BankAccountNameColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]銀行代號{BankCode:10}  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOO_BankCode
        {
            get { return getAttrGetString(this[theTable.EOO_BankCodeColumn]); }
            set { this[theTable.EOO_BankCodeColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]銀行名稱{BankName:50}  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOO_BankName
        {
            get { return getAttrGetString(this[theTable.EOO_BankNameColumn]); }
            set { this[theTable.EOO_BankNameColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]組織代號{Code:10}：【AB0913】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOO_Code
        {
            get { return getAttrGetString(this[theTable.EOO_CodeColumn]); }
            set { this[theTable.EOO_CodeColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]聯絡人{Contact:10}  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOO_Contact
        {
            get { return getAttrGetString(this[theTable.EOO_ContactColumn]); }
            set { this[theTable.EOO_ContactColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*建立日期{CreateDate：DATETIME_19}：【yyyy/MM/dd HH:mm:ss】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? EOO_CreateDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.EOO_CreateDateColumn]); }
            set { this[this.theTable.EOO_CreateDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///[DIRECT]*建立者id{CreatorId：Id}：  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOO_CreatorId
        {
            get { return getAttrGetString(this[theTable.EOO_CreatorIdColumn]); }
            set { this[theTable.EOO_CreatorIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOO_CreatorName_XX
        {
            get { return getAttrGetString(this[theTable.EOO_CreatorName_XXColumn]); }
            set { this[theTable.EOO_CreatorName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]Email{Email:100}  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOO_Email
        {
            get { return getAttrGetString(this[theTable.EOO_EmailColumn]); }
            set { this[theTable.EOO_EmailColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]傳真{Fax:20}  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOO_Fax
        {
            get { return getAttrGetString(this[theTable.EOO_FaxColumn]); }
            set { this[theTable.EOO_FaxColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*組織名稱{FullName:50}：【永利果菜批發商行】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOO_FullName
        {
            get { return getAttrGetString(this[theTable.EOO_FullNameColumn]); }
            set { this[theTable.EOO_FullNameColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]電話1{Phone1:20}  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOO_Phone1
        {
            get { return getAttrGetString(this[theTable.EOO_Phone1Column]); }
            set { this[theTable.EOO_Phone1Column] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]電話2{Phone2:20}  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOO_Phone2
        {
            get { return getAttrGetString(this[theTable.EOO_Phone2Column]); }
            set { this[theTable.EOO_Phone2Column] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]暫停或廢止原因{Reason:50}  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOO_Reason
        {
            get { return getAttrGetString(this[theTable.EOO_ReasonColumn]); }
            set { this[theTable.EOO_ReasonColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]登記日期{RegisterDate:D}  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? EOO_RegisterDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.EOO_RegisterDateColumn]); }
            set { this[this.theTable.EOO_RegisterDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///[DIRECT]登記證號{RegisterNo:20}  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOO_RegisterNo
        {
            get { return getAttrGetString(this[theTable.EOO_RegisterNoColumn]); }
            set { this[theTable.EOO_RegisterNoColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]備註{Remark:100}  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOO_Remark
        {
            get { return getAttrGetString(this[theTable.EOO_RemarkColumn]); }
            set { this[theTable.EOO_RemarkColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*組織簡稱{ShortName:10}：【永利行】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOO_ShortName
        {
            get { return getAttrGetString(this[theTable.EOO_ShortNameColumn]); }
            set { this[theTable.EOO_ShortNameColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]狀態{Status:1}  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOO_Status
        {
            get { return getAttrGetString(this[theTable.EOO_StatusColumn]); }
            set { this[theTable.EOO_StatusColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]狀態說明{StatusName_XX:10}【A：啟用 / B：暫停 / Z：廢止】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOO_StatusName_XX
        {
            get { return getAttrGetString(this[theTable.EOO_StatusName_XXColumn]); }
            set { this[theTable.EOO_StatusName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]統一編號{UnifiedNo:10}  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOO_UnifiedNo
        {
            get { return getAttrGetString(this[theTable.EOO_UnifiedNoColumn]); }
            set { this[theTable.EOO_UnifiedNoColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*異動日期{UpdateDate：DATETIME_19}：【yyyy/MM/dd HH:mm:ss】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? EOO_UpdateDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.EOO_UpdateDateColumn]); }
            set { this[this.theTable.EOO_UpdateDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///[DIRECT]*異動者id{UpdaterId：Id}：  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOO_UpdaterId
        {
            get { return getAttrGetString(this[theTable.EOO_UpdaterIdColumn]); }
            set { this[theTable.EOO_UpdaterIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOO_UpdaterName_XX
        {
            get { return getAttrGetString(this[theTable.EOO_UpdaterName_XXColumn]); }
            set { this[theTable.EOO_UpdaterName_XXColumn] = getAttrSetString(value); }
        }

    }
}
