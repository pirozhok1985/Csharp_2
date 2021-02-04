using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HelloWPF.Model
{
    public class Department
    {
        public ObservableCollection<Employee> Human { get; set; } = new();
        public string DepName { get; set; }
    }
}
