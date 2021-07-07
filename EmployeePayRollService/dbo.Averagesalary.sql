CREATE PROCEDURE [dbo].[SpAverageOperation]
AS
	SELECT AVG(Basic_Pay) FROM EmployeePayroll;
RETURN 0