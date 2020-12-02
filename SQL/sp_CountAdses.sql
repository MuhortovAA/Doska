USE [Doska]
GO

/****** Object:  StoredProcedure [dbo].[sp_CountAdses]    Script Date: 02.12.2020 17:05:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_CountAdses]
	-- Add the parameters for the stored procedure here
@IdCatalog int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT count(*) as 'count' FROM [dbo].[Adses] as a
	WHERE a.[IdCatalog] =@IdCatalog
	
END
GO


