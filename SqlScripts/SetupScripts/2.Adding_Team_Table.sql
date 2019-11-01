-- Create team table
create table Team (
	Id int,
	IsNBAFranchise bit,
	IsAllStar bit,
	City varchar(255),
	FullName varchar(255),
	Tricode varchar(3),
	Nickname varchar(255),
	ConfName varchar(255)
);