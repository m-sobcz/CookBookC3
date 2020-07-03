CREATE PROCEDURE [dbo].[Categories_Create]
	@Id int,
	@Name Varchar(100),
	@Description Varchar(1000)
AS
INSERT INTO Categories 
(Name,Description) 
VALUES (@Name, @Description)