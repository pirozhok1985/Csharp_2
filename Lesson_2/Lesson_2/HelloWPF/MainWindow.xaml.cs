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
            Employees.ItemsSource = App.Emp;
        }
        public static Employee __emp;
        private void Employees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var obj = (Employee)Employees.SelectedItem;
            __emp = obj;
        }

        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bOk_Click(object sender, RoutedEventArgs e)
        {
            EditWindow editWindow = new EditWindow();
            editWindow.Show();
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Show();
        }
    }
}
