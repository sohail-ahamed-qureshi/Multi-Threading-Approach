CREATE PROCEDURE [dbo].[SpSumOperation]
AS
	SELECT SUM(Basic_Pay) FROM EmployeePayroll WHERE Gender = 'male';
RETURN 0
