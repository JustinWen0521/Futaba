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
GO


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
GO


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
GO


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
GO


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
GO


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
GO

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
GO

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
GO

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
GO


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
GO


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
GO

INSERT INTO EO_UserEvent
           (EOUE_UserEventId
           ,EOUE_EventCode
           ,EOUE_KindName
           ,EOUE_Description
           ,EOUE_ListOrder)
     VALUES(
			'EOUE_2'
           ,'WT_ScheduleTaskExecuted'
           ,'工作排程執行成功'
           ,'工作排程執行成功'
           ,1
           )
GO

INSERT INTO EO_UserEvent
           (EOUE_UserEventId
           ,EOUE_EventCode
           ,EOUE_KindName
           ,EOUE_Description
           ,EOUE_ListOrder)
     VALUES(
			'EOUE_3'
           ,'WT_ScheduleTaskFailed'
           ,'工作排程執行失敗'
           ,'工作排程執行失敗'
           ,1
           )
GO

