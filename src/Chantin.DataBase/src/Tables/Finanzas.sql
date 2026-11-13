CREATE TABLE [dbo].[Finanzas] (
    [IdFinanzas]        INT             IDENTITY (1, 1) NOT NULL,
    [IdConcepto]        INT             NOT NULL,
    [IdAsociacion]      INT             NOT NULL,
    [IdEmpresa]         INT             NOT NULL,
    [Monto]             DECIMAL (12, 2) NULL,
    [Recargo]           DECIMAL (12, 2) NULL,
    [Descuento]         DECIMAL (12, 2) NULL,
    [fInicio]           DATETIME        NULL,
    [fFinal]            DATETIME        NULL,
    [fAlta]             DATETIME        NULL,
    [IdUsuarioAlta]     INT             NULL,
    [fModifica]         DATETIME        NULL,
    [IdUsuarioModifica] INT             NULL,
    [fBaja]             DATETIME        NULL,
    [IdUsuarioBaja]     INT             NULL,
    [Estatus]           BIT             CONSTRAINT [DF__Finanzas__Estatu__503BEA1C] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Finanzas] PRIMARY KEY CLUSTERED ([IdFinanzas] ASC),
    CONSTRAINT [FK_Finanzas_FinanzasConceptos] FOREIGN KEY ([IdConcepto]) REFERENCES [dbo].[FinanzasConceptos] ([IdConcepto])
);



