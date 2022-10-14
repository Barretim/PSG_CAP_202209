CREATE PROCEDURE SP_Questao_06
@Municipio INT, @Ano INT
AS
BEGIN
	SELECT * FROM RAW_Aquicultura_Brasil_Municipios
	WHERE Id_Municipio = @Municipio AND Ano = @Ano
END
GO

--EXECUÇÃO
EXEC SP_Questao_06 
GO
