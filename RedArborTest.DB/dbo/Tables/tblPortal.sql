CREATE TABLE [dbo].[tblPortal] (
    [PortalId]   SMALLINT      IDENTITY (1, 1) NOT NULL,
    [PortalName] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_tblPortal] PRIMARY KEY CLUSTERED ([PortalId] ASC)
);

