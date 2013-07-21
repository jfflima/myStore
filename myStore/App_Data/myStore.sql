CREATE TABLE Product (
	Id UNIQUEIDENTIFIER NOT NULL,
	Name NVARCHAR(200) NOT NULL,
	Description NVARCHAR(MAX) NOT NULL,
	CONSTRAINT PK_Product PRIMARY KEY (Id)  
)
GO

TRUNCATE TABLE Product
GO

INSERT INTO Product (Id, Name, Description) VALUES (newid(), 'Product1', 'Description1')
INSERT INTO Product (Id, Name, Description) VALUES (newid(), 'Product2', 'Description2')
INSERT INTO Product (Id, Name, Description) VALUES (newid(), 'Product3', 'Description3')
INSERT INTO Product (Id, Name, Description) VALUES (newid(), 'Product4', 'Description4')
INSERT INTO Product (Id, Name, Description) VALUES (newid(), 'Product5', 'Description5')
INSERT INTO Product (Id, Name, Description) VALUES (newid(), 'Product6', 'Description6')
INSERT INTO Product (Id, Name, Description) VALUES (newid(), 'Product7', 'Description7')
INSERT INTO Product (Id, Name, Description) VALUES (newid(), 'Product8', 'Description8')
INSERT INTO Product (Id, Name, Description) VALUES (newid(), 'Product9', 'Description9')
INSERT INTO Product (Id, Name, Description) VALUES (newid(), 'Product10', 'Description10')
INSERT INTO Product (Id, Name, Description) VALUES (newid(), 'Product11', 'Description11')
GO
