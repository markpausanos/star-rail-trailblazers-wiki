CREATE PROCEDURE [dbo].[spPathSR_DeletePathSR]
    @PathSRId INT
AS
BEGIN
    UPDATE [dbo].[PathSR]
    SET [IsDeleted] = 1
    WHERE [Id] = @PathSRId;

    UPDATE [dbo].[Trailblazer]
    SET [PathSRId] = NULL
    WHERE [PathSRId] = @PathSRId;
END
