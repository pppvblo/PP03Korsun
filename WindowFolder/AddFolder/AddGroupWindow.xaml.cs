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
    /// Логика взаимодействия для AddGroupWindow.xaml
    /// </summary>
    public partial class AddGroupWindow : Window
    {
        public AddGroupWindow()
        {
            InitializeComponent();
            IdTutor.ItemsSource = DBEntities.GetContext().Tutor.ToList();
            IdSpecialization.ItemsSource = DBEntities.GetContext().Specialization.ToList();
        }

        private void BackAddGroupBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void AddGroupBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AddGroupTB.Text))
            {
                MBClass.ErrorMB("Поле осталось пустым");
                AddGroupTB.Focus();
            }
            else if (IdTutor.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Поле осталось пустым");
                AddGroupTB.Focus();
            }
            else if (IdSpecialization.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Поле осталось пустым");
                AddGroupTB.Focus();
            }

            else
            {
                try
                {
                    DBEntities.GetContext().Group.Add(new Group()
                    {
                        GroupName = AddGroupTB.Text,
                        IdTutor = Int32.Parse(IdTutor.SelectedValue.ToString()),
                        IdSpecialization = Int32.Parse(IdSpecialization.SelectedValue.ToString())
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
        private void AddSpecialixation_Click(object sender, RoutedEventArgs e)
        {
            new AddSpecializationWindow().ShowDialog();
            IdSpecialization.ItemsSource = DBEntities.GetContext().Specialization.ToList();
        }
    }
}
