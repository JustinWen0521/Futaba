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
			,'�t�κ��@'
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
           ,'�t�κ޲z��'
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
			,'�t�κ��@'
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
           ,'�D�\���'
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
           ,'�t��\APP\�t�κ޲z��'
           ,'�����t�γ̰��v���A�]�w��i�H�ϥΨt�Υ����\��C'
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
           ,'�t��\APP\�@��ϥ��v'
           ,'�����t�Τ@���v���C'
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
           ,'�t��\���~��´\�t�κ޲z��'
           ,'�t�Υ��~��´�̰��v��'
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
           ,'�t��\���~��´\�@��ϥ��v'
           ,'�t�Υ��~��´�@���v��'
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
           ,'EMS\�����t�m��\�޲z�v��'
           ,'EMS\�����t�m��\�޲z�v��'
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
           ,'EMS\�����t�m��\�˵��v��'
           ,'EMS\�����t�m��\�˵��v��'
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
           ,'�ϥΪ̵n�J'
           ,'�ϥΪ̵n�J'
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
           ,'�t�θ�Ʀ^��'
           ,'�t�θ�Ʀ^��'
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
           ,'email �iĵ�ɪ��N���H���'
           ,'ems@yourcompany.com.tw'
           ,'Email�H���'
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
           ,'�������Һʱ��t��'
           ,'Email�H��̦W��'
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
           ,'Email ���A��'
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
           ,'Email SMTP�b��'
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
           ,'Email SMTP�K�X'
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
           ,'����EMAIL�]�w���ܡA�Ҧ����l�󳣱N�e���Ӷl��a�}�C'
           ,null
           ,'EMAIL�����b��'
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
           ,'EMS�t�κ��}�A�Ω�E-mail�q���H���s��'
           ,'http://localhost/EMS2010'
           ,'EMS�t�κ��}'
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
           ,'EMS\�q�������O�s�Ѽ�'
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
           ,'EVERY8D²�T �t��API�ѧO�b��'
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
           ,'EVERY8D²�T �|���n�J�b��'
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
           ,'EVERY8D²�T �|���n�J�K�X'
           )
;

commit;