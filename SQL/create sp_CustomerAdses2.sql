USE [Doska]
GO

/****** Object:  StoredProcedure [dbo].[sp_CustomerAdses2]    Script Date: 04.12.2020 15:42:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_CustomerAdses2]
 @IdCustomer nvarchar(450)
	
AS
	SELECT 
	a.[id]
	, a.[AdsCreate]
	, a.[AdsText]
	, s.[NameSubtitle]
	, t.[NameTitle]
FROM [dbo].[Adses] as a
join [dbo].[Subtitles] as s ON s.[id]=a.[IdCatalog] AND a.[IdCustomer] =@IdCustomer
join [dbo].[Titles] as t ON t.[id]=s.[idTitle]
	ORDER BY a.[Id] desc
GO


