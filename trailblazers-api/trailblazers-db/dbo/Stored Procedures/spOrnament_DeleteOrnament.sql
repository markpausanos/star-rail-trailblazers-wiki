CREATE PROCEDURE [dbo].[spOrnament_DeleteOrnament]
    @OrnamentId INT
AS
BEGIN
    UPDATE [dbo].[Ornament]
    SET [IsDeleted] = 1
    WHERE [Id] = @OrnamentId;
END
