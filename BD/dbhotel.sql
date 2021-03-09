USE [dbhotelsm]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 08/03/2021 10:31:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[idcliente] [int] IDENTITY(1,1) NOT NULL,
	[tipo_documento] [varchar](20) NOT NULL,
	[numero_documento] [varchar](20) NOT NULL,
	[nombres] [varchar](40) NOT NULL,
	[apellidos] [varchar](40) NOT NULL,
	[direccion] [varchar](150) NOT NULL,
	[telefono] [varchar](15) NOT NULL,
	[email] [varchar](45) NOT NULL,
	[estado] [varchar](1) NOT NULL,
 CONSTRAINT [PK_CLIENTE] PRIMARY KEY CLUSTERED 
(
	[idcliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[consumo]    Script Date: 08/03/2021 10:31:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[consumo](
	[idconsumo] [int] IDENTITY(1,1) NOT NULL,
	[idreserva] [int] NOT NULL,
	[idproducto] [int] NOT NULL,
	[cantidad] [decimal](7, 2) NOT NULL,
	[precio_venta] [decimal](7, 2) NOT NULL,
	[estado] [varchar](1) NOT NULL,
 CONSTRAINT [PK_CONSUMO] PRIMARY KEY CLUSTERED 
(
	[idconsumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[habitacion]    Script Date: 08/03/2021 10:31:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[habitacion](
	[idhabitacion] [int] IDENTITY(1,1) NOT NULL,
	[numero] [varchar](4) NOT NULL,
	[piso] [varchar](4) NOT NULL,
	[descripcion] [varchar](200) NOT NULL,
	[caracteristicas] [varchar](200) NOT NULL,
	[precio_diario] [decimal](7, 2) NOT NULL,
	[estado] [varchar](1) NOT NULL,
	[idtipo_habitacion] [int] NOT NULL,
 CONSTRAINT [PK_HABITACION] PRIMARY KEY CLUSTERED 
(
	[idhabitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pago]    Script Date: 08/03/2021 10:31:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pago](
	[idpago] [int] IDENTITY(1,1) NOT NULL,
	[idreserva] [int] NOT NULL,
	[tipo_comprobante] [varchar](20) NOT NULL,
	[num_comprobante] [varchar](12) NOT NULL,
	[igv] [decimal](4, 2) NOT NULL,
	[total_pago] [decimal](9, 2) NOT NULL,
	[fecha_emision] [date] NOT NULL,
	[fecha_pago] [date] NOT NULL,
	[estado] [varchar](1) NOT NULL,
 CONSTRAINT [PK_PAGO] PRIMARY KEY CLUSTERED 
(
	[idpago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[producto]    Script Date: 08/03/2021 10:31:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto](
	[idproducto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](200) NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio] [decimal](7, 2) NOT NULL,
	[estado] [varchar](1) NOT NULL,
 CONSTRAINT [PK_PRODUCTO] PRIMARY KEY CLUSTERED 
(
	[idproducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reportes]    Script Date: 08/03/2021 10:31:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reportes](
	[idreportes] [int] IDENTITY(1,1) NOT NULL,
	[idpago] [int] NOT NULL,
	[idconsumo] [int] NOT NULL,
	[idtrabajador] [int] NOT NULL,
	[idcliente] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_REPORTES] PRIMARY KEY CLUSTERED 
(
	[idreportes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reserva]    Script Date: 08/03/2021 10:31:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reserva](
	[idreserva] [int] IDENTITY(1,1) NOT NULL,
	[idhabitacion] [int] NOT NULL,
	[idcliente] [int] NOT NULL,
	[idtrabajador] [int] NOT NULL,
	[tipo_reserva] [varchar](30) NOT NULL,
	[fecha_ingreso] [date] NOT NULL,
	[fecha_salida] [date] NOT NULL,
	[costo_alojamiento] [decimal](7, 2) NOT NULL,
	[observacion] [varchar](255) NOT NULL,
	[estado] [varchar](1) NOT NULL,
 CONSTRAINT [PK_RESERVA] PRIMARY KEY CLUSTERED 
(
	[idreserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_habitacion]    Script Date: 08/03/2021 10:31:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_habitacion](
	[idtipo_habitacion] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](200) NOT NULL,
	[estado] [varchar](1) NOT NULL,
 CONSTRAINT [PK_TIPO_HABITACION] PRIMARY KEY CLUSTERED 
(
	[idtipo_habitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_trabajador]    Script Date: 08/03/2021 10:31:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_trabajador](
	[idtipo_trabajador] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](200) NOT NULL,
	[estado] [varchar](1) NOT NULL,
 CONSTRAINT [PK_TIPO_TRABAJADOR] PRIMARY KEY CLUSTERED 
(
	[idtipo_trabajador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[trabajador]    Script Date: 08/03/2021 10:31:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trabajador](
	[idtrabajador] [int] IDENTITY(1,1) NOT NULL,
	[tipo_documento] [varchar](20) NOT NULL,
	[numero_documento] [varchar](20) NOT NULL,
	[nombres] [varchar](40) NOT NULL,
	[apellidos] [varchar](40) NOT NULL,
	[direccion] [varchar](150) NOT NULL,
	[telefono] [varchar](15) NOT NULL,
	[email] [varchar](45) NOT NULL,
	[sueldo] [decimal](7, 2) NOT NULL,
	[codigo] [varchar](20) NOT NULL,
	[password] [varchar](20) NOT NULL,
	[estado] [varchar](1) NOT NULL,
	[idtipo_trabajador] [int] NOT NULL,
 CONSTRAINT [PK_TRABAJADOR] PRIMARY KEY CLUSTERED 
(
	[idtrabajador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[cliente] ON 

INSERT [dbo].[cliente] ([idcliente], [tipo_documento], [numero_documento], [nombres], [apellidos], [direccion], [telefono], [email], [estado]) VALUES (1, N'DNI', N'71321367', N'Jorge Luis', N'Mamani Maquera ', N'Villa Inclan Mz. 91 Lt. 8', N'925391658', N'guitarrista_luis14@hotmail.com', N'A')
INSERT [dbo].[cliente] ([idcliente], [tipo_documento], [numero_documento], [nombres], [apellidos], [direccion], [telefono], [email], [estado]) VALUES (2, N'DNI', N'72314658', N'Marko ', N'Rivas', N'Av Bolognesi', N'921458792', N'marko@gmail.com', N'A')
INSERT [dbo].[cliente] ([idcliente], [tipo_documento], [numero_documento], [nombres], [apellidos], [direccion], [telefono], [email], [estado]) VALUES (3, N'DNI', N'712814652', N'Andre', N'Reinoso', N'Pocollay #514', N'921462514', N'andre@gmail.com', N'A')
INSERT [dbo].[cliente] ([idcliente], [tipo_documento], [numero_documento], [nombres], [apellidos], [direccion], [telefono], [email], [estado]) VALUES (4, N'DNI', N'71428952', N'Miguel', N'Flores', N'Av. Bacigalupo', N'985146254', N'miguel@upt.pe', N'A')
INSERT [dbo].[cliente] ([idcliente], [tipo_documento], [numero_documento], [nombres], [apellidos], [direccion], [telefono], [email], [estado]) VALUES (5, N'DNI', N'71841231', N'Guido', N'Pacsi', N'Ciudad Nueva', N'982147521', N'guido@hotmail.com', N'A')
INSERT [dbo].[cliente] ([idcliente], [tipo_documento], [numero_documento], [nombres], [apellidos], [direccion], [telefono], [email], [estado]) VALUES (6, N'DNI', N'71452847', N'Allison', N'Chino', N'Ilo', N'921452361', N'allison@gmail.com', N'A')
SET IDENTITY_INSERT [dbo].[cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[consumo] ON 

INSERT [dbo].[consumo] ([idconsumo], [idreserva], [idproducto], [cantidad], [precio_venta], [estado]) VALUES (1, 2, 2, CAST(1.00 AS Decimal(7, 2)), CAST(2.00 AS Decimal(7, 2)), N'P')
SET IDENTITY_INSERT [dbo].[consumo] OFF
GO
SET IDENTITY_INSERT [dbo].[habitacion] ON 

INSERT [dbo].[habitacion] ([idhabitacion], [numero], [piso], [descripcion], [caracteristicas], [precio_diario], [estado], [idtipo_habitacion]) VALUES (1, N'101', N'1', N'1 Cama de 1 ½ plz plazas y media', N' Wi-fi, Baño Privado, No incluye desayune', CAST(40.00 AS Decimal(7, 2)), N'3', 1)
INSERT [dbo].[habitacion] ([idhabitacion], [numero], [piso], [descripcion], [caracteristicas], [precio_diario], [estado], [idtipo_habitacion]) VALUES (2, N'102', N'1', N'1 Cama de 1 plazas y media', N'Wi-fi, Baño Privado con tina y agua caliente, Tv con cable con mas de 80 canales.', CAST(70.00 AS Decimal(7, 2)), N'4', 2)
SET IDENTITY_INSERT [dbo].[habitacion] OFF
GO
SET IDENTITY_INSERT [dbo].[pago] ON 

INSERT [dbo].[pago] ([idpago], [idreserva], [tipo_comprobante], [num_comprobante], [igv], [total_pago], [fecha_emision], [fecha_pago], [estado]) VALUES (1, 2, N'Factura', N'0001', CAST(0.18 AS Decimal(4, 2)), CAST(40.00 AS Decimal(9, 2)), CAST(N'2021-03-09' AS Date), CAST(N'0001-01-01' AS Date), N'2')
SET IDENTITY_INSERT [dbo].[pago] OFF
GO
SET IDENTITY_INSERT [dbo].[producto] ON 

INSERT [dbo].[producto] ([idproducto], [nombre], [descripcion], [cantidad], [precio], [estado]) VALUES (1, N'Gaseosa', N'Productos de Hotel', 10, CAST(1.00 AS Decimal(7, 2)), N'A')
INSERT [dbo].[producto] ([idproducto], [nombre], [descripcion], [cantidad], [precio], [estado]) VALUES (2, N'Agua', N'Productos de Hotel', 11, CAST(2.00 AS Decimal(7, 2)), N'A')
INSERT [dbo].[producto] ([idproducto], [nombre], [descripcion], [cantidad], [precio], [estado]) VALUES (3, N'Galletas', N'Productos de Hotel', 12, CAST(2.00 AS Decimal(7, 2)), N'A')
SET IDENTITY_INSERT [dbo].[producto] OFF
GO
SET IDENTITY_INSERT [dbo].[reserva] ON 

INSERT [dbo].[reserva] ([idreserva], [idhabitacion], [idcliente], [idtrabajador], [tipo_reserva], [fecha_ingreso], [fecha_salida], [costo_alojamiento], [observacion], [estado]) VALUES (2, 2, 6, 3, N'Online', CAST(N'2021-03-09' AS Date), CAST(N'2021-03-10' AS Date), CAST(40.00 AS Decimal(7, 2)), N'coca  cola', N'3')
INSERT [dbo].[reserva] ([idreserva], [idhabitacion], [idcliente], [idtrabajador], [tipo_reserva], [fecha_ingreso], [fecha_salida], [costo_alojamiento], [observacion], [estado]) VALUES (3, 2, 2, 2, N'Presencial', CAST(N'0001-01-01' AS Date), CAST(N'0001-01-01' AS Date), CAST(25.00 AS Decimal(7, 2)), N'Ninguna', N'2')
SET IDENTITY_INSERT [dbo].[reserva] OFF
GO
SET IDENTITY_INSERT [dbo].[tipo_habitacion] ON 

INSERT [dbo].[tipo_habitacion] ([idtipo_habitacion], [descripcion], [estado]) VALUES (1, N'Habitacion Simple Estandar', N'A')
INSERT [dbo].[tipo_habitacion] ([idtipo_habitacion], [descripcion], [estado]) VALUES (2, N'Habitacion Simple Especial', N'A')
INSERT [dbo].[tipo_habitacion] ([idtipo_habitacion], [descripcion], [estado]) VALUES (3, N' Habitacion Simple Premium Santa Maria', N'A')
INSERT [dbo].[tipo_habitacion] ([idtipo_habitacion], [descripcion], [estado]) VALUES (4, N'Habitacion Doble Estandar', N'A')
INSERT [dbo].[tipo_habitacion] ([idtipo_habitacion], [descripcion], [estado]) VALUES (5, N'Habitacion Doble Especial', N'A')
INSERT [dbo].[tipo_habitacion] ([idtipo_habitacion], [descripcion], [estado]) VALUES (6, N'Habitacion Doble Premium Santa Maria', N'A')
INSERT [dbo].[tipo_habitacion] ([idtipo_habitacion], [descripcion], [estado]) VALUES (7, N'Habitacion Matrimonial Estandar', N'A')
INSERT [dbo].[tipo_habitacion] ([idtipo_habitacion], [descripcion], [estado]) VALUES (8, N'Habitacion Matrimonial Especial', N'A')
INSERT [dbo].[tipo_habitacion] ([idtipo_habitacion], [descripcion], [estado]) VALUES (9, N'Habitacion Matrimonial Premium Santa Maria', N'A')
SET IDENTITY_INSERT [dbo].[tipo_habitacion] OFF
GO
SET IDENTITY_INSERT [dbo].[tipo_trabajador] ON 

INSERT [dbo].[tipo_trabajador] ([idtipo_trabajador], [descripcion], [estado]) VALUES (1, N'Administrador', N'A')
INSERT [dbo].[tipo_trabajador] ([idtipo_trabajador], [descripcion], [estado]) VALUES (2, N'Recepcionista', N'A')
INSERT [dbo].[tipo_trabajador] ([idtipo_trabajador], [descripcion], [estado]) VALUES (3, N'Cajero', N'A')
INSERT [dbo].[tipo_trabajador] ([idtipo_trabajador], [descripcion], [estado]) VALUES (4, N'Invitado', N'A')
SET IDENTITY_INSERT [dbo].[tipo_trabajador] OFF
GO
SET IDENTITY_INSERT [dbo].[trabajador] ON 

INSERT [dbo].[trabajador] ([idtrabajador], [tipo_documento], [numero_documento], [nombres], [apellidos], [direccion], [telefono], [email], [sueldo], [codigo], [password], [estado], [idtipo_trabajador]) VALUES (1, N'DNI', N'72567658', N'YN', N'Catari ', N'AS.24 DE JUNIO', N'955766034', N'admin@upt.pe', CAST(200.00 AS Decimal(7, 2)), N'12345', N'12345', N'A', 1)
INSERT [dbo].[trabajador] ([idtrabajador], [tipo_documento], [numero_documento], [nombres], [apellidos], [direccion], [telefono], [email], [sueldo], [codigo], [password], [estado], [idtipo_trabajador]) VALUES (2, N'DNI', N'78689657', N'Rafael', N'Callata Flores', N'Aso. Begonias', N'900861', N'rafael@upt.pe', CAST(800.00 AS Decimal(7, 2)), N'2016055214', N'123456', N'A', 2)
INSERT [dbo].[trabajador] ([idtrabajador], [tipo_documento], [numero_documento], [nombres], [apellidos], [direccion], [telefono], [email], [sueldo], [codigo], [password], [estado], [idtipo_trabajador]) VALUES (3, N'DNI', N'11111111', N'Invitado', N'invitado', N'invitado', N'123456789', N'invitado@gmail.com', CAST(10.00 AS Decimal(7, 2)), N'12345', N'123456', N'A', 4)
SET IDENTITY_INSERT [dbo].[trabajador] OFF
GO
ALTER TABLE [dbo].[consumo]  WITH CHECK ADD  CONSTRAINT [consumo_fk0] FOREIGN KEY([idreserva])
REFERENCES [dbo].[reserva] ([idreserva])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[consumo] CHECK CONSTRAINT [consumo_fk0]
GO
ALTER TABLE [dbo].[consumo]  WITH CHECK ADD  CONSTRAINT [consumo_fk1] FOREIGN KEY([idproducto])
REFERENCES [dbo].[producto] ([idproducto])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[consumo] CHECK CONSTRAINT [consumo_fk1]
GO
ALTER TABLE [dbo].[habitacion]  WITH CHECK ADD  CONSTRAINT [habitacion_fk0] FOREIGN KEY([idtipo_habitacion])
REFERENCES [dbo].[tipo_habitacion] ([idtipo_habitacion])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[habitacion] CHECK CONSTRAINT [habitacion_fk0]
GO
ALTER TABLE [dbo].[pago]  WITH CHECK ADD  CONSTRAINT [pago_fk0] FOREIGN KEY([idreserva])
REFERENCES [dbo].[reserva] ([idreserva])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[pago] CHECK CONSTRAINT [pago_fk0]
GO
ALTER TABLE [dbo].[reportes]  WITH CHECK ADD  CONSTRAINT [reportes_fk0] FOREIGN KEY([idpago])
REFERENCES [dbo].[pago] ([idpago])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[reportes] CHECK CONSTRAINT [reportes_fk0]
GO
ALTER TABLE [dbo].[reserva]  WITH CHECK ADD  CONSTRAINT [reserva_fk0] FOREIGN KEY([idhabitacion])
REFERENCES [dbo].[habitacion] ([idhabitacion])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[reserva] CHECK CONSTRAINT [reserva_fk0]
GO
ALTER TABLE [dbo].[reserva]  WITH CHECK ADD  CONSTRAINT [reserva_fk1] FOREIGN KEY([idcliente])
REFERENCES [dbo].[cliente] ([idcliente])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[reserva] CHECK CONSTRAINT [reserva_fk1]
GO
ALTER TABLE [dbo].[reserva]  WITH CHECK ADD  CONSTRAINT [reserva_fk2] FOREIGN KEY([idtrabajador])
REFERENCES [dbo].[trabajador] ([idtrabajador])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[reserva] CHECK CONSTRAINT [reserva_fk2]
GO
ALTER TABLE [dbo].[trabajador]  WITH CHECK ADD  CONSTRAINT [trabajador_fk0] FOREIGN KEY([idtipo_trabajador])
REFERENCES [dbo].[tipo_trabajador] ([idtipo_trabajador])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[trabajador] CHECK CONSTRAINT [trabajador_fk0]
GO
