CREATE TABLE [dbo].[Post]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Description] NVARCHAR(MAX) NULL,
    [UserId] INT NULL,
    [TeamId] INT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0,
    CONSTRAINT [FK_Post_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User]([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Post_Team] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Team]([Id]) ON DELETE CASCADE
);