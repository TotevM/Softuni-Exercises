select* from Employees

--1
SELECT FirstName,LastName
FROM Employees
WHERE FirstName LIKE 'Sa%'

--2
SELECT FirstName,LastName
FROM Employees
WHERE LastName LIKE '%ei%%'

--3
SELECT FirstName
FROM Employees
WHERE (DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005) AND DepartmentID IN (10,3)

--4
SELECT FirstName,LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%%'

--5
SELECT [Name]
FROM Towns
WHERE Len([Name]) IN (5,6)
ORDER BY [Name]

--6
SELECT TownID, [Name]
FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

--7
SELECT TownID, [Name]
FROM Towns
WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name]

--8
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName,LastName
FROM Employees
WHERE DATEPART(YEAR, HireDate) >2000

--9
SELECT FirstName, LastName
FROM Employees
WHERE Len(LastName) =5

--10
SELECT EmployeeID, FirstName,LastName,Salary,
DENSE_RANK() OVER (PARTITION BY SALARY ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

--11
SELECT EmployeeID, FirstName,LastName,Salary,[Rank]
FROM
(
SELECT EmployeeID, FirstName,LastName,Salary,
DENSE_RANK() OVER (PARTITION BY SALARY ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
) AS Ranked
WHERE [RANK]=2
ORDER BY Salary DESC

--12
SELECT CountryName, IsoCode
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

--13
SELECT PeakName, RiverName,
LOWER(SUBSTRING(PeakName,1,LEN(PeakName)-1)+RiverName) AS Mix
FROM Peaks,Rivers
WHERE LEFT(RiverName,1) = RIGHT(PeakName,1)
ORDER BY Mix

--14
SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE DATEPART(YEAR, [Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name]

--15
SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email)+1,LEN(Email)) AS EmailProvider
FROM Users
ORDER BY EmailProvider, Username

--16
SELECT Username, IpAddress
FROM Users
WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY Username


--17
SELECT [Name],
CASE
When DATEPART(HOUR, [Start]) <12 THEN 'Morning'
When DATEPART(HOUR, [Start]) <18 THEN 'Afternoon'
ElSE 'Evening' END AS PartOfTheDay,
CASE
When Duration <=3 THEN 'Extra Short'
When Duration <=6 THEN 'Short'
When Duration > 6 THEN 'Long'
ElSE 'Extra Long' END AS Duration
FROM Games
ORDER BY [Name],Duration,PartOfTheDay

--18
SELECT ProductName, OrderDate,
	DATEADD(DAY, 3, OrderDate) AS [Pay Due],
	DATEADD(MONTH, 1, OrderDate) AS [Delivery Due]
FROM Orders