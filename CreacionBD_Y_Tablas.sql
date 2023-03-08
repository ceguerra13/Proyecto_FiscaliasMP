--Creación de Base de Datos

--create database FiscaliasMP
--use FiscaliasMP

-- Crear Tablas a Utilizar

CREATE TABLE Fiscalias(
	[Id_Fiscalia] int identity(1,1) NOT NULL,
	[Nombre_Fiscalia] [varchar](255) NOT NULL,
	[Ubicacion] [varchar](255) NOT NULL,
	[Estado] [bit] NOT NULL,
	
 CONSTRAINT [PK_Fiscalias] PRIMARY KEY CLUSTERED 
(
	[Id_Fiscalia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE Telefonos(
	[Id_Telefono] int identity(1,1) NOT NULL,
	[Id_Fiscalia] [int] NOT NULL,
	[Numero] [decimal](8) NOT NULL,
	[Extension] [decimal](5) NULL,
	[Estado] [bit] NOT NULL,
	
 CONSTRAINT [PK_Telefonos] PRIMARY KEY CLUSTERED 
(
	[Id_Telefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Telefonos]  WITH CHECK ADD  CONSTRAINT [FK_Telefonos_Fiscalias] FOREIGN KEY([Id_Fiscalia])
REFERENCES [dbo].[Fiscalias] ([Id_Fiscalia])

-- Mostrar Tablas
--select * from Fiscalias
--select * from Telefonos

-- Eliminar Tablas (de requerirlo, se debe eliminar primero tbl.telefonos en virtud a FK)
--drop table telefonos
--drop table fiscalias



