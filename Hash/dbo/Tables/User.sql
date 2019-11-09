CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[FirstName] varchar(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL,
	[BirthDate] Datetime NOT NULL
)
