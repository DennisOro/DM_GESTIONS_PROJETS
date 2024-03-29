USE [master]
GO
/****** Object:  Database [INF6150]    Script Date: 2019-05-15 1:32:51 PM ******/
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
/****** Object:  Table [dbo].[Client]    Script Date: 2019-05-15 1:32:52 PM ******/
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
/****** Object:  Table [dbo].[Projet]    Script Date: 2019-05-15 1:32:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projet](
	[idProjet] [int] IDENTITY(1,1) NOT NULL,
	[nomProjet] [nvarchar](50) NULL,
	[idClient] [int] NOT NULL,
	[statut] [nvarchar](50) NULL,
	[dateDebut] [date] NULL,
	[dateFin] [date] NULL,
 CONSTRAINT [PK_Projet] PRIMARY KEY CLUSTERED 
(
	[idProjet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tache]    Script Date: 2019-05-15 1:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tache](
	[idTache] [int] NOT NULL,
	[nomTache] [nvarchar](50) NULL,
	[idProjet] [int] NULL,
	[nbreHeuresTravailles] [nchar](10) NULL,
 CONSTRAINT [PK_Tache] PRIMARY KEY CLUSTERED 
(
	[idTache] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utilisateur]    Script Date: 2019-05-15 1:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilisateur](
	[matricule] [int] IDENTITY(1,1) NOT NULL,
	[nomLogin] [nvarchar](50) NULL,
	[hashedPassword] [binary](50) NOT NULL,
	[nom] [nvarchar](50) NULL,
	[prénom] [nvarchar](50) NULL,
	[dateEmbauche] [date] NULL,
	[dateNaissance] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[typeUtilisateur] [nvarchar](50) NULL,
 CONSTRAINT [PK_Utilisateur] PRIMARY KEY CLUSTERED 
(
	[matricule] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utilisateur-Tache]    Script Date: 2019-05-15 1:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilisateur-Tache](
	[idUtilisateur] [int] NOT NULL,
	[idTache] [int] NOT NULL,
 CONSTRAINT [PK_Utilisateur-Tache] PRIMARY KEY CLUSTERED 
(
	[idUtilisateur] ASC,
	[idTache] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Projet]  WITH CHECK ADD  CONSTRAINT [FK_Projet_Client] FOREIGN KEY([idClient])
REFERENCES [dbo].[Client] ([idClient])
GO
ALTER TABLE [dbo].[Projet] CHECK CONSTRAINT [FK_Projet_Client]
GO
ALTER TABLE [dbo].[Tache]  WITH CHECK ADD  CONSTRAINT [FK_Tache_Projet] FOREIGN KEY([idProjet])
REFERENCES [dbo].[Projet] ([idProjet])
GO
ALTER TABLE [dbo].[Tache] CHECK CONSTRAINT [FK_Tache_Projet]
GO
ALTER TABLE [dbo].[Utilisateur-Tache]  WITH CHECK ADD  CONSTRAINT [FK_Utilisateur-Tache_Tache] FOREIGN KEY([idTache])
REFERENCES [dbo].[Tache] ([idTache])
GO
ALTER TABLE [dbo].[Utilisateur-Tache] CHECK CONSTRAINT [FK_Utilisateur-Tache_Tache]
GO
ALTER TABLE [dbo].[Utilisateur-Tache]  WITH CHECK ADD  CONSTRAINT [FK_Utilisateur-Tache_Utilisateur] FOREIGN KEY([idUtilisateur])
REFERENCES [dbo].[Utilisateur] ([matricule])
GO
ALTER TABLE [dbo].[Utilisateur-Tache] CHECK CONSTRAINT [FK_Utilisateur-Tache_Utilisateur]
GO
/****** Object:  StoredProcedure [dbo].[spAjoutHeures]    Script Date: 2019-05-15 1:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[spAjoutHeures]
@idTache int,
@idUtilisateur int,
@heures float
as
Begin

UPDATE Tache
Set nbreHeuresTravailles = @heures 
where idTache = @idTache AND
idUtilisateur = @idUtilisateur

End
GO
/****** Object:  StoredProcedure [dbo].[spConnectionUser]    Script Date: 2019-05-15 1:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spConnectionUser]
@nomLogin nvarchar(50),
@password nvarchar(50)
AS
BEGIN

SELECT nomLogin, hashedPassword
from Utilisateur
where nomLogin = @nomLogin and
hashedPassword = @password

END
GO
/****** Object:  StoredProcedure [dbo].[spCreerProjet]    Script Date: 2019-05-15 1:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[spCreerProjet]
@nomProjet varchar(50)
as
Begin

INSERT INTO Projet(nomProjet,statut, dateDebut)
values(@nomProjet, 'actif', getdate()) 

End
GO
/****** Object:  StoredProcedure [dbo].[spCreerUsager]    Script Date: 2019-05-15 1:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[spCreerUsager]
@login nvarchar(50),
@password binary(50),
@nom  nvarchar(50),
@prenom nvarchar(50),
@messageReponse NVARCHAR(250) output
as
Begin

 BEGIN TRY

   insert into Utilisateur(nomLogin,hashedPassword, nom, prénom)
   values(@login, HASHBYTES('SHA2_512',@password), @nom, @prenom) 

   SET @messageReponse = 'succes'
end try
begin catch
   SET @messageReponse= ERROR_MESSAGE()
   END CATCH

End
GO
USE [master]
GO
ALTER DATABASE [INF6150] SET  READ_WRITE 
GO
