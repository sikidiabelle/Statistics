EXEC sp_configure 'show advanced options', 1
RECONFIGURE;
GO

EXEC sp_configure 'ad hoc distributed queries', 1
RECONFIGURE;
GO

USE BDD;
GO
SELECT * INTO Trajectoire2019
FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0',
    'Excel 12.0; Database=chemin', [Trajectoire_2019$]);
GO
SELECT * INTO Realise2018
FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0',
    'Excel 12.0; Database=chemin', [Realise_2018$]);
GO
SELECT * INTO Dotations
FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0',
    'Excel 12.0; Database=chemin', [Dotations$]);
GO