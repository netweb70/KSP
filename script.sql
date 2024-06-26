USE [master]
GO
/****** Object:  Database [BiblioGestion]    Script Date: dom., 16, jun., 2024 08:09:38 p. m. ******/
CREATE DATABASE [BiblioGestion]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BiblioGestion', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BiblioGestion.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BiblioGestion_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BiblioGestion_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BiblioGestion] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BiblioGestion].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BiblioGestion] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BiblioGestion] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BiblioGestion] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BiblioGestion] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BiblioGestion] SET ARITHABORT OFF 
GO
ALTER DATABASE [BiblioGestion] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BiblioGestion] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BiblioGestion] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BiblioGestion] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BiblioGestion] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BiblioGestion] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BiblioGestion] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BiblioGestion] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BiblioGestion] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BiblioGestion] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BiblioGestion] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BiblioGestion] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BiblioGestion] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BiblioGestion] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BiblioGestion] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BiblioGestion] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BiblioGestion] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BiblioGestion] SET RECOVERY FULL 
GO
ALTER DATABASE [BiblioGestion] SET  MULTI_USER 
GO
ALTER DATABASE [BiblioGestion] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BiblioGestion] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BiblioGestion] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BiblioGestion] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BiblioGestion] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BiblioGestion] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BiblioGestion', N'ON'
GO
ALTER DATABASE [BiblioGestion] SET QUERY_STORE = ON
GO
ALTER DATABASE [BiblioGestion] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BiblioGestion]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: dom., 16, jun., 2024 08:09:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: dom., 16, jun., 2024 08:09:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[idCategoria] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[esActivo] [bit] NULL,
	[fechaRegistro] [datetime] NULL,
 CONSTRAINT [PK__Categori__8A3D240CED1907F1] PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallePrestamo]    Script Date: dom., 16, jun., 2024 08:09:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallePrestamo](
	[idDetallePrestamo] [int] IDENTITY(1,1) NOT NULL,
	[idPrestamo] [int] NULL,
	[idLibro] [int] NULL,
	[cantidad] [int] NULL,
	[devuelta] [int] NULL,
 CONSTRAINT [PK__DetalleV__BFE2843F851DE491] PRIMARY KEY CLUSTERED 
(
	[idDetallePrestamo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libro]    Script Date: dom., 16, jun., 2024 08:09:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libro](
	[idLibro] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](100) NULL,
	[editorial] [varchar](100) NULL,
	[descripcion] [varchar](100) NULL,
	[idCategoria] [int] NULL,
	[stock] [int] NULL,
	[esActivo] [bit] NULL,
	[fechaRegistro] [datetime] NULL,
 CONSTRAINT [PK__Libro__07F4A132B3DE1441] PRIMARY KEY CLUSTERED 
(
	[idLibro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NumeroDocumento]    Script Date: dom., 16, jun., 2024 08:09:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NumeroDocumento](
	[id] [int] NOT NULL,
	[fechaRegistro] [datetime] NULL,
 CONSTRAINT [PK_NumeroDocumento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prestamo]    Script Date: dom., 16, jun., 2024 08:09:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prestamo](
	[idPrestamo] [int] IDENTITY(1,1) NOT NULL,
	[numeroDocumento] [varchar](40) NULL,
	[tipoDocumento] [varchar](50) NULL,
	[fechaRegistro] [datetime] NULL,
	[idUsuario] [int] NULL,
	[documentoCliente] [varchar](40) NULL,
	[nombreCliente] [varchar](40) NULL,
 CONSTRAINT [PK__Prestamo__077D5614D2880592] PRIMARY KEY CLUSTERED 
(
	[idPrestamo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: dom., 16, jun., 2024 08:09:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[idRol] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[esActivo] [bit] NULL,
	[fechaRegistro] [datetime] NULL,
 CONSTRAINT [PK__Rol__3C872F76D60D3150] PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: dom., 16, jun., 2024 08:09:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](40) NULL,
	[correo] [varchar](40) NULL,
	[telefono] [varchar](40) NULL,
	[idRol] [int] NULL,
	[clave] [varchar](40) NULL,
	[esActivo] [bit] NULL,
 CONSTRAINT [PK__Usuario__645723A6E137D226] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240616212339_Initial', N'6.0.0')
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([idCategoria], [descripcion], [esActivo], [fechaRegistro]) VALUES (1, N'Hardware', 1, CAST(N'2024-06-04T08:57:50.280' AS DateTime))
INSERT [dbo].[Categoria] ([idCategoria], [descripcion], [esActivo], [fechaRegistro]) VALUES (2, N'Ciencia Ficcion', 1, CAST(N'2024-06-04T08:57:50.283' AS DateTime))
INSERT [dbo].[Categoria] ([idCategoria], [descripcion], [esActivo], [fechaRegistro]) VALUES (3, N'Clasicas', 1, CAST(N'2024-06-04T08:57:50.283' AS DateTime))
INSERT [dbo].[Categoria] ([idCategoria], [descripcion], [esActivo], [fechaRegistro]) VALUES (4, N'Matematicas', 1, CAST(N'2024-06-04T08:57:50.283' AS DateTime))
INSERT [dbo].[Categoria] ([idCategoria], [descripcion], [esActivo], [fechaRegistro]) VALUES (5, N'Programacion', 1, CAST(N'2024-06-04T08:57:50.283' AS DateTime))
INSERT [dbo].[Categoria] ([idCategoria], [descripcion], [esActivo], [fechaRegistro]) VALUES (6, N'Arte', 1, CAST(N'2024-06-04T08:57:50.283' AS DateTime))
INSERT [dbo].[Categoria] ([idCategoria], [descripcion], [esActivo], [fechaRegistro]) VALUES (7, N'Diseño', 1, CAST(N'2024-06-05T13:02:25.040' AS DateTime))
INSERT [dbo].[Categoria] ([idCategoria], [descripcion], [esActivo], [fechaRegistro]) VALUES (8, N'Leyendas', 1, CAST(N'2024-06-05T16:40:00.117' AS DateTime))
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[DetallePrestamo] ON 

INSERT [dbo].[DetallePrestamo] ([idDetallePrestamo], [idPrestamo], [idLibro], [cantidad], [devuelta]) VALUES (1003, 1003, 10, 2, 2)
INSERT [dbo].[DetallePrestamo] ([idDetallePrestamo], [idPrestamo], [idLibro], [cantidad], [devuelta]) VALUES (1004, 1004, 9, 1, 0)
INSERT [dbo].[DetallePrestamo] ([idDetallePrestamo], [idPrestamo], [idLibro], [cantidad], [devuelta]) VALUES (1010, 1010, 9, 2, 0)
INSERT [dbo].[DetallePrestamo] ([idDetallePrestamo], [idPrestamo], [idLibro], [cantidad], [devuelta]) VALUES (1012, 1012, 5, 1, 1)
SET IDENTITY_INSERT [dbo].[DetallePrestamo] OFF
GO
SET IDENTITY_INSERT [dbo].[Libro] ON 

INSERT [dbo].[Libro] ([idLibro], [codigo], [editorial], [descripcion], [idCategoria], [stock], [esActivo], [fechaRegistro]) VALUES (5, N'101014', N'Nostromo', N'La constelación de Casiopea', 2, 14, 1, CAST(N'2024-06-04T08:57:50.310' AS DateTime))
INSERT [dbo].[Libro] ([idLibro], [codigo], [editorial], [descripcion], [idCategoria], [stock], [esActivo], [fechaRegistro]) VALUES (6, N'101015', N'Nostromo', N'Viaje Septimo', 2, 8, 1, CAST(N'2024-06-04T08:57:50.310' AS DateTime))
INSERT [dbo].[Libro] ([idLibro], [codigo], [editorial], [descripcion], [idCategoria], [stock], [esActivo], [fechaRegistro]) VALUES (8, N'101017', N'Porrua', N'La Iliada', 3, 10, 1, CAST(N'2024-06-04T08:57:50.310' AS DateTime))
INSERT [dbo].[Libro] ([idLibro], [codigo], [editorial], [descripcion], [idCategoria], [stock], [esActivo], [fechaRegistro]) VALUES (9, N'101018', N'Porrua', N'La Odisea', 3, 7, 1, CAST(N'2024-06-04T08:57:50.310' AS DateTime))
INSERT [dbo].[Libro] ([idLibro], [codigo], [editorial], [descripcion], [idCategoria], [stock], [esActivo], [fechaRegistro]) VALUES (10, N'101019', N'Grijalbo', N'Algebra 2', 4, 15, 1, CAST(N'2024-06-04T08:57:50.310' AS DateTime))
SET IDENTITY_INSERT [dbo].[Libro] OFF
GO
INSERT [dbo].[NumeroDocumento] ([id], [fechaRegistro]) VALUES (2, CAST(N'2024-06-16T19:00:24.843' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Prestamo] ON 

INSERT [dbo].[Prestamo] ([idPrestamo], [numeroDocumento], [tipoDocumento], [fechaRegistro], [idUsuario], [documentoCliente], [nombreCliente]) VALUES (1003, N'000004', N'Credencial Escolar', CAST(N'2024-06-06T11:47:58.380' AS DateTime), 1, N'qqqqq', N'peter')
INSERT [dbo].[Prestamo] ([idPrestamo], [numeroDocumento], [tipoDocumento], [fechaRegistro], [idUsuario], [documentoCliente], [nombreCliente]) VALUES (1004, N'000005', N'Credencial Escolar', CAST(N'2024-06-06T20:18:10.750' AS DateTime), 1, N'FSGFSGF45w35rw2DGFD', N'Yorch Arroyo')
INSERT [dbo].[Prestamo] ([idPrestamo], [numeroDocumento], [tipoDocumento], [fechaRegistro], [idUsuario], [documentoCliente], [nombreCliente]) VALUES (1010, N'000011', N'Boleta', CAST(N'2024-06-12T11:55:01.680' AS DateTime), 1, N'GGGGHHHHWWWW', N'Daniel Villas')
INSERT [dbo].[Prestamo] ([idPrestamo], [numeroDocumento], [tipoDocumento], [fechaRegistro], [idUsuario], [documentoCliente], [nombreCliente]) VALUES (1012, N'000002', N'Credencial Escolar', CAST(N'2024-06-16T19:00:47.687' AS DateTime), 1, N'PRUEBADOCCTE', N'Alberto Ruiz Zarate')
SET IDENTITY_INSERT [dbo].[Prestamo] OFF
GO
SET IDENTITY_INSERT [dbo].[Rol] ON 

INSERT [dbo].[Rol] ([idRol], [descripcion], [esActivo], [fechaRegistro]) VALUES (1, N'Administrador', 1, CAST(N'2024-06-04T08:57:50.247' AS DateTime))
INSERT [dbo].[Rol] ([idRol], [descripcion], [esActivo], [fechaRegistro]) VALUES (2, N'Empleado', 1, CAST(N'2024-06-04T08:57:50.247' AS DateTime))
SET IDENTITY_INSERT [dbo].[Rol] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([idUsuario], [nombre], [correo], [telefono], [idRol], [clave], [esActivo]) VALUES (1, N'admin', N'admin@gmail.com', N'444333', 1, N'123', 1)
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [correo], [telefono], [idRol], [clave], [esActivo]) VALUES (2, N'user', N'user@gmail.com', N'555666', 2, N'123', 1)
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [correo], [telefono], [idRol], [clave], [esActivo]) VALUES (1003, N'dave', N'dd.valle@gmail.com', N'242342', 2, N'123', 1)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
/****** Object:  Index [IX_DetallePrestamo_idLibro]    Script Date: dom., 16, jun., 2024 08:09:39 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_DetallePrestamo_idLibro] ON [dbo].[DetallePrestamo]
(
	[idLibro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DetallePrestamo_idPrestamo]    Script Date: dom., 16, jun., 2024 08:09:39 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_DetallePrestamo_idPrestamo] ON [dbo].[DetallePrestamo]
(
	[idPrestamo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Libro_idCategoria]    Script Date: dom., 16, jun., 2024 08:09:39 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Libro_idCategoria] ON [dbo].[Libro]
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Prestamo_idUsuario]    Script Date: dom., 16, jun., 2024 08:09:39 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Prestamo_idUsuario] ON [dbo].[Prestamo]
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Usuario_idRol]    Script Date: dom., 16, jun., 2024 08:09:39 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Usuario_idRol] ON [dbo].[Usuario]
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categoria] ADD  DEFAULT (getdate()) FOR [fechaRegistro]
GO
ALTER TABLE [dbo].[Libro] ADD  DEFAULT (getdate()) FOR [fechaRegistro]
GO
ALTER TABLE [dbo].[NumeroDocumento] ADD  DEFAULT (getdate()) FOR [fechaRegistro]
GO
ALTER TABLE [dbo].[Prestamo] ADD  DEFAULT (getdate()) FOR [fechaRegistro]
GO
ALTER TABLE [dbo].[Rol] ADD  DEFAULT (getdate()) FOR [fechaRegistro]
GO
ALTER TABLE [dbo].[DetallePrestamo]  WITH CHECK ADD  CONSTRAINT [FK__DetalleVe__idPro__60A75C0F] FOREIGN KEY([idLibro])
REFERENCES [dbo].[Libro] ([idLibro])
GO
ALTER TABLE [dbo].[DetallePrestamo] CHECK CONSTRAINT [FK__DetalleVe__idPro__60A75C0F]
GO
ALTER TABLE [dbo].[DetallePrestamo]  WITH CHECK ADD  CONSTRAINT [FK__DetalleVe__idVen__5FB337D6] FOREIGN KEY([idPrestamo])
REFERENCES [dbo].[Prestamo] ([idPrestamo])
GO
ALTER TABLE [dbo].[DetallePrestamo] CHECK CONSTRAINT [FK__DetalleVe__idVen__5FB337D6]
GO
ALTER TABLE [dbo].[Libro]  WITH CHECK ADD  CONSTRAINT [FK__Libro__idCate__5812160E] FOREIGN KEY([idCategoria])
REFERENCES [dbo].[Categoria] ([idCategoria])
GO
ALTER TABLE [dbo].[Libro] CHECK CONSTRAINT [FK__Libro__idCate__5812160E]
GO
ALTER TABLE [dbo].[Prestamo]  WITH CHECK ADD  CONSTRAINT [FK__Prestamo__idUsuario__5CD6CB2B] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Prestamo] CHECK CONSTRAINT [FK__Prestamo__idUsuario__5CD6CB2B]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK__Usuario__idRol__3A81B327] FOREIGN KEY([idRol])
REFERENCES [dbo].[Rol] ([idRol])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK__Usuario__idRol__3A81B327]
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarDevolucion]    Script Date: dom., 16, jun., 2024 08:09:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_RegistrarDevolucion](
@IdDetallePrestamo int,
@Devuelta int
)
as
begin
	declare @IdLibro int

	BEGIN TRY
		BEGIN TRANSACTION

			set @IdLibro = (select IdLibro from DetallePrestamo where IdDetallePrestamo = @IdDetallePrestamo);

			update d set d.devuelta = @Devuelta from DetallePrestamo d where d.IdDetallePrestamo = @IdDetallePrestamo;
			update l set l.Stock = l.Stock + @Devuelta from Libro l where l.IdLibro = @IdLibro;

		COMMIT

	END TRY
	BEGIN CATCH
		ROLLBACK
	END CATCH

end

GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarPrestamo]    Script Date: dom., 16, jun., 2024 08:09:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_RegistrarPrestamo](
@documentoCliente varchar(40),
@nombreCliente varchar(40),
@tipoDocumento varchar(50),
@idUsuario int,
@libro xml,
@nroDocumento varchar(6) output
)
as
begin
	declare @nrodocgenerado varchar(6)
	declare @nro int
	declare @idprestamo int

	declare @tblibro table (
	IdLibro int,
	Cantidad int
	)

	BEGIN TRY
		BEGIN TRANSACTION

			insert into @tblibro(IdLibro,Cantidad)
			select 
				nodo.elemento.value('IdLibro[1]','int') as IdLibro, 
				nodo.elemento.value('Cantidad[1]','int') as Cantidad
			from @libro.nodes('Libros/Item') nodo(elemento)

			update NumeroDocumento set
			@nro = id= id+1
			
			set @nrodocgenerado =  RIGHT('000000' + convert(varchar(max),@nro),6)

			insert into Prestamo(numeroDocumento,tipoDocumento,idUsuario,documentoCliente,nombreCliente) 
			values (@nrodocgenerado,@tipoDocumento,@idUsuario,@documentoCliente,@nombreCliente)


			set @idprestamo = SCOPE_IDENTITY()

			insert into DetallePrestamo(IdPrestamo,IdLibro,cantidad) 
			select @idprestamo,IdLibro,Cantidad from @tblibro

			update p set p.Stock = p.Stock - dv.Cantidad from Libro p
			inner join @tblibro dv on dv.IdLibro = p.IdLibro

		COMMIT
		set @nroDocumento = @nrodocgenerado

	END TRY
	BEGIN CATCH
		ROLLBACK
		set @nroDocumento = ''
	END CATCH

end

GO
USE [master]
GO
ALTER DATABASE [BiblioGestion] SET  READ_WRITE 
GO
