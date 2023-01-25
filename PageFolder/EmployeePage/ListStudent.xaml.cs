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

namespace PP03Korsun.PageFolder.EmployeePage
{
    /// <summary>
    /// Логика взаимодействия для ListStudent.xaml
    /// </summary>
    public partial class ListStudent : Page
    {
        public ListStudent()
        {
            InitializeComponent();
            ListStudentLB.ItemsSource = DBEntities.GetContext().Student.ToList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListStudentLB.ItemsSource = DBEntities.GetContext().Student.Where(
                    u => u.LastNameStudent.StartsWith(SearchTb.Text) ||
                    u.FirstNameStudent.StartsWith(SearchTb.Text)).ToList();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void EditStudentMI_Click(object sender, RoutedEventArgs e)
        {
            Student student = ListStudentLB.SelectedItem as Student;
            VariableClass.IdStudent = student.IdStudent.ToString();
            NavigationService.Navigate(new EditStudent(ListStudentLB.SelectedItem as Student));
        }

        private void DeleteStudedntMI_Click(object sender, RoutedEventArgs e)
        {
            Student student = ListStudentLB.SelectedItem as Student;

            if (MBClass.QuestionMB($"Удалить студента с ФИО: \n" +
            $"{student.LastNameStudent} {student.FirstNameStudent} {student.MiddleNameStudent}?"))
            {
                DBEntities.GetContext().Student.Remove(ListStudentLB.SelectedItem as Student);

                DBEntities.GetContext().SaveChanges();
                ListStudentLB.ItemsSource = DBEntities.GetContext().Student.ToList().OrderBy(u => u.IdGroup);

            }
            //try
            //{
            //    Student student = ListStudentLB.SelectedItem as Student;
            //    if (MBClass.QuestionMB($"Вы действительно хотите" +
            //        $" удалить куратора " +
            //        $"{student.LastNameStudent}"))
            //    {
            //        DBEntities.GetContext().Student.Remove(ListStudentLB.SelectedItem as Student);
            //        DBEntities.GetContext().SaveChanges();
            //        ListStudentLB.ItemsSource = DBEntities.GetContext().Student
            //        .Where(u => u.IdStudent == 1).ToList().OrderBy(u => u.LastNameStudent);
            //        ListStudentLB.ItemsSource = DBEntities.GetContext().Student.ToList();
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MBClass.ErrorMB(ex);
            //}
        }

        private void InfoStudent_Click(object sender, RoutedEventArgs e)
        {
            Student student = ListStudentLB.SelectedItem as Student;
            VariableClass.IdStudent = student.IdStudent.ToString();
            NavigationService.Navigate(new InfoStudent(ListStudentLB.SelectedItem as Student));
        }
    }
}
