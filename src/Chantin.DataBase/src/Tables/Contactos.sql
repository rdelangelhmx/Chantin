CREATE TABLE [dbo].[Contactos] (
    [IdContacto]        INT           IDENTITY (1, 1) NOT NULL,
    [IdEmpresa]         INT           NOT NULL,
    [Nombre]            VARCHAR (100) NULL,
    [Apellidos]         VARCHAR (200) NULL,
    [Correo]            VARCHAR (500) NULL,
    [Telelefono]        VARCHAR (10)  NULL,
    [Celular]           VARCHAR (10)  NULL,
    [Facebook]          VARCHAR (75)  NULL,
    [Twitter]           VARCHAR (75)  NULL,
    [Google]            VARCHAR (75)  NULL,
    [LinkedIn]          VARCHAR (75)  NULL,
    [Instagram]         VARCHAR (75)  NULL,
    [fAlta]             DATETIME      NULL,
    [IdUsuarioAlta]     INT           NULL,
    [fModifica]         DATETIME      NULL,
    [IdUsuarioModifica] INT           NULL,
    [fBaja]             DATETIME      NULL,
    [IdUsuarioBaja]     INT           NULL,
    [Estatus]           BIT           CONSTRAINT [DF__tmp_ms_xx__Estat__33BFA6FF] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Contactos_1] PRIMARY KEY CLUSTERED ([IdContacto] ASC),
    CONSTRAINT [FK_Contactos_Empresas] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresas] ([IdEmpresa])
);



