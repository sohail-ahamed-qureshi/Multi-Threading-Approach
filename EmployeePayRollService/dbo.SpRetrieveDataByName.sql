CREATE PROCEDURE [dbo].[SpRetrieveDataByName]
	@EmployeeName varchar(255)
AS
	SELECT EmployeeName, Gender, Department, PhoneNumber, Address, Basic_Pay, StartingDate FROM EmployeePayroll Where EmployeeName = @EmployeeName;
RETURN 0
