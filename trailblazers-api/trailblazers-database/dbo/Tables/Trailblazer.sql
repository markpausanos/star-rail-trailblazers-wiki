CREATE TABLE [dbo].[Trailblazer]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
	[name] NVARCHAR(50) NOT NULL, 
    [description] NVARCHAR(50) NOT NULL, 
    [image_file_path] NVARCHAR(50) NOT NULL, 
    [element_type_id] INT NOT NULL,
    [path_type_id] INT NOT NULL,
    [rarity] INT NOT NULL, 
    [base_hp] INT NOT NULL, 
    [base_atk] INT NOT NULL, 
    [base_def] INT NOT NULL, 
    [base_speed] INT NOT NULL, 
    Constraint [FK_Trailblazer_Element] FOREIGN KEY ([element_type_id]) REFERENCES [dbo].[Elements]([id]) ON DELETE CASCADE,
    Constraint [FK_Trailblazer_Path] FOREIGN KEY ([path_type_id]) REFERENCES [dbo].[Paths]([id]) ON DELETE CASCADE
)
