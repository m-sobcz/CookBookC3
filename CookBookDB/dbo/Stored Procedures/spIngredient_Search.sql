CREATE PROCEDURE [dbo].[spIngredient_Search]
	@searchTerm VARCHAR(50)
AS
BEGIN
SET NOCOUNT ON
select [Name],[Description]
	from dbo.Ingredients
	where Name LIKE '%' + @searchTerm + '%'
	or Description LIKE '%' + @searchTerm + '%';
END