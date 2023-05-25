CREATE TABLE [dbo].[Like]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [UserId] INT NOT NULL,
    [BuildId] INT NOT NULL,
    CONSTRAINT [FK_Like_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User]([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Like_Build] FOREIGN KEY ([BuildId]) REFERENCES [dbo].[Build]([Id]) ON DELETE NO ACTION,
    CONSTRAINT [UC_Like_UserId_BuildId] UNIQUE ([UserId], [BuildId])
);
