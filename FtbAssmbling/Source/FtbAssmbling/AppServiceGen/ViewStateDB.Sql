/****** Object:  Table [dbo].[AspNet_ViewState]    Script Date: 07/15/2010 10:17:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AspNet_ViewState](
	[VS_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[VS_DATE] [smalldatetime] NULL,
	[VS_DATA] [varbinary](max) NULL,
	[VS_NextId] [bigint] NULL,
 CONSTRAINT [PK_AspNet_ViewState_1] PRIMARY KEY NONCLUSTERED 
(
	[VS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[AspNet_ViewState] ADD  CONSTRAINT [DF_AspNet_ViewState_VS_DATE]  DEFAULT (getdate()) FOR [VS_DATE]
GO

ALTER TABLE [dbo].[AspNet_ViewState] ADD  CONSTRAINT [DF_AspNet_ViewState_VS_NextId]  DEFAULT ((0)) FOR [VS_NextId]
GO



/****** Object:  StoredProcedure [dbo].[ViewState_Add]    Script Date: 07/15/2010 10:17:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/***************
寫入ViewSate
***************/
CREATE PROCEDURE [dbo].[ViewState_Add]
(	
	@VS_DATA varbinary(max)
	, @VS_PreId bigint --上一筆資料
	, @VS_ID bigint out
)	
AS	
	insert into AspNet_ViewState (VS_DATA) values (@VS_DATA)
	select @VS_ID = SCOPE_IDENTITY() 
	update AspNet_ViewState set VS_NextId = @VS_ID 
	where VS_ID = @VS_PreId

GO



/****** Object:  StoredProcedure [dbo].[ViewState_Read]    Script Date: 07/15/2010 10:18:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ViewState_Read]
(
	@VS_ID bigint
	, @VS_DATA varbinary(max) out	
	, @VS_NextId bigint out
)
AS
	select @VS_DATA = VS_DATA, @VS_NextId = VS_NextId 
	from AspNet_ViewState 
	where VS_ID = @VS_ID
	

GO

