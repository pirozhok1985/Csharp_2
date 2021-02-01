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
        }

        private Department itDep = new Department("IT Department");
        private Department mDep = new Department("Marketing Department");
        private Department hrDep = new Department("HR Department");

        private Employee emp1 = new Employee("Petya", "Vasechkin", 1);
        private Employee emp2 = new Employee("Vasya", "Petechkin", 2);
        private Employee emp3 = new Employee("Stepa", "Ivanishin", 3);
    }
}
