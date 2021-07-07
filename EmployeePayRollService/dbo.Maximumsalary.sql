CREATE PROCEDURE [dbo].[SpMaxOperation]
AS
	SELECT Max(Basic_Pay) FROM EmployeePayroll;
RETURN 0
