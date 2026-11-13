CREATE TABLE [dbo].[Proveedores] (
    [IdProveedor]       INT           IDENTITY (1, 1) NOT NULL,
    [IdAsociacion]      INT           NOT NULL,
    [IdEmpresa]         INT           NOT NULL,
    [Nombre]            VARCHAR (100) NULL,
    [Apellidos]         VARCHAR (200) NULL,
    [RazonSocial]       VARCHAR (500) NULL,
    [Clave]             VARCHAR (6)   NULL,
    [RFC]               VARCHAR (15)  NULL,
    [CURP]              VARCHAR (20)  NULL,
    [Telefono]          VARCHAR (10)  NULL,
    [Otro]              VARCHAR (15)  NULL,
    [Dominio]           VARCHAR (500) NULL,
    [Contacto]          VARCHAR (250) NULL,
    [Correo]            VARCHAR (250) NULL,
    [Celular]           VARCHAR (10)  NULL,
    [fAlta]             DATETIME      NULL,
    [IdUsuarioAlta]     INT           NULL,
    [fModifica]         DATETIME      NULL,
    [IdUsuarioModifica] INT           NULL,
    [fBaja]             DATETIME      NULL,
    [IdUsuarioBaja]     INT           NULL,
    [Estatus]           BIT           CONSTRAINT [DF__tmp_ms_xx__Estat__369C13AA] DEFAULT ((1)) NULL,
    CONSTRAINT [PK__tmp_ms_x__E8B631AF47C5DB92] PRIMARY KEY CLUSTERED ([IdProveedor] ASC),
    CONSTRAINT [FK_Proveedores_Asociaciones] FOREIGN KEY ([IdAsociacion]) REFERENCES [dbo].[Asociaciones] ([IdAsociacion]),
    CONSTRAINT [FK_Proveedores_Empresas] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresas] ([IdEmpresa])
);



