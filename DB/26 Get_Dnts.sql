SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE Get_Dnts 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP (9) [Id]
		  ,[Title]
		  ,[Url]
		  ,[Description]
		  ,[CreatedDate]
		  ,[LastUpdatedDate]
	  FROM [VeteDB].[dbo].[Dnt]
END
GO
