UPDATE Cliente 
SET ativo = 0, DataAlteracao = GETDATE()
WHERE Codigo = 6
GO

INSERT INTO Cliente(Nome,Documento,Telefone,Email,Endereço)
VALUES 
('Brrabas','456','987654321','Lucas@teste.com','Rua x, n.11')
GO

UPDATE Cliente 
SET ativo = 0, DataAlteracao = GETDATE(), DataExclusao = GETDATE ()
WHERE Codigo = 9
GO

UPDATE Cliente 
SET ativo = 1, DataAlteracao = GETDATE(), DataExclusao = NULL
WHERE Codigo = 9
GO 
