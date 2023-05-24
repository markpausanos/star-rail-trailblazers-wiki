CREATE TABLE [dbo].[Trace]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(MAX) NULL,
    [Description] NVARCHAR(MAX) NULL,
    [Image] NVARCHAR(MAX) NULL,
    [Order] INT NOT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0,
    [TrailblazerId] INT NULL,
    CONSTRAINT [FK_Trace_Trailblazer] FOREIGN KEY ([TrailblazerId]) REFERENCES [dbo].[Trailblazer]([Id]) ON DELETE CASCADE
);