CREATE PROCEDURE [dbo].[spRelic_DeleteRelic]
    @RelicId INT
AS
BEGIN
    UPDATE [dbo].[Relic]
    SET [IsDeleted] = 1
    WHERE [Id] = @RelicId;
    
    DELETE FROM [dbo].[BuildRelic]
    WHERE [RelicId] = @RelicId;
END
