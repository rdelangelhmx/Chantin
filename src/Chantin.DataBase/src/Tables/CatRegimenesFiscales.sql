CREATE TABLE [dbo].[CatRegimenesFiscales] (
    [IdRegimenFiscal] INT           IDENTITY (1, 1) NOT NULL,
    [Clave]           VARCHAR (3)   NULL,
    [Nombre]          VARCHAR (150) NULL,
    [Fisica]          BIT           NULL,
    [Moral]           BIT           NULL,
    CONSTRAINT [PK_catRegimenesFiscales] PRIMARY KEY CLUSTERED ([IdRegimenFiscal] ASC)
);

