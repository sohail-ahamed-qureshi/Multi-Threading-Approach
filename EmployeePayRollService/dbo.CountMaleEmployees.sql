CREATE PROCEDURE [dbo].[SpCountOperation]
AS
	SELECT Count(EmployeeId) FROM EmployeePayroll where Gender = 'male';
	SELECT Count(EmployeeId) FROM EmployeePayroll where Gender = 'female';
RETURN 0
