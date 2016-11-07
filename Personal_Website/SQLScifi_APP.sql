create table Movies(ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,Title nvarchar(100) not null,
DateRel date,SubCategory varchar(100), Link1 varchar(255), Link2 varchar(255))

create table Users(UserID int NOT NULL IDENTITY(1,1) PRIMARY KEY,UserName nvarchar(50) not null,
Email nvarchar(100) not null)

create table Rates(MovieID int not null foreign key references Movies(ID),
UserID int not null foreign key references Users(UserID),
Rate int not null 
Constraint RateID primary key(MovieID,UserID));

create table Comments(MovieID int not null foreign key references Movies(ID),
UserID int not null foreign key references Users(UserID),
Comment nvarchar(1000) not null, Likes int,
Constraint CommentID primary key(MovieID,UserID));



