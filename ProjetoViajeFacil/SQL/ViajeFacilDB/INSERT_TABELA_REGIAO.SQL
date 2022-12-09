SET IDENTITY_INSERT [dbo].[regiao] ON

INSERT INTO [dbo].[regiao] ([id_regiao], [nome], [id_pais]) VALUES 

(1,'Região Norte', 30),
(2,'Região Sul', 30),
(3,'Região Centro-Oeste', 30),
(4,'Região Nordeste', 30),
(5,'Região Sudeste', 30)

SET IDENTITY_INSERT [dbo].[regiao] OFF

--SELECT * FROM regiao
