CREATE TABLE [dbo].[Notificaciones] (
    [IdNotificacion]   INT           IDENTITY (1, 1) NOT NULL,
    [IdEmpresa]        INT           NOT NULL,
    [IdAsociacion]     INT           NULL,
    [TipoNotificacion] INT           NOT NULL,
    [Importancia]      INT           NOT NULL,
    [Adjuntos]         BIT           CONSTRAINT [DF__tmp_ms_xx__Adjun__3C34F16F] DEFAULT ((0)) NOT NULL,
    [IdCrea]           INT           NOT NULL,
    [TipoCrea]         INT           NOT NULL,
    [IdDestino]        INT           NOT NULL,
    [TipoDestino]      INT           CONSTRAINT [DF_Notificaciones_TipoDestino] DEFAULT ((1)) NOT NULL,
    [Asunto]           VARCHAR (150) NOT NULL,
    [Mensaje]          VARCHAR (MAX) NOT NULL,
    [fRegistro]        DATETIME      NOT NULL,
    [fTermino]         DATETIME      NULL,
    [fEnvio]           DATETIME      NULL,
    [fLectura]         DATETIME      NULL,
    [fRespuesta]       DATETIME      NULL,
    [Estatus]          BIT           CONSTRAINT [DF__tmp_ms_xx__Estat__3D2915A8] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Notificaciones_1] PRIMARY KEY CLUSTERED ([IdNotificacion] ASC),
    CONSTRAINT [FK_Notificaciones_Empresas] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresas] ([IdEmpresa])
);






GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'SuperAdmin = 0,Administrador = 1,Empleado = 2,Residente = 3,Vigilancia = 4,Proveedor = 5', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Notificaciones', @level2type = N'COLUMN', @level2name = N'TipoDestino';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'SuperAdmin = 0,Administrador = 1,Empleado = 2,Residente = 3,Vigilancia = 4,Proveedor = 5', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Notificaciones', @level2type = N'COLUMN', @level2name = N'TipoCrea';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Urgente = 1,Alta = 2,Normal = 3,Baja = 4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Notificaciones', @level2type = N'COLUMN', @level2name = N'Importancia';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Publicacion = 1,
Aviso = 2,
Comunicado = 3,
Logro = 4,
Solicitud = 5,
Comentario = 6,
Denuncia = 7,
Mensaje = 8, // Correo, Interno
Alerta = 9, // SMS, WhatsApp, Push
Otro = 0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Notificaciones', @level2type = N'COLUMN', @level2name = N'TipoNotificacion';

