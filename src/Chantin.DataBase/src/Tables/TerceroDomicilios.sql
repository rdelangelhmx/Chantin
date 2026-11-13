CREATE TABLE [dbo].[TerceroDomicilios] (
    [IdTercero]   INT NOT NULL,
    [IdDomicilio] INT NOT NULL,
    CONSTRAINT [PK_TerceroDomicilios] PRIMARY KEY CLUSTERED ([IdTercero] ASC, [IdDomicilio] ASC),
    CONSTRAINT [FK_TerceroDomicilios_Domicilios] FOREIGN KEY ([IdDomicilio]) REFERENCES [dbo].[Domicilios] ([IdDomicilio]),
    CONSTRAINT [FK_TerceroDomicilios_Terceros] FOREIGN KEY ([IdTercero]) REFERENCES [dbo].[Terceros] ([IdTercero])
);

