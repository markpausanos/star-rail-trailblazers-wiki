CREATE TABLE [dbo].[Skill]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Title] NVARCHAR(MAX) NULL,
    [Name] NVARCHAR(MAX) NULL,
    [Description] NVARCHAR(MAX) NULL,
    [Image] NVARCHAR(MAX) NULL,
    [Type] NVARCHAR(MAX) NULL,
    [TrailblazerId] INT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0,
    CONSTRAINT [FK_Skill_Trailblazer] FOREIGN KEY ([TrailblazerId]) REFERENCES [dbo].[Trailblazer]([Id]) ON DELETE SET NULL
);
