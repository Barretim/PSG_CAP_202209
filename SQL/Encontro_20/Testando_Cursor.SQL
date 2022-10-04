--Criar um subconjunto de Funcionário, para Sexo = 'F' e Sobrenome começando com 'MID'.

--Para esse subconjunto, criar Parcelamento via Boleto, até 10x.
--Obs.:
--Criar uma tabela de carnês Física com a estrutura:
--ParcelaId BIGINT
--FuncionarioId BIGINT
--Valor DECIMAL

CREATE TABLE Parcelamento(
	ParcelaId BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	FuncionarioId BIGINT NOT NULL,
	ParcelaNumero INT NOT NULL,
	Valor DECIMAL NOT NULL
)

DECLARE @ParcelaMax INT 
	SET @ParcelaMax = 10

DECLARE @QntdParcelas INT 

DECLARE @Valor DECIMAL
	SET @Valor = 3000

DECLARE @ParcelaInicial INT
	SET @ParcelaInicial = 1

DECLARE @ValorParcela DECIMAL


DECLARE @FuncId BIGINT
DECLARE CursorFunc CURSOR
	FOR SELECT FuncionarioId FROM Funcionario WHERE Sexo = 'F' AND Sobrenome LIKE 'MID%'
OPEN CursorFunc
FETCH NEXT FROM CursorFunc INTO @FuncId

WHILE (@@FETCH_STATUS = 0)
BEGIN
	SET @QntdParcelas = FLOOR(RAND() * (@ParcelaMax + 1)+1)

	WHILE(@QntdParcelas = 0)
	BEGIN
		SET @QntdParcelas = FLOOR(RAND() * (@ParcelaMax + 1)+1)
	END

	WHILE(@ParcelaInicial < @QntdParcelas)
	BEGIN
		SET @ValorParcela = (@ParcelaInicial * @Valor)

		INSERT INTO Parcelamento (FuncionarioId , ParcelaNumero, Valor)
			SELECT 
				FuncionarioId,
				@ParcelaInicial,
				@ValorParcela
			FROM Funcionario
			WHERE (FuncionarioId = @FuncId)

		SET @ParcelaInicial = @ParcelaInicial + 1
	END
	SET @QntdParcelas = 0 
	SET @ParcelaInicial = 1
	FETCH NEXT FROM CursorFunc INTO @FuncId
END
CLOSE CursorFunc
DEALLOCATE CursorFunc
SELECT * FROM Parcelamento

GO

