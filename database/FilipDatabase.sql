USE [master]
GO
/****** Object:  Database [INF6150FK]    Script Date: 2019-05-19 3:17:51 PM ******/
CREATE DATABASE [INF6150FK]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'INF6150FK', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\INF6150FK.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'INF6150FK_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\INF6150FK_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [INF6150FK] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [INF6150FK].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [INF6150FK] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [INF6150FK] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [INF6150FK] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [INF6150FK] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [INF6150FK] SET ARITHABORT OFF 
GO
ALTER DATABASE [INF6150FK] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [INF6150FK] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [INF6150FK] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [INF6150FK] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [INF6150FK] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [INF6150FK] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [INF6150FK] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [INF6150FK] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [INF6150FK] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [INF6150FK] SET  DISABLE_BROKER 
GO
ALTER DATABASE [INF6150FK] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [INF6150FK] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [INF6150FK] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [INF6150FK] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [INF6150FK] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [INF6150FK] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [INF6150FK] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [INF6150FK] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [INF6150FK] SET  MULTI_USER 
GO
ALTER DATABASE [INF6150FK] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [INF6150FK] SET DB_CHAINING OFF 
GO
ALTER DATABASE [INF6150FK] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [INF6150FK] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [INF6150FK] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [INF6150FK] SET QUERY_STORE = OFF
GO
USE [INF6150FK]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 2019-05-19 3:17:52 PM ******/
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
/****** Object:  Table [dbo].[Etat]    Script Date: 2019-05-19 3:17:52 PM ******/
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
/****** Object:  Table [dbo].[Login]    Script Date: 2019-05-19 3:17:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[login] [nvarchar](max) NULL,
	[password] [nvarchar](max) NULL,
	[matricule] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 2019-05-19 3:17:52 PM ******/
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
/****** Object:  Table [dbo].[Projet]    Script Date: 2019-05-19 3:17:53 PM ******/
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
/****** Object:  Table [dbo].[Task]    Script Date: 2019-05-19 3:17:53 PM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 2019-05-19 3:17:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[idUser] [nvarchar](max) NULL,
	[prenom] [nvarchar](max) NULL,
	[nom] [nvarchar](max) NULL,
	[tauxHoraire] [int] NOT NULL,
	[nbProjets] [int] NULL,
	[role] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
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
/****** Object:  StoredProcedure [dbo].[spCreerEmploye]    Script Date: 2019-05-19 3:17:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spCreerEmploye]
@login  nvarchar(50),
@password nvarchar(50),
@idUser nvarchar(50),
@prenom nvarchar(50),
@nom nvarchar(50),
@role nvarchar(50),
@tauxHoraire int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	  insert into Login(login, password, matricule)
      values(@login , HASHBYTES('SHA2_512',@password), @idUser) 

	   insert into [User] (idUser, prenom, nom, tauxHoraire, role)
	   values(@idUser, @prenom, @nom, @tauxHoraire, @role)

END
GO
USE [master]
GO
ALTER DATABASE [INF6150FK] SET  READ_WRITE 
GO
