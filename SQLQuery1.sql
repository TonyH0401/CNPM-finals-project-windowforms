--create database CNPM_final_project

--use CNPM_final_project

create table Account (
	accountID varchar(255) not null,
	accountPassword varchar(255) not null,
	accountFirstName nvarchar(255) not null,
	accountLastName nvarchar(255) not null,
	accountEmail varchar(255) not null,
	accountPhone varchar(255) not null,
	accountAddress nvarchar (255) not null,
	constraint PK_accountID primary key(accountID)
)


insert into Account values ('ACCT1', '123','Nguyễn', 'Toàn', 'nguyenvantoan@gmail.com','111-222-333','123 Nguyễn Văn Cừ, F.1, Q.1, TPHCM')
insert into Account values ('ACCT2', '123','Nguyễn', 'Hoàng', 'nguyenhuyhoang@gmail.com','444-555-777','123 Nguyễn Khuyến, F.2, Q.2, HN')
insert into Account values ('STRMNGR1', '123','Hồ', 'Toàn', 'hovantoan@gmail.com','222-222-333','123 Nguyễn Bỉnh Khiêm, F.3, Q.3, TPHCM')
insert into Account values ('STRMNGR2', '123','Hồ', 'Huy', 'hovanhuy@gmail.com','333-222-333','123 Nguyễn Văn Cừ, F.4, Q.4, Đà Năng')
select * from Account

create table Product (
	productID varchar(255) not null,
	productName nvarchar(255) not null,
	productPrice int not null,
	productQuantity int not null,
	productOrigin nvarchar(255) not null,
	constraint PK_productID primary key(productID)
)

insert into Product values ('PROD1','Workout Powder',30,1000,'USA')
insert into Product values ('PROD2','Workout Energy Bar',10,1500,'Germany')
insert into Product values ('PROD3','Static Energy Drink',20,1000,'Vietnam')
insert into Product values ('PROD4','Chicken Salad',40,1000,'China')
select * from Product

create table Store (
	storeID varchar(255) not null,
	storeName nvarchar(255) not null,
	storeLocation nvarchar(255) not null,
	constraint PK_storeId primary key (storeID)
)
delete from Store

insert into Store values ('ST1', 'CITYGYM L1', '1 Ngo Quyen, F.1, Q.1, TPHCM')
insert into Store values ('ST2', 'YOGA FITNESS', '2 Hoang Hoa Tham, F.1, Q.1, TPHCM')
insert into Store values ('ST3', 'HOME GYM', '2 Nguyen Hue, F.1, Q.1, TPHCM')
insert into Store values ('ST4', 'CITYGYM L2', '1 Pasteur, F.1, Q.1, TPHCM')
select * from Store