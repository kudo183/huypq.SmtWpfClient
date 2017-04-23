using huypq.SmtWpfClient.ViewModel;
using System.Windows;

namespace huypq.SmtWpfClient.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        LoginViewModel _vm;
        public LoginWindow()
        {
            InitializeComponent();
            _vm = new LoginViewModel(this);
            DataContext = _vm;
        }
        
        private void login_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _vm.Pass = passboxLogin.Password;
        }
        
        private void register_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _vm.Pass = passboxRegister.Password;
        }

        private void reset_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _vm.Pass = passboxRegset.Password;
        }

        public void RunApp(Window main)
        {
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            if (ShowDialog() == true)
            {
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                Application.Current.MainWindow = main;
                main.Show();
            }
            else
            {
                Application.Current.Shutdown(-1);
            }
        }
    }
}
