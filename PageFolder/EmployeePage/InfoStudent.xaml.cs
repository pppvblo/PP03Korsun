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
    /// Логика взаимодействия для InfoStudent.xaml
    /// </summary>
    public partial class InfoStudent : Page
    {
        DataFolder.Student student = new DataFolder.Student();
        DataFolder.Address address = new DataFolder.Address();
        public InfoStudent(Student student)
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
            MessageBox.Show($"Информация о студенте Id" +
                $"{student.IdAddressRegistration}");
            AddresRegistrationRegionCB.Text = address.Region.RegionName;
            AddresRegistrationCityCB.Text = address.City.CityName;
            AddresRegistrationStreetCB.Text = address.Street.StreetName;
            AddresRegistrationHouseTB.Text = address.House;
            AddresRegistrationFrameTB.Text = address.Frame;
            AddresRegistrationFlatTB.Text = address.Flat;


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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
