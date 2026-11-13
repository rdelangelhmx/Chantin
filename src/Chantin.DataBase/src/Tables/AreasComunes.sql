CREATE TABLE [dbo].[AreasComunes] (
    [IdAreaComun]       INT             IDENTITY (1, 1) NOT NULL,
    [IdAsociacion]      INT             NOT NULL,
    [IdEmpresa]         INT             NOT NULL,
    [Nombre]            VARCHAR (250)   NULL,
    [Clave]             VARCHAR (6)     NULL,
    [Renta]             DECIMAL (12, 3) NULL,
    [fAlta]             DATETIME        NULL,
    [IdUsuarioAlta]     INT             NULL,
    [fModifica]         DATETIME        NULL,
    [IdUsuarioModifica] INT             NULL,
    [fBaja]             DATETIME        NULL,
    [IdUsuarioBaja]     INT             NULL,
    [Estatus]           BIT             CONSTRAINT [DF__AreasComu__Estat__5165187F] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_AreasComunes_1] PRIMARY KEY CLUSTERED ([IdAreaComun] ASC),
    CONSTRAINT [FK_AreasComunes_Asociaciones] FOREIGN KEY ([IdAsociacion]) REFERENCES [dbo].[Asociaciones] ([IdAsociacion])
);



