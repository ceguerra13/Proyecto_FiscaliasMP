
-- Creación Vistas

-- Vista Fiscalías

CREATE VIEW [dbo].[VW_FISCALIAS]
AS
select Id_Fiscalia, Nombre_Fiscalia, Ubicacion
from Fiscalias
WHERE Estado = 1

-- Vista Teléfonos

CREATE VIEW [dbo].[VW_TELEFONOS]
AS
select Fiscalias.Id_Fiscalia, telefonos.Id_telefono, Fiscalias.Nombre_Fiscalia, Fiscalias.Ubicacion, Telefonos.Numero, Telefonos.Extension
from Fiscalias
inner join Telefonos
on Fiscalias.Id_Fiscalia = Telefonos.Id_Fiscalia
WHERE FISCALIAS.ESTADO = 1 AND TELEFONOS.ESTADO = 1

-- Vista Fiscalías y Teléfonos

CREATE VIEW [dbo].[VW_FISCALIASYNUM]
AS
select distinct Fiscalias.Id_Fiscalia, Fiscalias.Nombre_Fiscalia, Fiscalias.Ubicacion, Telefonos.Numero, Telefonos.Extension
from Fiscalias
inner join Telefonos
on Fiscalias.Id_Fiscalia = Telefonos.Id_Fiscalia
WHERE FISCALIAS.ESTADO = 1 AND TELEFONOS.ESTADO = 1