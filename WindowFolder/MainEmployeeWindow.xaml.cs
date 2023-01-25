using PP03Korsun.ClassFolder;
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

namespace PP03Korsun.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для MainEmployeeWindow.xaml
    /// </summary>
    public partial class MainEmployeeWindow : Window
    {
        public MainEmployeeWindow()
        {
            InitializeComponent();
        }

        private void ListStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrameEmployee.Navigate(new PageFolder.EmployeePage.ListStudent());
        }

        private void AddStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrameEmployee.Navigate(new PageFolder.EmployeePage.AddStudent());
        }

        private void CloseBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ExitBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void ListTutorBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrameEmployee.Navigate(new PageFolder.EmployeePage.ListTutor());
        }

        private void AddTutorBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrameEmployee.Navigate(new PageFolder.EmployeePage.AddTutor());
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
