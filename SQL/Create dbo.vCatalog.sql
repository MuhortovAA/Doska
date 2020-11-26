USE [Doska]
GO

/****** Object: View [dbo].[vCatalog] Script Date: 26.11.2020 20:59:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [dbo].[vCatalog]
	AS
	SELECT s.[id], t.[NameTitle], s.[NameSubtitle], t.[id] as 'TitleId'
	FROM [dbo].[Subtitles] as s
	JOIN [dbo].[Titles] as t ON t.[id]=s.[idTitle]
	--ORDER BY c.[SortedSubtitle]
