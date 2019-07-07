Create Database ArticleApi

GO

USE ArticleApi

GO

CREATE TABLE [Authors] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(250) NOT NULL,
    [Bio] nvarchar(max) NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Articles] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(250) NOT NULL,
    [Content] nvarchar(max) NULL,
    [AuthorId] int NULL,
    CONSTRAINT [PK_Articles] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Articles_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Articles_AuthorId] ON [Articles] ([AuthorId]);

GO