-- Create player table
create table Player (
	Id int,
	FirstName varchar(255),
	LastName varchar(255),
	HeightFeet int,
	HeightInches int,
	TeamId  int,
	TeamName varchar(255),
	DateOfBirth DateTime,
	WeightPounds int,
	Country varchar(255),
	constraint primary_key_PersonId primary key (Id)
);