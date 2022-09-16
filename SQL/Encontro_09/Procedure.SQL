CREATE PROCEDURE SP_Pesquiasar_Municipios_Por_IBGE7
@CODIGO CHAR(7)
AS
BEGIN
	SELECT CodigoMunicipio, NomeMunicipio, CodigoIBGE6, CodigoIBGE7, CEP, SiglaUF, DescricaoUF
	FROM VW_Municipios_IBGE 
	WHERE (SiglaUF = @SIGLA)
END
GO
