using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HelloWPF
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
            Departments.ItemsSource = App.Dep;
        }

        private static Department __dep;

        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bOK_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(id.Text, out int Id);
            Employee emp = new Employee(name.Text, sname.Text, Id);
            emp.AddToDepartment(__dep);
            App.Emp.Add(emp);
            this.Close();
        }

        private void department_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var obj = (Department)Departments.SelectedItem;
            __dep = obj;
        }
    }
}
