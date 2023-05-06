CREATE TABLE [dbo].[Lightcone]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Title] NVARCHAR(MAX) NULL,
    [Name] NVARCHAR(MAX) NULL,
    [Description] NVARCHAR(MAX) NULL,
    [Image] NVARCHAR(MAX) NULL,
    [Rarity] INT NOT NULL,
    [BaseHp] INT NOT NULL,
    [BaseAtk] INT NOT NULL,
    [BaseDef] INT NOT NULL,
    [PathSRId] INT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0,
    CONSTRAINT [FK_Lightcone_PathSR] FOREIGN KEY ([PathSRId]) REFERENCES [dbo].[PathSR]([Id]) ON DELETE SET NULL
)
