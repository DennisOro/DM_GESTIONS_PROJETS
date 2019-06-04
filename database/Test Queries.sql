select * from [INF6150].[dbo].[User]

select * from [INF6150].[dbo].[Login]

select * from [INF6150].[dbo].[Task]

select * from [INF6150].[dbo].[Task] where idProjet = 2

select * from [INF6150].[dbo].[qTaskPrj]

select * from [INF6150].[dbo].[TaskUser] 

select * from [INF6150].[dbo].[Project]

select * from [INF6150].[dbo].[Client]

select * from [INF6150].[dbo].[Etat]

select descEtat from [INF6150].[dbo].[Etat] where idEtat = 2


UPDATE [INF6150].[dbo].[Project] SET nomProjet = 'Aggravation continue', dateDebut =  '7/15/2019 12:00:00 AM', dateFin =  '10/30/2019 12:00:00 AM' WHERE idProjet = 3

INSERT INTO [INF6150].[dbo].[Project] values (1,'Aggravation continue                             ',4, 0, '2019-02-02', '2019-08-09')

select role from [INF6150].[dbo].[User] where matricule = 'AAA101'

select top 1 idProjet from [INF6150].[dbo].[Project] order by idProjet desc

INSERT INTO [INF6150].[dbo].[Project] values (4,'',3,2, '','');

INSERT INTO [INF6150].[dbo].[Project] values (4,'New Proj',4, 2, '', '')

delete from [INF6150].[dbo].[Project] where idProjet = 4

select idClient from [INF6150].[dbo].[Client] where nomClient = 'UQAM'

select idEtat from [INF6150].[dbo].[Etat] where descEtat = 'En Cours'

INSERT INTO [INF6150].[dbo].[User] (matricule, prenom, nom, tauxHoraire, role)

VALUES (34, 'Anna', 'Smith', 'CA');

INSERT INTO [INF6150].[dbo].[User] values (bbb,'Alec',asad, 0, '')

INSERT INTO [INF6150].[dbo].[User] (matricule, prenom, nom, tauxHoraire, role)VALUES ('bbb69','Alec','asad', 0, '')

select * from [INF6150].[dbo].[User] where prenom = 'Marc' and nom = 'St-Pierre'

UPDATE [INF6150].[dbo].[User]  SET prenom = 'Marc', nom =  'St-Pierre', tauxHoraire =  25, role =  'Utilisateur' WHERE matricule = 'AAA102'

delete from [INF6150].[dbo].[Project] where idProjet = 4 --3

delete  from [INF6150].[dbo].[Task] where idProjet = 3 and idTache = 15 --2

delete from [INF6150].[dbo].[TaskUser] where idTache = 1 --1

delete from [INF6150].[dbo].[User] where matricule = '33'


select distinct t.idTache, t.description, tp.totHeuresTravaillees, tp.nbrHeuresEstime, e.descEtat, t.idProjet, t.idEtat
from [INF6150].[dbo].[Task] t
join [INF6150].[dbo].[qTaskPrj] tp on t.idTache = tp.idTache and t.idProjet = tp.idProjet
join [INF6150].[dbo].[Etat] e on t.idEtat = e.idEtat
where t.description like 'Analyse des besoins (charte)%' and t.idProjet = 1

update [INF6150].[dbo].[Task] set description = 'descr test2', idProjet = 1, idEtat = 1, nbrHeuresEstime = 29
where idTache = 1 --and idProjet = 1

--update [INF6150].[dbo].[qTaskPrj] set description = 'descr test', nbrHeuresEstime = 29, totHeuresTravaillees = 28
--where idTache = 1 and idProjet = 2


delete from [INF6150].[dbo].[TaskUser] where idTache = 2; 

delete from [INF6150].[dbo].[Task] where idTache = 2

select top 1 idTache from [INF6150].[dbo].[Task] order by idTache desc

INSERT INTO [INF6150].[dbo].[Task] (idTache, description, idProjet, nbrHeuresEstime, idEtat) values()

select idEtat from [INF6150].[dbo].[Etat] where descEtat like 'En attente%'


select distinct t.idTache, t.description, tp.totHeuresTravaillees, tp.nbrHeuresEstime, e.descEtat, t.idProjet, t.idEtat
                                    from [INF6150].[dbo].[Task] t
                                    join [INF6150].[dbo].[qTaskPrj] tp on t.idTache = tp.idTache and t.idProjet = tp.idProjet
                                    join [INF6150].[dbo].[Etat] e on t.idEtat = e.idEtat
									where t.idProjet = 2

delete from [INF6150].[dbo].[TaskUser] where matricule = 'AAA103';
delete from [INF6150].[dbo].[User] where matricule = 'AAA103'








