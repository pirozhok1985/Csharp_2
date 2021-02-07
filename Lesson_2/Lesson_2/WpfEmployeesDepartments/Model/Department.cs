using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WpfEmployeesDepartments.Model
{
   public class Department
    {
        public ObservableCollection<Employee> Emp { get; set; }
        public string Name { get; set; }
    }
}
