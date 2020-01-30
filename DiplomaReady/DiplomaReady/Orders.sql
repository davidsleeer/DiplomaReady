CREATE TABLE [dbo].[Orders]
(
		[CustID] INT NOT NULL , 
    [RecordID] NVARCHAR(10) NOT NULL, 
    [DateOrdered] DATE NOT NULL, 
    [Price] MONEY NULL, 
    PRIMARY KEY ([CustID], [RecordID], [DateOrdered]),
    FOREIGN KEY ([CustID]) REFERENCES CUST ([CustID]),
    FOREIGN KEY ([RecordID]) REFERENCES CD ([RecordID])
)
