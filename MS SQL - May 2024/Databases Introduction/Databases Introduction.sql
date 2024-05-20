--1st exercise
create database Minions

--2 exercise
create table Minions
(
Id int primary key,
[Name] varchar(60),
Age int
)

create table Towns
(
Id int primary key,
[Name] varchar(60)
)
--3 exercise
alter table Minions
add TownId int foreign key references Towns(Id)

--4 exercise

Insert Towns(Id, Name)
		values(1,'Sofia'),
		(2,'Plovdiv'),
		(3,'Varna')


Insert Minions(Id, Name,Age, TownId)
		values(1,'Kevin',22,1),
		(2,'Bob',15,3),
		(3,'Steward',null,2)
		
