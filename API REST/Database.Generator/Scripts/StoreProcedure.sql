
IF OBJECT_ID('sp_generate_properties_table', 'P') IS NOT NULL  -- Si procedimiento <nombre_PA> existe...
  DROP PROCEDURE sp_generate_properties_table;                 -- ... se elimina
GO
CREATE PROC sp_generate_properties_table  
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

IF OBJECT_ID('SP_GetPermisos', 'P') IS NOT NULL  -- Si procedimiento <SP_GetPermisos> existe...
 DROP PROCEDURE SP_GetPermisos;                 -- ... se elimina
GO
CREATE PROC [SP_GetPermisos]  
@IdUsuario INT = 0
AS 
BEGIN
 SELECT  
  'Rol' = (SELECT R.Nombre,R.Id,U.id IdUsuario FROM  Rol R  
             INNER JOIN UsuarioRol UR ON U.id = UR.IdUsuario
			 WHERE UR.IdUsuario = U.id AND R.Vigencia = 1
			 FOR JSON AUTO),
  U.NombreUsuario,
  U.NombreCompleto,
  'Menus' = (select distinct * from [PARDO].[dbo].[Accesos] Parent
             INNER JOIN [PARDO].[dbo].[Accesos] Child  on Child.IdPadre = Parent.Id 
			 INNER JOIN [PARDO].[dbo].[AccesosPermitidos] Actions on Actions.IdAccesos = Child.Id
			 where Actions.IdUsuario = u.id  
			 FOR JSON AUTO)
  FROM Usuario U   
  WHERE   U.Vigencia = 1  
  AND U.ID = @IdUsuario
END
go