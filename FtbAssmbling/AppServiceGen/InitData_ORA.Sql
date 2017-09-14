--EO_Department
INSERT INTO EO_Department 
			(EOD_DepartmentId
           ,EOD_DepartmentName
           ,EOD_DepartmentCode
           ,EOD_DepartmentType
           ,EOD_VirtualType
           ,EOD_SortNo
           ,EOD_ParentId
           ,EOD_Note)
     VALUES(
			'EOD_1'
			,'系統維護'
			,'SYS001'
			,'A'
			,NULL
			,3
			,NULL
			,NULL
			)
;


--EO_Employee
INSERT INTO EO_Employee
           (EOE_EmployeeId
           ,EOE_DepartmentId
           ,EOE_EmployeeName
           ,EOE_EmployeeTitleId
           ,EOE_EmployeeCode
           ,EOE_EmployeeEmail
           ,EOE_EmployeeSid
           ,EOE_Phone1
           ,EOE_Phone2
           ,EOE_Sex
           ,EOE_Signature
           ,EOE_PersonalImage
           ,EOE_EntryDate
           ,EOE_LeaveDate
           ,EOE_SmsNumber
           ,EOE_CZip
           ,EOE_CAddress
           ,EOE_Remark)
     VALUES(
			'EOE_1'
           ,'EOD_1'
           ,'系統管理員'
           ,'EOET_1'
           ,'999999'
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           )
;


--EO_EmployeeTitle
INSERT INTO EO_EmployeeTitle
           (EOET_EmployeeTitleId
           ,EOET_TitleName
           ,EOET_TitleCode
           ,EOET_ListOrder)
     VALUES(
			'EOET_1'
			,'系統維護'
			,'SYS'
			,1000
			)
;


--EO_LoginAccount
INSERT INTO EO_LoginAccount
           (EOLA_LoginAccountId
           ,EOLA_LoginAccount
           ,EOLA_LoginPassword
           ,EOLA_FailureDate
           ,EOLA_FailureCount
           ,EOLA_LastLoginDate
           ,EOLA_IsEnable)
     VALUES(
			'EOE_1'
           ,'admin'
           ,'123'
           ,NULL
           ,0
           ,NULL
           ,NULL
           )
;


--EO_Menu
INSERT INTO EO_Menu
           (EOM_MenuId
           ,EOM_MenuName
           ,EOM_FileName
           ,EOM_StructId
           ,EOM_StructSource)
     VALUES(
			'EOM_MAINMENU'
           ,'主功能表'
           ,'~/data/AppMainMenu.xml'
           ,NULL
           ,'F'
           )
;


--EO_Permission
INSERT INTO EO_Permission
           (EOP_PermissionId
           ,EOP_PermissionCode
           ,EOP_PermissionName
           ,EOP_Description
           ,EOP_IsEveryOneAllow
           ,EOP_IsObjectNeed)
     VALUES(
			'EOP_APP_SA'
           ,'APN_APP_SystemAdmin'
           ,'系統\APP\系統管理者'
           ,'全部系統最高權限，設定後可以使用系統全部功能。'
           ,'B'
           ,'B'
           )
;

INSERT INTO EO_Permission
           (EOP_PermissionId
           ,EOP_PermissionCode
           ,EOP_PermissionName
           ,EOP_Description
           ,EOP_IsEveryOneAllow
           ,EOP_IsObjectNeed)
     VALUES(
			'EOP_APP_GU'
           ,'APN_APP_GeneralUse'
           ,'系統\APP\一般使用權'
           ,'全部系統一般權限。'
           ,'A'
           ,'B'
           )
;

INSERT INTO EO_Permission
           (EOP_PermissionId
           ,EOP_PermissionCode
           ,EOP_PermissionName
           ,EOP_Description
           ,EOP_IsEveryOneAllow
           ,EOP_IsObjectNeed)
     VALUES(
			'EOP_EO_SA'
           ,'APN_EO_SystemAdmin'
           ,'系統\企業組織\系統管理員'
           ,'系統企業組織最高權限'
           ,'B'
           ,'B'
           )
;

INSERT INTO EO_Permission
           (EOP_PermissionId
           ,EOP_PermissionCode
           ,EOP_PermissionName
           ,EOP_Description
           ,EOP_IsEveryOneAllow
           ,EOP_IsObjectNeed)
     VALUES(
			'EOP_EO_GU'
           ,'APN_EO_GeneralUse'
           ,'系統\企業組織\一般使用權'
           ,'系統企業組織一般權限'
           ,'A'
           ,'B'
           )
;

INSERT INTO EO_Permission
           (EOP_PermissionId
           ,EOP_PermissionCode
           ,EOP_PermissionName
           ,EOP_Description
           ,EOP_IsEveryOneAllow
           ,EOP_IsObjectNeed)
     VALUES(
			'EOP_EM_01'
           ,'APN_EM_LayoutManager'
           ,'EMS\平面配置圖\管理權限'
           ,'EMS\平面配置圖\管理權限'
           ,'B'
           ,'A'
           )
;

INSERT INTO EO_Permission
           (EOP_PermissionId
           ,EOP_PermissionCode
           ,EOP_PermissionName
           ,EOP_Description
           ,EOP_IsEveryOneAllow
           ,EOP_IsObjectNeed)
     VALUES(
			'EOP_EM_02'
           ,'APN_EM_LayoutView'
           ,'EMS\平面配置圖\檢視權限'
           ,'EMS\平面配置圖\檢視權限'
           ,'B'
           ,'A'
           )
