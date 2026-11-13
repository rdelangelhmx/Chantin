CREATE TABLE [dbo].[BitacoraVigilancia] (
    [IdBitacora]          BIGINT        IDENTITY (1, 1) NOT NULL,
    [IdEmpresa]           INT           NOT NULL,
    [IdAsociacion]        INT           NOT NULL,
    [IdEmpresaVigilancia] INT           NOT NULL,
    [IdVigilante]         INT           NOT NULL,
    [fAcceso]             DATETIME      NOT NULL,
    [fSalida]             DATETIME      NULL,
    [Identificacion]      INT           NULL,
    [IdResidente]         INT           NULL,
    [Evidencia]           VARCHAR (250) NULL,
    CONSTRAINT [PK_BitacoraVigilancia] PRIMARY KEY CLUSTERED ([IdBitacora] ASC),
    CONSTRAINT [FK_BitacoraVigilancia_Asociaciones] FOREIGN KEY ([IdAsociacion]) REFERENCES [dbo].[Asociaciones] ([IdAsociacion]),
    CONSTRAINT [FK_BitacoraVigilancia_Empresas] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresas] ([IdEmpresa]),
    CONSTRAINT [FK_BitacoraVigilancia_Proveedores] FOREIGN KEY ([IdEmpresaVigilancia]) REFERENCES [dbo].[Proveedores] ([IdProveedor]),
    CONSTRAINT [FK_BitacoraVigilancia_Residentes] FOREIGN KEY ([IdResidente]) REFERENCES [dbo].[Residentes] ([IdResidente]),
    CONSTRAINT [FK_BitacoraVigilancia_Terceros] FOREIGN KEY ([IdVigilante]) REFERENCES [dbo].[Terceros] ([IdTercero])
);

