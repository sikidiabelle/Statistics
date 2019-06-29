EXEC sp_configure 'show advanced options', 1
RECONFIGURE;
GO

EXEC sp_configure 'ad hoc distributed queries', 1
RECONFIGURE;
GO

USE [API_DPFContext-20190519145831]
GO

INSERT INTO Charges
SELECT Type_de_charges FROM BDD.dbo.Realise2018 WHERE Type_de_charges != 'NULL'
ORDER BY Type_de_charges
GO
