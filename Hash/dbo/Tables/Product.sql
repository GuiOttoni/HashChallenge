﻿CREATE TABLE [dbo].[Product]
(
	[Id] varchar(10) NOT NULL PRIMARY KEY,
    [PriceInCents] int,
    [Title] varchar(50),
    [Description] varchar(150),
    [IdDiscount] INT,
	FOREIGN KEY (IdDiscount) REFERENCES Discount(Id)
)
