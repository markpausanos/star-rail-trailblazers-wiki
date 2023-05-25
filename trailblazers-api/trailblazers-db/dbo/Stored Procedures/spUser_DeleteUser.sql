CREATE PROCEDURE [dbo].[spUser_DeleteUser]
    @UserId INT
AS
BEGIN 
    UPDATE [dbo].[User]
    SET [IsDeleted] = 1
    WHERE [Id] = @UserId;
END

