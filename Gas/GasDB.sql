USE [master]
GO
/****** Object:  Database [Gas]    Script Date: 12/14/2018 9:38:00 PM ******/
CREATE DATABASE [Gas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Gas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Gas.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Gas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Gas_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Gas] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Gas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Gas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Gas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Gas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Gas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Gas] SET ARITHABORT OFF 
GO
ALTER DATABASE [Gas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Gas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Gas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Gas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Gas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Gas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Gas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Gas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Gas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Gas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Gas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Gas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Gas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Gas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Gas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Gas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Gas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Gas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Gas] SET  MULTI_USER 
GO
ALTER DATABASE [Gas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Gas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Gas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Gas] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Gas] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Gas]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 12/14/2018 9:38:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[address] [nvarchar](100) NULL,
	[phone] [nvarchar](100) NULL,
	[stt] [int] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gas]    Script Date: 12/14/2018 9:38:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[quantity] [float] NOT NULL,
	[price] [float] NOT NULL,
 CONSTRAINT [PK_Gas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Owe]    Script Date: 12/14/2018 9:38:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Owe](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [datetime] NOT NULL,
	[customer] [int] NOT NULL,
	[gas] [int] NULL,
	[price] [float] NULL,
	[quantity] [float] NULL,
	[total] [float] NOT NULL,
	[stt] [int] NOT NULL,
	[note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Owe] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pay]    Script Date: 12/14/2018 9:38:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pay](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [datetime] NOT NULL,
	[owe] [int] NULL,
	[note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Pay] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([id], [name], [address], [phone], [stt]) VALUES (1, N'bác Phương', N'thôn 11', N'0983974232', 1)
INSERT [dbo].[Customer] ([id], [name], [address], [phone], [stt]) VALUES (2, N'bác Gấm', N'thôn 11', N'0983974232', 1)
INSERT [dbo].[Customer] ([id], [name], [address], [phone], [stt]) VALUES (3, N'mợ Thu ', N'thôn 4', N'0983974232', 1)
INSERT [dbo].[Customer] ([id], [name], [address], [phone], [stt]) VALUES (5, N'cậu Kiên', N'thôn 4', N'0983974232', 0)
INSERT [dbo].[Customer] ([id], [name], [address], [phone], [stt]) VALUES (7, N'anh Quang', N'Hà Nội', N'', 1)
INSERT [dbo].[Customer] ([id], [name], [address], [phone], [stt]) VALUES (8, N'anh Quang', N'', N'', 0)
INSERT [dbo].[Customer] ([id], [name], [address], [phone], [stt]) VALUES (9, N'', N'', N'', 0)
INSERT [dbo].[Customer] ([id], [name], [address], [phone], [stt]) VALUES (10, N'Võ Nhật Thiên', N'', N'', 1)
INSERT [dbo].[Customer] ([id], [name], [address], [phone], [stt]) VALUES (11, N'Cậu Phú', N'', N'', 0)
INSERT [dbo].[Customer] ([id], [name], [address], [phone], [stt]) VALUES (12, N'anh Đăng 1', N'thôn 11', N'113', 0)
INSERT [dbo].[Customer] ([id], [name], [address], [phone], [stt]) VALUES (13, N'Cô Hiên thôn 4', N'thôn 4', N'0983974232', 1)
INSERT [dbo].[Customer] ([id], [name], [address], [phone], [stt]) VALUES (14, N'Na Na', N'Thôn 11 Xã Thống Nhất', N'0378034064', 1)
INSERT [dbo].[Customer] ([id], [name], [address], [phone], [stt]) VALUES (15, N'Thủy Bảo', N'nhà', N'113', 1)
INSERT [dbo].[Customer] ([id], [name], [address], [phone], [stt]) VALUES (16, N'Hòa Phát', N'Miền Tây', N'133', 1)
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Gas] ON 

