CREATE PROCEDURE [dbo].[Add_Cust]
	@param1 int,
	@param2 nvarchar(50),
	@param3 nvarchar(50),
	@param4 int,
	@param5 nvarchar(10),
	@param6 nvarchar(100)
AS
BEGIN

	INSERT INTO Cust (CustID, FirstName, LastName, CustPcode, InterestCode, CustAddress) 
        VALUES (@param1, @param2, @param3, @param4, @param5, @param6);


END;
