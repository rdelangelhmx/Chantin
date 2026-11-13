CREATE TABLE [dbo].[EncuestaPreguntas] (
    [IdPregunta]      INT           NOT NULL,
    [IdEncuesta]      INT           NOT NULL,
    [IdAsociacion]    INT           NOT NULL,
    [IdEmpresa]       INT           NOT NULL,
    [Pregunta]        VARCHAR (500) NULL,
    [Correcta]        INT           NULL,
    [IdRespuestas]    INT           NULL,
    [IdTipoRespuesta] INT           NULL,
    CONSTRAINT [PK_EncuestaPreguntas] PRIMARY KEY CLUSTERED ([IdPregunta] ASC, [IdEncuesta] ASC),
    CONSTRAINT [FK_EncuestaPreguntas_EncuestaRespuestaResidentes] FOREIGN KEY ([IdPregunta], [IdEncuesta]) REFERENCES [dbo].[EncuestaRespuestaResidentes] ([IdPregunta], [IdEncuesta]),
    CONSTRAINT [FK_EncuestaPreguntas_Encuestas] FOREIGN KEY ([IdEncuesta]) REFERENCES [dbo].[Encuestas] ([IdEncuesta])
);

