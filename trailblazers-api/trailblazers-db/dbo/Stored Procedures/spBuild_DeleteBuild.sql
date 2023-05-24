CREATE PROCEDURE [dbo].[spBuild_DeleteBuild]
    @BuildId INT
AS
BEGIN
    UPDATE [dbo].[Build]
    SET [IsDeleted] = 1
    WHERE [Id] = @BuildId;
END
