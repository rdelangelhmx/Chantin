CREATE TABLE [dbo].[LicitacionProveedores] (
    [IdPropuesta]       INT           IDENTITY (1, 1) NOT NULL,
    [IdLicitacion]      INT           NOT NULL,
    [IdProveedor]       INT           NOT NULL,
    [IdAsociacion]      INT           NOT NULL,
    [IdEmpresa]         INT           NOT NULL,
    [Archivo]           VARCHAR (250) NULL,
    [fEnvio]            DATETIME      NULL,
    [fRevision]         DATETIME      NULL,
    [fAsignacion]       DATETIME      NULL,
    [Ganador]           BIT           CONSTRAINT [DF__Licitacio__Ganad__573DED66] DEFAULT ((0)) NULL,
    [fAlta]             DATETIME      NULL,
    [IdUsuarioAlta]     INT           NULL,
    [fModifica]         DATETIME      NULL,
    [IdUsuarioModifica] INT           NULL,
    [fBaja]             DATETIME      NULL,
    [IdUsuarioBaja]     INT           NULL,
    [Estatus]           BIT           CONSTRAINT [DF__Licitacio__Estat__5832119F] DEFAULT ((1)) NULL,
    CONSTRAINT [PK__Licitaci__1923FEFB6299439F] PRIMARY KEY CLUSTERED ([IdPropuesta] ASC),
    CONSTRAINT [FK_LicitacionProveedores_Proveedores] FOREIGN KEY ([IdProveedor]) REFERENCES [dbo].[Proveedores] ([IdProveedor])
);

