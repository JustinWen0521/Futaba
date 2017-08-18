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
    /// &lt;ZZOD&gt;訂單明細{ZZ_OrderDetail}
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class ZZ_OrderDetailDataTable : FtdTypedDataTable<ZZ_OrderDetailRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public ZZ_OrderDetailDataTable() : base("ZZ_OrderDetail")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new ZZ_OrderDetailDataTable();
            return getTableSchema(xs, dt, "ZZOD");
        }

        [DebuggerNonUserCodeAttribute()]
        protected ZZ_OrderDetailDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// [DIRECT]*訂單明細ID {DTN_NID}：【PK&lt;ZZO&gt;】
        /// </summary> 
        public DataColumn ZZOD_OrderDetailIdColumn;

        /// <summary>
        /// [DIRECT]*金額{DTN_INTEGER}：【299】
        /// </summary> 
        public DataColumn ZZOD_Amount_XXColumn;

        /// <summary>
        /// [DIRECT]*建立日期(DTN_DATETIME_19)：【】
        /// </summary> 
        public DataColumn ZZOD_CreateDateColumn;

        /// <summary>
        /// [DIRECT]*建立者ID(DTN_NID)：【】
        /// </summary> 
        public DataColumn ZZOD_CreatorIdColumn;

        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        public DataColumn ZZOD_CreatorName_XXColumn;

        /// <summary>
        /// [DIRECT]*品項{DTN_NVARCHAR20}：【滑鼠】
        /// </summary> 
        public DataColumn ZZOD_ItemColumn;

        /// <summary>
        /// [DIRECT]*訂單說明{DTN_NVARCHAR50}：【Note7炸彈一支】&lt;br/&gt;
        /// </summary> 
        public DataColumn ZZOD_OrderDate_XXColumn;

        /// <summary>
        /// [DIRECT]*訂單說明{DTN_NVARCHAR50}：【Note7炸彈一支】&lt;br/&gt;
        /// </summary> 
        public DataColumn ZZOD_OrderDesc_XXColumn;

        /// <summary>
        /// [DIRECT]*訂單ID {DTN_NID}：【PK&lt;ZZO&gt;】
        /// </summary> 
        public DataColumn ZZOD_OrderIdColumn;

        /// <summary>
        /// [DIRECT]*訂單號碼{DTN_NVARCHAR10}：【20161022001】&lt;br/&gt;
        /// </summary> 
        public DataColumn ZZOD_OrderNo_XXColumn;

        /// <summary>
        /// [DIRECT]*數量{DTN_INTEGER}：【1】
        /// </summary> 
        public DataColumn ZZOD_QtyColumn;

        /// <summary>
        /// [DIRECT]*單價{DTN_INTEGER}：【1】
        /// </summary> 
        public DataColumn ZZOD_UnitPriceColumn;

        /// <summary>
        /// [DIRECT]*異動日期(DTN_DATETIME_19)：【】
        /// </summary> 
        public DataColumn ZZOD_UpdateDateColumn;

        /// <summary>
        /// [DIRECT]*異動者ID(DTN_NID)：【】
        /// </summary> 
        public DataColumn ZZOD_UpdaterIdColumn;

        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        public DataColumn ZZOD_UpdaterName_XXColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public ZZ_OrderDetailRow findByPrimaryKey(String ZZOD_OrderDetailId)
        {
            return (ZZ_OrderDetailRow)(Rows.Find(new object[] { ZZOD_OrderDetailId }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new ZZ_OrderDetailDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            ZZOD_OrderDetailIdColumn = Columns["ZZOD_OrderDetailId"];
            ZZOD_Amount_XXColumn = Columns["ZZOD_Amount_XX"];
            ZZOD_CreateDateColumn = Columns["ZZOD_CreateDate"];
            ZZOD_CreatorIdColumn = Columns["ZZOD_CreatorId"];
            ZZOD_CreatorName_XXColumn = Columns["ZZOD_CreatorName_XX"];
            ZZOD_ItemColumn = Columns["ZZOD_Item"];
            ZZOD_OrderDate_XXColumn = Columns["ZZOD_OrderDate_XX"];
            ZZOD_OrderDesc_XXColumn = Columns["ZZOD_OrderDesc_XX"];
            ZZOD_OrderIdColumn = Columns["ZZOD_OrderId"];
            ZZOD_OrderNo_XXColumn = Columns["ZZOD_OrderNo_XX"];
            ZZOD_QtyColumn = Columns["ZZOD_Qty"];
            ZZOD_UnitPriceColumn = Columns["ZZOD_UnitPrice"];
            ZZOD_UpdateDateColumn = Columns["ZZOD_UpdateDate"];
            ZZOD_UpdaterIdColumn = Columns["ZZOD_UpdaterId"];
            ZZOD_UpdaterName_XXColumn = Columns["ZZOD_UpdaterName_XX"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            ZZOD_OrderDetailIdColumn = new DataColumn("ZZOD_OrderDetailId", typeof(String), null, MappingType.Attribute);
            Columns.Add(ZZOD_OrderDetailIdColumn);
            ZZOD_OrderDetailIdColumn.AllowDBNull = false;

            ZZOD_Amount_XXColumn = new DataColumn("ZZOD_Amount_XX", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(ZZOD_Amount_XXColumn);

            ZZOD_CreateDateColumn = new DataColumn("ZZOD_CreateDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(ZZOD_CreateDateColumn);

            ZZOD_CreatorIdColumn = new DataColumn("ZZOD_CreatorId", typeof(String), null, MappingType.Attribute);
            Columns.Add(ZZOD_CreatorIdColumn);

            ZZOD_CreatorName_XXColumn = new DataColumn("ZZOD_CreatorName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(ZZOD_CreatorName_XXColumn);

            ZZOD_ItemColumn = new DataColumn("ZZOD_Item", typeof(String), null, MappingType.Attribute);
            Columns.Add(ZZOD_ItemColumn);

            ZZOD_OrderDate_XXColumn = new DataColumn("ZZOD_OrderDate_XX", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(ZZOD_OrderDate_XXColumn);

            ZZOD_OrderDesc_XXColumn = new DataColumn("ZZOD_OrderDesc_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(ZZOD_OrderDesc_XXColumn);

            ZZOD_OrderIdColumn = new DataColumn("ZZOD_OrderId", typeof(String), null, MappingType.Attribute);
            Columns.Add(ZZOD_OrderIdColumn);

            ZZOD_OrderNo_XXColumn = new DataColumn("ZZOD_OrderNo_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(ZZOD_OrderNo_XXColumn);

            ZZOD_QtyColumn = new DataColumn("ZZOD_Qty", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(ZZOD_QtyColumn);

            ZZOD_UnitPriceColumn = new DataColumn("ZZOD_UnitPrice", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(ZZOD_UnitPriceColumn);

            ZZOD_UpdateDateColumn = new DataColumn("ZZOD_UpdateDate", typeof(DateTime), null, MappingType.Attribute);
            Columns.Add(ZZOD_UpdateDateColumn);

            ZZOD_UpdaterIdColumn = new DataColumn("ZZOD_UpdaterId", typeof(String), null, MappingType.Attribute);
            Columns.Add(ZZOD_UpdaterIdColumn);

            ZZOD_UpdaterName_XXColumn = new DataColumn("ZZOD_UpdaterName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(ZZOD_UpdaterName_XXColumn);

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { ZZOD_OrderDetailIdColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new ZZ_OrderDetailRow(builder);
        }

    }

    ///<summary>
    ///&lt;ZZOD&gt;訂單明細{ZZ_OrderDetail}  
    ///</summary>
    public class ZZ_OrderDetailRow : FtdDataRow
    {
        private ZZ_OrderDetailDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal ZZ_OrderDetailRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((ZZ_OrderDetailDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public ZZ_OrderDetailDataTable TypeTable
        {
            get { return (ZZ_OrderDetailDataTable)Table; }
        }

        ///<summary>
        ///[DIRECT]*訂單明細ID {DTN_NID}：【PK&lt;ZZO&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ZZOD_OrderDetailId
        {
            get { return getAttrGetString(this[theTable.ZZOD_OrderDetailIdColumn]); }
            set { this[theTable.ZZOD_OrderDetailIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*金額{DTN_INTEGER}：【299】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? ZZOD_Amount_XX
        {
            get { return getAttrGetValue<Int32>(this[theTable.ZZOD_Amount_XXColumn]); }
            set { this[this.theTable.ZZOD_Amount_XXColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///[DIRECT]*建立日期(DTN_DATETIME_19)：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? ZZOD_CreateDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.ZZOD_CreateDateColumn]); }
            set { this[this.theTable.ZZOD_CreateDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///[DIRECT]*建立者ID(DTN_NID)：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ZZOD_CreatorId
        {
            get { return getAttrGetString(this[theTable.ZZOD_CreatorIdColumn]); }
            set { this[theTable.ZZOD_CreatorIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ZZOD_CreatorName_XX
        {
            get { return getAttrGetString(this[theTable.ZZOD_CreatorName_XXColumn]); }
            set { this[theTable.ZZOD_CreatorName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*品項{DTN_NVARCHAR20}：【滑鼠】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ZZOD_Item
        {
            get { return getAttrGetString(this[theTable.ZZOD_ItemColumn]); }
            set { this[theTable.ZZOD_ItemColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*訂單說明{DTN_NVARCHAR50}：【Note7炸彈一支】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? ZZOD_OrderDate_XX
        {
            get { return getAttrGetValue<DateTime>(this[theTable.ZZOD_OrderDate_XXColumn]); }
            set { this[this.theTable.ZZOD_OrderDate_XXColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///[DIRECT]*訂單說明{DTN_NVARCHAR50}：【Note7炸彈一支】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ZZOD_OrderDesc_XX
        {
            get { return getAttrGetString(this[theTable.ZZOD_OrderDesc_XXColumn]); }
            set { this[theTable.ZZOD_OrderDesc_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*訂單ID {DTN_NID}：【PK&lt;ZZO&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ZZOD_OrderId
        {
            get { return getAttrGetString(this[theTable.ZZOD_OrderIdColumn]); }
            set { this[theTable.ZZOD_OrderIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*訂單號碼{DTN_NVARCHAR10}：【20161022001】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ZZOD_OrderNo_XX
        {
            get { return getAttrGetString(this[theTable.ZZOD_OrderNo_XXColumn]); }
            set { this[theTable.ZZOD_OrderNo_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*數量{DTN_INTEGER}：【1】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? ZZOD_Qty
        {
            get { return getAttrGetValue<Int32>(this[theTable.ZZOD_QtyColumn]); }
            set { this[this.theTable.ZZOD_QtyColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///[DIRECT]*單價{DTN_INTEGER}：【1】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? ZZOD_UnitPrice
        {
            get { return getAttrGetValue<Int32>(this[theTable.ZZOD_UnitPriceColumn]); }
            set { this[this.theTable.ZZOD_UnitPriceColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///[DIRECT]*異動日期(DTN_DATETIME_19)：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public DateTime? ZZOD_UpdateDate
        {
            get { return getAttrGetValue<DateTime>(this[theTable.ZZOD_UpdateDateColumn]); }
            set { this[this.theTable.ZZOD_UpdateDateColumn] = getAttrSetValue<DateTime>(value); }
        }

        ///<summary>
        ///[DIRECT]*異動者ID(DTN_NID)：【】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ZZOD_UpdaterId
        {
            get { return getAttrGetString(this[theTable.ZZOD_UpdaterIdColumn]); }
            set { this[theTable.ZZOD_UpdaterIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string ZZOD_UpdaterName_XX
        {
            get { return getAttrGetString(this[theTable.ZZOD_UpdaterName_XXColumn]); }
            set { this[theTable.ZZOD_UpdaterName_XXColumn] = getAttrSetString(value); }
        }

    }
}
