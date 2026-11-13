CREATE TABLE [dbo].[Paises] (
    [IdPais] INT           NOT NULL,
    [Clave]  NVARCHAR (5)  NOT NULL,
    [Nombre] VARCHAR (150) NOT NULL,
    [Moneda] NVARCHAR (5)  NULL,
    CONSTRAINT [PK_Paises] PRIMARY KEY CLUSTERED ([IdPais] ASC)
);

