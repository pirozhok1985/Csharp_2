using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_2
{
    abstract class Employee : IComparable
    {
        protected string _Name;
        protected string _sName;
        protected int _tNumber;

        protected Employee(string name, string sname, int number)
        {
            _Name = name;
            _sName = sname;
            _tNumber = number;
        }

        public int CompareTo(object obj)
        {
            Employee emp = obj as Employee;
            if (emp != null)
            {
                return this._sName.CompareTo(emp._sName);
            }
            throw new ArgumentNullException();
        }

        public abstract void SalaryCount(double salary);
        public abstract void Display();
    }
}
