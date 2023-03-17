CREATE TABLE [prod].[Product]
(
    [Id] [uniqueidentifier] NOT NULL,
    [Name] [nvarchar](max) NOT NULL,
    [Description] [nvarchar](max) NOT NULL,
    [Price] [decimal](18,2) NOT NULL,
    [ImageUrl] [nvarchar](max) NULL,
    [CategoryId] [uniqueidentifier] NOT NULL,

    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC),

    CONSTRAINT [FK_Product_Category] FOREIGN KEY ([CategoryId]) 
        REFERENCES [prod].[Category] ([Id]) ON DELETE NO ACTION
)