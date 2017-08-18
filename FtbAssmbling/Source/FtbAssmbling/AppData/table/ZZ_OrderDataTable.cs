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
    /// &lt;WTST&gt;訂單{ScheduleTask}
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class ZZ_OrderDataTable : FtdTypedDataTable<ZZ_OrderRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public ZZ_OrderDataTable() : base("ZZ_Order")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new ZZ_OrderDataTable();
            return getTableSchema(xs, dt, "ZZO");
        }

        [DebuggerNonUserCodeAttribute()]
        protected ZZ_OrderDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// [DIRECT]*訂單ID {DTN_NID}：【PK&lt;ZZO&gt;】
        /// </summary> 
        public DataColumn ZZO_OrderIdColumn;

        /// <summary>
        /// [DIRECT]*建立日期(DTN_DATETIME_19)：【】
        /// </summary> 
        public DataColumn ZZO_CreateDateColumn;

        /// <summary>
        /// [DIRECT]*建立者ID(DTN_NID)：【】
        /// </summary> 
        public DataColumn ZZO_CreatorIdColumn;

        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        public DataColumn ZZO_CreatorName_XXColumn;

        /// <summary>
        /// [DIRECT]*訂單日期{DTN_NVARCHAR50}：【Note7炸彈一支】
        /// </summary> 
        public DataColumn ZZO_DateColumn;

        /// <summary>
        /// [DIRECT]*訂單說明{DTN_NVARCHAR50}：【Note7炸彈一支】
        /// </summary> 
        public DataColumn ZZO_DescColumn;

        /// <summary>
        /// [DIRECT]*是否啟用{DTN_NVARCHAR1}：【Y：啟用 / N：不啟用】
        /// </summary> 
        public DataColumn ZZO_IsEnableColumn;

        /// <summary>
        /// [DIRECT]*是否啟用{DTN_NVARCHAR10}：【Y：啟用 / N：不啟用】
        /// </summary> 
        public DataColumn ZZO_IsEnableName_XXColumn;

        /// <summary>
        /// *訂單總金額{DTN_INTEGER}：【2008/04/01 12:30:40】
        /// </summary> 
        public DataColumn ZZO_OrderAmount_XXColumn;

        /// <summary>
        /// [DIRECT]*訂單號碼{DTN_NVARCHAR10}：【20161022001】
        /// </summary> 
        public DataColumn ZZO_OrderNoColumn;

        /// <summary>
        /// [DIRECT]*異動日期(DTN_DATETIME_19)：【】
        /// </summary> 
        public DataColumn ZZO_UpdateDateColumn;

        /// <summary>
        /// [DIRECT]*異動者ID(DTN_NID)：【】
        /// </summary> 
        public DataColumn ZZO_UpdaterIdColumn;

        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        public DataColumn ZZO_UpdaterName_XXColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public ZZ_OrderRow findByPrimaryKey(String ZZO_OrderId)
        {
            return (ZZ_OrderRow)(Rows.Find(new object[] { ZZO_OrderId }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new ZZ_OrderDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            ZZO_OrderIdColumn = Columns["ZZO_OrderId"];
            ZZO_CreateDateColumn = Columns["ZZO_CreateDate"];
            ZZO_CreatorIdColumn = Columns["ZZO_CreatorId"];
            ZZO_CreatorName_XXColumn = Columns["ZZO_CreatorName_XX"];
            ZZO_DateColumn = Columns["ZZO_Date"];
            ZZO_DescColumn = Columns["ZZO_Desc"];
            ZZO_IsEnableColumn = Columns["ZZO_IsEnable"];
            ZZO_IsEnableName_XXColumn = Columns["ZZO_IsEnableName_XX"];
            ZZO_OrderAmount_XXColumn = Columns["ZZO_OrderAmount_XX"];
            ZZO_OrderNoColumn = Columns["ZZO_OrderNo"];
            ZZO_UpdateDateColumn = Columns["ZZO_UpdateDate"];
            ZZO_UpdaterIdColumn = Columns["ZZO_UpdaterId"];
            ZZO_UpdaterName_XXColumn = Columns["ZZO_UpdaterName_XX"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            ZZO_OrderIdColumn = new DataColumn("ZZO_OrderId", typeof(String), null, MappingType.Attribute);
            Columns.Add(ZZO_OrderIdColumn);
            ZZO_OrderIdColumn.AllowDBNull = false;

            ZZO_CreateDateColumn = new DataColumn("ZZO_CreateDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(ZZO_CreateDateColumn);

            ZZO_CreatorIdColumn = new DataColumn("ZZO_CreatorId", typeof(String), null, MappingType.Attribute);
            Columns.Add(ZZO_CreatorIdColumn);

            ZZO_CreatorName_XXColumn = new DataColumn("ZZO_CreatorName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(ZZO_CreatorName_XXColumn);

            ZZO_DateColumn = new DataColumn("ZZO_Date", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(ZZO_DateColumn);

            ZZO_DescColumn = new DataColumn("ZZO_Desc", typeof(String), null, MappingType.Attribute);
            Columns.Add(ZZO_DescColumn);

            ZZO_IsEnableColumn = new DataColumn("ZZO_IsEnable", typeof(String), null, MappingType.Attribute);
            Columns.Add(ZZO_IsEnableColumn);

            ZZO_IsEnableName_XXColumn = new DataColumn("ZZO_IsEnableName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(ZZO_IsEnableName_XXColumn);

            ZZO_OrderAmount_XXColumn = new DataColumn("ZZO_OrderAmount_XX", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(ZZO_OrderAmount_XXColumn);

            ZZO_OrderNoColumn = new DataColumn("ZZO_OrderNo", typeof(String), null, MappingType.Attribute);
            Columns.Add(ZZO_OrderNoColumn);

            ZZO_UpdateDateColumn = new DataColumn("ZZO_UpdateDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(ZZO_UpdateDateColumn);

            ZZO_UpdaterIdColumn = new DataColumn("ZZO_UpdaterId", typeof(String), null, MappingType.Attribute);
            Columns.Add(ZZO_UpdaterIdColumn);

            ZZO_UpdaterName_XXColumn = new DataColumn("ZZO_UpdaterName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(ZZO_UpdaterName_XXColumn);

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { ZZO_OrderIdColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new ZZ_OrderRow(builder);
        }

    }

    ///<summary>
    ///&lt;WTST&gt;訂單{ScheduleTask}  
    ///</summary>
    public class ZZ_OrderRow : FtdDataRow
    {
        private ZZ_OrderDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal ZZ_OrderRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((ZZ_OrderDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public ZZ_OrderDataTable TypeTable
        {
            get { return (ZZ_OrderDataTable)Table; }
        }

        ///<summary>
        ///[DIRECT]*訂單ID {DTN_NID}：【PK&lt;ZZO&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ZZO_OrderId
        {
            get { return getAttrGetString(this[theTable.ZZO_OrderIdColumn]); }
            set { this[theTable.ZZO_OrderIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*建立日期(DTN_DATETIME_19)：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? ZZO_CreateDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.ZZO_CreateDateColumn]); }
            set { this[this.theTable.ZZO_CreateDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///[DIRECT]*建立者ID(DTN_NID)：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ZZO_CreatorId
        {
            get { return getAttrGetString(this[theTable.ZZO_CreatorIdColumn]); }
            set { this[theTable.ZZO_CreatorIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ZZO_CreatorName_XX
        {
            get { return getAttrGetString(this[theTable.ZZO_CreatorName_XXColumn]); }
            set { this[theTable.ZZO_CreatorName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*訂單日期{DTN_NVARCHAR50}：【Note7炸彈一支】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? ZZO_Date
        {
            get { return getAttrGetValue<DateTime>(this[theTable.ZZO_DateColumn]); }
            set { this[this.theTable.ZZO_DateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///[DIRECT]*訂單說明{DTN_NVARCHAR50}：【Note7炸彈一支】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ZZO_Desc
        {
            get { return getAttrGetString(this[theTable.ZZO_DescColumn]); }
            set { this[theTable.ZZO_DescColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*是否啟用{DTN_NVARCHAR1}：【Y：啟用 / N：不啟用】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ZZO_IsEnable
        {
            get { return getAttrGetString(this[theTable.ZZO_IsEnableColumn]); }
            set { this[theTable.ZZO_IsEnableColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*是否啟用{DTN_NVARCHAR10}：【Y：啟用 / N：不啟用】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ZZO_IsEnableName_XX
        {
            get { return getAttrGetString(this[theTable.ZZO_IsEnableName_XXColumn]); }
            set { this[theTable.ZZO_IsEnableName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///*訂單總金額{DTN_INTEGER}：【2008/04/01 12:30:40】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? ZZO_OrderAmount_XX
        {
            get { return getAttrGetValue<Int32>(this[theTable.ZZO_OrderAmount_XXColumn]); }
            set { this[this.theTable.ZZO_OrderAmount_XXColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///[DIRECT]*訂單號碼{DTN_NVARCHAR10}：【20161022001】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ZZO_OrderNo
        {
            get { return getAttrGetString(this[theTable.ZZO_OrderNoColumn]); }
            set { this[theTable.ZZO_OrderNoColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*異動日期(DTN_DATETIME_19)：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? ZZO_UpdateDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.ZZO_UpdateDateColumn]); }
            set { this[this.theTable.ZZO_UpdateDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///[DIRECT]*異動者ID(DTN_NID)：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ZZO_UpdaterId
        {
            get { return getAttrGetString(this[theTable.ZZO_UpdaterIdColumn]); }
            set { this[theTable.ZZO_UpdaterIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ZZO_UpdaterName_XX
        {
            get { return getAttrGetString(this[theTable.ZZO_UpdaterName_XXColumn]); }
            set { this[theTable.ZZO_UpdaterName_XXColumn] = getAttrSetString(value); }
        }

    }
}
