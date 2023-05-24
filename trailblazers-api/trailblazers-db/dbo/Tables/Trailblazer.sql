CREATE TABLE [dbo].[Trailblazer]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(MAX) NULL,
    [Image] NVARCHAR(MAX) NULL,
    [Rarity] INT NOT NULL,
    [BaseHp] INT NOT NULL,
    [BaseAtk] INT NOT NULL,
    [BaseDef] INT NOT NULL,
    [BaseSpeed] INT NOT NULL,
    [ElementId] INT NOT NULL,
    [PathSRId] INT NOT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0,
    CONSTRAINT [FK_Trailblazer_Element] FOREIGN KEY ([ElementId]) REFERENCES [dbo].[Element]([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_Trailblazer_PathSR] FOREIGN KEY ([PathSRId]) REFERENCES [dbo].[PathSR]([Id]) ON DELETE SET NULL
)
