CREATE TABLE [dbo].[Recipes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(100) NULL, 
    [Description] NVARCHAR(1000) NULL, 
    [Time] INT NULL, 
    [Portions] INT NULL, 
    [Users_Id] INT NULL, 
    CONSTRAINT [FK_Users] FOREIGN KEY (Users_Id) REFERENCES [Users]([Id])
)
