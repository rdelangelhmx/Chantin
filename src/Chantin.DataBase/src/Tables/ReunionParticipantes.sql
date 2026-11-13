CREATE TABLE [dbo].[ReunionParticipantes] (
    [IdParticipante]     INT           IDENTITY (1, 1) NOT NULL,
    [IdReunion]          INT           NOT NULL,
    [IdAsociacion]       INT           NOT NULL,
    [IdEmpresa]          INT           NOT NULL,
    [Nombre]             VARCHAR (250) NULL,
    [IdTipoParticipante] INT           NULL,
    CONSTRAINT [PK__ReunionP__56139242B64625E0] PRIMARY KEY CLUSTERED ([IdParticipante] ASC),
    CONSTRAINT [FK_ReunionParticipantes_Reuniones] FOREIGN KEY ([IdReunion]) REFERENCES [dbo].[Reuniones] ([IdReunion])
);

