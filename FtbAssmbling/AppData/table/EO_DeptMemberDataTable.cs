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
    /// &lt;EODM&gt;部門成員{DeptMember}
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class EO_DeptMemberDataTable : FtdTypedDataTable<EO_DeptMemberRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public EO_DeptMemberDataTable() : base("EO_DeptMember")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new EO_DeptMemberDataTable();
            return getTableSchema(xs, dt, "EODM");
        }

        [DebuggerNonUserCodeAttribute()]
        protected EO_DeptMemberDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// [DIRECT]*PrimaryKey{DeptMemberId}：【PK&lt;EODM&gt;】
        /// </summary> 
        public DataColumn EODM_DeptMemberIdColumn;

        /// <summary>
        /// [DIRECT]部門代號{DepartmentCode:50}：【AB0913】&lt;br/&gt;
        /// </summary> 
        public DataColumn EODM_DeptCode_XXColumn;

        /// <summary>
        /// [DIRECT]*部門Id{DeptId}：【&lt;EOD&gt;】
        /// </summary> 
        public DataColumn EODM_DeptIdColumn;

        /// <summary>
        /// [DIRECT]*部門名稱{DepartmentName:50}：【資訊中心】&lt;br/&gt;
        /// </summary> 
        public DataColumn EODM_DeptName_XXColumn;

        /// <summary>
        /// [DIRECT]*部門類型{DepartmentType:1,DepartmentTypeName_XX}：○{Name}正式部門 ○{Name_U}會員群組&lt;br/&gt;
        /// </summary> 
        public DataColumn EODM_DeptType_XXColumn;

        /// <summary>
        /// [DIRECT]*部門類型{DepartmentType:1,DepartmentTypeName_XX}：○{Name}部門 ○{Name_U}群組&lt;br/&gt;
        /// </summary> 
        public DataColumn EODM_DeptTypeName_XXColumn;

        /// <summary>
        /// [DIRECT]人員編號{EmployeeCode:20}：【EA001】&lt;br/&gt;
        /// </summary> 
        public DataColumn EODM_EmpCode_XXColumn;

        /// <summary>
        /// [DIRECT]*部門{DepartmentId, DepartmentName_XX}：【&lt;EOD&gt;,資訊中心】&lt;br/&gt;
        /// </summary> 
        public DataColumn EODM_EmpDeptId_XXColumn;

        /// <summary>
        /// [DIRECT]*部門{DepartmentId, DepartmentName_XX}：【&lt;EOD&gt;,資訊中心】&lt;br/&gt;
        /// </summary> 
        public DataColumn EODM_EmpDeptName_XXColumn;

        /// <summary>
        /// [DIRECT]*Email{EmployeeEmail:50}：【shengwen@mail2000.com.tw】&lt;br/&gt;
        /// </summary> 
        public DataColumn EODM_EmpEmail_XXColumn;

        /// <summary>
        /// [DIRECT]#完整姓名{EmployeeFullName_XX}：【市政府-林勝文 組長】&lt;br/&gt;
        /// </summary> 
        public DataColumn EODM_EmpFullName_XXColumn;

        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        public DataColumn EODM_EmpName_XXColumn;

        /// <summary>
        /// [DIRECT]性別{Sex:1,SexName_XX}：○{Name}男 ○{Name_U}女&lt;br/&gt;
        /// </summary> 
        public DataColumn EODM_EmpSex_XXColumn;

        /// <summary>
        /// [DIRECT]性別{Sex:1,SexName_XX}：○{Name}男 ○{Name_U}女&lt;br/&gt;
        /// </summary> 
        public DataColumn EODM_EmpSexName_XXColumn;

        /// <summary>
        /// [DIRECT]身分証字號{EmployeeSid:20}：【R122322555】&lt;br/&gt;
        /// </summary> 
        public DataColumn EODM_EmpSid_XXColumn;

        /// <summary>
        /// [DIRECT]*職稱{EmployeeTitleId, EmployeeTitleName_XX, EmployeeTitleCode_XX}：【&lt;EOET&gt;,主任,B01】&lt;br/&gt;
        /// </summary> 
        public DataColumn EODM_EmpTitleId_XXColumn;

        /// <summary>
        /// [DIRECT]*職稱{EmployeeTitleId, EmployeeTitleName_XX, EmployeeTitleCode_XX}：【&lt;EOET&gt;,主任,B01】&lt;br/&gt;
        /// </summary> 
        public DataColumn EODM_EmpTitleName_XXColumn;

        /// <summary>
        /// [DIRECT]部門代號{DepartmentCode:50}：【AB0913】&lt;br/&gt;
        /// </summary> 
        public DataColumn EODM_M_DepCode_XXColumn;

        /// <summary>
        /// [DIRECT]*部門名稱{DepartmentName:50}：【資訊中心】&lt;br/&gt;
        /// </summary> 
        public DataColumn EODM_M_DeptName_XXColumn;

        /// <summary>
        /// [DIRECT]*部門類型{DepartmentType:1,DepartmentTypeName_XX}：○{Name}正式部門 ○{Name_U}會員群組&lt;br/&gt;
        /// </summary> 
        public DataColumn EODM_M_DeptType_XXColumn;

        /// <summary>
        /// [DIRECT]*部門類型{DepartmentType:1,DepartmentTypeName_XX}：○{Name}部門 ○{Name_U}群組&lt;br/&gt;
        /// </summary> 
        public DataColumn EODM_M_DeptTypeName_XXColumn;

        /// <summary>
        /// [DIRECT]*成員Id{MemberId}：【&lt;EOD|EOE&gt;】
        /// </summary> 
        public DataColumn EODM_MemberIdColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public EO_DeptMemberRow findByPrimaryKey(String EODM_DeptMemberId)
        {
            return (EO_DeptMemberRow)(Rows.Find(new object[] { EODM_DeptMemberId }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new EO_DeptMemberDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            EODM_DeptMemberIdColumn = Columns["EODM_DeptMemberId"];
            EODM_DeptCode_XXColumn = Columns["EODM_DeptCode_XX"];
            EODM_DeptIdColumn = Columns["EODM_DeptId"];
            EODM_DeptName_XXColumn = Columns["EODM_DeptName_XX"];
            EODM_DeptType_XXColumn = Columns["EODM_DeptType_XX"];
            EODM_DeptTypeName_XXColumn = Columns["EODM_DeptTypeName_XX"];
            EODM_EmpCode_XXColumn = Columns["EODM_EmpCode_XX"];
            EODM_EmpDeptId_XXColumn = Columns["EODM_EmpDeptId_XX"];
            EODM_EmpDeptName_XXColumn = Columns["EODM_EmpDeptName_XX"];
            EODM_EmpEmail_XXColumn = Columns["EODM_EmpEmail_XX"];
            EODM_EmpFullName_XXColumn = Columns["EODM_EmpFullName_XX"];
            EODM_EmpName_XXColumn = Columns["EODM_EmpName_XX"];
            EODM_EmpSex_XXColumn = Columns["EODM_EmpSex_XX"];
            EODM_EmpSexName_XXColumn = Columns["EODM_EmpSexName_XX"];
            EODM_EmpSid_XXColumn = Columns["EODM_EmpSid_XX"];
            EODM_EmpTitleId_XXColumn = Columns["EODM_EmpTitleId_XX"];
            EODM_EmpTitleName_XXColumn = Columns["EODM_EmpTitleName_XX"];
            EODM_M_DepCode_XXColumn = Columns["EODM_M_DepCode_XX"];
            EODM_M_DeptName_XXColumn = Columns["EODM_M_DeptName_XX"];
            EODM_M_DeptType_XXColumn = Columns["EODM_M_DeptType_XX"];
            EODM_M_DeptTypeName_XXColumn = Columns["EODM_M_DeptTypeName_XX"];
            EODM_MemberIdColumn = Columns["EODM_MemberId"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            EODM_DeptMemberIdColumn = new DataColumn("EODM_DeptMemberId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EODM_DeptMemberIdColumn);
            EODM_DeptMemberIdColumn.AllowDBNull = false;

            EODM_DeptCode_XXColumn = new DataColumn("EODM_DeptCode_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EODM_DeptCode_XXColumn);

            EODM_DeptIdColumn = new DataColumn("EODM_DeptId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EODM_DeptIdColumn);

            EODM_DeptName_XXColumn = new DataColumn("EODM_DeptName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EODM_DeptName_XXColumn);

            EODM_DeptType_XXColumn = new DataColumn("EODM_DeptType_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EODM_DeptType_XXColumn);

            EODM_DeptTypeName_XXColumn = new DataColumn("EODM_DeptTypeName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EODM_DeptTypeName_XXColumn);

            EODM_EmpCode_XXColumn = new DataColumn("EODM_EmpCode_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EODM_EmpCode_XXColumn);

            EODM_EmpDeptId_XXColumn = new DataColumn("EODM_EmpDeptId_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EODM_EmpDeptId_XXColumn);

            EODM_EmpDeptName_XXColumn = new DataColumn("EODM_EmpDeptName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EODM_EmpDeptName_XXColumn);

            EODM_EmpEmail_XXColumn = new DataColumn("EODM_EmpEmail_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EODM_EmpEmail_XXColumn);

            EODM_EmpFullName_XXColumn = new DataColumn("EODM_EmpFullName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EODM_EmpFullName_XXColumn);

            EODM_EmpName_XXColumn = new DataColumn("EODM_EmpName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EODM_EmpName_XXColumn);

            EODM_EmpSex_XXColumn = new DataColumn("EODM_EmpSex_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EODM_EmpSex_XXColumn);

            EODM_EmpSexName_XXColumn = new DataColumn("EODM_EmpSexName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EODM_EmpSexName_XXColumn);

            EODM_EmpSid_XXColumn = new DataColumn("EODM_EmpSid_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EODM_EmpSid_XXColumn);

            EODM_EmpTitleId_XXColumn = new DataColumn("EODM_EmpTitleId_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EODM_EmpTitleId_XXColumn);

            EODM_EmpTitleName_XXColumn = new DataColumn("EODM_EmpTitleName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EODM_EmpTitleName_XXColumn);

            EODM_M_DepCode_XXColumn = new DataColumn("EODM_M_DepCode_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EODM_M_DepCode_XXColumn);

            EODM_M_DeptName_XXColumn = new DataColumn("EODM_M_DeptName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EODM_M_DeptName_XXColumn);

            EODM_M_DeptType_XXColumn = new DataColumn("EODM_M_DeptType_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EODM_M_DeptType_XXColumn);

            EODM_M_DeptTypeName_XXColumn = new DataColumn("EODM_M_DeptTypeName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EODM_M_DeptTypeName_XXColumn);

            EODM_MemberIdColumn = new DataColumn("EODM_MemberId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EODM_MemberIdColumn);

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { EODM_DeptMemberIdColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new EO_DeptMemberRow(builder);
        }

    }

    ///<summary>
    ///&lt;EODM&gt;部門成員{DeptMember}  
    ///</summary>
    public class EO_DeptMemberRow : FtdDataRow
    {
        private EO_DeptMemberDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal EO_DeptMemberRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((EO_DeptMemberDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public EO_DeptMemberDataTable TypeTable
        {
            get { return (EO_DeptMemberDataTable)Table; }
        }

        ///<summary>
        ///[DIRECT]*PrimaryKey{DeptMemberId}：【PK&lt;EODM&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EODM_DeptMemberId
        {
            get { return getAttrGetString(this[theTable.EODM_DeptMemberIdColumn]); }
            set { this[theTable.EODM_DeptMemberIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]部門代號{DepartmentCode:50}：【AB0913】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EODM_DeptCode_XX
        {
            get { return getAttrGetString(this[theTable.EODM_DeptCode_XXColumn]); }
            set { this[theTable.EODM_DeptCode_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*部門Id{DeptId}：【&lt;EOD&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EODM_DeptId
        {
            get { return getAttrGetString(this[theTable.EODM_DeptIdColumn]); }
            set { this[theTable.EODM_DeptIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*部門名稱{DepartmentName:50}：【資訊中心】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EODM_DeptName_XX
        {
            get { return getAttrGetString(this[theTable.EODM_DeptName_XXColumn]); }
            set { this[theTable.EODM_DeptName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*部門類型{DepartmentType:1,DepartmentTypeName_XX}：○{Name}正式部門 ○{Name_U}會員群組&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EODM_DeptType_XX
        {
            get { return getAttrGetString(this[theTable.EODM_DeptType_XXColumn]); }
            set { this[theTable.EODM_DeptType_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*部門類型{DepartmentType:1,DepartmentTypeName_XX}：○{Name}部門 ○{Name_U}群組&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EODM_DeptTypeName_XX
        {
            get { return getAttrGetString(this[theTable.EODM_DeptTypeName_XXColumn]); }
            set { this[theTable.EODM_DeptTypeName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]人員編號{EmployeeCode:20}：【EA001】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EODM_EmpCode_XX
        {
            get { return getAttrGetString(this[theTable.EODM_EmpCode_XXColumn]); }
            set { this[theTable.EODM_EmpCode_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*部門{DepartmentId, DepartmentName_XX}：【&lt;EOD&gt;,資訊中心】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EODM_EmpDeptId_XX
        {
            get { return getAttrGetString(this[theTable.EODM_EmpDeptId_XXColumn]); }
            set { this[theTable.EODM_EmpDeptId_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*部門{DepartmentId, DepartmentName_XX}：【&lt;EOD&gt;,資訊中心】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EODM_EmpDeptName_XX
        {
            get { return getAttrGetString(this[theTable.EODM_EmpDeptName_XXColumn]); }
            set { this[theTable.EODM_EmpDeptName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*Email{EmployeeEmail:50}：【shengwen@mail2000.com.tw】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EODM_EmpEmail_XX
        {
            get { return getAttrGetString(this[theTable.EODM_EmpEmail_XXColumn]); }
            set { this[theTable.EODM_EmpEmail_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]#完整姓名{EmployeeFullName_XX}：【市政府-林勝文 組長】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EODM_EmpFullName_XX
        {
            get { return getAttrGetString(this[theTable.EODM_EmpFullName_XXColumn]); }
            set { this[theTable.EODM_EmpFullName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EODM_EmpName_XX
        {
            get { return getAttrGetString(this[theTable.EODM_EmpName_XXColumn]); }
            set { this[theTable.EODM_EmpName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]性別{Sex:1,SexName_XX}：○{Name}男 ○{Name_U}女&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EODM_EmpSex_XX
        {
            get { return getAttrGetString(this[theTable.EODM_EmpSex_XXColumn]); }
            set { this[theTable.EODM_EmpSex_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]性別{Sex:1,SexName_XX}：○{Name}男 ○{Name_U}女&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EODM_EmpSexName_XX
        {
            get { return getAttrGetString(this[theTable.EODM_EmpSexName_XXColumn]); }
            set { this[theTable.EODM_EmpSexName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]身分証字號{EmployeeSid:20}：【R122322555】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EODM_EmpSid_XX
        {
            get { return getAttrGetString(this[theTable.EODM_EmpSid_XXColumn]); }
            set { this[theTable.EODM_EmpSid_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*職稱{EmployeeTitleId, EmployeeTitleName_XX, EmployeeTitleCode_XX}：【&lt;EOET&gt;,主任,B01】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EODM_EmpTitleId_XX
        {
            get { return getAttrGetString(this[theTable.EODM_EmpTitleId_XXColumn]); }
            set { this[theTable.EODM_EmpTitleId_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*職稱{EmployeeTitleId, EmployeeTitleName_XX, EmployeeTitleCode_XX}：【&lt;EOET&gt;,主任,B01】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EODM_EmpTitleName_XX
        {
            get { return getAttrGetString(this[theTable.EODM_EmpTitleName_XXColumn]); }
            set { this[theTable.EODM_EmpTitleName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]部門代號{DepartmentCode:50}：【AB0913】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EODM_M_DepCode_XX
        {
            get { return getAttrGetString(this[theTable.EODM_M_DepCode_XXColumn]); }
            set { this[theTable.EODM_M_DepCode_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*部門名稱{DepartmentName:50}：【資訊中心】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EODM_M_DeptName_XX
        {
            get { return getAttrGetString(this[theTable.EODM_M_DeptName_XXColumn]); }
            set { this[theTable.EODM_M_DeptName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*部門類型{DepartmentType:1,DepartmentTypeName_XX}：○{Name}正式部門 ○{Name_U}會員群組&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EODM_M_DeptType_XX
        {
            get { return getAttrGetString(this[theTable.EODM_M_DeptType_XXColumn]); }
            set { this[theTable.EODM_M_DeptType_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*部門類型{DepartmentType:1,DepartmentTypeName_XX}：○{Name}部門 ○{Name_U}群組&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EODM_M_DeptTypeName_XX
        {
            get { return getAttrGetString(this[theTable.EODM_M_DeptTypeName_XXColumn]); }
            set { this[theTable.EODM_M_DeptTypeName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*成員Id{MemberId}：【&lt;EOD|EOE&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EODM_MemberId
        {
            get { return getAttrGetString(this[theTable.EODM_MemberIdColumn]); }
            set { this[theTable.EODM_MemberIdColumn] = getAttrSetString(value); }
        }

    }
}
