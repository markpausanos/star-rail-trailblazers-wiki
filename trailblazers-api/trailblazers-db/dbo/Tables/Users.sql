CREATE TABLE [dbo].[User] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (100) NOT NULL,
    [Password]  NVARCHAR (MAX) NULL,
    [UserType]  CHAR (1) NOT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Name] ASC)
);
