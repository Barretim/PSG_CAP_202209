CREATE PROCEDURE SP_Questao_08
@IdMunicipio INT, @Ano INT
AS
BEGIN
	SELECT * FROM VW_Dados_Aquicultura
	WHERE IdMunicipio = @IdMunicipio AND Ano = @Ano AND Producao IS NOT NULL
END
GO

--EXECUÇÃO
EXEC SP_Questao_08 
GO
