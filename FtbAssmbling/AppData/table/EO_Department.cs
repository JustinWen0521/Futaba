using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using ftd.nsql;
using ftd.service;
using ftd.data.nstable;
namespace ftd.data
{
    /// <summary>
    /// &lt;EOD&gt;部門{Department}
    /// </summary>
    public interface EO_Department : INsTable
    {
        /// <summary>
        /// [DIRECT]*部門ID{DepartmentId}：【PK&lt;EOD&gt;】
        /// </summary> 
        NsColumn EOD_DepartmentId { get; }
        /// <summary>
        /// #兄弟點數量{BrotherCount_XX:N}：【5】
        /// </summary> 
        NsColumn EOD_BrotherCount_XX { get; }
        /// <summary>
        /// #子部門數量{ChildDeptCount_XX:INT}：【1】
        /// </summary> 
        NsColumn EOD_ChildCount_XX { get; }
        /// <summary>
        /// #{目前登入者}可否檢視此群組{CU_IsVirtualVisible}：○{T}是 ○{F}不是             ※(群組需為公開)或是(非公開，但是為其成員者)。
        /// </summary> 
        NsColumn EOD_CU_IsVirtualVisible_XX { get; }
        /// <summary>
        /// [DIRECT]部門代號{DepartmentCode:50}：【AB0913】
        /// </summary> 
        NsColumn EOD_DepartmentCode { get; }
        /// <summary>
        /// #完整部門名稱{DepartmentFullName_XX}：【市政府\資訊中心】
        /// </summary> 
        NsColumn EOD_DepartmentFullName_XX { get; }
        /// <summary>
        /// #完整部門名稱II{DepartmentFullNameII_XX}：【A001-市政府\資訊中心】
        /// </summary> 
        NsColumn EOD_DepartmentFullNameII_XX { get; }
        /// <summary>
        /// [DIRECT]*部門名稱{DepartmentName:50}：【資訊中心】
        /// </summary> 
        NsColumn EOD_DepartmentName { get; }
        /// <summary>
        /// [DIRECT]#部門物件名稱{DepartmentObjectName_XX}：【[部門]資訊中心】
        /// </summary> 
        NsColumn EOD_DepartmentObjectName_XX { get; }
        /// <summary>
        /// [DIRECT]*部門類型{DepartmentType:1,DepartmentTypeName_XX}：○{Name}正式部門 ○{Name_U}會員群組
        /// </summary> 
        NsColumn EOD_DepartmentType { get; }
        /// <summary>
        /// [DIRECT]*部門類型{DepartmentType:1,DepartmentTypeName_XX}：○{Name}部門 ○{Name_U}群組
        /// </summary> 
        NsColumn EOD_DepartmentTypeName_XX { get; }
        /// <summary>
        /// #人員數量{EmployeeCount_XX:INT}：【5】
        /// </summary> 
        NsColumn EOD_EmployeeCount_XX { get; }
        /// <summary>
        /// #可否刪除{IsDeleteable_XX}：○{T}是 ○{F}是             ※部門有子部門或有人員者禁止刪除※群組有子群組者禁止刪除
        /// </summary> 
        NsColumn EOD_IsDeleteable_XX { get; }
        /// <summary>
        /// [DIRECT]*備註{Note:100}：【This is node great deparment】
        /// </summary> 
        NsColumn EOD_Note { get; }
        /// <summary>
        /// [DIRECT]部門代號{DepartmentCode:50}：【AB0913】&lt;br/&gt;
        /// </summary> 
        NsColumn EOD_ParentCode_XX { get; }
        /// <summary>
        /// #完整部門名稱{DepartmentFullName_XX}：【市政府\資訊中心】&lt;br/&gt;
        /// </summary> 
        NsColumn EOD_ParentFullName_XX { get; }
        /// <summary>
        /// [DIRECT]父部門Id{ParentId}：【KEY&lt;EOD&gt;】
        /// </summary> 
        NsColumn EOD_ParentId { get; }
        /// <summary>
        /// [DIRECT]*部門名稱{DepartmentName:50}：【資訊中心】&lt;br/&gt;
        /// </summary> 
        NsColumn EOD_ParentName_XX { get; }
        /// <summary>
        /// #範圍階層號碼{ScopeLevelNo_XX:INT}：【10】※0台南 1台灣 2世界
        /// </summary> 
        NsColumn EOD_ScopeLevelNo_XX { get; }
        /// <summary>
        /// #範圍樹系號碼{ScopeTreeLeftNo_XX:INT}：【10】
        /// </summary> 
        NsColumn EOD_ScopeTreeLeftNo_XX { get; }
        /// <summary>
        /// #範圍樹系號碼{ScopeTreeRightNo_XX:INT}：【10】
        /// </summary> 
        NsColumn EOD_ScopeTreeRightNo_XX { get; }
        /// <summary>
        /// [DIRECT]*排序順序{SortNo:INT}：【1】
        /// </summary> 
        NsColumn EOD_SortNo { get; }
        /// <summary>
        /// [DIRECT]*群組可見性{VirtualType:1}：○{Name}公開 ○{Name_U}非公開
        /// </summary> 
        NsColumn EOD_VirtualType { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class EO_DepartmentNsTable : NsTable, EO_Department
        {
            public NsColumn EOD_DepartmentId
            {
                  get { return this["EOD_DepartmentId"]; }
            }
            public NsColumn EOD_BrotherCount_XX
            {
                  get { return this["EOD_BrotherCount_XX"]; }
            }
            public NsColumn EOD_ChildCount_XX
            {
                  get { return this["EOD_ChildCount_XX"]; }
            }
            public NsColumn EOD_CU_IsVirtualVisible_XX
            {
                  get { return this["EOD_CU_IsVirtualVisible_XX"]; }
            }
            public NsColumn EOD_DepartmentCode
            {
                  get { return this["EOD_DepartmentCode"]; }
            }
            public NsColumn EOD_DepartmentFullName_XX
            {
                  get { return this["EOD_DepartmentFullName_XX"]; }
            }
            public NsColumn EOD_DepartmentFullNameII_XX
            {
                  get { return this["EOD_DepartmentFullNameII_XX"]; }
            }
            public NsColumn EOD_DepartmentName
            {
                  get { return this["EOD_DepartmentName"]; }
            }
            public NsColumn EOD_DepartmentObjectName_XX
            {
                  get { return this["EOD_DepartmentObjectName_XX"]; }
            }
            public NsColumn EOD_DepartmentType
            {
                  get { return this["EOD_DepartmentType"]; }
            }
            public NsColumn EOD_DepartmentTypeName_XX
            {
                  get { return this["EOD_DepartmentTypeName_XX"]; }
            }
            public NsColumn EOD_EmployeeCount_XX
            {
                  get { return this["EOD_EmployeeCount_XX"]; }
            }
            public NsColumn EOD_IsDeleteable_XX
            {
                  get { return this["EOD_IsDeleteable_XX"]; }
            }
            public NsColumn EOD_Note
            {
                  get { return this["EOD_Note"]; }
            }
            public NsColumn EOD_ParentCode_XX
            {
                  get { return this["EOD_ParentCode_XX"]; }
            }
            public NsColumn EOD_ParentFullName_XX
            {
                  get { return this["EOD_ParentFullName_XX"]; }
            }
            public NsColumn EOD_ParentId
            {
                  get { return this["EOD_ParentId"]; }
            }
            public NsColumn EOD_ParentName_XX
            {
                  get { return this["EOD_ParentName_XX"]; }
            }
            public NsColumn EOD_ScopeLevelNo_XX
            {
                  get { return this["EOD_ScopeLevelNo_XX"]; }
            }
            public NsColumn EOD_ScopeTreeLeftNo_XX
            {
                  get { return this["EOD_ScopeTreeLeftNo_XX"]; }
            }
            public NsColumn EOD_ScopeTreeRightNo_XX
            {
                  get { return this["EOD_ScopeTreeRightNo_XX"]; }
            }
            public NsColumn EOD_SortNo
            {
                  get { return this["EOD_SortNo"]; }
            }
            public NsColumn EOD_VirtualType
            {
                  get { return this["EOD_VirtualType"]; }
            }
        }
    }
}
