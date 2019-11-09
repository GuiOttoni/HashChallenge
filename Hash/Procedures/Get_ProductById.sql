CREATE PROCEDURE [dbo].[Get_ProductById]
	@ProductId varchar
AS
	select P.[Id], 
P.[PriceInCents], 
P.[Title], 
P.[Description],
D.Id,
D.[Percent] 
from Product P
left join Discount D on P.IdDiscount = D.Id
where P.Id = @ProductId

RETURN 0
