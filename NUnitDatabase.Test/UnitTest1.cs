using EmployeePayRollService;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NUnitDatabase.Test
{
    public class Tests
    {
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