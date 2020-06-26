CREATE TABLE [dbo].[Ingredients]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(100) NULL, 
    [Description] NVARCHAR(1000) NULL, 
    [Unit] NVARCHAR(100) NULL, 
    [Cost] DECIMAL(18, 2) NULL, 
    [Callories] INT NULL
)
