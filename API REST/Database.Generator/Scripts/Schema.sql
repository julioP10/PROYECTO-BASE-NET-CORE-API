

--ALTER TABLES 
IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[Producto]') 
         AND name = 'imagen'
)
BEGIN 
ALTER TABLE [dbo].[Producto] 
 ALTER COLUMN imagen varchar(max);
END
GO
IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[Producto]') 
         AND name = 'estado'
)
BEGIN 
ALTER TABLE [dbo].[Producto] 
 ALTER COLUMN [estado] int;
END
GO
IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[Producto]') 
         AND name = 'logo'
)
BEGIN 
ALTER TABLE [dbo].[Empresa] 
 ALTER COLUMN [logo] varchar(max); 
END
GO

IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[Empresa]') 
         AND name = 'banner'
)
BEGIN 
ALTER TABLE [dbo].[Empresa] 
 ALTER COLUMN [banner] varchar(max); 
END
GO

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[EmpresaCupon]') 
         AND name = 'montoParaAcceder'
)
BEGIN 
ALTER TABLE [dbo].[EmpresaCupon] 
 ADD [montoParaAcceder] decimal(18,2);
 END
GO

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[Grupo]') 
         AND name = 'opcionMaximo'
)
BEGIN 
ALTER TABLE [dbo].[Grupo] 
 ADD [opcionMaximo] int;
END
GO

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[Grupo]') 
         AND name = 'opcionMinimo'
)
BEGIN 
ALTER TABLE [dbo].[Grupo] 
 ADD [opcionMinimo] int;
 END
GO

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[Grupo]') 
         AND name = 'orden'
)
BEGIN 
ALTER TABLE [dbo].[Grupo] 
 ADD [orden] int;
END
GO

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[Grupo]') 
         AND name = 'tipo'
)
BEGIN 
 ALTER TABLE [dbo].[Grupo]  ADD [tipo] varchar(100);
END
GO

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[Grupo]') 
         AND name = 'IdEmpresa'
)
BEGIN 
ALTER TABLE [dbo].[Grupo] 
 ADD [IdEmpresa] int FOREIGN KEY references Empresa (Id) ;
END
GO

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[Etiquetas]') 
         AND name = 'Icon'
)
BEGIN 
ALTER TABLE [dbo].[Etiquetas]
 ADD Icon varchar(100) 
END
GO

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[EmpresaCobertura]') 
         AND name = 'visible'
)
BEGIN 
ALTER TABLE [dbo].[Etiquetas]
 ADD visible bit DEFAULT(1) 
END
GO

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[Sector]') 
         AND name = 'Descripcion'
)
BEGIN 
ALTER TABLE [dbo].[Etiquetas]
 ADD Descripcion varchar(200)
END
GO
 
