CREATE TABLE [dbo].[User]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [username] NVARCHAR(50) NOT NULL, 
    [password] NVARCHAR(50) NOT NULL
)
