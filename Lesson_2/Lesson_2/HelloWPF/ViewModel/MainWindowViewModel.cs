using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using HelloWPF.Model;

namespace HelloWPF.ViewModel
{
    class MainWindowViewModel
    {
        public List<Department> _Dep { get; set;}

        public MainWindowViewModel()
        {
            var i = 1;
            _Dep = Enumerable.Range(1, 5).Select(d => new Department
            {
                DepName = $"Department - {d}",
                Human = new(Enumerable.Range(1,5).Select(h =>new Employee
                {
                    Name = $"Name - {i}",
                    SName = $"SName - {i}",
                    Id = i++
                }))
            }).ToList();
        }
    }
}
