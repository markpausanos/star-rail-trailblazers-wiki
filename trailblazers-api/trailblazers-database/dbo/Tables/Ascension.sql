CREATE TABLE [dbo].[Ascension]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [trailblazer_id] INT NOT NULL, 
    [image_file_path] NVARCHAR(50) NOT NULL,
    [description] NVARCHAR(50) NOT NULL, 
    [order] INT NOT NULL, 
    Constraint [FK_Ascension_Trailblazer] FOREIGN KEY ([trailblazer_id]) REFERENCES [dbo].[Trailblazer]([id]) ON DELETE CASCADE
)
