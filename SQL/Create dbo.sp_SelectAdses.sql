USE [Doska]
GO

/****** Object: SqlProcedure [dbo].[sp_SelectAdses] Script Date: 26.11.2020 20:59:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_SelectAdses]
 @IdCatalog int
	
AS
	SELECT * FROM [dbo].[Adses] as a
	WHERE a.[IdCatalog] =@IdCatalog
	ORDER BY a.[Id] desc
