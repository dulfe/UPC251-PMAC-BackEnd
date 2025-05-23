SET IDENTITY_INSERT [dbo].[Cliente] ON 
GO
INSERT [dbo].[Cliente] ([ClienteId], [Empresa], [NombreDelRepresentante], [ApellidosDelRepresentante], [Cargo], [FechaDeCreacion], [Estado]) VALUES (1, N'Acme Corp', N'John', N'Doe', N'CEO', CAST(N'2024-11-01T19:16:33.6233333+00:00' AS DateTimeOffset), N'A')
GO
INSERT [dbo].[Cliente] ([ClienteId], [Empresa], [NombreDelRepresentante], [ApellidosDelRepresentante], [Cargo], [FechaDeCreacion], [Estado]) VALUES (2, N'Stark Industries', N'Tony', N'Stark', N'Iron Man', CAST(N'2024-11-01T19:16:33.6233333+00:00' AS DateTimeOffset), N'A')
GO
INSERT [dbo].[Cliente] ([ClienteId], [Empresa], [NombreDelRepresentante], [ApellidosDelRepresentante], [Cargo], [FechaDeCreacion], [Estado]) VALUES (3, N'Wayne Enterprises', N'Bruce', N'Wayne', N'Batman', CAST(N'2024-11-01T19:16:33.6233333+00:00' AS DateTimeOffset), N'A')
GO
INSERT [dbo].[Cliente] ([ClienteId], [Empresa], [NombreDelRepresentante], [ApellidosDelRepresentante], [Cargo], [FechaDeCreacion], [Estado]) VALUES (4, N'Oscorp', N'Norman', N'Osborn', N'Green Goblin', CAST(N'2024-11-01T19:16:33.6233333+00:00' AS DateTimeOffset), N'A')
GO
INSERT [dbo].[Cliente] ([ClienteId], [Empresa], [NombreDelRepresentante], [ApellidosDelRepresentante], [Cargo], [FechaDeCreacion], [Estado]) VALUES (5, N'LexCorp', N'Lex', N'Luthor', N'CEO', CAST(N'2024-11-01T19:16:33.6233333+00:00' AS DateTimeOffset), N'A')
GO
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Fabrica] ON 
GO
INSERT [dbo].[Fabrica] ([FabricaId], [Nombre], [FechaDeCreacion]) VALUES (1, N'Factory A', CAST(N'2024-11-01T19:16:33.6466667+00:00' AS DateTimeOffset))
GO
INSERT [dbo].[Fabrica] ([FabricaId], [Nombre], [FechaDeCreacion]) VALUES (2, N'Factory B', CAST(N'2024-11-01T19:16:33.6466667+00:00' AS DateTimeOffset))
GO
INSERT [dbo].[Fabrica] ([FabricaId], [Nombre], [FechaDeCreacion]) VALUES (3, N'Factory C', CAST(N'2024-11-01T19:16:33.6466667+00:00' AS DateTimeOffset))
GO
INSERT [dbo].[Fabrica] ([FabricaId], [Nombre], [FechaDeCreacion]) VALUES (4, N'Factory D', CAST(N'2024-11-01T19:16:33.6466667+00:00' AS DateTimeOffset))
GO
INSERT [dbo].[Fabrica] ([FabricaId], [Nombre], [FechaDeCreacion]) VALUES (5, N'Factory E', CAST(N'2024-11-01T19:16:33.6466667+00:00' AS DateTimeOffset))
GO
SET IDENTITY_INSERT [dbo].[Fabrica] OFF
GO
SET IDENTITY_INSERT [dbo].[OrdenDeTrabajo] ON 
GO
INSERT [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId], [FechaEstimadaDeTermino], [FechaEstimadaDeEnvio], [FechaEstimadaDeEntrega], [FechaDeCreacion], [ClienteId], [FabricaId], [CodigoDeSeguimiento], [Descripcion], [PesoEnKilos], [LugarDeEntrega], [DireccionDeEntrega], [DireccionDeEntregaLat], [DireccionDeEntregaLon], [Estado]) VALUES (1, CAST(N'2024-02-09T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-02-10T16:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-02-11T08:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-02-02T00:00:00.0000000-05:00' AS DateTimeOffset), 1, 1, N'ABC1102024', N'Order Description', CAST(1851.94 AS Decimal(6, 2)), N'Alicorp S.A.A.', N'Av. Argentina 4793, Callao 07041, Peru', CAST(-12.047176 AS Decimal(9, 6)), CAST(-77.092985 AS Decimal(9, 6)), N'C')
GO
INSERT [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId], [FechaEstimadaDeTermino], [FechaEstimadaDeEnvio], [FechaEstimadaDeEntrega], [FechaDeCreacion], [ClienteId], [FabricaId], [CodigoDeSeguimiento], [Descripcion], [PesoEnKilos], [LugarDeEntrega], [DireccionDeEntrega], [DireccionDeEntregaLat], [DireccionDeEntregaLon], [Estado]) VALUES (2, CAST(N'2024-07-06T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-07-07T10:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-07-08T08:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-07-01T00:00:00.0000000-05:00' AS DateTimeOffset), 1, 2, N'ABC1202024', N'Order Description', CAST(1085.12 AS Decimal(6, 2)), N'Backus y Johnston S.A.A.', N'Calle San Felipe 211, Lima 15074, Peru', CAST(-12.190250 AS Decimal(9, 6)), CAST(-77.010740 AS Decimal(9, 6)), N'C')
GO
INSERT [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId], [FechaEstimadaDeTermino], [FechaEstimadaDeEnvio], [FechaEstimadaDeEntrega], [FechaDeCreacion], [ClienteId], [FabricaId], [CodigoDeSeguimiento], [Descripcion], [PesoEnKilos], [LugarDeEntrega], [DireccionDeEntrega], [DireccionDeEntregaLat], [DireccionDeEntregaLon], [Estado]) VALUES (3, CAST(N'2024-10-10T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-10-30T11:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-11-20T08:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-10-04T00:00:00.0000000-05:00' AS DateTimeOffset), 1, 3, N'ABC1302024', N'Order Description', CAST(1772.57 AS Decimal(6, 2)), N'Cementos Pacasmayo S.A.A.', N'Av. República de Panamá 3591, Lima 15046, Peru', CAST(-12.099861 AS Decimal(9, 6)), CAST(-77.018925 AS Decimal(9, 6)), N'E')
GO
INSERT [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId], [FechaEstimadaDeTermino], [FechaEstimadaDeEnvio], [FechaEstimadaDeEntrega], [FechaDeCreacion], [ClienteId], [FabricaId], [CodigoDeSeguimiento], [Descripcion], [PesoEnKilos], [LugarDeEntrega], [DireccionDeEntrega], [DireccionDeEntregaLat], [DireccionDeEntregaLon], [Estado]) VALUES (4, CAST(N'2024-06-13T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-06-14T13:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-06-14T17:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-06-07T00:00:00.0000000-05:00' AS DateTimeOffset), 1, 4, N'ABC1402024', N'Order Description', CAST(989.87 AS Decimal(6, 2)), N'Compañía de Minas Buenaventura S.A.A.', N'Av. Paseo de la República 3939, Lima 15046, Peru', CAST(-12.103843 AS Decimal(9, 6)), CAST(-77.027693 AS Decimal(9, 6)), N'C')
GO
INSERT [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId], [FechaEstimadaDeTermino], [FechaEstimadaDeEnvio], [FechaEstimadaDeEntrega], [FechaDeCreacion], [ClienteId], [FabricaId], [CodigoDeSeguimiento], [Descripcion], [PesoEnKilos], [LugarDeEntrega], [DireccionDeEntrega], [DireccionDeEntregaLat], [DireccionDeEntregaLon], [Estado]) VALUES (5, CAST(N'2024-10-02T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-10-03T09:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-10-04T08:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-09-22T00:00:00.0000000-05:00' AS DateTimeOffset), 1, 5, N'ABC1502024', N'Order Description', CAST(931.30 AS Decimal(6, 2)), N'Credicorp Ltd.', N'Av. Canaval y Moreyra 454, Lima 15074, Peru', CAST(-12.097141 AS Decimal(9, 6)), CAST(-77.021866 AS Decimal(9, 6)), N'C')
GO
INSERT [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId], [FechaEstimadaDeTermino], [FechaEstimadaDeEnvio], [FechaEstimadaDeEntrega], [FechaDeCreacion], [ClienteId], [FabricaId], [CodigoDeSeguimiento], [Descripcion], [PesoEnKilos], [LugarDeEntrega], [DireccionDeEntrega], [DireccionDeEntregaLat], [DireccionDeEntregaLon], [Estado]) VALUES (6, CAST(N'2024-09-22T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-09-23T10:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-09-23T15:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-09-12T00:00:00.0000000-05:00' AS DateTimeOffset), 2, 1, N'ABC2102024', N'Order Description', CAST(1091.20 AS Decimal(6, 2)), N'Ferreycorp S.A.A.', N'Av. Dionisio Derteano 144, Lima 15038, Peru', CAST(-12.095921 AS Decimal(9, 6)), CAST(-77.021972 AS Decimal(9, 6)), N'C')
GO
INSERT [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId], [FechaEstimadaDeTermino], [FechaEstimadaDeEnvio], [FechaEstimadaDeEntrega], [FechaDeCreacion], [ClienteId], [FabricaId], [CodigoDeSeguimiento], [Descripcion], [PesoEnKilos], [LugarDeEntrega], [DireccionDeEntrega], [DireccionDeEntregaLat], [DireccionDeEntregaLon], [Estado]) VALUES (7, CAST(N'2024-10-07T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-10-08T11:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-10-08T15:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-09-27T00:00:00.0000000-05:00' AS DateTimeOffset), 2, 2, N'ABC2202024', N'Order Description', CAST(1463.69 AS Decimal(6, 2)), N'Graña y Montero S.A.A.', N'Av. Paseo de la República 4435, Lima 15046, Peru', CAST(-12.110008 AS Decimal(9, 6)), CAST(-77.026533 AS Decimal(9, 6)), N'C')
GO
INSERT [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId], [FechaEstimadaDeTermino], [FechaEstimadaDeEnvio], [FechaEstimadaDeEntrega], [FechaDeCreacion], [ClienteId], [FabricaId], [CodigoDeSeguimiento], [Descripcion], [PesoEnKilos], [LugarDeEntrega], [DireccionDeEntrega], [DireccionDeEntregaLat], [DireccionDeEntregaLon], [Estado]) VALUES (8, CAST(N'2024-12-10T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-12-11T14:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-12-12T08:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-12-01T00:00:00.0000000-05:00' AS DateTimeOffset), 2, 3, N'ABC2302024', N'Order Description', CAST(975.14 AS Decimal(6, 2)), N'Grupo Intercorp S.A.A.', N'Av. Carlos Villarán 140, Lima 15074, Peru', CAST(-12.088833 AS Decimal(9, 6)), CAST(-77.020121 AS Decimal(9, 6)), N'P')
GO
INSERT [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId], [FechaEstimadaDeTermino], [FechaEstimadaDeEnvio], [FechaEstimadaDeEntrega], [FechaDeCreacion], [ClienteId], [FabricaId], [CodigoDeSeguimiento], [Descripcion], [PesoEnKilos], [LugarDeEntrega], [DireccionDeEntrega], [DireccionDeEntregaLat], [DireccionDeEntregaLon], [Estado]) VALUES (9, CAST(N'2024-09-21T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-09-22T08:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-09-22T12:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-09-13T00:00:00.0000000-05:00' AS DateTimeOffset), 2, 4, N'ABC2402024', N'Order Description', CAST(997.47 AS Decimal(6, 2)), N'InRetail Perú Corp.', N'Av. Paseo de la República 3220, Lima 15046, Peru', CAST(-12.095044 AS Decimal(9, 6)), CAST(-77.025066 AS Decimal(9, 6)), N'C')
GO
INSERT [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId], [FechaEstimadaDeTermino], [FechaEstimadaDeEnvio], [FechaEstimadaDeEntrega], [FechaDeCreacion], [ClienteId], [FabricaId], [CodigoDeSeguimiento], [Descripcion], [PesoEnKilos], [LugarDeEntrega], [DireccionDeEntrega], [DireccionDeEntregaLat], [DireccionDeEntregaLon], [Estado]) VALUES (10, CAST(N'2024-05-26T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-05-27T16:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-05-28T08:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-05-21T00:00:00.0000000-05:00' AS DateTimeOffset), 2, 5, N'ABC2502024', N'Order Description', CAST(1001.80 AS Decimal(6, 2)), N'Minsur S.A.', N'Av. Víctor Andrés Belaúnde 147, Lima 15074, Peru', CAST(-12.097477 AS Decimal(9, 6)), CAST(-77.037413 AS Decimal(9, 6)), N'C')
GO
INSERT [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId], [FechaEstimadaDeTermino], [FechaEstimadaDeEnvio], [FechaEstimadaDeEntrega], [FechaDeCreacion], [ClienteId], [FabricaId], [CodigoDeSeguimiento], [Descripcion], [PesoEnKilos], [LugarDeEntrega], [DireccionDeEntrega], [DireccionDeEntregaLat], [DireccionDeEntregaLon], [Estado]) VALUES (11, CAST(N'2024-06-14T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-06-15T16:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-06-16T08:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-06-05T00:00:00.0000000-05:00' AS DateTimeOffset), 3, 1, N'ABC3102024', N'Order Description', CAST(1655.12 AS Decimal(6, 2)), N'Petroperú S.A.', N'Av. Enrique Canaval y Moreyra 150, Lima 15074, Peru', CAST(-12.097320 AS Decimal(9, 6)), CAST(-77.024503 AS Decimal(9, 6)), N'C')
GO
INSERT [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId], [FechaEstimadaDeTermino], [FechaEstimadaDeEnvio], [FechaEstimadaDeEntrega], [FechaDeCreacion], [ClienteId], [FabricaId], [CodigoDeSeguimiento], [Descripcion], [PesoEnKilos], [LugarDeEntrega], [DireccionDeEntrega], [DireccionDeEntregaLat], [DireccionDeEntregaLon], [Estado]) VALUES (12, CAST(N'2024-12-23T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-12-24T17:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-12-25T08:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-12-15T00:00:00.0000000-05:00' AS DateTimeOffset), 3, 2, N'ABC3202024', N'Order Description', CAST(914.37 AS Decimal(6, 2)), N'Scotiabank Perú S.A.A.', N'Av. Rivera Navarrete 849, Lima 15074, Peru', CAST(-12.092884 AS Decimal(9, 6)), CAST(-77.026829 AS Decimal(9, 6)), N'P')
GO
INSERT [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId], [FechaEstimadaDeTermino], [FechaEstimadaDeEnvio], [FechaEstimadaDeEntrega], [FechaDeCreacion], [ClienteId], [FabricaId], [CodigoDeSeguimiento], [Descripcion], [PesoEnKilos], [LugarDeEntrega], [DireccionDeEntrega], [DireccionDeEntregaLat], [DireccionDeEntregaLon], [Estado]) VALUES (13, CAST(N'2024-12-01T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-12-02T10:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-12-02T16:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-11-22T00:00:00.0000000-05:00' AS DateTimeOffset), 3, 3, N'ABC3302024', N'Order Description', CAST(894.38 AS Decimal(6, 2)), N'Southern Copper Corporation', N'Av. Canaval y Moreyra 525, Lima 15074, Peru', CAST(-12.097518 AS Decimal(9, 6)), CAST(-77.019833 AS Decimal(9, 6)), N'P')
GO
INSERT [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId], [FechaEstimadaDeTermino], [FechaEstimadaDeEnvio], [FechaEstimadaDeEntrega], [FechaDeCreacion], [ClienteId], [FabricaId], [CodigoDeSeguimiento], [Descripcion], [PesoEnKilos], [LugarDeEntrega], [DireccionDeEntrega], [DireccionDeEntregaLat], [DireccionDeEntregaLon], [Estado]) VALUES (14, CAST(N'2024-09-25T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-09-26T13:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-09-27T08:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-09-15T00:00:00.0000000-05:00' AS DateTimeOffset), 3, 4, N'ABC3402024', N'Order Description', CAST(740.08 AS Decimal(6, 2)), N'Telefónica del Perú S.A.A.', N'Av. Pardo y Aliaga 650, Lima 15074, Peru', CAST(-12.107639 AS Decimal(9, 6)), CAST(-77.035498 AS Decimal(9, 6)), N'C')
GO
INSERT [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId], [FechaEstimadaDeTermino], [FechaEstimadaDeEnvio], [FechaEstimadaDeEntrega], [FechaDeCreacion], [ClienteId], [FabricaId], [CodigoDeSeguimiento], [Descripcion], [PesoEnKilos], [LugarDeEntrega], [DireccionDeEntrega], [DireccionDeEntregaLat], [DireccionDeEntregaLon], [Estado]) VALUES (15, CAST(N'2024-06-23T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-06-24T14:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-06-25T08:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-06-13T00:00:00.0000000-05:00' AS DateTimeOffset), 3, 5, N'ABC3502024', N'Order Description', CAST(431.33 AS Decimal(6, 2)), N'Unión de Cervecerías Peruanas Backus y Johnston S.A.A.', N'Av. Nicolás Ayllón 2951, Ate 15481, Peru', CAST(-12.064069 AS Decimal(9, 6)), CAST(-76.989300 AS Decimal(9, 6)), N'C')
GO
INSERT [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId], [FechaEstimadaDeTermino], [FechaEstimadaDeEnvio], [FechaEstimadaDeEntrega], [FechaDeCreacion], [ClienteId], [FabricaId], [CodigoDeSeguimiento], [Descripcion], [PesoEnKilos], [LugarDeEntrega], [DireccionDeEntrega], [DireccionDeEntregaLat], [DireccionDeEntregaLon], [Estado]) VALUES (16, CAST(N'2024-08-06T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-08-07T14:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-08-08T08:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-07-31T00:00:00.0000000-05:00' AS DateTimeOffset), 4, 1, N'ABC4102024', N'Order Description', CAST(413.30 AS Decimal(6, 2)), N'Yanacocha S.R.L.', N'Carretera Cajamarca - Bambamarca km 48, Cajamarca, Peru', CAST(-7.163780 AS Decimal(9, 6)), CAST(-78.500270 AS Decimal(9, 6)), N'C')
GO
INSERT [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId], [FechaEstimadaDeTermino], [FechaEstimadaDeEnvio], [FechaEstimadaDeEntrega], [FechaDeCreacion], [ClienteId], [FabricaId], [CodigoDeSeguimiento], [Descripcion], [PesoEnKilos], [LugarDeEntrega], [DireccionDeEntrega], [DireccionDeEntregaLat], [DireccionDeEntregaLon], [Estado]) VALUES (17, CAST(N'2024-07-14T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-07-15T17:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-07-16T08:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-07-07T00:00:00.0000000-05:00' AS DateTimeOffset), 4, 2, N'ABC4202024', N'Order Description', CAST(899.03 AS Decimal(6, 2)), N'Gloria S.A.', N'Av. República de Panamá 2461, Lima 15046, Peru', CAST(-12.097672 AS Decimal(9, 6)), CAST(-77.020655 AS Decimal(9, 6)), N'C')
GO
INSERT [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId], [FechaEstimadaDeTermino], [FechaEstimadaDeEnvio], [FechaEstimadaDeEntrega], [FechaDeCreacion], [ClienteId], [FabricaId], [CodigoDeSeguimiento], [Descripcion], [PesoEnKilos], [LugarDeEntrega], [DireccionDeEntrega], [DireccionDeEntregaLat], [DireccionDeEntregaLon], [Estado]) VALUES (18, CAST(N'2024-09-13T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-09-14T16:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-09-15T08:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-09-05T00:00:00.0000000-05:00' AS DateTimeOffset), 4, 3, N'ABC4302024', N'Order Description', CAST(1766.75 AS Decimal(6, 2)), N'BBVA Perú', N'Av. República de Panamá 3055, Lima 15046, Peru', CAST(-12.093576 AS Decimal(9, 6)), CAST(-77.021197 AS Decimal(9, 6)), N'C')
GO
INSERT [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId], [FechaEstimadaDeTermino], [FechaEstimadaDeEnvio], [FechaEstimadaDeEntrega], [FechaDeCreacion], [ClienteId], [FabricaId], [CodigoDeSeguimiento], [Descripcion], [PesoEnKilos], [LugarDeEntrega], [DireccionDeEntrega], [DireccionDeEntregaLat], [DireccionDeEntregaLon], [Estado]) VALUES (19, CAST(N'2024-05-02T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-05-03T08:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-05-03T15:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-04-26T00:00:00.0000000-05:00' AS DateTimeOffset), 4, 4, N'ABC4402024', N'Order Description', CAST(1699.79 AS Decimal(6, 2)), N'Interbank', N'Av. Carlos Villarán 140, Lima 15074, Peru', CAST(-12.088833 AS Decimal(9, 6)), CAST(-77.020121 AS Decimal(9, 6)), N'C')
GO
INSERT [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId], [FechaEstimadaDeTermino], [FechaEstimadaDeEnvio], [FechaEstimadaDeEntrega], [FechaDeCreacion], [ClienteId], [FabricaId], [CodigoDeSeguimiento], [Descripcion], [PesoEnKilos], [LugarDeEntrega], [DireccionDeEntrega], [DireccionDeEntregaLat], [DireccionDeEntregaLon], [Estado]) VALUES (20, CAST(N'2024-03-08T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-03-09T12:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-03-10T08:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-03-03T00:00:00.0000000-05:00' AS DateTimeOffset), 4, 5, N'ABC4502024', N'Order Description', CAST(722.29 AS Decimal(6, 2)), N'BCP', N'Av. Luis Bedoya Reyes 205, Lima 15046, Peru', CAST(-12.072932 AS Decimal(9, 6)), CAST(-77.030443 AS Decimal(9, 6)), N'C')
GO
INSERT [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId], [FechaEstimadaDeTermino], [FechaEstimadaDeEnvio], [FechaEstimadaDeEntrega], [FechaDeCreacion], [ClienteId], [FabricaId], [CodigoDeSeguimiento], [Descripcion], [PesoEnKilos], [LugarDeEntrega], [DireccionDeEntrega], [DireccionDeEntregaLat], [DireccionDeEntregaLon], [Estado]) VALUES (21, CAST(N'2024-04-22T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-04-23T09:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-04-24T08:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-04-16T00:00:00.0000000-05:00' AS DateTimeOffset), 5, 1, N'ABC5102024', N'Order Description', CAST(629.42 AS Decimal(6, 2)), N'Caja Arequipa', N'Calle Jerusalén 401, Arequipa, Peru', CAST(-16.395719 AS Decimal(9, 6)), CAST(-71.533900 AS Decimal(9, 6)), N'C')
GO
INSERT [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId], [FechaEstimadaDeTermino], [FechaEstimadaDeEnvio], [FechaEstimadaDeEntrega], [FechaDeCreacion], [ClienteId], [FabricaId], [CodigoDeSeguimiento], [Descripcion], [PesoEnKilos], [LugarDeEntrega], [DireccionDeEntrega], [DireccionDeEntregaLat], [DireccionDeEntregaLon], [Estado]) VALUES (22, CAST(N'2024-01-04T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-01-05T11:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-01-06T08:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2023-12-26T00:00:00.0000000-05:00' AS DateTimeOffset), 5, 2, N'ABC5202024', N'Order Description', CAST(1539.08 AS Decimal(6, 2)), N'Real Plaza', N'Prolongacion Primavera 2390, Santiago de Surco 15023, Peru', CAST(-12.099803 AS Decimal(9, 6)), CAST(-76.970895 AS Decimal(9, 6)), N'C')
GO
INSERT [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId], [FechaEstimadaDeTermino], [FechaEstimadaDeEnvio], [FechaEstimadaDeEntrega], [FechaDeCreacion], [ClienteId], [FabricaId], [CodigoDeSeguimiento], [Descripcion], [PesoEnKilos], [LugarDeEntrega], [DireccionDeEntrega], [DireccionDeEntregaLat], [DireccionDeEntregaLon], [Estado]) VALUES (23, CAST(N'2024-10-17T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-10-29T09:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-11-30T14:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-10-12T00:00:00.0000000-05:00' AS DateTimeOffset), 5, 3, N'ABC5302024', N'Order Description', CAST(934.79 AS Decimal(6, 2)), N'Plaza Vea', N'Av. Alfredo Mendiola 3698, Lima 15108, Peru', CAST(-11.995370 AS Decimal(9, 6)), CAST(-77.062883 AS Decimal(9, 6)), N'E')
GO
INSERT [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId], [FechaEstimadaDeTermino], [FechaEstimadaDeEnvio], [FechaEstimadaDeEntrega], [FechaDeCreacion], [ClienteId], [FabricaId], [CodigoDeSeguimiento], [Descripcion], [PesoEnKilos], [LugarDeEntrega], [DireccionDeEntrega], [DireccionDeEntregaLat], [DireccionDeEntregaLon], [Estado]) VALUES (24, CAST(N'2024-08-19T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-08-20T12:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-08-21T08:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-08-12T00:00:00.0000000-05:00' AS DateTimeOffset), 5, 4, N'ABC5402024', N'Order Description', CAST(1686.75 AS Decimal(6, 2)), N'Tottus', N'Av. La Marina 2469, San Miguel 15088, Peru', CAST(-12.076927 AS Decimal(9, 6)), CAST(-77.082713 AS Decimal(9, 6)), N'C')
GO
INSERT [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId], [FechaEstimadaDeTermino], [FechaEstimadaDeEnvio], [FechaEstimadaDeEntrega], [FechaDeCreacion], [ClienteId], [FabricaId], [CodigoDeSeguimiento], [Descripcion], [PesoEnKilos], [LugarDeEntrega], [DireccionDeEntrega], [DireccionDeEntregaLat], [DireccionDeEntregaLon], [Estado]) VALUES (25, CAST(N'2024-04-12T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-04-13T14:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-04-14T08:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-04-03T00:00:00.0000000-05:00' AS DateTimeOffset), 5, 5, N'ABC5502024', N'Order Description', CAST(1128.45 AS Decimal(6, 2)), N'Sodimac', N'Av. Javier Prado Este 4200, Lima 15024, Peru', CAST(-12.069717 AS Decimal(9, 6)), CAST(-76.948844 AS Decimal(9, 6)), N'C')
GO
SET IDENTITY_INSERT [dbo].[OrdenDeTrabajo] OFF
GO
SET IDENTITY_INSERT [dbo].[Conductor] ON 
GO
INSERT [dbo].[Conductor] ([ConductorId], [Nombres], [Apellidos], [Telefono], [FechaDeCreacion], [Estado]) VALUES (1, N'Clark', N'Kent', N'555-1234', CAST(N'2024-11-01T19:16:33.6433333+00:00' AS DateTimeOffset), N'A')
GO
INSERT [dbo].[Conductor] ([ConductorId], [Nombres], [Apellidos], [Telefono], [FechaDeCreacion], [Estado]) VALUES (2, N'Peter', N'Parker', N'555-5678', CAST(N'2024-11-01T19:16:33.6433333+00:00' AS DateTimeOffset), N'A')
GO
INSERT [dbo].[Conductor] ([ConductorId], [Nombres], [Apellidos], [Telefono], [FechaDeCreacion], [Estado]) VALUES (3, N'Diana', N'Prince', N'555-9012', CAST(N'2024-11-01T19:16:33.6433333+00:00' AS DateTimeOffset), N'A')
GO
INSERT [dbo].[Conductor] ([ConductorId], [Nombres], [Apellidos], [Telefono], [FechaDeCreacion], [Estado]) VALUES (4, N'Barry', N'Allen', N'555-3456', CAST(N'2024-11-01T19:16:33.6433333+00:00' AS DateTimeOffset), N'A')
GO
INSERT [dbo].[Conductor] ([ConductorId], [Nombres], [Apellidos], [Telefono], [FechaDeCreacion], [Estado]) VALUES (5, N'Hal', N'Jordan', N'555-7890', CAST(N'2024-11-01T19:16:33.6433333+00:00' AS DateTimeOffset), N'A')
GO
SET IDENTITY_INSERT [dbo].[Conductor] OFF
GO
SET IDENTITY_INSERT [dbo].[Envio] ON 
GO
INSERT [dbo].[Envio] ([EnvioId], [OrdenDeTrabajoId], [FechaDeEntrega], [FechaDeCreacion], [Estado], [ConductorId]) VALUES (6, 1, CAST(N'2024-02-11T21:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-02-10T18:00:00.0000000-05:00' AS DateTimeOffset), N'C', 1)
GO
INSERT [dbo].[Envio] ([EnvioId], [OrdenDeTrabajoId], [FechaDeEntrega], [FechaDeCreacion], [Estado], [ConductorId]) VALUES (7, 2, CAST(N'2024-07-08T15:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-07-07T12:00:00.0000000-05:00' AS DateTimeOffset), N'C', 2)
GO
INSERT [dbo].[Envio] ([EnvioId], [OrdenDeTrabajoId], [FechaDeEntrega], [FechaDeCreacion], [Estado], [ConductorId]) VALUES (8, 3, NULL, CAST(N'2024-10-11T13:00:00.0000000-05:00' AS DateTimeOffset), N'E', 3)
GO
INSERT [dbo].[Envio] ([EnvioId], [OrdenDeTrabajoId], [FechaDeEntrega], [FechaDeCreacion], [Estado], [ConductorId]) VALUES (9, 4, CAST(N'2024-06-15T18:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-06-14T15:00:00.0000000-05:00' AS DateTimeOffset), N'C', 4)
GO
INSERT [dbo].[Envio] ([EnvioId], [OrdenDeTrabajoId], [FechaDeEntrega], [FechaDeCreacion], [Estado], [ConductorId]) VALUES (10, 5, CAST(N'2024-10-04T14:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-10-03T11:00:00.0000000-05:00' AS DateTimeOffset), N'C', 5)
GO
INSERT [dbo].[Envio] ([EnvioId], [OrdenDeTrabajoId], [FechaDeEntrega], [FechaDeCreacion], [Estado], [ConductorId]) VALUES (11, 6, CAST(N'2024-09-24T15:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-09-23T12:00:00.0000000-05:00' AS DateTimeOffset), N'C', 1)
GO
INSERT [dbo].[Envio] ([EnvioId], [OrdenDeTrabajoId], [FechaDeEntrega], [FechaDeCreacion], [Estado], [ConductorId]) VALUES (12, 7, CAST(N'2024-10-09T16:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-10-08T13:00:00.0000000-05:00' AS DateTimeOffset), N'C', 2)
GO
INSERT [dbo].[Envio] ([EnvioId], [OrdenDeTrabajoId], [FechaDeEntrega], [FechaDeCreacion], [Estado], [ConductorId]) VALUES (13, 9, CAST(N'2024-09-23T13:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-09-22T10:00:00.0000000-05:00' AS DateTimeOffset), N'C', 3)
GO
INSERT [dbo].[Envio] ([EnvioId], [OrdenDeTrabajoId], [FechaDeEntrega], [FechaDeCreacion], [Estado], [ConductorId]) VALUES (14, 10, CAST(N'2024-05-28T21:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-05-27T18:00:00.0000000-05:00' AS DateTimeOffset), N'C', 4)
GO
INSERT [dbo].[Envio] ([EnvioId], [OrdenDeTrabajoId], [FechaDeEntrega], [FechaDeCreacion], [Estado], [ConductorId]) VALUES (15, 11, CAST(N'2024-06-16T21:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-06-15T18:00:00.0000000-05:00' AS DateTimeOffset), N'C', 5)
GO
INSERT [dbo].[Envio] ([EnvioId], [OrdenDeTrabajoId], [FechaDeEntrega], [FechaDeCreacion], [Estado], [ConductorId]) VALUES (16, 14, CAST(N'2024-09-27T18:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-09-26T15:00:00.0000000-05:00' AS DateTimeOffset), N'C', 1)
GO
INSERT [dbo].[Envio] ([EnvioId], [OrdenDeTrabajoId], [FechaDeEntrega], [FechaDeCreacion], [Estado], [ConductorId]) VALUES (17, 15, CAST(N'2024-06-25T19:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-06-24T16:00:00.0000000-05:00' AS DateTimeOffset), N'C', 2)
GO
INSERT [dbo].[Envio] ([EnvioId], [OrdenDeTrabajoId], [FechaDeEntrega], [FechaDeCreacion], [Estado], [ConductorId]) VALUES (18, 16, CAST(N'2024-08-08T19:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-08-07T16:00:00.0000000-05:00' AS DateTimeOffset), N'C', 3)
GO
INSERT [dbo].[Envio] ([EnvioId], [OrdenDeTrabajoId], [FechaDeEntrega], [FechaDeCreacion], [Estado], [ConductorId]) VALUES (19, 17, CAST(N'2024-07-16T22:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-07-15T19:00:00.0000000-05:00' AS DateTimeOffset), N'C', 4)
GO
INSERT [dbo].[Envio] ([EnvioId], [OrdenDeTrabajoId], [FechaDeEntrega], [FechaDeCreacion], [Estado], [ConductorId]) VALUES (20, 18, CAST(N'2024-09-15T21:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-09-14T18:00:00.0000000-05:00' AS DateTimeOffset), N'C', 5)
GO
INSERT [dbo].[Envio] ([EnvioId], [OrdenDeTrabajoId], [FechaDeEntrega], [FechaDeCreacion], [Estado], [ConductorId]) VALUES (21, 19, CAST(N'2024-05-04T13:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-05-03T10:00:00.0000000-05:00' AS DateTimeOffset), N'C', 1)
GO
INSERT [dbo].[Envio] ([EnvioId], [OrdenDeTrabajoId], [FechaDeEntrega], [FechaDeCreacion], [Estado], [ConductorId]) VALUES (22, 20, CAST(N'2024-03-10T17:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-03-09T14:00:00.0000000-05:00' AS DateTimeOffset), N'C', 2)
GO
INSERT [dbo].[Envio] ([EnvioId], [OrdenDeTrabajoId], [FechaDeEntrega], [FechaDeCreacion], [Estado], [ConductorId]) VALUES (23, 21, CAST(N'2024-04-24T14:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-04-23T11:00:00.0000000-05:00' AS DateTimeOffset), N'C', 3)
GO
INSERT [dbo].[Envio] ([EnvioId], [OrdenDeTrabajoId], [FechaDeEntrega], [FechaDeCreacion], [Estado], [ConductorId]) VALUES (24, 22, CAST(N'2024-01-06T16:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-01-05T13:00:00.0000000-05:00' AS DateTimeOffset), N'C', 4)
GO
INSERT [dbo].[Envio] ([EnvioId], [OrdenDeTrabajoId], [FechaDeEntrega], [FechaDeCreacion], [Estado], [ConductorId]) VALUES (25, 23, NULL, CAST(N'2024-10-18T11:00:00.0000000-05:00' AS DateTimeOffset), N'E', 5)
GO
INSERT [dbo].[Envio] ([EnvioId], [OrdenDeTrabajoId], [FechaDeEntrega], [FechaDeCreacion], [Estado], [ConductorId]) VALUES (26, 24, CAST(N'2024-08-21T17:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-08-20T14:00:00.0000000-05:00' AS DateTimeOffset), N'C', 1)
GO
INSERT [dbo].[Envio] ([EnvioId], [OrdenDeTrabajoId], [FechaDeEntrega], [FechaDeCreacion], [Estado], [ConductorId]) VALUES (27, 25, CAST(N'2024-04-14T19:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-04-13T16:00:00.0000000-05:00' AS DateTimeOffset), N'C', 2)
GO
SET IDENTITY_INSERT [dbo].[Envio] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([UsuarioId], [Email], [PasswordHash], [Nombres], [Apellidos], [FechaDeCreacion], [Estado]) VALUES (1, N'john.doe@acme.com', N'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', N'John', N'Doe', CAST(N'2024-11-01T19:16:33.6500000+00:00' AS DateTimeOffset), N'A')
GO
INSERT [dbo].[Usuario] ([UsuarioId], [Email], [PasswordHash], [Nombres], [Apellidos], [FechaDeCreacion], [Estado]) VALUES (2, N'tony.stark@acme.com', N'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', N'Tony', N'Stark', CAST(N'2024-11-01T19:16:33.6500000+00:00' AS DateTimeOffset), N'A')
GO
INSERT [dbo].[Usuario] ([UsuarioId], [Email], [PasswordHash], [Nombres], [Apellidos], [FechaDeCreacion], [Estado]) VALUES (3, N'bruce.wayne@acme.com', N'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', N'Bruce', N'Wayne', CAST(N'2024-11-01T19:16:33.6500000+00:00' AS DateTimeOffset), N'A')
GO
INSERT [dbo].[Usuario] ([UsuarioId], [Email], [PasswordHash], [Nombres], [Apellidos], [FechaDeCreacion], [Estado]) VALUES (4, N'norman.osborn@acme.com', N'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', N'Norman', N'Osborn', CAST(N'2024-11-01T19:16:33.6500000+00:00' AS DateTimeOffset), N'A')
GO
INSERT [dbo].[Usuario] ([UsuarioId], [Email], [PasswordHash], [Nombres], [Apellidos], [FechaDeCreacion], [Estado]) VALUES (5, N'lex.luthor@acme.com', N'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', N'Lex', N'Luthor', CAST(N'2024-11-01T19:16:33.6500000+00:00' AS DateTimeOffset), N'A')
GO
INSERT [dbo].[Usuario] ([UsuarioId], [Email], [PasswordHash], [Nombres], [Apellidos], [FechaDeCreacion], [Estado]) VALUES (8, N'test@server.com', N'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', N'nombres', N'apellidos', CAST(N'2025-05-03T12:38:22.7762321-04:00' AS DateTimeOffset), N'A')
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
INSERT [dbo].[OrdenPorUsuario] ([OrdenDeTrabajoId], [UsuarioId], [FechaDeCreacion], [FechaDeUltimaConsulta]) VALUES (3, 2, CAST(N'2024-11-01T17:01:08.9574000-04:00' AS DateTimeOffset), CAST(N'2024-11-01T17:01:08.9574000-04:00' AS DateTimeOffset))
GO
INSERT [dbo].[OrdenPorUsuario] ([OrdenDeTrabajoId], [UsuarioId], [FechaDeCreacion], [FechaDeUltimaConsulta]) VALUES (8, 2, CAST(N'2024-11-01T17:09:35.1598111-04:00' AS DateTimeOffset), CAST(N'2024-11-01T17:09:35.1598111-04:00' AS DateTimeOffset))
GO
INSERT [dbo].[OrdenPorUsuario] ([OrdenDeTrabajoId], [UsuarioId], [FechaDeCreacion], [FechaDeUltimaConsulta]) VALUES (13, 2, CAST(N'2024-11-01T17:10:25.6487737-04:00' AS DateTimeOffset), CAST(N'2025-05-02T22:05:41.2380461-04:00' AS DateTimeOffset))
GO
INSERT [dbo].[OrdenPorUsuario] ([OrdenDeTrabajoId], [UsuarioId], [FechaDeCreacion], [FechaDeUltimaConsulta]) VALUES (14, 2, CAST(N'2024-11-03T15:36:50.4379347-05:00' AS DateTimeOffset), CAST(N'2024-11-08T21:14:50.2906001-05:00' AS DateTimeOffset))
GO
INSERT [dbo].[OrdenPorUsuario] ([OrdenDeTrabajoId], [UsuarioId], [FechaDeCreacion], [FechaDeUltimaConsulta]) VALUES (22, 1, CAST(N'2024-11-19T16:48:32.9126308-05:00' AS DateTimeOffset), CAST(N'2024-11-19T16:48:32.9126714-05:00' AS DateTimeOffset))
GO
INSERT [dbo].[OrdenPorUsuario] ([OrdenDeTrabajoId], [UsuarioId], [FechaDeCreacion], [FechaDeUltimaConsulta]) VALUES (22, 2, CAST(N'2024-11-08T21:12:11.1252794-05:00' AS DateTimeOffset), CAST(N'2025-05-02T22:04:06.8755566-04:00' AS DateTimeOffset))
GO
INSERT [dbo].[OrdenPorUsuario] ([OrdenDeTrabajoId], [UsuarioId], [FechaDeCreacion], [FechaDeUltimaConsulta]) VALUES (23, 2, CAST(N'2024-11-01T17:02:00.7144847-04:00' AS DateTimeOffset), CAST(N'2024-11-01T17:02:00.7144847-04:00' AS DateTimeOffset))
GO
