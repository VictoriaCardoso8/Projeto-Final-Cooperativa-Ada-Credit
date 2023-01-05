using Ada_Credit.Entities;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using System.Globalization;
using CsvHelper.Configuration.Attributes;
using Bogus;
using CsvHelper.Configuration;

namespace Ada_Credit.Repositories
{
    internal class EmployeeRepositories
    {
        public static List<Employee> ListOfEmployees = new List<Employee>();

        public static void AddEmployee(Employee employee)
        {
            TryEmployee(employee);
            var path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory)));
            var csvPath = Path.Combine(path, "EmployeeList.csv");
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(csvPath, true))
            {
                file.WriteLine(employee.NameEmp + "," + employee.loginEmp + "," + employee.passwordEmp);
            }
        }
        public static void TryEmployee(Employee employee)
        {
            if (ListOfEmployees.Any(x => x.loginEmp.Equals(employee.loginEmp)))
            {
                Console.WriteLine("Login já cadastrado");

            }
            else
                ListOfEmployees.Add(employee);
        }
        public static void UpdateEmployeeList()
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            var path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory)));
            var csvPath = Path.Combine(path, "EmployeeList.csv");
            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader, configuration))
            {
                var records = csv.GetRecords<Employee>();
                ListOfEmployees.AddRange(records);
            }
        }


    }
}
