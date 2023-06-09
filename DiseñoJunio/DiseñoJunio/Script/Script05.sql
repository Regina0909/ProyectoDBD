USE [ClinicaBase]
GO
/****** Object:  Table [dbo].[Consulta]    Script Date: 05/06/2023 14:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consulta](
	[consultaID] [int] IDENTITY(1,1) NOT NULL,
	[cantServicios] [int] NOT NULL,
	[fechaConsulta] [datetime] NOT NULL,
	[pacienteID] [int] NULL,
	[servicioID] [int] NULL,
	[deleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[consultaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 05/06/2023 14:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa](
	[empresaID] [int] IDENTITY(1,1) NOT NULL,
	[nombreEmpresa] [nvarchar](50) NOT NULL,
	[direccionEmpresa] [nvarchar](100) NOT NULL,
	[numRucEmpresa] [int] NOT NULL,
	[correoEmpresa] [nvarchar](50) NULL,
	[telEmpresa] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[empresaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 05/06/2023 14:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[facturaID] [int] IDENTITY(1,1) NOT NULL,
	[fechaFactura] [datetime] NULL,
	[totalFactura] [decimal](10, 2) NOT NULL,
	[consultaID] [int] NULL,
	[deleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[facturaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paciente]    Script Date: 05/06/2023 14:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paciente](
	[pacienteID] [int] IDENTITY(1,1) NOT NULL,
	[nombrePaciente] [nvarchar](50) NOT NULL,
	[apellidoPaciente] [nvarchar](50) NOT NULL,
	[fechaRegistro] [datetime] NULL,
	[telefono] [nvarchar](10) NULL,
	[direccion] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[alergias] [nvarchar](50) NULL,
	[notas] [nvarchar](50) NULL,
	[deleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[pacienteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicio]    Script Date: 05/06/2023 14:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicio](
	[servicioID] [int] IDENTITY(1,1) NOT NULL,
	[nombreServicio] [nvarchar](50) NOT NULL,
	[costoServicio] [decimal](10, 2) NOT NULL,
	[deleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[servicioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 05/06/2023 14:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[usuarioID] [int] IDENTITY(1,1) NOT NULL,
	[nombreUsuario] [nvarchar](50) NOT NULL,
	[claveUsuario] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[usuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Consulta] ADD  DEFAULT ((0)) FOR [deleted]
GO
ALTER TABLE [dbo].[Factura] ADD  DEFAULT ((0)) FOR [deleted]
GO
ALTER TABLE [dbo].[Paciente] ADD  DEFAULT ((0)) FOR [deleted]
GO
ALTER TABLE [dbo].[Servicio] ADD  DEFAULT ((0)) FOR [deleted]
GO
ALTER TABLE [dbo].[Consulta]  WITH CHECK ADD FOREIGN KEY([pacienteID])
REFERENCES [dbo].[Paciente] ([pacienteID])
GO
ALTER TABLE [dbo].[Consulta]  WITH CHECK ADD FOREIGN KEY([servicioID])
REFERENCES [dbo].[Servicio] ([servicioID])
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD FOREIGN KEY([consultaID])
REFERENCES [dbo].[Consulta] ([consultaID])
GO
