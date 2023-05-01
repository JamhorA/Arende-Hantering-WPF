using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using Arende_hantering_wpf.Contexts;
using Arende_hantering_wpf.Services;

namespace Arende_hantering_wpf.Pages
{
    /// <summary>
    /// Interaction logic for Case.xaml
    /// </summary>
     public interface IValidation
    {
    bool IsValid();
}
public partial class Case :  Page, IValidation
    {
        public bool IsValid()
        {
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            string email = Email.Text;
            string phoneNumber = PhoneNumber.Text;
            string streetName = StreetName.Text;
            string postalCode = PostalCode.Text;
            string city = City.Text;

            if (string.IsNullOrEmpty(firstName) ||
                string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(phoneNumber) ||
                string.IsNullOrEmpty(streetName) ||
                string.IsNullOrEmpty(postalCode) ||
                string.IsNullOrEmpty(city)) 
                
            {
                return false;
            }
            else
            {
                
                return true;
            }
        }
        
        private readonly CaseService _caseService;
        private readonly UserService _userService;
        public Case()
        {
            InitializeComponent();
            _caseService = new CaseService();
            _userService = new UserService();
        }
      
        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            
            if (IsValid())
            {
                await _caseService.SaveAsync(new Models.CaseAddModel
                {

                    Title = _Title.Text,
                    Description = Description.Text,
                    User = new Models.UserModel()
                    {
                        FirstName = FirstName.Text,
                        LastName = LastName.Text,
                        Email = Email.Text,
                        PhoneNumber = PhoneNumber.Text,
                        StreetName = StreetName.Text,
                        PostalCode = PostalCode.Text,
                        City = City.Text,
                        UserType = "Customer"
                    }
                });
                Add_Case_Panel.Visibility = Visibility.Visible;
                Field.Visibility = Visibility.Collapsed;
            }
            Add_Case_Panel.Visibility = Visibility.Collapsed;
            Fieled_Panel.Visibility = Visibility.Visible;

            ClearForm();
            



        }
        private void ClearForm()
        {
            FirstName.Text = "";
            LastName.Text = string.Empty;
            Email.Text = string.Empty;
            PhoneNumber.Text = string.Empty;
            StreetName.Text = string.Empty;
            PostalCode.Text = string.Empty;
            City.Text = string.Empty;
            _Title.Text = string.Empty;
            Description.Text = string.Empty;
            
        }
        private readonly DataContext _context = new DataContext();
        
        


     
    }
}
