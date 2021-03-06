USE [master]
GO
/****** Object:  Database [DBSistemaVentas]    Script Date: 10/8/2016 8:59:10 AM ******/
CREATE DATABASE [DBSistemaVentas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBSistemaVentas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DBSistemaVentas.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DBSistemaVentas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DBSistemaVentas_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DBSistemaVentas] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBSistemaVentas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBSistemaVentas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBSistemaVentas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBSistemaVentas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBSistemaVentas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBSistemaVentas] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBSistemaVentas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBSistemaVentas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBSistemaVentas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBSistemaVentas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBSistemaVentas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBSistemaVentas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBSistemaVentas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBSistemaVentas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBSistemaVentas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBSistemaVentas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBSistemaVentas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBSistemaVentas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBSistemaVentas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBSistemaVentas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBSistemaVentas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBSistemaVentas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBSistemaVentas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBSistemaVentas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBSistemaVentas] SET  MULTI_USER 
GO
ALTER DATABASE [DBSistemaVentas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBSistemaVentas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBSistemaVentas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBSistemaVentas] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DBSistemaVentas] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DBSistemaVentas]
GO
/****** Object:  Table [dbo].[articulo]    Script Date: 10/8/2016 8:59:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[articulo](
	[idArticulo] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](1024) NULL,
	[imagen] [image] NULL,
	[idCategoria] [int] NOT NULL,
	[idPresentacion] [int] NOT NULL,
 CONSTRAINT [PK_articulo] PRIMARY KEY CLUSTERED 
(
	[idArticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 10/8/2016 8:59:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[categoria](
	[idCategoria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](255) NOT NULL,
 CONSTRAINT [PK_categoria] PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 10/8/2016 8:59:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cliente](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellidos] [varchar](40) NULL,
	[sexo] [varchar](1) NULL,
	[fechaNacimiento] [date] NULL,
	[RFC] [varchar](20) NOT NULL,
	[direccion] [varchar](100) NULL,
	[telefono] [varchar](10) NULL,
	[email] [varchar](70) NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[detalleIngreso]    Script Date: 10/8/2016 8:59:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalleIngreso](
	[idDetalleIngreso] [int] IDENTITY(1,1) NOT NULL,
	[idIngreso] [int] NOT NULL,
	[idArticulo] [int] NOT NULL,
	[precioCompra] [money] NOT NULL,
	[precioVenta] [money] NOT NULL,
	[stockInicial] [int] NOT NULL,
	[stockActual] [int] NOT NULL,
	[fechaProduccion] [date] NOT NULL,
	[fechaCaducidad] [date] NOT NULL,
 CONSTRAINT [PK_detalleIngreso] PRIMARY KEY CLUSTERED 
(
	[idDetalleIngreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[detalleVenta]    Script Date: 10/8/2016 8:59:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalleVenta](
	[idDetalleVenta] [int] IDENTITY(1,1) NOT NULL,
	[idVenta] [int] NOT NULL,
	[idDetalleIngreso] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precioVenta] [money] NOT NULL,
	[descuento] [money] NOT NULL,
 CONSTRAINT [PK_detalleVenta] PRIMARY KEY CLUSTERED 
(
	[idDetalleVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ingreso]    Script Date: 10/8/2016 8:59:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ingreso](
	[idIngreso] [int] IDENTITY(1,1) NOT NULL,
	[idTrabajador] [int] NOT NULL,
	[idProveedor] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[tipoComprobante] [varchar](20) NOT NULL,
	[serie] [varchar](4) NOT NULL,
	[correlativo] [varchar](7) NOT NULL,
	[iva] [decimal](4, 2) NOT NULL,
 CONSTRAINT [PK_ingreso] PRIMARY KEY CLUSTERED 
(
	[idIngreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[presentacion]    Script Date: 10/8/2016 8:59:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[presentacion](
	[idPresentacion] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[descripcion] [varchar](255) NULL,
 CONSTRAINT [PK_presentacion] PRIMARY KEY CLUSTERED 
(
	[idPresentacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 10/8/2016 8:59:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[proveedor](
	[idProveedor] [int] IDENTITY(1,1) NOT NULL,
	[razonSocial] [varchar](50) NOT NULL,
	[sectorComercial] [varchar](50) NOT NULL,
	[RFC] [varchar](50) NOT NULL,
	[direccion] [varchar](100) NULL,
	[telefono] [varchar](10) NULL,
	[url] [varchar](100) NULL,
 CONSTRAINT [PK_proveedor] PRIMARY KEY CLUSTERED 
(
	[idProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[trabajador]    Script Date: 10/8/2016 8:59:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[trabajador](
	[idTrabajador] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[apellidos] [nchar](50) NOT NULL,
	[sexo] [nchar](1) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[numeroDocumento] [nchar](13) NOT NULL,
	[direccion] [nchar](100) NULL,
	[telefono] [varchar](10) NULL,
	[email] [varchar](50) NULL,
	[usuario] [varchar](20) NOT NULL,
	[acceso] [varchar](20) NOT NULL,
	[password] [varchar](20) NOT NULL,
 CONSTRAINT [PK_trabajador] PRIMARY KEY CLUSTERED 
(
	[idTrabajador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[venta]    Script Date: 10/8/2016 8:59:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[venta](
	[idVenta] [int] IDENTITY(1,1) NOT NULL,
	[idCliente] [int] NOT NULL,
	[idTrabajador] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[tipoComprobante] [varchar](20) NOT NULL,
	[serie] [varchar](4) NOT NULL,
	[correlativo] [varchar](7) NOT NULL,
	[iva] [decimal](4, 2) NOT NULL,
 CONSTRAINT [PK_venta] PRIMARY KEY CLUSTERED 
(
	[idVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[articulo]  WITH CHECK ADD  CONSTRAINT [FK_articulo_categoria] FOREIGN KEY([idCategoria])
REFERENCES [dbo].[categoria] ([idCategoria])
GO
ALTER TABLE [dbo].[articulo] CHECK CONSTRAINT [FK_articulo_categoria]
GO
ALTER TABLE [dbo].[articulo]  WITH CHECK ADD  CONSTRAINT [FK_articulo_presentacion] FOREIGN KEY([idPresentacion])
REFERENCES [dbo].[presentacion] ([idPresentacion])
GO
ALTER TABLE [dbo].[articulo] CHECK CONSTRAINT [FK_articulo_presentacion]
GO
ALTER TABLE [dbo].[detalleIngreso]  WITH CHECK ADD  CONSTRAINT [FK_detalleIngreso_articulo] FOREIGN KEY([idArticulo])
REFERENCES [dbo].[articulo] ([idArticulo])
GO
ALTER TABLE [dbo].[detalleIngreso] CHECK CONSTRAINT [FK_detalleIngreso_articulo]
GO
ALTER TABLE [dbo].[detalleIngreso]  WITH CHECK ADD  CONSTRAINT [FK_detalleIngreso_ingreso] FOREIGN KEY([idIngreso])
REFERENCES [dbo].[ingreso] ([idIngreso])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalleIngreso] CHECK CONSTRAINT [FK_detalleIngreso_ingreso]
GO
ALTER TABLE [dbo].[detalleVenta]  WITH CHECK ADD  CONSTRAINT [FK_detalleVenta_detalleIngreso] FOREIGN KEY([idDetalleIngreso])
REFERENCES [dbo].[detalleIngreso] ([idDetalleIngreso])
GO
ALTER TABLE [dbo].[detalleVenta] CHECK CONSTRAINT [FK_detalleVenta_detalleIngreso]
GO
ALTER TABLE [dbo].[detalleVenta]  WITH CHECK ADD  CONSTRAINT [FK_detalleVenta_venta] FOREIGN KEY([idVenta])
REFERENCES [dbo].[venta] ([idVenta])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalleVenta] CHECK CONSTRAINT [FK_detalleVenta_venta]
GO
ALTER TABLE [dbo].[ingreso]  WITH CHECK ADD  CONSTRAINT [FK_ingreso_proveedor] FOREIGN KEY([idProveedor])
REFERENCES [dbo].[proveedor] ([idProveedor])
GO
ALTER TABLE [dbo].[ingreso] CHECK CONSTRAINT [FK_ingreso_proveedor]
GO
ALTER TABLE [dbo].[ingreso]  WITH CHECK ADD  CONSTRAINT [FK_ingreso_trabajador] FOREIGN KEY([idTrabajador])
REFERENCES [dbo].[trabajador] ([idTrabajador])
GO
ALTER TABLE [dbo].[ingreso] CHECK CONSTRAINT [FK_ingreso_trabajador]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [FK_venta_cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[cliente] ([idCliente])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [FK_venta_cliente]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [FK_venta_trabajador] FOREIGN KEY([idTrabajador])
REFERENCES [dbo].[trabajador] ([idTrabajador])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [FK_venta_trabajador]
GO
USE [master]
GO
ALTER DATABASE [DBSistemaVentas] SET  READ_WRITE 
GO
