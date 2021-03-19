CREATE TABLE [dbo].[tblCompany] (
    [CompanyId]   INT           IDENTITY (1, 1) NOT NULL,
    [CompanyName] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_tblCompany] PRIMARY KEY CLUSTERED ([CompanyId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_tblCompany]
    ON [dbo].[tblCompany]([CompanyId] ASC);

