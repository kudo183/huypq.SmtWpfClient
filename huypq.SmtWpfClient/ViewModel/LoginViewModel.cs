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
        IDataService _dataService;

        private bool _isLoggedIn;
        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set
            {
                if (_isLoggedIn != value)
                {
                    _isLoggedIn = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isTenant;
        public bool IsTenant
        {
            get { return _isTenant; }
            set
            {
                if (_isTenant != value)
                {
                    _isTenant = value;
                    OnPropertyChanged();
                }
            }
        }

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
                    UserResetCommand.RaiseCanExecuteChanged();
                    TenantLoginCommand.RaiseCanExecuteChanged();
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

        public LoginViewModel()
        {
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
                    && string.IsNullOrEmpty(_email) == false);
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

        public void ClearData()
        {
            IsLoggedIn = false;
            IsTenant = false;
            TenantName = string.Empty;
            Email = string.Empty;
            Pass = string.Empty;
            Token = string.Empty;
            Msg = string.Empty;
        }

        void UserLoginButtonClick()
        {
            try
            {
                Msg = "";

                _dataService.UserLogin(TenantName, Email, Pass);

                IsLoggedIn = true;
                IsTenant = false;
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

                IsLoggedIn = true;
                IsTenant = true;
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

                Msg = _dataService.Register(Email, TenantName);
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
