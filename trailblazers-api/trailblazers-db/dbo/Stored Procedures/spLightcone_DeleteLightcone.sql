CREATE PROCEDURE [dbo].[spLightcone_DeleteLightcone]
    @LightconeId INT
AS
BEGIN
    UPDATE [dbo].[Lightcone]
    SET [IsDeleted] = 1
    WHERE [Id] = @LightconeId;

    UPDATE [dbo].[Build]
    SET [LightconeId] = NULL
    WHERE [LightconeId] = @LightconeId;
END
