CREATE VIEW [dbo].[qTaskPrj]
AS
SELECT        t.idProjet, t.idTache, t.description, t.nbrHeuresEstime, SUM(u.nbrHeuresTravaillees) AS totHeuresTravaillees, t.idEtat, e.descEtat
FROM            dbo.Task AS t INNER JOIN
                        dbo.TaskUser AS u ON u.idTache = t.idTache INNER JOIN
                        dbo.Etat AS e ON e.idEtat = t.idEtat
GROUP BY t.idProjet, t.idTache, t.description, t.nbrHeuresEstime, t.idEtat, e.descEtat
GO