INSERT [dbo].[Gas] ([id], [name], [quantity], [price]) VALUES (1, N'Xăng A95', 1000, 20000)
INSERT [dbo].[Gas] ([id], [name], [quantity], [price]) VALUES (2, N'Xăng E5', 500, 19000)
INSERT [dbo].[Gas] ([id], [name], [quantity], [price]) VALUES (3, N'Dầu DO', 2000, 17000)
INSERT [dbo].[Gas] ([id], [name], [quantity], [price]) VALUES (4, N'xăng A92', 1000, 0)
INSERT [dbo].[Gas] ([id], [name], [quantity], [price]) VALUES (5, N'Tiền Mượn', 0, 0)
SET IDENTITY_INSERT [dbo].[Gas] OFF
SET IDENTITY_INSERT [dbo].[Owe] ON 

INSERT [dbo].[Owe] ([id], [date], [customer], [gas], [price], [quantity], [total], [stt], [note]) VALUES (1, CAST(N'2018-06-12 02:01:03.000' AS DateTime), 1, 1, 20000, 1, 20000, 1, N'Trả hết')
INSERT [dbo].[Owe] ([id], [date], [customer], [gas], [price], [quantity], [total], [stt], [note]) VALUES (3, CAST(N'2018-07-12 00:00:00.000' AS DateTime), 2, 1, 20000, 1, 20000, 1, N'Trả Hết')
INSERT [dbo].[Owe] ([id], [date], [customer], [gas], [price], [quantity], [total], [stt], [note]) VALUES (4, CAST(N'2018-02-01 00:00:00.000' AS DateTime), 3, 1, 20000, 1, 20000, 2, N'Thiếu 10K')
INSERT [dbo].[Owe] ([id], [date], [customer], [gas], [price], [quantity], [total], [stt], [note]) VALUES (5, CAST(N'2018-12-07 00:00:00.000' AS DateTime), 1, 1, 20000, 1, 20000, 1, N'Trả Hết')
INSERT [dbo].[Owe] ([id], [date], [customer], [gas], [price], [quantity], [total], [stt], [note]) VALUES (6, CAST(N'2018-12-08 11:10:58.000' AS DateTime), 7, 1, 20000, 1, 20000, 1, NULL)
INSERT [dbo].[Owe] ([id], [date], [customer], [gas], [price], [quantity], [total], [stt], [note]) VALUES (7, CAST(N'2018-12-09 11:15:10.000' AS DateTime), 7, 2, 18000, 2, 36000, 2, NULL)
INSERT [dbo].[Owe] ([id], [date], [customer], [gas], [price], [quantity], [total], [stt], [note]) VALUES (8, CAST(N'2018-12-08 11:21:53.000' AS DateTime), 1, 1, 20000, 1, 20000, 1, NULL)
INSERT [dbo].[Owe] ([id], [date], [customer], [gas], [price], [quantity], [total], [stt], [note]) VALUES (9, CAST(N'2018-12-08 11:25:15.000' AS DateTime), 1, 3, 17000, 5, 85000, 2, N'Mai Tra')
INSERT [dbo].[Owe] ([id], [date], [customer], [gas], [price], [quantity], [total], [stt], [note]) VALUES (10, CAST(N'2018-12-08 11:34:22.000' AS DateTime), 13, 2, 18000, 1, 18000, 0, N'ba lấy')
INSERT [dbo].[Owe] ([id], [date], [customer], [gas], [price], [quantity], [total], [stt], [note]) VALUES (11, CAST(N'2018-12-09 10:12:39.000' AS DateTime), 2, 1, 0, 0, 20000, 2, N'Mai Tra')
INSERT [dbo].[Owe] ([id], [date], [customer], [gas], [price], [quantity], [total], [stt], [note]) VALUES (12, CAST(N'2018-12-09 13:02:00.000' AS DateTime), 7, 1, 20000, 2.2, 44000, 2, N'')
INSERT [dbo].[Owe] ([id], [date], [customer], [gas], [price], [quantity], [total], [stt], [note]) VALUES (13, CAST(N'2018-12-10 09:04:24.000' AS DateTime), 2, 1, 20000, 1, 20000, 2, N'mai tra')
INSERT [dbo].[Owe] ([id], [date], [customer], [gas], [price], [quantity], [total], [stt], [note]) VALUES (14, CAST(N'2018-12-11 11:19:45.000' AS DateTime), 2, 3, 17000, 1, 17000, 1, N'mua dau')
INSERT [dbo].[Owe] ([id], [date], [customer], [gas], [price], [quantity], [total], [stt], [note]) VALUES (15, CAST(N'2018-12-11 11:23:41.000' AS DateTime), 14, 5, 0, 0, 6000000, 1, N'Na Na mượn ')
INSERT [dbo].[Owe] ([id], [date], [customer], [gas], [price], [quantity], [total], [stt], [note]) VALUES (16, CAST(N'2018-12-11 22:54:15.000' AS DateTime), 15, 1, 0, 0, 2500000, 1, N'Thủy Lấy')
INSERT [dbo].[Owe] ([id], [date], [customer], [gas], [price], [quantity], [total], [stt], [note]) VALUES (17, CAST(N'2018-12-11 22:55:28.000' AS DateTime), 15, 5, 0, 1, 500, 2, N'thêm hôm nay')
INSERT [dbo].[Owe] ([id], [date], [customer], [gas], [price], [quantity], [total], [stt], [note]) VALUES (18, CAST(N'2018-12-11 23:04:12.000' AS DateTime), 16, 2, 19000, 10, 190000, 1, N'Chú Lịch Lấy')
INSERT [dbo].[Owe] ([id], [date], [customer], [gas], [price], [quantity], [total], [stt], [note]) VALUES (19, CAST(N'2018-12-10 23:06:06.000' AS DateTime), 16, 3, 17000, 50, 850000, 1, N'')
SET IDENTITY_INSERT [dbo].[Owe] OFF
SET IDENTITY_INSERT [dbo].[Pay] ON 

