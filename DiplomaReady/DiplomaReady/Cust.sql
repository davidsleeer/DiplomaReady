CREATE TABLE [dbo].[Cust]
(
	[CustID] INT NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [CustPcode] INT NULL, 
    [InterestCode] NVARCHAR(10) NULL,
    [CustAddress] NVARCHAR(100) NULL, 
    FOREIGN KEY ([InterestCode]) REFERENCES INTERESTS ([InterestCode])
)
