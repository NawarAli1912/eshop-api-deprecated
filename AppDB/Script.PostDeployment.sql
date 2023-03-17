/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
USE [eshop_api_DB];

-- Insert data into [cust].[Customers]
INSERT INTO [cust].[Customers] (Id, Email, Name)
VALUES (NEWID(), 'john.doe@example.com', 'John Doe');

-- Insert data into [prod].[Category]
INSERT INTO [prod].[Category] (Id, Name, Description, ParentCategoryId, ImageUrl, IsFeatured)
VALUES (NEWID(), 'Category Name', 'Category Description', NULL, NULL, 0);

-- Insert data into [prod].[Product]
DECLARE @categoryId UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM [prod].[Category]);
INSERT INTO [prod].[Product] (Id, Name, Description, Price, ImageUrl, CategoryId)
VALUES (NEWID(), 'Product Name', 'Product Description', 10.99, NULL, @categoryId);


-- Insert data into [ordr].[Orders]
INSERT INTO [ordr].[Orders] (Id, CustomerId, Created, Updated, Version)
VALUES (NEWID(), (SELECT TOP 1 Id FROM [cust].[Customers]), GETDATE(), GETDATE(), 1);

-- Insert data into [ordr].[LineItems]
DECLARE @orderId UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM [ordr].[Orders]);
DECLARE @productId UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM [prod].[Product]);
INSERT INTO [ordr].[LineItems] (Id, OrderId, ProductId, PriceAmount, PriceCurrency, Quantity)
VALUES (NEWID(), @orderId, @productId, 10.99, 'USD', 1);
