using huypq.SmtWpfClient.Abstraction;
using huypq.wpf.Utils;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;

namespace huypq.SmtWpfClient.ViewModel
{
    public class ChangePasswordViewModel : INotifyPropertyChanged
    {
        IDataService _dataService;

        private string _currentPass;
        public string CurrentPass
        {
            get { return _currentPass; }
            set
            {
                if (_currentPass != value)
                {
                    _currentPass = value;
                    OnPropertyChanged();
                    OkCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _newPass;
        public string NewPass
        {
            get { return _newPass; }
            set
            {
                if (_newPass != value)
                {
                    _newPass = value;
                    OnPropertyChanged();
                    OkCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _confirmNewPass;
        public string ConfirmNewPass
        {
            get { return _confirmNewPass; }
            set
            {
                if (_confirmNewPass != value)
                {
                    _confirmNewPass = value;
                    OnPropertyChanged();
                    OkCommand.RaiseCanExecuteChanged();
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
        public ChangePasswordViewModel()
        {
            _dataService = ServiceLocator.Get<IDataService>();

            OkCommand = new SimpleCommand("OkCommand",
                () => { OkButtonClick(); },
                () =>
                {
                    return
                    (string.IsNullOrEmpty(_currentPass) == false
                    && string.IsNullOrEmpty(_newPass) == false
                    && string.IsNullOrEmpty(_confirmNewPass) == false)
                    && (_newPass == _confirmNewPass);
                }
            );
        }
        
        void OkButtonClick()
        {
            try
            {
                Msg = "";

                Msg = _dataService.ChangePassword(CurrentPass, NewPass);

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

        public SimpleCommand OkCommand { get; private set; }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
