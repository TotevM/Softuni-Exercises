--1st exercise
CREATE DATABASE [Minions]

--2 exercise
CREATE TABLE [Minions]
(
	[Id] INT PRIMARY KEY,
	[Name] VARCHAR(60),
	[Age] INT
)

CREATE TABLE [Towns]
(
	[Id] INT PRIMARY KEY,
	[Name] VARCHAR(60)
)
--3 exercise
ALTER TABLE [Minions]
	ADD [TownId] INT FOREIGN KEY REFERENCES [Towns](Id)

--4 exercise

INSERT [Towns]([Id], [Name])
		VALUES	(1,'Sofia'),
				(2,'Plovdiv'),
				(3,'Varna')


INSERT [Minions]([Id], [Name],[Age], [TownId])
		VAlUES	(1,'Kevin',22,1),
				(2,'Bob',15,3),
				(3,'Steward',NULL,2)
		
--5.	Truncate minions 
TRUNCATE TABLE [Minions]

--6 drop all tables
DROP TABLE [Minions]
DROP TABLE [Towns]

--7.Create Table People
CREATE TABLE [People]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(200) NOT NULL,
[Picture] VARBINARY(MAX),
[Height] DECIMAL(3,2),
[Weight] DECIMAL(5,2),
[Gender] CHAR(1) NOT NULL
CHECK([Gender] IN ('f', 'm')),
[Birthdate] DATETIME2 NOT NULL,
[Biography] VARCHAR(MAX)
)

INSERT INTO [People]([Name], [Gender], [Birthdate])
			VALUES	('Stanimir', 'm', '1999-2-23'),
					('Rado', 'm', '1929-2-28'),
					('Mira', 'f', '1989-12-13'),
					('Nadejda', 'f', '2008-3-21'),
					'Yoanna', 'f', '2005-9-10')

--08. Create Table Users

CREATE TABLE [Users]
(
[Id] BIGINT PRIMARY KEY IDENTITY,
[Username] VARCHAR(30) UNIQUE NOT NULL,
[password] VARCHAR(26),
[ProfilePicture] VARBINARY(MAX),
[LastLoginTime] DATETIME2,
[IsDeleted] BIT
)

INSERT INTO [Users] ([Username], [Password])
			VALUES ('Momi', '123123'),
				   ('Petar', 'leftright'),
				   ('Micky', 'micky02'),
				   ('Rosie', 'iloveM5cs'),
				   ('Melek', 'pickle123456')

--9.	Change Primary Key

ALTER TABLE [Users]
DROP CONSTRAINT PK__Users__3214EC07019DD6ED
ALTER TABLE [Users]
ADD CONSTRAINT PK_IdUsernameCombo PRIMARY KEY([Id],[Username])

--10.	Add Check Constraint
ALTER TABLE [Users]
ADD CONSTRAINT CHK_PasswordIsAtleastFiveSymbols
CHECK(LEN([Password]) >= 5)


-- 11.	Set Default Value of a Field
ALTER TABLE [Users]
ADD CONSTRAINT DF_LoginValue
DEFAULT GETDATE() FOR [LastLoginTime]

-- 12.	Set Unique Field
ALTER TABLE [Users]
DROP CONSTRAINT PK_UsersTable

ALTER TABLE [Users]
ADD CONSTRAINT PK_UsersTable PRIMARY KEY([Id])

ALTER TABLE [Users]
ADD CONSTRAINT CHK_UsernameIsAtleastThreeSymbols
CHECK(LEN([Username]) >= 3)

--13. Movies database
CREATE DATABASE [Movies]

CREATE TABLE [Directors] 
(
[Id] INT PRIMARY KEY IDENTITY,
[DirectorName] VARCHAR(200) NOT NULL,
[Notes] VARCHAR(MAX)
)

INSERT INTO [Directors]([DirectorName])
				VALUES('John'),('Anthony'),('Rick'),('Molly'),('Steve')

