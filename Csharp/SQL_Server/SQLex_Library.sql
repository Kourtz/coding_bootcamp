use master; 
go
if exists(select * from sys.databases where name='Exercise_library')
drop database Exercise_library;
go
create database Exercise_library;


use Exercise_library;



if exists(select * from INFORMATION_SCHEMA.Tables where TABLE_NAME='Authors')
drop database Authors;
create table Authors(ID int NOT NULL IDENTITY(1,1) PRIMARY KEY, Name varchar(128) NOT NULL);

if exists(select * from INFORMATION_SCHEMA.Tables where TABLE_NAME='Books')
drop database Books;
create table Books(ISBN int NOT NULL IDENTITY(1,1) PRIMARY KEY, Title varchar(128) NOT NULL);

if exists(select * from INFORMATION_SCHEMA.Tables where TABLE_NAME='Libraries')
drop database Libraries;
create table Libraries(LibraryID int NOT NULL IDENTITY(1,1) PRIMARY KEY,Name varchar(128) not null);

if exists(select * from INFORMATION_SCHEMA.Tables where TABLE_NAME='Users')
drop database Users;
create table Users(ID int not null identity (1,1) primary key,Name varchar(128) not null);

if exists(select * from INFORMATION_SCHEMA.Tables where TABLE_NAME='Librarian')
drop database Librarian;
create table Librarian(ID int not null identity (1,1) primary key,Name varchar(128) not null,
ManageLibraryID int not null foreign key references Libraries(LibraryID));





--Table with book and author keys
create table BookAuthors(BookISBN int not null foreign key references Books(ISBN),
AuthorID int not null foreign key references Authors(ID),
Constraint BookAuthorsID primary key(BookISBN,AuthorID));

--books and library
create table LibraryBooks(
LibraryID int not null foreign key references Libraries(LibraryID),
BookISBN int not null foreign key references Books(ISBN),
PhysicalCopies int not null default 0,
AvailableCopies int not null default 0,
Constraint LibraryBooksID primary key (LibraryID,BookISBN));

--library and users
create table LibraryUsers(
LibraryID int not null foreign key references Libraries(LibraryID),
UserID int not null foreign key references Users(ID),
Constraint LibraryUsersID primary key (LibraryID,UserID));

--Library and librarian
create table LibraryLibrarian(
LibraryID int not null foreign key references Libraries(LibraryID),
LibrarianID int not null foreign key references Librarian(ID),
Constraint LibraryLibrarianID primary key (LibraryID,LibrarianID));


--Rents
create table Rents(
RentID int not null primary key,
LibraryID int not null foreign key references Libraries(LibraryID),
UserID int not null foreign key references Users(ID),
BookISBN int not null foreign key references Books(ISBN),
DateRent date not null default getdate(),
Authorized int not null foreign key references Librarian(ID)) ;






--insert books
insert into Authors(Name) values ('Tom Robbins');
insert into Authors(Name) values ('Fyodor Dostoyevsky');
insert into Authors(Name) values ('Friedrich Nietzsche');
insert into Authors(Name) values ('Camus Albert');

insert into Books (Title) values ('Even Cowgirls Get the Blues');
insert into Books (Title) values ('Half Asleep Crime and Punishment');
insert into Books (Title) values ('The Idiot');
insert into Books (Title) values ('Demons');
insert into Books (Title) values ('Thus Spoke Zarathustra'),('Beyond Good and Evil'),
('The Antichrist'),('On the Genealogy of Morality');
insert into Books (Title) values ('The Stranger'),('The Plague'),
('The Myth of Sisyphus'),('The Fall');

--keys gia books-authors
INSERT INTO BookAuthors VALUES(1, 1),(2,2), (3,2),(4,2),(5,3),(6,3),(7,3),(8,3),(9,4),(10,4),(11,4),(12,4);

--library
insert into Libraries(Name) values ('Dream Library');
insert into Librarian values ('Takis Takis',1);

--keys gia books-library
insert into LibraryBooks values (1,1,10,10);
insert into LibraryBooks values (1,2,10,10),(1,3,8,8),(1,4,6,6),(1,5,10,10),(1,7,10,10),(1,8,10,10),(1,10,10,10),(1,11,10,10),(1,12,10,10);



--users
insert into Users(Name) values ('Kourtz Christos');
insert into Users(Name) values ('Papadopoulos Mpampis');
insert into Users(Name) values ('Tade Maria');
insert into Users(Name) values ('Drakos Giangkos');

insert into LibraryUsers values (1,1),(1,2),(1,3),(1,4);


--Rents
insert into Rents values (1,1,1,5,default,1);

