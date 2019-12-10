USE [VeteDB]
GO
/****** Object:  StoredProcedure [dbo].[Search_User] 'DO6'   Script Date: 18/08/2019 05:10:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Search_Diesease] 
	-- Add the parameters for the stored procedure here
	@Para					VARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		SELECT *
		FROM [DiseasesSymptoms] DS 
        INNER JOIN Dnt DE ON DE.Id = DS.DntId
        WHERE DS.SymptomsId IN (SELECT VALUE FROM STRING_SPLIT ( @Para , ',' ))

END
