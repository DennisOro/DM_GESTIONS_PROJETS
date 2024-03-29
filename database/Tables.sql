USE [INF6150]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 2019-05-20 11:22:25 ******/
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
/****** Object:  Table [dbo].[Etat]    Script Date: 2019-05-20 11:22:25 ******/
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
/****** Object:  Table [dbo].[Login]    Script Date: 2019-05-20 11:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[login] [nchar](15) NOT NULL,
	[password] [nchar](10) NOT NULL,
	[matricule] [nchar](10) NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 2019-05-20 11:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[idProjet] [int] NOT NULL,
	[nomProjet] [nchar](50) NULL,
	[idClient] [int] NULL,
	[idEtat] [int] NULL,
	[dateDebut] [date] NULL,
	[dateFin] [date] NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[idProjet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 2019-05-20 11:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[idTache] [int] NOT NULL,
	[description] [nchar](100) NULL,
	[idProjet] [int] NOT NULL,
	[nbrHeuresEstime] [int] NULL,
	[idEtat] [int] NOT NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[idTache] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskUser]    Script Date: 2019-05-20 11:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskUser](
	[idTache] [int] NOT NULL,
	[matricule] [nchar](10) NOT NULL,
	[nbrHeuresTravaillees] [int] NULL,
	[dateCreation] [datetime] NOT NULL,
 CONSTRAINT [PK_TaskUser] PRIMARY KEY CLUSTERED 
(
	[idTache] ASC,
	[matricule] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2019-05-20 11:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[matricule] [nchar](10) NOT NULL,
	[prenom] [nchar](50) NOT NULL,
	[nom] [nchar](50) NOT NULL,
	[tauxHoraire] [decimal](10, 2) NOT NULL,
	[role] [nchar](20) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[matricule] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TaskUser] ADD  CONSTRAINT [DF_TaskUser_nbrHeuresTravaillees]  DEFAULT ((0)) FOR [nbrHeuresTravaillees]
GO
ALTER TABLE [dbo].[TaskUser] ADD  CONSTRAINT [DF_TaskUser_dateCreation]  DEFAULT (getdate()) FOR [dateCreation]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_tauxHoraire]  DEFAULT ((0)) FOR [tauxHoraire]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Client] FOREIGN KEY([idClient])
REFERENCES [dbo].[Client] ([idClient])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Client]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Etat] FOREIGN KEY([idEtat])
REFERENCES [dbo].[Etat] ([idEtat])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Etat]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Etat] FOREIGN KEY([idEtat])
REFERENCES [dbo].[Etat] ([idEtat])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Etat]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Project] FOREIGN KEY([idProjet])
REFERENCES [dbo].[Project] ([idProjet])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Project]
GO
ALTER TABLE [dbo].[TaskUser]  WITH CHECK ADD  CONSTRAINT [FK_TaskUser_Task] FOREIGN KEY([idTache])
REFERENCES [dbo].[Task] ([idTache])
GO
ALTER TABLE [dbo].[TaskUser] CHECK CONSTRAINT [FK_TaskUser_Task]
GO
ALTER TABLE [dbo].[TaskUser]  WITH CHECK ADD  CONSTRAINT [FK_TaskUser_User] FOREIGN KEY([matricule])
REFERENCES [dbo].[User] ([matricule])
GO
ALTER TABLE [dbo].[TaskUser] CHECK CONSTRAINT [FK_TaskUser_User]
GO
