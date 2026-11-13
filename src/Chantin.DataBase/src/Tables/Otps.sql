CREATE TABLE [dbo].[Otps] (
    [IdOtp]     INT           IDENTITY (1, 1) NOT NULL,
    [Correo]    VARCHAR (250) NULL,
    [Code]      VARCHAR (10)  NULL,
    [ExpiresAt] DATETIME      NULL,
    [IsUsed]    BIT           NULL,
    [UsedAt]    DATETIME      NULL,
    [Purpose]   VARCHAR (50)  NULL,
    CONSTRAINT [PK_Otps] PRIMARY KEY CLUSTERED ([IdOtp] ASC)
);

