CREATE TABLE [dbo].[Encuestas] (
    [IdEncuesta]        INT           IDENTITY (1, 1) NOT NULL,
    [IdAsociacion]      INT           NOT NULL,
    [IdEmpresa]         INT           NOT NULL,
    [Nombre]            VARCHAR (250) NULL,
    [Indicaciones]      VARCHAR (MAX) NULL,
    [Clave]             VARCHAR (6)   NULL,
    [fInicio]           DATETIME      NULL,
    [fFinal]            DATETIME      NULL,
    [fAlta]             DATETIME      NULL,
    [IdUsuarioAlta]     INT           NULL,
    [fModifica]         DATETIME      NULL,
    [IdUsuarioModifica] INT           NULL,
    [fBaja]             DATETIME      NULL,
    [IdUsuarioBaja]     INT           NULL,
    [Estatus]           BIT           CONSTRAINT [DF__Encuestas__Estat__5555A4F4] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Encuestas] PRIMARY KEY CLUSTERED ([IdEncuesta] ASC),
    CONSTRAINT [FK_Encuestas_Asociaciones] FOREIGN KEY ([IdAsociacion]) REFERENCES [dbo].[Asociaciones] ([IdAsociacion]),
    CONSTRAINT [FK_Encuestas_Empresas] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresas] ([IdEmpresa])
);



