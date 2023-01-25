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
    /// Логика взаимодействия для AddPlaceOfBirthCityWindow.xaml
    /// </summary>
    public partial class AddPlaceOfBirthCityWindow : Window
    {
        public AddPlaceOfBirthCityWindow()
        {
            InitializeComponent();
        }

        private void BackAddresRegistrationCityBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddAddresRegistrationCityBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AddAddresRegistrationCityTB.Text))
            {
                MBClass.ErrorMB("Поле осталось пустым");
                AddAddresRegistrationCityTB.Focus();
            }
            else
            {
                try
                {
                    DBEntities.GetContext().City.Add(new City()
                    {
                        CityName = AddAddresRegistrationCityTB.Text
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Город успешно добавлен");
                    Close();
                }
                catch (Exception ex)
                {

                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
