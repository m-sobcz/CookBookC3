CREATE TABLE [dbo].[Steps]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Description] NVARCHAR(1000) NULL, 
    [Recipe_Id] INT NULL, 
   [Order] INT NULL, 
    CONSTRAINT [fk_StepsRecipe] FOREIGN KEY (Recipe_Id) REFERENCES Recipes([Id])
)
