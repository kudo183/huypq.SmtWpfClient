using huypq.SmtWpfClient.Abstraction;
using huypq.SmtShared;
using System.Windows;
using System;
using huypq.wpf.Utils;

namespace huypq.SmtWpfClient.ViewModel
{
    public class SmtUserBaseViewModel<T> : BaseViewModel<T> where T : class, IUserDto, new()
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

            AddCommand = new SimpleCommand("AddCommand", () =>
            {
                var dto = new T();
                var de = new View.DataEditor();
                de.Add(nameof(IUserDto.Email), nameof(IUserDto.Email), View.DataEditor.DataType.Text);
                de.Add(nameof(IUserDto.UserName), nameof(IUserDto.UserName), View.DataEditor.DataType.Text);
                de.DataContext = dto;
                if (de.ShowDialog(400, 200) == true)
                {
                    try
                    {
                        SysMsg = _dataService.Add(dto);
                    }
                    catch (Exception ex)
                    {
                        SysMsg = ex.Message;
                    }
                    Load();
                }
            });

            UpdateCommand = new SimpleCommand("UpdateCommand", () =>
            {
                var dto = SelectedItem as T;
                var de = new View.DataEditor();
                de.Add(nameof(IUserDto.UserName), nameof(IUserDto.UserName), View.DataEditor.DataType.Text);
                de.DataContext = dto;
                if (de.ShowDialog(400, 150) == true)
                {
                    try
                    {
                        SysMsg = _dataService.Update(dto);
                    }
                    catch (Exception ex)
                    {
                        SysMsg = ex.Message;
                    }
                    Load();
                }
            }, () => SelectedValue != null);

            DeleteCommand = new SimpleCommand("DeleteCommand", () =>
            {
                var dto = SelectedItem as T;
                if (MessageBox.Show(string.Format("delete user [{0}] ?", dto.Email), "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        SysMsg = _dataService.Delete(dto);
                    }
                    catch (Exception ex)
                    {
                        SysMsg = ex.Message;
                    }
                    Load();
                }
            }, () => SelectedValue != null);

            LockUserCommand = new SimpleCommand("LockUserCommand", () =>
            {
                var dto = SelectedItem as IUserDto;
                if (MessageBox.Show(string.Format("{0} user [{1}] ?", dto.IsLocked ? "unlock" : "lock", dto.Email), "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        SysMsg = _dataService.LockUser((SelectedItem as IUserDto).Email, dto.IsLocked == false);
                    }
                    catch (Exception ex)
                    {
                        SysMsg = ex.Message;
                    }
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
            var dto = SelectedItem as IUserDto;
            LockUserButtonContent = dto.IsLocked ? "Unlock" : "Lock";
        }

        public SimpleCommand AddCommand { get; set; }
        public SimpleCommand UpdateCommand { get; set; }
        public SimpleCommand DeleteCommand { get; set; }
        public SimpleCommand LockUserCommand { get; set; }
    }
}
