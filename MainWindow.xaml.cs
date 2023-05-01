using Arende_hantering_wpf.Pages;
using System.Windows;
using System.Windows.Controls;

namespace Arende_hantering_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        //private readonly CaseService _caseService;
        public MainWindow()
        {
            InitializeComponent();
            navframe.Navigate(new Case());
            
        }

        private void sidebar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = sidebar.SelectedItem as NavButton;
            navframe.Navigate(selected?.Navlink);

        }


    }
}
