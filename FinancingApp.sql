USE [master]
GO
/****** Object:  Database [FinancingApp]    Script Date: 12/5/2014 1:14:57 AM ******/
CREATE DATABASE [FinancingApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FinancingApp', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\FinancingApp.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FinancingApp_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\FinancingApp_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FinancingApp] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FinancingApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FinancingApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FinancingApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FinancingApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FinancingApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FinancingApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [FinancingApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FinancingApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FinancingApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FinancingApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FinancingApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FinancingApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FinancingApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FinancingApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FinancingApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FinancingApp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FinancingApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FinancingApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FinancingApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FinancingApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FinancingApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FinancingApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FinancingApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FinancingApp] SET RECOVERY FULL 
GO
ALTER DATABASE [FinancingApp] SET  MULTI_USER 
GO
ALTER DATABASE [FinancingApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FinancingApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FinancingApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FinancingApp] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [FinancingApp] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'FinancingApp', N'ON'
GO
USE [FinancingApp]
GO
/****** Object:  User [NT AUTHORITY\SYSTEM]    Script Date: 12/5/2014 1:14:57 AM ******/
CREATE USER [NT AUTHORITY\SYSTEM] FOR LOGIN [NT AUTHORITY\SYSTEM] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_datareader] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 12/5/2014 1:14:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Address](
	[AddressId] [bigint] IDENTITY(1,1) NOT NULL,
	[AddressLine1] [varchar](100) NOT NULL,
	[AddressLine2] [varchar](50) NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](50) NOT NULL,
	[Zipcode] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Application]    Script Date: 12/5/2014 1:14:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Application](
	[ApplicationId] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CustomerId] [bigint] NOT NULL,
	[SalesRepresentativeId] [bigint] NOT NULL,
	[VendorId] [bigint] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[Status] [varchar](50) NULL,
	[EmployeeId] [bigint] NULL,
	[Name] [varchar](50) NOT NULL,
	[ConfirmationNumber] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Application_1] PRIMARY KEY CLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 12/5/2014 1:14:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [bigint] IDENTITY(1,1) NOT NULL,
	[SSN] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NOT NULL,
	[AddressId] [bigint] NOT NULL,
	[ProfileId] [bigint] NULL,
	[Phone] [varchar](50) NULL,
	[EmailAddress] [varchar](50) NULL,
 CONSTRAINT [PK_Customer_2] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 12/5/2014 1:14:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 12/5/2014 1:14:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Equipment](
	[EquipmentId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Type] [varchar](50) NULL,
	[Cost] [money] NOT NULL,
	[AddressId] [bigint] NOT NULL,
 CONSTRAINT [PK_Equipment] PRIMARY KEY CLUSTERED 
(
	[EquipmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Profile]    Script Date: 12/5/2014 1:14:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Profile](
	[ProfileId] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[ProfileType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SalesRepresentative]    Script Date: 12/5/2014 1:14:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SalesRepresentative](
	[SalesRepresentativeId] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NOT NULL,
	[ProfileId] [bigint] NOT NULL,
 CONSTRAINT [PK_SalesRepresentative_1] PRIMARY KEY CLUSTERED 
(
	[SalesRepresentativeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 12/5/2014 1:14:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vendor](
	[VendorId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[AddressId] [bigint] NOT NULL,
 CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED 
(
	[VendorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendorSalesRepresentative]    Script Date: 12/5/2014 1:14:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorSalesRepresentative](
	[SalesRepresentativeId] [bigint] NOT NULL,
	[VendorId] [bigint] NOT NULL,
	[RepresentativeType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SalesRepresentative_Vendor] PRIMARY KEY CLUSTERED 
(
	[SalesRepresentativeId] ASC,
	[VendorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Application_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Application] CHECK CONSTRAINT [FK_Application_Customer]
GO
ALTER TABLE [dbo].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Application_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Application] CHECK CONSTRAINT [FK_Application_Employee]
GO
ALTER TABLE [dbo].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Application_SalesRepresentative] FOREIGN KEY([SalesRepresentativeId])
REFERENCES [dbo].[SalesRepresentative] ([SalesRepresentativeId])
GO
ALTER TABLE [dbo].[Application] CHECK CONSTRAINT [FK_Application_SalesRepresentative]
GO
ALTER TABLE [dbo].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Application_Vendor] FOREIGN KEY([VendorId])
REFERENCES [dbo].[Vendor] ([VendorId])
GO
ALTER TABLE [dbo].[Application] CHECK CONSTRAINT [FK_Application_Vendor]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Address] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([AddressId])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Address]
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_Address] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([AddressId])
GO
ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK_Equipment_Address]
GO
ALTER TABLE [dbo].[Vendor]  WITH CHECK ADD  CONSTRAINT [FK_Vendor_Address] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([AddressId])
GO
ALTER TABLE [dbo].[Vendor] CHECK CONSTRAINT [FK_Vendor_Address]
GO
ALTER TABLE [dbo].[VendorSalesRepresentative]  WITH CHECK ADD  CONSTRAINT [FK_SalesRepresentative_Vendor_SalesRepresentative] FOREIGN KEY([SalesRepresentativeId])
REFERENCES [dbo].[SalesRepresentative] ([SalesRepresentativeId])
GO
ALTER TABLE [dbo].[VendorSalesRepresentative] CHECK CONSTRAINT [FK_SalesRepresentative_Vendor_SalesRepresentative]
GO
ALTER TABLE [dbo].[VendorSalesRepresentative]  WITH CHECK ADD  CONSTRAINT [FK_SalesRepresentative_Vendor_Vendor] FOREIGN KEY([VendorId])
REFERENCES [dbo].[Vendor] ([VendorId])
GO
ALTER TABLE [dbo].[VendorSalesRepresentative] CHECK CONSTRAINT [FK_SalesRepresentative_Vendor_Vendor]
GO
USE [master]
GO
ALTER DATABASE [FinancingApp] SET  READ_WRITE 
GO
