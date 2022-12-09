SET IDENTITY_INSERT [dbo].[estado] ON

INSERT INTO [dbo].[estado] ([id_estado], [nome], [uf], [id_regiao]) VALUES 

(1,'RONDÔNIA','RO',1),
(2,'ACRE','AC',1),
(3,'AMAZONAS','AM',1),
(4,'RORAIMA' ,'RR',1),
(5,'PARÁ','PA',1),
(6,'AMAPÁ','AP',1),
(7,'TOCANTINS','TO',1),
(8,'MARANHÃO','MA',4),
(9,'PIAUÍ','PI',4),
(10,'CEARÁ','CE',4),
(11,'RIO GRANDE DO NORTE','RN',4),
(12,'PARAÍBA','PB',4),
(13,'PERNAMBUCO','PE',4),
(14,'ALAGOAS','AL',4),
(15,'SERGIPE','SE',4),
(16,'BAHIA','BA',4),
(17,'MINAS GERAIS','MG',5),
(18,'ESPÍRITO SANTO','ES',5),
(19,'RIO DE JANEIRO','RJ',5),
(20,'SÃO PAULO','SP',5),
(21,'PARANÁ','PR',2),
(22,'SANTA CATARINA','S',2),
(23,'RIO GRANDE DO SUL','RS',2),
(24,'MATO GROSSO DO SUL','MS',3),
(25,'MATO GROSSO','MT',3),
(26,'GOIÁS','GO',3),
(27,'DISTRITO FEDERAL','DF',3)

SET IDENTITY_INSERT [dbo].[pais] OFF

--SELECT * FROM pais 
