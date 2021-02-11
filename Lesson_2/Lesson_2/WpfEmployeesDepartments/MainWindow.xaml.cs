using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfEmployeesDepartments.Model;
using WpfEmployeesDepartments.ViewModel;

namespace WpfEmployeesDepartments
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bRemove_Click(object sender, RoutedEventArgs e)
        {
            var data = (MainWindowViewModel)DataContext;
            if(Departments.SelectedItem is Department dep)
            {
                if (Employees.SelectedItem is Employee emp)
                {
                    dep.Emp.Remove(emp);
                    dbOperations.RemoveEmployee(emp);
                    return;
                }

                data.Deps.Remove(dep);
                dbOperations.RemoveDepartment(dep);
            }
            return;
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            var data = (MainWindowViewModel)DataContext;
            if (Departments.SelectedItem is Department dep)
            {
                Employee item = new Employee("имя", "фамилия", 0, 0);
                dep.Emp.Add(item);
                dbOperations.InsertEmployee(item,dep);
                return;
            }
            data.Deps.Add(new Department("Новый отдел"));
            dbOperations.InsertDepartment(new Department("Новый отдел")); //Кодировка
            return;
        }

        private void Departments_KeyDown(object sender, KeyEventArgs e)
        {
            Departments.SelectedItem = null;
        }
    }
}
