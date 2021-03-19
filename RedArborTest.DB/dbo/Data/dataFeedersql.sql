USE [RedArborDatabase]
GO
SET IDENTITY_INSERT [dbo].[tblCompany] ON 
GO
INSERT [dbo].[tblCompany] ([CompanyId], [CompanyName]) VALUES (1, N'Coca Cola')
GO
INSERT [dbo].[tblCompany] ([CompanyId], [CompanyName]) VALUES (2, N'Apple')
GO
INSERT [dbo].[tblCompany] ([CompanyId], [CompanyName]) VALUES (3, N'Disney')
GO
SET IDENTITY_INSERT [dbo].[tblCompany] OFF
GO
SET IDENTITY_INSERT [dbo].[tblPortal] ON 
GO
INSERT [dbo].[tblPortal] ([PortalId], [PortalName]) VALUES (1, N'Computrabajo')
GO
INSERT [dbo].[tblPortal] ([PortalId], [PortalName]) VALUES (2, N'Sherlock')
GO
INSERT [dbo].[tblPortal] ([PortalId], [PortalName]) VALUES (3, N'Holmes')
GO
SET IDENTITY_INSERT [dbo].[tblPortal] OFF
GO
SET IDENTITY_INSERT [dbo].[tblRole] ON 
GO
INSERT [dbo].[tblRole] ([RoleId], [RoleName]) VALUES (1, N'Usuario')
GO
INSERT [dbo].[tblRole] ([RoleId], [RoleName]) VALUES (2, N'Admin')
GO
SET IDENTITY_INSERT [dbo].[tblRole] OFF
GO
SET IDENTITY_INSERT [dbo].[tblStatus] ON 
GO
INSERT [dbo].[tblStatus] ([StatusId], [StatusName]) VALUES (1, N'Activo')
GO
INSERT [dbo].[tblStatus] ([StatusId], [StatusName]) VALUES (2, N'Eliminado')
GO
SET IDENTITY_INSERT [dbo].[tblStatus] OFF
GO
