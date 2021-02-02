using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HelloWPF
{
   public class Employee
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

        public override string ToString()
        {
            return String.Format("{0} {1}",Name,SName);
        }
    }
}
