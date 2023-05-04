CREATE TABLE [dbo].[Skills]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [trailblazer_id] INT NOT NULL, 
    [image_file_path] NVARCHAR(50) NOT NULL,
    [bonus_effect_name] NVARCHAR(50) NOT NULL, 
    [bonus_effect_description] NVARCHAR(50) NOT NULL, 
    [type] NVARCHAR(50) NOT NULL, 
    Constraint [FK_Skills_Trailblazer] FOREIGN KEY ([trailblazer_id]) REFERENCES [dbo].[Trailblazer]([id]) ON DELETE CASCADE
)
