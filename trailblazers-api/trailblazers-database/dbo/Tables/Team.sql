CREATE TABLE [dbo].[Team]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [user_id] INT NOT NULL, 
    [build_one] INT NOT NULL,
    [build_two] INT NOT NULL, 
    [build_three] INT NOT NULL, 
    [build_four] INT NOT NULL, 
    Constraint [FK_Team_User] FOREIGN KEY ([user_id]) REFERENCES [dbo].[User]([id]) ON DELETE CASCADE,
    Constraint [FK_Team_BuildOne] FOREIGN KEY ([build_one]) REFERENCES [dbo].[Build]([id]) ON DELETE CASCADE,
    Constraint [FK_Team_BuildTwo] FOREIGN KEY ([build_two]) REFERENCES [dbo].[Build]([id]) ON DELETE CASCADE,
    Constraint [FK_Team_BuildThree] FOREIGN KEY ([build_three]) REFERENCES [dbo].[Build]([id]) ON DELETE CASCADE,
    Constraint [FK_Team_BuildFour] FOREIGN KEY ([build_four]) REFERENCES [dbo].[Build]([id]) ON DELETE CASCADE
)
