CREATE TABLE TipoAquicultura(
	IdTipoAquicultura INT NOT NULL PRIMARY KEY,
	DescricaoTipoAquicultura VARCHAR(100) NOT NULL
)


INSERT INTO TipoAquicultura (IdTipoAquicultura, DescricaoTipoAquicultura)
	SELECT DISTINCT Id_Tipo_Aquicultura, Descricao_Tipo_Aquicultura FROM RAW_Aquicultura_Brasil_Municipios
	ORDER BY Id_Tipo_Aquicultura
