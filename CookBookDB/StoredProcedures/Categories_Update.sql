CREATE PROCEDURE [dbo].[Categories_Update]
	@Name Varchar(1000),
	@Description Varchar(1000),
	@Id int
AS
UPDATE Categories 
SET Name=@Name, Description=@Description 
WHERE Id=@Id