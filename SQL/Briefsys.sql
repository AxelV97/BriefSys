CREATE DATABASE [BriefSys]
USE [BriefSys]
GO
/****** Object:  Table [dbo].[Acceso_Usuario]    Script Date: 01/02/2021 20:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acceso_Usuario](
	[IdEmp] [int] NULL,
	[UsuarioID] [varchar](100) NULL,
	[Password] [varchar](150) NULL,
	[Salt] [varchar](100) NULL,
	[FechaModificacion] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Auditoria_Global]    Script Date: 01/02/2021 20:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auditoria_Global](
	[IdHistorico] [int] NULL,
	[TipoDocumento] [varchar](150) NULL,
	[IdDocumento] [varchar](150) NULL,
	[DescripcionMovimiento] [varchar](max) NULL,
	[DescripcionUsuario] [varchar](max) NULL,
	[Cuando] [datetime] NULL,
	[IdQuien] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Catalogo_General]    Script Date: 01/02/2021 20:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Catalogo_General](
	[IdProducto] [varchar](20) NULL,
	[Producto] [varchar](max) NULL,
	[PresentacionInterna] [varchar](100) NULL,
	[Estado] [char](1) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 01/02/2021 20:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento](
	[IdDepartamento] [int] IDENTITY,
	[Clasificacion] [varchar](5) NULL,
	[Descripcion] [varchar](100) NULL,
	[Estado] [char](1) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 01/02/2021 20:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[IdDepartamento] [int] NULL,
	[IdPuesto] [int] NULL,
	[IdEmp] [int] IDENTITY,
	[Ingreso] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado_Detalle]    Script Date: 01/02/2021 20:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado_Detalle](
	[IdEmp] [int],
	[Nombre] [varchar](100) NULL,
	[ApellidoP] [varchar](100) NULL,
	[ApellidoM] [varchar](100) NULL,
	[FechaNac] [date] NULL,
	[Telefono] [varchar](100) NULL,
	[Extension] [varchar](100) NULL,
	[FotografiaDigital] [varbinary](max) NULL,
	[Estado] [char](1) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orden]    Script Date: 01/02/2021 20:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orden](
	[IdOrden] [int] IDENTITY(1,1) NOT NULL,
	[IdRequisicion] [int] NULL,
	[IdProveedor] [varchar](50) NULL,
	[Proveedor] [varchar](max) NULL,
	[FechaElaboracion] [date] NULL,
	[FechaEntrega] [date] NULL,
	[Moneda] [varchar](5) NULL,
	[IdElaboro] [int] NULL,
	[Estado] [char](1) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orden_Archivo]    Script Date: 01/02/2021 20:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orden_Archivo](
	[IdOrden] [int] NULL,
	[NombreArchivo] [varchar](150) NULL,
	[Archivo] [varbinary](max) NULL,
	[FechaSubida] [datetime] NULL,
	[IdQuien] [int] NULL,
	[Estado] [char](1) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orden_Calendario]    Script Date: 01/02/2021 20:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orden_Calendario](
	[IdOrden] [int] NULL,
	[Partida] [int] NULL,
	[Color] [varchar](150) NULL,
	[FechaEntrega] [date] NULL,
	[FechaSugerida] [datetime] NULL,
	[Estado] [char](1) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orden_Detalle]    Script Date: 01/02/2021 20:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orden_Detalle](
	[IdOrden] [int] NULL,
	[CodigoPartida] [int] IDENTITY(1,1) NOT NULL,
	[Partida] [int] NULL,
	[PartidaRequisicion] [int] NULL,
	[IdProducto] [varchar](20) NULL,
	[Producto] [varchar](max) NULL,
	[Cantidad] [decimal](10, 2) NULL,
	[UnidadInterna] [varchar](100) NULL,
	[UnidadExterna] [varchar](100) NULL,
	[Atendido] [bit] NULL,
	[Estado] [char](1) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orden_Recibida]    Script Date: 01/02/2021 20:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orden_Recibida](
	[IdOrden] [int] NULL,
	[FechaRecepcion] [datetime] NULL,
	[CantidadRecibida] [decimal](10, 2) NULL,
	[IdRecibio] [int] NULL,
	[Estado] [char](1) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puesto]    Script Date: 01/02/2021 20:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puesto](
	[IdPuesto] [int] IDENTITY(1,1) NOT NULL,
	[IdDepartamento] [int] NULL,
	[Clasificacion] [varchar](5) NULL,
	[Descripcion] [varchar](100) NULL,
	[Estado] [char](1) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Requisicion]    Script Date: 01/02/2021 20:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requisicion](
	[IdReq] [int] IDENTITY,
	[FechaReq] [datetime] NULL,
	[FechaAprobación] [datetime] NULL,
	[IdElaboro] [int] NULL,
	[Estado] [char](1) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Requisicion_Aprobacion]    Script Date: 01/02/2021 20:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requisicion_Aprobacion](
	[IdReq] [int] NULL,
	[IdAprobo] [int] NULL,
	[CantidadRequisicion] [decimal](10, 2) NULL,
	[CantidadAprobada] [decimal](10, 2) NULL,
	[FechaAprobacion] [datetime] NULL,
	[Estado] [char](1) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Requisicion_Detalle]    Script Date: 01/02/2021 20:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requisicion_Detalle](
	[IdReq] [int] NULL,
	[IdProducto] [varchar](20) NULL,
	[Producto] [varchar](max) NULL,
	[CantidadSolicitada] [decimal](10, 2) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceDesk]    Script Date: 01/02/2021 20:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceDesk](
	[IdTicket] [numeric](9, 0) IDENTITY,
	[FechaInicio] [datetime] NULL,
	[FechaFin] [datetime] NULL,
	[HorasSeguimiento] [decimal](10, 2) NULL,
	[EnTiempo] [nvarchar](100) NULL,
	[Tipo] [nvarchar](300) NULL,
	[Categoria] [nvarchar](300) NULL,
	[Subcategoria] [nvarchar](300) NULL,
	[Prioridad] [int] NULL,
	[Tiempo] [decimal](10, 2) NULL,
	[ReportadoPor] [int] NULL,
	[ReportadoMediante] [varchar](max) NULL,
	[Nota] [varchar](max) NULL,
	[IdEstado] [char](1) NULL,
	[Estado] [varchar](max) NULL,
	[Auditoria] [datetime] NULL,
	[Quien] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceDesk_Detalle]    Script Date: 01/02/2021 20:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceDesk_Detalle](
	[IdTicket] [int] NULL,
	[Nota] [varchar](max) NULL,
	[FechaNota] [datetime] NULL,
	[IdEstadoNota] [char](1) NULL,
	[EstadoNota] [varchar](max) NULL,
	[IdEmpleado] [int] NULL,
	[Auditoria] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
