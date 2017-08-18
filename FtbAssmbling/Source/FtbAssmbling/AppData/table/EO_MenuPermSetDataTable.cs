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
    /// {T}&lt;EOMPS&gt;功能表/授權功能{MenuPermSet}
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class EO_MenuPermSetDataTable : FtdTypedDataTable<EO_MenuPermSetRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public EO_MenuPermSetDataTable() : base("EO_MenuPermSet")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new EO_MenuPermSetDataTable();
            return getTableSchema(xs, dt, "EOMPS");
        }

        [DebuggerNonUserCodeAttribute()]
        protected EO_MenuPermSetDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// [DIRECT]*授權功能ID{ MenuPermSetId}：【PK&lt;EOMPS&gt;】
        /// </summary> 
        public DataColumn EOMPS_MenuPermSetIdColumn;

        /// <summary>
        /// [DIRECT]*功能表ID{MenuId}：【FK&lt;EOM&gt;】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOMPS_MenuId_XXColumn;

        /// <summary>
        /// [DIRECT]*功能項目No{MenuItemNo:50}：【Report.1】
        /// </summary> 
        public DataColumn EOMPS_MenuItemNoColumn;

        /// <summary>
        /// #功能項目No{MenuItemNoName_XX}：【個人紀錄報表】
        /// </summary> 
        public DataColumn EOMPS_MenuItemNoName_XXColumn;

        /// <summary>
        /// [DIRECT]*授權對象ID{MenuPermId}：【FK&lt;EOMP&gt;】
        /// </summary> 
        public DataColumn EOMPS_MenuPermIdColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public EO_MenuPermSetRow findByPrimaryKey(String EOMPS_MenuPermSetId)
        {
            return (EO_MenuPermSetRow)(Rows.Find(new object[] { EOMPS_MenuPermSetId }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new EO_MenuPermSetDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            EOMPS_MenuPermSetIdColumn = Columns["EOMPS_MenuPermSetId"];
            EOMPS_MenuId_XXColumn = Columns["EOMPS_MenuId_XX"];
            EOMPS_MenuItemNoColumn = Columns["EOMPS_MenuItemNo"];
            EOMPS_MenuItemNoName_XXColumn = Columns["EOMPS_MenuItemNoName_XX"];
            EOMPS_MenuPermIdColumn = Columns["EOMPS_MenuPermId"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            EOMPS_MenuPermSetIdColumn = new DataColumn("EOMPS_MenuPermSetId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMPS_MenuPermSetIdColumn);
            EOMPS_MenuPermSetIdColumn.AllowDBNull = false;

            EOMPS_MenuId_XXColumn = new DataColumn("EOMPS_MenuId_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMPS_MenuId_XXColumn);

            EOMPS_MenuItemNoColumn = new DataColumn("EOMPS_MenuItemNo", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMPS_MenuItemNoColumn);

            EOMPS_MenuItemNoName_XXColumn = new DataColumn("EOMPS_MenuItemNoName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMPS_MenuItemNoName_XXColumn);

            EOMPS_MenuPermIdColumn = new DataColumn("EOMPS_MenuPermId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOMPS_MenuPermIdColumn);

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { EOMPS_MenuPermSetIdColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new EO_MenuPermSetRow(builder);
        }

    }

    ///<summary>
    ///{T}&lt;EOMPS&gt;功能表/授權功能{MenuPermSet}  
    ///</summary>
    public class EO_MenuPermSetRow : FtdDataRow
    {
        private EO_MenuPermSetDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal EO_MenuPermSetRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((EO_MenuPermSetDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public EO_MenuPermSetDataTable TypeTable
        {
            get { return (EO_MenuPermSetDataTable)Table; }
        }

        ///<summary>
        ///[DIRECT]*授權功能ID{ MenuPermSetId}：【PK&lt;EOMPS&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMPS_MenuPermSetId
        {
            get { return getAttrGetString(this[theTable.EOMPS_MenuPermSetIdColumn]); }
            set { this[theTable.EOMPS_MenuPermSetIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*功能表ID{MenuId}：【FK&lt;EOM&gt;】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMPS_MenuId_XX
        {
            get { return getAttrGetString(this[theTable.EOMPS_MenuId_XXColumn]); }
            set { this[theTable.EOMPS_MenuId_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*功能項目No{MenuItemNo:50}：【Report.1】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMPS_MenuItemNo
        {
            get { return getAttrGetString(this[theTable.EOMPS_MenuItemNoColumn]); }
            set { this[theTable.EOMPS_MenuItemNoColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///#功能項目No{MenuItemNoName_XX}：【個人紀錄報表】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMPS_MenuItemNoName_XX
        {
            get { return getAttrGetString(this[theTable.EOMPS_MenuItemNoName_XXColumn]); }
            set { this[theTable.EOMPS_MenuItemNoName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*授權對象ID{MenuPermId}：【FK&lt;EOMP&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOMPS_MenuPermId
        {
            get { return getAttrGetString(this[theTable.EOMPS_MenuPermIdColumn]); }
            set { this[theTable.EOMPS_MenuPermIdColumn] = getAttrSetString(value); }
        }

    }
}
