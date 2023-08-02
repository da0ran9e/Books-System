use BXDatabase

create table users(
	id int not null identity(1,1) primary key,
	userName varchar(20) not null unique,
	password varchar(50) not null,	
	fname nvarchar(100),
	lname nvarchar(100),
	gender tinyint, --(1) male (2) female (0) other
	email varchar(150) unique,
	phone bigint unique,
	birthDate date,
	age int,
	location varchar(250),
	profileImage varchar(300),
)