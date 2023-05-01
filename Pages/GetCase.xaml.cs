using Arende_hantering_wpf.Contexts;
using Arende_hantering_wpf.Services;
using System;
using System.Windows;
using System.Windows.Controls;
using Button = System.Windows.Controls.Button;

namespace Arende_hantering_wpf.Pages
{
    /// <summary>
    /// Interaction logic for GetCase.xaml
    /// </summary>
    public partial class GetCase : Page
    {
        private readonly UserService _userService;
        private readonly CaseService _caseService;
        private readonly CommentService _commentService;
        public GetCase()
        {
            InitializeComponent();
            _userService = new UserService();
            _caseService = new CaseService();
            _commentService = new CommentService();
             getall();
        }
        private readonly DataContext _context = new DataContext();

        
        private async void GetBtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var cases = await _caseService.GetAllAsync();
            casesList.ItemsSource = cases;

        }
        public async void getall()
        {
            
            var cases = await _caseService.GetAllAsync();
            casesList.ItemsSource = cases;
        }
        Guid FakeCaseId;
        Guid FakeUserId;
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            var selectedId = button?.Tag.ToString();
            
            if (selectedId != null)
            {
                var item = await _caseService.GetAsync(x => x.Id == Guid.Parse(selectedId));
                FakeUserId = item.UserId;
                FakeCaseId = Guid.Parse(selectedId);
                if (item != null)
                {
                    
                    Email.Text = item.User.Email.ToString();
                    FirstName.Text = item.User.FirstName.ToString();
                    LastName.Text = item.User.LastName.ToString();
                    PohoneNumber.Text = item.User.PohoneNumber.ToString();
                    TypeName.Text = item.User.UserType.TypeName.ToString();
                    title.Text = item.Title.ToString();
                    Description.Text = item.Description.ToString();
                    Modified.Text = item.Modified.ToString();
                    Created.Text = item.Created.ToString();
                    Id.Text = item.Id.ToString();
                    var ContactInfo = "Contact Information";
                    contactInfo.Text = ContactInfo;
                    var created = "Created";
                    UCreated.Text = created;
                    var modified = "Modified";
                    UModified.Text = modified;
                    var subject = "Subject";
                    USubject.Text = subject;
                    var description = "Description";
                    UDescription.Text = description;
                    var Ucase = "Case";
                    UCase.Text = Ucase;
                    //var CaseComment = "Comment";
                    //CComment.Text = CaseComment;
                    //cComment.Text = item.User.Comment.ToString();

                    // Visa "EditPanel"
                    EditPanel.Visibility = Visibility.Visible;

                }


            }
           

        }

        private void Add_Comment_Btn(object sender, RoutedEventArgs e)
        {
            Add_Comment_Panel.Visibility = Visibility.Visible;           

        }
        private async void Save_Comment_Btn(object sender, RoutedEventArgs e)
        {
            await _commentService.SaveAsync(new Models.CommentAddModel
            {
                Comment = Comment.Text,
                Case = new Models.CaseModel()
                {
                    Id = FakeCaseId,
                    
                },
                User = new Models.UserModel()
                {
                    Id = FakeUserId,
                }

            }) ;
            Add_Comment_Panel.Visibility = Visibility.Collapsed;

        }
        
        
        private void Change_Status_Btn(object sender, RoutedEventArgs e)
        {
            ChangeStatus.Visibility = Visibility.Visible;
        }
        private async void Save_Status_Change_Btn(object sender, RoutedEventArgs e)
        {
            var item = await _caseService.GetAsync(x => x.Id == FakeCaseId);
            if (item != null)
            {
                var StatusConverted = int.Parse(Status.Text);
                                
                await _caseService.SaveUpdateAsync(new Models.CaseModel
                {
                    
                    StatusTypeId = StatusConverted,
                    Id = FakeCaseId,

                });
                getall();
                ChangeStatus.Visibility = Visibility.Collapsed;
            }
        }
        private async void Remove_Case_Btn(object sender, RoutedEventArgs e)
        {
            await _caseService.DeleteAsync(new Models.CaseModel
            {
                Id= FakeCaseId,
            });
            getall();
        }
    }
}
