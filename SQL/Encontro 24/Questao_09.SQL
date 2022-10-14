CREATE PROCEDURE SP_Questao_09
@IdTipo INT, @IdMunicipio INT, @Ano INT
AS
BEGIN
	SELECT Aquicultura.IdAquicultura, 
		   Aquicultura.Ano, 
		   Aquicultura.IdMunicipio, 
		   tipo.IdTipoAquicultura,
		   Tipo.DescricaoTipoAquicultura, 
		   Aquicultura.Producao, 
		   Aquicultura.ValorProducao, 
		   Aquicultura.ProporcaoValorProducao,
		   Aquicultura.Moeda

	FROM Aquicultura 
	INNER JOIN TipoAquicultura AS Tipo ON Aquicultura.IdTipoAquicultura = Tipo.IdTipoAquicultura
	WHERE tipo.IdTipoAquicultura = @IdTipo AND IdMunicipio = @IdMunicipio AND Ano = @Ano AND Aquicultura.Producao IS NOT NULL
END
GO

--EXECUÇÃO
EXEC SP_Questao_09 
GO
