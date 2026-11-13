CREATE TABLE [dbo].[UsuarioDomicilios] (
    [IdUsuario]   INT NOT NULL,
    [IdDomicilio] INT NOT NULL,
    CONSTRAINT [PK_UsuarioDomicilios] PRIMARY KEY CLUSTERED ([IdUsuario] ASC, [IdDomicilio] ASC),
    CONSTRAINT [FK_UsuarioDomicilios_Domicilios] FOREIGN KEY ([IdDomicilio]) REFERENCES [dbo].[Domicilios] ([IdDomicilio]),
    CONSTRAINT [FK_UsuarioDomicilios_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([IdUsuario])
);

