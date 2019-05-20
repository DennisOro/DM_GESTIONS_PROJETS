

use [INF6150]
go

delete from [INF6150].[dbo].[TaskUser]
delete from [INF6150].[dbo].[Task]
delete from [INF6150].[dbo].[Project]
delete from [INF6150].[dbo].[Login]
delete from [INF6150].[dbo].[User]
delete from [INF6150].[dbo].[Etat]
delete from [INF6150].[dbo].[Client]



insert into [INF6150].[dbo].[Client] (idClient, nomClient) values (1,'Air Canada');
insert into [INF6150].[dbo].[Client] (idClient, nomClient) values (2,'Bombardier');
insert into [INF6150].[dbo].[Client] (idClient, nomClient) values (3,'Revenu Canada');
insert into [INF6150].[dbo].[Client] (idClient, nomClient) values (4,'UQAM');
insert into [INF6150].[dbo].[Client] (idClient, nomClient) values (5,'CGI');

select * from  [INF6150].[dbo].[Etat]

insert into [INF6150].[dbo].[Etat]
select *  from (
select 1 as id, 'En attente' as de union all
select 2, 'En Cours' union all
select 7, 'Annulé' union all
select 8, 'Completé' union all
select 9, 'Eliminé') as tmp

select * from [INF6150].[dbo].[Etat]

insert into [INF6150].[dbo].[User]
select *  from (
select 'AAA101' as mat, 'John' as pre, 'Dugat' as nom, 12.5 as taux, 'Utilisateur' as rol union all
select 'AAA102' , 'Marc' as pre, 'St-Pierre' as nom, 25 as taux, 'Gestionnaire' union all
select 'AAA103' , 'Andrew' , 'Li' , 12.5 , 'Utilisateur'
) as tmp

insert into [INF6150].[dbo].[Login]
select *  from (
select 'uqam' as login, '123' as pass, 'AAA101' as nmat union all
select 'marc' as login, '111' as pass, 'AAA102' as nmat union all
select 'ali' as login, '222' as pass, 'AAA103' as nmat

) as tmp

-- select * from [INF6150].[dbo].[Login]

insert into [INF6150].[dbo].[Project]
select *  from (
select 1 as np, 'ERP RRHH et Finances' as nom, 5 as cli, 1 as etat, '2019-06-01' as dd, '2019-08-30' as df union all
select 2 as np, 'Prototype du CSeries' as nom, 2 as cli, 1 as etat, '2019-07-01' as dd, '2019-12-31' as df union all
select 3 as np, 'Amélioration continue' as nom, 3 as cli, 1 as etat, '2019-07-15' as dd, '2019-10-30' as df 

) as tmp

select * from [INF6150].[dbo].[Project]

insert into [INF6150].[dbo].[Task] 
select *  from (
select 1 as id, 'Analyse des besoins (charte)' as nom, 1 as ip, 50 as nh, 1 as etat union all
select 2 as id, 'Diagrammes du projet' as nom, 1 as ip, 20 as nh, 1 as etat union all
select 3 as id, 'Creations de la BD' as nom, 1 as ip, 15 as nh, 1 as etat union all
select 4 as id, 'Creations des interfaces' as nom, 1 as ip, 30 as nh, 1 as etat union all
select 5 as id, 'Backend de RRHH' as nom, 1 as ip, 200 as nh, 1 as etat union all
select 6 as id, 'Backend de Finances' as nom, 1 as ip, 210 as nh, 1 as etat union all
select 7 as id, 'FrontEnd du projet' as nom, 1 as ip, 350 as nh, 1 as etat union all

select 8 as id, 'Analyse des besoins (charte)' as nom, 2 as ip, 100 as nh, 1 as etat union all
select 9 as id, 'Diagrammes des moteurs' as nom, 2 as ip, 60 as nh, 1 as etat union all
select 10 as id, 'Dessin de la structure' as nom, 2 as ip, 50 as nh, 1 as etat union all
select 11 as id, 'Assemblage de pieces' as nom, 2 as ip, 350 as nh, 1 as etat union all
select 12 as id, 'Cablage interieur' as nom, 2 as ip, 100 as nh, 1 as etat union all
select 13 as id, 'Peinture' as nom, 2 as ip, 150 as nh, 1 as etat union all
select 14 as id, 'Rembourrage' as nom, 2 as ip, 120 as nh, 1 as etat union all

select 15 as id, 'Proposition initiale (Document)' as nom, 3 as ip, 30 as nh, 1 as etat union all
select 16 as id, 'Reorganisation des rôles' as nom, 3 as ip, 80 as nh, 1 as etat union all
select 17 as id, 'Proposition finale (Document)' as nom, 3 as ip, 40 as nh, 1 as etat 
) as tmp


insert into [INF6150].[dbo].[TaskUser](idTache, matricule, nbrHeuresTravaillees)
select *  from (
select 1 as id,'AAA101' as mat, 10 as nh union all
select 2 as id,'AAA101' as mat, 15 as nh union all
select 3 as id,'AAA101' as mat, 22 as nh union all
select 4 as id,'AAA101' as mat, 30 as nh union all
select 5 as id,'AAA101' as mat, 11 as nh union all
select 10 as id,'AAA101' as mat, 12 as nh union all
select 11 as id,'AAA101' as mat, 14 as nh union all
select 15 as id,'AAA101' as mat, 21 as nh union all

select 9 as id,'AAA102' as mat, 5 as nh union all
select 7 as id,'AAA102' as mat, 7 as nh union all
select 3 as id,'AAA102' as mat, 22 as nh union all
select 4 as id,'AAA102' as mat, 20 as nh union all
select 5 as id,'AAA102' as mat, 14 as nh union all
select 10 as id,'AAA102' as mat, 11 as nh union all
select 14 as id,'AAA102' as mat, 14 as nh union all
select 16 as id,'AAA102' as mat, 22 as nh union all

select 6 as id,'AAA103' as mat, 5 as nh union all
select 8 as id,'AAA103' as mat, 7 as nh union all
select 12 as id,'AAA103' as mat, 22 as nh union all
select 13 as id,'AAA103' as mat, 20 as nh union all
select 5 as id,'AAA103' as mat, 14 as nh union all
select 2 as id,'AAA103' as mat, 11 as nh union all
select 1 as id,'AAA103' as mat, 14 as nh union all
select 17 as id,'AAA103' as mat, 22 as nh 

) as tmp
