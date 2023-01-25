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
    /// Логика взаимодействия для AddPlaceOfBirthRegionWindow.xaml
    /// </summary>
    public partial class AddPlaceOfBirthRegionWindow : Window
    {
        public AddPlaceOfBirthRegionWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void AddPlaceOfBirthRegionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AddPlaceOfBirthRegionTB.Text))
            {
                MBClass.ErrorMB("Поле осталось пустым");
                AddPlaceOfBirthRegionTB.Focus();
            }
            else
            {
                try
                {
                    DBEntities.GetContext().Region.Add(new Region()
                    {
                        RegionName = AddPlaceOfBirthRegionTB.Text
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

        private void BackPlaceOfBirthRegionBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
