using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClient.View;
using System.Windows;

namespace huypq.SmtWpfClientTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IDataService _dataService = ServiceLocator.Get<IDataService>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            _dataService.Logout();
        }

        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            var w = new ChangePasswordWindow();
            w.ShowDialog();
        }

        private void ManageUserButton_Click(object sender, RoutedEventArgs e)
        {
            var w = new Window()
            {
                Content = new ManageUserView()
            };
            w.ShowDialog();
        }
    }
}
