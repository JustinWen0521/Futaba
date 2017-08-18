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
    /// &lt;EOE&gt;人員{Employee}
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class EO_EmployeeDataTable : FtdTypedDataTable<EO_EmployeeRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public EO_EmployeeDataTable() : base("EO_Employee")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new EO_EmployeeDataTable();
            return getTableSchema(xs, dt, "EOE");
        }

        [DebuggerNonUserCodeAttribute()]
        protected EO_EmployeeDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// [DIRECT]*人員ID{EmployeeId}：【PK&lt;EOE&gt;】
        /// </summary> 
        public DataColumn EOE_EmployeeIdColumn;

        /// <summary>
        /// [DIRECT]*通訊住址{CAddress:50} 【高雄市 海邊路119巷37號】
        /// </summary> 
        public DataColumn EOE_CAddressColumn;

        /// <summary>
        /// [DIRECT]#人員是否為目前登入者{CU_IsLoginUser_XX}：○{T}是 ○{F}不是
        /// </summary> 
        public DataColumn EOE_CU_IsLoginUser_XXColumn;

        /// <summary>
        /// [DIRECT]*郵遞區號{CZip:10} 【71804】
        /// </summary> 
        public DataColumn EOE_CZipColumn;

        /// <summary>
        /// [DIRECT]部門代號{DepartmentCode:50}：【AB0913】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOE_DepartmentCode_XXColumn;

        /// <summary>
        /// #完整部門名稱{DepartmentFullName_XX}：【市政府\資訊中心】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOE_DepartmentFullName_XXColumn;

        /// <summary>
        /// [DIRECT]*部門{DepartmentId, DepartmentName_XX}：【&lt;EOD&gt;,資訊中心】
        /// </summary> 
        public DataColumn EOE_DepartmentIdColumn;

        /// <summary>
        /// [DIRECT]*部門名稱{DepartmentName:50}：【資訊中心】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOE_DepartmentName_XXColumn;

        /// <summary>
        /// [DIRECT]人員編號{EmployeeCode:20}：【EA001】
        /// </summary> 
        public DataColumn EOE_EmployeeCodeColumn;

        /// <summary>
        /// [DIRECT]*Email{EmployeeEmail:50}：【shengwen@mail2000.com.tw】
        /// </summary> 
        public DataColumn EOE_EmployeeEmailColumn;

        /// <summary>
        /// [DIRECT]#完整姓名{EmployeeFullName_XX}：【市政府-林勝文 組長】
        /// </summary> 
        public DataColumn EOE_EmployeeFullName_XXColumn;

        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】
        /// </summary> 
        public DataColumn EOE_EmployeeNameColumn;

        /// <summary>
        /// [DIRECT]#搜尋用名稱 {EmployeeSearchName_XX}：【林勝文 組長 (shengwen@mail2000.com.tw)】
        /// </summary> 
        public DataColumn EOE_EmployeeSearchName_XXColumn;

        /// <summary>
        /// [DIRECT]身分証字號{EmployeeSid:20}：【R122322555】
        /// </summary> 
        public DataColumn EOE_EmployeeSidColumn;

        /// <summary>
        /// [DIRECT]#標準姓名{EmployeeStandardName_XX}：【林勝文 組長】
        /// </summary> 
        public DataColumn EOE_EmployeeStandardName_XXColumn;

        /// <summary>
        /// [DIRECT]職稱代號 {TitleCode:20}：【A312】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOE_EmployeeTitleCode_XXColumn;

        /// <summary>
        /// [DIRECT]*職稱{EmployeeTitleId, EmployeeTitleName_XX, EmployeeTitleCode_XX}：【&lt;EOET&gt;,主任,B01】
        /// </summary> 
        public DataColumn EOE_EmployeeTitleIdColumn;

        /// <summary>
        /// [DIRECT]*職稱名稱{TitleName:20}：【組長】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOE_EmployeeTitleName_XXColumn;

        /// <summary>
        /// [DIRECT]是否啟用【T：是 / F：否】
        /// </summary> 
        public DataColumn EOE_EnabledColumn;

        /// <summary>
        /// [DIRECT]*任職日期{EntryDate:D}：【2006/09/19】
        /// </summary> 
        public DataColumn EOE_EntryDateColumn;

        /// <summary>
        /// [DIRECT]#是否離職{IsLeave_XX}：○{T}是 ○{F}不是
        /// </summary> 
        public DataColumn EOE_IsLeave_XXColumn;

        /// <summary>
        /// [DIRECT]離職日期{LeaveDate:D}：【2006/10/19】(※填此日期代表已離職，否則為在職)
        /// </summary> 
        public DataColumn EOE_LeaveDateColumn;

        /// <summary>
        /// [DIRECT]*登入帳號{LoginAccount:50}：【Administrator】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOE_LoginAccount_XXColumn;

        /// <summary>
        /// [DIRECT]*登入密碼{LoginPassword:20}：【XYXCDE】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOE_LoginPassword_XXColumn;

        /// <summary>
        /// [DIRECT]個人圖片{PersonalImage:50}：【XXXXXX00-00011.GIF】
        /// </summary> 
        public DataColumn EOE_PersonalImageColumn;

        /// <summary>
        /// [DIRECT]聯絡電話1{Phone1:20}：【06-5951579】
        /// </summary> 
        public DataColumn EOE_Phone1Column;

        /// <summary>
        /// [DIRECT]聯絡電話2{Phone2:20}：【0913670599】
        /// </summary> 
        public DataColumn EOE_Phone2Column;

        /// <summary>
        /// [DIRECT]備註{Remark:100}：【此員工表現良好】
        /// </summary> 
        public DataColumn EOE_RemarkColumn;

        /// <summary>
        /// [DIRECT]性別{Sex:1,SexName_XX}：○{Name}男 ○{Name_U}女
        /// </summary> 
        public DataColumn EOE_SexColumn;

        /// <summary>
        /// [DIRECT]性別{Sex:1,SexName_XX}：○{Name}男 ○{Name_U}女
        /// </summary> 
        public DataColumn EOE_SexName_XXColumn;

        /// <summary>
        /// [DIRECT]簽名檔：{Signature:100}：【我很笨但我很溫柔】
        /// </summary> 
        public DataColumn EOE_SignatureColumn;

        /// <summary>
        /// [DIRECT]*簡訊通知號碼{SmsNumber:20}：【0913670599】
        /// </summary> 
        public DataColumn EOE_SmsNumberColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public EO_EmployeeRow findByPrimaryKey(String EOE_EmployeeId)
        {
            return (EO_EmployeeRow)(Rows.Find(new object[] { EOE_EmployeeId }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new EO_EmployeeDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            EOE_EmployeeIdColumn = Columns["EOE_EmployeeId"];
            EOE_CAddressColumn = Columns["EOE_CAddress"];
            EOE_CU_IsLoginUser_XXColumn = Columns["EOE_CU_IsLoginUser_XX"];
            EOE_CZipColumn = Columns["EOE_CZip"];
            EOE_DepartmentCode_XXColumn = Columns["EOE_DepartmentCode_XX"];
            EOE_DepartmentFullName_XXColumn = Columns["EOE_DepartmentFullName_XX"];
            EOE_DepartmentIdColumn = Columns["EOE_DepartmentId"];
            EOE_DepartmentName_XXColumn = Columns["EOE_DepartmentName_XX"];
            EOE_EmployeeCodeColumn = Columns["EOE_EmployeeCode"];
            EOE_EmployeeEmailColumn = Columns["EOE_EmployeeEmail"];
            EOE_EmployeeFullName_XXColumn = Columns["EOE_EmployeeFullName_XX"];
            EOE_EmployeeNameColumn = Columns["EOE_EmployeeName"];
            EOE_EmployeeSearchName_XXColumn = Columns["EOE_EmployeeSearchName_XX"];
            EOE_EmployeeSidColumn = Columns["EOE_EmployeeSid"];
            EOE_EmployeeStandardName_XXColumn = Columns["EOE_EmployeeStandardName_XX"];
            EOE_EmployeeTitleCode_XXColumn = Columns["EOE_EmployeeTitleCode_XX"];
            EOE_EmployeeTitleIdColumn = Columns["EOE_EmployeeTitleId"];
            EOE_EmployeeTitleName_XXColumn = Columns["EOE_EmployeeTitleName_XX"];
            EOE_EnabledColumn = Columns["EOE_Enabled"];
            EOE_EntryDateColumn = Columns["EOE_EntryDate"];
            EOE_IsLeave_XXColumn = Columns["EOE_IsLeave_XX"];
            EOE_LeaveDateColumn = Columns["EOE_LeaveDate"];
            EOE_LoginAccount_XXColumn = Columns["EOE_LoginAccount_XX"];
            EOE_LoginPassword_XXColumn = Columns["EOE_LoginPassword_XX"];
            EOE_PersonalImageColumn = Columns["EOE_PersonalImage"];
            EOE_Phone1Column = Columns["EOE_Phone1"];
            EOE_Phone2Column = Columns["EOE_Phone2"];
            EOE_RemarkColumn = Columns["EOE_Remark"];
            EOE_SexColumn = Columns["EOE_Sex"];
            EOE_SexName_XXColumn = Columns["EOE_SexName_XX"];
            EOE_SignatureColumn = Columns["EOE_Signature"];
            EOE_SmsNumberColumn = Columns["EOE_SmsNumber"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            EOE_EmployeeIdColumn = new DataColumn("EOE_EmployeeId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_EmployeeIdColumn);
            EOE_EmployeeIdColumn.AllowDBNull = false;

            EOE_CAddressColumn = new DataColumn("EOE_CAddress", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_CAddressColumn);

            EOE_CU_IsLoginUser_XXColumn = new DataColumn("EOE_CU_IsLoginUser_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_CU_IsLoginUser_XXColumn);

            EOE_CZipColumn = new DataColumn("EOE_CZip", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_CZipColumn);

            EOE_DepartmentCode_XXColumn = new DataColumn("EOE_DepartmentCode_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_DepartmentCode_XXColumn);

            EOE_DepartmentFullName_XXColumn = new DataColumn("EOE_DepartmentFullName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_DepartmentFullName_XXColumn);

            EOE_DepartmentIdColumn = new DataColumn("EOE_DepartmentId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_DepartmentIdColumn);

            EOE_DepartmentName_XXColumn = new DataColumn("EOE_DepartmentName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_DepartmentName_XXColumn);

            EOE_EmployeeCodeColumn = new DataColumn("EOE_EmployeeCode", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_EmployeeCodeColumn);

            EOE_EmployeeEmailColumn = new DataColumn("EOE_EmployeeEmail", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_EmployeeEmailColumn);

            EOE_EmployeeFullName_XXColumn = new DataColumn("EOE_EmployeeFullName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_EmployeeFullName_XXColumn);

            EOE_EmployeeNameColumn = new DataColumn("EOE_EmployeeName", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_EmployeeNameColumn);

            EOE_EmployeeSearchName_XXColumn = new DataColumn("EOE_EmployeeSearchName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_EmployeeSearchName_XXColumn);

            EOE_EmployeeSidColumn = new DataColumn("EOE_EmployeeSid", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_EmployeeSidColumn);

            EOE_EmployeeStandardName_XXColumn = new DataColumn("EOE_EmployeeStandardName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_EmployeeStandardName_XXColumn);

            EOE_EmployeeTitleCode_XXColumn = new DataColumn("EOE_EmployeeTitleCode_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_EmployeeTitleCode_XXColumn);

            EOE_EmployeeTitleIdColumn = new DataColumn("EOE_EmployeeTitleId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_EmployeeTitleIdColumn);

            EOE_EmployeeTitleName_XXColumn = new DataColumn("EOE_EmployeeTitleName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_EmployeeTitleName_XXColumn);

            EOE_EnabledColumn = new DataColumn("EOE_Enabled", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_EnabledColumn);

            EOE_EntryDateColumn = new DataColumn("EOE_EntryDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(EOE_EntryDateColumn);

            EOE_IsLeave_XXColumn = new DataColumn("EOE_IsLeave_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_IsLeave_XXColumn);

            EOE_LeaveDateColumn = new DataColumn("EOE_LeaveDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(EOE_LeaveDateColumn);

            EOE_LoginAccount_XXColumn = new DataColumn("EOE_LoginAccount_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_LoginAccount_XXColumn);

            EOE_LoginPassword_XXColumn = new DataColumn("EOE_LoginPassword_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_LoginPassword_XXColumn);

            EOE_PersonalImageColumn = new DataColumn("EOE_PersonalImage", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_PersonalImageColumn);

            EOE_Phone1Column = new DataColumn("EOE_Phone1", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_Phone1Column);

            EOE_Phone2Column = new DataColumn("EOE_Phone2", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_Phone2Column);

            EOE_RemarkColumn = new DataColumn("EOE_Remark", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_RemarkColumn);

            EOE_SexColumn = new DataColumn("EOE_Sex", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_SexColumn);

            EOE_SexName_XXColumn = new DataColumn("EOE_SexName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_SexName_XXColumn);

            EOE_SignatureColumn = new DataColumn("EOE_Signature", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_SignatureColumn);

            EOE_SmsNumberColumn = new DataColumn("EOE_SmsNumber", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOE_SmsNumberColumn);

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { EOE_EmployeeIdColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new EO_EmployeeRow(builder);
        }

    }

    ///<summary>
    ///&lt;EOE&gt;人員{Employee}  
    ///</summary>
    public class EO_EmployeeRow : FtdDataRow
    {
        private EO_EmployeeDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal EO_EmployeeRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((EO_EmployeeDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public EO_EmployeeDataTable TypeTable
        {
            get { return (EO_EmployeeDataTable)Table; }
        }

        ///<summary>
        ///[DIRECT]*人員ID{EmployeeId}：【PK&lt;EOE&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_EmployeeId
        {
            get { return getAttrGetString(this[theTable.EOE_EmployeeIdColumn]); }
            set { this[theTable.EOE_EmployeeIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*通訊住址{CAddress:50} 【高雄市 海邊路119巷37號】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_CAddress
        {
            get { return getAttrGetString(this[theTable.EOE_CAddressColumn]); }
            set { this[theTable.EOE_CAddressColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]#人員是否為目前登入者{CU_IsLoginUser_XX}：○{T}是 ○{F}不是  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_CU_IsLoginUser_XX
        {
            get { return getAttrGetString(this[theTable.EOE_CU_IsLoginUser_XXColumn]); }
            set { this[theTable.EOE_CU_IsLoginUser_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*郵遞區號{CZip:10} 【71804】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_CZip
        {
            get { return getAttrGetString(this[theTable.EOE_CZipColumn]); }
            set { this[theTable.EOE_CZipColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]部門代號{DepartmentCode:50}：【AB0913】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_DepartmentCode_XX
        {
            get { return getAttrGetString(this[theTable.EOE_DepartmentCode_XXColumn]); }
            set { this[theTable.EOE_DepartmentCode_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///#完整部門名稱{DepartmentFullName_XX}：【市政府\資訊中心】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_DepartmentFullName_XX
        {
            get { return getAttrGetString(this[theTable.EOE_DepartmentFullName_XXColumn]); }
            set { this[theTable.EOE_DepartmentFullName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*部門{DepartmentId, DepartmentName_XX}：【&lt;EOD&gt;,資訊中心】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_DepartmentId
        {
            get { return getAttrGetString(this[theTable.EOE_DepartmentIdColumn]); }
            set { this[theTable.EOE_DepartmentIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*部門名稱{DepartmentName:50}：【資訊中心】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_DepartmentName_XX
        {
            get { return getAttrGetString(this[theTable.EOE_DepartmentName_XXColumn]); }
            set { this[theTable.EOE_DepartmentName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]人員編號{EmployeeCode:20}：【EA001】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_EmployeeCode
        {
            get { return getAttrGetString(this[theTable.EOE_EmployeeCodeColumn]); }
            set { this[theTable.EOE_EmployeeCodeColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*Email{EmployeeEmail:50}：【shengwen@mail2000.com.tw】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_EmployeeEmail
        {
            get { return getAttrGetString(this[theTable.EOE_EmployeeEmailColumn]); }
            set { this[theTable.EOE_EmployeeEmailColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]#完整姓名{EmployeeFullName_XX}：【市政府-林勝文 組長】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_EmployeeFullName_XX
        {
            get { return getAttrGetString(this[theTable.EOE_EmployeeFullName_XXColumn]); }
            set { this[theTable.EOE_EmployeeFullName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*人員姓名{EmployeeName:20}：【林勝文】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_EmployeeName
        {
            get { return getAttrGetString(this[theTable.EOE_EmployeeNameColumn]); }
            set { this[theTable.EOE_EmployeeNameColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]#搜尋用名稱 {EmployeeSearchName_XX}：【林勝文 組長 (shengwen@mail2000.com.tw)】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_EmployeeSearchName_XX
        {
            get { return getAttrGetString(this[theTable.EOE_EmployeeSearchName_XXColumn]); }
            set { this[theTable.EOE_EmployeeSearchName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]身分証字號{EmployeeSid:20}：【R122322555】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_EmployeeSid
        {
            get { return getAttrGetString(this[theTable.EOE_EmployeeSidColumn]); }
            set { this[theTable.EOE_EmployeeSidColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]#標準姓名{EmployeeStandardName_XX}：【林勝文 組長】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_EmployeeStandardName_XX
        {
            get { return getAttrGetString(this[theTable.EOE_EmployeeStandardName_XXColumn]); }
            set { this[theTable.EOE_EmployeeStandardName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]職稱代號 {TitleCode:20}：【A312】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_EmployeeTitleCode_XX
        {
            get { return getAttrGetString(this[theTable.EOE_EmployeeTitleCode_XXColumn]); }
            set { this[theTable.EOE_EmployeeTitleCode_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*職稱{EmployeeTitleId, EmployeeTitleName_XX, EmployeeTitleCode_XX}：【&lt;EOET&gt;,主任,B01】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_EmployeeTitleId
        {
            get { return getAttrGetString(this[theTable.EOE_EmployeeTitleIdColumn]); }
            set { this[theTable.EOE_EmployeeTitleIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*職稱名稱{TitleName:20}：【組長】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_EmployeeTitleName_XX
        {
            get { return getAttrGetString(this[theTable.EOE_EmployeeTitleName_XXColumn]); }
            set { this[theTable.EOE_EmployeeTitleName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]是否啟用【T：是 / F：否】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_Enabled
        {
            get { return getAttrGetString(this[theTable.EOE_EnabledColumn]); }
            set { this[theTable.EOE_EnabledColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*任職日期{EntryDate:D}：【2006/09/19】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? EOE_EntryDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.EOE_EntryDateColumn]); }
            set { this[this.theTable.EOE_EntryDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///[DIRECT]#是否離職{IsLeave_XX}：○{T}是 ○{F}不是  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_IsLeave_XX
        {
            get { return getAttrGetString(this[theTable.EOE_IsLeave_XXColumn]); }
            set { this[theTable.EOE_IsLeave_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]離職日期{LeaveDate:D}：【2006/10/19】(※填此日期代表已離職，否則為在職)  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? EOE_LeaveDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.EOE_LeaveDateColumn]); }
            set { this[this.theTable.EOE_LeaveDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///[DIRECT]*登入帳號{LoginAccount:50}：【Administrator】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_LoginAccount_XX
        {
            get { return getAttrGetString(this[theTable.EOE_LoginAccount_XXColumn]); }
            set { this[theTable.EOE_LoginAccount_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*登入密碼{LoginPassword:20}：【XYXCDE】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_LoginPassword_XX
        {
            get { return getAttrGetString(this[theTable.EOE_LoginPassword_XXColumn]); }
            set { this[theTable.EOE_LoginPassword_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]個人圖片{PersonalImage:50}：【XXXXXX00-00011.GIF】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_PersonalImage
        {
            get { return getAttrGetString(this[theTable.EOE_PersonalImageColumn]); }
            set { this[theTable.EOE_PersonalImageColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]聯絡電話1{Phone1:20}：【06-5951579】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_Phone1
        {
            get { return getAttrGetString(this[theTable.EOE_Phone1Column]); }
            set { this[theTable.EOE_Phone1Column] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]聯絡電話2{Phone2:20}：【0913670599】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_Phone2
        {
            get { return getAttrGetString(this[theTable.EOE_Phone2Column]); }
            set { this[theTable.EOE_Phone2Column] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]備註{Remark:100}：【此員工表現良好】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_Remark
        {
            get { return getAttrGetString(this[theTable.EOE_RemarkColumn]); }
            set { this[theTable.EOE_RemarkColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]性別{Sex:1,SexName_XX}：○{Name}男 ○{Name_U}女  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_Sex
        {
            get { return getAttrGetString(this[theTable.EOE_SexColumn]); }
            set { this[theTable.EOE_SexColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]性別{Sex:1,SexName_XX}：○{Name}男 ○{Name_U}女  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_SexName_XX
        {
            get { return getAttrGetString(this[theTable.EOE_SexName_XXColumn]); }
            set { this[theTable.EOE_SexName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]簽名檔：{Signature:100}：【我很笨但我很溫柔】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_Signature
        {
            get { return getAttrGetString(this[theTable.EOE_SignatureColumn]); }
            set { this[theTable.EOE_SignatureColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*簡訊通知號碼{SmsNumber:20}：【0913670599】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOE_SmsNumber
        {
            get { return getAttrGetString(this[theTable.EOE_SmsNumberColumn]); }
            set { this[theTable.EOE_SmsNumberColumn] = getAttrSetString(value); }
        }

    }
}
