using huypq.SmtWpfClient.Abstraction;
using huypq.SmtShared;
using System.Windows;

namespace huypq.SmtWpfClient.ViewModel
{
    public class SmtUserBaseViewModel<T> : BaseViewModel<T> where T : class, SmtIUserDto, new()
    {
        IDataService _dataService;

        private string _lockUserButtonContent;

        public string LockUserButtonContent
        {
            get { return _lockUserButtonContent; }
            set
            {
                if (_lockUserButtonContent != value)
                {
                    _lockUserButtonContent = value;
                    OnPropertyChanged();
                }
            }
        }

        public SmtUserBaseViewModel()
        {
            _dataService = ServiceLocator.Get<IDataService>();

            AddCommand = new SimpleDataGrid.SimpleCommand("AddCommand", () =>
            {
                var dto = new T();
                var de = new View.DataEditor();
                de.Add(nameof(SmtIUserDto.Email), nameof(SmtIUserDto.Email), View.DataEditor.DataType.Text);
                de.Add(nameof(SmtIUserDto.UserName), nameof(SmtIUserDto.UserName), View.DataEditor.DataType.Text);
                de.DataContext = dto;
                if (de.ShowDialog(400, 200) == true)
                {
                    _dataService.Add(dto);
                    Load();
                }
            });

            UpdateCommand = new SimpleDataGrid.SimpleCommand("UpdateCommand", () =>
            {
                var dto = SelectedItem as T;
                var de = new View.DataEditor();
                de.Add(nameof(SmtIUserDto.UserName), nameof(SmtIUserDto.UserName), View.DataEditor.DataType.Text);
                de.DataContext = dto;
                if (de.ShowDialog(400, 150) == true)
                {
                    _dataService.Update(dto);
                    Load();
                }
            }, () => SelectedValue != null);

            DeleteCommand = new SimpleDataGrid.SimpleCommand("DeleteCommand", () =>
            {
                var dto = SelectedItem as T;
                if (MessageBox.Show(string.Format("delete user [{0}] ?", dto.Email), "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _dataService.Delete(dto);
                    Load();
                }
            }, () => SelectedValue != null);

            LockUserCommand = new SimpleDataGrid.SimpleCommand("LockUserCommand", () =>
            {
                var dto = SelectedItem as SmtIUserDto;
                if (MessageBox.Show(string.Format("{0} user [{1}] ?", dto.IsLocked ? "unlock" : "lock", dto.Email), "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _dataService.LockUser((SelectedItem as SmtIUserDto).Email, dto.IsLocked == false);
                    Load();
                }
            }, () => SelectedValue != null);
        }

        protected override void RaiseCommandCanExecuteChanged()
        {
            UpdateCommand.RaiseCanExecuteChanged();
            DeleteCommand.RaiseCanExecuteChanged();
            LockUserCommand.RaiseCanExecuteChanged();
        }

        protected override void OnSelectedValueChanged()
        {
            var dto = SelectedItem as SmtIUserDto;
            LockUserButtonContent = dto.IsLocked ? "Unlock" : "Lock";
        }

        public SimpleDataGrid.SimpleCommand AddCommand { get; set; }
        public SimpleDataGrid.SimpleCommand UpdateCommand { get; set; }
        public SimpleDataGrid.SimpleCommand DeleteCommand { get; set; }
        public SimpleDataGrid.SimpleCommand LockUserCommand { get; set; }
    }
}
