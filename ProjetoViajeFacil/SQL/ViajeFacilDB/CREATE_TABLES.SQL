CREATE DATABASE ViajeFacilDB


CREATE TABLE pais(
	id_pais BIGINT NOT NULL IDENTITY(1,1),
	nome VARCHAR(100) NOT NULL,
	CONSTRAINT PK_pais PRIMARY KEY (id_pais)
)
GO

CREATE TABLE regiao (
	id_regiao BIGINT NOT NULL IDENTITY(1,1),
	nome VARCHAR(100) NOT NULL,
	id_pais BIGINT NOT NULL,
	CONSTRAINT PK_regiao PRIMARY KEY (id_regiao),
	CONSTRAINT FK_regiao_pais FOREIGN KEY (id_pais) REFERENCES pais(id_pais)
) 
GO

CREATE TABLE estado (
	id_estado BIGINT NOT NULL IDENTITY(1,1),
	nome VARCHAR(100) NOT NULL,
	uf VARCHAR(2) NOT NULL,
	id_regiao BIGINT NOT NULL,
	codigouf BIGINT NULL,
	CONSTRAINT PK_estado PRIMARY KEY (id_estado),
	CONSTRAINT FK_estado_regiao FOREIGN KEY (id_regiao) REFERENCES regiao(id_regiao)
) 
GO

CREATE TABLE cidade (
	id_cidade BIGINT NOT NULL IDENTITY(1,1),
	nome VARCHAR(100) NOT NULL,
	codigo_ibge7 BIGINT NOT NULL,
	uf VARCHAR(2) NOT NULL,
	id_estado BIGINT NOT NULL,
	CONSTRAINT PK_cidade PRIMARY KEY (id_cidade),
	CONSTRAINT FK_cidade_estado FOREIGN KEY (id_estado) REFERENCES estado(id_estado)
) 
GO

CREATE TABLE endereco (
	id_endereco BIGINT NOT NULL IDENTITY(1,1),
	rua VARCHAR(100) NOT NULL,
	numero INT NOT NULL,
	complemento VARCHAR(255) NULL,
	bairro VARCHAR(100) NOT NULL,
	cep VARCHAR(9) NOT NULL,
	id_cidade BIGINT NOT NULL,
	CONSTRAINT PK_endereco PRIMARY KEY (id_endereco),
	CONSTRAINT FK_endereco_cidade FOREIGN KEY (id_cidade) REFERENCES cidade(id_cidade)
) 
GO

CREATE TABLE instituicao (
	id_instituicao BIGINT NOT NULL IDENTITY(1,1),
	nome VARCHAR(100) NOT NULL,
	telefone VARCHAR(20) NOT NULL,
	id_endereco BIGINT NOT NULL,
	CONSTRAINT PK_instituicao PRIMARY KEY (id_instituicao),
	CONSTRAINT FK_instituicao_endereco FOREIGN KEY (id_endereco) REFERENCES endereco(id_endereco)
) 
GO

CREATE TABLE tipo_usuario (
	id_tipo_usuario BIGINT NOT NULL IDENTITY(1,1),
	descricao VARCHAR(255) NOT NULL,
	CONSTRAINT PK_tipo_usuario PRIMARY KEY (id_tipo_usuario)
) 
GO

CREATE TABLE usuario (
	id_usuario BIGINT NOT NULL IDENTITY(1,1),
	nome VARCHAR(100) NOT NULL,
	email VARCHAR(50) NOT NULL,
	cpf VARCHAR(50) NULL,
	telefone VARCHAR(20) NOT NULL,
	[login] VARCHAR(50) NOT NULL,
	senha VARCHAR(255) NOT NULL,
	id_endereco BIGINT NOT NULL,
	id_tipo_usuario BIGINT NOT NULL,
	id_instituicao BIGINT NOT NULL,
	CONSTRAINT PK_usuario PRIMARY KEY (id_usuario),
	CONSTRAINT FK_usuario_endereco FOREIGN KEY (id_endereco) REFERENCES endereco(id_endereco),
	CONSTRAINT FK_usuario_instituicao FOREIGN KEY (id_instituicao) REFERENCES instituicao(id_instituicao)
) 
GO

CREATE TABLE rota (
	id_rota BIGINT NOT NULL IDENTITY(1,1),
	ponto_inicial VARCHAR(50) NOT NULL,
	pnyo_final VARCHAR(255) NOT NULL,
	CONSTRAINT PK_rota PRIMARY KEY (id_rota),
) 
GO

CREATE TABLE ponto_parada (
	id_ponto_parada BIGINT NOT NULL IDENTITY(1,1),
	descricao VARCHAR(255) NOT NULL,
	latitude VARCHAR(50) NOT NULL,
	longitude VARCHAR(50) NULL,
	id_rota BIGINT NOT NULL,
	CONSTRAINT PK_ponto_parada PRIMARY KEY (id_ponto_parada),
	CONSTRAINT FK_ponto_parada_rota FOREIGN KEY (id_rota) REFERENCES rota(id_rota)
) 
GO

CREATE TABLE evento (
	id_evento BIGINT NOT NULL IDENTITY(1,1),
	titulo VARCHAR(255) NOT NULL,
	decricao VARCHAR(255) NOT NULL,
	data_ida DATE NOT NULL,
	data_volta DATE NOT NULL,
	id_instituicao BIGINT NOT NULL,
	id_rota_ida BIGINT NOT NULL,
	id_rota_volta BIGINT NOT NULL,
	id_usuario_responsavel BIGINT NOT NULL,
	CONSTRAINT PK_evento PRIMARY KEY (id_evento),
	CONSTRAINT FK_evento_instituicao FOREIGN KEY (id_instituicao) REFERENCES instituicao(id_instituicao),
	CONSTRAINT FK_evento_rota_ida FOREIGN KEY (id_rota_ida) REFERENCES rota(id_rota),
	CONSTRAINT FK_evento_rota_volta FOREIGN KEY (id_rota_volta) REFERENCES rota(id_rota),
	CONSTRAINT FK_evento_usuario_responsavel FOREIGN KEY (id_usuario_responsavel) REFERENCES usuario(id_usuario),
) 
GO

CREATE TABLE participante_evento (
	id_participante BIGINT NOT NULL IDENTITY(1,1),
	pagamento INT NOT NULL,
	sugestao VARCHAR(255) NOT NULL,
	avaliacao INT NULL,
	id_evento BIGINT NOT NULL,
	id_usuario BIGINT NOT NULL,
	CONSTRAINT PK_participante_evento PRIMARY KEY (id_participante),
	CONSTRAINT FK_participante_evento_evento FOREIGN KEY (id_evento) REFERENCES evento(id_evento),
	CONSTRAINT FK_participante_evento_usuario FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario),
) 
GO
