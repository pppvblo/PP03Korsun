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
    /// Логика взаимодействия для AddSpecializationWindow.xaml
    /// </summary>
    public partial class AddSpecializationWindow : Window
    {
        public AddSpecializationWindow()
        {
            InitializeComponent();
        }

        private void SpealizationBackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddSpealizationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AddCypherTB.Text))
            {
                MBClass.ErrorMB("Поле осталось пустым");
                AddCypherTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(AddSpecializationNameTB.Text))
            {
                MBClass.ErrorMB("Поле осталось пустым");
                AddSpecializationNameTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(AddEducationPerionDP.Text))
            {
                MBClass.ErrorMB("Поле осталось пустым");
                AddEducationPerionDP.Focus();
            }

            else
            {
                try
                {
                    DBEntities.GetContext().Specialization.Add(new Specialization()
                    {
                        Cipher = AddCypherTB.Text,
                        SpecializationName = AddSpecializationNameTB.Text,
                        EducationPeriod = AddEducationPerionDP.Text

                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Специальность успешно добавлена");
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
