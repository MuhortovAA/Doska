USE [Doska]
GO

/****** Object: SqlProcedure [dbo].[sp_FindAdses] Script Date: 26.11.2020 20:59:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_FindAdses]
	@find nvarchar(255) 
AS
	SELECT *
FROM [dbo].[Adses] as a
WHERE a.[AdsText] like ''+@find+''
