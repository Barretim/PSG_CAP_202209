CREATE PROCEDURE SP_Desafio_023
AS
BEGIN
	DECLARE @SexoFuncionario CHAR(1)
	SET @SexoFuncionario = 'M'

	DECLARE @Registros INT 
	SELECT @Registros = COUNT(*)
	FROM Funcionario WHERE Sexo LIKE @SexoFuncionario

	BEGIN
	SELECT * FROM Funcionario
	WHERE Sexo LIKE @SexoFuncionario
	ORDER BY Sexo
	END
END

DROP PROCEDURE SP_Desafio_023

EXEC dbo.SP_Desafio_023
