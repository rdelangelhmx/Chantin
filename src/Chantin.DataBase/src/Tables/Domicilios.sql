CREATE TABLE [dbo].[Domicilios] (
    [IdDomicilio]       INT           IDENTITY (1, 1) NOT NULL,
    [TipoDomicilio]     INT           NULL,
    [Calle]             VARCHAR (250) NULL,
    [Exterior]          VARCHAR (15)  NULL,
    [Interior]          VARCHAR (25)  NULL,
    [IdPais]            INT           NULL,
    [IdEstado]          INT           NULL,
    [IdMunicipio]       INT           NULL,
    [IdColonia]         INT           NULL,
    [CodPos]            VARCHAR (5)   NULL,
    [fAlta]             DATETIME      NULL,
    [IdUsuarioAlta]     INT           NULL,
    [fModifica]         DATETIME      NULL,
    [IdUsuarioModifica] INT           NULL,
    [fBaja]             DATETIME      NULL,
    [IdUsuarioBaja]     INT           NULL,
    [Estatus]           BIT           CONSTRAINT [DF__tmp_ms_xx__Estat__2AE0483B] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Direcciones] PRIMARY KEY CLUSTERED ([IdDomicilio] ASC),
    CONSTRAINT [FK_Domicilios_Poblaciones] FOREIGN KEY ([IdPais], [IdEstado], [IdMunicipio], [IdColonia]) REFERENCES [dbo].[Poblaciones] ([IdPais], [IdEstado], [IdMunicipio], [IdColonia])
);








GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Casa = 1, Oficina = 2, Fiscal = 3, Otro = 4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Domicilios', @level2type = N'COLUMN', @level2name = N'TipoDomicilio';

