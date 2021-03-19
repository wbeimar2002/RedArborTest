CREATE TYPE [dbo].[EmployeeData] AS TABLE (
    [EmployeeId] INT           NULL,
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
    [DeletedOn]  DATETIME      NULL);

