using huypq.SmtWpfClient.Abstraction;
using huypq.SmtShared;
using System.Windows;

namespace huypq.SmtWpfClient.ViewModel
{
    public class SmtUserBaseViewModel<T> : BaseViewModel<T> where T : class, SmtIUserDto, new()
    {
        IDataService _dataService;

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
                var selected = SelectedItem as SmtIUserDto;
                var dto = new T()
                {
                    UserName = selected.UserName,
                    PasswordHash = selected.PasswordHash,
                    CreateDate = selected.CreateDate,
                    Email = selected.Email,
                    ID = selected.ID,
                    LastUpdateTime = selected.LastUpdateTime,
                    TokenValidTime = selected.TokenValidTime,
                    TenantID = selected.TenantID
                };
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
                var dto = SelectedItem as SmtIUserDto;
                if (MessageBox.Show(string.Format("delete user [{0}] ?", dto.Email), "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _dataService.Delete(dto);
                    Load();
                }
            }, () => SelectedValue != null);

            ResetPasswordCommand = new SimpleDataGrid.SimpleCommand("ResetPasswordCommand", () =>
            {
                var dto = SelectedItem as SmtIUserDto;
                if (MessageBox.Show(string.Format("reset password of user [{0}] ?", dto.Email), "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _dataService.ResetUserPassword((SelectedItem as SmtIUserDto).Email);
                    Load();
                }
            }, () => SelectedValue != null);
        }

        protected override void RaiseCommandCanExecuteChanged()
        {
            UpdateCommand.RaiseCanExecuteChanged();
            DeleteCommand.RaiseCanExecuteChanged();
            ResetPasswordCommand.RaiseCanExecuteChanged();
        }

        public SimpleDataGrid.SimpleCommand AddCommand { get; set; }
        public SimpleDataGrid.SimpleCommand UpdateCommand { get; set; }
        public SimpleDataGrid.SimpleCommand DeleteCommand { get; set; }
        public SimpleDataGrid.SimpleCommand ResetPasswordCommand { get; set; }
    }
}
