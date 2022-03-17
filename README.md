CustomersAPI
Db first olarak oluşturulan proje için database scripti:




USE [master]
GO

DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)
FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1
EXECUTE (N'CREATE DATABASE BankX
  ON PRIMARY (NAME = N''BankX'', FILENAME = N''' + @device_directory + N'BankX.mdf'')
  LOG ON (NAME = N''BankX_log'',  FILENAME = N''' + @device_directory + N'BankX.ldf'')  WITH CATALOG_COLLATION = DATABASE_DEFAULT')

GO
ALTER DATABASE [BankX] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BankX].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BankX] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [BankX] SET ANSI_NULLS ON 
GO
ALTER DATABASE [BankX] SET ANSI_PADDING ON 
GO
ALTER DATABASE [BankX] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [BankX] SET ARITHABORT ON 
GO
ALTER DATABASE [BankX] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BankX] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BankX] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BankX] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BankX] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [BankX] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [BankX] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BankX] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [BankX] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BankX] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BankX] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BankX] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BankX] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BankX] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BankX] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BankX] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BankX] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BankX] SET RECOVERY FULL 
GO
ALTER DATABASE [BankX] SET  MULTI_USER 
GO
ALTER DATABASE [BankX] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BankX] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BankX] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BankX] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BankX] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BankX] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BankX] SET QUERY_STORE = OFF
GO
USE [BankX]
GO
/****** Object:  Table [dbo].[CustomerDetails]    Script Date: 17.03.2022 02:27:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerBudget] [money] NULL,
	[CustomerDebt] [money] NULL,
	[GiveCredit] [bit] NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
	[TransactionDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 17.03.2022 02:27:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [uniqueidentifier] NOT NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
	[CustomerLastName] [nvarchar](50) NOT NULL,
	[CustomerPhone] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CustomerDetails] ON 

INSERT [dbo].[CustomerDetails] ([Id], [CustomerBudget], [CustomerDebt], [GiveCredit], [CustomerId], [TransactionDate]) VALUES (1, 35.0000, 35.0000, 1, N'e61359f8-f105-42e8-bf7e-93e51b30a90c', CAST(N'2022-03-01T02:50:16.013' AS DateTime))
INSERT [dbo].[CustomerDetails] ([Id], [CustomerBudget], [CustomerDebt], [GiveCredit], [CustomerId], [TransactionDate]) VALUES (2, 854.0000, 55555.0000, 1, N'f51c7753-86aa-43a8-b853-cb7085aa4513', CAST(N'2022-03-01T02:50:43.413' AS DateTime))
INSERT [dbo].[CustomerDetails] ([Id], [CustomerBudget], [CustomerDebt], [GiveCredit], [CustomerId], [TransactionDate]) VALUES (3, 7.0000, 578555.0000, 1, N'73959531-b1a1-4b74-979e-cb7957bb91d9', CAST(N'2022-03-01T02:51:06.653' AS DateTime))
INSERT [dbo].[CustomerDetails] ([Id], [CustomerBudget], [CustomerDebt], [GiveCredit], [CustomerId], [TransactionDate]) VALUES (4, 854.0000, 25.0000, 1, N'edff4599-ddff-4c47-8be7-cbcca7c23c4e', CAST(N'2022-03-01T02:51:31.143' AS DateTime))
INSERT [dbo].[CustomerDetails] ([Id], [CustomerBudget], [CustomerDebt], [GiveCredit], [CustomerId], [TransactionDate]) VALUES (5, 854.0000, 825.0000, 0, N'edff4599-ddff-4c47-8be7-cbcca7c23c4e', CAST(N'2022-03-01T02:51:39.603' AS DateTime))
INSERT [dbo].[CustomerDetails] ([Id], [CustomerBudget], [CustomerDebt], [GiveCredit], [CustomerId], [TransactionDate]) VALUES (6, 854.0000, 1000.0000, 0, N'edff4599-ddff-4c47-8be7-cbcca7c23c4e', CAST(N'2022-03-01T02:51:53.903' AS DateTime))
INSERT [dbo].[CustomerDetails] ([Id], [CustomerBudget], [CustomerDebt], [GiveCredit], [CustomerId], [TransactionDate]) VALUES (7, 70.0000, 80.0000, 1, N'73959531-b1a1-4b74-979e-cb7957bb91d9', CAST(N'2022-03-01T02:52:22.763' AS DateTime))
INSERT [dbo].[CustomerDetails] ([Id], [CustomerBudget], [CustomerDebt], [GiveCredit], [CustomerId], [TransactionDate]) VALUES (8, 770.0000, 80.0000, 0, N'73959531-b1a1-4b74-979e-cb7957bb91d9', CAST(N'2022-03-01T02:52:28.650' AS DateTime))
INSERT [dbo].[CustomerDetails] ([Id], [CustomerBudget], [CustomerDebt], [GiveCredit], [CustomerId], [TransactionDate]) VALUES (9, 40.0000, 80.0000, 1, N'f51c7753-86aa-43a8-b853-cb7085aa4513', CAST(N'2022-03-01T02:53:02.983' AS DateTime))
INSERT [dbo].[CustomerDetails] ([Id], [CustomerBudget], [CustomerDebt], [GiveCredit], [CustomerId], [TransactionDate]) VALUES (10, 40.0000, 4780.0000, 0, N'f51c7753-86aa-43a8-b853-cb7085aa4513', CAST(N'2022-03-01T02:53:07.900' AS DateTime))
INSERT [dbo].[CustomerDetails] ([Id], [CustomerBudget], [CustomerDebt], [GiveCredit], [CustomerId], [TransactionDate]) VALUES (11, 60.0000, 380.0000, 1, N'e61359f8-f105-42e8-bf7e-93e51b30a90c', CAST(N'2022-03-01T02:53:32.833' AS DateTime))
INSERT [dbo].[CustomerDetails] ([Id], [CustomerBudget], [CustomerDebt], [GiveCredit], [CustomerId], [TransactionDate]) VALUES (12, 650.0000, 3780.0000, 0, N'e61359f8-f105-42e8-bf7e-93e51b30a90c', CAST(N'2022-03-01T02:53:43.310' AS DateTime))
INSERT [dbo].[CustomerDetails] ([Id], [CustomerBudget], [CustomerDebt], [GiveCredit], [CustomerId], [TransactionDate]) VALUES (1012, 1500.0000, 2000.0000, 1, N'edff4599-ddff-4c47-8be7-cbcca7c23c4e', CAST(N'2022-03-15T23:38:41.363' AS DateTime))
SET IDENTITY_INSERT [dbo].[CustomerDetails] OFF
GO
INSERT [dbo].[Customers] ([CustomerId], [CustomerName], [CustomerLastName], [CustomerPhone]) VALUES (N'9eee84ca-4e86-4aee-a391-7118ad457487', N'Sami', N'Bozdağ', 5684525812)
INSERT [dbo].[Customers] ([CustomerId], [CustomerName], [CustomerLastName], [CustomerPhone]) VALUES (N'7b579764-88e8-4392-bcc4-883e8a63b658', N'Sema', N'Akalın', 2)
INSERT [dbo].[Customers] ([CustomerId], [CustomerName], [CustomerLastName], [CustomerPhone]) VALUES (N'e61359f8-f105-42e8-bf7e-93e51b30a90c', N'Cemal', N'Süreya', 553255534)
INSERT [dbo].[Customers] ([CustomerId], [CustomerName], [CustomerLastName], [CustomerPhone]) VALUES (N'd732acb8-acaf-44bc-8f2a-969724e39ce9', N'Zeynep', N'Yaman', 0)
INSERT [dbo].[Customers] ([CustomerId], [CustomerName], [CustomerLastName], [CustomerPhone]) VALUES (N'd471ad32-b2e0-47e4-84fb-99e73d306ccd', N'Emre', N'Yeşil', 505685582)
INSERT [dbo].[Customers] ([CustomerId], [CustomerName], [CustomerLastName], [CustomerPhone]) VALUES (N'f51c7753-86aa-43a8-b853-cb7085aa4513', N'Halit Ziya', N'Usakligil', 534)
INSERT [dbo].[Customers] ([CustomerId], [CustomerName], [CustomerLastName], [CustomerPhone]) VALUES (N'73959531-b1a1-4b74-979e-cb7957bb91d9', N'Elif Sena', N'Safak', 241541152)
INSERT [dbo].[Customers] ([CustomerId], [CustomerName], [CustomerLastName], [CustomerPhone]) VALUES (N'edff4599-ddff-4c47-8be7-cbcca7c23c4e', N'Orhan', N'Pamuk', 5532588114)
INSERT [dbo].[Customers] ([CustomerId], [CustomerName], [CustomerLastName], [CustomerPhone]) VALUES (N'359f7b7b-efc1-4b37-a3f5-fc175f750785', N'Selahattin', N'Boz', 56845812)
GO
ALTER TABLE [dbo].[CustomerDetails] ADD  DEFAULT (getdate()) FOR [TransactionDate]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT (newid()) FOR [CustomerId]
GO
ALTER TABLE [dbo].[CustomerDetails]  WITH CHECK ADD  CONSTRAINT [FK_CustomerDetails_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[CustomerDetails] CHECK CONSTRAINT [FK_CustomerDetails_Customers]
GO
USE [master]
GO
ALTER DATABASE [BankX] SET  READ_WRITE 
GO
