create database CategoryProduct
GO

create table Category
(
	CategoryId INT IDENTITY (1,1),
	CategoryName VARCHAR(100) NOT NULL

	constraint PK_Category PRIMARY KEY NONCLUSTERED (CategoryId)
);

create table Product
(
	ProductId INT IDENTITY (1,1),
	ProductName VARCHAR(100) NOT NULL

	constraint PK_Product PRIMARY KEY NONCLUSTERED (ProductId)
);

create table CategoryProduct
(
	Id INT NOT NULL IDENTITY (1,1),
	CategoryId INT NOT NULL,
	ProductId INT NOT NULL,

	constraint FK_CategoryProduct_Product FOREIGN KEY (ProductId) REFERENCES Product(ProductId),
	constraint FK_CategoryProduct_Category FOREIGN KEY (CategoryId) REFERENCES Category(CategoryId)
);



insert into Category (CategoryName) values
('A'), ('B'), ('C');

insert into Product (ProductName) values
('First'), ('Second'), ('Third'), ('Fourth'), ('Fifth')

insert into CategoryProduct (CategoryId, ProductId) values
(1,1), (1,3), (1,5), (2,1), (2,2), (3,3);
