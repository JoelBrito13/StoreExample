# StoreExample
Example of RESTFul API written in ASP.NET Core 2.2 using: 
* Async Verbs 
* Entity Framework
* UnitOfWorks + Repository. 
* SQL Server

All the Methods should be Testing using the termination URL: _/swagger/index.html_ 

To test in your local environment, just change the _ConnectionStrings_ inside the _appsettings.json_ to receive the DataBase

  # Example of Database Creation

```console
	CREATE DATABASE demo;
	USE demo; ***

	CREATE TABLE Category(
		Idx INT IDENTITY(1,1) PRIMARY KEY,
		Name VARCHAR(50));

	CREATE TABLE Product(
		Idx INT IDENTITY(1,1) PRIMARY KEY,
		Name VARCHAR(50),
		Price FLOAT,
		CategoryIdx INT REFERENCES Category(Idx) ON DELETE CASCADE);

	INSERT INTO Category(Name) VALUES ( 'Eletronics');
	INSERT INTO Category(Name) VALUES ( 'Warehouse');

	INSERT INTO Product(Name, Price, CategoryIdx) VALUES ('Dell Inspiron', 11222.22, 1);
	INSERT INTO Product(Name, Price, CategoryIdx) VALUES ('Asus VivoBook', 113.22, 1);
	INSERT INTO Product(Name, Price, CategoryIdx) VALUES ('MacBook', 1.99, 1);
	INSERT INTO Product(Name, Price, CategoryIdx) VALUES ('LG Smart TV', 2.52, 2);

	SELECT * FROM Category;
	SELECT * FROM Product;
```

# Credits
Repository Patern + UnitOfWor: https://www.programmingwithwolfgang.com/repository-and-unit-of-work-pattern/


