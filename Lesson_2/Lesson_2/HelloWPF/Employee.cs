using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HelloWPF
{
    class Employee
    {
        public string Name { get;}
        public string SName { get;}
        public int Id { get;}
        public string Department { get; set; }

        public Employee(string name, string sname, int id)
        {
            Name = name;
            SName = sname;
            Id = id;
        }

        public void AddToDepartment(Department dep)
        {
            Department = dep.DepName;
            dep.AddEmployee(this);
        }
    }
}
