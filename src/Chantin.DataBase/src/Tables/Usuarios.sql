CREATE TABLE [dbo].[Usuarios] (
    [IdUsuario]         INT           IDENTITY (0, 1) NOT NULL,
    [IdEmpresa]         INT           NOT NULL,
    [IdAsociacion]      INT           NULL,
    [Correo]            VARCHAR (250) NOT NULL,
    [Password]          VARCHAR (50)  NOT NULL,
    [Nombre]            VARCHAR (100) NULL,
    [Apellidos]         VARCHAR (200) NULL,
    [IdRol]             INT           NOT NULL,
    [Clave]             VARCHAR (6)   NULL,
    [Telefono]          VARCHAR (15)  NULL,
    [Imagen]            VARCHAR (25)  NULL,
    [Activo]            BIT           CONSTRAINT [DF_Usuarios_Activo] DEFAULT ((0)) NOT NULL,
    [fUltimoAcceso]     DATETIME      NULL,
    [IdPadre]           INT           NULL,
    [Code]              VARCHAR (10)  NULL,
    [fExpiracion]       DATETIME      NULL,
    [Usado]             BIT           NULL,
    [fUso]              DATETIME      NULL,
    [fAlta]             DATETIME      CONSTRAINT [DF_Usuarios_fAlta] DEFAULT (getdate()) NOT NULL,
    [IdUsuarioAlta]     INT           CONSTRAINT [DF_Usuarios_IdUsuarioAlta] DEFAULT ((0)) NULL,
    [fModifica]         DATETIME      NULL,
    [IdUsuarioModifica] INT           NULL,
    [fBaja]             DATETIME      NULL,
    [IdUsuarioBaja]     INT           NULL,
    [Estatus]           BIT           CONSTRAINT [DF__Usuarios__Estatu__60A75C0F] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Usuarios_1] PRIMARY KEY CLUSTERED ([IdUsuario] ASC),
    CONSTRAINT [FK_Usuarios_Asociaciones] FOREIGN KEY ([IdAsociacion]) REFERENCES [dbo].[Asociaciones] ([IdAsociacion]),
    CONSTRAINT [FK_Usuarios_Empresas] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresas] ([IdEmpresa]),
    CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY ([IdRol]) REFERENCES [dbo].[Roles] ([IdRol])
);










GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'SuperAdmin=0, Administrador=1, StaffAdmin=2, Vigilancia=3, Residente=4, Proveedor=5', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Usuarios', @level2type = N'COLUMN', @level2name = N'IdRol';

