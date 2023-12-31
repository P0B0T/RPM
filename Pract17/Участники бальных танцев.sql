USE [master]
GO
/****** Object:  Database [Участники бальных танцев]    Script Date: 20.03.2023 19:08:40 ******/
CREATE DATABASE [Участники бальных танцев]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Участники бальных танцев', FILENAME = N'D:\SQL SERVER\MSSQL15.SQLEXPRESS\MSSQL\DATA\Участники бальных танцев.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Участники бальных танцев_log', FILENAME = N'D:\SQL SERVER\MSSQL15.SQLEXPRESS\MSSQL\DATA\Участники бальных танцев_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Участники бальных танцев] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Участники бальных танцев].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Участники бальных танцев] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Участники бальных танцев] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Участники бальных танцев] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Участники бальных танцев] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Участники бальных танцев] SET ARITHABORT OFF 
GO
ALTER DATABASE [Участники бальных танцев] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Участники бальных танцев] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Участники бальных танцев] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Участники бальных танцев] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Участники бальных танцев] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Участники бальных танцев] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Участники бальных танцев] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Участники бальных танцев] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Участники бальных танцев] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Участники бальных танцев] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Участники бальных танцев] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Участники бальных танцев] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Участники бальных танцев] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Участники бальных танцев] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Участники бальных танцев] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Участники бальных танцев] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Участники бальных танцев] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Участники бальных танцев] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Участники бальных танцев] SET  MULTI_USER 
GO
ALTER DATABASE [Участники бальных танцев] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Участники бальных танцев] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Участники бальных танцев] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Участники бальных танцев] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Участники бальных танцев] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Участники бальных танцев] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Участники бальных танцев] SET QUERY_STORE = OFF
GO
USE [Участники бальных танцев]
GO
/****** Object:  Table [dbo].[Участники]    Script Date: 20.03.2023 19:08:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Участники](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ФИО] [nvarchar](150) NULL,
	[Город] [nvarchar](150) NULL,
	[Фамилия_тренера] [nvarchar](150) NULL,
	[Оценка] [int] NULL,
 CONSTRAINT [PK_Участники] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Участники] ON 

INSERT [dbo].[Участники] ([Id], [ФИО], [Город], [Фамилия_тренера], [Оценка]) VALUES (3, N'Ивано Иван Иванович', N'рязань', N'Белов', 4)
INSERT [dbo].[Участники] ([Id], [ФИО], [Город], [Фамилия_тренера], [Оценка]) VALUES (4, N'уолоипуало', N'уклопвкш', N'2', 2)
INSERT [dbo].[Участники] ([Id], [ФИО], [Город], [Фамилия_тренера], [Оценка]) VALUES (5, N'ив', N'в', N'в', 4)
INSERT [dbo].[Участники] ([Id], [ФИО], [Город], [Фамилия_тренера], [Оценка]) VALUES (6, N'Ив', N'2', N'2', 2)
INSERT [dbo].[Участники] ([Id], [ФИО], [Город], [Фамилия_тренера], [Оценка]) VALUES (7, N'Иванов', N'в', N'в', 3)
SET IDENTITY_INSERT [dbo].[Участники] OFF
GO
USE [master]
GO
ALTER DATABASE [Участники бальных танцев] SET  READ_WRITE 
GO
