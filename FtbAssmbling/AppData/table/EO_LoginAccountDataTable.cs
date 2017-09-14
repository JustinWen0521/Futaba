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
    /// &lt;EOLA&gt;登入帳號{LoginAccount}
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class EO_LoginAccountDataTable : FtdTypedDataTable<EO_LoginAccountRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public EO_LoginAccountDataTable() : base("EO_LoginAccount")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new EO_LoginAccountDataTable();
            return getTableSchema(xs, dt, "EOLA");
        }

        [DebuggerNonUserCodeAttribute()]
        protected EO_LoginAccountDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// [DIRECT]*登入者Id{LoginAccountId}：【PK&lt;EOE&gt;】
        /// </summary> 
        public DataColumn EOLA_LoginAccountIdColumn;

        /// <summary>
        /// [DIRECT]登入失敗次數{FailureCount:INT}：【3】
        /// </summary> 
        public DataColumn EOLA_FailureCountColumn;

        /// <summary>
        /// [DIRECT]失敗停權日期{FailureDate:D}：【2006/09/19 13:20:20】
        /// </summary> 
        public DataColumn EOLA_FailureDateColumn;

        /// <summary>
        /// [DIRECT]帳號啟用{IsEnable:1,IsEnableName_XX}：○{T}啟用 ○{F}停用
        /// </summary> 
        public DataColumn EOLA_IsEnableColumn;

        /// <summary>
        /// [DIRECT]帳號啟用{IsEnable:1,IsEnableName_XX}：○{T}啟用 ○{F}停用
        /// </summary> 
        public DataColumn EOLA_IsEnableName_XXColumn;

        /// <summary>
        /// [DIRECT]最後登入日期{LastLoginDate:D}：【2006/09/19 13:20:20】
        /// </summary> 
        public DataColumn EOLA_LastLoginDateColumn;

        /// <summary>
        /// [DIRECT]*登入帳號{LoginAccount:50}：【Administrator】
        /// </summary> 
        public DataColumn EOLA_LoginAccountColumn;

        /// <summary>
        /// [DIRECT]*登入密碼{LoginPassword:20}：【XYXCDE】
        /// </summary> 
        public DataColumn EOLA_LoginPasswordColumn;

        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOLA_UserEmail_XXColumn;

        /// <summary>
        /// [DIRECT]#標準姓名{EmployeeStandardName_XX}：【林勝文 組長】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOLA_UserName_XXColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public EO_LoginAccountRow findByPrimaryKey(String EOLA_LoginAccountId)
        {
            return (EO_LoginAccountRow)(Rows.Find(new object[] { EOLA_LoginAccountId }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new EO_LoginAccountDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            EOLA_LoginAccountIdColumn = Columns["EOLA_LoginAccountId"];
            EOLA_FailureCountColumn = Columns["EOLA_FailureCount"];
            EOLA_FailureDateColumn = Columns["EOLA_FailureDate"];
            EOLA_IsEnableColumn = Columns["EOLA_IsEnable"];
            EOLA_IsEnableName_XXColumn = Columns["EOLA_IsEnableName_XX"];
            EOLA_LastLoginDateColumn = Columns["EOLA_LastLoginDate"];
            EOLA_LoginAccountColumn = Columns["EOLA_LoginAccount"];
            EOLA_LoginPasswordColumn = Columns["EOLA_LoginPassword"];
            EOLA_UserEmail_XXColumn = Columns["EOLA_UserEmail_XX"];
            EOLA_UserName_XXColumn = Columns["EOLA_UserName_XX"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            EOLA_LoginAccountIdColumn = new DataColumn("EOLA_LoginAccountId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOLA_LoginAccountIdColumn);
            EOLA_LoginAccountIdColumn.AllowDBNull = false;

            EOLA_FailureCountColumn = new DataColumn("EOLA_FailureCount", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(EOLA_FailureCountColumn);

            EOLA_FailureDateColumn = new DataColumn("EOLA_FailureDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(EOLA_FailureDateColumn);

            EOLA_IsEnableColumn = new DataColumn("EOLA_IsEnable", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOLA_IsEnableColumn);

            EOLA_IsEnableName_XXColumn = new DataColumn("EOLA_IsEnableName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOLA_IsEnableName_XXColumn);

            EOLA_LastLoginDateColumn = new DataColumn("EOLA_LastLoginDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(EOLA_LastLoginDateColumn);

            EOLA_LoginAccountColumn = new DataColumn("EOLA_LoginAccount", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOLA_LoginAccountColumn);

            EOLA_LoginPasswordColumn = new DataColumn("EOLA_LoginPassword", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOLA_LoginPasswordColumn);

            EOLA_UserEmail_XXColumn = new DataColumn("EOLA_UserEmail_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOLA_UserEmail_XXColumn);

            EOLA_UserName_XXColumn = new DataColumn("EOLA_UserName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOLA_UserName_XXColumn);

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { EOLA_LoginAccountIdColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new EO_LoginAccountRow(builder);
        }

    }

    ///<summary>
    ///&lt;EOLA&gt;登入帳號{LoginAccount}  
    ///</summary>
    public class EO_LoginAccountRow : FtdDataRow
    {
        private EO_LoginAccountDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal EO_LoginAccountRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((EO_LoginAccountDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public EO_LoginAccountDataTable TypeTable
        {
            get { return (EO_LoginAccountDataTable)Table; }
        }

        ///<summary>
        ///[DIRECT]*登入者Id{LoginAccountId}：【PK&lt;EOE&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOLA_LoginAccountId
        {
            get { return getAttrGetString(this[theTable.EOLA_LoginAccountIdColumn]); }
            set { this[theTable.EOLA_LoginAccountIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]登入失敗次數{FailureCount:INT}：【3】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? EOLA_FailureCount
        {
            get { return getAttrGetValue<Int32>(this[theTable.EOLA_FailureCountColumn]); }
            set { this[this.theTable.EOLA_FailureCountColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///[DIRECT]失敗停權日期{FailureDate:D}：【2006/09/19 13:20:20】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? EOLA_FailureDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.EOLA_FailureDateColumn]); }
            set { this[this.theTable.EOLA_FailureDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///[DIRECT]帳號啟用{IsEnable:1,IsEnableName_XX}：○{T}啟用 ○{F}停用  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOLA_IsEnable
        {
            get { return getAttrGetString(this[theTable.EOLA_IsEnableColumn]); }
            set { this[theTable.EOLA_IsEnableColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]帳號啟用{IsEnable:1,IsEnableName_XX}：○{T}啟用 ○{F}停用  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOLA_IsEnableName_XX
        {
            get { return getAttrGetString(this[theTable.EOLA_IsEnableName_XXColumn]); }
            set { this[theTable.EOLA_IsEnableName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]最後登入日期{LastLoginDate:D}：【2006/09/19 13:20:20】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? EOLA_LastLoginDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.EOLA_LastLoginDateColumn]); }
            set { this[this.theTable.EOLA_LastLoginDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///[DIRECT]*登入帳號{LoginAccount:50}：【Administrator】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOLA_LoginAccount
        {
            get { return getAttrGetString(this[theTable.EOLA_LoginAccountColumn]); }
            set { this[theTable.EOLA_LoginAccountColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*登入密碼{LoginPassword:20}：【XYXCDE】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOLA_LoginPassword
        {
            get { return getAttrGetString(this[theTable.EOLA_LoginPasswordColumn]); }
            set { this[theTable.EOLA_LoginPasswordColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOLA_UserEmail_XX
        {
            get { return getAttrGetString(this[theTable.EOLA_UserEmail_XXColumn]); }
            set { this[theTable.EOLA_UserEmail_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]#標準姓名{EmployeeStandardName_XX}：【林勝文 組長】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOLA_UserName_XX
        {
            get { return getAttrGetString(this[theTable.EOLA_UserName_XXColumn]); }
            set { this[theTable.EOLA_UserName_XXColumn] = getAttrSetString(value); }
        }

    }
}
