CREATE TABLE [dbo].[Licitaciones] (
    [IdLicitacion]      INT           IDENTITY (1, 1) NOT NULL,
    [IdAsociacion]      INT           NOT NULL,
    [IdEmpresa]         INT           NOT NULL,
    [Nombre]            VARCHAR (250) NULL,
    [Clave]             VARCHAR (6)   NULL,
    [Especificaciones]  VARCHAR (MAX) NULL,
    [fAlta]             DATETIME      NULL,
    [IdUsuarioAlta]     INT           NULL,
    [fModifica]         DATETIME      NULL,
    [IdUsuarioModifica] INT           NULL,
    [fBaja]             DATETIME      NULL,
    [IdUsuarioBaja]     INT           NULL,
    [Estatus]           BIT           CONSTRAINT [DF__Licitacio__Estat__5649C92D] DEFAULT ((1)) NULL,
    CONSTRAINT [PK__Licitaci__C105CD0D6713882F] PRIMARY KEY CLUSTERED ([IdLicitacion] ASC),
    CONSTRAINT [FK_Licitaciones_Asociaciones] FOREIGN KEY ([IdAsociacion]) REFERENCES [dbo].[Asociaciones] ([IdAsociacion]),
    CONSTRAINT [FK_Licitaciones_Empresas] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresas] ([IdEmpresa]),
    CONSTRAINT [FK_Licitaciones_LicitacionProveedores] FOREIGN KEY ([IdLicitacion]) REFERENCES [dbo].[LicitacionProveedores] ([IdPropuesta])
);



