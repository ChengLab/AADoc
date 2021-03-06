USE [AADoc]
GO
/****** Object:  Table [dbo].[AA_SecurityCode]    Script Date: 2019/8/17/周六 17:01:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AA_SecurityCode](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [varchar](30) NULL,
	[GmtCreate] [datetime] NULL,
	[GmtModified] [datetime] NULL,
	[EnabledState] [int] NULL,
 CONSTRAINT [PK_AA_SECURITYCODE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[AA_SecurityCode] ([Id], [Code], [GmtCreate], [GmtModified], [EnabledState]) VALUES (N'edb13d0b-004f-43e3-ab7f-e5e5e4a01665', N'ab123cd', CAST(N'2019-08-16 00:00:00.000' AS DateTime), CAST(N'2019-08-16 00:00:00.000' AS DateTime), 1)
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_SecurityCode', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'防伪码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_SecurityCode', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_SecurityCode', @level2type=N'COLUMN',@level2name=N'GmtCreate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_SecurityCode', @level2type=N'COLUMN',@level2name=N'GmtModified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'启用状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_SecurityCode', @level2type=N'COLUMN',@level2name=N'EnabledState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'防伪码表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_SecurityCode'
GO
