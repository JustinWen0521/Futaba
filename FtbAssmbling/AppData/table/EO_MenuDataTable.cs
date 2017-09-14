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
    /// &lt;EOM&gt; 功能表定義{Menu}
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class EO_MenuDataTable : FtdTypedDataTable<EO_MenuRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public EO_MenuDataTable() : base("EO_Menu")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new EO_MenuDataTable();
            return getTableSchema(xs, dt, "EOM");
        }

        [DebuggerNonUserCodeAttribute()]
        protected EO_MenuDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// [DIRECT]*功能表ID{MenuId}：【PK&lt;EOM&gt;】
        /// </summary> 
        public DataColumn EOM_MenuIdColumn;

        /// <summary>
        /// #XML檔案路徑{FileFullName_XX}：【C:\001\AppMenu.xml】
        /// </summary> 
        public DataColumn EOM_FileFullName_XXColumn;

        /// <summary>
        /// [DIRECT]XML檔案{FileName:50}：【~/data/AppMenu.xml】
        /// </summary> 
        public DataColumn EOM_FileNameColumn;

        /// <summary>
        /// [DIRECT]*功能表名稱{MenuName:20}：【首頁功能表】
        /// </summary> 
        public DataColumn EOM_MenuNameColumn;

        /// <summary>
        /// [DIRECT]資料庫檔案{StructId,StructName_XX}：【KEY&lt;EOMS&gt;,首頁功能表】
        /// </summary> 
        public DataColumn EOM_StructIdColumn;

        /// <summary>
        /// [DIRECT]功能表名稱{Name:20}：【主檔維護】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOM_StructName_XXColumn;

        /// <summary>
        /// [DIRECT]*結構檔案{StructSource:1}：○{F}Xml檔案 ○{D}資料庫檔案
        /// </summary> 
        public DataColumn EOM_StructSourceColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public EO_MenuRow findByPrimaryKey(String EOM_MenuId)
        {
            return (EO_MenuRow)(Rows.Find(new object[] { EOM_MenuId }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new EO_MenuDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            EOM_MenuIdColumn = Columns["EOM_MenuId"];
            EOM_FileFullName_XXColumn = Columns["EOM_FileFullName_XX"];
            EOM_FileNameColumn = Columns["EOM_FileName"];
            EOM_MenuNameColumn = Columns["EOM_MenuName"];
            EOM_StructIdColumn = Columns["EOM_StructId"];
            EOM_StructName_XXColumn = Columns["EOM_StructName_XX"];
            EOM_StructSourceColumn = Columns["EOM_StructSource"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            EOM_MenuIdColumn = new DataColumn("EOM_MenuId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOM_MenuIdColumn);
            EOM_MenuIdColumn.AllowDBNull = false;

            EOM_FileFullName_XXColumn = new DataColumn("EOM_FileFullName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOM_FileFullName_XXColumn);

            EOM_FileNameColumn = new DataColumn("EOM_FileName", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOM_FileNameColumn);

            EOM_MenuNameColumn = new DataColumn("EOM_MenuName", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOM_MenuNameColumn);

            EOM_StructIdColumn = new DataColumn("EOM_StructId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOM_StructIdColumn);

            EOM_StructName_XXColumn = new DataColumn("EOM_StructName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOM_StructName_XXColumn);

            EOM_StructSourceColumn = new DataColumn("EOM_StructSource", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOM_StructSourceColumn);

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { EOM_MenuIdColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new EO_MenuRow(builder);
        }

    }

    ///<summary>
    ///&lt;EOM&gt; 功能表定義{Menu}  
    ///</summary>
    public class EO_MenuRow : FtdDataRow
    {
        private EO_MenuDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal EO_MenuRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((EO_MenuDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public EO_MenuDataTable TypeTable
        {
            get { return (EO_MenuDataTable)Table; }
        }

        ///<summary>
        ///[DIRECT]*功能表ID{MenuId}：【PK&lt;EOM&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOM_MenuId
        {
            get { return getAttrGetString(this[theTable.EOM_MenuIdColumn]); }
            set { this[theTable.EOM_MenuIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///#XML檔案路徑{FileFullName_XX}：【C:\001\AppMenu.xml】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOM_FileFullName_XX
        {
            get { return getAttrGetString(this[theTable.EOM_FileFullName_XXColumn]); }
            set { this[theTable.EOM_FileFullName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]XML檔案{FileName:50}：【~/data/AppMenu.xml】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOM_FileName
        {
            get { return getAttrGetString(this[theTable.EOM_FileNameColumn]); }
            set { this[theTable.EOM_FileNameColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*功能表名稱{MenuName:20}：【首頁功能表】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOM_MenuName
        {
            get { return getAttrGetString(this[theTable.EOM_MenuNameColumn]); }
            set { this[theTable.EOM_MenuNameColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]資料庫檔案{StructId,StructName_XX}：【KEY&lt;EOMS&gt;,首頁功能表】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOM_StructId
        {
            get { return getAttrGetString(this[theTable.EOM_StructIdColumn]); }
            set { this[theTable.EOM_StructIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]功能表名稱{Name:20}：【主檔維護】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOM_StructName_XX
        {
            get { return getAttrGetString(this[theTable.EOM_StructName_XXColumn]); }
            set { this[theTable.EOM_StructName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*結構檔案{StructSource:1}：○{F}Xml檔案 ○{D}資料庫檔案  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOM_StructSource
        {
            get { return getAttrGetString(this[theTable.EOM_StructSourceColumn]); }
            set { this[theTable.EOM_StructSourceColumn] = getAttrSetString(value); }
        }

    }
}
