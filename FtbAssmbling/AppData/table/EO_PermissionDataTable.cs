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
    /// 權限主檔
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class EO_PermissionDataTable : FtdTypedDataTable<EO_PermissionRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public EO_PermissionDataTable() : base("EO_Permission")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new EO_PermissionDataTable();
            return getTableSchema(xs, dt, "EOP");
        }

        [DebuggerNonUserCodeAttribute()]
        protected EO_PermissionDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// [DIRECT]*權限ID{PK}：【key(EOP)】
        /// </summary> 
        public DataColumn EOP_PermissionIdColumn;

        /// <summary>
        /// [DIRECT]*權限說明{Description:100}：【最高權限】
        /// </summary> 
        public DataColumn EOP_DescriptionColumn;

        /// <summary>
        /// [DIRECT]*開放給每個人：A:是 B:否             ※若為是，則不用設定表每個人皆可使用
        /// </summary> 
        public DataColumn EOP_IsEveryOneAllowColumn;

        /// <summary>
        /// [DIRECT]#開放給每個人：A:是 B:否             ※若為是，則不用設定表每個人皆可使用
        /// </summary> 
        public DataColumn EOP_IsEveryOneAllowName_XXColumn;

        /// <summary>
        /// [DIRECT]*需指定物件：A:是 B:否             ※若為是，則該權限需另外指派物件.
        /// </summary> 
        public DataColumn EOP_IsObjectNeedColumn;

        /// <summary>
        /// [DIRECT]#需指定物件：A:是 B:否             ※若為是，則該權限需另外指派物件.
        /// </summary> 
        public DataColumn EOP_IsObjectNeedName_XXColumn;

        /// <summary>
        /// [DIRECT]*權限CODE{PermissionCode:50}：【APN_KM_Admin】
        /// </summary> 
        public DataColumn EOP_PermissionCodeColumn;

        /// <summary>
        /// [DIRECT]*權限名稱{PermissionName:50}：【系統\KM\系統管理員】
        /// </summary> 
        public DataColumn EOP_PermissionNameColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public EO_PermissionRow findByPrimaryKey(String EOP_PermissionId)
        {
            return (EO_PermissionRow)(Rows.Find(new object[] { EOP_PermissionId }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new EO_PermissionDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            EOP_PermissionIdColumn = Columns["EOP_PermissionId"];
            EOP_DescriptionColumn = Columns["EOP_Description"];
            EOP_IsEveryOneAllowColumn = Columns["EOP_IsEveryOneAllow"];
            EOP_IsEveryOneAllowName_XXColumn = Columns["EOP_IsEveryOneAllowName_XX"];
            EOP_IsObjectNeedColumn = Columns["EOP_IsObjectNeed"];
            EOP_IsObjectNeedName_XXColumn = Columns["EOP_IsObjectNeedName_XX"];
            EOP_PermissionCodeColumn = Columns["EOP_PermissionCode"];
            EOP_PermissionNameColumn = Columns["EOP_PermissionName"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            EOP_PermissionIdColumn = new DataColumn("EOP_PermissionId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOP_PermissionIdColumn);
            EOP_PermissionIdColumn.AllowDBNull = false;

            EOP_DescriptionColumn = new DataColumn("EOP_Description", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOP_DescriptionColumn);

            EOP_IsEveryOneAllowColumn = new DataColumn("EOP_IsEveryOneAllow", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOP_IsEveryOneAllowColumn);

            EOP_IsEveryOneAllowName_XXColumn = new DataColumn("EOP_IsEveryOneAllowName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOP_IsEveryOneAllowName_XXColumn);

            EOP_IsObjectNeedColumn = new DataColumn("EOP_IsObjectNeed", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOP_IsObjectNeedColumn);

            EOP_IsObjectNeedName_XXColumn = new DataColumn("EOP_IsObjectNeedName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOP_IsObjectNeedName_XXColumn);

            EOP_PermissionCodeColumn = new DataColumn("EOP_PermissionCode", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOP_PermissionCodeColumn);

            EOP_PermissionNameColumn = new DataColumn("EOP_PermissionName", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOP_PermissionNameColumn);

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { EOP_PermissionIdColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new EO_PermissionRow(builder);
        }

    }

    ///<summary>
    ///權限主檔  
    ///</summary>
    public class EO_PermissionRow : FtdDataRow
    {
        private EO_PermissionDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal EO_PermissionRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((EO_PermissionDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public EO_PermissionDataTable TypeTable
        {
            get { return (EO_PermissionDataTable)Table; }
        }

        ///<summary>
        ///[DIRECT]*權限ID{PK}：【key(EOP)】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOP_PermissionId
        {
            get { return getAttrGetString(this[theTable.EOP_PermissionIdColumn]); }
            set { this[theTable.EOP_PermissionIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*權限說明{Description:100}：【最高權限】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOP_Description
        {
            get { return getAttrGetString(this[theTable.EOP_DescriptionColumn]); }
            set { this[theTable.EOP_DescriptionColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*開放給每個人：A:是 B:否             ※若為是，則不用設定表每個人皆可使用  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOP_IsEveryOneAllow
        {
            get { return getAttrGetString(this[theTable.EOP_IsEveryOneAllowColumn]); }
            set { this[theTable.EOP_IsEveryOneAllowColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]#開放給每個人：A:是 B:否             ※若為是，則不用設定表每個人皆可使用  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOP_IsEveryOneAllowName_XX
        {
            get { return getAttrGetString(this[theTable.EOP_IsEveryOneAllowName_XXColumn]); }
            set { this[theTable.EOP_IsEveryOneAllowName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*需指定物件：A:是 B:否             ※若為是，則該權限需另外指派物件.  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOP_IsObjectNeed
        {
            get { return getAttrGetString(this[theTable.EOP_IsObjectNeedColumn]); }
            set { this[theTable.EOP_IsObjectNeedColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]#需指定物件：A:是 B:否             ※若為是，則該權限需另外指派物件.  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOP_IsObjectNeedName_XX
        {
            get { return getAttrGetString(this[theTable.EOP_IsObjectNeedName_XXColumn]); }
            set { this[theTable.EOP_IsObjectNeedName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*權限CODE{PermissionCode:50}：【APN_KM_Admin】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOP_PermissionCode
        {
            get { return getAttrGetString(this[theTable.EOP_PermissionCodeColumn]); }
            set { this[theTable.EOP_PermissionCodeColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*權限名稱{PermissionName:50}：【系統\KM\系統管理員】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOP_PermissionName
        {
            get { return getAttrGetString(this[theTable.EOP_PermissionNameColumn]); }
            set { this[theTable.EOP_PermissionNameColumn] = getAttrSetString(value); }
        }

    }
}
