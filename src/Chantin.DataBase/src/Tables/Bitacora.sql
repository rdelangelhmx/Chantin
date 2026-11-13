CREATE TABLE [dbo].[Bitacora] (
    [IdBitacora]      INT           IDENTITY (1, 1) NOT NULL,
    [IdEmpresa]       INT           NOT NULL,
    [Tabla]           VARCHAR (50)  NULL,
    [TipoAccion]      INT           NULL,
    [Accion]          VARCHAR (MAX) NULL,
    [IdUsuarioAfecta] INT           NULL,
    [fAfectacion]     DATETIME      NULL,
    [Estatus]         BIT           CONSTRAINT [DF__Bitacora__Estatu__534D60F1] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Bitacora_1] PRIMARY KEY CLUSTERED ([IdBitacora] ASC),
    CONSTRAINT [FK_Bitacora_Empresas] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresas] ([IdEmpresa])
);




GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Crete = 1, Read = 2, Update = 3, Delete = 4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Bitacora', @level2type = N'COLUMN', @level2name = N'TipoAccion';

