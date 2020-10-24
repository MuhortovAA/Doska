USE [Doska]
GO

/****** Object: View [dbo].[vCatalog] Script Date: 19.10.2020 21:04:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER VIEW [dbo].[vCatalog]
	AS
	SELECT s.[id], t.[NameTitle], s.[NameSubtitle], t.[id] as 'TitleId'
	FROM [dbo].[Subtitles] as s
	JOIN [dbo].[Titles] as t ON t.[id]=s.[idTitle]
	--ORDER BY c.[SortedSubtitle]
