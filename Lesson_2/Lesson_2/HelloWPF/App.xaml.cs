using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HelloWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
      public static List<Department> Dep = new List<Department>()
        {
            new Department("IT Department"),
            new Department("Marketing Department"),
            new Department("HR Department")
        };

     public static List<Employee> Emp = new List<Employee>()
        {
            new Employee("Petya", "Vasechkin", 1),
            new Employee("Vasya", "Petechkin", 2),
            new Employee("Stepa", "Ivanishin", 3)
        };
    }
}
