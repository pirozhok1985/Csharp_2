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

namespace HelloWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Employees.ItemsSource = new List<Employee>()
            {
                new Employee("Petya", "Vasechkin", 1),
                new Employee("Vasya", "Petechkin", 2),
                new Employee("Stepa", "Ivanishin", 3)
            };
            Departments.ItemsSource = new List<Department>()
            {
                new Department("IT Department"),
                new Department("Marketing Department"),
                new Department("HR Department")
            };
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
