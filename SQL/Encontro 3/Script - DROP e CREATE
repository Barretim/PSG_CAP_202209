ALTER TABLE Categoria
	--ADD DataInsert DATETIME NOT NULL DEFAULT GETDATE()
	ADD CONSTRAINT DF_DATAINSERT
		DEFAULT GETDATE() FOR DateInsert
GO

DROP TABLE Produto

DROP TABLE Subcategoria

DROP TABLE Categoria
GO

CREATE TABLE Categoria(
    Codigo INT NOT NULL IDENTITY(1,1),
    Descricao VARCHAR(MAX) NOT NULL,
    DataInsert DATETIME NOT NULL,
    CONSTRAINT PK_Categoria PRIMARY KEY(Codigo)
)
GO

CREATE TABLE Subcategoria(
    Codigo INT NOT NULL IDENTITY(1,1),
    CodigoCategoria INT NOT NULL,
    Descricao VARCHAR(MAX) NOT NULL,
    DataInsert DATETIME NOT NULL,
    CONSTRAINT PK_Subcategoria PRIMARY KEY (Codigo),
    CONSTRAINT FK_Subcategoria_Categoria FOREIGN KEY(CodigoCategoria) REFERENCES Categoria(Codigo)
)
GO

CREATE TABLE Produto(
    Codigo INT NOT NULL IDENTITY(1,1),
    CodigoSubcategoria INT NOT NULL,
    CodigoCategoria INT NOT NULL,
    Descricao VARCHAR(MAX) NOT NULL,
    DataInsert DATETIME NOT NULL,
    CONSTRAINT PK_Produto PRIMARY KEY (Codigo),
    CONSTRAINT FK_Produto_Subcategoria FOREIGN KEY (CodigoSubcategoria) REFERENCES Subcategoria (Codigo)
)
GO
