using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmployeePayRollService
{
    /// <summary>
    /// details of Employee data
    /// </summary>
    public class Employee
    {
        //properties of Model class
        public string EmployeeName { get; set; }
        public DateTime StartingDate { get; set; }
        public long PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public double BasicPay { get; set; }
        public double Deductions { get; set; }
        public double TaxablePay { get; set; }
        public double Tax { get; set; }
        public double NetPay { get; set; }

        readonly string connectionString = "Data Source=S;Initial Catalog=payroll-service;Integrated Security=True;Pooling=False";
        /// <summary>
        /// method to get data from database using SqlConnection and SqlCommand passing sql query.
        /// </summary>
        public void GetData()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT EmployeeName, Gender, Department, PhoneNumber, Address, Basic_Pay, StartingDate FROM EmployeePayroll;";
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            EmployeeName = dr.GetString(0);
                            Gender = dr.GetString(1);
                            Department = dr.GetString(2);
                            PhoneNumber = dr.GetInt64(3);
                            Address = dr.GetString(4);
                            BasicPay = dr.GetDouble(5);
                            StartingDate = dr.GetDateTime(6);
                            Console.WriteLine($"{EmployeeName} {Gender} {Department} {PhoneNumber} {Address} {BasicPay} {StartingDate}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Performs 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool GetDataByName(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    string spName = "dbo.SpRetrieveDataByName";
                    SqlCommand command = new SqlCommand(spName, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", name);
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        EmployeeName = dr.GetString(0);
                        Gender = dr.GetString(1);
                        Department = dr.GetString(2);
                        PhoneNumber = dr.GetInt64(3);
                        Address = dr.GetString(4);
                        BasicPay = dr.GetDouble(5);
                        StartingDate = dr.GetDateTime(6);
                        Console.WriteLine($"{EmployeeName} {Gender} {Department} {PhoneNumber} {Address} {BasicPay} {StartingDate}");
                    }
                    if (dr != null)
                        return true;
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Performs Sum, Average, Minimum, Maximum, Count operations.
        /// </summary>
        public void Operations()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    //Total Sum of male employess
                    string spSum = "dbo.SpSumOperation";
                    SqlCommand command = new SqlCommand(spSum, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        BasicPay = dr.GetDouble(0);
                        Console.WriteLine($"Total Salary of Male Employees is : " + BasicPay);
                    }
                    dr.Close();
                    //Average salary of employees
                    string spAverage = "dbo.SpAverageOperation";
                    command = new SqlCommand(spAverage, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        BasicPay = dr.GetDouble(0);
                        Console.WriteLine($"Average Salary of Employees is : " + BasicPay);
                    }
                    dr.Close();
                    //Minimum salary of employees
                    string spMinimum = "dbo.SpMinOperation";
                    command = new SqlCommand(spMinimum, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        BasicPay = dr.GetDouble(0);
                        Console.WriteLine($"Minimum Salary of Employees is : " + BasicPay);
                    }
                    dr.Close();
                    //Maximum salary of employees
                    string spMaximum = "dbo.SpMaxOperation";
                    command = new SqlCommand(spMaximum, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        BasicPay = dr.GetDouble(0);
                        Console.WriteLine($"Maximum Salary of Employees is : " + BasicPay);
                    }
                    dr.Close();
                    //Count Number of male employees
                    string spCount = "dbo.SpCountOperation";
                    command = new SqlCommand(spCount, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        int countMale = dr.GetInt32(0);
                        Console.WriteLine($"Number of Male Employees : " + countMale);
                    }
                    dr.Close();
                    //Count Number of Female employees
                    string spCountFemale = "dbo.SpCountFemaleOperation";
                    command = new SqlCommand(spCountFemale, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        int countFemale = dr.GetInt32(0);
                        Console.WriteLine($"Number of Female Employees : " + countFemale);
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// performs data addition to database
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool AddData(Employee employee)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string spName = "dbo.SpAddEmployeeData";
                    SqlCommand command = new SqlCommand(spName, connection);
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                    command.Parameters.AddWithValue("@StartingDate", employee.StartingDate);
                    command.Parameters.AddWithValue("@Gender", employee.Gender);
                    command.Parameters.AddWithValue("@Department", employee.Department);
                    command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                    command.Parameters.AddWithValue("@Basic_Pay", employee.BasicPay);
                    command.Parameters.AddWithValue("@Address", employee.Address);
                    command.Parameters.AddWithValue("@Deductions", employee.Deductions);
                    command.Parameters.AddWithValue("@Taxable_Pay", employee.TaxablePay);
                    command.Parameters.AddWithValue("@Tax", employee.Tax);
                    command.Parameters.AddWithValue("@Net_Pay", employee.NetPay);
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                        return true;
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Ability to add multiple Employees to database, returns true on successful insertion.
        /// </summary>
        /// <param name="employeeList">list of employees</param>
        /// <returns></returns>
        public bool AddData(List<Employee> employeeList)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                if (employeeList.Count == 0)
                {
                    Console.WriteLine("Employee List is empty");
                    return false;
                }
                int result = 0;
                connection.Open();
                using (connection)
                {
                    string spName = "dbo.SpAddEmployeeData";
                    foreach (Employee employee in employeeList)
                    {
                        SqlCommand command = new SqlCommand(spName, connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                        command.Parameters.AddWithValue("@StartingDate", employee.StartingDate);
                        command.Parameters.AddWithValue("@Gender", employee.Gender);
                        command.Parameters.AddWithValue("@Department", employee.Department);
                        command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                        command.Parameters.AddWithValue("@Basic_Pay", employee.BasicPay);
                        command.Parameters.AddWithValue("@Address", employee.Address);
                        command.Parameters.AddWithValue("@Deductions", employee.Deductions);
                        command.Parameters.AddWithValue("@Taxable_Pay", employee.TaxablePay);
                        command.Parameters.AddWithValue("@Tax", employee.Tax);
                        command.Parameters.AddWithValue("@Net_Pay", employee.NetPay);
                        result = command.ExecuteNonQuery();
                    }
                }
                if (result != 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


        /// <summary>
        /// retrieve salary of a employee from database.
        /// </summary>
        /// <param name="name">name of the employee</param>
        public void RetrieveSalary(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    string spName = "dbo.SpRetrieveSalary";
                    SqlCommand command = new SqlCommand(spName, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", name);
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        BasicPay = dr.GetDouble(0);
                        Console.WriteLine($"Salary of {name} is : " + BasicPay);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// ability to update the basic pay of employee present in the database.
        /// </summary>
        /// <param name="name">name of the employee</param>
        /// <param name="salary">salary to be updated</param>
        public bool UpdateSalary(string name, double salary)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    string spName = "dbo.SpUpdateSalary";
                    SqlCommand command = new SqlCommand(spName, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", name);
                    command.Parameters.AddWithValue("@Salary", salary);
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        BasicPay = dr.GetDouble(0);
                        Console.WriteLine($"Updated Salary of {name} is : " + BasicPay);
                    }
                    if (dr != null)
                        return true;
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
    }
}
