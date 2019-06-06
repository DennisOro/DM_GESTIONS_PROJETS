USE [INF6150]
GO

/****** Object:  Table [dbo].[TaskUserHrs]    Script Date: 2019-06-06 19:07:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TaskUserHrs](
	[idHrs] [int] IDENTITY(1,1) NOT NULL,
	[idTache] [int] NOT NULL,
	[matricule] [nchar](10) NOT NULL,
	[dateCreation] [datetime] NOT NULL,
	[nbrHeure] [int] NOT NULL,
 CONSTRAINT [PK_TaskUserHrs] PRIMARY KEY CLUSTERED 
(
	[idHrs] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TaskUserHrs] ADD  CONSTRAINT [DF_TaskUserHrs_dateCreation]  DEFAULT (getdate()) FOR [dateCreation]
GO

ALTER TABLE [dbo].[TaskUserHrs] ADD  CONSTRAINT [DF_TaskUserHrs_nbrHeure]  DEFAULT ((0)) FOR [nbrHeure]
GO

ALTER TABLE [dbo].[TaskUserHrs]  WITH CHECK ADD  CONSTRAINT [FK_TaskUserHrs_TaskUser] FOREIGN KEY([idTache], [matricule])
REFERENCES [dbo].[TaskUser] ([idTache], [matricule])
GO

ALTER TABLE [dbo].[TaskUserHrs] CHECK CONSTRAINT [FK_TaskUserHrs_TaskUser]
GO


