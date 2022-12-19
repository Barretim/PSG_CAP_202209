INSERT INTO Estado(Nome,UF)
SELECT m.nome, m.uf
FROM ViajeFacilDB.dbo.estado as m 
INNER JOIN Estado as e ON m.uf = e.UF
GO
