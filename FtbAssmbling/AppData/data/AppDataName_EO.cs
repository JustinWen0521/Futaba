using System;
using System.Collections.Generic;
using System.Text;
using ftd.data.model.tag;
using ftd.data.model.datatype;
using ftd.data;
using ftd.nsql;

namespace ftd.data
{
    /// <summary>
    /// 資料名稱
    /// </summary>
    public partial class AppDataName : FdmDataName
    {
        /// <summary>
        /// Enterprise Organization
        /// </summary>        
        [FdmSystemDef("EO_")]
        public const string EO = "EO";

        #region [EO_Organization]
        ///// <summary>
        ///// &lt;EOO>組織{Organization}
        ///// </summary>
        //[FdmTableDef("EOO_", EOO_OrganizationId, IsSessionEnable = false,
        //      RowInsertUserName = AppDataName.EOO_CreatorId,
        //      RowInsertDateName = AppDataName.EOO_CreateDate,
        //      RowModifyUserName = AppDataName.EOO_UpdaterId,
        //      RowModifyDateName = AppDataName.EOO_UpdateDate
        //    )]
        //[FdmTableProvider("ftd.dataaccess.EoOrganizationProvider, AppService")]
        //public const string EO_Organization = "EO_Organization";

        ///// <summary>
        ///// *組織ID{OrganizationId}：【PK&lt;EOO>】
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //public const string EOO_OrganizationId = "EOO_OrganizationId";

        ///// <summary>
        ///// 組織代號{Code:10}：【AB0913】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR10)]
        //public const string EOO_Code = "EOO_Code";

        ///// <summary>
        ///// *組織名稱{FullName:50}：【永利果菜批發商行】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR50)]
        //public const string EOO_FullName = "EOO_FullName";

        ///// <summary>
        ///// *組織簡稱{ShortName:10}：【永利行】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR10)]
        //public const string EOO_ShortName = "EOO_ShortName";

