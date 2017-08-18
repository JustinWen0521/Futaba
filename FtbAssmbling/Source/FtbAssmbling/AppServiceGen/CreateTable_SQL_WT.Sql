create table S_WT_ScheduleDate
(
 S_WTSD_NsSessionId nvarchar(20)
, S_WTSD_ScheduleDateId nvarchar(15)
, S_WTSD_Description nvarchar(50)
, S_WTSD_IsEnable nvarchar(1)
, S_WTSD_NsRowState nvarchar(10)
, S_WTSD_Parameters nvarchar(4000)
, S_WTSD_ScheduleTaskId nvarchar(15)
, primary key (S_WTSD_NsSessionId,S_WTSD_ScheduleDateId)
)
GO
create table S_WT_ScheduleNotify
(
 S_WTSN_NsSessionId nvarchar(20)
, S_WTSN_ScheduleNotifyId nvarchar(15)
, S_WTSN_EmployeeId nvarchar(15)
, S_WTSN_NsRowState nvarchar(10)
, S_WTSN_ScheduleTaskId nvarchar(15)
, primary key (S_WTSN_NsSessionId,S_WTSN_ScheduleNotifyId)
)
GO
create table S_WT_ScheduleTask
(
 S_WTST_NsSessionId nvarchar(20)
, S_WTST_ScheduleTaskId nvarchar(15)
, S_WTST_Description nvarchar(200)
, S_WTST_ExecuteBeginDate datetime
, S_WTST_ExecuteEndDate datetime
, S_WTST_ExecuteException nvarchar(1000)
, S_WTST_ExecuteState nvarchar(1)
, S_WTST_IsEnable nvarchar(1)
, S_WTST_NsRowState nvarchar(10)
, S_WTST_ObjectTypeName nvarchar(100)
, S_WTST_Parameters nvarchar(100)
, S_WTST_TaskName nvarchar(50)
, primary key (S_WTST_NsSessionId,S_WTST_ScheduleTaskId)
)
GO
create table WT_ContentType
(
 WTCT_ExtName nvarchar(10)
, WTCT_ContentType nvarchar(50)
, primary key (WTCT_ExtName)
)
GO
create table WT_MailQueue
(
 WTMQ_MailQueueId nvarchar(15)
, WTMQ_Content text
, WTMQ_RowInsertDate datetime
, primary key (WTMQ_MailQueueId)
)
GO
create table WT_ScheduleDate
(
 WTSD_ScheduleDateId nvarchar(15)
, WTSD_Description nvarchar(50)
, WTSD_IsEnable nvarchar(1)
, WTSD_Parameters nvarchar(4000)
, WTSD_ScheduleTaskId nvarchar(15)
, primary key (WTSD_ScheduleDateId)
)
GO
create table WT_ScheduleNotify
(
 WTSN_ScheduleNotifyId nvarchar(15)
, WTSN_EmployeeId nvarchar(15)
, WTSN_ScheduleTaskId nvarchar(15)
, primary key (WTSN_ScheduleNotifyId)
)
GO
create table WT_ScheduleTask
(
 WTST_ScheduleTaskId nvarchar(15)
, WTST_Description nvarchar(200)
, WTST_ExecuteBeginDate datetime
, WTST_ExecuteEndDate datetime
, WTST_ExecuteException nvarchar(1000)
, WTST_ExecuteState nvarchar(1)
, WTST_IsEnable nvarchar(1)
, WTST_ObjectTypeName nvarchar(100)
, WTST_Parameters nvarchar(100)
, WTST_TaskName nvarchar(50)
, primary key (WTST_ScheduleTaskId)
)
GO
create table WT_ServiceException
(
 WTSE_ServiceExceptionId nvarchar(15)
, WTSE_ExceptionMessage text
, WTSE_Program nvarchar(50)
, WTSE_RaiseDate datetime
, primary key (WTSE_ServiceExceptionId)
)
GO
create table WT_WebDirectory
(
 WTWD_WebDirectoryId nvarchar(15)
, WTWD_DirectoryName nvarchar(50)
, WTWD_PhysicalFolderName nvarchar(20)
, primary key (WTWD_WebDirectoryId)
)
GO
create table WT_WebFile
(
 WTWF_WebFileId nvarchar(15)
, WTWF_Desc nvarchar(50)
, WTWF_DirectoryId nvarchar(15)
, WTWF_FileName nvarchar(50)
, WTWF_RowInsertDate datetime
, WTWF_SourceId nvarchar(15)
, WTWF_StorageName nvarchar(50)
, primary key (WTWF_WebFileId)
)
GO
