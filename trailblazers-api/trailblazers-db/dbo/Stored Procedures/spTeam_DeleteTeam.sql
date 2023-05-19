CREATE PROCEDURE [dbo].[spTeam_DeleteTeam]
	@TeamId INT
AS
BEGIN
	UPDATE [dbo].[Team] 
	SET [IsDeleted] = 1
	WHERE [Id] = @TeamId;
	
	UPDATE [dbo].[Build]
	SET [IsDeleted] = 1
	WHERE [Id] IN 
	(SELECT [Id] FROM [TeamBuild] WHERE [TeamId] = @TeamId)

	UPDATE [dbo].[Post]
	SET [IsDeleted] = 1
	WHERE [TeamId] = @TeamId;

	DELETE FROM [dbo].[TeamBuild]
    WHERE [TeamId] = @TeamId;

	DELETE FROM [dbo].[TeamLike]
	WHERE [TeamId] = @TeamId;
END
