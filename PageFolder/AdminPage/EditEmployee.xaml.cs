using System;
using System.Collections.Generic;
using PP03Korsun.ClassFolder;
using PP03Korsun.DataFolder;
using PP03Korsun.WindowFolder;
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
using System.Data.Entity.Validation;

namespace PP03Korsun.PageFolder.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Page
    {
        DataFolder.User user = new DataFolder.User();


        public EditEmployee(User user)
        {
            InitializeComponent();

            DataContext = user;
            EditRoleCB.ItemsSource = DataFolder.DBEntities.GetContext().Role.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void EdittEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EditLoginTB.Text))
            {
                MBClass.ErrorMB("Введите логин");
                EditLoginTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(EditPasswordTB.Text))
            {
                MBClass.ErrorMB("Введите пароль");
                EditPasswordTB.Focus();
            }
            else if (EditRoleCB.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Выберите роль");
                EditRoleCB.Focus();
            }
            else
            {
                try
                {
                    user = DBEntities.GetContext()
                    .User
                    .FirstOrDefault(u => u.IdUser == VariableClass.IdUser);
                    user.Login = EditLoginTB.Text;
                    user.Password = EditPasswordTB.Text;
                    user.IdRole = Int32.Parse(EditRoleCB.SelectedValue.ToString());
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Пользователь отредактирован");
                    NavigationService.Navigate(new PageFolder.AdminPage.ListEmployee());
                }
                catch (DbEntityValidationException ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
               
        }
    }
}
