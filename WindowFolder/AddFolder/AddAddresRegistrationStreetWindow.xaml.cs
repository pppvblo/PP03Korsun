using PP03Korsun.ClassFolder;
using PP03Korsun.DataFolder;
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
    /// Логика взаимодействия для AddAddresRegistrationStreetWindow.xaml
    /// </summary>
    public partial class AddAddresRegistrationStreetWindow : Window
    {
        public AddAddresRegistrationStreetWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void BackAddresRegistrationStreetBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddAddresRegistrationStreetBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AddAddresRegistrationStreetTB.Text))
            {
                MBClass.ErrorMB("Поле осталось пустым");
                AddAddresRegistrationStreetTB.Focus();
            }
            else
            {
                try
                {
                    DBEntities.GetContext().Street.Add(new Street()
                    {
                        StreetName = AddAddresRegistrationStreetTB.Text
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Улица успешно добавлена");
                    Close();
                }
                catch (Exception ex)
                {

                    MBClass.ErrorMB(ex);
                }
            }
        }
    }
}
