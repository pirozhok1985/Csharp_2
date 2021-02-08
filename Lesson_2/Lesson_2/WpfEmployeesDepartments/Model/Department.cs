using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WpfEmployeesDepartments.Model
{
   public class Department : INotifyPropertyChanged
    {
        private string _Name;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Employee> Emp { get; set; }

        public string Name
        {
            get => _Name;
            set
            {
                _Name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public Department()
        {
            
        }

        public Department(string name)
        {
            Name = name;
            Emp = new ObservableCollection<Employee>();
        }
    }
}
