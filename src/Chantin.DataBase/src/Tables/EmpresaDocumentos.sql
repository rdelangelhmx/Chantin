CREATE TABLE [dbo].[EmpresaDocumentos] (
    [IdDocumento]    INT           IDENTITY (1, 1) NOT NULL,
    [IdEmpresa]      INT           NOT NULL,
    [TipoDocumento]  INT           NULL,
    [Archivo]        VARCHAR (25)  NULL,
    [Descripcion]    VARCHAR (500) NULL,
    [fCarga]         DATETIME      NULL,
    [IdUsuarioCarga] INT           NULL,
    [fBaja]          DATETIME      NULL,
    [IdUsuarioBaja]  INT           NULL,
    [Estatus]        BIT           CONSTRAINT [DF_EmpresaDocumentos_Estatus] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_EmrpesaDocumentos] PRIMARY KEY CLUSTERED ([IdDocumento] ASC),
    CONSTRAINT [FK_EmpresaDocumentos_Empresas] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresas] ([IdEmpresa])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Comunicados = 1,
Asambleas = 2,
Recibos = 3,
Facturas = 4,
Cotizaciones = 5,
Comprobantes = 6,
EstadosCuenta = 7,
Imagenes = 8,
Reglamentos = 9,
Otros = 0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmpresaDocumentos', @level2type = N'COLUMN', @level2name = N'TipoDocumento';

