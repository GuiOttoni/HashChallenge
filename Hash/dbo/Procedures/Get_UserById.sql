CREATE PROCEDURE [dbo].[Get_UserById]
	@UserId varchar
AS
Select  U.[Id], 
U.[FirstName], 
U.[LastName], 
U.[BirthDate]
from [User] U
where U.Id = @UserId
RETURN 0

