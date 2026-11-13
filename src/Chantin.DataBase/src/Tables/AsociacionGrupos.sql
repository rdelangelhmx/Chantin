CREATE TABLE [dbo].[AsociacionGrupos] (
    [IdGrupo]            INT           IDENTITY (1, 1) NOT NULL,
    [IdAsociacion]       INT           NOT NULL,
    [IdEmpresa]          INT           NOT NULL,
    [Nombre]             VARCHAR (250) NULL,
    [TipoGrupoResidente] INT           CONSTRAINT [DF__EmpresaGr__TipoG__4E53A1AA] DEFAULT ((1)) NULL,
    [fAlta]              DATETIME      NULL,
    [IdUsuarioAlta]      INT           NULL,
    [fModifica]          DATETIME      NULL,
    [IdUsuarioModifica]  INT           NULL,
    [fBaja]              DATETIME      NULL,
    [IdUsuarioBaja]      INT           NULL,
    [Estatus]            BIT           CONSTRAINT [DF__EmpresaGr__Estat__4F47C5E3] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_EmpresaGrupos_1] PRIMARY KEY CLUSTERED ([IdGrupo] ASC),
    CONSTRAINT [FK_EmpresaGrupos_Asociaciones] FOREIGN KEY ([IdAsociacion]) REFERENCES [dbo].[Asociaciones] ([IdAsociacion])
);



