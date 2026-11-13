CREATE TABLE [dbo].[Terceros] (
    [IdTercero]         INT           IDENTITY (1, 1) NOT NULL,
    [IdEmpresa]         INT           NULL,
    [IdResidente]       INT           NULL,
    [IdUsuario]         INT           NULL,
    [Nombre]            VARCHAR (100) NULL,
    [Apellidos]         VARCHAR (200) NULL,
    [Clave]             VARCHAR (6)   NULL,
    [TipoTercero]       INT           NULL,
    [IdPuesto]          INT           NULL,
    [RFC]               VARCHAR (15)  NULL,
    [CURP]              VARCHAR (20)  NULL,
    [Telefono]          VARCHAR (10)  NULL,
    [Celular]           VARCHAR (10)  NULL,
    [Logo]              VARCHAR (500) NULL,
    [Dominio]           VARCHAR (500) NULL,
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
    [Estatus]           BIT           CONSTRAINT [DF__tmp_ms_xx__Estat__2180FB33] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Terceros_1] PRIMARY KEY CLUSTERED ([IdTercero] ASC),
    CONSTRAINT [FK_Terceros_EmpresaPuestos] FOREIGN KEY ([IdPuesto], [IdEmpresa]) REFERENCES [dbo].[EmpresaPuestos] ([IdPuesto], [IdEmpresa]),
    CONSTRAINT [FK_Terceros_Empresas] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresas] ([IdEmpresa]),
    CONSTRAINT [FK_Terceros_Residentes] FOREIGN KEY ([IdResidente]) REFERENCES [dbo].[Residentes] ([IdResidente]),
    CONSTRAINT [FK_Terceros_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([IdUsuario])
);




GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Proveedor = 1         Personal = 2        Visitante = 3        Vigilancia = 4        Domestico = 5        Otro = 6', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Terceros', @level2type = N'COLUMN', @level2name = N'IdTercero';

