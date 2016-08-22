
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/19/2016 18:43:42
-- Generated from EDMX file: E:\学习·开发\Sloth\P1.Model\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DAQ];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_R_User_Role_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_User_Role] DROP CONSTRAINT [FK_R_User_Role_User];
GO
IF OBJECT_ID(N'[dbo].[FK_R_User_Role_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_User_Role] DROP CONSTRAINT [FK_R_User_Role_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_R_Role_Action_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_Role_Action] DROP CONSTRAINT [FK_R_Role_Action_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_R_Role_Action_Action]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_Role_Action] DROP CONSTRAINT [FK_R_Role_Action_Action];
GO
IF OBJECT_ID(N'[dbo].[FK_R_User_Action_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_User_Action] DROP CONSTRAINT [FK_R_User_Action_User];
GO
IF OBJECT_ID(N'[dbo].[FK_R_User_Action_Action]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_User_Action] DROP CONSTRAINT [FK_R_User_Action_Action];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Actions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Actions];
GO
IF OBJECT_ID(N'[dbo].[R_User_Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[R_User_Role];
GO
IF OBJECT_ID(N'[dbo].[R_Role_Action]', 'U') IS NOT NULL
    DROP TABLE [dbo].[R_Role_Action];
GO
IF OBJECT_ID(N'[dbo].[R_User_Action]', 'U') IS NOT NULL
    DROP TABLE [dbo].[R_User_Action];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] uniqueidentifier  NOT NULL,
    [UserName] nvarchar(32)  NULL,
    [Password] nvarchar(32)  NULL,
    [ModifyTime] datetime  NOT NULL,
    [DeleteMark] int  NOT NULL,
    [CreateByID] uniqueidentifier  NULL,
    [CreateByName] nvarchar(32)  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleID] uniqueidentifier  NOT NULL,
    [RoleName] nvarchar(32)  NULL,
    [RoleType] nvarchar(max)  NULL,
    [ModifyTime] datetime  NULL,
    [DeleteMark] int  NULL
);
GO

-- Creating table 'Actions'
CREATE TABLE [dbo].[Actions] (
    [ActionID] uniqueidentifier  NOT NULL,
    [ActionName] nvarchar(max)  NULL,
    [RequestURL] nvarchar(max)  NULL,
    [RequestHttpType] nvarchar(max)  NULL,
    [ModifyTime] datetime  NULL
);
GO

-- Creating table 'R_User_Role'
CREATE TABLE [dbo].[R_User_Role] (
    [User_UserID] uniqueidentifier  NOT NULL,
    [Role_RoleID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'R_Role_Action'
CREATE TABLE [dbo].[R_Role_Action] (
    [Role_RoleID] uniqueidentifier  NOT NULL,
    [Action_ActionID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'R_User_Action'
CREATE TABLE [dbo].[R_User_Action] (
    [R_User_Action_Action_UserID] uniqueidentifier  NOT NULL,
    [Action_ActionID] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [RoleID] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleID] ASC);
GO

-- Creating primary key on [ActionID] in table 'Actions'
ALTER TABLE [dbo].[Actions]
ADD CONSTRAINT [PK_Actions]
    PRIMARY KEY CLUSTERED ([ActionID] ASC);
GO

-- Creating primary key on [User_UserID], [Role_RoleID] in table 'R_User_Role'
ALTER TABLE [dbo].[R_User_Role]
ADD CONSTRAINT [PK_R_User_Role]
    PRIMARY KEY NONCLUSTERED ([User_UserID], [Role_RoleID] ASC);
GO

-- Creating primary key on [Role_RoleID], [Action_ActionID] in table 'R_Role_Action'
ALTER TABLE [dbo].[R_Role_Action]
ADD CONSTRAINT [PK_R_Role_Action]
    PRIMARY KEY NONCLUSTERED ([Role_RoleID], [Action_ActionID] ASC);
GO

-- Creating primary key on [R_User_Action_Action_UserID], [Action_ActionID] in table 'R_User_Action'
ALTER TABLE [dbo].[R_User_Action]
ADD CONSTRAINT [PK_R_User_Action]
    PRIMARY KEY NONCLUSTERED ([R_User_Action_Action_UserID], [Action_ActionID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_UserID] in table 'R_User_Role'
ALTER TABLE [dbo].[R_User_Role]
ADD CONSTRAINT [FK_R_User_Role_User]
    FOREIGN KEY ([User_UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Role_RoleID] in table 'R_User_Role'
ALTER TABLE [dbo].[R_User_Role]
ADD CONSTRAINT [FK_R_User_Role_Role]
    FOREIGN KEY ([Role_RoleID])
    REFERENCES [dbo].[Roles]
        ([RoleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_User_Role_Role'
CREATE INDEX [IX_FK_R_User_Role_Role]
ON [dbo].[R_User_Role]
    ([Role_RoleID]);
GO

-- Creating foreign key on [Role_RoleID] in table 'R_Role_Action'
ALTER TABLE [dbo].[R_Role_Action]
ADD CONSTRAINT [FK_R_Role_Action_Role]
    FOREIGN KEY ([Role_RoleID])
    REFERENCES [dbo].[Roles]
        ([RoleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Action_ActionID] in table 'R_Role_Action'
ALTER TABLE [dbo].[R_Role_Action]
ADD CONSTRAINT [FK_R_Role_Action_Action]
    FOREIGN KEY ([Action_ActionID])
    REFERENCES [dbo].[Actions]
        ([ActionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_Role_Action_Action'
CREATE INDEX [IX_FK_R_Role_Action_Action]
ON [dbo].[R_Role_Action]
    ([Action_ActionID]);
GO

-- Creating foreign key on [R_User_Action_Action_UserID] in table 'R_User_Action'
ALTER TABLE [dbo].[R_User_Action]
ADD CONSTRAINT [FK_R_User_Action_User]
    FOREIGN KEY ([R_User_Action_Action_UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Action_ActionID] in table 'R_User_Action'
ALTER TABLE [dbo].[R_User_Action]
ADD CONSTRAINT [FK_R_User_Action_Action]
    FOREIGN KEY ([Action_ActionID])
    REFERENCES [dbo].[Actions]
        ([ActionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_User_Action_Action'
CREATE INDEX [IX_FK_R_User_Action_Action]
ON [dbo].[R_User_Action]
    ([Action_ActionID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------