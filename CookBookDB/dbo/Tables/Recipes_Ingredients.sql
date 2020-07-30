CREATE TABLE [dbo].[Recipes_Ingredients]
(
	[Recipes_Id] INT NOT NULL, 
    [Ingredients_Id] INT NOT NULL,
	[Count] INT NULL, 
    CONSTRAINT [fk_RecipeIngredient] FOREIGN KEY ([Recipes_Id]) REFERENCES Recipes([Id]),
	CONSTRAINT [fk_IngredientRecipe] FOREIGN KEY ([Ingredients_Id]) REFERENCES Ingredients([Id])
)
