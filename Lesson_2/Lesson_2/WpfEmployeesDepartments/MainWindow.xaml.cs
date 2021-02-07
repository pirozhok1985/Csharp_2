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

        private void bOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            var data = (MainWindowViewModel)DataContext;
            if(Departments.SelectedItem is Department dep)
            {
                if (Employees.SelectedItem is Employee emp)
                {
                    dep.Emp.Remove(emp);
                    return;
                }

                data.Deps.Remove(dep);
            }
            return;
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            var data = (MainWindowViewModel)DataContext;
            if (Departments.SelectedItem is Department dep)
            {
                var empWindow = new AddEmpWindow();
                empWindow.Name = dep.Name;
                empWindow.Show();
            }
            else
            {
                var depWindow = new AddDepWindow();
                depWindow.Show();
            }
        }

        private void bEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
