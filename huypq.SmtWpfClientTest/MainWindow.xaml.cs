using huypq.SmtSharedTest;
using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClient.View;
using huypq.SmtWpfClient.ViewModel;
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
        
        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            ReferenceDataManager<TestDataDto>.Instance.Update();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            _dataService.Logout();
            (loginView.DataContext as LoginViewModel).ClearData();
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
            w.Show();
        }

        private void TestDataButton_Click(object sender, RoutedEventArgs e)
        {
            var w = new Window()
            {
                Content = new TestDataView()
            };
            w.Show();
        }

        private void TestChildDataButton_Click(object sender, RoutedEventArgs e)
        {
            var w = new Window()
            {
                Content = new TestChildDataView()
            };
            w.Show();
        }
    }
}
