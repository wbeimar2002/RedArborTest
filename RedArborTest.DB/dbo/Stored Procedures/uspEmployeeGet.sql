-- =============================================
-- Author:		Alexander Gonzalez
-- Create date: 03-17-2021
-- Description:	Employee StoreProcedure
-- =============================================
CREATE PROCEDURE [dbo].[uspEmployeeGet] 
	@EmployeeId int = NULL 
AS
BEGIN
	SELECT 
				EmployeeId
				, Name
				, Fax
				, Email
				, Password
				, UserName
				, Telephone
				, CompanyName
				, PortalName
				, RoleName
				, StatusName
				, LastLogin
				, CreatedOn
				, UpdateOn
				, DeletedOn
		FROM [dbo].[tblEmployee] emp 
		INNER JOIN [dbo].[tblCompany]	com		ON emp.CompanyId = com.CompanyId
		INNER JOIN [dbo].[tblPortal]	por		ON emp.PortalId = por.PortalId
		INNER JOIN [dbo].[tblRole]		rol		ON emp.RoleId = rol.RoleId
		INNER JOIN [dbo].[tblStatus]	sta		ON emp.StatusId = sta.StatusId
		WHERE emp.StatusId <>2 
		and (@EmployeeId IS NULL OR EmployeeId = @EmployeeId)
END
