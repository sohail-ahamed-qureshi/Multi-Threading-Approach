CREATE PROCEDURE [dbo].[SpCountFemaleOperation]
AS
	SELECT Count(EmployeeId) FROM EmployeePayroll where Gender = 'female';
RETURN 0

