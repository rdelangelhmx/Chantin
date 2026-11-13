CREATE TABLE [dbo].[EncuestaRespuestaResidentes] (
    [IdPregunta]   INT           NOT NULL,
    [IdEncuesta]   INT           NOT NULL,
    [IdResidente]  INT           NOT NULL,
    [IdAsociacion] INT           NOT NULL,
    [IdEmpresa]    INT           NOT NULL,
    [Respuesta]    VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_EncuestaRespuestaResidentes] PRIMARY KEY CLUSTERED ([IdPregunta] ASC, [IdEncuesta] ASC),
    CONSTRAINT [FK_EncuestaRespuestaResidentes_Residentes] FOREIGN KEY ([IdResidente]) REFERENCES [dbo].[Residentes] ([IdResidente])
);

