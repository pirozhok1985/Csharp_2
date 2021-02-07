using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace WpfEmployeesDepartments.Model
{
    public class Employee
    {
        public string Name { get; set; }
        public string SName { get; set; }
        public int Id { get; set; }
        public double Salary { get; set; }

        public Employee(string name, string sname, int id, double salary)
        {
            Name = name;
            SName = sname;
            Id = id;
            Salary = salary;
        }
    }
}
