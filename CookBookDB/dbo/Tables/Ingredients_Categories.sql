CREATE TABLE [dbo].[Ingredients_Categories]
(
	[Ingredients_Id] INT NOT NULL, 
    [Categories_Id] INT NOT NULL, 
    CONSTRAINT [fk_Ingredients] FOREIGN KEY (Ingredients_Id) REFERENCES Ingredients([Id]),
    CONSTRAINT [fk_Categories] FOREIGN KEY (Categories_Id) REFERENCES Categories([Id])
)
