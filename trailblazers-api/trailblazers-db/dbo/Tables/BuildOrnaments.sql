CREATE TABLE [dbo].[BuildOrnament]
(
    [BuildId] INT NOT NULL,
    [OrnamentId] INT NOT NULL,
    CONSTRAINT [PK_BuildOrnament] PRIMARY KEY ([BuildId], [OrnamentId]),
    CONSTRAINT [FK_BuildOrnament_Build] FOREIGN KEY ([BuildId]) REFERENCES [dbo].[Build]([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BuildOrnament_Ornament] FOREIGN KEY ([OrnamentId]) REFERENCES [dbo].[Ornament]([Id]) ON DELETE CASCADE
);