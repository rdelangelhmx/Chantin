CREATE TABLE [dbo].[CatBancos] (
    [IdBanco]     INT           IDENTITY (1, 1) NOT NULL,
    [Clave]       VARCHAR (5)   NULL,
    [Nombre]      VARCHAR (25)  NULL,
    [RazonSocial] VARCHAR (500) NULL,
    [Estatus]     BIT           CONSTRAINT [DF__CatBancos__Estat__5441852A] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_CatBancos] PRIMARY KEY CLUSTERED ([IdBanco] ASC)
);