CREATE TABLE [Genres]
(
[Id] INT PRIMARY KEY IDENTITY,
[GenreName] VARCHAR(200) NOT NULL,
[Notes] VARCHAR(MAX)
)

INSERT INTO [Genres]([GenreName])
			VALUES('comedy'),('fantasy'),('cartoon'),('action'),('romance')

CREATE TABLE [Categories]  
(
[Id] INT PRIMARY KEY IDENTITY,
[CategoryName] VARCHAR(200) NOT NULL,
[Notes] VARCHAR(MAX)
)
INSERT INTO [Categories]([CategoryName])
				VALUES('Drama'),('Horror'),('Mystery'),('Thriller'),('Western')

CREATE TABLE [Movies]  
(
[Id] INT PRIMARY KEY IDENTITY,
[Title] VARCHAR(500) NOT NULL,
[DirectorId] INT REFERENCES [Directors]([Id])not null,
[CopyrightYear] DATETIME2,
[Length] INT,
[GenreId] INT REFERENCES [Genres]([Id]) not null,
[CategoryId] INT REFERENCES [Categories]([Id]) not null,
[Rating] DECIMAL,
[Notes] VARCHAR(MAX)
)

INSERT INTO [Movies]([Title], [DirectorId], [GenreId], [CategoryId])
			VALUES	('Robbin Hood', 1,2,4),
					('Snowwhite',1,2,3),
					('Minions', 1,3,4),
					('Ice Age', 5,3,5),
					('Star Wars', 2,4,3)

--14.	Car Rental Database
CREATE DATABASE [CarRental]

CREATE TABLE [Categories]  
(
[Id] INT PRIMARY KEY IDENTITY,
[CategoryName] VARCHAR(200) NOT NULL,
[DailyRate] INT,
[WeeklyRate] INT,
[MonthlyRate] INT,
[WeekendRate] INT,
)

INSERT INTO [Categories]([CategoryName])
		VALUES	('Sports'),
				('SUV'),
				('Truck')


CREATE TABLE [Cars]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[PlateNumber] VARCHAR(10) NOT NULL,
	[Manufacturer] VARCHAR(30) NOT NULL,
	[Model] VARCHAR(20),
	[CarYear] SMALLINT NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id),
	[Doors] TINYINT,
	[Picture] VARBINARY(MAX),
	[Condition] VARCHAR(20),
	[Available] VARCHAR(3) NOT NULL
		CHECK([Available] in('Yes', 'No'))
)

INSERT INTO Cars(PlateNumber, Manufacturer, CarYear, Available)
			VALUES	('EH8938BM', 'VW', 2010, 'Yes'),
					('CB777777', 'Mercedes-benz', 2024, 'No'),
					('XAXAXAXA', 'BMW', 2020, 'No')

CREATE TABLE [Employees]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(15) NOT NULL,
	[LastName] VARCHAR(15) NOT NULL,
	[Title] VARCHAR(15) NOT NULL,
	[Notes] VARCHAR(MAX)
)

INSERT INTO [Employees]([FirstName], [LastName], [Title])
				VALUES('Georgi', 'Goeorgiev', 'Intern'),
					  ('Vladimir', 'Stotanov', 'Boss'),
					  ('Momchil', 'Petranov', 'Assistant')

CREATE TABLE [Customers]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[DriverLicenseNumber] VARCHAR(20) NOT NULL,
	[FullName] VARCHAR(30) NOT NULL,
	[Address] VARCHAR(30),
	[City] VARCHAR(30) NOT NULL,
	[ZIPCode] VARCHAR(10),
	[Notes] VARCHAR(MAX)
)

INSERT INTO Customers(DriverLicenseNumber, FullName, City)
				VALUES('513456789', 'Petar Petrov', 'Pernik'),
					  ('987452321', 'Nikolai Asenov', 'Pleven'),
					  ('11398456', 'Mario Iliev', 'Sofia')

