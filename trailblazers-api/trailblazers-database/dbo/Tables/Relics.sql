CREATE TABLE [dbo].[Relics]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
	[name] NVARCHAR(50) NOT NULL, 
    [description] NVARCHAR(50) NOT NULL, 
    [image_file_path] NVARCHAR(50) NOT NULL, 
    [bonus_effect_two_description] NVARCHAR(50) NOT NULL, 
    [bonus_effect_four_description] NVARCHAR(50) NOT NULL
)
