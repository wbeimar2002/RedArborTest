CREATE TABLE [dbo].[tblEmployee] (
    [EmployeeId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]       VARCHAR (100) NOT NULL,
    [Fax]        VARCHAR (11)  NULL,
    [Email]      VARCHAR (100) NOT NULL,
    [Password]   VARCHAR (100) NOT NULL,
    [UserName]   VARCHAR (100) NOT NULL,
    [Telephone]  VARCHAR (11)  NULL,
    [CompanyId]  INT           NOT NULL,
    [PortalId]   SMALLINT      NOT NULL,
    [RoleId]     SMALLINT      NOT NULL,
    [StatusId]   SMALLINT      NOT NULL,
    [LastLogin]  DATETIME      NOT NULL,
    [CreatedOn]  DATETIME      NOT NULL,
    [UpdateOn]   DATETIME      NULL,
    [DeletedOn]  DATETIME      NULL,
    CONSTRAINT [PK_tblEmployee] PRIMARY KEY CLUSTERED ([EmployeeId] ASC),
    CONSTRAINT [FK_tblEmployee_tblCompany] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[tblCompany] ([CompanyId]),
    CONSTRAINT [FK_tblEmployee_tblPortal] FOREIGN KEY ([PortalId]) REFERENCES [dbo].[tblPortal] ([PortalId]),
    CONSTRAINT [FK_tblEmployee_tblRole] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[tblRole] ([RoleId]),
    CONSTRAINT [FK_tblEmployee_tblStatus] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[tblStatus] ([StatusId])
);

