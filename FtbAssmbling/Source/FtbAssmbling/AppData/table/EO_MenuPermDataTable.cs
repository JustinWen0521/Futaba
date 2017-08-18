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
    /// {T}&lt;EOMP&gt;功能表/授權對象{MenuPerm}
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class EO_MenuPermDataTable : FtdTypedDataTable<EO_MenuPermRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public EO_MenuPermDataTable() : base("EO_MenuPerm")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new EO_MenuPermDataTable();
            return getTableSchema(xs, dt, "EOMP");
        }

        [DebuggerNonUserCodeAttribute()]
        protected EO_MenuPermDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// [DIRECT]*授權對象ID{MenuPermId}：【PK&lt;EOMP&gt;】
        /// </summary> 
        public DataColumn EOMP_MenuPermIdColumn;

        /// <summary>
        /// [DIRECT]*功能表ID{MenuId}：【FK&lt;EOM&gt;】
        /// </summary> 
        public DataColumn EOMP_MenuIdColumn;

        /// <summary>
        /// [DIRECT]*授權對象代號{TargetId,TargetCode_XX}：【FK&lt;EOM|EOD|EOET&gt;，(部門)主計處】
        /// </summary> 
        public DataColumn EOMP_TargetCode_XXColumn;

        /// <summary>
        /// [DIRECT]*授權對象{TargetId,TargetName_XX}：【FK&lt;EOM|EOD|EOET&gt;，(部門)主計處】
        /// </summary> 
        public DataColumn EOMP_TargetIdColumn;

        /// <summary>
        /// [DIRECT]*授權類型{TargetKind,TargetKindName_XX}：A：員工 / B：群組 / C：職稱 / D：權限 / E：機關
        /// </summary> 
        public DataColumn EOMP_TargetKindColumn;

        /// <summary>
        /// [DIRECT]*授權類型{TargetKind,TargetKindName_XX}：A：員工 / B：群組 / C：職稱 / D：權限 / E：機關
        /// </summary> 
        public DataColumn EOMP_TargetKindName_XXColumn;

        /// <summary>
        /// [DIRECT]*授權對象名稱{TargetId,TargetName_XX}：【FK&lt;EOM|EOD|EOET&gt;，(部門)主計處】
        /// </summary> 
        public DataColumn EOMP_TargetName_XXColumn;

        /// <summary>
        /// [DIRECT]*檢視權限{ViewKind,ViewKindName_XX}○{Name}可檢視 ○{Name_U}不可檢視
        /// </summary> 
        public DataColumn EOMP_ViewKindColumn;

        /// <summary>
        /// [DIRECT]*檢視權限{ViewKind,ViewKindName_XX}○{Name}可檢視 ○{Name_U}不可檢視
        /// </summary> 
        public DataColumn EOMP_ViewKindName_XXColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public EO_MenuPermRow findByPrimaryKey(String EOMP_MenuPermId)
        {
            return (EO_MenuPermRow)(Rows.Find(new object[] { EOMP_MenuPermId }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new EO_MenuPermDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            EOMP_MenuPermIdColumn = Columns["EOMP_MenuPermId"];
            EOMP_MenuIdColumn = Columns["EOMP_MenuId"];
            EOMP_TargetCode_XXColumn = Columns["EOMP_TargetCode_XX"];
            EOMP_TargetIdColumn = Columns["EOMP_TargetId"];
            EOMP_TargetKindColumn = Columns["EOMP_TargetKind"];
            EOMP_TargetKindName_XXColumn = Columns["EOMP_TargetKindName_XX"];
            EOMP_TargetName_XXColumn = Columns["EOMP_TargetName_XX"];
            EOMP_ViewKindColumn = Columns["EOMP_ViewKind"];
            EOMP_ViewKindName_XXColumn = Columns["EOMP_ViewKindName_XX"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            EOMP_MenuPermIdColumn = new DataColumn("EOMP_MenuPermId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMP_MenuPermIdColumn);
            EOMP_MenuPermIdColumn.AllowDBNull = false;

            EOMP_MenuIdColumn = new DataColumn("EOMP_MenuId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMP_MenuIdColumn);

            EOMP_TargetCode_XXColumn = new DataColumn("EOMP_TargetCode_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMP_TargetCode_XXColumn);

            EOMP_TargetIdColumn = new DataColumn("EOMP_TargetId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMP_TargetIdColumn);

            EOMP_TargetKindColumn = new DataColumn("EOMP_TargetKind", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMP_TargetKindColumn);

            EOMP_TargetKindName_XXColumn = new DataColumn("EOMP_TargetKindName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMP_TargetKindName_XXColumn);

            EOMP_TargetName_XXColumn = new DataColumn("EOMP_TargetName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMP_TargetName_XXColumn);

            EOMP_ViewKindColumn = new DataColumn("EOMP_ViewKind", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMP_ViewKindColumn);

            EOMP_ViewKindName_XXColumn = new DataColumn("EOMP_ViewKindName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMP_ViewKindName_XXColumn);

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { EOMP_MenuPermIdColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new EO_MenuPermRow(builder);
        }

    }

    ///<summary>
    ///{T}&lt;EOMP&gt;功能表/授權對象{MenuPerm}  
    ///</summary>
    public class EO_MenuPermRow : FtdDataRow
    {
        private EO_MenuPermDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal EO_MenuPermRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((EO_MenuPermDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public EO_MenuPermDataTable TypeTable
        {
            get { return (EO_MenuPermDataTable)Table; }
        }

        ///<summary>
        ///[DIRECT]*授權對象ID{MenuPermId}：【PK&lt;EOMP&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMP_MenuPermId
        {
            get { return getAttrGetString(this[theTable.EOMP_MenuPermIdColumn]); }
            set { this[theTable.EOMP_MenuPermIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*功能表ID{MenuId}：【FK&lt;EOM&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMP_MenuId
        {
            get { return getAttrGetString(this[theTable.EOMP_MenuIdColumn]); }
            set { this[theTable.EOMP_MenuIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*授權對象代號{TargetId,TargetCode_XX}：【FK&lt;EOM|EOD|EOET&gt;，(部門)主計處】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMP_TargetCode_XX
        {
            get { return getAttrGetString(this[theTable.EOMP_TargetCode_XXColumn]); }
            set { this[theTable.EOMP_TargetCode_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*授權對象{TargetId,TargetName_XX}：【FK&lt;EOM|EOD|EOET&gt;，(部門)主計處】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMP_TargetId
        {
            get { return getAttrGetString(this[theTable.EOMP_TargetIdColumn]); }
            set { this[theTable.EOMP_TargetIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*授權類型{TargetKind,TargetKindName_XX}：A：員工 / B：群組 / C：職稱 / D：權限 / E：機關  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMP_TargetKind
        {
            get { return getAttrGetString(this[theTable.EOMP_TargetKindColumn]); }
            set { this[theTable.EOMP_TargetKindColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*授權類型{TargetKind,TargetKindName_XX}：A：員工 / B：群組 / C：職稱 / D：權限 / E：機關  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMP_TargetKindName_XX
        {
            get { return getAttrGetString(this[theTable.EOMP_TargetKindName_XXColumn]); }
            set { this[theTable.EOMP_TargetKindName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*授權對象名稱{TargetId,TargetName_XX}：【FK&lt;EOM|EOD|EOET&gt;，(部門)主計處】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMP_TargetName_XX
        {
            get { return getAttrGetString(this[theTable.EOMP_TargetName_XXColumn]); }
            set { this[theTable.EOMP_TargetName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*檢視權限{ViewKind,ViewKindName_XX}○{Name}可檢視 ○{Name_U}不可檢視  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMP_ViewKind
        {
            get { return getAttrGetString(this[theTable.EOMP_ViewKindColumn]); }
            set { this[theTable.EOMP_ViewKindColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*檢視權限{ViewKind,ViewKindName_XX}○{Name}可檢視 ○{Name_U}不可檢視  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMP_ViewKindName_XX
        {
            get { return getAttrGetString(this[theTable.EOMP_ViewKindName_XXColumn]); }
            set { this[theTable.EOMP_ViewKindName_XXColumn] = getAttrSetString(value); }
        }

    }
}
