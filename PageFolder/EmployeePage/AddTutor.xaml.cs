using Microsoft.Win32;
using PP03Korsun.ClassFolder;
using PP03Korsun.DataFolder;
using PP03Korsun.WindowFolder;
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
    /// Логика взаимодействия для AddTutor.xaml
    /// </summary>
    public partial class AddTutor : Page
    {
        Tutor tutor = new Tutor();
        public AddTutor()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void AddStudentBtn_Click(object sender, RoutedEventArgs e)
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
                    DBEntities.GetContext().Tutor.Add(new Tutor()
                    {
                        LastNameTutor = LastNameTB.Text,
                        FirstNameTutor = MiddleNameTB.Text,
                        MiddleNameTutor = MiddleNameTB.Text,
                        PhoneNumber = NumberPhoneTB.Text,
                        Email = EmailTB.Text,
                        DateOfBirth = DateTime.Parse(DateOfBirth.Text),
                        PhotoTutor = ImageClass.ConvertImageToByteArray(selectedFileName)                       
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Пользователь успешно добавлен");
                    NavigationService.Navigate(new PageFolder.EmployeePage.ListTutor());
                }
                catch (Exception ex)
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
                    AddImage.Source = ImageClass.ConvertByteArrayToImage(tutor.PhotoTutor);
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
