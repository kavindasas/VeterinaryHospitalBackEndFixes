SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE Update_DogInfo 
	-- Add the parameters for the stored procedure here
	@UserId			INT = 0,
	@DogName		VARCHAR(20) = NULL,
	@Vacination		VARCHAR(220) = NULL,
	@HRecord		VARCHAR(220) = NULL
AS
BEGIN

	IF @UserId > 0
	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		DECLARE @OwnerId INT;
		SET NOCOUNT ON;

		SET @OwnerId = (SELECT DogOwnerId FROM AppUser WHERE Id = @UserId)

		UPDATE DogOwner
		SET DogName = @DogName
		WHERE Id = @OwnerId

		-- Insert statements for procedure here
		IF 0 < (SELECT 1 FROM AppointmentAndRecords WHERE UserId = @UserId)
		BEGIN
			UPDATE AppointmentAndRecords 
			SET Vacination = @Vacination ,
				HRecord = @HRecord
			WHERE UserId = @UserId
			SELECT 1 AS Status
		END
		ELSE
		BEGIN
			INSERT INTO [dbo].[AppointmentAndRecords]
			   ([UserId]
			   ,[Vacination]
			   ,[HRecord])
			VALUES
			   (@UserId
			   ,@Vacination
			   ,@HRecord)
			SELECT 1 AS Status
		END
	END
	ELSE
	BEGIN
		RAISERROR ('Invalid User.', -- Error Message
               16, -- Severity.
               1 -- State.
               );
	END
END
GO
