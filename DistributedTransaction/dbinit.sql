USE [master]
GO
/****** Object:  Database [AADoc]    Script Date: 2019/8/17/周六 16:49:50 ******/
CREATE DATABASE [AADoc]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AADoc', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\AADoc.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AADoc_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\AADoc_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AADoc] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AADoc].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AADoc] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AADoc] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AADoc] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AADoc] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AADoc] SET ARITHABORT OFF 
GO
ALTER DATABASE [AADoc] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AADoc] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AADoc] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AADoc] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AADoc] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AADoc] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AADoc] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AADoc] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AADoc] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AADoc] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AADoc] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AADoc] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AADoc] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AADoc] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AADoc] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AADoc] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AADoc] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AADoc] SET RECOVERY FULL 
GO
ALTER DATABASE [AADoc] SET  MULTI_USER 
GO
ALTER DATABASE [AADoc] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AADoc] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AADoc] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AADoc] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [AADoc] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AADoc', N'ON'
GO
USE [AADoc]
GO
/****** Object:  Table [dbo].[AA_ReturnEventMsg]    Script Date: 2019/8/17/周六 16:49:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AA_ReturnEventMsg](
	[Id] [uniqueidentifier] NOT NULL,
	[MsgId] [uniqueidentifier] NULL,
	[ConsumerSatus] [int] NULL,
	[ReturnOrderId] [uniqueidentifier] NULL,
	[EventMsgType] [int] NULL,
	[GmtCreate] [datetime] NULL,
	[GmtModified] [datetime] NULL,
	[RetryCount] [int] NULL,
 CONSTRAINT [PK_AA_RETURNEVENTMSG] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AA_ReturnOrder]    Script Date: 2019/8/17/周六 16:49:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AA_ReturnOrder](
	[Id] [uniqueidentifier] NOT NULL,
	[BillNum] [nvarchar](30) NOT NULL,
	[GmtCreate] [datetime] NULL,
	[Status] [int] NULL,
	[GmtModified] [datetime] NULL,
 CONSTRAINT [PK_AA_ReturnOrder_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AA_ReturnSecurityDistinct]    Script Date: 2019/8/17/周六 16:49:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AA_ReturnSecurityDistinct](
	[MsgId] [uniqueidentifier] NOT NULL,
	[GmtCreate] [datetime] NULL,
 CONSTRAINT [PK_AA_RETURNSECURITYDISTINCT] PRIMARY KEY CLUSTERED 
(
	[MsgId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AA_SecurityCode]    Script Date: 2019/8/17/周六 16:49:50 ******/
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
/****** Object:  Table [dbo].[AA_StockInOrder]    Script Date: 2019/8/17/周六 16:49:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AA_StockInOrder](
	[Id] [uniqueidentifier] NOT NULL,
	[StockInType] [int] NULL,
	[BillNum] [nvarchar](30) NOT NULL,
	[ObjectOrderId] [uniqueidentifier] NOT NULL,
	[GmtCreate] [datetime] NOT NULL,
	[GmtModified] [datetime] NOT NULL,
 CONSTRAINT [PK_AA_STOCKINORDER] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'10 待消费
   20 消费成功 
   ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_ReturnEventMsg', @level2type=N'COLUMN',@level2name=N'ConsumerSatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'10 -防伪码初始化； 20 入库单创建' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_ReturnEventMsg', @level2type=N'COLUMN',@level2name=N'EventMsgType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_ReturnEventMsg', @level2type=N'COLUMN',@level2name=N'GmtCreate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_ReturnEventMsg', @level2type=N'COLUMN',@level2name=N'GmtModified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退货事件消息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_ReturnEventMsg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_ReturnOrder', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单据编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_ReturnOrder', @level2type=N'COLUMN',@level2name=N'BillNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_ReturnOrder', @level2type=N'COLUMN',@level2name=N'GmtCreate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_ReturnOrder', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_ReturnOrder', @level2type=N'COLUMN',@level2name=N'GmtModified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退货订单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_ReturnOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_ReturnSecurityDistinct', @level2type=N'COLUMN',@level2name=N'GmtCreate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退货防伪码初始化消息去重表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_ReturnSecurityDistinct'
GO
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_StockInOrder', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_StockInOrder', @level2type=N'COLUMN',@level2name=N'StockInType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单据编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_StockInOrder', @level2type=N'COLUMN',@level2name=N'BillNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联单据id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_StockInOrder', @level2type=N'COLUMN',@level2name=N'ObjectOrderId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_StockInOrder', @level2type=N'COLUMN',@level2name=N'GmtCreate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_StockInOrder', @level2type=N'COLUMN',@level2name=N'GmtModified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_StockInOrder'
GO
USE [master]
GO
ALTER DATABASE [AADoc] SET  READ_WRITE 
GO
