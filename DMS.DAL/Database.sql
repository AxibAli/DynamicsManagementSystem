create database DMS_DB;
use DMS_DB

create table [User] (
[Id] int identity(1, 1) primary key,
[Username] varchar(50) not null,
[Email] varchar(50) unique not null,
[PasswordHash] varbinary(max) not null,
[PasswordSalt] varbinary(max) not null,
[Role] int not null,
);

create table [Teacher](
[Id] int identity(1000, 1) primary key,
[Picture] varchar(max),
[FirstName] varchar(50) not null,
[LastName] varchar(50) not null,
[CNIC] varchar(50) not null,
[Gender] int not null,
[DoB] datetime not null,
[Age] int not null,
[PrimaryPhoneNumber] varchar(50) not null,
[SecondaryPhoneNumber] varchar(50) not null,
[Address] varchar(max) not null,
[IsActive] bit default(1),
[IsDeleted] bit default(0),
);

create table [TeacherUser](
[Id] int identity(1, 1) primary key,
TeacherId int FOREIGN KEY REFERENCES [Teacher](Id),
UserId int FOREIGN KEY REFERENCES [User](Id)
);

create table [Class](
[Id] int identity(1, 1) primary key,
[Name] varchar(50) not null,
[Section] varchar(50) not null
);

create table [Course](
[Id] int identity(1, 1) primary key,
[Name] varchar(50) not null,
[TotalMarks] decimal not null,
[MinimumMarks] decimal not null,
ClassId int FOREIGN KEY REFERENCES [Class](Id),
TeacherId int FOREIGN KEY REFERENCES [Teacher](Id),
);

create table [Student](
[Id] int identity(1, 1) primary key,
[Picture] varchar(max),
[FirstName] varchar(50) not null,
[LastName] varchar(50) not null,
[FatherName] varchar(50) not null,
[Gender] int not null,
[DoB] datetime not null,
[Age] int not null,
[PrimaryPhoneNumber] varchar(50) not null,
[SecondaryPhoneNumber] varchar(50) not null,
[Address] varchar(max) not null,
[GRNo] varchar(50) not null,
[IsActive] bit default(1),
[IsDeleted] bit default(0),
ClassId int FOREIGN KEY REFERENCES [Class](Id),
);

create table [StudentUser](
[Id] int identity(1, 1) primary key,
StudentId int FOREIGN KEY REFERENCES [Student](Id),
UserId int FOREIGN KEY REFERENCES [User](Id)
);
