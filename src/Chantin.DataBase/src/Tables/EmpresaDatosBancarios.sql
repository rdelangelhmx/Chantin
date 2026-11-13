CREATE TABLE [dbo].[EmpresaDatosBancarios] (
    [IdEmpresa]      INT NOT NULL,
    [IdDatoBancario] INT NOT NULL,
    CONSTRAINT [PK_EmpresaDatosBancarios] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdDatoBancario] ASC),
    CONSTRAINT [FK_EmpresaDatosBancarios_DatosBancarios] FOREIGN KEY ([IdDatoBancario]) REFERENCES [dbo].[DatosBancarios] ([IdDatoBancario]),
    CONSTRAINT [FK_EmpresaDatosBancarios_Empresas] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresas] ([IdEmpresa])
);

