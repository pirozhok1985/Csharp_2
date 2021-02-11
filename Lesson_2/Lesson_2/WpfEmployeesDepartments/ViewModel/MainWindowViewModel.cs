using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Text;
using WpfEmployeesDepartments.Model;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace WpfEmployeesDepartments.ViewModel
{
    public class MainWindowViewModel
    {
        public ObservableCollection<Department> Deps { get; set; }

        public MainWindowViewModel()
        {
            Deps = dbOperations.GetDepartments();
        }
    }
}
