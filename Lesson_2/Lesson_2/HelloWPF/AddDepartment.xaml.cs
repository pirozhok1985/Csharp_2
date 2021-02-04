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
using HelloWPF.Model;
using HelloWPF.ViewModel;

namespace HelloWPF
{
    /// <summary>
    /// Interaction logic for AddDepartment.xaml
    /// </summary>
    public partial class AddDepartment : Window
    {
        public AddDepartment()
        {
            InitializeComponent();
        }

        private void BCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bOk_Click(object sender, RoutedEventArgs e)
        {
            var dataModel = (MainWindowViewModel)DataContext;
            dataModel._Dep.Add(new Department
            {
                DepName = Dep.ToString(),
                //Human = 
            });
        }
    }
}
