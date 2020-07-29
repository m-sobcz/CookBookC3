USE [CookBook]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[Steps_Delete]
		@Id = 4

SELECT	@return_value as 'Return Value'

GO
