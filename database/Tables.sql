USE [INF6150]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 2019-05-18 15:47:17 ******/
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
/****** Object:  Table [dbo].[Etat]    Script Date: 2019-05-18 15:47:17 ******/
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
/****** Object:  Table [dbo].[Projet]    Script Date: 2019-05-18 15:47:17 ******/
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
/****** Object:  Table [dbo].[Tache]    Script Date: 2019-05-18 15:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tache](
	[idTache] [int] NOT NULL,
	[nomTache] [nvarchar](50) NOT NULL,
	[idProjet] [int] NOT NULL,
	[idEtat] [int] NOT NULL,
	[nbreHeuresEstimes] [int] NOT NULL,
 CONSTRAINT [PK_Tache] PRIMARY KEY CLUSTERED 
(
	[idTache] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utilisateur]    Script Date: 2019-05-18 15:47:18 ******/
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
/****** Object:  Table [dbo].[Utilisateur-Tache]    Script Date: 2019-05-18 15:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilisateur-Tache](
	[idUtilisateur] [int] NOT NULL,
	[idTache] [int] NOT NULL,
	[nbreHeuresTravailles] [int] NOT NULL,
	[dateCreation] [datetime] NOT NULL,
 CONSTRAINT [PK_Utilisateur-Tache] PRIMARY KEY CLUSTERED 
(
	[idUtilisateur] ASC,
	[idTache] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tache] ADD  CONSTRAINT [DF_Tache_nbreHeuresEstimes]  DEFAULT ((0)) FOR [nbreHeuresEstimes]
GO
ALTER TABLE [dbo].[Utilisateur-Tache] ADD  CONSTRAINT [DF_Utilisateur-Tache_nbreHeuresTravailles]  DEFAULT ((0)) FOR [nbreHeuresTravailles]
GO
ALTER TABLE [dbo].[Utilisateur-Tache] ADD  CONSTRAINT [DF_Utilisateur-Tache_dateCreation]  DEFAULT (getdate()) FOR [dateCreation]
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
ALTER TABLE [dbo].[Tache]  WITH CHECK ADD  CONSTRAINT [FK_Tache_Etat] FOREIGN KEY([idEtat])
REFERENCES [dbo].[Etat] ([idEtat])
GO
ALTER TABLE [dbo].[Tache] CHECK CONSTRAINT [FK_Tache_Etat]
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
