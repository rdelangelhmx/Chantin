CREATE TABLE [dbo].[EmpresaRegimenes] (
    [IdRegimenFiscal] INT          NOT NULL,
    [IdEmpresa]       INT          NOT NULL,
    [TipoComprobante] INT          NULL,
    [Digitos]         INT          NULL,
    [Serie]           NVARCHAR (5) NULL,
    [Folio]           INT          NULL,
    [fAlta]           DATETIME     NULL,
    [fBaja]           DATETIME     NULL,
    [Estatus]         INT          NULL,
    CONSTRAINT [PK_EmpresaRegimenes_1] PRIMARY KEY CLUSTERED ([IdRegimenFiscal] ASC, [IdEmpresa] ASC),
    CONSTRAINT [FK_EmpresaRegimenes_CatRegimenesFiscales] FOREIGN KEY ([IdRegimenFiscal]) REFERENCES [dbo].[CatRegimenesFiscales] ([IdRegimenFiscal]),
    CONSTRAINT [FK_EmpresaRegimenes_Empresas] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresas] ([IdEmpresa])
);






GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Factura = 1,Nota_Credito = 2,Recibo_Nomina = 3,Recibo_Honorarios = 4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmpresaRegimenes', @level2type = N'COLUMN', @level2name = N'TipoComprobante';

