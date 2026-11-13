CREATE TABLE [dbo].[ReunionDocumentos] (
    [IdDocumento]    INT           IDENTITY (1, 1) NOT NULL,
    [IdReunion]      INT           NOT NULL,
    [IdAsociacion]   INT           NOT NULL,
    [IdEmpresa]      INT           NOT NULL,
    [TipoDocumento]  INT           NULL,
    [Archivo]        VARCHAR (50)  NULL,
    [Descripcion]    VARCHAR (500) NULL,
    [fCarga]         DATETIME      NULL,
    [IdUsuarioCarga] INT           NULL,
    [fBaja]          DATETIME      NULL,
    [IdUsuarioBaja]  INT           NULL,
    [Estatus]        BIT           CONSTRAINT [DF_ReunionDocumentos_Estatus] DEFAULT ((1)) NULL,
    CONSTRAINT [PK__ReunionD__E5207347D5C4FFFF] PRIMARY KEY CLUSTERED ([IdDocumento] ASC),
    CONSTRAINT [FK_ReunionDocumentos_Reuniones] FOREIGN KEY ([IdReunion]) REFERENCES [dbo].[Reuniones] ([IdReunion])
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
Otros = 0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReunionDocumentos', @level2type = N'COLUMN', @level2name = N'TipoDocumento';

