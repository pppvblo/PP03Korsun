using Microsoft.Win32;
using PP03Korsun.ClassFolder;
using PP03Korsun.DataFolder;
using PP03Korsun.WindowFolder.AddFolder;
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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PP03Korsun.PageFolder.EmployeePage
{
    /// <summary>
    /// Логика взаимодействия для AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Page
    {
        Student student = new Student();
        Address address= new Address();
        Address addressReg = new Address();
        public AddStudent()
        {
            InitializeComponent();
            WhoGivePassportCB.ItemsSource = DBEntities.GetContext().WhoGivePassport.ToList();
            PlaceOfBirthRegionCB.ItemsSource = DBEntities.GetContext().Region.ToList();
            PlaceOfBirthCityCB.ItemsSource = DBEntities.GetContext().City.ToList();
            AddresRegistrationRegionCB.ItemsSource = DBEntities.GetContext().Region.ToList();
            AddresRegistrationCityCB.ItemsSource = DBEntities.GetContext().City.ToList();
            AddresRegistrationStreetCB.ItemsSource = DBEntities.GetContext().Street.ToList();
            GroupCB.ItemsSource = DBEntities.GetContext().Group.ToList();
            StatusCB.ItemsSource = DBEntities.GetContext().Status.ToList();            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void TwoBorder_Click(object sender, RoutedEventArgs e)
        {
            FirstBorder.Visibility = Visibility.Hidden;
            SecondBorder.Visibility = Visibility.Visible;
            TwoBorder.Visibility = Visibility.Hidden;
            OneBorder.Visibility = Visibility.Visible;
            
        }

        private void OneBorder_Click(object sender, RoutedEventArgs e)
        {
            FirstBorder.Visibility = Visibility.Visible;
            SecondBorder.Visibility = Visibility.Hidden;
            TwoBorder.Visibility = Visibility.Visible;
            OneBorder.Visibility = Visibility.Hidden;
           
        }

        private void AddWhoGivePassport_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new AddWhoGivePassportWindow().ShowDialog();
            WhoGivePassportCB.ItemsSource = DBEntities.GetContext().WhoGivePassport.ToList();

        }

        private void AddPlaceOfBirthRegion_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new AddPlaceOfBirthRegionWindow().ShowDialog();
            PlaceOfBirthRegionCB.ItemsSource = DBEntities.GetContext().Region.ToList();
        }

        private void AddPlaceOfBirthCity_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new AddPlaceOfBirthCityWindow().ShowDialog();
            PlaceOfBirthCityCB.ItemsSource = DBEntities.GetContext().City.ToList();
        }

        private void AddAddresRegistrationRegion_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new AddAddresRegistrationRegionWindow().ShowDialog();
            AddresRegistrationRegionCB.ItemsSource = DBEntities.GetContext().Region.ToList();
        }

        private void AddAddresRegistrationCity_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new AddAddresRegistrationCityWindow().ShowDialog();
            AddresRegistrationCityCB.ItemsSource = DBEntities.GetContext().City.ToList();
        }

        private void AddAddresRegistrationStreet_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new AddAddresRegistrationStreetWindow().ShowDialog();
            AddresRegistrationStreetCB.ItemsSource = DBEntities.GetContext().Street.ToList();
        }

        private void AddGroup_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new AddGroupWindow().ShowDialog();
            GroupCB.ItemsSource = DBEntities.GetContext().Group.ToList();
        }

        private void AddStatus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new AddStatusWindow().ShowDialog();
            StatusCB.ItemsSource = DBEntities.GetContext().Status.ToList();
        }



        private void AddtStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AddFirstNameTB.Text) ||
               string.IsNullOrWhiteSpace(AddLastNameTB.Text) ||
               string.IsNullOrWhiteSpace(AddMiddleNameTB.Text) ||
               string.IsNullOrWhiteSpace(AddNumberPhoneTB.Text) ||
               string.IsNullOrWhiteSpace(AddEmailTB.Text) ||
               string.IsNullOrWhiteSpace(DateOfBirth.Text) ||
               string.IsNullOrWhiteSpace(PassportNumberTB.Text) ||
               string.IsNullOrWhiteSpace(PassportSeriaTB.Text) ||
               (WhoGivePassportCB.SelectedIndex == -1) ||
               (PlaceOfBirthRegionCB.SelectedIndex == -1) ||
               (PlaceOfBirthCityCB.SelectedIndex == -1) ||
               (AddresRegistrationRegionCB.SelectedIndex == -1) ||
               (AddresRegistrationCityCB.SelectedIndex == -1) ||
               (AddresRegistrationStreetCB.SelectedIndex == -1) ||
               string.IsNullOrWhiteSpace(AddresRegistrationHouseTB.Text) ||
               string.IsNullOrWhiteSpace(AddresRegistrationFrameTB.Text) ||
               string.IsNullOrWhiteSpace(AddresRegistrationFlatTB.Text) ||
               (GroupCB.SelectedIndex == -1) ||
               (StatusCB.SelectedIndex == -1) ||
               string.IsNullOrWhiteSpace(INNTB.Text) ||
               string.IsNullOrWhiteSpace(SNILSTB.Text) ||
               string.IsNullOrWhiteSpace(NumberOMSTB.Text) ||
               string.IsNullOrWhiteSpace(DateEducationStart.Text) ||
               string.IsNullOrWhiteSpace(DateEducationEnd.Text) ||
               string.IsNullOrWhiteSpace(OrderTB.Text))
            {
                MBClass.ErrorMB("Заполните все поля");
            }
            else
            {
                try
                {
                    AddPlaceOfBirth();
                    AddAddressRegistration();
                    StudentAdd();


                   MBClass.InfoMB("Студент добавлен");
                   NavigationService.Navigate(new PageFolder.EmployeePage.ListStudent());
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex.Message);
                }
}
                         
        }
        string selectedFileName = "";

        private void StudentAdd()
        {
            var studentAdd = new Student()
            {
                LastNameStudent = AddLastNameTB.Text,
                FirstNameStudent = AddFirstNameTB.Text,
                MiddleNameStudent = AddMiddleNameTB.Text,
                DateOfBirth = DateTime.Parse(DateOfBirth.Text),
                Email = AddEmailTB.Text,
                PhoneNumber = AddNumberPhoneTB.Text,
                PassportSeria = PassportSeriaTB.Text,
                PassportNumber = PassportNumberTB.Text,
                IdWhoGivePassport = Int32.Parse(WhoGivePassportCB.SelectedValue.ToString()),
                DateWhoGivePassport = DateTime.Parse(DateWhoGivePassport.Text),
                IdPlaceOfBirth = address.IdAddress,
                IdAddressRegistration = addressReg.IdAddress,
                IdGroup = Int32.Parse(GroupCB.SelectedValue.ToString()),
                INN = INNTB.Text,
                SNILS = SNILSTB.Text,
                OMS = NumberOMSTB.Text,
                DateEducationStart = DateTime.Parse(DateEducationStart.Text),
                DateEducationEnd = DateTime.Parse(DateEducationEnd.Text),
                IdStatus = Int32.Parse(StatusCB.SelectedValue.ToString()),
                OrderNumber = OrderTB.Text,
                PhotoStudent = ImageClass.ConvertImageToByteArray(selectedFileName)
            };
            DBEntities.GetContext().Student.Add(studentAdd);
            DBEntities.GetContext().SaveChanges();
            student.IdStudent = studentAdd.IdStudent;

        }

        private void AddPlaceOfBirth()
        {
            var placeOfBirthAdd = new Address()
            {
                IdRegion = Int32.Parse(PlaceOfBirthRegionCB.SelectedValue.ToString()),
                IdCity = Int32.Parse(PlaceOfBirthCityCB.SelectedValue.ToString())
            };
            DBEntities.GetContext().Address.Add(placeOfBirthAdd);
            DBEntities.GetContext().SaveChanges();
            address.IdAddress = placeOfBirthAdd.IdAddress;

        }

        private void AddAddressRegistration()
        {
            var addressRegistrationAdd = new Address()
            {

                IdRegion = Int32.Parse(AddresRegistrationRegionCB.SelectedValue.ToString()),
                IdCity = Int32.Parse(AddresRegistrationCityCB.SelectedValue.ToString()),
                IdStreet = Int32.Parse(AddresRegistrationStreetCB.SelectedValue.ToString()),
                House = AddresRegistrationHouseTB.Text,
                Frame = AddresRegistrationFrameTB.Text,
                Flat = AddresRegistrationFlatTB.Text
            };
            DBEntities.GetContext().Address.Add(addressRegistrationAdd);
            DBEntities.GetContext().SaveChanges();
            addressReg.IdAddress= addressRegistrationAdd.IdAddress; 
        }

        
        private void AddPhoto()
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
                        AddImageStudent.Source = ImageClass.ConvertByteArrayToImage(student.PhotoStudent);
                    }
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
            catch(Exception ex) 
            {
                MBClass.ErrorMB(ex);
            }
        }
        private void photo_Click(object sender, RoutedEventArgs e)
        {
            AddPhoto();
        }
    }
}





