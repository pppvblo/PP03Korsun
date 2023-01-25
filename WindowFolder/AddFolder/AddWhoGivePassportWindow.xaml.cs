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
    /// Логика взаимодействия для AddWhoGivePassportWindow.xaml
    /// </summary>
    public partial class AddWhoGivePassportWindow : Window
    {
        public AddWhoGivePassportWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void AddWhoGivePassportBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AddOrganNameTB.Text))
            {
                MBClass.ErrorMB("Поле осталось пустым");
                AddOrganNameTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(AddCodeUnitTB.Text))
            {
                MBClass.ErrorMB("Поле осталось пустым");
                AddCodeUnitTB.Focus();
            }

            else
            {
                try
                {
                    DBEntities.GetContext().WhoGivePassport.Add(new WhoGivePassport()
                    {
                        DivisionCode = AddCodeUnitTB.Text,
                        WhoGivePassportName = AddOrganNameTB.Text,
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Группа успешно добавлена");
                    Close();
                }
                catch (Exception ex)
                {

                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void BackWhoGivePassportBackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
