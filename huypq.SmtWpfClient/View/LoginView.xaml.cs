using huypq.SmtWpfClient.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace huypq.SmtWpfClient.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        LoginViewModel _vm;
        
        public LoginView()
        {
            InitializeComponent();

            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject()) == true)
            {
                return;
            }

            _vm = new LoginViewModel();
            DataContext = _vm;

            _vm.PropertyChanged += _vm_PropertyChanged;
        }

        private void _vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginViewModel.Pass))
            {
                if (passboxLogin.Password != _vm.Pass)
                {
                    passboxLogin.Password = _vm.Pass;
                }
                if (passboxReset.Password != _vm.Pass)
                {
                    passboxReset.Password = _vm.Pass;
                }
            }
        }

        private void login_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (_vm.Pass != passboxLogin.Password)
            {
                _vm.Pass = passboxLogin.Password;
            }
        }

        private void reset_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (_vm.Pass != passboxReset.Password)
            {
                _vm.Pass = passboxReset.Password;
            }
        }
    }
}
