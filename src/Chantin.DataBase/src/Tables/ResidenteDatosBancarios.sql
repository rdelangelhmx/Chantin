CREATE TABLE [dbo].[ResidenteDatosBancarios] (
    [IdResidente]    INT NOT NULL,
    [IdDatoBancario] INT NOT NULL,
    CONSTRAINT [PK_ResidenteDatosBancarios] PRIMARY KEY CLUSTERED ([IdResidente] ASC, [IdDatoBancario] ASC),
    CONSTRAINT [FK_ResidenteDatosBancarios_DatosBancarios] FOREIGN KEY ([IdDatoBancario]) REFERENCES [dbo].[DatosBancarios] ([IdDatoBancario]),
    CONSTRAINT [FK_ResidenteDatosBancarios_Residentes] FOREIGN KEY ([IdResidente]) REFERENCES [dbo].[Residentes] ([IdResidente])
);

