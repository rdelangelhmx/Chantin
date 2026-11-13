CREATE TABLE [dbo].[EmpresaPuestos] (
    [IdPuesto]          INT          IDENTITY (1, 1) NOT NULL,
    [IdEmpresa]         INT          NOT NULL,
    [IdDepartamento]    INT          NOT NULL,
    [Nombre]            VARCHAR (50) NULL,
    [Clave]             VARCHAR (6)  NULL,
    [fAlta]             DATETIME     NULL,
    [IdUsuarioAlta]     INT          NULL,
    [fModifica]         DATETIME     NULL,
    [IdUsuarioModifica] INT          NULL,
    [fBaja]             DATETIME     NULL,
    [IdUsuarioBaja]     INT          NULL,
    [Estatus]           BIT          CONSTRAINT [DF__EmpresaPu__Estat__4242D080] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Puestos_1] PRIMARY KEY CLUSTERED ([IdPuesto] ASC, [IdEmpresa] ASC),
    CONSTRAINT [FK_EmpresaPuestos_EmpresaDepartamentos] FOREIGN KEY ([IdDepartamento]) REFERENCES [dbo].[EmpresaDepartamentos] ([IdDepartamento]),
    CONSTRAINT [FK_Puestos_Empresas] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresas] ([IdEmpresa])
);



