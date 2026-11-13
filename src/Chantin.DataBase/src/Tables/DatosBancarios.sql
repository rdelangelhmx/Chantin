CREATE TABLE [dbo].[DatosBancarios] (
    [IdDatoBancario]    INT             IDENTITY (1, 1) NOT NULL,
    [IdBanco]           INT             NOT NULL,
    [TipoCuenta]        INT             NULL,
    [Cuenta]            VARCHAR (12)    NULL,
    [CLABE]             VARCHAR (18)    NULL,
    [SaldoInicial]      DECIMAL (15, 3) NULL,
    [SaldoFinal]        DECIMAL (15, 3) NULL,
    [fAlta]             DATETIME        NULL,
    [IdUsuarioAlta]     INT             NULL,
    [fModifica]         DATETIME        NULL,
    [IdUsuarioModifica] INT             NULL,
    [fBaja]             DATETIME        NULL,
    [IdUsuarioBaja]     INT             NULL,
    [Estatus]           BIT             CONSTRAINT [DF__DatosBanc__Estat__571DF1D5] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_DatosBancarios] PRIMARY KEY CLUSTERED ([IdDatoBancario] ASC),
    CONSTRAINT [FK_DatosBancarios_CatBancos] FOREIGN KEY ([IdBanco]) REFERENCES [dbo].[CatBancos] ([IdBanco])
);




GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Debito = 1, Credito = 2, Cheques = 3, Ahorro = 4, Otra = 5', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DatosBancarios', @level2type = N'COLUMN', @level2name = N'TipoCuenta';

