EXEC sp_configure 'show advanced options', 1
RECONFIGURE;
GO

EXEC sp_configure 'ad hoc distributed queries', 1
RECONFIGURE;
GO

USE [API_DPFContext-20190519145831];
GO
INSERT INTO Realises (Compta, OffreId, ChargeId)
SELECT BDD.dbo.Realise2018.Comptablise, Offres.Id , Charges.Id 
FROM BDD.dbo.Realise2018 
INNER JOIN [API_DPFContext-20190519145831].dbo.Offres ON Offre = nom 
INNER JOIN [API_DPFContext-20190519145831].dbo.Charges ON Type_de_charges = Type
GO 