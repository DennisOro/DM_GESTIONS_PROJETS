USE [INF6150]
GO

/****** Object:  View [dbo].[qTaskUserPrj]    Script Date: 2019-05-30 11:49:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[qTaskUserPrj]
AS
SELECT        u.idTache, t.description, p.nomProjet, t.nbrHeuresEstime, u.nbrHeuresTravaillees, t.idEtat, u.matricule, v.login
FROM            dbo.TaskUser AS u INNER JOIN
                         dbo.Task AS t ON u.idTache = t.idTache INNER JOIN
                         dbo.Project AS p ON p.idProjet = t.idProjet INNER JOIN
                         dbo.Login AS v ON u.matricule = v.matricule
WHERE        (t.idEtat < 8)
GO


