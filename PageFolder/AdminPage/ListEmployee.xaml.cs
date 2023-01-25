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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PP03Korsun.PageFolder.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для ListEmployee.xaml
    /// </summary>
    public partial class ListEmployee : Page
    {
        public ListEmployee()
        {
            InitializeComponent();
            ListUserLB.ItemsSource = DBEntities.GetContext().User.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListUserLB.ItemsSource = DBEntities.GetContext().User.Where(
                    u => u.Login.StartsWith(SearchTb.Text) || 
                    u.Password.StartsWith(SearchTb.Text)).ToList();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void EditUserMI_Click(object sender, RoutedEventArgs e)
        {

            User user = ListUserLB.SelectedItem as User;
            VariableClass.IdUser = user.IdUser;
            NavigationService.Navigate(new EditEmployee(ListUserLB.SelectedItem as User));
        }

        private void DeleteUserMI_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = ListUserLB.SelectedItem as User;
                if (MBClass.QuestionMB($"Вы действительно хотите" +
                    $" удалить пользователя " +
                    $"{user.Login}"))
                {
                    DBEntities.GetContext().User.Remove(ListUserLB.SelectedItem as User);

                    DBEntities.GetContext().SaveChanges();

                    ListUserLB.ItemsSource = DBEntities.GetContext().User.ToList();
                }
            }
            catch (Exception ex)
            {

                MBClass.ErrorMB(ex);
            }
        }
    }
}
