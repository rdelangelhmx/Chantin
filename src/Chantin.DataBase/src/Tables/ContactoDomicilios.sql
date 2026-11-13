CREATE TABLE [dbo].[ContactoDomicilios] (
    [IdContacto]  INT NOT NULL,
    [IdDomicilio] INT NOT NULL,
    CONSTRAINT [PK_ContactoDomicilios] PRIMARY KEY CLUSTERED ([IdContacto] ASC, [IdDomicilio] ASC),
    CONSTRAINT [FK_ContactoDomicilios_Contactos] FOREIGN KEY ([IdContacto]) REFERENCES [dbo].[Contactos] ([IdContacto]),
    CONSTRAINT [FK_ContactoDomicilios_Domicilios] FOREIGN KEY ([IdDomicilio]) REFERENCES [dbo].[Domicilios] ([IdDomicilio])
);

