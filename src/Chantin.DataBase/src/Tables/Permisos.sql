CREATE TABLE [dbo].[Permisos] (
    [IdRol]             INT          NOT NULL,
    [IdOpcion]          INT          NOT NULL,
    [Acceso]            NVARCHAR (5) NULL,
    [fAlta]             DATETIME     NULL,
    [IdUsuarioAlta]     INT          NULL,
    [fModifica]         DATETIME     NULL,
    [IdUsuarioModifica] INT          NULL,
    [fBaja]             DATETIME     NULL,
    [IdUsuarioBaja]     INT          NULL,
    CONSTRAINT [PK_Permisos_1] PRIMARY KEY CLUSTERED ([IdRol] ASC, [IdOpcion] ASC),
    CONSTRAINT [FK_Permisos_Opciones] FOREIGN KEY ([IdOpcion]) REFERENCES [dbo].[Opciones] ([IdOpcion]),
    CONSTRAINT [FK_Permisos_Roles] FOREIGN KEY ([IdRol]) REFERENCES [dbo].[Roles] ([IdRol])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'SuperAdmin=0, Administrador=1, StaffAdmin=2, Vigilante=3, Residente=4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Permisos', @level2type = N'COLUMN', @level2name = N'IdRol';

