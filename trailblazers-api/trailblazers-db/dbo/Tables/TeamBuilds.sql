CREATE TABLE [dbo].[TeamBuild]
(
    [TeamId] INT NOT NULL,
    [BuildId] INT NOT NULL,
    CONSTRAINT [PK_TeamBuild] PRIMARY KEY ([TeamId], [BuildId]),
    CONSTRAINT [FK_TeamBuild_Team] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Team]([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TeamBuild_Build] FOREIGN KEY ([BuildId]) REFERENCES [dbo].[Build]([Id]) ON DELETE CASCADE
);