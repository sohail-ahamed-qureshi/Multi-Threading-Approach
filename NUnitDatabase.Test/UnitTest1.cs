using EmployeePayRollService;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NUnitDatabase.Test
{
    public class Tests
    {
        //list of employees for adding multiple employees at same time
        List<Employee> employeeList = new List<Employee>()
        {
            new Employee{ EmployeeName = "Mohan",Gender = "Male", Address = "some address",Department = "Sales", PhoneNumber = 1234565432, BasicPay = 100000, Deductions = 5000, TaxablePay = 2000, Tax = 1000, NetPay = 900000, StartingDate =  DateTime.ParseExact("1996-10-10", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)},
            new Employee{ EmployeeName = "Rohan",Gender = "Male", Address = "some address",Department = "Sales", PhoneNumber = 1234565432, BasicPay = 100000, Deductions = 5000, TaxablePay = 2000, Tax = 1000, NetPay = 900000, StartingDate =  DateTime.ParseExact("1996-10-10", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)},
            new Employee{ EmployeeName = "ManMohan",Gender = "Male", Address = "some address",Department = "Sales", PhoneNumber = 1234565432, BasicPay = 100000, Deductions = 5000, TaxablePay = 2000, Tax = 1000, NetPay = 900000, StartingDate =  DateTime.ParseExact("1996-10-10", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)},
            new Employee{ EmployeeName = "Sohan",Gender = "Male", Address = "some address",Department = "Sales", PhoneNumber = 1234565432, BasicPay = 100000, Deductions = 5000, TaxablePay = 2000, Tax = 1000, NetPay = 900000, StartingDate =  DateTime.ParseExact("1996-10-10", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)},
            new Employee{ EmployeeName = "Mihan",Gender = "Male", Address = "some address",Department = "Sales", PhoneNumber = 1234565432, BasicPay = 100000, Deductions = 5000, TaxablePay = 2000, Tax = 1000, NetPay = 900000, StartingDate =  DateTime.ParseExact("1996-10-10", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)},
            new Employee{ EmployeeName = "Vihan",Gender = "Male", Address = "some address",Department = "Sales", PhoneNumber = 1234565432, BasicPay = 100000, Deductions = 5000, TaxablePay = 2000, Tax = 1000, NetPay = 900000, StartingDate =  DateTime.ParseExact("1996-10-10", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)},
            new Employee{ EmployeeName = "Rihan",Gender = "Male", Address = "some address",Department = "Sales", PhoneNumber = 1234565432, BasicPay = 100000, Deductions = 5000, TaxablePay = 2000, Tax = 1000, NetPay = 900000, StartingDate =  DateTime.ParseExact("1996-10-10", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)},
        };

        [Test]
        public void GivenMultipleEmployeeDetailsToAdd_ReturnsTrue()
        {
            //Arrange
            bool expected = true;
            Employee employee = new Employee();
            //Act
            bool result = employee.AddData(employeeList);
            //Assert
            Assert.AreEqual(result, expected);
        }
        [Test]
        public void GivenSalaryAndName_UpdatesInDatebase()
        {
            //Arrange
            Employee employee = new Employee();
            bool result = employee.UpdateSalary("sohail", 5000000);
            bool expected = true;
            Assert.AreEqual(result,expected);
        }

        [Test]
        public void GivenName_ReturnsEmployeeDetails()
        {
            //Arrange
            Employee employee = new Employee();
            bool result = employee.GetDataByName("john");
            bool expected = true;
            Assert.AreEqual(result, expected);
        }

    }
}