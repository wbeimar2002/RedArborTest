-- =============================================
-- Author:		Alexander Gonzalez
-- Create date: 03/18/2021
-- Description:	Create Update Employee Stored Procedure
-- =============================================
CREATE PROCEDURE uspEmployeeCreateUpdate
	@EmployeeData	[dbo].[EmployeeData]	READONLY
AS
BEGIN
		IF EXISTS (SELECT TOP 1 [EmployeeId] FROM @EmployeeData WHERE [EmployeeId] IS NOT NULL) BEGIN
		
			UPDATE [tblEmployee] 
			SET		Name			= emp.Name
					,Fax			= emp.Fax
					,Email			= emp.Email
					,Password		= emp.Password
					,UserName		= emp.UserName
					,Telephone		= emp.Telephone
					,CompanyId		= emp.CompanyId
					,PortalId		= emp.PortalId
					,RoleId			= emp.RoleId
					,StatusId		= emp.StatusId
					,LastLogin		= emp.LastLogin
					,CreatedOn		= emp.CreatedOn
					,UpdateOn		= emp.UpdateOn
					,DeletedOn		= emp.DeletedOn
			FROM	(SELECT  EmployeeId
							 ,Name		
							 ,Fax		
							 ,Email		
							 ,Password
							 ,UserName
							 ,Telephone
							 ,CompanyId
							 ,PortalId
							 ,RoleId		
							 ,StatusId
							 ,LastLogin
							 ,CreatedOn
							 ,UpdateOn
							 ,DeletedOn
						FROM @EmployeeData) AS emp
			WHERE	emp.EmployeeId  = [tblEmployee].EmployeeId  
		END 
		ELSE BEGIN 

			INSERT INTO [dbo].[tblEmployee]
			SELECT  Name
					, Fax
					, Email
					, Password
					, UserName
					, Telephone
					, CompanyId
					, PortalId
					, RoleId
					, StatusId
					, LastLogin
					, CreatedOn
					, UpdateOn
					, DeletedOn
			FROM	@EmployeeData
		END
END
