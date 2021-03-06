USE [master]
GO
/****** Object:  Database [WorkManagementSystem]    Script Date: 9.05.2022 22:02:20 ******/
CREATE DATABASE [WorkManagementSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WorkManagementSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\WorkManagementSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WorkManagementSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\WorkManagementSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [WorkManagementSystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WorkManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WorkManagementSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WorkManagementSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WorkManagementSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WorkManagementSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WorkManagementSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [WorkManagementSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WorkManagementSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WorkManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WorkManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WorkManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WorkManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WorkManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WorkManagementSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WorkManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WorkManagementSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WorkManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WorkManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WorkManagementSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WorkManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WorkManagementSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WorkManagementSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WorkManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WorkManagementSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [WorkManagementSystem] SET  MULTI_USER 
GO
ALTER DATABASE [WorkManagementSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WorkManagementSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WorkManagementSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WorkManagementSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WorkManagementSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WorkManagementSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'WorkManagementSystem', N'ON'
GO
ALTER DATABASE [WorkManagementSystem] SET QUERY_STORE = OFF
GO
USE [WorkManagementSystem]
GO
/****** Object:  Table [dbo].[Authorization]    Script Date: 9.05.2022 22:02:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authorization](
	[Authorizationd] [int] IDENTITY(1,1) NOT NULL,
	[AuthorizationName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Authorization] PRIMARY KEY CLUSTERED 
(
	[Authorizationd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 9.05.2022 22:02:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 9.05.2022 22:02:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [varchar](50) NOT NULL,
	[EmployeeSurName] [varchar](50) NOT NULL,
	[EmployeeEmail] [varchar](50) NOT NULL,
	[EmployeePassword] [varchar](6) NULL,
	[EmployeePhone] [varchar](11) NULL,
	[EmployeeDepartmentId] [int] NOT NULL,
	[EmployeeAuthorizationId] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Request]    Script Date: 9.05.2022 22:02:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[RequestId] [int] IDENTITY(1,1) NOT NULL,
	[RequestDepartmentId] [int] NOT NULL,
	[RequestSubjectId] [int] NOT NULL,
	[RequestUrgencyId] [int] NOT NULL,
	[RequestStartDate] [date] NULL,
	[RequestEndDate] [date] NULL,
	[RequestMessage] [varchar](250) NOT NULL,
	[RequestTitle] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 9.05.2022 22:02:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[SubjectId] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Urgency]    Script Date: 9.05.2022 22:02:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urgency](
	[UrgencyId] [int] IDENTITY(1,1) NOT NULL,
	[UrgencyName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Urgency] PRIMARY KEY CLUSTERED 
(
	[UrgencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Authorization] FOREIGN KEY([EmployeeAuthorizationId])
REFERENCES [dbo].[Authorization] ([Authorizationd])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Authorization]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([EmployeeDepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Department] FOREIGN KEY([RequestDepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Department]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Subject] FOREIGN KEY([RequestSubjectId])
REFERENCES [dbo].[Subject] ([SubjectId])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Subject]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Urgency] FOREIGN KEY([RequestUrgencyId])
REFERENCES [dbo].[Urgency] ([UrgencyId])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Urgency]
GO
USE [master]
GO
ALTER DATABASE [WorkManagementSystem] SET  READ_WRITE 
GO
