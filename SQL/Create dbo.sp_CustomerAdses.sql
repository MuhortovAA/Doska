USE [Doska]
GO

/****** Object: SqlProcedure [dbo].[sp_CustomerAdses] Script Date: 26.11.2020 20:57:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_CustomerAdses]
 @IdCustomer nvarchar(450)
	
AS
	SELECT * FROM [dbo].[Adses] as a
	WHERE a.IdCustomer=@IdCustomer
	ORDER BY a.[Id] desc
