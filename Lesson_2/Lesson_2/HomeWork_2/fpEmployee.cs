using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_2
{
    class fpEmployee : Employee
    {
        public double FSalary { get; private set; }
        public fpEmployee(string name, string sname, int number)
            :base(name, sname, number)
        {
            _Name = name;
            _sName = sname;
            _tNumber = number;
        }


        public override void SalaryCount(double salary)
        {
            FSalary = salary;
        }

        public override void Display()
        {
            Console.WriteLine($"{_Name}, {_sName}, {_tNumber}");
        }
    }
}
