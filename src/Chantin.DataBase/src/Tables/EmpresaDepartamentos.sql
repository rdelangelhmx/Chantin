CREATE TABLE [dbo].[EmpresaDepartamentos] (
    [IdDepartamento]    INT           IDENTITY (1, 1) NOT NULL,
    [IdEmpresa]         INT           NOT NULL,
    [Nombre]            VARCHAR (100) NULL,
    [Clave]             VARCHAR (6)   NULL,
    [Correo]            VARCHAR (500) NULL,
    [fAlta]             DATETIME      NULL,
    [IdUsuarioAlta]     INT           NULL,
    [fModifica]         DATETIME      NULL,
    [IdUsuarioModifica] INT           NULL,
    [fBaja]             DATETIME      NULL,
    [IdUsuarioBaja]     INT           NULL,
    [Estatus]           BIT           CONSTRAINT [DF__EmpresaDe__Estat__2645B050] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_EmpresaDepartamentos_1] PRIMARY KEY CLUSTERED ([IdDepartamento] ASC),
    CONSTRAINT [FK_EmpresaDepartamentos_Empresas] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresas] ([IdEmpresa])
);



