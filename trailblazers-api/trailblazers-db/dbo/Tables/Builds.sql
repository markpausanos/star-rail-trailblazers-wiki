﻿CREATE TABLE [dbo].[Build]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [UserId] INT NOT NULL,
    [TrailblazerId] INT NOT NULL,
    [LightconeId] INT NOT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0,
    CONSTRAINT [FK_Build_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User]([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Build_Trailblazer] FOREIGN KEY ([TrailblazerId]) REFERENCES [dbo].[Trailblazer]([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Build_Lightcone] FOREIGN KEY ([LightconeId]) REFERENCES [dbo].[Lightcone]([Id]) ON DELETE SET NULL
);
