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
using System.Windows.Shapes;
using WpfEmployeesDepartments.Model;
using WpfEmployeesDepartments.ViewModel;
using System.Globalization;

namespace WpfEmployeesDepartments
{
    /// <summary>
    /// Interaction logic for AddEmpWindow.xaml
    /// </summary>
    public partial class AddEmpWindow : Window
    {
        public AddEmpWindow()
        {
            InitializeComponent();
        }

        private void bExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bOk_Click(object sender, RoutedEventArgs e)
        {
            var data = (MainWindowViewModel)DataContext;
            var dep = data.Deps.First(d => d.Name == this.Name);
            dep.Emp.Add(new Employee(TName.Text,TSName.Text,Convert.ToInt32(TId.Text),Convert.ToDouble(TSalary.Text)));
            this.Close();
        }
    }
}
