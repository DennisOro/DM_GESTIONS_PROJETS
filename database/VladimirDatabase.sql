USE [master]
GO
/****** Object:  Database [INF6150]    Script Date: 5/19/2019 12:36:39 AM ******/
CREATE DATABASE [INF6150]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'INF6150', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\INF6150.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'INF6150_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\INF6150_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [INF6150] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [INF6150].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [INF6150] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [INF6150] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [INF6150] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [INF6150] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [INF6150] SET ARITHABORT OFF 
GO
ALTER DATABASE [INF6150] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [INF6150] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [INF6150] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [INF6150] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [INF6150] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [INF6150] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [INF6150] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [INF6150] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [INF6150] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [INF6150] SET  DISABLE_BROKER 
GO
ALTER DATABASE [INF6150] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [INF6150] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [INF6150] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [INF6150] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [INF6150] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [INF6150] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [INF6150] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [INF6150] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [INF6150] SET  MULTI_USER 
GO
ALTER DATABASE [INF6150] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [INF6150] SET DB_CHAINING OFF 
GO
ALTER DATABASE [INF6150] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [INF6150] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [INF6150] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [INF6150] SET QUERY_STORE = OFF
GO
USE [INF6150]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 5/19/2019 12:36:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[idClient] [int] NOT NULL,
	[nomClient] [varchar](50) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[idClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Etat]    Script Date: 5/19/2019 12:36:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Etat](
	[idEtat] [int] NOT NULL,
	[descEtat] [nchar](15) NOT NULL,
 CONSTRAINT [PK_Etat] PRIMARY KEY CLUSTERED 
(
	[idEtat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 5/19/2019 12:36:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[login] [nchar](10) NULL,
	[password] [nchar](10) NULL,
	[matricule] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 5/19/2019 12:36:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[idProjet] [int] NULL,
	[nomProjet] [nchar](50) NULL,
	[idClient] [int] NULL,
	[idEtat] [int] NULL,
	[dateDebut] [nchar](10) NULL,
	[dateFin] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projet]    Script Date: 5/19/2019 12:36:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projet](
	[idProjet] [int] IDENTITY(1,1) NOT NULL,
	[nomProjet] [nvarchar](50) NULL,
	[idClient] [int] NOT NULL,
	[idEtat] [int] NULL,
	[dateDebut] [date] NULL,
	[dateFin] [date] NULL,
 CONSTRAINT [PK_Projet] PRIMARY KEY CLUSTERED 
(
	[idProjet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 5/19/2019 12:36:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[idTache] [int] NOT NULL,
	[idUser] [nchar](10) NOT NULL,
	[idProjet] [int] NOT NULL,
	[nbrHeuresEstime] [int] NULL,
	[nbrEmployes] [int] NULL,
	[description] [nchar](100) NULL,
	[statut] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/19/2019 12:36:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[idUser] [nchar](10) NULL,
	[prenom] [nchar](50) NULL,
	[nom] [nchar](50) NULL,
	[tauxHoraire] [int] NOT NULL,
	[nbProjets] [int] NULL,
	[role] [nchar](10) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Projet]  WITH CHECK ADD  CONSTRAINT [FK_Projet_Client] FOREIGN KEY([idClient])
REFERENCES [dbo].[Client] ([idClient])
GO
ALTER TABLE [dbo].[Projet] CHECK CONSTRAINT [FK_Projet_Client]
GO
ALTER TABLE [dbo].[Projet]  WITH CHECK ADD  CONSTRAINT [FK_Projet_Etat] FOREIGN KEY([idEtat])
REFERENCES [dbo].[Etat] ([idEtat])
GO
ALTER TABLE [dbo].[Projet] CHECK CONSTRAINT [FK_Projet_Etat]
GO
USE [master]
GO
ALTER DATABASE [INF6150] SET  READ_WRITE 
GO
