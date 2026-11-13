CREATE TABLE [dbo].[Parametros] (
    [IdParametro]       INT            IDENTITY (1, 1) NOT NULL,
    [IdEmpresa]         INT            NOT NULL,
    [Nombre]            VARCHAR (50)   NULL,
    [Descripcion]       NVARCHAR (250) NULL,
    [Valor]             NVARCHAR (MAX) NULL,
    [Tipo]              VARCHAR (3)    NULL,
    [fAlta]             DATETIME       NULL,
    [IdUsuarioAlta]     INT            NULL,
    [fModifica]         DATETIME       NULL,
    [IdUsuarioModifica] INT            NULL,
    [fBaja]             DATETIME       NULL,
    [IdUsuarioBaja]     INT            NULL,
    [Estatus]           BIT            CONSTRAINT [DF_Parametros_Estatus] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Parametros] PRIMARY KEY CLUSTERED ([IdParametro] ASC),
    CONSTRAINT [FK_Parametros_Empresas] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresas] ([IdEmpresa])
);




GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'str = String   int = Numerico Entero   dec = Numerico Decimal   fec = Fecha', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Parametros', @level2type = N'COLUMN', @level2name = N'Tipo';

