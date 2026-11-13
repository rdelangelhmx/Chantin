CREATE TABLE [dbo].[AsociacionDomicilios] (
    [IdAsociacion] INT NOT NULL,
    [IdDomicilio]  INT NOT NULL,
    CONSTRAINT [PK_AsociacionDomicilios] PRIMARY KEY CLUSTERED ([IdAsociacion] ASC, [IdDomicilio] ASC),
    CONSTRAINT [FK_AsociacionDomicilios_Asociaciones] FOREIGN KEY ([IdAsociacion]) REFERENCES [dbo].[Asociaciones] ([IdAsociacion]),
    CONSTRAINT [FK_AsociacionDomicilios_Domicilios] FOREIGN KEY ([IdDomicilio]) REFERENCES [dbo].[Domicilios] ([IdDomicilio])
);

