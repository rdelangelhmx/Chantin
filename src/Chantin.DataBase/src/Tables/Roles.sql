CREATE TABLE [dbo].[Roles] (
    [IdRol]             INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]            VARCHAR (25) NULL,
    [fAlta]             DATETIME     NULL,
    [IdUsuarioAlta]     INT          NULL,
    [fModifica]         DATETIME     NULL,
    [IdUsuarioModifica] INT          NULL,
    [fBaja]             DATETIME     NULL,
    [IdUsuarioBaja]     INT          NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([IdRol] ASC)
);

