-- Select only Names from Minions table
SELECT Name
 FROM [Minions].[dbo].[Minions]

-- Order them ascending by name
GO 
SELECT Name
 FROM [Minions].[dbo].[Minions]
 ORDER BY Name ASC

-- Change Stuart’s age from NULL to 10
GO
UPDATE [Minions]
 SET Age = 10
 WHERE Name = 'Stuart'

-- Change Stuart’s age from NULL to 10
GO
UPDATE [Minions]
 SET Age = Age + 1

-- Delete Bob from the table
GO
DELETE FROM [Minions]
 WHERE Name = 'Bob'