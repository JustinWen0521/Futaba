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
    /// &lt;EOD&gt;部門{Department}
    /// </summary>
    [Serializable]
    [XmlSchemaProviderAttribute("getTableSchema")]
    public class EO_DepartmentDataTable : FtdTypedDataTable<EO_DepartmentRow>
    {
        [DebuggerNonUserCodeAttribute()]
        public EO_DepartmentDataTable() : base("EO_Department")
        {
        }

        /// <summary>
        /// GetTableSchema For WebService
        /// </summary>
        public static XmlSchemaComplexType getTableSchema(XmlSchemaSet xs)
        {
            var dt = new EO_DepartmentDataTable();
            return getTableSchema(xs, dt, "EOD");
        }

        [DebuggerNonUserCodeAttribute()]
        protected EO_DepartmentDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {  
        }

        /// <summary>
        /// [DIRECT]*部門ID{DepartmentId}：【PK&lt;EOD&gt;】
        /// </summary> 
        public DataColumn EOD_DepartmentIdColumn;

        /// <summary>
        /// #兄弟點數量{BrotherCount_XX:N}：【5】
        /// </summary> 
        public DataColumn EOD_BrotherCount_XXColumn;

        /// <summary>
        /// #子部門數量{ChildDeptCount_XX:INT}：【1】
        /// </summary> 
        public DataColumn EOD_ChildCount_XXColumn;

        /// <summary>
        /// #{目前登入者}可否檢視此群組{CU_IsVirtualVisible}：○{T}是 ○{F}不是             ※(群組需為公開)或是(非公開，但是為其成員者)。
        /// </summary> 
        public DataColumn EOD_CU_IsVirtualVisible_XXColumn;

        /// <summary>
        /// [DIRECT]部門代號{DepartmentCode:50}：【AB0913】
        /// </summary> 
        public DataColumn EOD_DepartmentCodeColumn;

        /// <summary>
        /// #完整部門名稱{DepartmentFullName_XX}：【市政府\資訊中心】
        /// </summary> 
        public DataColumn EOD_DepartmentFullName_XXColumn;

        /// <summary>
        /// #完整部門名稱II{DepartmentFullNameII_XX}：【A001-市政府\資訊中心】
        /// </summary> 
        public DataColumn EOD_DepartmentFullNameII_XXColumn;

        /// <summary>
        /// [DIRECT]*部門名稱{DepartmentName:50}：【資訊中心】
        /// </summary> 
        public DataColumn EOD_DepartmentNameColumn;

        /// <summary>
        /// [DIRECT]#部門物件名稱{DepartmentObjectName_XX}：【[部門]資訊中心】
        /// </summary> 
        public DataColumn EOD_DepartmentObjectName_XXColumn;

        /// <summary>
        /// [DIRECT]*部門類型{DepartmentType:1,DepartmentTypeName_XX}：○{Name}正式部門 ○{Name_U}會員群組
        /// </summary> 
        public DataColumn EOD_DepartmentTypeColumn;

        /// <summary>
        /// [DIRECT]*部門類型{DepartmentType:1,DepartmentTypeName_XX}：○{Name}部門 ○{Name_U}群組
        /// </summary> 
        public DataColumn EOD_DepartmentTypeName_XXColumn;

        /// <summary>
        /// #人員數量{EmployeeCount_XX:INT}：【5】
        /// </summary> 
        public DataColumn EOD_EmployeeCount_XXColumn;

        /// <summary>
        /// #可否刪除{IsDeleteable_XX}：○{T}是 ○{F}是             ※部門有子部門或有人員者禁止刪除※群組有子群組者禁止刪除
        /// </summary> 
        public DataColumn EOD_IsDeleteable_XXColumn;

        /// <summary>
        /// [DIRECT]*備註{Note:100}：【This is node great deparment】
        /// </summary> 
        public DataColumn EOD_NoteColumn;

        /// <summary>
        /// [DIRECT]部門代號{DepartmentCode:50}：【AB0913】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOD_ParentCode_XXColumn;

        /// <summary>
        /// #完整部門名稱{DepartmentFullName_XX}：【市政府\資訊中心】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOD_ParentFullName_XXColumn;

        /// <summary>
        /// [DIRECT]父部門Id{ParentId}：【KEY&lt;EOD&gt;】
        /// </summary> 
        public DataColumn EOD_ParentIdColumn;

        /// <summary>
        /// [DIRECT]*部門名稱{DepartmentName:50}：【資訊中心】&lt;br/&gt;
        /// </summary> 
        public DataColumn EOD_ParentName_XXColumn;

        /// <summary>
        /// #範圍階層號碼{ScopeLevelNo_XX:INT}：【10】※0台南 1台灣 2世界
        /// </summary> 
        public DataColumn EOD_ScopeLevelNo_XXColumn;

        /// <summary>
        /// #範圍樹系號碼{ScopeTreeLeftNo_XX:INT}：【10】
        /// </summary> 
        public DataColumn EOD_ScopeTreeLeftNo_XXColumn;

        /// <summary>
        /// #範圍樹系號碼{ScopeTreeRightNo_XX:INT}：【10】
        /// </summary> 
        public DataColumn EOD_ScopeTreeRightNo_XXColumn;

        /// <summary>
        /// [DIRECT]*排序順序{SortNo:INT}：【1】
        /// </summary> 
        public DataColumn EOD_SortNoColumn;

        /// <summary>
        /// [DIRECT]*群組可見性{VirtualType:1}：○{Name}公開 ○{Name_U}非公開
        /// </summary> 
        public DataColumn EOD_VirtualTypeColumn;

        /// <summary>
        /// FindRow By PrimaryKey
        /// </summary>  
        [DebuggerNonUserCodeAttribute()]
        public EO_DepartmentRow findByPrimaryKey(String EOD_DepartmentId)
        {
            return (EO_DepartmentRow)(Rows.Find(new object[] { EOD_DepartmentId }));
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataTable CreateInstance()
        {
            return new EO_DepartmentDataTable();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void initColumns()
        {
            EOD_DepartmentIdColumn = Columns["EOD_DepartmentId"];
            EOD_BrotherCount_XXColumn = Columns["EOD_BrotherCount_XX"];
            EOD_ChildCount_XXColumn = Columns["EOD_ChildCount_XX"];
            EOD_CU_IsVirtualVisible_XXColumn = Columns["EOD_CU_IsVirtualVisible_XX"];
            EOD_DepartmentCodeColumn = Columns["EOD_DepartmentCode"];
            EOD_DepartmentFullName_XXColumn = Columns["EOD_DepartmentFullName_XX"];
            EOD_DepartmentFullNameII_XXColumn = Columns["EOD_DepartmentFullNameII_XX"];
            EOD_DepartmentNameColumn = Columns["EOD_DepartmentName"];
            EOD_DepartmentObjectName_XXColumn = Columns["EOD_DepartmentObjectName_XX"];
            EOD_DepartmentTypeColumn = Columns["EOD_DepartmentType"];
            EOD_DepartmentTypeName_XXColumn = Columns["EOD_DepartmentTypeName_XX"];
            EOD_EmployeeCount_XXColumn = Columns["EOD_EmployeeCount_XX"];
            EOD_IsDeleteable_XXColumn = Columns["EOD_IsDeleteable_XX"];
            EOD_NoteColumn = Columns["EOD_Note"];
            EOD_ParentCode_XXColumn = Columns["EOD_ParentCode_XX"];
            EOD_ParentFullName_XXColumn = Columns["EOD_ParentFullName_XX"];
            EOD_ParentIdColumn = Columns["EOD_ParentId"];
            EOD_ParentName_XXColumn = Columns["EOD_ParentName_XX"];
            EOD_ScopeLevelNo_XXColumn = Columns["EOD_ScopeLevelNo_XX"];
            EOD_ScopeTreeLeftNo_XXColumn = Columns["EOD_ScopeTreeLeftNo_XX"];
            EOD_ScopeTreeRightNo_XXColumn = Columns["EOD_ScopeTreeRightNo_XX"];
            EOD_SortNoColumn = Columns["EOD_SortNo"];
            EOD_VirtualTypeColumn = Columns["EOD_VirtualType"];
            base.initColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override void createColumns()
        {
            EOD_DepartmentIdColumn = new DataColumn("EOD_DepartmentId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOD_DepartmentIdColumn);
            EOD_DepartmentIdColumn.AllowDBNull = false;

            EOD_BrotherCount_XXColumn = new DataColumn("EOD_BrotherCount_XX", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(EOD_BrotherCount_XXColumn);

            EOD_ChildCount_XXColumn = new DataColumn("EOD_ChildCount_XX", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(EOD_ChildCount_XXColumn);

            EOD_CU_IsVirtualVisible_XXColumn = new DataColumn("EOD_CU_IsVirtualVisible_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOD_CU_IsVirtualVisible_XXColumn);

            EOD_DepartmentCodeColumn = new DataColumn("EOD_DepartmentCode", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOD_DepartmentCodeColumn);

            EOD_DepartmentFullName_XXColumn = new DataColumn("EOD_DepartmentFullName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOD_DepartmentFullName_XXColumn);

            EOD_DepartmentFullNameII_XXColumn = new DataColumn("EOD_DepartmentFullNameII_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOD_DepartmentFullNameII_XXColumn);

            EOD_DepartmentNameColumn = new DataColumn("EOD_DepartmentName", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOD_DepartmentNameColumn);

            EOD_DepartmentObjectName_XXColumn = new DataColumn("EOD_DepartmentObjectName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOD_DepartmentObjectName_XXColumn);

            EOD_DepartmentTypeColumn = new DataColumn("EOD_DepartmentType", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOD_DepartmentTypeColumn);

            EOD_DepartmentTypeName_XXColumn = new DataColumn("EOD_DepartmentTypeName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOD_DepartmentTypeName_XXColumn);

            EOD_EmployeeCount_XXColumn = new DataColumn("EOD_EmployeeCount_XX", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(EOD_EmployeeCount_XXColumn);

            EOD_IsDeleteable_XXColumn = new DataColumn("EOD_IsDeleteable_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOD_IsDeleteable_XXColumn);

            EOD_NoteColumn = new DataColumn("EOD_Note", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOD_NoteColumn);

            EOD_ParentCode_XXColumn = new DataColumn("EOD_ParentCode_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOD_ParentCode_XXColumn);

            EOD_ParentFullName_XXColumn = new DataColumn("EOD_ParentFullName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOD_ParentFullName_XXColumn);

            EOD_ParentIdColumn = new DataColumn("EOD_ParentId", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOD_ParentIdColumn);

            EOD_ParentName_XXColumn = new DataColumn("EOD_ParentName_XX", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOD_ParentName_XXColumn);

            EOD_ScopeLevelNo_XXColumn = new DataColumn("EOD_ScopeLevelNo_XX", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(EOD_ScopeLevelNo_XXColumn);

            EOD_ScopeTreeLeftNo_XXColumn = new DataColumn("EOD_ScopeTreeLeftNo_XX", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(EOD_ScopeTreeLeftNo_XXColumn);

            EOD_ScopeTreeRightNo_XXColumn = new DataColumn("EOD_ScopeTreeRightNo_XX", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(EOD_ScopeTreeRightNo_XXColumn);

            EOD_SortNoColumn = new DataColumn("EOD_SortNo", typeof(Int32), null, MappingType.Attribute);
            Columns.Add(EOD_SortNoColumn);

            EOD_VirtualTypeColumn = new DataColumn("EOD_VirtualType", typeof(String), null, MappingType.Attribute);
            Columns.Add(EOD_VirtualTypeColumn);

            Constraints.Add(new UniqueConstraint("PrimaryKey", new DataColumn[] { EOD_DepartmentIdColumn }, true));
            base.createColumns();
        }

        [DebuggerNonUserCodeAttribute()]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new EO_DepartmentRow(builder);
        }

    }

    ///<summary>
    ///&lt;EOD&gt;部門{Department}  
    ///</summary>
    public class EO_DepartmentRow : FtdDataRow
    {
        private EO_DepartmentDataTable theTable;

        [DebuggerNonUserCodeAttribute()]
        protected internal EO_DepartmentRow(DataRowBuilder rb)
            : base(rb)
        {
            theTable = ((EO_DepartmentDataTable)(Table));
        }

        [DebuggerNonUserCodeAttribute()]
        public EO_DepartmentDataTable TypeTable
        {
            get { return (EO_DepartmentDataTable)Table; }
        }

        ///<summary>
        ///[DIRECT]*部門ID{DepartmentId}：【PK&lt;EOD&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOD_DepartmentId
        {
            get { return getAttrGetString(this[theTable.EOD_DepartmentIdColumn]); }
            set { this[theTable.EOD_DepartmentIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///#兄弟點數量{BrotherCount_XX:N}：【5】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? EOD_BrotherCount_XX
        {
            get { return getAttrGetValue<Int32>(this[theTable.EOD_BrotherCount_XXColumn]); }
            set { this[this.theTable.EOD_BrotherCount_XXColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///#子部門數量{ChildDeptCount_XX:INT}：【1】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? EOD_ChildCount_XX
        {
            get { return getAttrGetValue<Int32>(this[theTable.EOD_ChildCount_XXColumn]); }
            set { this[this.theTable.EOD_ChildCount_XXColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///#{目前登入者}可否檢視此群組{CU_IsVirtualVisible}：○{T}是 ○{F}不是             ※(群組需為公開)或是(非公開，但是為其成員者)。  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOD_CU_IsVirtualVisible_XX
        {
            get { return getAttrGetString(this[theTable.EOD_CU_IsVirtualVisible_XXColumn]); }
            set { this[theTable.EOD_CU_IsVirtualVisible_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]部門代號{DepartmentCode:50}：【AB0913】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOD_DepartmentCode
        {
            get { return getAttrGetString(this[theTable.EOD_DepartmentCodeColumn]); }
            set { this[theTable.EOD_DepartmentCodeColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///#完整部門名稱{DepartmentFullName_XX}：【市政府\資訊中心】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOD_DepartmentFullName_XX
        {
            get { return getAttrGetString(this[theTable.EOD_DepartmentFullName_XXColumn]); }
            set { this[theTable.EOD_DepartmentFullName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///#完整部門名稱II{DepartmentFullNameII_XX}：【A001-市政府\資訊中心】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOD_DepartmentFullNameII_XX
        {
            get { return getAttrGetString(this[theTable.EOD_DepartmentFullNameII_XXColumn]); }
            set { this[theTable.EOD_DepartmentFullNameII_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*部門名稱{DepartmentName:50}：【資訊中心】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOD_DepartmentName
        {
            get { return getAttrGetString(this[theTable.EOD_DepartmentNameColumn]); }
            set { this[theTable.EOD_DepartmentNameColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]#部門物件名稱{DepartmentObjectName_XX}：【[部門]資訊中心】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOD_DepartmentObjectName_XX
        {
            get { return getAttrGetString(this[theTable.EOD_DepartmentObjectName_XXColumn]); }
            set { this[theTable.EOD_DepartmentObjectName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*部門類型{DepartmentType:1,DepartmentTypeName_XX}：○{Name}正式部門 ○{Name_U}會員群組  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOD_DepartmentType
        {
            get { return getAttrGetString(this[theTable.EOD_DepartmentTypeColumn]); }
            set { this[theTable.EOD_DepartmentTypeColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*部門類型{DepartmentType:1,DepartmentTypeName_XX}：○{Name}部門 ○{Name_U}群組  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOD_DepartmentTypeName_XX
        {
            get { return getAttrGetString(this[theTable.EOD_DepartmentTypeName_XXColumn]); }
            set { this[theTable.EOD_DepartmentTypeName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///#人員數量{EmployeeCount_XX:INT}：【5】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? EOD_EmployeeCount_XX
        {
            get { return getAttrGetValue<Int32>(this[theTable.EOD_EmployeeCount_XXColumn]); }
            set { this[this.theTable.EOD_EmployeeCount_XXColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///#可否刪除{IsDeleteable_XX}：○{T}是 ○{F}是             ※部門有子部門或有人員者禁止刪除※群組有子群組者禁止刪除  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOD_IsDeleteable_XX
        {
            get { return getAttrGetString(this[theTable.EOD_IsDeleteable_XXColumn]); }
            set { this[theTable.EOD_IsDeleteable_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*備註{Note:100}：【This is node great deparment】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOD_Note
        {
            get { return getAttrGetString(this[theTable.EOD_NoteColumn]); }
            set { this[theTable.EOD_NoteColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]部門代號{DepartmentCode:50}：【AB0913】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOD_ParentCode_XX
        {
            get { return getAttrGetString(this[theTable.EOD_ParentCode_XXColumn]); }
            set { this[theTable.EOD_ParentCode_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///#完整部門名稱{DepartmentFullName_XX}：【市政府\資訊中心】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOD_ParentFullName_XX
        {
            get { return getAttrGetString(this[theTable.EOD_ParentFullName_XXColumn]); }
            set { this[theTable.EOD_ParentFullName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]父部門Id{ParentId}：【KEY&lt;EOD&gt;】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOD_ParentId
        {
            get { return getAttrGetString(this[theTable.EOD_ParentIdColumn]); }
            set { this[theTable.EOD_ParentIdColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///[DIRECT]*部門名稱{DepartmentName:50}：【資訊中心】&lt;br/&gt;  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOD_ParentName_XX
        {
            get { return getAttrGetString(this[theTable.EOD_ParentName_XXColumn]); }
            set { this[theTable.EOD_ParentName_XXColumn] = getAttrSetString(value); }
        }

        ///<summary>
        ///#範圍階層號碼{ScopeLevelNo_XX:INT}：【10】※0台南 1台灣 2世界  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? EOD_ScopeLevelNo_XX
        {
            get { return getAttrGetValue<Int32>(this[theTable.EOD_ScopeLevelNo_XXColumn]); }
            set { this[this.theTable.EOD_ScopeLevelNo_XXColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///#範圍樹系號碼{ScopeTreeLeftNo_XX:INT}：【10】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? EOD_ScopeTreeLeftNo_XX
        {
            get { return getAttrGetValue<Int32>(this[theTable.EOD_ScopeTreeLeftNo_XXColumn]); }
            set { this[this.theTable.EOD_ScopeTreeLeftNo_XXColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///#範圍樹系號碼{ScopeTreeRightNo_XX:INT}：【10】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? EOD_ScopeTreeRightNo_XX
        {
            get { return getAttrGetValue<Int32>(this[theTable.EOD_ScopeTreeRightNo_XXColumn]); }
            set { this[this.theTable.EOD_ScopeTreeRightNo_XXColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///[DIRECT]*排序順序{SortNo:INT}：【1】  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public Int32? EOD_SortNo
        {
            get { return getAttrGetValue<Int32>(this[theTable.EOD_SortNoColumn]); }
            set { this[this.theTable.EOD_SortNoColumn] = getAttrSetValue<Int32>(value); }
        }

        ///<summary>
        ///[DIRECT]*群組可見性{VirtualType:1}：○{Name}公開 ○{Name_U}非公開  
        ///</summary>
        [DebuggerNonUserCodeAttribute()]
        public string EOD_VirtualType
        {
            get { return getAttrGetString(this[theTable.EOD_VirtualTypeColumn]); }
            set { this[theTable.EOD_VirtualTypeColumn] = getAttrSetString(value); }
        }

    }
}
