CREATE PROCEDURE SP_Pesquiasar_Municipios_Por_IBGE7
@CODIGO INT
AS
BEGIN
	SELECT CodigoMunicipio, NomeMunicipio, CodigoIBGE6, CodigoIBGE7, CEP, SiglaUF, DescricaoUF
	FROM VW_Municipios_IBGE 
	WHERE (CodigoIBGE7 = @CODIGO)
END
GO
