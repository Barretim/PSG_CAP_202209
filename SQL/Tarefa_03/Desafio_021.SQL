CREATE PROCEDURE SP_Desafio_021
AS
BEGIN
	DECLARE @LetrasIniciais CHAR(3)
	SET @LetrasIniciais = 'Mar'

	DECLARE @Registros INT 
	SELECT @Registros = COUNT(*)
	FROM Funcionario WHERE Nome LIKE @LetrasIniciais+'%'


	IF(@Registros=0)
	BEGIN
	PRINT ('Não há funcionarios que inicie com') +@LetrasIniciais
	END
	ELSE
	BEGIN
	SELECT * FROM Funcionario
	WHERE Nome LIKE @LetrasIniciais+'%'
	ORDER BY Nome
	END
END

DROP PROCEDURE SP_Desafio_021

EXEC dbo.SP_Desafio_021
