﻿using System;
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
using HelloWPF.Model;
using HelloWPF.ViewModel;

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

        private void BAdd_OnClick(object sender, RoutedEventArgs e)
        {
            AddDepartment add = new AddDepartment();
             add.Show();
        }

        private void bRemove_Click(object sender, RoutedEventArgs e)
        {
            var dataModel = (MainWindowViewModel)DataContext;
            var Dep = (Department)Departments.SelectedItem;
            
            if(Dep is null) return;

            dataModel._Dep.Remove(Dep);
        }
    }
}