INSERT [dbo].[Pay] ([id], [date], [owe], [note]) VALUES (1, CAST(N'2018-12-10 08:58:06.000' AS DateTime), 12, N'tra')
INSERT [dbo].[Pay] ([id], [date], [owe], [note]) VALUES (2, CAST(N'2018-12-10 08:59:28.000' AS DateTime), 7, N'ok')
INSERT [dbo].[Pay] ([id], [date], [owe], [note]) VALUES (3, CAST(N'2018-12-10 09:04:49.000' AS DateTime), 13, N'tra roi')
INSERT [dbo].[Pay] ([id], [date], [owe], [note]) VALUES (4, CAST(N'2018-12-10 09:05:35.000' AS DateTime), 11, N'Mai Tra')
INSERT [dbo].[Pay] ([id], [date], [owe], [note]) VALUES (5, CAST(N'2018-12-11 10:51:10.000' AS DateTime), 9, N'Đã Trả Hết')
INSERT [dbo].[Pay] ([id], [date], [owe], [note]) VALUES (6, CAST(N'2018-12-11 22:58:06.000' AS DateTime), 4, N'Cậu Kiên trả')
INSERT [dbo].[Pay] ([id], [date], [owe], [note]) VALUES (7, CAST(N'2018-12-11 23:00:39.000' AS DateTime), 17, N'Thiên Trả')
SET IDENTITY_INSERT [dbo].[Pay] OFF
ALTER TABLE [dbo].[Owe]  WITH CHECK ADD  CONSTRAINT [FK_Owe_Customer] FOREIGN KEY([customer])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[Owe] CHECK CONSTRAINT [FK_Owe_Customer]
GO
ALTER TABLE [dbo].[Owe]  WITH CHECK ADD  CONSTRAINT [FK_Owe_Gas] FOREIGN KEY([gas])
REFERENCES [dbo].[Gas] ([id])
GO
ALTER TABLE [dbo].[Owe] CHECK CONSTRAINT [FK_Owe_Gas]
GO
ALTER TABLE [dbo].[Pay]  WITH CHECK ADD  CONSTRAINT [FK_Pay_Owe] FOREIGN KEY([owe])
REFERENCES [dbo].[Owe] ([id])
GO
ALTER TABLE [dbo].[Pay] CHECK CONSTRAINT [FK_Pay_Owe]
GO
USE [master]
GO
ALTER DATABASE [Gas] SET  READ_WRITE 
GO
