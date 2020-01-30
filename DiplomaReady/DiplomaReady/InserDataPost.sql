/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

BEGIN


--DELETE FROM Cust;
--DELETE FROM CD;
--DELETE FROM Interests;
--DELETE FROM Orders;


INSERT INTO INTERESTS (InterestCode, Description) VALUES
('RR', 'Rock and Roll'),
('JA', 'Jazz'),
('RB', 'Rhythm and Blues');

INSERT INTO CD (RecordID, Title, Performer) VALUES
('PF003', 'The Wall', 'Pink Floyd'),
('SP069', 'Never Mind the Bollocks', 'Sex Pistols'),
('PF002', 'The Dark Side of the Moon', 'Pink Floyd'),
('IX005', 'Shabooh Shoobah', 'INXS'),
('SP070', 'Floggin a Dead Horse', 'Sex Pistols'),
('PF004', 'The Endless River', 'Pink Floyd'),
('IX002', 'Kick', 'INXS'),
('PF006', 'Wish You Were Here', 'Pink Floyd'),
('SP075', 'Agents of Anarchy', 'Sex Pistols'),
('PF007', 'The Division Bell', 'Pink Floyd');


--INSERT INTO CUST (CustID, FirstName, LastName,CustPcode, InterestCode, CustAddress) VALUES
--(123, 'Jimmy','Barnes', 3000, 'RR','1 Sesame Street');
--(456, 'Ian', 'Moss', 4000, 'JA','10 Downing Street'),
--(789, 'Don', 'Walker', 5000, 'RB','221B Baker Street');

EXEC Add_Cust @param1 = 123, @param2 = 'Freddie', @param3 = 'Mercury',@param4 = 3000, @param5 = 'RR', @param6 = '1 Sesame Street';

EXEC Add_Cust @param1 = 456, @param2 = 'Brian', @param3 = 'May',@param4 = 4000, @param5 = 'JA', @param6 = '10 Downing Street';

EXEC Add_Cust @param1 = 789, @param2 = 'John', @param3 = 'Deacon',@param4 = 5000, @param5 = 'RB', @param6 = '221B Baker Street';

EXEC Add_Cust @param1 = 234, @param2 = 'Roger ', @param3 = 'Taylor',@param4 = 6000, @param5 = 'RR', @param6 = 'LG1 College Cres, Parkville';

EXEC Add_Cust @param1 = 567, @param2 = 'Mike', @param3 = 'Grose',@param4 = 7000, @param5 = 'RB', @param6 = '1 Adelaide Avenue';

INSERT INTO ORDERS (CustID, RecordID,DateOrdered, Price) VALUES
(123, 'PF003', '2019-12-01', 30.00),
(123, 'IX002', '2019-12-01', 29.95),
(123, 'SP069', '2019-12-02', 12.45),
(123, 'IX002', '2019-12-05', 30.00),
(456, 'PF002', '2019-12-01', 31.00),
(456, 'IX005', '2019-12-03', 28.95),
(456, 'SP070', '2019-12-06', 13.45),
(789, 'PF004', '2019-12-02', 29.00),
(789, 'IX002', '2019-12-05', 29.95),
(234, 'PF006', '2019-12-01', 29.95),
(234, 'SP075', '2019-12-04', 29.95),
(567, 'PF007', '2019-12-03', 29.95);

END;