CREATE PROCEDURE [dbo].[spUser_DeleteUser]
    @UserId INT
AS
BEGIN
    UPDATE [dbo].[Post]
    SET [IsDeleted] = 1
    WHERE [UserId] = @UserId;
    
    Update [dbo].[User]
    SET [IsDeleted] = 1
    WHERE [Id] = @UserId;
END

