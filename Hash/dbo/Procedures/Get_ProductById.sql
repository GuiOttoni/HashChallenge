CREATE PROCEDURE [dbo].[Get_ProductById]
	@ProductId varchar
AS
	select P.[Id], 
P.[PriceInCents], 
P.[Title], 
P.[Description]
from Product P
where P.Id = @ProductId

RETURN 0
