using Microsoft.Win32;
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
    /// Логика взаимодействия для EditStudent.xaml
    /// </summary>
    public partial class EditStudent : Page
    {
        DataFolder.Student student = new DataFolder.Student();
        //DataFolder.Address address = new DataFolder.Address();
        Address address = new Address();
        Address addressReg = new Address();

        public EditStudent(Student student)
        {
            InitializeComponent();
            DataContext = student;
            var studAddressReg = DBEntities.GetContext().Student.FirstOrDefault(a => a.IdStudent == student.IdStudent);
            this.student.IdAddressRegistration = studAddressReg.IdAddressRegistration;
            WhoGivePassportCB.ItemsSource = DBEntities.GetContext().WhoGivePassport.ToList();
            PlaceOfBirthRegionCB.ItemsSource = DBEntities.GetContext().Region.ToList();
            PlaceOfBirthCityCB.ItemsSource = DBEntities.GetContext().City.ToList();
            AddresRegistrationRegionCB.ItemsSource = DBEntities.GetContext().Region.ToList();
            AddresRegistrationCityCB.ItemsSource = DBEntities.GetContext().City.ToList();
            AddresRegistrationStreetCB.ItemsSource = DBEntities.GetContext().Street.ToList();
            GroupCB.ItemsSource = DBEntities.GetContext().Group.ToList();
            StatusCB.ItemsSource = DBEntities.GetContext().Status.ToList();
            DateOfBirth.Text = student.DateOfBirth.ToString();
            DateWhoGivePassport.Text = student.DateWhoGivePassport.ToString();
            DateEducationStart.Text = student.DateEducationStart.ToString();
            DateEducationEnd.Text = student.DateEducationEnd.ToString();
            LoadAddress();

        }

        private void LoadAddress()
        {
            var address = DBEntities.GetContext().Address.FirstOrDefault(a => a.IdAddress == student.IdAddressRegistration);
            MessageBox.Show($"Редактирование студента Id" +
                $"{student.IdAddressRegistration}");
            AddresRegistrationRegionCB.Text = address.Region.RegionName;
            AddresRegistrationCityCB.Text = address.City.CityName;
            AddresRegistrationStreetCB.Text = address.Street.StreetName;
            AddresRegistrationHouseTB.Text = address.House;
            AddresRegistrationFrameTB.Text = address.Frame;
            AddresRegistrationFlatTB.Text = address.Flat;
        }


        private void OneBorder_Click(object sender, RoutedEventArgs e)
        {
            FirstBorder.Visibility = Visibility.Visible;
            SecondBorder.Visibility = Visibility.Hidden;
            TwoBorder.Visibility = Visibility.Visible;
            OneBorder.Visibility = Visibility.Hidden;
        }

        private void TwoBorder_Click(object sender, RoutedEventArgs e)
        {
            FirstBorder.Visibility = Visibility.Hidden;
            SecondBorder.Visibility = Visibility.Visible;
            TwoBorder.Visibility = Visibility.Hidden;
            OneBorder.Visibility = Visibility.Visible;
        }

        private void StudentEdit()
        {
            //    var studentEdit = new Student()
            //    {
            //        student = DBEntities.GetContext()
            //            .Student
            //            .FirstOrDefault(u => u.IdStudent == VariableClass.IdStudent);
            //    student.LastNameStudent = LastNameTB.Text;
            //    student.FirstNameStudent = FirstNameTB.Text;
            //    student.MiddleNameStudent = MiddleNameTB.Text;
            //    student.DateOfBirth = DateTime.Parse(DateOfBirth.Text);
            //    student.Email = EmailTB.Text;
            //    student.PhoneNumber = NumberPhoneTB.Text;
            //    student.PassportSeria = PassportSeriaTB.Text;
            //    student.PassportNumber = PassportNumberTB.Text;
            //    student.IdWhoGivePassport = Int32.Parse(WhoGivePassportCB.SelectedValue.ToString());
            //    student.DateWhoGivePassport = DateTime.Parse(DateWhoGivePassport.Text);
            //    student.IdPlaceOfBirth = address.IdAddress;
            //    student.IdAddressRegistration = addressReg.IdAddress;
            //    student.IdGroup = Int32.Parse(GroupCB.SelectedValue.ToString());
            //    student.INN = INNTB.Text;
            //    student.SNILS = SNILSTB.Text;
            //    student.OMS = NumberOMSTB.Text;
            //    student.DateEducationStart = DateTime.Parse(DateEducationStart.Text);
            //    student.DateEducationEnd = DateTime.Parse(DateEducationEnd.Text);
            //    student.IdStatus = Int32.Parse(StatusCB.SelectedValue.ToString());
            //    student.OrderNumber = OrderTB.Text;
            //    student.PhotoStudent = ImageClass.ConvertImageToByteArray(selectedFileName);
            //};
            //DBEntities.GetContext().SaveChanges();
            //student.IdStudent = studentEdit.IdStudent;
        }
        private void AddPlaceOfBirth()
        {
            //var placeOfBirthEdit = new Address()
            //{
            //    addressReg = DBEntities.GetContext().Address.FirstOrDefault(u => u.IdAddress == VariableClass.IdAddressRegistration);
            //    addres.IdRegion = Int32.Parse(PlaceOfBirthRegionCB.SelectedValue.ToString()),
            //    addres.IdCity = Int32.Parse(PlaceOfBirthCityCB.SelectedValue.ToString())
            //    DBEntities.GetContext().SaveChanges();
            //    address.IdAddress = placeOfBirthEdit.IdAddress;
            //};

        }
        private void AddAddressRegistration()
        {
            //var addressRegistrationEdit = new Address()
            //{
            //    addressReg = DBEntities.GetContext().Address.FirstOrDefault(u => u.IdAddress == VariableClass.IdAddressRegistration);
            //addressReg.IdRegion = Int32.Parse(AddresRegistrationRegionCB.SelectedValue.ToString()),
            //    addressReg.IdCity = Int32.Parse(AddresRegistrationCityCB.SelectedValue.ToString()),
            //    addressReg.IdStreet = Int32.Parse(AddresRegistrationStreetCB.SelectedValue.ToString()),
            //    addressReg.House = AddresRegistrationHouseTB.Text,
            //    addressReg.Frame = AddresRegistrationFrameTB.Text,
            //    addressReg.Flat = AddresRegistrationFlatTB.Text
            //    DBEntities.GetContext().SaveChanges();
            //    addressReg.IdAddress = addressRegistrationEdit.IdAddress;
            //};

        }

        string selectedFileName = "";
        private void EditPhoto()
        {
            try
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
                        student.PhotoStudent = ImageClass.ConvertImageToByteArray(selectedFileName);
                        ImageStudent.Source = ImageClass.ConvertByteArrayToImage(student.PhotoStudent);
                    }
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void photo_Click(object sender, RoutedEventArgs e)
        {
            EditPhoto();
        }

        private void EditStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    student = DBEntities.GetContext().Student.FirstOrDefault(u => u.IdStudent == VariableClass.IdStudent);
            //    student.LastNameStudent = LastNameTB.Text;
            //    student.FirstNameStudent = FirstNameTB.Text;
            //    student.MiddleNameStudent = MiddleNameTB.Text;
            //    student.DateOfBirth = DateTime.Parse(DateOfBirth.Text);
            //    student.Email = EmailTB.Text;
            //    student.PhoneNumber = NumberPhoneTB.Text;
            //    student.PassportSeria = PassportSeriaTB.Text;
            //    student.PassportNumber = PassportNumberTB.Text;
            //    student.IdWhoGivePassport = Int32.Parse(WhoGivePassportCB.SelectedValue.ToString());
            //    student.DateWhoGivePassport = DateTime.Parse(DateWhoGivePassport.Text);
            //    student.IdPlaceOfBirth = address.IdAddress;
            //    student.IdAddressRegistration = addressReg.IdAddress;
            //    student.IdGroup = Int32.Parse(GroupCB.SelectedValue.ToString());
            //    student.INN = INNTB.Text;
            //    student.SNILS = SNILSTB.Text;
            //    student.OMS = NumberOMSTB.Text;
            //    student.DateEducationStart = DateTime.Parse(DateEducationStart.Text);
            //    student.DateEducationEnd = DateTime.Parse(DateEducationEnd.Text);
            //    student.IdStatus = Int32.Parse(StatusCB.SelectedValue.ToString());
            //    student.OrderNumber = OrderTB.Text;
            //    student.PhotoStudent = ImageClass.ConvertImageToByteArray(selectedFileName);
            //    DBEntities.GetContext().SaveChanges();

            //    MBClass.InfoMB("Куратор отредактирован");
            //    NavigationService.Navigate(new PageFolder.EmployeePage.ListTutor());
            //}
            //catch (Exception ex)
            //{
            //    MBClass.ErrorMB(ex);
            //}
        }
    }
}
