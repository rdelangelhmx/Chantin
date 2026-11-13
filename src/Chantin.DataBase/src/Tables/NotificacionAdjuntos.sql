CREATE TABLE [dbo].[NotificacionAdjuntos] (
    [IdAdjunto]         INT           IDENTITY (1, 1) NOT NULL,
    [IdNotificacion]    INT           NOT NULL,
    [IdAsociacion]      INT           NOT NULL,
    [IdEmpresa]         INT           NOT NULL,
    [Nombre]            VARCHAR (250) NOT NULL,
    [Archivo]           VARCHAR (50)  NOT NULL,
    [fAlta]             DATETIME      NULL,
    [IdUsuarioAlta]     INT           NULL,
    [fModifica]         DATETIME      NULL,
    [IdUsuarioModifica] INT           NULL,
    [fBaja]             DATETIME      NULL,
    [IdUsuarioBaja]     INT           NULL,
    [Estatus]           BIT           CONSTRAINT [DF_NotificacionAdjuntos_Estatus] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_NotificacionAdjuntos] PRIMARY KEY CLUSTERED ([IdAdjunto] ASC),
    CONSTRAINT [FK_NotificacionAdjuntos_Notificaciones] FOREIGN KEY ([IdNotificacion]) REFERENCES [dbo].[Notificaciones] ([IdNotificacion])
);

