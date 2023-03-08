
--Creación Stored Procedures

-- Insertar Fiscalías

CREATE PROCEDURE [dbo].[SP_INSERT](

		@Nombre_Fiscalia varchar(255),
		@Ubicacion varchar(255),
		@Numero decimal(8),
		@Extension decimal(5)
)
AS

DECLARE @id_fiscalia int

INSERT INTO [dbo].[Fiscalias]
           ([Nombre_Fiscalia]
           ,[Ubicacion]
		   ,[Estado])
     VALUES
           (@Nombre_Fiscalia, @Ubicacion,1)

set @id_fiscalia = SCOPE_IDENTITY();

INSERT INTO [dbo].[Telefonos]
           ([Id_Fiscalia]
           ,[Numero]
           ,[Extension]
		   ,[Estado])
     VALUES
           (@id_fiscalia, @Numero, @Extension,1)

-- Editar Fiscalías

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_EDITAR](
@Id_Fiscalia INT,
@Nombre_Fiscalia VARCHAR(255),
@Ubicacion VARCHAR(255)
)
AS
UPDATE [dbo].[Fiscalias]
   SET [Nombre_Fiscalia] = @Nombre_Fiscalia,
	   [Ubicacion] = @Ubicacion
 WHERE Id_Fiscalia = @Id_Fiscalia

 -- Elimar Fiscalías (La eliminación que se utiliza es lógica)

CREATE PROCEDURE [dbo].[SP_ELIMINAR](
@Id_Fiscalia INT
)
AS

UPDATE [dbo].[Fiscalias]
   SET [ESTADO] = 0
 WHERE Id_Fiscalia = @Id_Fiscalia
 UPDATE [dbo].[Telefonos]
   SET [ESTADO] = 0
 WHERE Id_Fiscalia = @Id_Fiscalia

 -- Agregar Teléfonos a Fiscalías

CREATE PROCEDURE [dbo].[SP_ADDNUMERO](

		@id_fiscalia int,
		@Numero decimal(8),
		@Extension decimal(5)
)
AS

INSERT INTO [dbo].[Telefonos]
           ([Id_Fiscalia]
           ,[Numero]
           ,[Extension]
		   ,[Estado])
     VALUES
           (@id_fiscalia,@Numero,@Extension,1)

-- Eliminar Teléfonos a Fiscalias

CREATE PROCEDURE [dbo].[SP_ELIMINARTEL](
@Id_Telefono INT
)
AS
 UPDATE [dbo].[Telefonos]
   SET [ESTADO] = 0
 WHERE Id_Telefono = @Id_Telefono

