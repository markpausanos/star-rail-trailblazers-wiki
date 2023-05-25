CREATE PROCEDURE [dbo].[spElement_DeleteElement]
    @ElementId INT
AS
BEGIN
    UPDATE [dbo].[Element]
    SET [IsDeleted] = 1
    WHERE [Id] = @ElementId;
    
    UPDATE [dbo].[Trailblazer]
    SET [ElementId] = NULL
    WHERE [ElementId] = @ElementId;
END
