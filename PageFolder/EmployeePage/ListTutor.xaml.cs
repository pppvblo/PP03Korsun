using PP03Korsun.ClassFolder;
using PP03Korsun.DataFolder;
using PP03Korsun.PageFolder.AdminPage;
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

namespace PP03Korsun.PageFolder.EmployeePage
{
    /// <summary>
    /// Логика взаимодействия для ListTutor.xaml
    /// </summary>
    public partial class ListTutor : Page
    {
        public ListTutor()
        {
            InitializeComponent();
            ListTutorLB.ItemsSource = DBEntities.GetContext().Tutor.ToList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListTutorLB.ItemsSource = DBEntities.GetContext().Tutor.Where(
                    u => u.LastNameTutor.StartsWith(SearchTb.Text) ||
                    u.FirstNameTutor.StartsWith(SearchTb.Text)).ToList();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void EditUserMI_Click(object sender, RoutedEventArgs e)
        {
            Tutor tutor = ListTutorLB.SelectedItem as Tutor;
            VariableClass.IdTutor = tutor.IdTutor;
            NavigationService.Navigate(new EditTutor(ListTutorLB.SelectedItem as Tutor));
        }

        private void DeleteUserMI_Click(object sender, RoutedEventArgs e)
        {

            Tutor tutor = ListTutorLB.SelectedItem as Tutor;

            if (MBClass.QuestionMB($"Удалить куратора с ФИО: \n" +
            $"{tutor.LastNameTutor} {tutor.FirstNameTutor} {tutor.MiddleNameTutor}?"))
            {
                DBEntities.GetContext().Tutor.Remove(ListTutorLB.SelectedItem as Tutor);

                DBEntities.GetContext().SaveChanges();
                ListTutorLB.ItemsSource = DBEntities.GetContext().Tutor.ToList().OrderBy(u => u.LastNameTutor);


                //try
                //{
                //    Tutor tutor = ListTutorLB.SelectedItem as Tutor;
                //    if (MBClass.QuestionMB($"Вы действительно хотите" +
                //        $" удалить куратора " +
                //        $"{tutor.LastNameTutor}")) 
                //    {
                //        DBEntities.GetContext().Tutor.Remove(ListTutorLB.SelectedItem as Tutor);
                //        DBEntities.GetContext().SaveChanges();
                //        //ListTutorLB.ItemsSource = DBEntities.GetContext().Tutor
                //        //.Where(u => u.IdTutor == 1).ToList().OrderBy(u => u.LastNameTutor);
                //        //ListTutorLB.ItemsSource = DBEntities.GetContext().Tutor.ToList();
                //    }
                //}
                //catch (Exception ex)
                //{

                //    MBClass.ErrorMB(ex);
                //}
            }
        }
    }
}
