CREATE TABLE [dbo].[AreaComunReservaciones] (
    [IdReservacion]     INT             IDENTITY (1, 1) NOT NULL,
    [IdAreaComun]       INT             NOT NULL,
    [IdResidente]       INT             NOT NULL,
    [IdAsociacion]      INT             NOT NULL,
    [IdEmpresa]         INT             NOT NULL,
    [Evento]            VARCHAR (150)   NULL,
    [fEvento]           DATETIME        NULL,
    [Anticipo]          DECIMAL (12, 2) NULL,
    [fAnticipo]         DATETIME        NULL,
    [Confirmado]        BIT             CONSTRAINT [DF__AreaComun__Confi__4D94879B] DEFAULT ((0)) NULL,
    [fConfirma]         DATETIME        NULL,
    [Cancelado]         BIT             CONSTRAINT [DF__AreaComun__Cance__4E88ABD4] DEFAULT ((0)) NULL,
    [fCancela]          DATETIME        NULL,
    [Liquidado]         BIT             CONSTRAINT [DF__AreaComun__Liqui__4F7CD00D] DEFAULT ((0)) NULL,
    [fLiquida]          DATETIME        NULL,
    [fAlta]             DATETIME        NULL,
    [IdUsuarioAlta]     INT             NULL,
    [fModifica]         DATETIME        NULL,
    [IdUsuarioModifica] INT             NULL,
    [fBaja]             DATETIME        NULL,
    [IdUsuarioBaja]     INT             NULL,
    [Estatus]           BIT             CONSTRAINT [DF__AreaComun__Estat__5070F446] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_AreaComunReservaciones_1] PRIMARY KEY CLUSTERED ([IdReservacion] ASC),
    CONSTRAINT [FK_AreaComunReservaciones_AreasComunes] FOREIGN KEY ([IdAreaComun]) REFERENCES [dbo].[AreasComunes] ([IdAreaComun]),
    CONSTRAINT [FK_AreaComunReservaciones_Residentes] FOREIGN KEY ([IdResidente]) REFERENCES [dbo].[Residentes] ([IdResidente])
);



