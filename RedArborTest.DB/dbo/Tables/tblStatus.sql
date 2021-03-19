CREATE TABLE [dbo].[tblStatus] (
    [StatusId]   SMALLINT     IDENTITY (1, 1) NOT NULL,
    [StatusName] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_tblStatus] PRIMARY KEY CLUSTERED ([StatusId] ASC)
);

