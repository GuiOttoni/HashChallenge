CREATE TABLE [dbo].[User]
(
	[Id] varchar(10) NOT NULL PRIMARY KEY,
	[FirstName] varchar(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL,
	[BirthDate] Datetime NOT NULL
)
