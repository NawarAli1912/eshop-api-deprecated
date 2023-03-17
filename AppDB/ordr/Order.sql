CREATE TABLE [ordr].[Orders] (
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [CustomerId] UNIQUEIDENTIFIER NOT NULL REFERENCES [cust].[Customers]([Id]),
    [Created] DATETIME2 NOT NULL,
    [Updated] DATETIME2 NOT NULL,
    [Version] INT NOT NULL
);