CREATE TABLE [dbo].[AsociacionDatosBancarios] (
    [IdAsociacion]   INT NOT NULL,
    [IdDatoBancario] INT NOT NULL,
    CONSTRAINT [PK_AsociacionDatosBancarios] PRIMARY KEY CLUSTERED ([IdAsociacion] ASC, [IdDatoBancario] ASC),
    CONSTRAINT [FK_AsociacionDatosBancarios_Asociaciones] FOREIGN KEY ([IdAsociacion]) REFERENCES [dbo].[Asociaciones] ([IdAsociacion]),
    CONSTRAINT [FK_AsociacionDatosBancarios_DatosBancarios] FOREIGN KEY ([IdDatoBancario]) REFERENCES [dbo].[DatosBancarios] ([IdDatoBancario])
);

