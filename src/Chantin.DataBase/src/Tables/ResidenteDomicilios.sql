CREATE TABLE [dbo].[ResidenteDomicilios] (
    [IdResidente] INT NOT NULL,
    [IdDomicilio] INT NOT NULL,
    CONSTRAINT [PK_ResidenteDomicilios] PRIMARY KEY CLUSTERED ([IdResidente] ASC, [IdDomicilio] ASC),
    CONSTRAINT [FK_ResidenteDomicilios_Domicilios] FOREIGN KEY ([IdDomicilio]) REFERENCES [dbo].[Domicilios] ([IdDomicilio]),
    CONSTRAINT [FK_ResidenteDomicilios_Residentes] FOREIGN KEY ([IdResidente]) REFERENCES [dbo].[Residentes] ([IdResidente])
);

