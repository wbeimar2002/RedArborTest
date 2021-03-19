-- =============================================
-- Author:		Alexander Gonzalez
-- Create date: 03/18/2021
-- Description:	Delete Employee stored procedure
-- =============================================
CREATE PROCEDURE uspEmployeeDelete 
	@EmployeeId int 
AS
BEGIN
		UPDATE [dbo].[tblEmployee]
		SET [StatusId] = 2
			,UpdateOn = GETDATE()
			,DeletedOn = GETDATE()
		WHERE [EmployeeId] = @EmployeeId
END
