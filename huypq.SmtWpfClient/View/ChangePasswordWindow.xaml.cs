using huypq.SmtWpfClient.ViewModel;
using System.Windows;

namespace huypq.SmtWpfClient.View
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        ChangePasswordViewModel _vm;
        public ChangePasswordWindow()
        {
            InitializeComponent();

            _vm = new ChangePasswordViewModel();
            DataContext = _vm;
        }
        
        private void current_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _vm.CurrentPass = passboxCurrent.Password;
        }

        private void new_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _vm.NewPass = passboxNew.Password;
        }

        private void confirm_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _vm.ConfirmNewPass = passboxConfirm.Password;
        }
    }
}
