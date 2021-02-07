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

namespace WpfEmployeesDepartments
{
    /// <summary>
    /// Interaction logic for AddDepWindow.xaml
    /// </summary>
    public partial class AddDepWindow : Window
    {
        public AddDepWindow()
        {
            InitializeComponent();
        }

        private void BExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BOk_Click(object sender, RoutedEventArgs e)
        {
            var data = (MainWindowViewModel)DataContext;
            data.Deps.Add(new Department(TDepName.Text));
            this.Close();
        }
    }
}
