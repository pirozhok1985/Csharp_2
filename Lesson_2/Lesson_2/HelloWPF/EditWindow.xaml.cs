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
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public EditWindow()
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
           MainWindow.__emp.AddToDepartment(__dep);
           Console.WriteLine();
        }

        private void Departments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var obj = (Department)Departments.SelectedItem;
            __dep = obj;
        }
    }
}
