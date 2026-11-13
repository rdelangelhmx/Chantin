CREATE TABLE [dbo].[Reuniones] (
    [IdReunion]         INT           IDENTITY (1, 1) NOT NULL,
    [IdAsociacion]      INT           NOT NULL,
    [IdEmpresa]         INT           NOT NULL,
    [Nombre]            VARCHAR (150) NULL,
    [fReunion]          DATETIME      NULL,
    [IdTipoReunion]     INT           NULL,
    [fAlta]             DATETIME      NULL,
    [IdUsuarioAlta]     INT           NULL,
    [fModifica]         DATETIME      NULL,
    [IdUsuarioModifica] INT           NULL,
    [fBaja]             DATETIME      NULL,
    [IdUsuarioBaja]     INT           NULL,
    [Estatus]           BIT           NULL,
    CONSTRAINT [PK_Reuniones] PRIMARY KEY CLUSTERED ([IdReunion] ASC),
    CONSTRAINT [FK_Reuniones_Asociaciones] FOREIGN KEY ([IdAsociacion]) REFERENCES [dbo].[Asociaciones] ([IdAsociacion]),
    CONSTRAINT [FK_Reuniones_Empresas] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresas] ([IdEmpresa])
);