CREATE TABLE [RentalOrders]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]),
	[CustomerId] INT FOREIGN KEY REFERENCES [Customers]([Id]),
	[CarId] INT FOREIGN KEY REFERENCES [Cars]([Id]),
	[TankLevel] DECIMAL(3,2),
	[KilometrageStart] INT,
	[KilometrageEnd] INT,
	[TotalKilometrage] INT,
	[StartDate] DATETIME2,
	[EndDate] DATETIME2,
	[TotalDays] INT,
	[RateApplied] DECIMAL(2,2),
	[TaxRate] DECIMAL(2,2),
	[OrderStatus] VARCHAR(15),
	[Notes] VARCHAR(MAX)
)

INSERT INTO [RentalOrders]([EmployeeId], [CustomerId], [CarId])
						VALUES(1, 1, 1),
							  (2, 2, 2),
							  (3, 3, 3)

--15.	Hotel Database
CREATE DATABASE [Hotel]
drop database hotel
CREATE TABLE [Employees]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(15) NOT NULL,
	[LastName] VARCHAR(15) NOT NULL,
	[Title] VARCHAR(10),
	[Notes] VARCHAR(MAX)
)

CREATE TABLE [Customers]
(
	[AccountNumber] INT PRIMARY KEY IDENTITY(1000, 1),
	[FirstName] VARCHAR(15) NOT NULL,
	[LastName] VARCHAR(15) NOT NULL,
	[PhoneNumber] VARCHAR(10),
	[EmergencyName] VARCHAR(15),
	[EmergencyNumber] VARCHAR(10),
	[Notes] VARCHAR(MAX)
)

CREATE TABLE [RoomStatus]
(
	[RoomStatus] VARCHAR(15) PRIMARY KEY,
	[Notes] VARCHAR(MAX)
)

CREATE TABLE [RoomTypes]
(
	[RoomType] VARCHAR(10) PRIMARY KEY,
	[Notes] VARCHAR(MAX)
)

CREATE TABLE [BedTypes]
(
	[BedType] VARCHAR(10) PRIMARY KEY,
	[Notes] VARCHAR(MAX)
)

CREATE TABLE [Rooms]
(
	[RoomNumber] INT PRIMARY KEY IDENTITY (100,1),
	[RoomType] VARCHAR(10) FOREIGN KEY REFERENCES [RoomTypes]([RoomType]),
	[BedType] VARCHAR(10) FOREIGN KEY REFERENCES [BedTypes]([BedType]),
	[Rate] DECIMAL(4,2),
	[RoomStatus] VARCHAR(15) FOREIGN KEY REFERENCES [RoomStatus]([RoomStatus]),
	[Notes] VARCHAR(MAX)
)

CREATE TABLE [Payments]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeID] INT FOREIGN KEY REFERENCES Employees(Id),
	[PaymentDate] DATETIME2,
	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers]([AccountNumber]),
	[FirstDateOccupied] DATETIME2,
	[LastDateOccupied] DATETIME2,
	[TotalDays] INT,
	[AmountCharged] DECIMAL(10,2),
	[TaxRate] DECIMAL(4,2),
	[TaxAmount] DECIMAL(6,2),
	[PaymentTotal] DECIMAL(10,2),
	[Notes] VARCHAR(MAX)
)

CREATE TABLE [Occupancies]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeID] INT FOREIGN KEY REFERENCES [Employees]([Id]),
	[DateOccupied] DATETIME2,
	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers]([AccountNumber]),
	[RoomNumber] INT FOREIGN KEY REFERENCES [Rooms]([RoomNumber]),
	[RateApplied] DECIMAL(4,2),
	[PhoneCharge] DECIMAL(6,2),
	[Notes] VARCHAR(MAX)
)

INSERT INTO [Employees]([FirstName], [LastName])
VALUES('Marso', 'Patrov'),
	  ('Alex', 'Ivanov'),
	  ('Ivo', 'Ivov')

INSERT INTO [Customers]([FirstName], [LastName])
VALUES('Lilia', 'Petrova'),
	  ('Mira', 'Viktorova'),
	  ('Viktor', 'Kovachev')

