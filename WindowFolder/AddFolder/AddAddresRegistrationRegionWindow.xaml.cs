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
    /// Логика взаимодействия для AddAddresRegistrationRegionWindow.xaml
    /// </summary>
    public partial class AddAddresRegistrationRegionWindow : Window
    {
        public AddAddresRegistrationRegionWindow()
        {
            InitializeComponent();
        }

        private void BackAddresRegistrationRegionBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void AddAddresRegistrationRegionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AddAddresRegistrationRegionTB.Text))
            {
                MBClass.ErrorMB("Поле осталось пустым");
                AddAddresRegistrationRegionTB.Focus();
            }
            else
            {
                try
                {
                    DBEntities.GetContext().Region.Add(new Region()
                    {
                        RegionName = AddAddresRegistrationRegionTB.Text
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Регион успешно добавлен");
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
