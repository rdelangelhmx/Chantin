CREATE TABLE [dbo].[EmpresaDomicilios] (
    [IdEmpresa]   INT NOT NULL,
    [IdDomicilio] INT NOT NULL,
    CONSTRAINT [PK_EmpresaDomicilios] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdDomicilio] ASC),
    CONSTRAINT [FK_EmpresaDomicilios_Domicilios] FOREIGN KEY ([IdDomicilio]) REFERENCES [dbo].[Domicilios] ([IdDomicilio]),
    CONSTRAINT [FK_EmpresaDomicilios_Empresas] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresas] ([IdEmpresa])
);

