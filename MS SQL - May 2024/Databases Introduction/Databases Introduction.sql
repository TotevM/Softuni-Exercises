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
				(3,'Steward',null,2)
		
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

