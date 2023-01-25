using Microsoft.Win32;
using PP03Korsun.ClassFolder;
using PP03Korsun.DataFolder;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PP03Korsun.PageFolder.EmployeePage
{
    /// <summary>
    /// Логика взаимодействия для EditTutor.xaml
    /// </summary>
    public partial class EditTutor : Page
    {
        DataFolder.Tutor tutor = new DataFolder.Tutor();
        public EditTutor(Tutor tutor)
        {
            InitializeComponent();
            DataContext = tutor;
            DateOfBirth.Text = tutor.DateOfBirth.ToString();
        }

        private void EditTutorBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FirstNameTB.Text))
            {
                MBClass.ErrorMB("Введите логин");
                FirstNameTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(LastNameTB.Text))
            {
                MBClass.ErrorMB("Введите пароль");
                LastNameTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(MiddleNameTB.Text))
            {
                MBClass.ErrorMB("Введите пароль");
                MiddleNameTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(EmailTB.Text))
            {
                MBClass.ErrorMB("Введите пароль");
                EmailTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(NumberPhoneTB.Text))
            {
                MBClass.ErrorMB("Введите пароль");
                NumberPhoneTB.Focus();
            }
            else
            {
                try
                {
                    tutor = DBEntities.GetContext()
                    .Tutor
                    .FirstOrDefault(u => u.IdTutor == VariableClass.IdTutor);
                    tutor.LastNameTutor = LastNameTB.Text;
                    tutor.FirstNameTutor = FirstNameTB.Text;
                    tutor.MiddleNameTutor = MiddleNameTB.Text;
                    tutor.PhoneNumber = NumberPhoneTB.Text;
                    tutor.Email = EmailTB.Text;
                    tutor.DateOfBirth = DateTime.Parse(DateOfBirth.Text);
                    tutor.PhotoTutor = ImageClass.ConvertImageToByteArray(selectedFileName);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Куратор отредактирован");
                    NavigationService.Navigate(new PageFolder.EmployeePage.ListTutor());
                }
                catch (DbEntityValidationException ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        string selectedFileName = "";
        private void photo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.InitialDirectory = "";
                op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                    "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                    "Portable Network Graphic (*.png)|*.png";

                if (op.ShowDialog() == true)
                {
                    selectedFileName = op.FileName;
                    tutor.PhotoTutor = ImageClass.ConvertImageToByteArray(selectedFileName);
                    ImageTutor.Source = ImageClass.ConvertByteArrayToImage(tutor.PhotoTutor);
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
