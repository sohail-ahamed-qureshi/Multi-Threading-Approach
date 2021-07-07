using System;

namespace EmployeePayRollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Section 3 - ADO.Net");
            //passing data into model class
            Employee employee = new Employee
            {
                EmployeeName = "Sohail",
                StartingDate = DateTime.ParseExact("1996-10-10", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Gender = "Male",
                Department = "Developer",
                PhoneNumber = 1234567890,
                Address = "Bangalore",
                BasicPay = 100000,
                Deductions = 2000,
                TaxablePay = 3000,
                Tax = 2000,
                NetPay = 1000
            };
            //add data to database which accepts parameter of type Employee.
            employee.AddData(employee);
            //retrives the data from data base and displays it.
            employee.GetData();
            //Retrieve salary of Employee
            employee.RetrieveSalary("terisa");
            //Update salary of Employee
            employee.UpdateSalary("John", 300000);
            //Perform operations like SUM, MAX, MIN, COUNT and AVG
            employee.Operations();
        }
    }
}
