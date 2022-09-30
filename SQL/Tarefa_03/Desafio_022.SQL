
CREATE PROCEDURE SP_Desafio_022
AS
BEGIN
	DECLARE @DataAniversario DATETIME
	SET @DataAniversario = '1960'

	DECLARE @Registros INT 
	SELECT @Registros = COUNT(*)
	FROM Funcionario WHERE DataNascimento LIKE @DataAniversario


	IF(@Registros=0)
	BEGIN
	PRINT ('Não há funcionarios que façam aniversario nessa data') + @DataAniversario
	END
	ELSE
	BEGIN
	SELECT * FROM Funcionario
	WHERE DataNascimento LIKE @DataAniversario
	ORDER BY DataNascimento
	END
END

DROP PROCEDURE SP_Desafio_022

EXEC dbo.SP_Desafio_022
