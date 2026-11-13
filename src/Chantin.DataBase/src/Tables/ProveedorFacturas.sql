CREATE TABLE [dbo].[ProveedorFacturas] (
    [IdFactura]         BIGINT          IDENTITY (1, 1) NOT NULL,
    [IdProveedor]       INT             NULL,
    [IdAsociacion]      INT             NOT NULL,
    [IdEmpresa]         INT             NOT NULL,
    [TipoDocumento]     INT             CONSTRAINT [DF_ProveedorFacturas_TipoDocumento] DEFAULT ((4)) NULL,
    [Factura]           VARCHAR (50)    NULL,
    [fFactura]          DATETIME        CONSTRAINT [DF_ProveedorFacturas_fFactura] DEFAULT (getdate()) NULL,
    [Descripción]       VARCHAR (500)   NULL,
    [Subtotal]          DECIMAL (12, 2) NULL,
    [Impuestos]         DECIMAL (12, 2) NULL,
    [Total]             DECIMAL (12, 2) NULL,
    [Saldo]             DECIMAL (12, 2) NULL,
    [Descuento]         DECIMAL (12, 2) NULL,
    [fAlta]             DATETIME        CONSTRAINT [DF_ProveedorFacturas_fAlta] DEFAULT (getdate()) NOT NULL,
    [IdUsuarioAlta]     INT             NULL,
    [fModifica]         DATETIME        NULL,
    [IdUsuarioModifica] INT             NULL,
    [fBaja]             DATETIME        NULL,
    [IdUsuarioBaja]     INT             NULL,
    [Estatus]           BIT             CONSTRAINT [DF_ProveedorFacturas_Estatus] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_ProveedorFacturas] PRIMARY KEY CLUSTERED ([IdFactura] ASC),
    CONSTRAINT [FK_ProveedorFacturas_Proveedores] FOREIGN KEY ([IdProveedor]) REFERENCES [dbo].[Proveedores] ([IdProveedor])
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
Otros = 0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ProveedorFacturas', @level2type = N'COLUMN', @level2name = N'TipoDocumento';

