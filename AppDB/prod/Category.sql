CREATE TABLE [prod].[Category]
(
    [Id] [uniqueidentifier] NOT NULL,
    [Name] [nvarchar](max) NOT NULL,
    [Description] [nvarchar](max) NOT NULL,
    [ParentCategoryId] [uniqueidentifier] NULL,
    [ImageUrl] [nvarchar](max) NULL,
    [IsFeatured] [bit] NOT NULL,

    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([Id] ASC),

    CONSTRAINT [FK_Category_ParentCategory] FOREIGN KEY ([ParentCategoryId]) 
        REFERENCES [prod].[Category] ([Id]) ON DELETE NO ACTION
)