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
     VALUES(
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
GO

INSERT INTO [dbo].[WT_ScheduleDate]
           ([WTSD_ScheduleDateId]
           ,[WTSD_Description]
           ,[WTSD_EveryDayHour]
           ,[WTSD_EveryDayMiniute]
           ,[WTSD_IsEnable]
           ,[WTSD_MoreMinute]
           ,[WTSD_Parameters]
           ,[WTSD_PeriodType]
           ,[WTSD_ScheduleTaskId])
     VALUES
           (
		   'WTSD_1'
           ,'每天0:0分 執行。 超過5分鐘仍視為到期'
           ,0
           ,0
           ,'Y'
           ,5
           ,'AAEAAAD/////AQAAAAAAAAAMAgAAAElTeXN0ZW0sIFZlcnNpb249NC4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iNzdhNWM1NjE5MzRlMDg5BQEAAAAyU3lzdGVtLkNvbGxlY3Rpb25zLlNwZWNpYWxpemVkLk5hbWVWYWx1ZUNvbGxlY3Rpb24HAAAACFJlYWRPbmx5DEhhc2hQcm92aWRlcghDb21wYXJlcgVDb3VudARLZXlzBlZhbHVlcwdWZXJzaW9uAAMDAAYFAAEyU3lzdGVtLkNvbGxlY3Rpb25zLkNhc2VJbnNlbnNpdGl2ZUhhc2hDb2RlUHJvdmlkZXIqU3lzdGVtLkNvbGxlY3Rpb25zLkNhc2VJbnNlbnNpdGl2ZUNvbXBhcmVyCAgCAAAAAAkDAAAACQQAAAAEAAAACQUAAAAJBgAAAAUAAAAEAwAAADJTeXN0ZW0uQ29sbGVjdGlvbnMuQ2FzZUluc2Vuc2l0aXZlSGFzaENvZGVQcm92aWRlcgEAAAAGbV90ZXh0Ax1TeXN0ZW0uR2xvYmFsaXphdGlvbi5UZXh0SW5mbwkHAAAABAQAAAAqU3lzdGVtLkNvbGxlY3Rpb25zLkNhc2VJbnNlbnNpdGl2ZUNvbXBhcmVyAQAAAA1tX2NvbXBhcmVJbmZvAyBTeXN0ZW0uR2xvYmFsaXphdGlvbi5Db21wYXJlSW5mbwkIAAAAEQUAAAAEAAAABgkAAAAKUGVyaW9kVHlwZQYKAAAADUV2ZXJ5RGF5X0hvdXIGCwAAABBFdmVyeURheV9NaW5pdXRlBgwAAAAKTW9yZU1pbnV0ZRAGAAAABAAAAAkNAAAACQ4AAAAJDwAAAAkQAAAABAcAAAAdU3lzdGVtLkdsb2JhbGl6YXRpb24uVGV4dEluZm8HAAAAD21fbGlzdFNlcGFyYXRvcgxtX2lzUmVhZE9ubHkNbV9jdWx0dXJlTmFtZRFjdXN0b21DdWx0dXJlTmFtZQttX25EYXRhSXRlbRFtX3VzZVVzZXJPdmVycmlkZQ1tX3dpbjMyTGFuZ0lEAQABAQAAAAEIAQgKAQYRAAAAAAkRAAAAAAAAAAB/AAAABAgAAAAgU3lzdGVtLkdsb2JhbGl6YXRpb24uQ29tcGFyZUluZm8EAAAABm1fbmFtZQl3aW4zMkxDSUQHY3VsdHVyZQ1tX1NvcnRWZXJzaW9uAQAAAwgIIFN5c3RlbS5HbG9iYWxpemF0aW9uLlNvcnRWZXJzaW9uCREAAAAAAAAAfwAAAAoEDQAAABxTeXN0ZW0uQ29sbGVjdGlvbnMuQXJyYXlMaXN0AwAAAAZfaXRlbXMFX3NpemUIX3ZlcnNpb24FAAAICAkSAAAAAQAAAAEAAAABDgAAAA0AAAAJEwAAAAEAAAABAAAAAQ8AAAANAAAACRQAAAABAAAAAQAAAAEQAAAADQAAAAkVAAAAAQAAAAEAAAAQEgAAAAEAAAAGFgAAAAhFdmVyeURheRATAAAAAQAAAAYXAAAAATAQFAAAAAEAAAAGGAAAAAEwEBUAAAABAAAABhkAAAABNQs='
           ,'A'
           ,'WTST_1'
GO
