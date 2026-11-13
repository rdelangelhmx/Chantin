CREATE TABLE [dbo].[EncuestaRespuestas] (
    [IdRespuesta]  INT           NOT NULL,
    [IdPregunta]   INT           NOT NULL,
    [IdEncuesta]   INT           NOT NULL,
    [IdAsociacion] INT           NOT NULL,
    [IdEmpresa]    INT           NOT NULL,
    [Respuesta]    VARCHAR (500) NULL,
    CONSTRAINT [PK_EncuestaRespuestas] PRIMARY KEY CLUSTERED ([IdRespuesta] ASC, [IdPregunta] ASC, [IdEncuesta] ASC),
    CONSTRAINT [FK_EncuestaRespuestas_EncuestaPreguntas] FOREIGN KEY ([IdPregunta], [IdEncuesta]) REFERENCES [dbo].[EncuestaPreguntas] ([IdPregunta], [IdEncuesta])
);

