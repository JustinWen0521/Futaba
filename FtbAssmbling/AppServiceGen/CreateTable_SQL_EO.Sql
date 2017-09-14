create table EO_Department
(
 EOD_DepartmentId nvarchar(15)
, EOD_DepartmentCode nvarchar(50)
, EOD_DepartmentName nvarchar(50)
, EOD_DepartmentType nvarchar(1)
, EOD_Note nvarchar(100)
, EOD_ParentId nvarchar(15)
, EOD_SortNo int
, EOD_VirtualType nvarchar(1)
, primary key (EOD_DepartmentId)
)
GO
create table EO_DeptMember
(
 EODM_DeptMemberId nvarchar(15)
, EODM_DeptId nvarchar(15)
, EODM_MemberId nvarchar(15)
, primary key (EODM_DeptMemberId)
)
GO
create table EO_Employee
(
 EOE_EmployeeId nvarchar(15)
, EOE_CAddress nvarchar(50)
, EOE_CZip nvarchar(10)
, EOE_DepartmentId nvarchar(15)
, EOE_EmployeeCode nvarchar(20)
, EOE_EmployeeEmail nvarchar(50)
, EOE_EmployeeName nvarchar(20)
, EOE_EmployeeSid nvarchar(20)
, EOE_EmployeeTitleId nvarchar(15)
, EOE_EntryDate datetime
, EOE_LeaveDate datetime
, EOE_PersonalImage nvarchar(50)
, EOE_Phone1 nvarchar(20)
, EOE_Phone2 nvarchar(20)
, EOE_Remark nvarchar(100)
, EOE_Sex nvarchar(1)
, EOE_Signature nvarchar(100)
, EOE_SmsNumber nvarchar(20)
, primary key (EOE_EmployeeId)
)
GO
create table EO_EmployeeTitle
(
 EOET_EmployeeTitleId nvarchar(15)
, EOET_ListOrder int
, EOET_TitleCode nvarchar(20)
, EOET_TitleName nvarchar(20)
, primary key (EOET_EmployeeTitleId)
)
GO
create table EO_LoginAccount
(
 EOLA_LoginAccountId nvarchar(15)
, EOLA_FailureCount int
, EOLA_FailureDate datetime
, EOLA_IsEnable nvarchar(1)
, EOLA_LastLoginDate datetime
, EOLA_LoginAccount nvarchar(50)
, EOLA_LoginPassword nvarchar(20)
, primary key (EOLA_LoginAccountId)
)
GO
create table EO_Menu
(
 EOM_MenuId nvarchar(15)
, EOM_FileName nvarchar(50)
, EOM_MenuName nvarchar(20)
, EOM_StructId nvarchar(15)
, EOM_StructSource nvarchar(1)
, primary key (EOM_MenuId)
)
GO
create table EO_MenuPerm
(
 EOMP_MenuPermId nvarchar(15)
, EOMP_MenuId nvarchar(15)
, EOMP_TargetId nvarchar(15)
, EOMP_TargetKind nvarchar(1)
, EOMP_ViewKind nvarchar(1)
, primary key (EOMP_MenuPermId)
)
GO
create table EO_MenuPermSet
(
 EOMPS_MenuPermSetId nvarchar(15)
, EOMPS_MenuItemNo nvarchar(50)
, EOMPS_MenuPermId nvarchar(15)
, primary key (EOMPS_MenuPermSetId)
)
GO
create table EO_MenuStruct
(
 EOMS_NodeId nvarchar(15)
, EOMS_ClickMode nvarchar(1)
, EOMS_Code nvarchar(20)
, EOMS_CustAttr1 nvarchar(20)
, EOMS_CustAttr2 nvarchar(20)
, EOMS_Name nvarchar(20)
, EOMS_Note nvarchar(100)
, EOMS_ParentId nvarchar(15)
, EOMS_SortNo int
, EOMS_Url nvarchar(100)
, EOMS_UrlTarget nvarchar(20)
, EOMS_WinClass nvarchar(50)
, EOMS_WinParam nvarchar(100)
, primary key (EOMS_NodeId)
)
GO
create table EO_Permission
(
 EOP_PermissionId nvarchar(15)
, EOP_Description nvarchar(100)
, EOP_IsEveryOneAllow nvarchar(1)
, EOP_IsObjectNeed nvarchar(1)
, EOP_PermissionCode nvarchar(50)
, EOP_PermissionName nvarchar(50)
, primary key (EOP_PermissionId)
)
GO
create table EO_PermissionSetting
(
 EOPS_PermissionSettingId nvarchar(15)
, EOPS_ObjectId nvarchar(15)
, EOPS_PermissionId nvarchar(15)
, EOPS_PermissionUserId nvarchar(15)
, primary key (EOPS_PermissionSettingId)
)
GO
create table EO_SignSite
(
 EOSS_SiteId nvarchar(15)
, EOSS_ApiUrl nvarchar(100)
, EOSS_FilterUrl1 nvarchar(50)
, EOSS_FilterUrl2 nvarchar(50)
, EOSS_Note nvarchar(100)
, EOSS_SiteName nvarchar(20)
, EOSS_WebUrl nvarchar(100)
, primary key (EOSS_SiteId)
)
GO
create table EO_UserEvent
(
 EOUE_UserEventId nvarchar(15)
, EOUE_Description nvarchar(100)
, EOUE_EventCode nvarchar(50)
, EOUE_KindName nvarchar(50)
, EOUE_ListOrder int
, primary key (EOUE_UserEventId)
)
GO
create table EO_UserEventLog
(
 EOUEL_UserEventLogId nvarchar(15)
, EOUEL_EventDate datetime
, EOUEL_ObjectId nvarchar(15)
, EOUEL_UserEventId nvarchar(15)
, EOUEL_UserId nvarchar(15)
, primary key (EOUEL_UserEventLogId)
)
GO
create table S_EO_Department
(
 S_EOD_DepartmentId nvarchar(15)
, S_EOD_NsSessionId nvarchar(20)
, S_EOD_DepartmentCode nvarchar(50)
, S_EOD_DepartmentName nvarchar(50)
, S_EOD_DepartmentType nvarchar(1)
, S_EOD_Note nvarchar(100)
, S_EOD_NsRowState nvarchar(10)
, S_EOD_ParentId nvarchar(15)
, S_EOD_SortNo int
, S_EOD_VirtualType nvarchar(1)
, primary key (S_EOD_DepartmentId,S_EOD_NsSessionId)
)
GO
create table S_EO_DeptMember
(
 S_EODM_DeptMemberId nvarchar(15)
, S_EODM_NsSessionId nvarchar(20)
, S_EODM_DeptId nvarchar(15)
, S_EODM_MemberId nvarchar(15)
, S_EODM_NsRowState nvarchar(10)
, primary key (S_EODM_DeptMemberId,S_EODM_NsSessionId)
)
GO
create table S_EO_Employee
(
 S_EOE_EmployeeId nvarchar(15)
, S_EOE_NsSessionId nvarchar(20)
, S_EOE_CAddress nvarchar(50)
, S_EOE_CZip nvarchar(10)
, S_EOE_DepartmentId nvarchar(15)
, S_EOE_EmployeeCode nvarchar(20)
, S_EOE_EmployeeEmail nvarchar(50)
, S_EOE_EmployeeName nvarchar(20)
, S_EOE_EmployeeSid nvarchar(20)
, S_EOE_EmployeeTitleId nvarchar(15)
, S_EOE_EntryDate datetime
, S_EOE_LeaveDate datetime
, S_EOE_NsRowState nvarchar(10)
, S_EOE_PersonalImage nvarchar(50)
, S_EOE_Phone1 nvarchar(20)
, S_EOE_Phone2 nvarchar(20)
, S_EOE_Remark nvarchar(100)
, S_EOE_Sex nvarchar(1)
, S_EOE_Signature nvarchar(100)
, S_EOE_SmsNumber nvarchar(20)
, primary key (S_EOE_EmployeeId,S_EOE_NsSessionId)
)
GO
create table S_EO_MenuPerm
(
 S_EOMP_MenuPermId nvarchar(15)
, S_EOMP_NsSessionId nvarchar(20)
, S_EOMP_MenuId nvarchar(15)
, S_EOMP_NsRowState nvarchar(10)
, S_EOMP_TargetId nvarchar(15)
, S_EOMP_TargetKind nvarchar(1)
, S_EOMP_ViewKind nvarchar(1)
, primary key (S_EOMP_MenuPermId,S_EOMP_NsSessionId)
)
GO
create table S_EO_MenuPermSet
(
 S_EOMPS_MenuPermSetId nvarchar(15)
, S_EOMPS_NsSessionId nvarchar(20)
, S_EOMPS_MenuItemNo nvarchar(50)
, S_EOMPS_MenuPermId nvarchar(15)
, S_EOMPS_NsRowState nvarchar(10)
, primary key (S_EOMPS_MenuPermSetId,S_EOMPS_NsSessionId)
)
GO
create table S_EO_MenuStruct
(
 S_EOMS_NodeId nvarchar(15)
, S_EOMS_NsSessionId nvarchar(20)
, S_EOMS_ClickMode nvarchar(1)
, S_EOMS_Code nvarchar(20)
, S_EOMS_CustAttr1 nvarchar(20)
, S_EOMS_CustAttr2 nvarchar(20)
, S_EOMS_Name nvarchar(20)
, S_EOMS_Note nvarchar(100)
, S_EOMS_NsRowState nvarchar(10)
, S_EOMS_ParentId nvarchar(15)
, S_EOMS_SortNo int
, S_EOMS_Url nvarchar(100)
, S_EOMS_UrlTarget nvarchar(20)
, S_EOMS_WinClass nvarchar(50)
, S_EOMS_WinParam nvarchar(100)
, primary key (S_EOMS_NodeId,S_EOMS_NsSessionId)
)
GO
create table S_EO_PermissionSetting
(
 S_EOPS_NsSessionId nvarchar(20)
, S_EOPS_PermissionSettingId nvarchar(15)
, S_EOPS_NsRowState nvarchar(10)
, S_EOPS_ObjectId nvarchar(15)
, S_EOPS_PermissionId nvarchar(15)
, S_EOPS_PermissionUserId nvarchar(15)
, primary key (S_EOPS_NsSessionId,S_EOPS_PermissionSettingId)
)
GO
