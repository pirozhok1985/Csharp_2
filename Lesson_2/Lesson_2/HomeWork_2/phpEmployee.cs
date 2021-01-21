using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_2
{
    class phpEmployee : Employee
    {
        public double PhSalary { get; private set; }
        public double PerHourPayment { get; private set; }
        public phpEmployee(string name, string sname, int number, double payment)
            : base(name, sname, number)
        {
            _Name = name;
            _sName = sname;
            _tNumber = number;
            PerHourPayment = payment;
        }

        public override void SalaryCount(double salary)
        {
            PhSalary = 20.8 * 8 * PerHourPayment;
        }

        public override void Display()
        {
            Console.WriteLine($"{_Name}, {_sName}, {_tNumber}");
        }
    }
}
