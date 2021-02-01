using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HelloWPF
{
    public class Department : IEnumerable
    {
        public List<Employee> Dep { get; set; }
        public string DepName { get; set; }

        public Department(string name)
        {
            Dep = new List<Employee>();
            DepName = name;
        }

        public Employee this[int index]
        {
            get
            {
                return Dep[index];
            }

            set
            {
                Dep[index] = value;
            }

        }

        public void AddEmployee(Employee emp)
        {
            Dep.Add(emp);
            emp.Department = DepName;
        }

        public IEnumerator GetEnumerator()
        {
            return Dep.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Format($"{DepName}");
        }
    }
}
