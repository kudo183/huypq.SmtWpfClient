using huypq.SmtWpfClient.Abstraction;
using SimpleDataGrid;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows;

namespace huypq.SmtWpfClient.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _tenantName;
        public string TenantName
        {
            get { return _tenantName; }
            set
            {
                if (_tenantName != value)
                {
                    _tenantName = value;
                    OnPropertyChanged();
                    RegisterCommand.RaiseCanExecuteChanged();
                    UserLoginCommand.RaiseCanExecuteChanged();
                    UserResendCommand.RaiseCanExecuteChanged();
                    UserResetCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
                    RegisterCommand.RaiseCanExecuteChanged();
                    UserLoginCommand.RaiseCanExecuteChanged();
                    UserResendCommand.RaiseCanExecuteChanged();
                    UserResetCommand.RaiseCanExecuteChanged();
                    TenantLoginCommand.RaiseCanExecuteChanged();
                    TenantResendCommand.RaiseCanExecuteChanged();
                    TenantResetCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _pass;
        public string Pass
        {
            get { return _pass; }
            set
            {
                if (_pass != value)
                {
                    _pass = value;
                    OnPropertyChanged();
                    UserLoginCommand.RaiseCanExecuteChanged();
                    TenantLoginCommand.RaiseCanExecuteChanged();
                    RegisterCommand.RaiseCanExecuteChanged();
                    ResetCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _token;
        public string Token
        {
            get { return _token; }
            set
            {
                if (_token != value)
                {
                    _token = value;
                    OnPropertyChanged();
                    ConfirmCommand.RaiseCanExecuteChanged();
                    ResetCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _msg;
        public string Msg
        {
            get { return _msg; }
            set
            {
                if (_msg != value)
                {
                    _msg = value;
                    OnPropertyChanged();
                }
            }
        }

        public LoginViewModel(Window window)
        {
            _window = window;
            _dataService = ServiceLocator.Get<IDataService>();

            UserLoginCommand = new SimpleCommand("UserLoginCommand",
                () => { UserLoginButtonClick(); },
                () =>
                {
                    return
                    (string.IsNullOrEmpty(_tenantName) == false
                    && string.IsNullOrEmpty(_email) == false
                    && string.IsNullOrEmpty(_pass) == false);
                }
            );

            TenantLoginCommand = new SimpleCommand("TenantLoginCommand",
                () => { TenantLoginButtonClick(); },
                () =>
                {
                    return (string.IsNullOrEmpty(_email) == false
                    && string.IsNullOrEmpty(_pass) == false);
                }
            );

            RegisterCommand = new SimpleCommand("RegisterCommand",
                () => { RegisterButtonClick(); },
                () =>
                {
                    return
                    (string.IsNullOrEmpty(_tenantName) == false
                    && string.IsNullOrEmpty(_email) == false
                    && string.IsNullOrEmpty(_pass) == false);
                }
            );
            TenantResendCommand = new SimpleCommand("ResendTenantCommand",
                () => { TenantResendButtonClick(); },
                () =>
                {
                    return string.IsNullOrEmpty(_email) == false;
                }
            );
            UserResendCommand = new SimpleCommand("ResendUserCommand",
                () => { UserResendButtonClick(); },
                () =>
                {
                    return
                    (string.IsNullOrEmpty(_tenantName) == false
                    && string.IsNullOrEmpty(_email) == false);
                }
            );
            ConfirmCommand = new SimpleCommand("ConfirmCommand",
                () => { ConfirmButtonClick(); },
                () =>
                {
                    return string.IsNullOrEmpty(_token) == false;
                }
            );
            TenantResetCommand = new SimpleCommand("TenantResetCommand",
                 () => { TenantResetButtonClick(); },
                 () =>
                 {
                     return string.IsNullOrEmpty(_email) == false;
                 }
             );
            UserResetCommand = new SimpleCommand("UserResetCommand",
                () => { UserResetButtonClick(); },
                () =>
                {
                    return
                    (string.IsNullOrEmpty(_tenantName) == false
                    && string.IsNullOrEmpty(_email) == false);
                }
            );
            ResetCommand = new SimpleCommand("ResetCommand",
                 () => { ResetButtonClick(); },
                 () =>
                 {
                     return string.IsNullOrEmpty(_token) == false;
                 }
             );
        }

        IDataService _dataService;
        Window _window;

        void UserLoginButtonClick()
        {
            try
            {
                Msg = "";

                _dataService.UserLogin(TenantName, Email, Pass);
                _window.DialogResult = true;
                _window.Close();
            }
            catch (WebException ex)
            {
                switch (ex.Status)
                {
                    case WebExceptionStatus.ConnectFailure:
                        Msg = "ConnectFailure";
                        break;
                    case WebExceptionStatus.Timeout:
                        Msg = "Timeout";
                        break;
                    case WebExceptionStatus.ProtocolError:
                        Msg = "ProtocolError";
                        break;
                }
            }
        }

        void TenantLoginButtonClick()
        {
            try
            {
                Msg = "";

                _dataService.TenantLogin(Email, Pass);
                _window.DialogResult = true;
                _window.Close();
            }
            catch (WebException ex)
            {
                switch (ex.Status)
                {
                    case WebExceptionStatus.ConnectFailure:
                        Msg = "ConnectFailure";
                        break;
                    case WebExceptionStatus.Timeout:
                        Msg = "Timeout";
                        break;
                    case WebExceptionStatus.ProtocolError:
                        Msg = "ProtocolError";
                        break;
                }
            }
        }

        void RegisterButtonClick()
        {
            try
            {
                Msg = "";

                Msg = _dataService.Register(Email, TenantName, Pass);
            }
            catch (WebException ex)
            {
                switch (ex.Status)
                {
                    case WebExceptionStatus.ConnectFailure:
                        Msg = "ConnectFailure";
                        break;
                    case WebExceptionStatus.Timeout:
                        Msg = "Timeout";
                        break;
                    case WebExceptionStatus.ProtocolError:
                        Msg = "ProtocolError";
                        break;
                }
            }
        }

        void TenantResendButtonClick()
        {
            try
            {
                Msg = "";

                Msg = _dataService.TenantRequestToken(Email, "confirmemail");
            }
            catch (WebException ex)
            {
                switch (ex.Status)
                {
                    case WebExceptionStatus.ConnectFailure:
                        Msg = "ConnectFailure";
                        break;
                    case WebExceptionStatus.Timeout:
                        Msg = "Timeout";
                        break;
                    case WebExceptionStatus.ProtocolError:
                        Msg = "ProtocolError";
                        break;
                }
            }
        }

        void UserResendButtonClick()
        {
            try
            {
                Msg = "";

                Msg = _dataService.UserRequestToken(Email, TenantName, "confirmemail");
            }
            catch (WebException ex)
            {
                switch (ex.Status)
                {
                    case WebExceptionStatus.ConnectFailure:
                        Msg = "ConnectFailure";
                        break;
                    case WebExceptionStatus.Timeout:
                        Msg = "Timeout";
                        break;
                    case WebExceptionStatus.ProtocolError:
                        Msg = "ProtocolError";
                        break;
                }
            }
        }

        void ConfirmButtonClick()
        {
            try
            {
                Msg = "";

                Msg = _dataService.ConfirmEmail(Token);
            }
            catch (WebException ex)
            {
                switch (ex.Status)
                {
                    case WebExceptionStatus.ConnectFailure:
                        Msg = "ConnectFailure";
                        break;
                    case WebExceptionStatus.Timeout:
                        Msg = "Timeout";
                        break;
                    case WebExceptionStatus.ProtocolError:
                        Msg = "ProtocolError";
                        break;
                }
            }
        }

        void TenantResetButtonClick()
        {
            try
            {
                Msg = "";

                Msg = _dataService.TenantRequestToken(Email, "resetpassword");
            }
            catch (WebException ex)
            {
                switch (ex.Status)
                {
                    case WebExceptionStatus.ConnectFailure:
                        Msg = "ConnectFailure";
                        break;
                    case WebExceptionStatus.Timeout:
                        Msg = "Timeout";
                        break;
                    case WebExceptionStatus.ProtocolError:
                        Msg = "ProtocolError";
                        break;
                }
            }
        }

        void UserResetButtonClick()
        {
            try
            {
                Msg = "";

                Msg = _dataService.UserRequestToken(Email, TenantName, "resetpassword");
            }
            catch (WebException ex)
            {
                switch (ex.Status)
                {
                    case WebExceptionStatus.ConnectFailure:
                        Msg = "ConnectFailure";
                        break;
                    case WebExceptionStatus.Timeout:
                        Msg = "Timeout";
                        break;
                    case WebExceptionStatus.ProtocolError:
                        Msg = "ProtocolError";
                        break;
                }
            }
        }

        void ResetButtonClick()
        {
            try
            {
                Msg = "";

                Msg = _dataService.ResetPassword(Token, Pass);
            }
            catch (WebException ex)
            {
                switch (ex.Status)
                {
                    case WebExceptionStatus.ConnectFailure:
                        Msg = "ConnectFailure";
                        break;
                    case WebExceptionStatus.Timeout:
                        Msg = "Timeout";
                        break;
                    case WebExceptionStatus.ProtocolError:
                        Msg = "ProtocolError";
                        break;
                }
            }
        }

        public SimpleCommand UserLoginCommand { get; private set; }

        public SimpleCommand TenantLoginCommand { get; private set; }

        public SimpleCommand RegisterCommand { get; private set; }

        public SimpleCommand TenantResendCommand { get; private set; }

        public SimpleCommand UserResendCommand { get; private set; }

        public SimpleCommand ConfirmCommand { get; private set; }

        public SimpleCommand UserResetCommand { get; private set; }

        public SimpleCommand TenantResetCommand { get; private set; }

        public SimpleCommand ResetCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