INSERT INTO [RoomStatus]([RoomStatus])
VALUES('Free'),
	  ('Taken'),
	  ('Reserved')

INSERT INTO [RoomTypes]([RoomType])
VALUES('Single'),
	  ('Double'),
	  ('For four')

INSERT INTO [BedTypes]([BedType])
VALUES('Single'),
	  ('Double'),
	  ('King')

INSERT INTO [Rooms]([RoomType], [BedType], [RoomStatus])
VALUES('Single', 'Single', 'Free'),
	  ('Double', 'Double', 'Taken'),
	  ('For four', 'King', 'Free')

INSERT INTO [Payments]([EmployeeID], [AccountNumber])
VALUES(1, 1000),
	  (2, 1001),
	  (3, 1002)

INSERT INTO [Occupancies]([EmployeeID], [AccountNumber], [RoomNumber])
VALUES (1, 1000, 100),
	   (2, 1001, 101),
	   (3, 1002, 102)


--16-18.	Create SoftUni Database

CREATE DATABASE [SoftUni]

CREATE TABLE [Towns]
(
[Id] INT PRIMARY KEY IDENTITY,
[NAME] VARCHAR(60) NOT NULL
)

INSERT INTO [Towns]([Name])
VALUES('Sofia'),('Plovdiv'),('Varna'),('Burgas')


CREATE TABLE [Addresses]
(
[Id] INT PRIMARY KEY IDENTITY,
[AddressText] VARCHAR(MAX) NOT NULL,
[TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL
)

INSERT INTO [Addresses]([AddressText], [TownId])
VALUES('Drujba 3', 1),('Boyana 1',3),('Strelbishte',2)

CREATE TABLE [Departments]
(
[Id] INT PRIMARY KEY IDENTITY,
[NAME] VARCHAR(60) NOT NULL
)

INSERT INTO [Departments]([NAME])
VALUES('Engineering'),('Sales'),('Marketing'),('Software Development'),('Quality Assurance')

CREATE TABLE [Employees]
(
[Id] INT PRIMARY KEY IDENTITY,
[FirstName] VARCHAR(60) NOT NULL,
[MiddleName] VARCHAR(60) NOT NULL,
[LastName] VARCHAR(60) NOT NULL,
[JobTitle] VARCHAR(60) NOT NULL,
[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id])NOT NULL,
[HireDate] DATETIME2 NOT NULL,
[Salary] DECIMAL(8,2) NOT NULL,
[AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id])
)

INSERT INTO [Employees] ([FirstName], [MiddleName], [LastName], [JobTitle], [DepartmentId], [HireDate], [Salary])
VALUES	('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-01-02', 3500.00),
		('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
		('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
		('Georgi', 'Terziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
		('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88);


	--19.	Basic Select All Fields
	SELECT*FROM [Towns]
	SELECT*FROM [Departments]
	SELECT*FROM [Employees]

	--20.	Basic Select All Fields and Order Them
		SELECT*FROM [Towns]
		ORDER BY [Name] ASC

		SELECT*FROM [Departments]
		ORDER BY [Name] ASC

		SELECT*FROM [Employees]
		ORDER BY [Salary] DESC

	--21.	Basic Select Some Fields
		SELECT [Name] FROM [Towns]
		ORDER BY [Name] ASC

		SELECT [Name] FROM [Departments]
		ORDER BY [Name] ASC

		SELECT [FirstName], [LastName], [JobTitle],[Salary] FROM [Employees]
		ORDER BY [Salary] DESC

	--22.	Increase Employees Salary
	UPDATE [Employees]
	SET [Salary]=1.1*[Salary]

	SELECT [Salary] FROM [Employees]

	--23. Decrease Tax Rate
	UPDATE[Payments]
	SET [TaxRate]=0.97*[TaxRate]

	SELECT [TaxRate] FROM [Payments]

	--24.	Delete All Records

DELETE FROM [Occupancies];