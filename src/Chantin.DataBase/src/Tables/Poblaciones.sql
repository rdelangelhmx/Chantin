CREATE TABLE [dbo].[Poblaciones] (
    [IdPais]         INT           CONSTRAINT [DF__tmp_ms_xx__IdPai__182C9B23] DEFAULT ((146)) NOT NULL,
    [IdEstado]       INT           NOT NULL,
    [IdMunicipio]    INT           NOT NULL,
    [IdColonia]      INT           NOT NULL,
    [Pais]           VARCHAR (100) NOT NULL,
    [Estado]         VARCHAR (100) NOT NULL,
    [Municipio]      VARCHAR (150) NOT NULL,
    [Colonia]        VARCHAR (250) NULL,
    [IdAsentamiento] INT           NOT NULL,
    [Asentamiento]   VARCHAR (150) NULL,
    [TipoZona]       VARCHAR (25)  NULL,
    [CodPos]         VARCHAR (5)   NULL,
    [Estatus]        BIT           CONSTRAINT [DF__tmp_ms_xx__Estat__1920BF5C] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Poblaciones] PRIMARY KEY CLUSTERED ([IdPais] ASC, [IdEstado] ASC, [IdMunicipio] ASC, [IdColonia] ASC)
);





