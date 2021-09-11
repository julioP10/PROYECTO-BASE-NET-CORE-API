USE [PARDO]
GO
SET IDENTITY_INSERT [dbo].[Accesos] ON 
GO
INSERT [dbo].[Accesos] ([Id], [Modulo], [Pagina], [Url], [Icono], [IdPadre], [Orden], [Vigencia], [Espermisopordefecto]) VALUES (1, N'Configuracion', NULL, N'/config', N'', NULL, 1, 1, 0)
GO
INSERT [dbo].[Accesos] ([Id], [Modulo], [Pagina], [Url], [Icono], [IdPadre], [Orden], [Vigencia], [Espermisopordefecto]) VALUES (2, N'Sector', N'Sector', N'/config/sector', N'', 1, 1, 1, 0)
GO
INSERT [dbo].[Accesos] ([Id], [Modulo], [Pagina], [Url], [Icono], [IdPadre], [Orden], [Vigencia], [Espermisopordefecto]) VALUES (3, N'Perfil', NULL, N'/security', N'', NULL, 2, 1, 0)
GO
INSERT [dbo].[Accesos] ([Id], [Modulo], [Pagina], [Url], [Icono], [IdPadre], [Orden], [Vigencia], [Espermisopordefecto]) VALUES (4, N'Roles', N'Roles', N'/security/roles', N'', 3, 1, 1, 0)
GO
INSERT [dbo].[Accesos] ([Id], [Modulo], [Pagina], [Url], [Icono], [IdPadre], [Orden], [Vigencia], [Espermisopordefecto]) VALUES (5, N'Usuario', N'Usuario', N'/security/usuario', N'', 3, 2, 1, 0)
GO
INSERT [dbo].[Accesos] ([Id], [Modulo], [Pagina], [Url], [Icono], [IdPadre], [Orden], [Vigencia], [Espermisopordefecto]) VALUES (6, N'Empresa', N'Empresa', N'/security/empresa', N'', 3, 3, 1, 0)
GO
INSERT [dbo].[Accesos] ([Id], [Modulo], [Pagina], [Url], [Icono], [IdPadre], [Orden], [Vigencia], [Espermisopordefecto]) VALUES (7, N'Horarios y Delivery', N'', N'/menu', N'', NULL, 3, 1, 1)
GO
INSERT [dbo].[Accesos] ([Id], [Modulo], [Pagina], [Url], [Icono], [IdPadre], [Orden], [Vigencia], [Espermisopordefecto]) VALUES (8, N'Horarios de Apertura', N'Horarios de Apertura', N'/menu/open-hours', N'', 7, 1, 1, 1)
GO
INSERT [dbo].[Accesos] ([Id], [Modulo], [Pagina], [Url], [Icono], [IdPadre], [Orden], [Vigencia], [Espermisopordefecto]) VALUES (9, N'Entrega', N'Entrega Delivery', N'/menu/delivery', N'', 7, 2, 1, 1)
GO
INSERT [dbo].[Accesos] ([Id], [Modulo], [Pagina], [Url], [Icono], [IdPadre], [Orden], [Vigencia], [Espermisopordefecto]) VALUES (10, N'Productos', N'Productos', N'/menu/products', N'', 7, 4, 1, 1)
GO
INSERT [dbo].[Accesos] ([Id], [Modulo], [Pagina], [Url], [Icono], [IdPadre], [Orden], [Vigencia], [Espermisopordefecto]) VALUES (11, N'Opciones Producto', N'Opciones Producto', N'/menu/options', N'', 7, 3, 1, 1)
GO
INSERT [dbo].[Accesos] ([Id], [Modulo], [Pagina], [Url], [Icono], [IdPadre], [Orden], [Vigencia], [Espermisopordefecto]) VALUES (12, N'Cupones', N'Cupones', N'/menu/coupons', N'', 7, 5, 1, 1)
GO
INSERT [dbo].[Accesos] ([Id], [Modulo], [Pagina], [Url], [Icono], [IdPadre], [Orden], [Vigencia], [Espermisopordefecto]) VALUES (13, N'Perfil Cliente', NULL, N'/profile', N'', NULL, 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Accesos] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([id], [email], [clave], [estado], [vigencia], [fechaCreacion], [ModoAutenticacion], [NombreUsuario], [NombreCompleto], [IdEmpresa], [EsSuperUsuario]) VALUES (1, N'admin', N'f1wwkVetgYsE9UVXremr0A==', 1, 1, CAST(N'2021-03-08T00:00:00.000' AS DateTime), 1, N'admin', N'admin', NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[AccesosPermitidos] ON 
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (1, 2, 1, 3, N'ELIMINAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (2, 2, 1, 1, N'GUARDAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (3, 4, 1, 1, N'GUARDAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (4, 2, 1, 2, N'EDITAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (5, 4, 1, 2, N'EDITAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (6, 2, 1, 4, N'NUEVO', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (7, 5, 1, 4, N'NUEVO', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (8, 5, 1, 2, N'EDITAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (9, 5, 1, 3, N'ELIMINAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (10, 5, 1, 1, N'GUARDAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (11, 4, 1, 4, N'NUEVO', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (12, 4, 1, 3, N'ELIMINAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (13, 6, 1, 2, N'EDITAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (14, 6, 1, 1, N'GUARDAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (15, 6, 1, 4, N'NUEVO', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (16, 8, 1, 2, N'EDITAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (17, 8, 1, 1, N'GUARDAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (18, 6, 1, 3, N'ELIMINAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (19, 8, 1, 3, N'ELIMINAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (20, 8, 1, 4, N'NUEVO', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (21, 9, 1, 1, N'GUARDAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (22, 9, 1, 2, N'EDITAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (23, 9, 1, 3, N'ELIMINAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (24, 9, 1, 4, N'NUEVO', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (25, 10, 1, 2, N'EDITAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (26, 10, 1, 1, N'GUARDAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (27, 10, 1, 3, N'ELIMINAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (28, 11, 1, 1, N'GUARDAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (29, 10, 1, 4, N'NUEVO', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (30, 11, 1, 2, N'EDITAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (31, 11, 1, 3, N'ELIMINAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (32, 11, 1, 4, N'NUEVO', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (33, 12, 1, 4, N'NUEVO', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (34, 12, 1, 3, N'ELIMINAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (35, 12, 1, 1, N'GUARDAR', 1, 1)
GO
INSERT [dbo].[AccesosPermitidos] ([Id], [IdAccesos], [IdUsuario], [TipoPermiso], [NombreAccion], [Activo], [Vigencia]) VALUES (36, 12, 1, 2, N'EDITAR', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[AccesosPermitidos] OFF
GO
SET IDENTITY_INSERT [dbo].[Rol] ON 
GO
INSERT [dbo].[Rol] ([Id], [Nombre], [Descripcion], [Vigencia]) VALUES (1, N'Administrador', NULL, 1)
GO
INSERT [dbo].[Rol] ([Id], [Nombre], [Descripcion], [Vigencia]) VALUES (2, N'Empresa', N'Empresa', 1)
GO
INSERT [dbo].[Rol] ([Id], [Nombre], [Descripcion], [Vigencia]) VALUES (3, N'Usuario Regular', N'Usuario Regular', 1)
GO
SET IDENTITY_INSERT [dbo].[Rol] OFF
GO
SET IDENTITY_INSERT [dbo].[AccesosRol] ON 
GO
INSERT [dbo].[AccesosRol] ([Id], [IdRol], [IdAccesos]) VALUES (1, 1, 1)
GO
INSERT [dbo].[AccesosRol] ([Id], [IdRol], [IdAccesos]) VALUES (2, 1, 3)
GO
INSERT [dbo].[AccesosRol] ([Id], [IdRol], [IdAccesos]) VALUES (3, 1, 7)
GO
INSERT [dbo].[AccesosRol] ([Id], [IdRol], [IdAccesos]) VALUES (4, 2, 7)
GO
INSERT [dbo].[AccesosRol] ([Id], [IdRol], [IdAccesos]) VALUES (5, 3, 13)
GO
INSERT [dbo].[AccesosRol] ([Id], [IdRol], [IdAccesos]) VALUES (1001, 1, 13)
GO
SET IDENTITY_INSERT [dbo].[AccesosRol] OFF
GO
SET IDENTITY_INSERT [dbo].[UsuarioRol] ON 
GO
INSERT [dbo].[UsuarioRol] ([Id], [IdRol], [IdUsuario]) VALUES (1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[UsuarioRol] OFF
GO
SET IDENTITY_INSERT [dbo].[Etiquetas] ON 
GO
INSERT [dbo].[Etiquetas] ([id], [nombre], [vigencia], [Icon]) VALUES (1, N'Gluten', 1, N'')
GO
INSERT [dbo].[Etiquetas] ([id], [nombre], [vigencia], [Icon]) VALUES (2, N'Vegano', 1, N'')
GO
SET IDENTITY_INSERT [dbo].[Etiquetas] OFF
GO
SET IDENTITY_INSERT [dbo].[Sector] ON 
GO
INSERT [dbo].[Sector] ([id], [nombre], [vigencia], [Descripcion]) VALUES (1, N'Restaurant', 1, N'Restaurant')
GO
INSERT [dbo].[Sector] ([id], [nombre], [vigencia], [Descripcion]) VALUES (2, N'Market', 1, N'Market')
GO
SET IDENTITY_INSERT [dbo].[Sector] OFF
GO
