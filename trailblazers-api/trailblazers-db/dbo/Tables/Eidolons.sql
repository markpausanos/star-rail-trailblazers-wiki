CREATE TABLE [dbo].[Eidolon]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(MAX) NULL,
    [Description] NVARCHAR(MAX) NULL,
    [Image] NVARCHAR(MAX) NULL,
    [Order] INT NOT NULL,
    [TrailblazerId] INT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0,
    CONSTRAINT [FK_Eidolon_Trailblazer] FOREIGN KEY ([TrailblazerId]) REFERENCES [dbo].[Trailblazer]([Id])
)
