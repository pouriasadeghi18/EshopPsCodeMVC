
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/02/2022 20:34:23
-- Generated from EDMX file: C:\Users\Porya\Desktop\EshopPsCodeMVC\EshopPsCodeMVC\DataLayer\EshopPsCode.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EshopPsCode];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Grouping_Grouping]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Grouping] DROP CONSTRAINT [FK_Grouping_Grouping];
GO
IF OBJECT_ID(N'[dbo].[FK_Product_Galleries_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product_Galleries] DROP CONSTRAINT [FK_Product_Galleries_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_Product_Selected_Groups_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product_Selected_Groups] DROP CONSTRAINT [FK_Product_Selected_Groups_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_Product_Selected_Groups_Product1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product_Selected_Groups] DROP CONSTRAINT [FK_Product_Selected_Groups_Product1];
GO
IF OBJECT_ID(N'[dbo].[FK_Product_Tags_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product_Tags] DROP CONSTRAINT [FK_Product_Tags_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_Users_Role1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_Role1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Grouping]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Grouping];
GO
IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO
IF OBJECT_ID(N'[dbo].[Product_Galleries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product_Galleries];
GO
IF OBJECT_ID(N'[dbo].[Product_Selected_Groups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product_Selected_Groups];
GO
IF OBJECT_ID(N'[dbo].[Product_Tags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product_Tags];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [RoleID] int  NOT NULL,
    [RoleTitle] nvarchar(100)  NOT NULL,
    [RoleName] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [RoleID] int  NOT NULL,
    [UserName] nvarchar(250)  NOT NULL,
    [Email] nvarchar(250)  NOT NULL,
    [Password] nvarchar(250)  NOT NULL,
    [ActiveCode] nvarchar(250)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [RegisterDate] datetime  NOT NULL
);
GO

-- Creating table 'Grouping'
CREATE TABLE [dbo].[Grouping] (
    [GroupingID] int IDENTITY(1,1) NOT NULL,
    [GroupingName] nvarchar(350)  NOT NULL,
    [Subgroup] int  NULL
);
GO

-- Creating table 'Product'
CREATE TABLE [dbo].[Product] (
    [ProductID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(250)  NOT NULL,
    [ShortDiscraption] nvarchar(500)  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [Price] int  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [ImageName] varchar(50)  NOT NULL
);
GO

-- Creating table 'Product_Galleries'
CREATE TABLE [dbo].[Product_Galleries] (
    [GalleryID] int IDENTITY(1,1) NOT NULL,
    [ProductID] int  NOT NULL,
    [ImageName] varchar(50)  NULL
);
GO

-- Creating table 'Product_Selected_Groups'
CREATE TABLE [dbo].[Product_Selected_Groups] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GroupID] int  NOT NULL,
    [ProductID] int  NOT NULL
);
GO

-- Creating table 'Product_Tags'
CREATE TABLE [dbo].[Product_Tags] (
    [TagID] int IDENTITY(1,1) NOT NULL,
    [ProductID] int  NOT NULL,
    [Tag] nvarchar(250)  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [RoleID] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([RoleID] ASC);
GO

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [GroupingID] in table 'Grouping'
ALTER TABLE [dbo].[Grouping]
ADD CONSTRAINT [PK_Grouping]
    PRIMARY KEY CLUSTERED ([GroupingID] ASC);
GO

-- Creating primary key on [ProductID] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [PK_Product]
    PRIMARY KEY CLUSTERED ([ProductID] ASC);
GO

-- Creating primary key on [GalleryID] in table 'Product_Galleries'
ALTER TABLE [dbo].[Product_Galleries]
ADD CONSTRAINT [PK_Product_Galleries]
    PRIMARY KEY CLUSTERED ([GalleryID] ASC);
GO

-- Creating primary key on [ID] in table 'Product_Selected_Groups'
ALTER TABLE [dbo].[Product_Selected_Groups]
ADD CONSTRAINT [PK_Product_Selected_Groups]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [TagID] in table 'Product_Tags'
ALTER TABLE [dbo].[Product_Tags]
ADD CONSTRAINT [PK_Product_Tags]
    PRIMARY KEY CLUSTERED ([TagID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RoleID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_Users_Role1]
    FOREIGN KEY ([RoleID])
    REFERENCES [dbo].[Role]
        ([RoleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Users_Role1'
CREATE INDEX [IX_FK_Users_Role1]
ON [dbo].[Users]
    ([RoleID]);
GO

-- Creating foreign key on [Subgroup] in table 'Grouping'
ALTER TABLE [dbo].[Grouping]
ADD CONSTRAINT [FK_Grouping_Grouping]
    FOREIGN KEY ([Subgroup])
    REFERENCES [dbo].[Grouping]
        ([GroupingID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Grouping_Grouping'
CREATE INDEX [IX_FK_Grouping_Grouping]
ON [dbo].[Grouping]
    ([Subgroup]);
GO

-- Creating foreign key on [ID] in table 'Product_Selected_Groups'
ALTER TABLE [dbo].[Product_Selected_Groups]
ADD CONSTRAINT [FK_Product_Selected_Groups_Grouping]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Grouping]
        ([GroupingID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProductID] in table 'Product_Galleries'
ALTER TABLE [dbo].[Product_Galleries]
ADD CONSTRAINT [FK_Product_Galleries_Product]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[Product]
        ([ProductID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_Galleries_Product'
CREATE INDEX [IX_FK_Product_Galleries_Product]
ON [dbo].[Product_Galleries]
    ([ProductID]);
GO

-- Creating foreign key on [ProductID] in table 'Product_Selected_Groups'
ALTER TABLE [dbo].[Product_Selected_Groups]
ADD CONSTRAINT [FK_Product_Selected_Groups_Product]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[Product]
        ([ProductID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_Selected_Groups_Product'
CREATE INDEX [IX_FK_Product_Selected_Groups_Product]
ON [dbo].[Product_Selected_Groups]
    ([ProductID]);
GO

-- Creating foreign key on [ProductID] in table 'Product_Tags'
ALTER TABLE [dbo].[Product_Tags]
ADD CONSTRAINT [FK_Product_Tags_Product]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[Product]
        ([ProductID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_Tags_Product'
CREATE INDEX [IX_FK_Product_Tags_Product]
ON [dbo].[Product_Tags]
    ([ProductID]);
GO

-- Creating foreign key on [GroupID] in table 'Product_Selected_Groups'
ALTER TABLE [dbo].[Product_Selected_Groups]
ADD CONSTRAINT [FK_Product_Selected_Groups_Grouping1]
    FOREIGN KEY ([GroupID])
    REFERENCES [dbo].[Grouping]
        ([GroupingID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_Selected_Groups_Grouping1'
CREATE INDEX [IX_FK_Product_Selected_Groups_Grouping1]
ON [dbo].[Product_Selected_Groups]
    ([GroupID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------