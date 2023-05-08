CREATE TABLE [dbo].[BuildRelic]
(
    [BuildId] INT NOT NULL,
    [RelicId] INT NOT NULL,
    CONSTRAINT [PK_BuildRelic] PRIMARY KEY ([BuildId], [RelicId]),
    CONSTRAINT [FK_BuildRelic_Build] FOREIGN KEY ([BuildId]) REFERENCES [dbo].[Build]([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BuildRelic_Relic] FOREIGN KEY ([RelicId]) REFERENCES [dbo].[Relic]([Id]) ON DELETE CASCADE
);