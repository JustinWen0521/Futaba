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
    /// &lt;EOPS&gt;權限設定表{PermissonSetting}
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class EO_PermissionSettingDataTable : FtdTypedDataTable<EO_PermissionSettingRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public EO_PermissionSettingDataTable() : base("EO_PermissionSetting")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new EO_PermissionSettingDataTable();
            return getTableSchema(xs, dt, "EOPS");
        }

        [DebuggerNonUserCodeAttribute()]
        protected EO_PermissionSettingDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// [DIRECT]*權限設定Id{PermissionSettingId}：【PK&lt;EOPS&gt;】
        /// </summary> 
        public DataColumn EOPS_PermissionSettingIdColumn;

        /// <summary>
        /// [DIRECT]*開放給每個人：A:是 B:否             ※若為是，則不用設定表每個人皆可使用&lt;br/&gt;
        /// </summary> 
        public DataColumn EOPS_IsEveryOneAllow_XXColumn;

        /// <summary>
        /// [DIRECT]*需指定物件：A:是 B:否             ※若為是，則該權限需另外指派物件.&lt;br/&gt;
        /// </summary> 
        public DataColumn EOPS_IsObjectNeed_XXColumn;

        /// <summary>
        /// [DIRECT]權限物Id{ObjectId}：【&lt;KEY&gt;】※若IsObjectNedd為是，則該需指派物件
        /// </summary> 
        public DataColumn EOPS_ObjectIdColumn;

        /// <summary>
        /// [DIRECT]#權限物名稱{ObjectName_XX}：【[部門]資訊中心】
        /// </summary> 
        public DataColumn EOPS_ObjectName_XXColumn;

        /// <summary>
        /// [DIRECT]*權限CODE{PermissionCode:50}：【APN_KM_Admin】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOPS_PermissionCode_XXColumn;

        /// <summary>
        /// [DIRECT]*權限ID{PermissionId}:【KEY&lt;EOP&gt;】
        /// </summary> 
        public DataColumn EOPS_PermissionIdColumn;

        /// <summary>
        /// [DIRECT]*權限名稱{PermissionName:50}：【系統\KM\系統管理員】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOPS_PermissionName_XXColumn;

        /// <summary>
        /// [DIRECT]*人員ID{PermissionUserId}：【KEY&lt;EOE&gt;|KEY&lt;EOD&gt;】
        /// </summary> 
        public DataColumn EOPS_PermissionUserIdColumn;

        /// <summary>
        /// [DIRECT]*部門名稱{DepartmentName:50}：【資訊中心】&lt;br/&gt;#完整姓名{EmployeeFullName_XX}：【市政府-林勝文 組長】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOPS_PermissionUserName_XXColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public EO_PermissionSettingRow findByPrimaryKey(String EOPS_PermissionSettingId)
        {
            return (EO_PermissionSettingRow)(Rows.Find(new object[] { EOPS_PermissionSettingId }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new EO_PermissionSettingDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            EOPS_PermissionSettingIdColumn = Columns["EOPS_PermissionSettingId"];
            EOPS_IsEveryOneAllow_XXColumn = Columns["EOPS_IsEveryOneAllow_XX"];
            EOPS_IsObjectNeed_XXColumn = Columns["EOPS_IsObjectNeed_XX"];
            EOPS_ObjectIdColumn = Columns["EOPS_ObjectId"];
            EOPS_ObjectName_XXColumn = Columns["EOPS_ObjectName_XX"];
            EOPS_PermissionCode_XXColumn = Columns["EOPS_PermissionCode_XX"];
            EOPS_PermissionIdColumn = Columns["EOPS_PermissionId"];
            EOPS_PermissionName_XXColumn = Columns["EOPS_PermissionName_XX"];
            EOPS_PermissionUserIdColumn = Columns["EOPS_PermissionUserId"];
            EOPS_PermissionUserName_XXColumn = Columns["EOPS_PermissionUserName_XX"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            EOPS_PermissionSettingIdColumn = new DataColumn("EOPS_PermissionSettingId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOPS_PermissionSettingIdColumn);
            EOPS_PermissionSettingIdColumn.AllowDBNull = false;

            EOPS_IsEveryOneAllow_XXColumn = new DataColumn("EOPS_IsEveryOneAllow_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOPS_IsEveryOneAllow_XXColumn);

            EOPS_IsObjectNeed_XXColumn = new DataColumn("EOPS_IsObjectNeed_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOPS_IsObjectNeed_XXColumn);

            EOPS_ObjectIdColumn = new DataColumn("EOPS_ObjectId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOPS_ObjectIdColumn);

            EOPS_ObjectName_XXColumn = new DataColumn("EOPS_ObjectName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOPS_ObjectName_XXColumn);

            EOPS_PermissionCode_XXColumn = new DataColumn("EOPS_PermissionCode_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOPS_PermissionCode_XXColumn);

            EOPS_PermissionIdColumn = new DataColumn("EOPS_PermissionId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOPS_PermissionIdColumn);

            EOPS_PermissionName_XXColumn = new DataColumn("EOPS_PermissionName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOPS_PermissionName_XXColumn);

            EOPS_PermissionUserIdColumn = new DataColumn("EOPS_PermissionUserId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOPS_PermissionUserIdColumn);

            EOPS_PermissionUserName_XXColumn = new DataColumn("EOPS_PermissionUserName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOPS_PermissionUserName_XXColumn);

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { EOPS_PermissionSettingIdColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new EO_PermissionSettingRow(builder);
        }

    }

    ///<summary>
    ///&lt;EOPS&gt;權限設定表{PermissonSetting}  
    ///</summary>
    public class EO_PermissionSettingRow : FtdDataRow
    {
        private EO_PermissionSettingDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal EO_PermissionSettingRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((EO_PermissionSettingDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public EO_PermissionSettingDataTable TypeTable
        {
            get { return (EO_PermissionSettingDataTable)Table; }
        }

        ///<summary>
        ///[DIRECT]*權限設定Id{PermissionSettingId}：【PK&lt;EOPS&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOPS_PermissionSettingId
        {
            get { return getAttrGetString(this[theTable.EOPS_PermissionSettingIdColumn]); }
            set { this[theTable.EOPS_PermissionSettingIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*開放給每個人：A:是 B:否             ※若為是，則不用設定表每個人皆可使用&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOPS_IsEveryOneAllow_XX
        {
            get { return getAttrGetString(this[theTable.EOPS_IsEveryOneAllow_XXColumn]); }
            set { this[theTable.EOPS_IsEveryOneAllow_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*需指定物件：A:是 B:否             ※若為是，則該權限需另外指派物件.&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOPS_IsObjectNeed_XX
        {
            get { return getAttrGetString(this[theTable.EOPS_IsObjectNeed_XXColumn]); }
            set { this[theTable.EOPS_IsObjectNeed_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]權限物Id{ObjectId}：【&lt;KEY&gt;】※若IsObjectNedd為是，則該需指派物件  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOPS_ObjectId
        {
            get { return getAttrGetString(this[theTable.EOPS_ObjectIdColumn]); }
            set { this[theTable.EOPS_ObjectIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]#權限物名稱{ObjectName_XX}：【[部門]資訊中心】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOPS_ObjectName_XX
        {
            get { return getAttrGetString(this[theTable.EOPS_ObjectName_XXColumn]); }
            set { this[theTable.EOPS_ObjectName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*權限CODE{PermissionCode:50}：【APN_KM_Admin】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOPS_PermissionCode_XX
        {
            get { return getAttrGetString(this[theTable.EOPS_PermissionCode_XXColumn]); }
            set { this[theTable.EOPS_PermissionCode_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*權限ID{PermissionId}:【KEY&lt;EOP&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOPS_PermissionId
        {
            get { return getAttrGetString(this[theTable.EOPS_PermissionIdColumn]); }
            set { this[theTable.EOPS_PermissionIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*權限名稱{PermissionName:50}：【系統\KM\系統管理員】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOPS_PermissionName_XX
        {
            get { return getAttrGetString(this[theTable.EOPS_PermissionName_XXColumn]); }
            set { this[theTable.EOPS_PermissionName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*人員ID{PermissionUserId}：【KEY&lt;EOE&gt;|KEY&lt;EOD&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOPS_PermissionUserId
        {
            get { return getAttrGetString(this[theTable.EOPS_PermissionUserIdColumn]); }
            set { this[theTable.EOPS_PermissionUserIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*部門名稱{DepartmentName:50}：【資訊中心】&lt;br/&gt;#完整姓名{EmployeeFullName_XX}：【市政府-林勝文 組長】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOPS_PermissionUserName_XX
        {
            get { return getAttrGetString(this[theTable.EOPS_PermissionUserName_XXColumn]); }
            set { this[theTable.EOPS_PermissionUserName_XXColumn] = getAttrSetString(value); }
        }

    }
}
