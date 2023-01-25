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

namespace PP03Korsun.WindowFolder.AddFolder
{
    /// <summary>
    /// Логика взаимодействия для AddStatusWindow.xaml
    /// </summary>
    public partial class AddStatusWindow : Window
    {
        public AddStatusWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void BackAddStatusBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddStatusBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
