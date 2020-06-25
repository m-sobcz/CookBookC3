
ALTER PROCEDURE  dbo.spGetAllIngredients
as
begin
SET NOCOUNT ON
SELECT * 
from dbo.Ingredients
end