USE [Doska]
GO

/****** Object:  StoredProcedure [dbo].[sp_FindAdses2]    Script Date: 03.12.2020 17:31:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_FindAdses2]
	@find nvarchar(255) 
AS


	SELECT 
	a.[Id]
	,a.[AdsCreate]
	, a.[AdsText]
	,s.NameSubtitle
	,t.[NameTitle]
FROM [dbo].[Adses] as a
join [dbo].[Subtitles] as s ON s.[id]=a.[IdCatalog] and a.[AdsText] like ''+'%'+@find+'%'+''
join [dbo].[Titles] as t ON s.[idTitle]=t.[id]
GO


