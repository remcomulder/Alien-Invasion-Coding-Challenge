create database AlienInvasion
GO

use AlienInvasion
GO

create table AlienInvasionUser (
	id int not null primary key identity(1, 1),
	name nvarchar(250),
	score int,
	currentCity int,
	failuresOnCurrentCity int
	)
GO

create unique index idx_AlienInvasionUser_name on AlienInvasionUser(name)	
GO