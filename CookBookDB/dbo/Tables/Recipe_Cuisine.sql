CREATE TABLE [dbo].[Recipe_Cuisine]
(
	[Recipe_Id] INT NOT NULL, 
    [Cuisine_Id] INT NULL,
	CONSTRAINT [fk_Recipe] FOREIGN KEY (Recipe_Id) REFERENCES Recipes([Id]),
	CONSTRAINT [fk_Cuisine] FOREIGN KEY (Cuisine_Id) REFERENCES Cuisines([Id])
)
