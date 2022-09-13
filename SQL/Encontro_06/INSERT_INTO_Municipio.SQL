INSERT INTO Municipio (CodigoMunicipio, NomeMunicipio, CodigoIBGE6, CodigoIBGE7, CEP, CodigoUF, SiglaUF, Regiao, Populacao, Porte)

SELECT       
	C.MunicipioID,
	C.Nome,
	B.IBGE,
	B.IBGE7,
	A.CEP,
	C.UFID,
	A.UF,
	B.Região,
	B.População_2010, 
	B.Porte
FROM
	RAW_Cidades_IBGE6_UTF8 AS A
	INNER JOIN RAW_Lista_de_Municipios_com_IBGE_Brasil_UTF8 AS B ON A.IBGE = B.IBGE
	INNER JOIN RAW_Municipios_Complementar_IBGE_UTF8 AS C ON B.IBGE7 = C.CodigoIBGE
	ORDER BY C.MunicipioID
