
/*Notes/Notlar
//SQL server'da (açtığımız tablodaki herhangi bir (mesela id) kolon için) Identity Incermet değeri 1 ise otamatik olarak artar şekilde gidecektir
//Oluşturlan kolonda not null işaretli ise boş geçemeszsin diyorudur
//FOREIGN KEY ile başlayan komutlar diğer tablodan referansını alıyor
*/

--create database RentACar


create table Cars 
(
CarId int identity (1,1) not null,
CarName nvarchar (Max) ,
CategoryId int,
BrandId int,
ColorId int,
ModelYear int,
UnitPrice deciaml(18),
UnitsInStock smallint,
Description nvarchar (Max),
State nvarchar (Max),
ImageId int,
CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED ([CarId] ASC)--,
--FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId),
--FOREIGN KEY (BrandId) REFERENCES Brands(BrandId),
--FOREIGN KEY (ColorId) REFERENCES Colors(ColorId),
--FOREIGN KEY (ImageId) REFERENCES CarImages(ImageId)

);

select * from Cars

--drop table CarInfo

create table Categories
(
CategoryId int identity (1,1) not null,
CategoryName nvarchar (50),
CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryId] ASC)
);

select * from Categories
--drop table Categories

create table Brands
(
BrandId int identity (1,1) not null,
BrandName nvarchar (24),
CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED ([BrandId] ASC)
);

select * from Brands
--drop table Brands

create table Colors
(
ColorId int identity (1,1) not null,
ColorName nvarchar (50),
CONSTRAINT [PK_Colors] PRIMARY KEY CLUSTERED ([ColorId] ASC)
);

select * from Colors
--drop table Colors




--22.04.2021
create table Users(
UserId int identity (1,1) not null,
FirstName nvarchar (MAX) not null,
LastName nvarchar (Max)not null,
Email nvarchar (MAX),
Password nvarchar (max) not null,
CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserId] ASC)
)
select * from Users



create table Customers(
CustomerId int identity (1,1) not null,
UserId int null,
CompanyName nvarchar (max) not null,
CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([CustomerId] ASC)--,
--FOREIGN KEY (UserId) REFERENCES Users(UserId)

)
select * from Customers

--drop table Customers

create table Rentals(
RentId int identity (1,1) not null,
CarId int   null,
CustomerId int  null,
RentDate date  null,
ReturnDate date  null,
CONSTRAINT [PK_Rentals] PRIMARY KEY CLUSTERED ([RentId] ASC)--,
--FOREIGN KEY (CarId) REFERENCES Cars(CarId),
--FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
)

select * from Rentals

--drop table Rentals

create table CarImages
(
[ImageId]   INT            IDENTITY NOT NULL,
    [CarId]     INT            NOT NULL,
    [ImagePath] NVARCHAR (MAX) NOT NULL,
    [ImageDate] datetime DEFAULT GETDATE(),
CONSTRAINT [PK_CarImages] PRIMARY KEY CLUSTERED ([ImageId] ASC)--,
--FOREIGN KEY (CarId) REFERENCES Cars(CarId)
)

select * from CarImages

--drop table CarImages

 