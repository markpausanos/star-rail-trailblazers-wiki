CREATE TABLE [dbo].[Element]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(50) NULL,
    [Image] NVARCHAR(50) NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0
)