;


--EO_PermissionSetting
INSERT INTO EO_PermissionSetting
           (EOPS_PermissionSettingId
           ,EOPS_PermissionUserId
           ,EOPS_PermissionId
           ,EOPS_ObjectId)
     VALUES(
			'EOPS_1'
           ,'EOE_1'
           ,'EOP_APP_SA'
           ,NULL
           )
;


--EO_UserEvent
INSERT INTO EO_UserEvent
           (EOUE_UserEventId
           ,EOUE_EventCode
           ,EOUE_KindName
           ,EOUE_Description
           ,EOUE_ListOrder)
     VALUES(
			'EOUE_1'
           ,'EO_UserLogin'
           ,'使用者登入'
           ,'使用者登入'
           ,1
           )
;


--WT_ScheduleTask
INSERT INTO WT_ScheduleTask
           (WTST_ScheduleTaskId
           ,WTST_TaskName
           ,WTST_Description
           ,WTST_IsEnable
           ,WTST_ExecuteBeginDate
           ,WTST_ExecuteEndDate
           ,WTST_ExecuteState
           ,WTST_ExecuteException
           ,WTST_ObjectTypeName
           ,WTST_Parameters)
     VALUES
           (
           'WTST_1'
           ,'系統資料回收'
           ,'系統資料回收'
           ,'A'
           ,null
           ,null
           ,null
           ,null
           ,'ftd.data.schedule.AppRecycleTask,AppService'
           ,null
           )
;


--EM_SysParameter
INSERT INTO EM_SysParameter
           (EMSP_Code
           ,EMSP_Desc
           ,EMSP_Value
           ,EMSP_Name)
     VALUES
           (
           'EMAIL#01#SENDER'
           ,'email 告警時的代表寄件者'
           ,'ems@yourcompany.com.tw'
           ,'Email寄件者'
           )
;

INSERT INTO EM_SysParameter
           (EMSP_Code
           ,EMSP_Desc
           ,EMSP_Value
           ,EMSP_Name)
     VALUES
           (
           'EMAIL#02#SENDERNAME'
           ,NULL
           ,'雙葉環境監控系統'
           ,'Email寄件者名稱'
           )
;

INSERT INTO EM_SysParameter
           (EMSP_Code
           ,EMSP_Desc
           ,EMSP_Value
           ,EMSP_Name)
     VALUES
           (
           'EMAIL#03#SMTP'
           ,NULL
           ,'smtp.yourcompany.com.tw'
           ,'Email 伺服器'
           )
;

INSERT INTO EM_SysParameter
           (EMSP_Code
           ,EMSP_Desc
           ,EMSP_Value
           ,EMSP_Name)
     VALUES
           (
           'EMAIL#04#SMTP_USR'
           ,NULL
           ,'ems'
           ,'Email SMTP帳號'
           )
;

INSERT INTO EM_SysParameter
           (EMSP_Code
           ,EMSP_Desc
           ,EMSP_Value
           ,EMSP_Name)
     VALUES
           (
           'EMAIL#05#SMTP_PWD'
           ,NULL
           ,'ems'
           ,'Email SMTP密碼'
           )
;

INSERT INTO EM_SysParameter
           (EMSP_Code
           ,EMSP_Desc
           ,EMSP_Value
           ,EMSP_Name)
     VALUES
           (
           'EMAIL#06#DEBUG'
           ,'偵錯EMAIL設定的話，所有的郵件都將送往該郵件地址。'
           ,null
           ,'EMAIL偵錯帳號'
           )
;

INSERT INTO EM_SysParameter
           (EMSP_Code
           ,EMSP_Desc
           ,EMSP_Value
           ,EMSP_Name)
     VALUES
           (
           'EMAIL#07#SYS_URL'
           ,'EMS系統網址，用於E-mail通知信尾連結'
           ,'http://localhost/EMS2010'
           ,'EMS系統網址'
           )
;

INSERT INTO EM_SysParameter
           (EMSP_Code
           ,EMSP_Desc
           ,EMSP_Value
           ,EMSP_Name)
     VALUES
           (
           'EMS#SAVE#MEASURE'
           ,null
           ,'180'
           ,'EMS\量測紀錄保存天數'
           )
;

INSERT INTO EM_SysParameter
           (EMSP_Code
           ,EMSP_Desc
           ,EMSP_Value
           ,EMSP_Name)
     VALUES
           (
           'EVERY8D#01#CUSTOMER_ID'
           ,null
           ,'av8d20'
           ,'EVERY8D簡訊 系統API識別帳號'
           )
;

INSERT INTO EM_SysParameter
           (EMSP_Code
           ,EMSP_Desc
           ,EMSP_Value
           ,EMSP_Name)
     VALUES
           (
           'EVERY8D#02#USER_ID'
           ,null
           ,'ems'
           ,'EVERY8D簡訊 會員登入帳號'
           )
;

INSERT INTO EM_SysParameter
           (EMSP_Code
           ,EMSP_Desc
           ,EMSP_Value
           ,EMSP_Name)
     VALUES
           (
           'EVERY8D#03#USER_PWD'
           ,null
           ,'ems*'
           ,'EVERY8D簡訊 會員登入密碼'
           )
;

commit;
