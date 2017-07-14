using huypq.SmtShared.Test;
using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClient.View;
using huypq.SmtWpfClient.ViewModel;
using System.Windows;

namespace huypq.SmtWpfClient.Test
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
            ReferenceDataManager<TestDataDto>.Instance.LoadOrUpdate();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            _dataService.Logout();
            (loginView.DataContext as LoginViewModel).Logout();
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
