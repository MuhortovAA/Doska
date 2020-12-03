USE [Doska]
GO

/****** Object:  StoredProcedure [dbo].[sp_SelectAdses2]    Script Date: 03.12.2020 17:32:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_SelectAdses2]
 @IdCatalog int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT 
	a.[Id]
	,a.[AdsText]
	,a.[AdsCreate]
	,s.[NameSubtitle]
	,t.NameTitle
	FROM [dbo].[Adses] as a
	JOIN [dbo].[Subtitles] as s ON s.[id]=a.[IdCatalog]
	JOIN [dbo].[Titles] as t ON t.[id]=s.[idTitle]
	WHERE a.[IdCatalog] =@IdCatalog
	ORDER BY a.[Id] desc
END
GO


