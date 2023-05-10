CREATE TABLE [dbo].[Relic]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(MAX) NULL,
    [DescriptionOne] NVARCHAR(MAX) NULL,
    [DescriptionTwo] NVARCHAR(MAX) NULL,
    [Image] NVARCHAR(MAX) NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0
);
