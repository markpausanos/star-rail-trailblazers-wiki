CREATE TABLE [dbo].[Build]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [trailblazer_id] INT NOT NULL, 
    [lightcone] INT NOT NULL,
    [relic_one] INT NOT NULL, 
    [relic_two] INT NOT NULL, 
    [ornament] INT NOT NULL, 
    Constraint [FK_Build_Trailblazer] FOREIGN KEY ([trailblazer_id]) REFERENCES [dbo].[Trailblazer]([id]) ON DELETE CASCADE,
    Constraint [FK_Build_Lightcone] FOREIGN KEY ([lightcone]) REFERENCES [dbo].[Lightcone]([id]) ON DELETE CASCADE,
    Constraint [FK_Build_RelicOne] FOREIGN KEY ([relic_one]) REFERENCES [dbo].[Relics]([id]) ON DELETE CASCADE,
    Constraint [FK_Build_RelicTwo] FOREIGN KEY ([relic_two]) REFERENCES [dbo].[Relics]([id]) ON DELETE CASCADE,
    Constraint [FK_Build_Ornament] FOREIGN KEY ([ornament]) REFERENCES [dbo].[Ornaments]([id]) ON DELETE CASCADE
)
