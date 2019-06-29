EXEC sp_configure 'show advanced options', 1
RECONFIGURE;
GO

EXEC sp_configure 'ad hoc distributed queries', 1
RECONFIGURE;
GO

USE [API_DPFContext-20190519145831];
GO
INSERT INTO Offres
SELECT DISTINCT Definition_Projet FROM BDD.dbo.Trajectoire2019 WHERE Definition_Projet != 'NULL'
ORDER BY Definition_Projet
GO
INSERT INTO Annees (An, Courant) Values ('2018',0), ('2019',1),('2020',0), ('2021',0), ('2022',0), ('2023',0)
GO
INSERT INTO Charges
SELECT DISTINCT Type_de_charges FROM BDD.dbo.Trajectoire2019 WHERE Type_de_charges != 'NULL'
ORDER BY Type_de_charges
GO
INSERT INTO Commentaires
SELECT Commentaire, Id FROM BDD.dbo.Trajectoire2019 INNER JOIN [API_DPFContext-20190519145831].dbo.Charges ON BDD.dbo.Trajectoire2019.Type_de_charges = [API_DPFContext-20190519145831].dbo.Charges.Type
GO
INSERT INTO Details
SELECT F4,Id FROM BDD.dbo.Realise2018 INNER JOIN [API_DPFContext-20190519145831].dbo.Charges ON BDD.dbo.Realise2018.Type_de_charges = [API_DPFContext-20190519145831].dbo.Charges.Type
GO
INSERT INTO Mois(Mois) VALUES (1),(2),(3),(4),(5),(6),(7),(8),(9),(10),(11),(12)
GO
INSERT INTO Periodes
SELECT [API_DPFContext-20190519145831].dbo.Mois.Mois,[API_DPFContext-20190519145831].dbo.Annees.Id FROM Mois CROSS JOIN Annees
GO
INSERT INTO Trajectoires (Valeur, CommentaireId, OffreId, AnneeId)
SELECT Trajectoire, Commentaires.Id, Offres.Id, Annees.Id 
FROM BDD.dbo.Trajectoire2019 
INNER JOIN [API_DPFContext-20190519145831].dbo.Commentaires ON BDD.dbo.Trajectoire2019.Commentaire = [API_DPFContext-20190519145831].dbo.Commentaires.Comment
INNER JOIN [API_DPFContext-20190519145831].dbo.Offres ON Definition_Projet = nom 
INNER JOIN [API_DPFContext-20190519145831].dbo.Annees ON Annees.An = 2019
GO 
INSERT INTO Realises (Compta, OffreId, ChargeId, PeriodeId)
SELECT BDD.dbo.Realise2018.Comptablise, Offres.Id , Charges.Id, Periodes.Id
FROM BDD.dbo.Realise2018 
INNER JOIN [API_DPFContext-20190519145831].dbo.Offres ON Offre = nom 
INNER JOIN [API_DPFContext-20190519145831].dbo.Charges ON Type_de_charges = Type
INNER JOIN [API_DPFContext-20190519145831].dbo.Periodes ON Periodes.AnneeId = 1 AND Periodes.Mois = SUBSTRING(Realise2018.Periode, 6,2)
GO 
INSERT INTO [API_DPFContext-20190519145831].dbo.Dotations
SELECT Annees.Id, Offres.Id, BDD.dbo.Dotations.Dotations_2018
FROM BDD.dbo.Dotations
INNER JOIN [API_DPFContext-20190519145831].dbo.Offres ON BDD.dbo.Dotations.Service = Offres.nom
INNER JOIN [API_DPFContext-20190519145831].dbo.Annees ON Annees.An = 2018
GO
INSERT INTO [API_DPFContext-20190519145831].dbo.Dotations
SELECT Annees.Id, Offres.Id, BDD.dbo.Dotations.Dotations_2019
FROM BDD.dbo.Dotations
INNER JOIN [API_DPFContext-20190519145831].dbo.Offres ON BDD.dbo.Dotations.Service = Offres.nom
INNER JOIN [API_DPFContext-20190519145831].dbo.Annees ON Annees.An = 2019
GO
INSERT INTO [API_DPFContext-20190519145831].dbo.Dotations
SELECT Annees.Id, Offres.Id, BDD.dbo.Dotations.Dotations_2020
FROM BDD.dbo.Dotations
INNER JOIN [API_DPFContext-20190519145831].dbo.Offres ON BDD.dbo.Dotations.Service = Offres.nom
INNER JOIN [API_DPFContext-20190519145831].dbo.Annees ON Annees.An = 2020
GO
INSERT INTO [API_DPFContext-20190519145831].dbo.Dotations
SELECT Annees.Id, Offres.Id, BDD.dbo.Dotations.Dotations_2021
FROM BDD.dbo.Dotations
INNER JOIN [API_DPFContext-20190519145831].dbo.Offres ON BDD.dbo.Dotations.Service = Offres.nom
INNER JOIN [API_DPFContext-20190519145831].dbo.Annees ON Annees.An = 2021
GO
INSERT INTO [API_DPFContext-20190519145831].dbo.Dotations
SELECT Annees.Id, Offres.Id, BDD.dbo.Dotations.Dotations_2022
FROM BDD.dbo.Dotations
INNER JOIN [API_DPFContext-20190519145831].dbo.Offres ON BDD.dbo.Dotations.Service = Offres.nom
INNER JOIN [API_DPFContext-20190519145831].dbo.Annees ON Annees.An = 2022
GO
INSERT INTO [API_DPFContext-20190519145831].dbo.Dotations
SELECT Annees.Id, Offres.Id, BDD.dbo.Dotations.Dotations_2023
FROM BDD.dbo.Dotations
INNER JOIN [API_DPFContext-20190519145831].dbo.Offres ON BDD.dbo.Dotations.Service = Offres.nom
INNER JOIN [API_DPFContext-20190519145831].dbo.Annees ON Annees.An = 2023
GO
