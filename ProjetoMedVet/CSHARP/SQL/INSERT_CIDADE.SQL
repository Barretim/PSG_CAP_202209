INSERT INTO Cidade(Nome, CodigoIBGE7, CodigoEstado)
SELECT m.nome, m.codigo_ibge7, m.id_estado
FROM ViajeFacilDB.dbo.cidade as m
