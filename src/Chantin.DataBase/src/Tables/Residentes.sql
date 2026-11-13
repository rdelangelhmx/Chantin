CREATE TABLE [dbo].[Residentes] (
    [IdResidente]        INT           IDENTITY (1, 1) NOT NULL,
    [IdAsociacion]       INT           NOT NULL,
    [IdEmpresa]          INT           NOT NULL,
    [IdUsuario]          INT           NOT NULL,
    [Nombre]             VARCHAR (100) NULL,
    [Apellidos]          VARCHAR (200) NULL,
    [Clave]              VARCHAR (6)   NULL,
    [RFC]                VARCHAR (13)  NULL,
    [CURP]               VARCHAR (18)  NULL,
    [Genero]             INT           NULL,
    [EdoCivil]           INT           NULL,
    [TipoVivienda]       INT           NULL,
    [TipoGrupoResidente] INT           NULL,
    [MesaDirectiva]      BIT           NULL,
    [ComiteTecnico]      BIT           NULL,
    [ComiteVigilancia]   BIT           NULL,
    [Representante]      BIT           NULL,
    [Calle]              VARCHAR (250) NULL,
    [Exterior]           VARCHAR (15)  NULL,
    [Interior]           VARCHAR (25)  NULL,
    [Manzana]            VARCHAR (10)  NULL,
    [Lote]               VARCHAR (10)  NULL,
    [Ocupantes]          INT           NULL,
    [Telefono]           VARCHAR (15)  NULL,
    [Celular]            VARCHAR (15)  NULL,
    [Facebook]           VARCHAR (150) NULL,
    [Twitter]            VARCHAR (150) NULL,
    [Google]             VARCHAR (150) NULL,
    [LinkedIn]           VARCHAR (150) NULL,
    [Instagram]          VARCHAR (150) NULL,
    [fAlta]              DATETIME      NULL,
    [IdUsuarioAlta]      INT           NULL,
    [fModifica]          DATETIME      NULL,
    [IdUsuarioModifica]  INT           NULL,
    [fBaja]              DATETIME      NULL,
    [IdUsuarioBaja]      INT           NULL,
    [Estatus]            BIT           CONSTRAINT [DF__tmp_ms_xx__Estat__40F9A68C] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Residentes_1] PRIMARY KEY CLUSTERED ([IdResidente] ASC),
    CONSTRAINT [FK_Residentes_Asociaciones] FOREIGN KEY ([IdAsociacion]) REFERENCES [dbo].[Asociaciones] ([IdAsociacion]),
    CONSTRAINT [FK_Residentes_AsociacionGrupos] FOREIGN KEY ([TipoGrupoResidente]) REFERENCES [dbo].[AsociacionGrupos] ([IdGrupo]),
    CONSTRAINT [FK_Residentes_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([IdUsuario])
);




GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Casa = 1, Condominio = 2, Departamento = 3, Residencia = 4, Otro = 5', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Residentes', @level2type = N'COLUMN', @level2name = N'TipoVivienda';

