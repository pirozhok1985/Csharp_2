using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WpfEmployeesDepartments.Model;

namespace WpfEmployeesDepartments.ViewModel
{
    public class MainWindowViewModel
    {
        public ObservableCollection<Department> Deps { get; set; }

        public MainWindowViewModel()
        {
            Deps = new ObservableCollection<Department>
            {
                new Department
                {
                    Name = "Кадры",
                    Emp = new ObservableCollection<Employee>
                    {
                        new Employee("Петя", "Васечкин", 1, 15000),
                        new Employee("Вася", "Пупкин", 2, 16000),
                        new Employee("Лёша", "Мыльников", 3, 14000)
                    }
                },
                new Department
                {
                    Name = "ИТ",
                    Emp = new ObservableCollection<Employee>
                    {
                        new Employee("Лёня", "Иванов", 3, 25000),
                        new Employee("Миша", "Мозгин", 4, 26000),
                        new Employee("Женя", "Анисимов", 5, 25000)
                    }
                },
                new Department
                {
                    Name = "Бухгалтерия",
                    Emp = new ObservableCollection<Employee>
                    {
                        new Employee("Лена", "Пеплова", 6, 35000),
                        new Employee("Марина", "Поленова", 7, 36000),
                        new Employee("Вика", "Болтунова", 8, 30000)
                    }
                }
            };
        }
    }
}
