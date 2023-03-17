CREATE TABLE [ordr].[LineItems] (
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [OrderId] UNIQUEIDENTIFIER NOT NULL,
    [ProductId] UNIQUEIDENTIFIER NOT NULL REFERENCES [prod].[Product]([Id]),
    [PriceAmount] DECIMAL(18, 2) NOT NULL,
    [PriceCurrency] VARCHAR(3) NOT NULL,
    [Quantity] INT NOT NULL,
    CONSTRAINT [FK_LineItem_Order] FOREIGN KEY ([OrderId]) 
        REFERENCES [ordr].[Orders] ([Id]) ON DELETE CASCADE
);
