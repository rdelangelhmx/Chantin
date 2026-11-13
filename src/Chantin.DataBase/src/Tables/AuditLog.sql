CREATE TABLE [dbo].[AuditLog] (
    [IdLog]     INT            IDENTITY (1, 1) NOT NULL,
    [IdUsuario] INT            NULL,
    [IdOpcion]  INT            NULL,
    [IdAcccion] NVARCHAR (1)   NULL,
    [Mensaje]   NVARCHAR (MAX) NULL,
    [fAlta]     DATETIME       CONSTRAINT [DF_AuditLog_fAlta] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_tblAuditLog] PRIMARY KEY CLUSTERED ([IdLog] ASC),
    CONSTRAINT [FK_AuditLog_Opciones] FOREIGN KEY ([IdOpcion]) REFERENCES [dbo].[Opciones] ([IdOpcion]),
    CONSTRAINT [FK_AuditLog_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([IdUsuario])
);