//else
//{
//    try
//    {
//        DBEntities.GetContext().Student.Add(new Student()
//        {
//              LastNameStudent = AddLastNameTB.Text,
//              FirstNameStudent = AddFirstNameTB.Text,
//              MiddleNameStudent = AddMiddleNameTB.Text,
//              Email = AddEmailTB.Text,
//              PhoneNumber = AddNumberPhoneTB.Text,
//              DateOfBirth = DateTime.Parse(DateOfBirth.Text),
//              PassportSeria = PassportSeriaTB.Text,
//              PassportNumber = PassportNumberTB.Text,
//              IdWhoGivePassport = Int32.Parse(WhoGivePassportCB.SelectedValue.ToString()),
//              DateWhoGivePassport = DateTime.Parse(DateWhoGivePassport.Text),
//              //IdPlaceOfBirth = Int32.Parse(),
//              //IdAddresRegistration = Int32.Parse(),
//              IdGroup = Int32.Parse(GroupCB.SelectedValue.ToString()),
//              INN = INNTB.Text,
//              SNILS = SNILSTB.Text,
//              OMS = NumberOMSTB.Text,
//              DateEducationStart = DateTime.Parse(DateEducationStart.Text),
//              DateEducationEnd = DateTime.Parse(DateEducationEnd.Text),
//              IdStatus = Int32.Parse(StatusCB.SelectedValue.ToString()),
//              OrderNumber = OrderTB.Text,
//              PhotoStudent = ImageClass.ConvertImageToByteArray(selectedFileName)

//            });
//            DBEntities.GetContext().SaveChanges();
//            MBClass.InfoMB("Студент успешно добавлен");
//            NavigationService.Navigate(new PageFolder.EmployeePage.ListStudent());

//    }
//    catch (Exception ex)
//    {
//        MBClass.ErrorMB(ex);
//    }
//}                                         
