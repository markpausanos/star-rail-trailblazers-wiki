CREATE TABLE [dbo].[User] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (100) NOT NULL,
    [Password]  NVARCHAR (100) NULL,
    [UserType]  CHAR (1) NOT NULL DEFAULT 'U',
    [IsDeleted] BIT NOT NULL DEFAULT 0,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Name] ASC)
);
