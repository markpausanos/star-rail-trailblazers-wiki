CREATE TABLE [dbo].[Ornament]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(MAX) NULL,
    [Description] NVARCHAR(MAX) NULL,
    [Image] NVARCHAR(MAX) NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0
)
