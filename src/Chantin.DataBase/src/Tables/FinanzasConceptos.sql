CREATE TABLE [dbo].[FinanzasConceptos] (
    [IdConcepto]        INT           IDENTITY (1, 1) NOT NULL,
    [IdAsociacion]      INT           NOT NULL,
    [IdEmpresa]         INT           NOT NULL,
    [Clave]             VARCHAR (6)   NULL,
    [TipoConcepto]      INT           NULL,
    [Nombre]            VARCHAR (100) NULL,
    [fAlta]             DATETIME      NULL,
    [IdUsuarioAlta]     INT           NULL,
    [fModifica]         DATETIME      NULL,
    [IdUsuarioModifica] INT           NULL,
    [fBaja]             DATETIME      NULL,
    [IdUsuarioBaja]     INT           NULL,
    [Estatus]           BIT           CONSTRAINT [DF__FinanzasC__Estat__45BE5BA9] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_FinanzasConceptos] PRIMARY KEY CLUSTERED ([IdConcepto] ASC)
);




GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Cargo = 1, Abono = 2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FinanzasConceptos', @level2type = N'COLUMN', @level2name = N'TipoConcepto';

