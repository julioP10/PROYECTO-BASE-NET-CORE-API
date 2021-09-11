USE [master]
GO
/****** Object:  Database [PARDO]    Script Date: 07/03/2021 12:36:41 ******/
CREATE DATABASE [PARDO]

GO
USE [PARDO]
GO
/****** Object:  Table [dbo].[Accesos]    Script Date: 07/03/2021 12:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accesos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Modulo] [varchar](100) NULL,
	[Pagina] [varchar](100) NULL,
	[Url] [varchar](200) NULL,
	[Icono] [varchar](100) NULL,
	[IdPadre] [int] NULL,
	[Orden] [int] NULL,
	[Vigencia] [bit] NULL,
	[Espermisopordefecto] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccesosPermitidos]    Script Date: 07/03/2021 12:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccesosPermitidos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdAccesos] [int] NULL,
	[IdUsuario] [int] NULL,
	[TipoPermiso] [int] NULL,
	[NombreAccion] [varchar](100) NULL,
	[Activo] [bit] NULL,
	[Vigencia] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccesosRol]    Script Date: 07/03/2021 12:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccesosRol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdRol] [int] NULL,
	[IdAccesos] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Audit]    Script Date: 07/03/2021 12:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Audit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [varchar](200) NULL,
	[DateTime] [datetime] NULL,
	[KeyValues] [varchar](max) NULL,
	[OldValues] [varchar](max) NULL,
	[NewValues] [varchar](max) NULL,
	[User] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 07/03/2021 12:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](150) NOT NULL,
	[vigencia] [bit] NULL,
	[IdEmpresa] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 07/03/2021 12:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idSector] [int] NOT NULL,
	[nombre] [varchar](350) NOT NULL,
	[celular] [varchar](15) NOT NULL,
	[whatsapp] [varchar](15) NULL,
	[pedidosPorTelefono] [bit] NULL,
	[facebook] [varchar](350) NULL,
	[instagram] [varchar](350) NULL,
	[direccion] [varchar](650) NULL,
	[tiempoEntrega] [varchar](180) NULL,
	[logo] [varchar](max) NULL,
	[Longitud] [varchar](200) NOT NULL,
	[Latitud] [varchar](200) NOT NULL,
	[Banner] [varchar](max) NULL,
	[Vigencia] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpresaCobertura]    Script Date: 07/03/2021 12:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpresaCobertura](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idEmpresa] [int] NOT NULL,
	[nombre] [varchar](300) NOT NULL,
	[metros] [varchar](100) NOT NULL,
	[costo] [decimal](18, 2) NOT NULL,
	[vigencia] [bit] NULL,
	[costoMinimo] [decimal](18, 2) NULL,
	[visible] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpresaCupon]    Script Date: 07/03/2021 12:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpresaCupon](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idEmpresa] [int] NOT NULL,
	[porcentaje] [bit] NULL,
	[titulo] [varchar](250) NOT NULL,
	[codigo] [varchar](50) NOT NULL,
	[descripcion] [varchar](650) NULL,
	[inicia] [date] NULL,
	[termina] [date] NULL,
	[limite] [int] NOT NULL,
	[monto] [decimal](18, 2) NOT NULL,
	[tyc] [varchar](250) NOT NULL,
	[estado] [bit] NULL,
	[vigencia] [bit] NULL,
	[montoParaAcceder] [decimal](18, 2) NULL,
	[opcionMaximo] [int] NULL,
	[opcionMinimo] [int] NULL,
	[orden] [int] NULL,
	[tipo] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpresaHorarioAtencion]    Script Date: 07/03/2021 12:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpresaHorarioAtencion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idEmpresa] [int] NOT NULL,
	[lunes] [varchar](max) NULL,
	[martes] [varchar](max) NULL,
	[miercoles] [varchar](max) NULL,
	[Jueves] [varchar](max) NULL,
	[viernes] [varchar](max) NULL,
	[sabado] [varchar](max) NULL,
	[domingo] [varchar](max) NULL,
	[Vigencia] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpresaMetodosPago]    Script Date: 07/03/2021 12:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpresaMetodosPago](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idEmpresa] [int] NOT NULL,
	[yape] [varchar](650) NULL,
	[efectivo] [varchar](650) NULL,
	[tarjeta] [varchar](650) NULL,
	[transferencia] [varchar](650) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpresaTipoPedido]    Script Date: 07/03/2021 12:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpresaTipoPedido](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idEmpresa] [int] NOT NULL,
	[consumoEnLocal] [varchar](max) NULL,
	[paraLlevar] [varchar](max) NULL,
	[envioADomicilio] [varchar](max) NULL,
	[gmap] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Etiquetas]    Script Date: 07/03/2021 12:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Etiquetas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](150) NOT NULL,
	[vigencia] [bit] NULL,
	[Icon] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grupo]    Script Date: 07/03/2021 12:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grupo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](150) NOT NULL,
	[obligatorio] [bit] NULL,
	[estado] [bit] NULL,
	[vigencia] [bit] NULL,
	[opcionMinimo] [int] NULL,
	[orden] [int] NULL,
	[tipo] [varchar](100) NULL,
	[opcionMaximo] [int] NULL,
	[IdEmpresa] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GrupoOpciones]    Script Date: 07/03/2021 12:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GrupoOpciones](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idGrupo] [int] NOT NULL,
	[nombre] [varchar](250) NOT NULL,
	[precio] [decimal](18, 2) NULL,
	[estado] [bit] NULL,
	[limite] [int] NULL,
	[order] [int] NULL,
	[vigencia] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 07/03/2021 12:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idCategoria] [int] NOT NULL,
	[nombre] [varchar](150) NOT NULL,
	[precio] [decimal](18, 2) NOT NULL,
	[imagen] [varchar](max) NULL,
	[descripcion] [text] NULL,
	[precioConDescuento] [decimal](18, 2) NOT NULL,
	[estado] [int] NULL,
	[vigencia] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductoEtiquetas]    Script Date: 07/03/2021 12:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductoEtiquetas](
	[idProducto] [int] NOT NULL,
	[idEtiqueta] [int] NOT NULL,
	[vigencia] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductoGrupoOpciones]    Script Date: 07/03/2021 12:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductoGrupoOpciones](
	[idProducto] [int] NOT NULL,
	[idGrupo] [int] NOT NULL,
	[vigencia] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 07/03/2021 12:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NULL,
	[Descripcion] [varchar](250) NULL,
	[Vigencia] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sector]    Script Date: 07/03/2021 12:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sector](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](350) NOT NULL,
	[vigencia] [bit] NULL,
	[Descripcion] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 07/03/2021 12:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](250) NOT NULL,
	[clave] [varchar](250) NOT NULL,
	[estado] [bit] NULL,
	[vigencia] [bit] NULL,
	[fechaCreacion] [datetime] NULL,
	[ModoAutenticacion] [int] NULL,
	[NombreUsuario] [varchar](200) NULL,
	[NombreCompleto] [varchar](200) NULL,
	[IdEmpresa] [int] NULL,
	[EsSuperUsuario] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioRol]    Script Date: 07/03/2021 12:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioRol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdRol] [int] NULL,
	[IdUsuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Audit] ADD  DEFAULT (getdate()) FOR [DateTime]
GO
ALTER TABLE [dbo].[Empresa] ADD  DEFAULT ((1)) FOR [Vigencia]
GO
ALTER TABLE [dbo].[EmpresaCobertura] ADD  DEFAULT ((1)) FOR [visible]
GO
ALTER TABLE [dbo].[EmpresaHorarioAtencion] ADD  DEFAULT ((1)) FOR [Vigencia]
GO
ALTER TABLE [dbo].[Accesos]  WITH CHECK ADD FOREIGN KEY([IdPadre])
REFERENCES [dbo].[Accesos] ([Id])
GO
ALTER TABLE [dbo].[AccesosPermitidos]  WITH CHECK ADD FOREIGN KEY([IdAccesos])
REFERENCES [dbo].[Accesos] ([Id])
GO
ALTER TABLE [dbo].[AccesosPermitidos]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[AccesosRol]  WITH CHECK ADD FOREIGN KEY([IdAccesos])
REFERENCES [dbo].[Accesos] ([Id])
GO
ALTER TABLE [dbo].[AccesosRol]  WITH CHECK ADD FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([Id])
GO
ALTER TABLE [dbo].[Categoria]  WITH CHECK ADD  CONSTRAINT [FK_Categoria_Emoresa] FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[Empresa] ([id])
GO
ALTER TABLE [dbo].[Categoria] CHECK CONSTRAINT [FK_Categoria_Emoresa]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD FOREIGN KEY([idSector])
REFERENCES [dbo].[Sector] ([id])
GO
ALTER TABLE [dbo].[EmpresaCobertura]  WITH CHECK ADD FOREIGN KEY([idEmpresa])
REFERENCES [dbo].[Empresa] ([id])
GO
ALTER TABLE [dbo].[EmpresaCupon]  WITH CHECK ADD FOREIGN KEY([idEmpresa])
REFERENCES [dbo].[Empresa] ([id])
GO
ALTER TABLE [dbo].[EmpresaHorarioAtencion]  WITH CHECK ADD FOREIGN KEY([idEmpresa])
REFERENCES [dbo].[Empresa] ([id])
GO
ALTER TABLE [dbo].[EmpresaHorarioAtencion]  WITH CHECK ADD FOREIGN KEY([idEmpresa])
REFERENCES [dbo].[Empresa] ([id])
GO
ALTER TABLE [dbo].[EmpresaMetodosPago]  WITH CHECK ADD FOREIGN KEY([idEmpresa])
REFERENCES [dbo].[Empresa] ([id])
GO
ALTER TABLE [dbo].[EmpresaTipoPedido]  WITH CHECK ADD FOREIGN KEY([idEmpresa])
REFERENCES [dbo].[Empresa] ([id])
GO
ALTER TABLE [dbo].[Grupo]  WITH CHECK ADD FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[Empresa] ([id])
GO
ALTER TABLE [dbo].[GrupoOpciones]  WITH CHECK ADD FOREIGN KEY([idGrupo])
REFERENCES [dbo].[Grupo] ([id])
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([idCategoria])
REFERENCES [dbo].[Categoria] ([id])
GO
ALTER TABLE [dbo].[ProductoEtiquetas]  WITH CHECK ADD FOREIGN KEY([idEtiqueta])
REFERENCES [dbo].[Etiquetas] ([id])
GO
ALTER TABLE [dbo].[ProductoEtiquetas]  WITH CHECK ADD FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([id])
GO
ALTER TABLE [dbo].[ProductoGrupoOpciones]  WITH CHECK ADD FOREIGN KEY([idGrupo])
REFERENCES [dbo].[Grupo] ([id])
GO
ALTER TABLE [dbo].[ProductoGrupoOpciones]  WITH CHECK ADD FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([id])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[Empresa] ([id])
GO
ALTER TABLE [dbo].[UsuarioRol]  WITH CHECK ADD FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([Id])
GO
ALTER TABLE [dbo].[UsuarioRol]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([id])
GO
/****** Object:  StoredProcedure [dbo].[sp_generate_properties_table]    Script Date: 07/03/2021 12:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[dbo].[sp_generate_properties_table] 'p.','EmpresaMetodosPago'
CREATE PROC [dbo].[sp_generate_properties_table]  
@PRE VARCHAR(10)='p.',
@tablename varchar(max)='Producto'
AS
BEGIN

SELECT  'public '+case t.Name when 'varchar' then 'string' when 'char' then 'string' when 'bit' then 'bool' when 'datetime' then 'DateTime' else t.Name end+' '+UPPER(LEFT(c.Name, 1)) + LOWER(SUBSTRING(c.Name, 2, LEN(c.Name)))+' { get; set; }' as 'C#',
		'@'+c.Name+' '+case t.Name when 'varchar' then 'varchar('+CASE CAST(c.max_length as varchar(15)) WHEN -1 THEN 'max' ELSE CAST(c.max_length as varchar(15)) END +')' when 'char' then 'char('+CAST(c.max_length as varchar(15))+')' else t.Name end +','  as 'SP SQL',
		c.Name+'='+'@'+c.Name+',',
		UPPER(LEFT(c.Name, 1)) + LOWER(SUBSTRING(c.Name, 2, LEN(c.Name))) +' '+case t.Name when 'varchar' then 'varchar('+CASE CAST(c.max_length as varchar(15)) WHEN -1 THEN 'max' ELSE CAST(c.max_length as varchar(15)) END +')' when 'char' then 'char('+CAST(c.max_length as varchar(15))+')' else t.Name end +','  as 'SP SQL',
		UPPER(LEFT(c.Name, 1)) + LOWER(SUBSTRING(c.Name, 2, LEN(c.Name))) +',' AS Field_Name,
		LOWER(LEFT(c.Name, 1)) + LOWER(SUBSTRING(c.Name, 2, LEN(c.Name)))+' : '+case t.Name when 'varchar' then 'string' when 'char' then 'string' when 'bit' then 'boolean' when 'datetime' then 'DateTime' when 'int' then 'number' when 'decimal' then 'number' when 'text' then 'string' when 'date' then 'string' else t.Name end+';'AS InterfaceTypeScript,
		@PRE+UPPER(LEFT(c.Name, 1)) + LOWER(SUBSTRING(c.Name, 2, LEN(c.Name))) +',' AS Field_Name,
		o.name+'.'+c.Name+'=XMLdata.'+LOWER(c.Name)+',' as 'FOR UPDATE',
		'
				<label>'+c.Name+': </label>
				<div class="form-group">
				<input type="text" placeholder="Ingrese '+LOWER(c.Name)+'" class="form-control" name="'+c.Name+'" required>
				</div>		
		' 
		'For Html',
		t.Name AS Data_Type,       
		c.max_length AS ml,
		t.precision AS Precision
FROM sys.columns c 
		INNER JOIN sys.objects o ON o.object_id = c.object_id
		LEFT JOIN  sys.types t on t.user_type_id  = c.user_type_id   
WHERE o.type = 'U' and o.Name = @tablename
ORDER BY c.column_id
end
GO
USE [master]
GO
ALTER DATABASE [PARDO] SET  READ_WRITE 
GO
