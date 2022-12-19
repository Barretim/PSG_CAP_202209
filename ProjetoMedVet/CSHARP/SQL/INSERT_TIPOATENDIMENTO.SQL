INSERT INTO TipoAtendimento(Sigla, Descricao)
SELECT m.Sigla, m.Descricao
FROM MedVetDB.dbo.TipoPessoa as m
