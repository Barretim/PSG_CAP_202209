CREATE PROCEDURE SP_Desafio_025
AS
BEGIN
	DECLARE @SobrenomeFinal CHAR(3)
	SET @SobrenomeFinal = 'san'

	DECLARE @Registros INT 
	SELECT @Registros = COUNT(*)
	FROM Funcionario WHERE Sobrenome LIKE '%'+@SobrenomeFinal


	IF(@Registros=0)
	BEGIN
	PRINT ('Não há funcionarios que terminem com essas letras no sobreb') +@SobrenomeFinal
	END
	ELSE
	BEGIN
	SELECT * FROM Funcionario
	WHERE Sobrenome LIKE '%'+@SobrenomeFinal
	ORDER BY Sobrenome
	END
END

DROP PROCEDURE SP_Desafio_025

EXEC dbo.SP_Desafio_025
