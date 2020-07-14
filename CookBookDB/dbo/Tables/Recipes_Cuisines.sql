CREATE TABLE [dbo].[Recipes_Cuisines]
(
	[Recipes_Id] INT NOT NULL, 
    [Cuisines_Id] INT NOT NULL,
	CONSTRAINT [fk_Recipe] FOREIGN KEY ([Recipes_Id]) REFERENCES Recipes([Id]),
	CONSTRAINT [fk_Cuisine] FOREIGN KEY ([Cuisines_Id]) REFERENCES Cuisines([Id])
)
