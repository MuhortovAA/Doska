USE [Doska]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[sp_CustomerAdses]
		@IdCustomer = 1

SELECT	@return_value as 'Return Value'

GO
