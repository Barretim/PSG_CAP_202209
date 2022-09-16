DECLARE @CODIGO INT
SET @CODIGO = 2407807
BEGIN
SELECT CodigoMunicipio, NomeMunicipio, CodigoIBGE6, CodigoIBGE7, CEP, SiglaUF, DescricaoUF
	FROM VW_Municipios_IBGE 
	WHERE (CodigoIBGE7 = @CODIGO)
END
