USE [Doska]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetAds]    Script Date: 04.12.2020 15:43:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAds]
	-- Add the parameters for the stored procedure here
@Id nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM [dbo].[Adses] as a
	WHERE a.[Id] =@Id
	
END
GO


