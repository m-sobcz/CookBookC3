CREATE TABLE [dbo].[Ingredients]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(50) NULL, 
    [Description] NCHAR(200) NULL, 
    [Unit] NCHAR(10) NULL, 
    [Cost] DECIMAL NULL, 
    [Callories] INT NULL
)