        ///// <summary>
        ///// 地址{Address:100}
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR100)]
        //public const string EOO_Address = "EOO_Address";

        ///// <summary>
        ///// 電話1{Phone1:20}
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //public const string EOO_Phone1 = "EOO_Phone1";

        ///// <summary>
        ///// 電話2{Phone2:20}
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //public const string EOO_Phone2 = "EOO_Phone2";

        ///// <summary>
        ///// 傳真{Fax:20}
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //public const string EOO_Fax = "EOO_Fax";

        ///// <summary>
        ///// 聯絡人{Contact:10}
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR10)]
        //public const string EOO_Contact = "EOO_Contact";

        ///// <summary>
        ///// Email{Email:100}
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR100)]
        //public const string EOO_Email = "EOO_Email";

        ///// <summary>
        ///// 統一編號{UnifiedNo:10}
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR10)]
        //public const string EOO_UnifiedNo = "EOO_UnifiedNo";

        ///// <summary>
        ///// 登記證號{RegisterNo:20}
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //public const string EOO_RegisterNo = "EOO_RegisterNo";

        ///// <summary>
        ///// 登記日期{RegisterDate:D}
        ///// </summary>
        //[FdmStyleType(DTN_DATETIME_10)]
        //public const string EOO_RegisterDate = "EOO_RegisterDate";

        ///// <summary>
        ///// 銀行代號{BankCode:10}
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR10)]
        //public const string EOO_BankCode = "EOO_BankCode";

        ///// <summary>
        ///// 銀行名稱{BankName:50}
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR50)]
        //public const string EOO_BankName = "EOO_BankName";

        ///// <summary>
        ///// 銀行帳戶{BankAccount:20}
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //public const string EOO_BankAccount = "EOO_BankAccount";

        ///// <summary>
        ///// 帳戶名稱{BankAccountName:50}
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR50)]
        //public const string EOO_BankAccountName = "EOO_BankAccountName";

        ///// <summary>
        ///// 備註{Remark:100}
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR100)]
        //public const string EOO_Remark = "EOO_Remark";

        ///// <summary>
        ///// 信用額度{Bail:INT}
        ///// </summary>
        //[FdmStyleType(DTN_INTEGER)]
        //public const string EOO_Bail = "EOO_Bail";

        ///// <summary>
        ///// 狀態{Status:1}
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR1)]
        //public const string EOO_Status = "EOO_Status";

        ///// <summary>
        ///// 狀態說明{StatusName_XX:10}【A：啟用 / B：暫停 / Z：廢止】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR10)]
        //[FdmCodeName("CTN_EOO_Status", EOO_Status)]
        //public const string EOO_StatusName_XX = "EOO_StatusName_XX";

        ///// <summary>
        ///// 暫停或廢止原因{Reason:50}
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR50)]
        //public const string EOO_Reason = "EOO_Reason";

        ///// <summary>
        ///// *建立者id{CreatorId：Id}：
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //public const string EOO_CreatorId = "EOO_CreatorId";

        ///// <summary>
        ///// *建立者姓名{CreatorName_XX：NVARCHAR20}：
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //[FdmLink(EOO_CreatorId, AppDataName.EOE_EmployeeName)]
        //public const string EOO_CreatorName_XX = "EOO_CreatorName_XX";

        ///// <summary>
        ///// *建立日期{CreateDate：DATETIME_19}：【yyyy/MM/dd HH:mm:ss】
        ///// </summary>
        //[FdmStyleType(DTN_DATETIME_19)]
        //public const string EOO_CreateDate = "EOO_CreateDate";

        ///// <summary>
        ///// *異動者id{UpdaterId：Id}：
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //public const string EOO_UpdaterId = "EOO_UpdaterId";

        ///// <summary>
        ///// *異動者姓名{UpdaterName_XX：NVARCHAR20}：
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //[FdmLink(EOO_UpdaterId, AppDataName.EOE_EmployeeName)]
        //public const string EOO_UpdaterName_XX = "EOO_UpdaterName_XX";

        ///// <summary>
        ///// *異動日期{UpdateDate：DATETIME_19}：【yyyy/MM/dd HH:mm:ss】
        ///// </summary>
        //[FdmStyleType(DTN_DATETIME_19)]
        //public const string EOO_UpdateDate = "EOO_UpdateDate";

        #endregion

        #region [EO_Department]
        /// <summary>
        /// &lt;EOD>部門{Department}
        /// </summary>
        [FdmTableDef("EOD_", EOD_DepartmentId, IsSessionEnable = false)]
        [FdmTableProvider("ftd.dataaccess.EoDepartmentProvider, AppService")]
        [FdmCodeGen(Title = "部門")]
        public const string EO_Department = "EO_Department";

        /// <summary>
        /// *部門ID{DepartmentId}：【PK&lt;EOD>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "部門ID", IsRequired = true, IsSearch = false, IsUnique = true, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOD_DepartmentId = "EOD_DepartmentId";

        /// <summary>
        /// 部門代號{DepartmentCode:50}：【AB0913】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        [FdmCodeGen(Title = "部門代號", IsRequired = true, IsSearch = true, IsUnique = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOD_DepartmentCode = "EOD_DepartmentCode";

        /// <summary>
        /// *部門名稱{DepartmentName:50}：【資訊中心】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        [FdmCodeGen(Title = "部門名稱", IsRequired = true, IsSearch = true, IsUnique = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOD_DepartmentName = "EOD_DepartmentName";

        /// <summary>
        /// #範圍階層號碼{ScopeLevelNo_XX:INT}：【10】※0台南 1台灣 2世界
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCalculate]
        [FdmCodeGen(Title = "範圍階層號碼", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOD_ScopeLevelNo_XX = "EOD_ScopeLevelNo_XX";

        /// <summary>
        /// #範圍樹系號碼{ScopeTreeLeftNo_XX:INT}：【10】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCalculate]
        public const string EOD_ScopeTreeLeftNo_XX = "EOD_ScopeTreeLeftNo_XX";

        /// <summary>
        /// #範圍樹系號碼{ScopeTreeRightNo_XX:INT}：【10】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCalculate()]
        public const string EOD_ScopeTreeRightNo_XX = "EOD_ScopeTreeRightNo_XX";

        /// <summary>
        /// #完整部門名稱{DepartmentFullName_XX}：【市政府\資訊中心】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmCalculate]
        public const string EOD_DepartmentFullName_XX = "EOD_DepartmentFullName_XX";

        /// <summary>
        /// #完整部門名稱II{DepartmentFullNameII_XX}：【A001-市政府\資訊中心】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]        
        [FdmCalculate]
        public const string EOD_DepartmentFullNameII_XX = "EOD_DepartmentFullNameII_XX";

        /// <summary>
        /// #部門物件名稱{DepartmentObjectName_XX}：【[部門]資訊中心】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        [FdmCalculate]        
        public const string EOD_DepartmentObjectName_XX = "EOD_DepartmentObjectName_XX";

        /// <summary>
        /// *部門類型{DepartmentType:1,DepartmentTypeName_XX}：○{Name}正式部門 ○{Name_U}會員群組
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        public const string EOD_DepartmentType = "EOD_DepartmentType";

        /// <summary>
        /// *部門類型{DepartmentType:1,DepartmentTypeName_XX}：○{Name}部門 ○{Name_U}群組
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmCalculate]
        public const string EOD_DepartmentTypeName_XX = "EOD_DepartmentTypeName_XX";

        /// <summary>
        /// *群組可見性{VirtualType:1}：○{Name}公開 ○{Name_U}非公開
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        public const string EOD_VirtualType = "EOD_VirtualType";

        /// <summary>
        /// *排序順序{SortNo:INT}：【1】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        public const string EOD_SortNo = "EOD_SortNo";

        /// <summary>
        /// #子部門數量{ChildDeptCount_XX:INT}：【1】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCalculate]
        public const string EOD_ChildCount_XX = "EOD_ChildCount_XX";

        /// <summary>
        /// #兄弟點數量{BrotherCount_XX:N}：【5】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCalculate]
        public const string EOD_BrotherCount_XX = "EOD_BrotherCount_XX";

        /// <summary>
        /// 父部門Id{ParentId}：【KEY&lt;EOD>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        public const string EOD_ParentId = "EOD_ParentId";

        /// <summary>
        /// #父部門CODE{ParentCode_XX}：【A123】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmLink(EOD_ParentId, EOD_DepartmentCode)]
        public const string EOD_ParentCode_XX = "EOD_ParentCode_XX";

        /// <summary>
        /// #父部門名稱{ParentName_XX}：【資訊中心】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmLink(EOD_ParentId, EOD_DepartmentName)]
        public const string EOD_ParentName_XX = "EOD_ParentName_XX";

        /// <summary>
        ///  #父部門名稱{ParentFullName_XX}：【市政府\資訊中心】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmLink(EOD_ParentId, EOD_DepartmentFullName_XX)]
        public const string EOD_ParentFullName_XX = "EOD_ParentFullName_XX";

        /// <summary>
        /// #人員數量{EmployeeCount_XX:INT}：【5】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCalculate]
        public const string EOD_EmployeeCount_XX = "EOD_EmployeeCount_XX";

        /// <summary>
        /// #{目前登入者}可否檢視此群組{CU_IsVirtualVisible}：○{T}是 ○{F}不是
        /// ※(群組需為公開)或是(非公開，但是為其成員者)。
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        [FdmCalculate]
        public const string EOD_CU_IsVirtualVisible_XX = "EOD_CU_IsVirtualVisible_XX";

        /// <summary>
        /// #可否刪除{IsDeleteable_XX}：○{T}是 ○{F}是
        /// ※部門有子部門或有人員者禁止刪除※群組有子群組者禁止刪除
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        [FdmCalculate]        
        public const string EOD_IsDeleteable_XX = "EOD_IsDeleteable_XX";

        /// <summary>
        /// *備註{Note:100}：【This is node great deparment】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR100)]
        public const string EOD_Note = "EOD_Note";

        ///// <summary>
        ///// *組織ID{OrgId}
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //public const string EOD_OrgId = "EOD_OrgId";

        ///// <summary>
        ///// *組織代號{OrgCode_XX：10}
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR10)]
        //[FdmLink(EOD_OrgId, EOO_Code)]
        //public const string EOD_OrgCode_XX = "EOD_OrgCode_XX";

        ///// <summary>
        ///// *組織名稱{OrgFullName_XX：50}
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR50)]
        //[FdmLink(EOD_OrgId, EOO_FullName)]
        //public const string EOD_OrgFullName_XX = "EOD_OrgFullName_XX";

        ///// <summary>
        ///// *組織簡稱{OrgShortName_XX：50}
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR10)]
        //[FdmLink(EOD_OrgId, EOO_ShortName)]
        //public const string EOD_OrgShortName_XX = "EOD_OrgShortName_XX";

        #endregion

        #region [EO_DeptMember]
        /// <summary>
        /// &lt;EODM>部門成員{DeptMember}
        /// </summary>
        [FdmTableDef("EODM_", EODM_DeptMemberId, IsSessionEnable = false)]
        [FdmTableProvider("ftd.dataaccess.EoDeptMemberProvider, AppService")]
        [FdmCodeGen(Title = "部門成員")]
        public const string EO_DeptMember = "EO_DeptMember";

        /// <summary>
        /// *PrimaryKey{DeptMemberId}：【PK&lt;EODM>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "部門成員ID", IsRequired = true, IsSearch = false, IsUnique = true, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EODM_DeptMemberId = "EODM_DeptMemberId";

        /// <summary>
        /// *部門Id{DeptId}：【&lt;EOD>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "部門ID", IsRequired = true, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EODM_DeptId = "EODM_DeptId";

        /// <summary>
        /// #部門代號{DeptCode_XX}：【A001】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EODM_DeptId, EOD_DepartmentCode)]
        public const string EODM_DeptCode_XX = "EODM_DeptCode_XX";

        /// <summary>
        /// #部門名稱{DeptName_XX}：【資訊中心】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EODM_DeptId, EOD_DepartmentName)]
        public const string EODM_DeptName_XX = "EODM_DeptName_XX";

        /// <summary>
        /// #部門類型{DeptType_XX:1,DeptTypeName_XX}：○{Name}部門 ○{Name_U}群組
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EODM_DeptId, EOD_DepartmentType)]
        public const string EODM_DeptType_XX = "EODM_DeptType_XX";

        /// <summary>
        /// #部門類型{DeptType_XX:1,DeptTypeName_XX}：○{Name}部門 ○{Name_U}群組        
        /// </summary>        
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EODM_DeptId, EOD_DepartmentTypeName_XX)]
        public const string EODM_DeptTypeName_XX = "EODM_DeptTypeName_XX";

        /// <summary>
        /// *成員Id{MemberId}：【&lt;EOD|EOE>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        public const string EODM_MemberId = "EODM_MemberId";

        /// <summary>
        /// #人員代號{EmpCode_XX}：【林勝文】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EODM_MemberId, EOE_EmployeeCode)]
        public const string EODM_EmpCode_XX = "EODM_EmpCode_XX";

        /// <summary>
        /// #人員姓名{EmpName_XX}：【林勝文】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EODM_MemberId, EOE_EmployeeName)]
        public const string EODM_EmpName_XX = "EODM_EmpName_XX";

        /// <summary>
        /// #人員姓名{EmpFullName_XX}：【市政府-林勝文 組長】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EODM_MemberId, EOE_EmployeeFullName_XX)]
        public const string EODM_EmpFullName_XX = "EODM_EmpFullName_XX";

        /// <summary>
        /// *人員職稱Id{EmpTitleId_XX}：【KEY&lt;EOET>】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EODM_MemberId, EOE_EmployeeTitleId)]
        public const string EODM_EmpTitleId_XX = "EODM_EmpTitleId_XX";

        /// <summary>
        /// #人員職稱{EmpTitleName_XX}：【組長】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EODM_MemberId, EOE_EmployeeTitleName_XX)]
        public const string EODM_EmpTitleName_XX = "EODM_EmpTitleName_XX";

        /// <summary>
        /// #人員正式部門{EmpDeptId_XX, EmpDeptName_XX}：【KEY&lt;EOD>, 資訊中心】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EODM_MemberId, EOE_DepartmentId)]
        public const string EODM_EmpDeptId_XX = "EODM_EmpDeptId_XX";

        /// <summary>
        /// #人員正式部門{EmpDeptId_XX, EmpDeptName_XX}：【KEY&lt;EOD>, 資訊中心】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EODM_MemberId, EOE_DepartmentName_XX)]
        public const string EODM_EmpDeptName_XX = "EODM_EmpDeptName_XX";

        /// <summary>
        /// #人員EMAIL{EmpEmail_XX}：【mail2@kcg.gov.tw】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EODM_MemberId, EOE_EmployeeEmail)]
        public const string EODM_EmpEmail_XX = "EODM_EmpEmail_XX";

        /// <summary>
        /// #人員性別{EmpSex_XX:1,EmpSexName_XX}：○{Name}男 ○{Name_U}女
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EODM_MemberId, EOE_Sex)]
        public const string EODM_EmpSex_XX = "EODM_EmpSex_XX";

        /// <summary>
        /// #人員性別{EmpSex_XX:1,EmpSexName_XX}：○{Name}男 ○{Name_U}女
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EODM_MemberId, EOE_SexName_XX)]
        public const string EODM_EmpSexName_XX = "EODM_EmpSexName_XX";

        /// <summary>
        /// #人員身分証字號{EmpSid_XX:20}：【R122322555】
        ///</summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EODM_MemberId, EOE_EmployeeSid)]
        public const string EODM_EmpSid_XX = "EODM_EmpSid_XX";

        /// <summary>
        /// #成員部門名稱{M_DeptName_XX}：【資訊中心】
        ///</summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EODM_MemberId, EOD_DepartmentName)]
        public const string EODM_M_DeptName_XX = "EODM_M_DeptName_XX";

        /// <summary>
        /// #成員部門Code{M_DepCode_XX}：【AB0913】
        ///</summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EODM_MemberId, EOD_DepartmentCode)]
        public const string EODM_M_DepCode_XX = "EODM_M_DepCode_XX";

        /// <summary>
        /// #成員部門類型{M_DeptType_XX, M_DeptTypeName_XX}：○{Name}部門 ○{Name_U}群組
        ///</summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EODM_MemberId, EOD_DepartmentType)]
        public const string EODM_M_DeptType_XX = "EODM_M_DeptType_XX";

        /// <summary>
        /// #成員部門類型{M_DeptType_XX, M_DeptTypeName_XX}：○{Name}部門 ○{Name_U}群組
        ///</summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EODM_MemberId, EOD_DepartmentTypeName_XX)]
        public const string EODM_M_DeptTypeName_XX = "EODM_M_DeptTypeName_XX";

        #endregion

        #region [EO_Employee]
        /// <summary>
        /// &lt;EOE>人員{Employee}
        /// </summary>
        [FdmTableDef("EOE_", EOE_EmployeeId, IsSessionEnable = false)]
        [FdmTableProvider("ftd.dataaccess.EoEmployeeProvider, AppService")]
        [FdmCodeGen(Title = "人員")]
        public const string EO_Employee = "EO_Employee";

        /// <summary>
        /// *人員ID{EmployeeId}：【PK&lt;EOE>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "人員ID", IsRequired = true, IsUnique = true, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOE_EmployeeId = "EOE_EmployeeId";

        /// <summary>
        /// *部門{DepartmentId, DepartmentName_XX}：【&lt;EOD>,資訊中心】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "部門ID", IsRequired = true, IsUnique = true, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOE_DepartmentId = "EOE_DepartmentId";

        /// <summary>
        /// *部門{DepartmentId, DepartmentName_XX}：【&lt;EOD>,資訊中心】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EOE_DepartmentId, EOD_DepartmentName)]
        [FdmCodeGen(Title = "部門名稱", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOE_DepartmentName_XX = "EOE_DepartmentName_XX";

        /// <summary>
        /// #部門完整名稱{DepartmentFullName_XX}：【市政府\資訊中心】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EOE_DepartmentId, EOD_DepartmentFullName_XX)]
        [FdmCodeGen(Title = "部門完整名稱", IsRequired = false, IsUnique = false, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOE_DepartmentFullName_XX = "EOE_DepartmentFullName_XX";

        /// <summary>
        /// #部門代號{DepartmentCode_XX }：【A001】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EOE_DepartmentId, EOD_DepartmentCode)]
        [FdmCodeGen(Title = "部門代號", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOE_DepartmentCode_XX = "EOE_DepartmentCode_XX";

        /// <summary>
        /// *人員姓名{EmployeeName:20}：【林勝文】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmCodeGen(Title = "人員姓名", IsRequired = true, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOE_EmployeeName = "EOE_EmployeeName";

        /// <summary>
        /// *職稱{EmployeeTitleId, EmployeeTitleName_XX, EmployeeTitleCode_XX}：【&lt;EOET>,主任,B01】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "職稱ID", IsRequired = true, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOE_EmployeeTitleId = "EOE_EmployeeTitleId";

        /// <summary>
        /// *職稱{EmployeeTitleId, EmployeeTitleName_XX, EmployeeTitleCode_XX}：【&lt;EOET>,主任,B01】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EOE_EmployeeTitleId, EOET_TitleName)]
        [FdmCodeGen(Title = "職稱", IsRequired = false, IsUnique = false, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOE_EmployeeTitleName_XX = "EOE_EmployeeTitleName_XX";

        /// <summary>
        /// *職稱代號{EmployeeTitleId, EmployeeTitleName_XX, EmployeeTitleCode_XX}：【&lt;EOET>,主任,B01】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EOE_EmployeeTitleId, EOET_TitleCode)]
        [FdmCodeGen(Title = "職稱代號", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOE_EmployeeTitleCode_XX = "EOE_EmployeeTitleCode_XX";

        /// <summary>
        /// 人員編號{EmployeeCode:20}：【EA001】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmCodeGen(Title = "人員編號", IsRequired = true, IsUnique = true, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOE_EmployeeCode = "EOE_EmployeeCode";

        /// <summary>
        /// #標準姓名{EmployeeStandardName_XX}：【林勝文 組長】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmCalculate]
        [FdmCodeGen(Title = "標準姓名", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOE_EmployeeStandardName_XX = "EOE_EmployeeStandardName_XX";

        /// <summary>
        /// #完整姓名{EmployeeFullName_XX}：【市政府-林勝文 組長】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmCalculate]
        [FdmCodeGen(Title = "完整姓名", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOE_EmployeeFullName_XX = "EOE_EmployeeFullName_XX";

        /// <summary>
        /// #搜尋用名稱 {EmployeeSearchName_XX}：【林勝文 組長 (shengwen@mail2000.com.tw)】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmCalculate]
        [FdmCodeGen(Title = "名稱", IsRequired = false, IsUnique = false, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOE_EmployeeSearchName_XX = "EOE_EmployeeSearchName_XX";

        /// <summary>
        /// *Email{EmployeeEmail:50}：【shengwen@mail2000.com.tw】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        public const string EOE_EmployeeEmail = "EOE_EmployeeEmail";

        /// <summary>
        /// 身分証字號{EmployeeSid:20}：【R122322555】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        public const string EOE_EmployeeSid = "EOE_EmployeeSid";

        /// <summary>
        /// 聯絡電話1{Phone1:20}：【06-5951579】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        public const string EOE_Phone1 = "EOE_Phone1";

        /// <summary>
        /// 聯絡電話2{Phone2:20}：【0913670599】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        public const string EOE_Phone2 = "EOE_Phone2";

        /// <summary>
        /// 性別{Sex:1,SexName_XX}：○{Name}男 ○{Name_U}女
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        public const string EOE_Sex = "EOE_Sex";

        /// <summary>
        /// 性別{Sex:1,SexName_XX}：○{Name}男 ○{Name_U}女
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmCalculate]
        public const string EOE_SexName_XX = "EOE_SexName_XX";

        /// <summary>
        /// 簽名檔：{Signature:100}：【我很笨但我很溫柔】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR100)]
        public const string EOE_Signature = "EOE_Signature";

        /// <summary>
        /// 個人圖片{PersonalImage:50}：【XXXXXX00-00011.GIF】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        public const string EOE_PersonalImage = "EOE_PersonalImage";

        /// <summary>
        /// #登入帳號{LoginAccount_XX}：【David】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        [FdmLink(EOE_EmployeeId, EOLA_LoginAccount)]
        public const string EOE_LoginAccount_XX = "EOE_LoginAccount_XX";

        /// <summary>
        /// #登入密碼{LoginPassword_XX}：【#123$456】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmLink(EOE_EmployeeId, EOLA_LoginPassword)]
        public const string EOE_LoginPassword_XX = "EOE_LoginPassword_XX";

        /// <summary>
        /// *任職日期{EntryDate:D}：【2006/09/19】
        /// </summary>
        [FdmStyleType(DTN_DATETIME_10)]
        [FdmCodeGen(Title = "任職日期", IsRequired = false, IsUnique = false, IsSearch = true, IsSearchRange = true, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOE_EntryDate = "EOE_EntryDate";

        /// <summary>
        /// 離職日期{LeaveDate:D}：【2006/10/19】(※填此日期代表已離職，否則為在職)
        /// </summary>
        [FdmStyleType(DTN_DATETIME_10)]
        [FdmCodeGen(Title = "離職日期", IsRequired = false, IsUnique = false, IsSearch = true, IsSearchRange = true, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOE_LeaveDate = "EOE_LeaveDate";

        /// <summary>
        /// #是否離職{IsLeave_XX}：○{T}是 ○{F}不是
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        [FdmCalculate]
        public const string EOE_IsLeave_XX = "EOE_IsLeave_XX";

        /// <summary>
        /// *簡訊通知號碼{SmsNumber:20}：【0913670599】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        public const string EOE_SmsNumber = "EOE_SmsNumber";

        /// <summary>
        /// *郵遞區號{CZip:10} 【71804】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        public const string EOE_CZip = "EOE_CZip";

        /// <summary>
        /// *通訊住址{CAddress:50} 【高雄市 海邊路119巷37號】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        public const string EOE_CAddress = "EOE_CAddress";

        /// <summary>
        /// 備註{Remark:100}：【此員工表現良好】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR100)]
        public const string EOE_Remark = "EOE_Remark";

        /// <summary>
        /// #人員是否為目前登入者{CU_IsLoginUser_XX}：○{T}是 ○{F}不是
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmCalculate]
        public const string EOE_CU_IsLoginUser_XX = "EOE_CU_IsLoginUser_XX";

        ///// <summary>
        ///// 系統權限角色【A：系統管理員 / Y：機關管理員 / N：一般人員】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR1)]
        //public const string EOE_IsOrganManager = "EOE_IsOrganManager";

        ///// <summary>
        ///// 是否為財管人員【Y：是 / N：否】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR1)]
        //public const string EOE_IsManager = "EOE_IsManager";

        ///// <summary>
        ///// 是否為管區管理員【Y：是 / N：否】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR1)]
        //public const string EOE_IsDeptMgr = "EOE_IsDeptMgr";

        /// <summary>
        /// 是否啟用【T：是 / F：否】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        public const string EOE_Enabled = "EOE_Enabled";

        ///// <summary>
        ///// 機關代嗎{DTN_NID}：【397030000D】
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //public const string EOE_OrganId = "EOE_OrganId";

        ///// <summary>
        ///// #機關簡稱
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR100)]
        //[FdmLink(EOE_OrganId, SYO_OrganSName)]
        //public const string EOE_OrganSName_XX = "EOE_OrganSName_XX";

        ///// <summary>
        ///// #機關全銜
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR100)]
        //[FdmLink(EOE_OrganId, SYO_OrganAName)]
        //public const string EOE_OrganAName_XX = "EOE_OrganAName_XX";

        ///// <summary>
        ///// #機關儲存位置
        ///// </summary>
        //[FdmNVarcharType(2)]
        //[FdmLink(EOE_OrganId, SYO_StoreLoc)]
        //public const string EOE_OrganStoreLoc_XX = "EOE_OrganStoreLoc_XX";

        ///// <summary>
        ///// #機關簡碼
        ///// </summary>
        //[FdmNVarcharType(2)]
        //[FdmLink(EOE_OrganId, SYO_ShortId)]
        //public const string EOE_OrganShortId_XX = "EOE_OrganShortId_XX";

        ///// <summary>
        ///// #機關別(C：市有 / A：區有)
        ///// </summary>
        //[FdmNVarcharType(2)]
        //[FdmLink(EOE_OrganId, SYO_Title)]
        //public const string EOE_OrganTitle_XX = "EOE_OrganTitle_XX";

        ///// <summary>
        ///// #EnterpriseLimit(Y: / N:)
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR1)]
        //[FdmLink(EOE_OrganId, SYO_EnterpriseLimit)]
        //public const string EOE_EnterpriseLimit_XX = "EOE_EnterpriseLimit_XX";

        ///// <summary>
        ///// #OfficialLimit(1/2/99)
        ///// </summary>
        //[FdmNVarcharType(2)]
        //[FdmLink(EOE_OrganId, SYO_OfficialLimit)]
        //public const string EOE_OfficialLimit_XX = "EOE_OfficialLimit_XX";

        ///// <summary>
        ///// 單位{UnitName:20}：【總務處】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //public const string EOE_UnitName = "EOE_UnitName";

        #endregion

        #region [EO_EmployeeTitle]
        /// <summary>
        /// &lt;EOET>人員職稱{EmployeeTitle}
        /// </summary>
        [FdmTableDef("EOET_", EOET_EmployeeTitleId)]
        [FdmTableProvider("ftd.dataaccess.EoEmployeeTitleProvider, AppService")]
        [FdmCodeGen(Title = "職稱")]
        public const string EO_EmployeeTitle = "EO_EmployeeTitle";

        /// <summary>
        /// *職稱Id{EmployeeTitleId}：【PK&lt;EOET>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "職稱ID", IsRequired = true, IsUnique = true, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOET_EmployeeTitleId = "EOET_EmployeeTitleId";

        /// <summary>
        /// 職稱代號 {TitleCode:20}：【A312】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmCodeGen(Title = "職稱代號", IsRequired = true, IsUnique = true, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOET_TitleCode = "EOET_TitleCode";

        /// <summary>
        /// *職稱名稱{TitleName:20}：【組長】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmCodeGen(Title = "職稱名稱", IsRequired = true, IsUnique = false, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOET_TitleName = "EOET_TitleName";

        /// <summary>
        /// *職稱順序{ListOrder:INT}：【1000】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCodeGen(Title = "職稱順序", IsRequired = true, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOET_ListOrder = "EOET_ListOrder";

        /// <summary>
        /// #人數{UserCount_XX}：【1000】     
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCalculate]
        [FdmCodeGen(Title = "人數", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOET_UserCount_XX = "EOET_UserCount_XX";

        /// <summary>
        /// #是否正在使用中{InUse_XX,InUseName_XX}：○{T}是 ○{F}否     
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        [FdmCalculate]
        [FdmCodeGen(Title = "使用中", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOET_InUse_XX = "EOET_InUse_XX";

        /// <summary>
        /// #是否正在使用中{InUse_XX,InUseName_XX}：○{T}是 ○{F}否  
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmCalculate]
        [FdmCodeGen(Title = "使用中", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOET_InUseName_XX = "EOET_InUseName_XX";


        #endregion

        #region [EO_LoginAccount]
        /// <summary>
        /// &lt;EOLA>登入帳號{LoginAccount}
        /// </summary>
        [FdmTableDef("EOLA_", EOLA_LoginAccountId, KeyPrefix = "EOE_")]
        [FdmTableProvider("ftd.dataaccess.EoLoginAccountProvider, AppService")]       
        [FdmCodeGen(Title = "登入帳號")]
        public const string EO_LoginAccount = "EO_LoginAccount";

        /// <summary>
        /// *登入者Id{LoginAccountId}：【PK&lt;EOE>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "登入帳號ID", IsRequired = true, IsUnique = true, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOLA_LoginAccountId = "EOLA_LoginAccountId";

        /// <summary>
        /// *登入帳號{LoginAccount:50}：【Administrator】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]        
        [FdmCodeGen(Title = "登入帳號", IsRequired = true, IsUnique = true, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOLA_LoginAccount = "EOLA_LoginAccount";

        /// <summary>
        /// *登入密碼{LoginPassword:20}：【XYXCDE】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        public const string EOLA_LoginPassword = "EOLA_LoginPassword";

        /// <summary>
        /// #登入者姓名{UserName_XX}：【林勝文 組長】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EOLA_LoginAccountId, EOE_EmployeeStandardName_XX)]
        [FdmCodeGen(Title = "登入者姓名", IsRequired = false, IsUnique = false, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOLA_UserName_XX = "EOLA_UserName_XX";

        /// <summary>
        /// #登入者Email{UserEmail_XX:50}：【shengwen@mail2000.com.tw】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EOLA_LoginAccountId, EOE_EmployeeName)]
        [FdmCodeGen(Title = "登入者Email", IsRequired = false, IsUnique = true, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOLA_UserEmail_XX = "EOLA_UserEmail_XX";

        /// <summary>
        /// 失敗停權日期{FailureDate:D}：【2006/09/19 13:20:20】
        /// </summary>
        [FdmStyleType(DTN_DATETIME_19)]
        [FdmCodeGen(Title = "登入者Email", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOLA_FailureDate = "EOLA_FailureDate";

        /// <summary>
        /// 登入失敗次數{FailureCount:INT}：【3】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCodeGen(Title = "登入失敗次數", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOLA_FailureCount = "EOLA_FailureCount";

        /// <summary>
        /// 最後登入日期{LastLoginDate:D}：【2006/09/19 13:20:20】
        /// </summary>
        [FdmStyleType(DTN_DATETIME_19)]
        [FdmCodeGen(Title = "最後登入日期", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOLA_LastLoginDate = "EOLA_LastLoginDate";

        /// <summary>
        /// 帳號啟用{IsEnable:1,IsEnableName_XX}：○{T}啟用 ○{F}停用
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        [FdmCodeGen(Title = "帳號啟用", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOLA_IsEnable = "EOLA_IsEnable";

        /// <summary>
        /// 帳號啟用{IsEnable:1,IsEnableName_XX}：○{T}啟用 ○{F}停用
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmCodeName("CTN_APP_TF", EOLA_IsEnable)]
        [FdmCodeGen(Title = "帳號啟用", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOLA_IsEnableName_XX = "EOLA_IsEnableName_XX";

        #endregion

        #region [EO_Permission]
        /// <summary>
        /// 權限主檔
        /// </summary>
        [FdmTableDef("EOP_", EOP_PermissionId)]
        [FdmTableProvider("ftd.dataaccess.EoPermissionProvider, AppService")]
        [FdmCodeGen(Title = "權限主檔")]
        public const string EO_Permission = "EO_Permission";

        /// <summary>
        /// *權限ID{PK}：【key(EOP)】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "權限ID", IsRequired = true, IsUnique = true, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOP_PermissionId = "EOP_PermissionId";

        /// <summary>
        /// *權限CODE{PermissionCode:50}：【APN_KM_Admin】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        [FdmCodeGen(Title = "權限代號", IsRequired = true, IsUnique = true, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOP_PermissionCode = "EOP_PermissionCode";

        /// <summary>
        /// *權限名稱{PermissionName:50}：【系統\KM\系統管理員】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        [FdmCodeGen(Title = "權限名稱", IsRequired = true, IsUnique = false, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOP_PermissionName = "EOP_PermissionName";

        /// <summary>
        /// *權限說明{Description:100}：【最高權限】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR100)]
        [FdmCodeGen(Title = "權限說明", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOP_Description = "EOP_Description";

        /// <summary>
        /// *開放給每個人：A:是 B:否
        /// ※若為是，則不用設定表每個人皆可使用
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        [FdmCodeGen(Title = "開放給每個人", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOP_IsEveryOneAllow = "EOP_IsEveryOneAllow";

        /// <summary>
        /// #開放給每個人：A:是 B:否
        /// ※若為是，則不用設定表每個人皆可使用
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmCalculate]
        [FdmCodeGen(Title = "開放給每個人", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOP_IsEveryOneAllowName_XX = "EOP_IsEveryOneAllowName_XX";

        /// <summary>
        /// *需指定物件：A:是 B:否
        /// ※若為是，則該權限需另外指派物件.
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        public const string EOP_IsObjectNeed = "EOP_IsObjectNeed";

        /// <summary>
        /// #需指定物件：A:是 B:否
        /// ※若為是，則該權限需另外指派物件.
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmCalculate]
        public const string EOP_IsObjectNeedName_XX = "EOP_IsObjectNeedName_XX";
        #endregion

        #region [EO_PermissionSetting]
        /// <summary>
        /// &lt;EOPS>權限設定表{PermissonSetting}
        /// </summary>
        [FdmTableDef("EOPS_", EOPS_PermissionSettingId, IsSessionEnable = false)]
        [FdmTableProvider("ftd.dataaccess.EoPermissionSettingProvider, AppService")]
        [FdmCodeGen(Title = "權限設定")]
        public const string EO_PermissionSetting = "EO_PermissionSetting";

        /// <summary>
        /// *權限設定Id{PermissionSettingId}：【PK&lt;EOPS>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        public const string EOPS_PermissionSettingId = "EOPS_PermissionSettingId";

        /// <summary>
        /// *人員ID{PermissionUserId}：【KEY&lt;EOE>|KEY&lt;EOD>】
        /// </summary>
        [FdmStyleType(DTN_NID)]     
        public const string EOPS_PermissionUserId = "EOPS_PermissionUserId";

        /// <summary>
        /// #人員名稱{PermissionUserName_XX}：【資訊中心|市政府-林勝文 組長】
        /// </summary>        
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EOPS_PermissionUserId, EOD_DepartmentName)]
        [FdmLink(EOPS_PermissionUserId, EOE_EmployeeFullName_XX)]
        public const string EOPS_PermissionUserName_XX = "EOPS_PermissionUserName_XX";

        /// <summary>
        /// *權限ID{PermissionId}:【KEY&lt;EOP>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        public const string EOPS_PermissionId = "EOPS_PermissionId";

        /// <summary>
        /// #權限Code{PermissionCode_XX}:【APN_APP_SystemAdmin】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EOPS_PermissionId, EOP_PermissionCode)]
        public const string EOPS_PermissionCode_XX = "EOPS_PermissionCode_XX";

        /// <summary>
        /// #權限名稱{PermissionName_XX}:【系統\APP\系統管理者】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EOPS_PermissionId, EOP_PermissionName)]
        public const string EOPS_PermissionName_XX = "EOPS_PermissionName_XX";

        /// <summary>
        /// 權限物Id{ObjectId}：【&lt;KEY>】※若IsObjectNedd為是，則該需指派物件
        /// </summary>        
        [FdmStyleType(DTN_NID)]       
        public const string EOPS_ObjectId = "EOPS_ObjectId";

        /// <summary>
        /// #權限物名稱{ObjectName_XX}：【[部門]資訊中心】
        /// </summary>        
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmCalculate]        
        public const string EOPS_ObjectName_XX = "EOPS_ObjectName_XX";

        /// <summary>
        /// #權限需指定物件{IsObjectNeed_XX}：○{Name}YES ○{Name_U}NO
        /// </summary>        
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EOPS_PermissionId, EOP_IsObjectNeed)]
        public const string EOPS_IsObjectNeed_XX = "EOPS_IsObjectNeed_XX";

        /// <summary>
        /// #權限開放給每個人{IsEveryOneAllow_XX}：○{Name}YES ○{Name_U}NO
        /// </summary>        
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EOPS_PermissionId, EOP_IsEveryOneAllow)]
        public const string EOPS_IsEveryOneAllow_XX = "EOPS_IsEveryOneAllow_XX";
        #endregion

        #region [EO_Menu]
        /// <summary>
        /// &lt;EOM> 功能表定義{Menu}
        /// </summary>
        [FdmTableDef("EOM_", EOM_MenuId)]
        [FdmTableProvider("ftd.dataaccess.EoMenuProvider, AppService")]
        [FdmCodeGen(Title = "功能表")]
        public const string EO_Menu = "EO_Menu";

        /// <summary>
        /// *功能表ID{MenuId}：【PK&lt;EOM>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        public const string EOM_MenuId = "EOM_MenuId";

        /// <summary>
        /// *功能表名稱{MenuName:20}：【首頁功能表】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        public const string EOM_MenuName = "EOM_MenuName";

        /// <summary>
        /// XML檔案{FileName:50}：【~/data/AppMenu.xml】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        public const string EOM_FileName = "EOM_FileName";

        /// <summary>
        /// #XML檔案路徑{FileFullName_XX}：【C:\001\AppMenu.xml】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR100)]
        [FdmCalculate]
        public const string EOM_FileFullName_XX = "EOM_FileFullName_XX";

        /// <summary>
        /// *結構檔案{StructSource:1}：○{F}Xml檔案 ○{D}資料庫檔案
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        public const string EOM_StructSource = "EOM_StructSource";

        /// <summary>
        /// 資料庫檔案{StructId,StructName_XX}：【KEY&lt;EOMS>,首頁功能表】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        public const string EOM_StructId = "EOM_StructId";

        /// <summary>
        /// 資料庫檔案{StructId,StructName_XX}：【KEY&lt;EOMS>,首頁功能表】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR100)]
        [FdmLink(EOM_StructId, EOMS_Name)]
        public const string EOM_StructName_XX = "EOM_StructName_XX";

        #endregion

        #region [EO_MenuStruct]
        /// <summary>
        /// {T}&lt;EOMS>功能表/功能結構 {MenuStruct}
        /// </summary>
        [FdmTableDef("EOMS_", EOMS_NodeId, IsSessionEnable = false)]
        [FdmTableProvider("ftd.dataaccess.EoMenuStructProvider, AppService")]
        [FdmCodeGen(Title = "功能表")]
        public const string EO_MenuStruct = "EO_MenuStruct";

        /// <summary>
        ///  *功能ID{NodeId}：【PK】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "功能ID", IsRequired = true, IsSearch = false, IsUnique = true, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOMS_NodeId = "EOMS_NodeId";

        /// <summary>
        /// *父節點ID{ParentId}：【KEY&lt;EOMF>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "父節點ID", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOMS_ParentId = "EOMS_ParentId";

        /// <summary>
        /// *父節點代號{ParentCode_XX}：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmLink(EOMS_ParentId, EOMS_Code)]
        [FdmCodeGen(Title = "父節點代號", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOMS_ParentCode_XX = "EOMS_ParentCode_XX";

        /// <summary>
        /// *父節點名稱{ParentName_XX}：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        [FdmLink(EOMS_ParentId, EOMS_Name)]
        [FdmCodeGen(Title = "父節點名稱", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOMS_ParentName_XX = "EOMS_ParentName_XX";

        /// <summary>
        /// *節點類型{NodeType_XX}：○{A}功能表 ○{B}目錄 ○{C}功能
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmCalculate]
        [FdmCodeGen(Title = "節點類型", IsRequired = true, IsSearch = true, IsUnique = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOMS_NodeType_XX = "EOMS_NodeType_XX";

        /// <summary>
        /// 功能表名稱{Name:20}：【主檔維護】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        [FdmCodeGen(Title = "功能表名稱", IsRequired = true, IsSearch = true, IsUnique = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOMS_Name = "EOMS_Name";

        /// <summary>
        /// *備註{Note:100}：【HelloWorld】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR100)]
        [FdmCodeGen(Title = "備註", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOMS_Note = "EOMS_Note";

        /// <summary>
        /// 功能表代碼{Code:20}：【AB0001】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmCodeGen(Title = "功能表代碼", IsRequired = true, IsSearch = true, IsUnique = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOMS_Code = "EOMS_Code";

        /// <summary>
        /// 網址{Url:100}：【http://www.google.com.tw】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR100)]
        [FdmCodeGen(Title = "網址", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOMS_Url = "EOMS_Url";

        /// <summary>
        /// 網址Tareget{UrlTarget:20}：【_blank】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmCodeGen(Title = "網址Tareget", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOMS_UrlTarget = "EOMS_UrlTarget";

        /// <summary>
        /// 視窗{WinClass:50}：【EoMenuListWindow】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        [FdmCodeGen(Title = "視窗", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOMS_WinClass = "EOMS_WinClass";

        /// <summary>
        /// 視窗參數{WinParam:100}：【Name=123&amp;Name_U&#61;456】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR100)]
        [FdmCodeGen(Title = "視窗參數", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOMS_WinParam = "EOMS_WinParam";

        /// <summary>
        /// 自訂參數1 (Action){CustAttr1:20}：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmCodeGen(Title = "自訂參數1", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOMS_CustAttr1 = "EOMS_CustAttr1";

        /// <summary>
        /// 自訂參數2 (Controller){CustAttr2:20}：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmCodeGen(Title = "自訂參數2", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOMS_CustAttr2 = "EOMS_CustAttr2";

        /// <summary>
        /// 自訂參數3 (Area){CustAttr3:20}：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmCodeGen(Title = "自訂參數3", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOMS_CustAttr3 = "EOMS_CustAttr3";

        /// <summary>
        ///排序順序{SortNo:INT}：【1】※Brother之間的排序順位，由1起始編號。
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCodeGen(Title = "排序順序", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOMS_SortNo = "EOMS_SortNo";

        /// <summary>
        ///點選模式{ClickMode}：○{U}網址 ○{A}視窗代碼 {X}○其他
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        [FdmDefaultValue("A")]
        [FdmCodeGen(Title = "點選模式", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOMS_ClickMode = "EOMS_ClickMode";

        /// <summary>
        ///點選模式{ClickMode}：○{U}網址 ○{A}視窗代碼 {X}○其他
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        [FdmCodeName("CTN_EOMS_ClickMode", EOMS_ClickMode)]
        [FdmCodeGen(Title = "點選模式", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOMS_ClickModeName_XX = "EOMS_ClickModeName_XX";

        /// <summary>
        /// #節點歸屬的根結點Id{RootId_XX}：【KEY&lt;EOMS>】※節點歸屬的根結點
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCalculate]
        [FdmCodeGen(Title = "節點歸屬的根結點ID", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOMS_RootId_XX = "EOMS_RootId_XX";

        /// <summary>
        /// #子結點數量{ChildCount_XX:INT}：【1】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCalculate]
        [FdmCodeGen(Title = "子結點數量", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOMS_ChildCount_XX = "EOMS_ChildCount_XX";

        /// <summary>
        /// #兄弟節點數量{BrotherCount_XX:N}：【5】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCalculate]
        [FdmCodeGen(Title = "兄弟節點數量", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOMS_BrotherCount_XX = "EOMS_BrotherCount_XX";

        /// <summary>
        /// #階層號碼{LevelNo_XX:INT}：【10】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCalculate]
        [FdmCodeGen(Title = "階層號碼", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOMS_LevelNo_XX = "EOMS_LevelNo_XX";

        /// <summary>
        ///#樹系號碼-左{TreeLeftNo_XX:INT}：【10】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCalculate]
        [FdmCodeGen(Title = "樹系號碼-左", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOMS_TreeLeftNo_XX = "EOMS_TreeLeftNo_XX";

        /// <summary>
        /// #樹系號碼-右{TreeRightNo_XX:INT}：【10】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCalculate]
        [FdmCodeGen(Title = "樹系號碼-右", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOMS_TreeRightNo_XX = "EOMS_TreeRightNo_XX";

        /// <summary>
        /// #單一站台{MatchSiteId_XX}：【KEY&lt;EOSS>】ex.若有多個符合只列出第一個
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCalculate]
        [FdmCodeGen(Title = "單一站台", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOMS_MatchSiteId_XX = "EOMS_MatchSiteId_XX";

        /// <summary>
        /// 顯示於功能表{Viewable}：○{Y}是 ○{N}否
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        [FdmDefaultValue("Y")]
        [FdmCodeGen(Title = "顯示於功能表", IsRequired = true, IsSearch = true, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOMS_Viewable = "EOMS_Viewable";

        #endregion

        #region[EO_MenuPerm]

        /// <summary>
        /// {T}&lt;EOMP>功能表/授權對象{MenuPerm}
        /// </summary>
        [FdmTableDef("EOMP_", EOMP_MenuPermId, IsSessionEnable = false)]
        [FdmTableProvider("ftd.dataaccess.EoMenuPermProvider, AppService")]
        [FdmCodeGen(Title = "授權對象")]
        public const string EO_MenuPerm = "EO_MenuPerm";

        /// <summary>
        /// *授權對象ID{MenuPermId}：【PK&lt;EOMP>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        public const string EOMP_MenuPermId = "EOMP_MenuPermId";

        /// <summary>
        /// *功能表ID{MenuId}：【FK&lt;EOM>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        public const string EOMP_MenuId = "EOMP_MenuId";

        /// <summary>
        /// *授權類型{TargetKind,TargetKindName_XX}：A：員工 / B：群組 / C：職稱 / D：權限 / E：機關
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        public const string EOMP_TargetKind = "EOMP_TargetKind";

        /// <summary>
        /// *授權類型{TargetKind,TargetKindName_XX}：A：員工 / B：群組 / C：職稱 / D：權限 / E：機關
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCalculate]
        public const string EOMP_TargetKindName_XX = "EOMP_TargetKindName_XX";

        /// <summary>
        /// *授權對象{TargetId,TargetName_XX}：【FK&lt;EOM|EOD|EOET>，(部門)主計處】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        public const string EOMP_TargetId = "EOMP_TargetId";

        /// <summary>
        /// *授權對象代號{TargetId,TargetCode_XX}：【FK&lt;EOM|EOD|EOET>，(部門)主計處】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR100)]
        [FdmCalculate]
        public const string EOMP_TargetCode_XX = "EOMP_TargetCode_XX";

        /// <summary>
        /// *授權對象名稱{TargetId,TargetName_XX}：【FK&lt;EOM|EOD|EOET>，(部門)主計處】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR100)]
        [FdmCalculate]
        public const string EOMP_TargetName_XX = "EOMP_TargetName_XX";

        /// <summary>
        /// *檢視權限{ViewKind,ViewKindName_XX}○{Name}可檢視 ○{Name_U}不可檢視 
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        public const string EOMP_ViewKind = "EOMP_ViewKind";

        /// <summary>
        ///*檢視權限{ViewKind,ViewKindName_XX}○{Name}可檢視 ○{Name_U}不可檢視 
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR100)]
        [FdmCalculate]
        public const string EOMP_ViewKindName_XX = "EOMP_ViewKindName_XX";

        #endregion

        #region [EO_MenuPermSet]
        /// <summary>
        /// {T}&lt;EOMPS>功能表/授權功能{MenuPermSet}
        /// </summary>
        [FdmTableDef("EOMPS_", EOMPS_MenuPermSetId, IsSessionEnable = false)]
        [FdmTableProvider("ftd.dataaccess.EoMenuPermSetProvider, AppService")]
        [FdmCodeGen(Title = "授權功能")]
        public const string EO_MenuPermSet = "EO_MenuPermSet";

        /// <summary>
        /// *授權功能ID{ MenuPermSetId}：【PK&lt;EOMPS>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        public const string EOMPS_MenuPermSetId = "EOMPS_MenuPermSetId";

        /// <summary>
        /// *授權對象ID{MenuPermId}：【FK&lt;EOMP>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        public const string EOMPS_MenuPermId = "EOMPS_MenuPermId";

        /// <summary>
        /// #功能表ID{MenuId_XX}：【KEY&lt;EOM>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmLink(EOMPS_MenuPermId, EOMP_MenuId)]
        public const string EOMPS_MenuId_XX = "EOMPS_MenuId_XX";

        /// <summary>
        /// *功能項目No{MenuItemNo:50}：【Report.1】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        public const string EOMPS_MenuItemNo = "EOMPS_MenuItemNo";

        /// <summary>
        /// #功能項目No{MenuItemNoName_XX}：【個人紀錄報表】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCalculate]        
        public const string EOMPS_MenuItemNoName_XX = "EOMPS_MenuItemNoName_XX";

        #endregion

        #region [EO_UserEvent]
        /// <summary>
        /// &lt;EOUE>網站使用者事件主檔{UserEvent}
        /// </summary>
        [FdmTableDef("EOUE_", EOUE_UserEventId)]
        [FdmTableProvider("ftd.dataaccess.EoUserEventProvider, AppService")]
        [FdmCodeGen(Title = "網站事件主檔")]
        public const string EO_UserEvent = "EO_UserEvent";

        /// <summary>
        ///  *事件ID{UserEventLogId}：【PK&lt;EPUE>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "事件ID", IsRequired = true, IsUnique = true, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOUE_UserEventId = "EOUE_UserEventId";

        /// <summary>
        /// *事件代碼{EventCode:50}：【KM_LOGIN】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        [FdmCodeGen(Title = "事件代號", IsRequired = true, IsUnique = true, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOUE_EventCode = "EOUE_EventCode";

        /// <summary>
        /// *事件類型{KindName:50}：【登入系統】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        [FdmCodeGen(Title = "事件類型", IsRequired = true, IsUnique = false, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOUE_KindName = "EOUE_KindName";

        /// <summary>
        /// *事件描述{Description:100}：【使用者登入系統】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR100)]
        [FdmCodeGen(Title = "事件描述", IsRequired = true, IsUnique = false, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOUE_Description = "EOUE_Description";

        /// <summary>
        /// *列表順序 {ListOrder:INT}：【1】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        public const string EOUE_ListOrder = "EOUE_ListOrder";
        [FdmCodeGen(Title = "列表順序", IsRequired = true, IsUnique = false, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        #endregion

        #region [EO_UserEventLog]
        [FdmTableDef("EOUEL_", EOUEL_UserEventLogId)]
        [FdmTableProvider("ftd.dataaccess.EoUserEventLogProvider, AppService")]
        [FdmCodeGen(Title = "網站事件紀錄")]
        public const string EO_UserEventLog = "EO_UserEventLog";

        /// <summary>
        /// *事件檔紀錄ID{UserEventLogId}：【PK&lt;EPUEL>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "事件檔紀錄ID", IsRequired = true, IsUnique = true, IsSearch = true, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOUEL_UserEventLogId = "EOUEL_UserEventLogId";

        /// <summary>
        /// *事件Id{UserEventId}：【KEY&lt;EPUE>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "事件Id", IsRequired = true, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOUEL_UserEventId = "EOUEL_UserEventId";

        /// <summary>
        /// #事件代號Code{UserEventCode_XX}：【KM_LOGIN】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR100)]
        [FdmLink(EOUEL_UserEventId, EOUE_EventCode)]
        [FdmCodeGen(Title = "事件代號", IsRequired = true, IsUnique = false, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOUEL_UserEventCode_XX = "EOUEL_UserEventCode_XX";

        /// <summary>
        /// #事件類型{UserEventName_XX}：【登入系統】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR100)]
        [FdmLink(EOUEL_UserEventId, EOUE_KindName)]
        [FdmCodeGen(Title = "事件類型", IsRequired = true, IsUnique = false, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOUEL_UserEventName_XX = "EOUEL_UserEventName_XX";

        /// <summary>
        /// *事件日期{EventDate:D}：【2007/11/12 13:14】
        /// </summary>
        [FdmStyleType(DTN_DATETIME_16)]
        [FdmCodeGen(Title = "事件日期", IsRequired = true, IsUnique = false, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOUEL_EventDate = "EOUEL_EventDate";

        /// <summary>
        /// *人員{UserId}：【KEY&lt;EOE,ENM,KCG>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "人員Id", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOUEL_UserId = "EOUEL_UserId";

        /// <summary>
        /// #人員名稱{UserName_XX}：【市政府 王小明 組長】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EOUEL_UserId, EOE_EmployeeFullName_XX)]
        [FdmCodeGen(Title = "人員名稱", IsRequired = false, IsUnique = false, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOUEL_UserName_XX = "EOUEL_UserName_XX";

        /// <summary>
        /// 查看的物件Id{ObjectId }：【KEY】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "物件Id", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOUEL_ObjectId = "EOUEL_ObjectId";

        /// <summary>
        /// #查看的物件名稱：{ObjectName_XX}：【 [目錄]天下雜誌目錄|[KIOSK]漢神\1F】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmLink(EOUEL_ObjectId, EOE_EmployeeName, KeyAsValueWhenLinkless = true)]         //人員
        [FdmLink(EOUEL_ObjectId, WTST_TaskName, KeyAsValueWhenLinkless = true)]            //工作排程
        [FdmCodeGen(Title = "物件名稱", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOUEL_ObjectName_XX = "EOUEL_ObjectName_XX";

        /// <summary>
        /// 來源IP{SourceId }：【168.95.1.1】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        [FdmCodeGen(Title = "來源IP", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOUEL_SourceIP = "EOUEL_SourceIP";
        #endregion

        #region [EO_SignSite]
        ///// <summary>
        ///// &lt;EOSS>單一簽入站台{SignSite}
        ///// </summary>
        //[FdmTableDef("EOSS_", EOSS_SiteId)]
        //[FdmTableProvider("ftd.dataaccess.EoSignSiteProvider, AppService")]
        //[FdmCodeGen(Title = "單一簽入站台")]
        //public const string EO_SignSite = "EO_SignSite";

        ///// <summary>
        ///// *站台ID{SiteId}：【PK&lt;EOSS>】
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //public const string EOSS_SiteId = "EOSS_SiteId";

        ///// <summary>
        ///// *站台名稱{SiteName:20}：【船舶動態系統】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //public const string EOSS_SiteName = "EOSS_SiteName";

        ///// <summary>
        ///// *API網址{ApiUrl:100}：【http://10.10.111.227/sdci/SS_Navigate.asp】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR100)]
        //public const string EOSS_ApiUrl = "EOSS_ApiUrl";

        ///// <summary>
        /////*Web首頁{WebUrl:100}：【http://10.10.111.227/sdci/default.asp】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR100)]
        //public const string EOSS_WebUrl = "EOSS_WebUrl";

        ///// <summary>
        ///// *篩選網址1{FilterUrl1:50}：【http://10.10.111.227/sdci】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR50)]
        //public const string EOSS_FilterUrl1 = "EOSS_FilterUrl1";

        ///// <summary>
        ///// 篩選網址2{FilterUrl2:50}：【https://10.10.111.227/sdci】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR50)]
        //public const string EOSS_FilterUrl2 = "EOSS_FilterUrl2";

        ///// <summary>
        ///// 備註{Note:100}：【最高權限】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR100)]
        //public const string EOSS_Note = "EOSS_Note";

        #endregion

        #region [EO_MenuFun]
        /// <summary>
        /// {T}程式功能清單{EO_MenuFun}
        /// </summary>
        [FdmTableDef("EOMF_", AppDataName.EOMF_MenuFunId,
              //RowInsertUserName = AppDataName.EOMF_CreatorId,
              //RowInsertDateName = AppDataName.EOMF_CreateDate,
              //RowModifyUserName = AppDataName.EOMF_UpdaterId,
              //RowModifyDateName = AppDataName.EOMF_UpdateDate,
              IsSessionEnable = false)]
        [FdmTableProvider("ftd.dataaccess.EoMenuFunProvider, AppService")]
        [FdmCodeGen(Title = "程式功能清單")]
        public const string EO_MenuFun = "EO_MenuFun";

        /// <summary>
        /// *EOMF_MenupermfunId{Id}：【PK】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "程式功能清單ID", IsRequired = true, IsSearch = false, IsUnique = true, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOMF_MenuFunId = "EOMF_MenuFunId";

        /// <summary>
        /// 程式代號{20}
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmCodeGen(Title = "程式代號", IsRequired = true, IsSearch = true, IsUnique = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOMF_ItemNo = "EOMF_ItemNo";

        /// <summary>
        /// *功能代號{20}
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmCodeGen(Title = "功能代號", IsRequired = true, IsSearch = true, IsUnique = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOMF_FunctionCode = "EOMF_FunctionCode";

        /// <summary>
        /// 功能名稱{50}
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        [FdmCodeGen(Title = "功能名稱", IsRequired = true, IsSearch = true, IsUnique = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOMF_FunctionName = "EOMF_FunctionName";

        /// <summary>
        /// 功能說明{50}
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        [FdmCodeGen(Title = "功能說明", IsRequired = true, IsSearch = true, IsUnique = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOMF_FunctionDesc = "EOMF_FunctionDesc";

        /// <summary>
        /// 排序{INT}
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCodeGen(Title = "排序", IsRequired = true, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOMF_SeqNo = "EOMF_SeqNo";

        /// <summary>
        /// 工具列層級{1}【F：表單 / T：資料表 / R：資料列】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        [FdmDefaultValue("F")]
        [FdmCodeGen(Title = "工具列層級", IsRequired = true, IsSearch = true, IsUnique = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOMF_ToolbarLevel = "EOMF_ToolbarLevel";

        /// <summary>
        /// 工具列層級說明{1}【F：表單 / T：資料表 / R：資料列】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        [FdmCodeName("CTN_ToolbarLevel", AppDataName.EOMF_ToolbarLevel)]
        [FdmDefaultValue("F")]
        [FdmCodeGen(Title = "工具列層級", IsRequired = true, IsSearch = true, IsUnique = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOMF_ToolbarLevelName_XX = "EOMF_ToolbarLevelName_XX";

        ///// <summary>
        ///// *建立者id{NID}：
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //[FdmCodeGen(Title = "建立者id", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        //public const string EOMF_CreatorId = "EOMF_CreatorId";

        ///// <summary>
        ///// *建立者姓名{20}：
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //[FdmLink(AppDataName.EOMF_CreatorId, AppDataName.EOE_EmployeeName)]
        //[FdmCodeGen(Title = "建立者姓名", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        //public const string EOMF_CreatorName_XX = "EOMF_CreatorName_XX";

        ///// <summary>
        ///// *建立日期{DTN_DATETIME_19}：
        ///// </summary>
        //[FdmStyleType(DTN_DATETIME_19)]
        //[FdmCodeGen(Title = "建立日期", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        //public const string EOMF_CreateDate = "EOMF_CreateDate";

        ///// <summary>
        ///// *異動者id{NID}：
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //[FdmCodeGen(Title = "異動者id", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        //public const string EOMF_UpdaterId = "EOMF_UpdaterId";

        ///// <summary>
        ///// *異動者姓名{20}：
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //[FdmLink(AppDataName.EOMF_UpdaterId, AppDataName.EOE_EmployeeName)]
        //[FdmCodeGen(Title = "異動者姓名", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        //public const string EOMF_UpdaterName_XX = "EOMF_UpdaterName_XX";

        ///// <summary>
        ///// *異動日期{DTN_DATETIME_19}：
        ///// </summary>
        //[FdmStyleType(DTN_DATETIME_19)]
        //[FdmCodeGen(Title = "異動日期", IsRequired = false, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        //public const string EOMF_UpdateDate = "EOMF_UpdateDate";

        #endregion

        #region [EO_FunPermSet]
        /// <summary>
        /// {T}&lt;EOFPS>程式功能授權{FunPermSet}
        /// </summary>
        [FdmTableDef("EOFPS_", EOFPS_FunPermSetId,
              //RowInsertUserName = AppDataName.EOFPS_CreatorId,
              //RowInsertDateName = AppDataName.EOFPS_CreateDate,
              //RowModifyUserName = AppDataName.EOFPS_UpdaterId,
              //RowModifyDateName = AppDataName.EOFPS_UpdateDate, 
              IsSessionEnable = false)]
        [FdmTableProvider("ftd.dataaccess.EoFunPermSetProvider, AppService")]
        [FdmCodeGen(Title = "程式功能授權")]
        public const string EO_FunPermSet = "EO_FunPermSet";

        /// <summary>
        /// *授權功能ID{FunPermSetId}：【PK&lt;EOFPS>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "程式功能授權ID", IsRequired = true, IsSearch = false, IsUnique = true, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string EOFPS_FunPermSetId = "EOFPS_FunPermSetId";

        /// <summary>
        /// *授權程式ID{MenuPermSetId}：【FK&lt;EOMPS>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "授權程式ID", IsRequired = true, IsSearch = false, IsUnique = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOFPS_MenuPermSetId = "EOFPS_MenuPermSetId";

        /// <summary>
        /// #功能表ID{MenuId_XX}：【KEY&lt;EOM>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmLink(EOFPS_MenuPermSetId, EOMPS_MenuId_XX)]
        [FdmCodeGen(Title = "功能表ID", IsRequired = true, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOFPS_MenuId_XX = "EOFPS_MenuId_XX";

        /// <summary>
        /// *程式代號{MenuItemNo:50}：【Report.1】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        [FdmLink(EOFPS_MenuPermSetId, EOMPS_MenuItemNo)]
        [FdmCodeGen(Title = "程式代號", IsRequired = true, IsSearch = true, IsUnique = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOFPS_MenuItemNo_XX = "EOFPS_MenuItemNo_XX";

        /// <summary>
        /// #程式名稱{MenuItemNoName_XX}：【個人紀錄報表】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        //[FdmCalculate]
        [FdmLink(EOFPS_MenuPermSetId, EOMPS_MenuItemNoName_XX)]
        [FdmCodeGen(Title = "程式名稱", IsRequired = true, IsSearch = true, IsUnique = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOFPS_MenuItemNoName_XX = "EOFPS_MenuItemNoName_XX";

        /// <summary>
        /// *授權功能ID{MenuFunId}：【FK&lt;EOMF>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "授權程式ID", IsRequired = true, IsSearch = false, IsUnique = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOFPS_MenuFunId = "EOFPS_MenuFunId";

        /// <summary>
        /// *功能代號{FunctionCode_XX:50}：【Create】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        [FdmLink(EOFPS_MenuFunId, EOMF_FunctionCode)]
        [FdmCodeGen(Title = "功能代號", IsRequired = true, IsSearch = true, IsUnique = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOFPS_FunctionCode_XX = "EOFPS_FunctionCode_XX";

        /// <summary>
        /// *功能名稱{FunctionName_XX:50}：【新增】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        [FdmLink(EOFPS_MenuFunId, EOMF_FunctionName)]
        [FdmCodeGen(Title = "功能名稱", IsRequired = true, IsSearch = true, IsUnique = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOFPS_FunctionName_XX = "EOFPS_FunctionName_XX";

        /// <summary>
        /// *功能排序{FunctionSeqNo_XX:50}：【Report.1】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        [FdmLink(EOFPS_MenuFunId, EOMF_SeqNo)]
        [FdmCodeGen(Title = "功能排序", IsRequired = true, IsSearch = false, IsUnique = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string EOFPS_FunctionSeqNo_XX = "EOFPS_FunctionSeqNo_XX";

        ///// <summary>
        ///// *建立者id{NID}：
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //public const string EOFPS_CreatorId = "EOFPS_CreatorId";

        ///// <summary>
        ///// *建立者姓名{20}：
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //[FdmLink(AppDataName.EOFPS_CreatorId, AppDataName.EOE_EmployeeName)]
        //public const string EOFPS_CreatorName_XX = "EOFPS_CreatorName_XX";

        ///// <summary>
        ///// *建立日期{DTN_DATETIME_19}：
        ///// </summary>
        //[FdmStyleType(DTN_DATETIME_19)]
        //public const string EOFPS_CreateDate = "EOFPS_CreateDate";

        ///// <summary>
        ///// *異動者id{NID}：
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //public const string EOFPS_UpdaterId = "EOFPS_UpdaterId";

        ///// <summary>
        ///// *異動者姓名{20}：
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //[FdmLink(AppDataName.EOFPS_UpdaterId, AppDataName.EOE_EmployeeName)]
        //public const string EOFPS_UpdaterName_XX = "EOFPS_UpdaterName_XX";

        ///// <summary>
        ///// *異動日期{DTN_DATETIME_19}：
        ///// </summary>
        //[FdmStyleType(DTN_DATETIME_19)]
        //public const string EOFPS_UpdateDate = "EOFPS_UpdateDate";

        #endregion

    }
}
