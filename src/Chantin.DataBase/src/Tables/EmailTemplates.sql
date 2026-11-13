CREATE TABLE [dbo].[EmailTemplates] (
    [IdTemplate]        INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]            VARCHAR (250) NULL,
    [Asunto]            VARCHAR (250) NULL,
    [Contenido]         VARCHAR (MAX) NULL,
    [fAlta]             DATETIME      NULL,
    [IdUsuarioAlta]     INT           NULL,
    [fModifica]         DATETIME      NULL,
    [IdUsuarioModifica] INT           NULL,
    [fBaja]             DATETIME      NULL,
    [IdUsuarioBaja]     INT           NULL,
    [Estatus]           BIT           DEFAULT ((1)) NULL,
    CONSTRAINT [PK_EmailTemplates] PRIMARY KEY CLUSTERED ([IdTemplate] ASC)
);

