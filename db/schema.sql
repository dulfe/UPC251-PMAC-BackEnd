/****** Object:  Database [tracking]    Script Date: 11/13/2024 7:15:57 PM ******/
CREATE DATABASE [tracking]  (EDITION = 'GeneralPurpose', SERVICE_OBJECTIVE = 'GP_S_Gen5_2', MAXSIZE = 32 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS, LEDGER = OFF;
GO
ALTER DATABASE [tracking] SET COMPATIBILITY_LEVEL = 160
GO
ALTER DATABASE [tracking] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [tracking] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [tracking] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [tracking] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [tracking] SET ARITHABORT OFF 
GO
ALTER DATABASE [tracking] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [tracking] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [tracking] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [tracking] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [tracking] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [tracking] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [tracking] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [tracking] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [tracking] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [tracking] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [tracking] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [tracking] SET  MULTI_USER 
GO
ALTER DATABASE [tracking] SET ENCRYPTION ON
GO
ALTER DATABASE [tracking] SET QUERY_STORE = ON
GO
ALTER DATABASE [tracking] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 100, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/
GO
-- ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 11/13/2024 7:15:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[Empresa] [varchar](100) NOT NULL,
	[NombreDelRepresentante] [varchar](100) NOT NULL,
	[ApellidosDelRepresentante] [varchar](100) NOT NULL,
	[Cargo] [varchar](100) NOT NULL,
	[FechaDeCreacion] [datetimeoffset](7) NOT NULL,
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Conductor]    Script Date: 11/13/2024 7:15:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conductor](
	[ConductorId] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](100) NOT NULL,
	[Apellidos] [varchar](100) NOT NULL,
	[Telefono] [varchar](30) NOT NULL,
	[FechaDeCreacion] [datetimeoffset](7) NOT NULL,
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_Conductor] PRIMARY KEY CLUSTERED 
(
	[ConductorId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Envio]    Script Date: 11/13/2024 7:15:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Envio](
	[EnvioId] [int] IDENTITY(1,1) NOT NULL,
	[OrdenDeTrabajoId] [int] NOT NULL,
	[FechaDeEntrega] [datetimeoffset](7) NULL,
	[FechaDeCreacion] [datetimeoffset](7) NOT NULL,
	[Estado] [char](1) NOT NULL,
	[ConductorId] [int] NOT NULL,
 CONSTRAINT [PK_Envio] PRIMARY KEY CLUSTERED 
(
	[EnvioId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fabrica]    Script Date: 11/13/2024 7:15:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fabrica](
	[FabricaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[FechaDeCreacion] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Fabrica] PRIMARY KEY CLUSTERED 
(
	[FabricaId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenDeTrabajo]    Script Date: 11/13/2024 7:15:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenDeTrabajo](
	[OrdenDeTrabajoId] [int] IDENTITY(1,1) NOT NULL,
	[FechaEstimadaDeTermino] [datetimeoffset](7) NOT NULL,
	[FechaEstimadaDeEnvio] [datetimeoffset](7) NOT NULL,
	[FechaEstimadaDeEntrega] [datetimeoffset](7) NOT NULL,
	[FechaDeCreacion] [datetimeoffset](7) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[FabricaId] [int] NOT NULL,
	[CodigoDeSeguimiento] [char](10) NOT NULL,
	[Descripcion] [varchar](500) NOT NULL,
	[PesoEnKilos] [decimal](6, 2) NOT NULL,
	[LugarDeEntrega] [varchar](100) NOT NULL,
	[DireccionDeEntrega] [varchar](500) NOT NULL,
	[DireccionDeEntregaLat] [decimal](9, 6) NOT NULL,
	[DireccionDeEntregaLon] [decimal](9, 6) NOT NULL,
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_OrdenDeTrabajo] PRIMARY KEY CLUSTERED 
(
	[OrdenDeTrabajoId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_OrdenDeTrabajo_CodigoDeSeguimiento] UNIQUE NONCLUSTERED 
(
	[CodigoDeSeguimiento] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenPorUsuario]    Script Date: 11/13/2024 7:15:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenPorUsuario](
	[OrdenDeTrabajoId] [int] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[FechaDeCreacion] [datetimeoffset](7) NOT NULL,
	[FechaDeUltimaConsulta] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_OrdenPorUsuario] PRIMARY KEY CLUSTERED 
(
	[OrdenDeTrabajoId] ASC,
	[UsuarioId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RastreoEnTiempoReal]    Script Date: 11/13/2024 7:15:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RastreoEnTiempoReal](
	[RastreoId] [int] IDENTITY(1,1) NOT NULL,
	[EnvioId] [int] NOT NULL,
	[Latitud] [decimal](10, 6) NOT NULL,
	[Longitud] [decimal](10, 6) NOT NULL,
	[FechaDeCreacion] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_RastreoEnTiempoReal] PRIMARY KEY CLUSTERED 
(
	[RastreoId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RefreshToken]    Script Date: 11/13/2024 7:15:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefreshToken](
	[RefreshTokenId] [int] IDENTITY(1,1) NOT NULL,
	[Token] [varchar](50) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[FechaDeExpiracion] [datetime] NOT NULL,
	[EstaRevocada] [bit] NOT NULL,
	[FechaDeCreacion] [datetime] NOT NULL,
	[FechaDeRevocacion] [datetime] NULL,
 CONSTRAINT [PK_RefreshToken] PRIMARY KEY CLUSTERED 
(
	[RefreshTokenId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 11/13/2024 7:15:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[PasswordHash] [varchar](50) NOT NULL,
	[Nombres] [varchar](100) NOT NULL,
	[Apellidos] [varchar](100) NOT NULL,
	[FechaDeCreacion] [datetimeoffset](7) NOT NULL,
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Relationship1]    Script Date: 11/13/2024 7:15:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Relationship1] ON [dbo].[Envio]
(
	[ConductorId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Relationship6]    Script Date: 11/13/2024 7:15:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Relationship6] ON [dbo].[Envio]
(
	[OrdenDeTrabajoId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Relationship3]    Script Date: 11/13/2024 7:15:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Relationship3] ON [dbo].[OrdenDeTrabajo]
(
	[ClienteId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Relationship7]    Script Date: 11/13/2024 7:15:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Relationship7] ON [dbo].[OrdenDeTrabajo]
(
	[FabricaId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Relationship8]    Script Date: 11/13/2024 7:15:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Relationship8] ON [dbo].[RastreoEnTiempoReal]
(
	[EnvioId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente] ADD  DEFAULT ('A') FOR [Estado]
GO
ALTER TABLE [dbo].[Conductor] ADD  DEFAULT ('A') FOR [Estado]
GO
ALTER TABLE [dbo].[Envio] ADD  DEFAULT ('A') FOR [Estado]
GO
ALTER TABLE [dbo].[OrdenDeTrabajo] ADD  DEFAULT ('A') FOR [Estado]
GO
ALTER TABLE [dbo].[Envio]  WITH CHECK ADD  CONSTRAINT [Conduce] FOREIGN KEY([ConductorId])
REFERENCES [dbo].[Conductor] ([ConductorId])
GO
ALTER TABLE [dbo].[Envio] CHECK CONSTRAINT [Conduce]
GO
ALTER TABLE [dbo].[Envio]  WITH CHECK ADD  CONSTRAINT [Enviado] FOREIGN KEY([OrdenDeTrabajoId])
REFERENCES [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId])
GO
ALTER TABLE [dbo].[Envio] CHECK CONSTRAINT [Enviado]
GO
ALTER TABLE [dbo].[OrdenDeTrabajo]  WITH CHECK ADD  CONSTRAINT [Producido] FOREIGN KEY([FabricaId])
REFERENCES [dbo].[Fabrica] ([FabricaId])
GO
ALTER TABLE [dbo].[OrdenDeTrabajo] CHECK CONSTRAINT [Producido]
GO
ALTER TABLE [dbo].[OrdenDeTrabajo]  WITH CHECK ADD  CONSTRAINT [Solicita] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO
ALTER TABLE [dbo].[OrdenDeTrabajo] CHECK CONSTRAINT [Solicita]
GO
ALTER TABLE [dbo].[OrdenPorUsuario]  WITH CHECK ADD  CONSTRAINT [Asignado] FOREIGN KEY([OrdenDeTrabajoId])
REFERENCES [dbo].[OrdenDeTrabajo] ([OrdenDeTrabajoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrdenPorUsuario] CHECK CONSTRAINT [Asignado]
GO
ALTER TABLE [dbo].[OrdenPorUsuario]  WITH CHECK ADD  CONSTRAINT [Sigue] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([UsuarioId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrdenPorUsuario] CHECK CONSTRAINT [Sigue]
GO
ALTER TABLE [dbo].[RastreoEnTiempoReal]  WITH CHECK ADD  CONSTRAINT [Rastreado] FOREIGN KEY([EnvioId])
REFERENCES [dbo].[Envio] ([EnvioId])
GO
ALTER TABLE [dbo].[RastreoEnTiempoReal] CHECK CONSTRAINT [Rastreado]
GO
ALTER TABLE [dbo].[RefreshToken]  WITH CHECK ADD  CONSTRAINT [FK_RefreshToken_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([UsuarioId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RefreshToken] CHECK CONSTRAINT [FK_RefreshToken_Usuario]
GO
ALTER DATABASE [tracking] SET  READ_WRITE 
GO
