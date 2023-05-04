CREATE TABLE [dbo].[Lightcone]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
	[name] NVARCHAR(50) NOT NULL, 
    [description] NVARCHAR(50) NOT NULL, 
    [image_file_path] NVARCHAR(50) NOT NULL, 
    [path_type_id] INT NOT NULL,
    [rarity] INT NOT NULL, 
    [base_hp] INT NOT NULL, 
    [base_atk] INT NOT NULL, 
    [base_def] INT NOT NULL, 
    [bonus_effect_name] NVARCHAR(50) NOT NULL, 
    [bonus_effect_description] NVARCHAR(50) NOT NULL, 
    Constraint [FK_Lightcone_Path] FOREIGN KEY ([path_type_id]) REFERENCES [dbo].[Paths]([id]) ON DELETE CASCADE
)
