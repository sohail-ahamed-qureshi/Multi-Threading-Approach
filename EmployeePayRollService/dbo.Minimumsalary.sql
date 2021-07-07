CREATE PROCEDURE [dbo].[SpMinOperation]
AS
	SELECT MIN(Basic_Pay) FROM EmployeePayroll;
RETURN 0
