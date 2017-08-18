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
    /// &lt;EOET&gt;人員職稱{EmployeeTitle}
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class EO_EmployeeTitleDataTable : FtdTypedDataTable<EO_EmployeeTitleRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public EO_EmployeeTitleDataTable() : base("EO_EmployeeTitle")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new EO_EmployeeTitleDataTable();
            return getTableSchema(xs, dt, "EOET");
        }

        [DebuggerNonUserCodeAttribute()]
        protected EO_EmployeeTitleDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// [DIRECT]*職稱Id{EmployeeTitleId}：【PK&lt;EOET&gt;】
        /// </summary> 
        public DataColumn EOET_EmployeeTitleIdColumn;

        /// <summary>
        /// #是否正在使用中{InUse_XX,InUseName_XX}：○{T}是 ○{F}否
        /// </summary> 
        public DataColumn EOET_InUse_XXColumn;

        /// <summary>
        /// #是否正在使用中{InUse_XX,InUseName_XX}：○{T}是 ○{F}否
        /// </summary> 
        public DataColumn EOET_InUseName_XXColumn;

        /// <summary>
        /// [DIRECT]*職稱順序{ListOrder:INT}：【1000】
        /// </summary> 
        public DataColumn EOET_ListOrderColumn;

        /// <summary>
        /// [DIRECT]職稱代號 {TitleCode:20}：【A312】
        /// </summary> 
        public DataColumn EOET_TitleCodeColumn;

        /// <summary>
        /// [DIRECT]*職稱名稱{TitleName:20}：【組長】
        /// </summary> 
        public DataColumn EOET_TitleNameColumn;

        /// <summary>
        /// #人數{UserCount_XX}：【1000】
        /// </summary> 
        public DataColumn EOET_UserCount_XXColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public EO_EmployeeTitleRow findByPrimaryKey(String EOET_EmployeeTitleId)
        {
            return (EO_EmployeeTitleRow)(Rows.Find(new object[] { EOET_EmployeeTitleId }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new EO_EmployeeTitleDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            EOET_EmployeeTitleIdColumn = Columns["EOET_EmployeeTitleId"];
            EOET_InUse_XXColumn = Columns["EOET_InUse_XX"];
            EOET_InUseName_XXColumn = Columns["EOET_InUseName_XX"];
            EOET_ListOrderColumn = Columns["EOET_ListOrder"];
            EOET_TitleCodeColumn = Columns["EOET_TitleCode"];
            EOET_TitleNameColumn = Columns["EOET_TitleName"];
            EOET_UserCount_XXColumn = Columns["EOET_UserCount_XX"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            EOET_EmployeeTitleIdColumn = new DataColumn("EOET_EmployeeTitleId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOET_EmployeeTitleIdColumn);
            EOET_EmployeeTitleIdColumn.AllowDBNull = false;

            EOET_InUse_XXColumn = new DataColumn("EOET_InUse_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOET_InUse_XXColumn);

            EOET_InUseName_XXColumn = new DataColumn("EOET_InUseName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOET_InUseName_XXColumn);

            EOET_ListOrderColumn = new DataColumn("EOET_ListOrder", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(EOET_ListOrderColumn);

            EOET_TitleCodeColumn = new DataColumn("EOET_TitleCode", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOET_TitleCodeColumn);

            EOET_TitleNameColumn = new DataColumn("EOET_TitleName", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOET_TitleNameColumn);

            EOET_UserCount_XXColumn = new DataColumn("EOET_UserCount_XX", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(EOET_UserCount_XXColumn);

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { EOET_EmployeeTitleIdColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new EO_EmployeeTitleRow(builder);
        }

    }

    ///<summary>
    ///&lt;EOET&gt;人員職稱{EmployeeTitle}  
    ///</summary>
    public class EO_EmployeeTitleRow : FtdDataRow
    {
        private EO_EmployeeTitleDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal EO_EmployeeTitleRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((EO_EmployeeTitleDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public EO_EmployeeTitleDataTable TypeTable
        {
            get { return (EO_EmployeeTitleDataTable)Table; }
        }

        ///<summary>
        ///[DIRECT]*職稱Id{EmployeeTitleId}：【PK&lt;EOET&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOET_EmployeeTitleId
        {
            get { return getAttrGetString(this[theTable.EOET_EmployeeTitleIdColumn]); }
            set { this[theTable.EOET_EmployeeTitleIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///#是否正在使用中{InUse_XX,InUseName_XX}：○{T}是 ○{F}否  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOET_InUse_XX
        {
            get { return getAttrGetString(this[theTable.EOET_InUse_XXColumn]); }
            set { this[theTable.EOET_InUse_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///#是否正在使用中{InUse_XX,InUseName_XX}：○{T}是 ○{F}否  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOET_InUseName_XX
        {
            get { return getAttrGetString(this[theTable.EOET_InUseName_XXColumn]); }
            set { this[theTable.EOET_InUseName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*職稱順序{ListOrder:INT}：【1000】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? EOET_ListOrder
        {
            get { return getAttrGetValue<Int32>(this[theTable.EOET_ListOrderColumn]); }
            set { this[this.theTable.EOET_ListOrderColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///[DIRECT]職稱代號 {TitleCode:20}：【A312】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOET_TitleCode
        {
            get { return getAttrGetString(this[theTable.EOET_TitleCodeColumn]); }
            set { this[theTable.EOET_TitleCodeColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*職稱名稱{TitleName:20}：【組長】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOET_TitleName
        {
            get { return getAttrGetString(this[theTable.EOET_TitleNameColumn]); }
            set { this[theTable.EOET_TitleNameColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///#人數{UserCount_XX}：【1000】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? EOET_UserCount_XX
        {
            get { return getAttrGetValue<Int32>(this[theTable.EOET_UserCount_XXColumn]); }
            set { this[this.theTable.EOET_UserCount_XXColumn] = getAttrSetValue<Int32>(value); }
        }

    }
}
