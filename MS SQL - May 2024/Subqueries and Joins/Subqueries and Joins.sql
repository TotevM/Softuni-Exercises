--1
SELECT TOP(5) EmployeeId, JobTitle,e.AddressID, AddressText
FROM Employees AS e
JOIN Addresses AS a ON a.AddressID=e.AddressID
ORDER BY e.AddressID

--2
SELECT TOP(50) FirstName, LastName,[Name], AddressText
FROM Employees AS e
JOIN Addresses AS a ON a.AddressID=e.AddressID
JOIN Towns AS t On a.TownID=t.TownID
ORDER BY FirstName, LastName

--3
SELECT EmployeeID, FirstName, LastName, d.[Name]
FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID=e.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY EmployeeID

--4
SELECT TOP 5 EmployeeID, FirstName, Salary, d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID=e.DepartmentID
WHERE Salary > 15000
ORDER BY e.DepartmentID 

--5
SELECT TOP 3 e.EmployeeID, FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON ep.EmployeeID=e.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID 

--6
SELECT  FirstName,LastName, HireDate, [Name]
FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID=e.DepartmentID
WHERE d.[Name] IN ('Finance', 'Sales')
ORDER BY e.HireDate 

--7
SELECT TOP 5 e.EmployeeID, FirstName, p.[Name]
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON ep.EmployeeID=e.EmployeeID
LEFT JOIN Projects AS p ON ep.ProjectID=p.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID 

--8
SELECT e.EmployeeID, FirstName, 
CASE
WHEN DATEPART(YEAR,p.StartDate)>2004 THEN NULL
ELSE p.[Name]
END AS ProjectName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON ep.EmployeeID=e.EmployeeID
LEFT JOIN Projects AS p ON ep.ProjectID=p.ProjectID
WHERE e.EmployeeID=24
ORDER BY e.EmployeeID

--9
SELECT e.EmployeeID, e.FirstName, em.EmployeeID, em.FirstName
FROM Employees AS e
JOIN Employees AS em ON em.EmployeeID=e.ManagerID
WHERE e.ManagerID IN (3,7)
ORDER BY e.EmployeeID 

--10
SELECT TOP 50 e.EmployeeID, CONCAT_WS(' ', e.FirstName, e.LastName) , CONCAT_WS(' ', em.FirstName, em.LastName), d.[Name]
FROM Employees AS e
JOIN Employees AS em ON em.EmployeeID=e.ManagerID
JOIN Departments AS d ON d.DepartmentID=e.DepartmentID
ORDER BY e.EmployeeID 

--11
SELECT TOP 1 AVG(Salary) AS MinAverageSalary
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID=d.DepartmentID
GROUP BY e.DepartmentID
ORDER BY AVG(Salary)


--12
SELECT c.CountryCode, MountainRange, p.PeakName, p.Elevation
FROM Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode=c.CountryCode
JOIN Mountains AS m ON mc.MountainId=m.Id
JOIN Peaks AS p ON p.MountainId=m.Id
WHERE c.CountryCode='BG' AND p.Elevation>2835
ORDER BY Elevation DESC

--13
SELECT c.CountryCode, COUNT(MountainRange)
FROM Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode=c.CountryCode
JOIN Mountains AS m ON mc.MountainId=m.Id
WHERE c.CountryCode IN('BG', 'RU','US')
GROUP BY c.CountryCode

--14
SELECT TOP 5 c.CountryName, RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode=c.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId=r.Id
WHERE ContinentCode= 'AF'
ORDER BY CountryName 

--15
SELECT ContinentCode, CurrencyCode, CurrencyUsage
FROM
(SELECT *,
				DENSE_RANK() OVER (PARTITION BY [ContinentCode] ORDER BY CurrencyUsage DESC)
			AS [CurrencyRank]
			FROM
(
SELECT ContinentCode, CurrencyCode, Count(CurrencyCode) AS CurrencyUsage
FROM Countries
GROUP BY ContinentCode, CurrencyCode
HAVING Count(CurrencyCode)>1
) AS s
) AS f
WHERE [CurrencyRank]=1


--16
SELECT COUNT(*) AS [Count]
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode=c.CountryCode
WHERE MountainId IS NULL


--17
SELECT TOP 5 c.CountryName, 
MAX(p.Elevation) AS HighestPeakElevation,
MAX(r.[Length]) AS LongestRiverLength
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode=mc.CountryCode
LEFT JOIN Mountains AS m ON m.Id=mc.MountainId
LEFT JOIN Peaks AS p ON p.MountainId=m.Id

LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId 

GROUP BY c.CountryName
ORDER BY MAX(p.Elevation) DESC, MAX(r.[Length]) DESC, c.CountryName

--18
WITH PeaksRankedByElevation AS 
(
	SELECT
		c.CountryName,
		p.PeakName,
		p.Elevation,
		m.MountainRange,
		DENSE_RANK() OVER
			(PARTITION BY c.CountryName ORDER BY Elevation DESC) AS PeakRank
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
	LEFT JOIN Peaks AS p ON m.Id = p.MountainId
)

SELECT TOP(5)
	CountryName AS Country,
	ISNULL(PeakName, '(no highest peak)') AS [Highest Peak Name],
	ISNULL(Elevation, 0) AS [Highest Peak Elevation],
	ISNULL(MountainRange, '(no mountain)') AS Mountain
FROM PeaksRankedByElevation
WHERE PeakRank = 1
ORDER BY 
	CountryName, [Highest Peak Name]