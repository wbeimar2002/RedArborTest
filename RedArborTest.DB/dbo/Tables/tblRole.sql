CREATE TABLE [dbo].[tblRole] (
    [RoleId]   SMALLINT      IDENTITY (1, 1) NOT NULL,
    [RoleName] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_tblRole] PRIMARY KEY CLUSTERED ([RoleId] ASC)
);

