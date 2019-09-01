-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE Delete_User
	-- Add the parameters for the stored procedure here
	@Id			INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF 3 = (SELECT UserType FROM AppUser WHERE Id = @Id)
	BEGIN
		DELETE DogOwner WHERE Id = (SELECT DogOwnerId FROM AppUser WHERE Id = @Id)
		DELETE AppointmentAndRecords WHERE UserId = @Id
		DELETE AppUser WHERE Id = @Id
	END
	ELSE
	BEGIN
		DELETE Staff WHERE Id = (SELECT StaffId FROM AppUser WHERE Id = @Id)
		DELETE AppUser WHERE Id = @Id
	END
END
GO
