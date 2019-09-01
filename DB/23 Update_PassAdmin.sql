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
CREATE PROCEDURE Update_PassAdmin
	-- Add the parameters for the stored procedure here
	@UserId			INT = 0,
	@NewPass		VARCHAR(100) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS(SELECT 1 FROM AppUser WHERE Id = @UserId)
	BEGIN
		UPDATE AppUser SET PassWord = @NewPass WHERE Id = @UserId
	END
	ELSE
	BEGIN
		RAISERROR ('User does not exsist.', -- Error Message
               16, -- Severity.
               1 -- State.
               );
	END
END
GO
