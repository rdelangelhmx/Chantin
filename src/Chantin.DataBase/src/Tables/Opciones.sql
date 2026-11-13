CREATE TABLE [dbo].[Opciones] (
    [IdOpcion]    INT            NOT NULL,
    [Nombre]      NVARCHAR (50)  NULL,
    [Controlador] NVARCHAR (250) NULL,
    [Vista]       NVARCHAR (250) NULL,
    [Icono]       NVARCHAR (50)  NULL,
    [Parametros]  NVARCHAR (500) NULL,
    [idPadre]     INT            NULL,
    [IsPrincipal] BIT            CONSTRAINT [DF_Opciones_IsPrincipal] DEFAULT ((0)) NULL,
    [Estatus]     BIT            CONSTRAINT [DF__Opciones__Estatu__5BE2A6F2] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Opciones] PRIMARY KEY CLUSTERED ([IdOpcion] ASC)
);

