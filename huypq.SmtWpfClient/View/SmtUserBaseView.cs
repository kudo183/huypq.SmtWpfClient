using huypq.SmtShared;
using huypq.SmtWpfClient.Abstraction;
using SimpleDataGrid;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace huypq.SmtWpfClient.View
{
    public class SmtUserBaseView<T, T1> : BaseView<T, T1> where T : class, IUserDto, new() where T1 : class, IUserDataModel<T>, new()
    {
        public SmtUserBaseView()
        {
            var grid = new EditableGridView()
            {
                IsReadOnly = true,
                SaveButtonVisibility = Visibility.Collapsed
            };
            grid.Columns.Add(new DataGridTextColumnExt()
            {
                Width = 80,
                Header = nameof(IUserDto.ID),
                Binding = new Binding()
                {
                    Path = new PropertyPath(nameof(IUserDto.ID)),
                    Mode = BindingMode.OneWay
                }
            });
            grid.Columns.Add(new DataGridTextColumnExt()
            {
                Width = 180,
                Header = nameof(IUserDto.Email),
                Binding = new Binding()
                {
                    Path = new PropertyPath(nameof(IUserDto.Email)),
                    Mode = BindingMode.OneWay
                }
            });
            grid.Columns.Add(new DataGridTextColumnExt()
            {
                Width = 120,
                Header = nameof(IUserDto.UserName),
                Binding = new Binding()
                {
                    Path = new PropertyPath(nameof(IUserDto.UserName)),
                    Mode = BindingMode.OneWay
                }
            });
            grid.Columns.Add(new DataGridTextColumnExt()
            {
                Width = 80,
                Header = nameof(IUserDto.IsLocked),
                Binding = new Binding()
                {
                    Path = new PropertyPath(nameof(IUserDto.IsLocked)),
                    Mode = BindingMode.OneWay
                }
            });
            grid.Columns.Add(new DataGridTextColumnExt()
            {
                Width = 80,
                Header = nameof(IUserDto.CreateDate),
                Binding = new Binding()
                {
                    Path = new PropertyPath(nameof(IUserDto.CreateDate)),
                    Mode = BindingMode.OneWay
                }
            });
            grid.Columns.Add(new DataGridTextColumnExt()
            {
                Width = 80,
                Header = nameof(IUserDto.LastUpdateTime),
                Binding = new Binding()
                {
                    Path = new PropertyPath(nameof(IUserDto.LastUpdateTime)),
                    Mode = BindingMode.OneWay,
                    Converter = Converter.LongToDateTimeStringConverter.Instance
                }
            });
            grid.Columns.Add(new DataGridTextColumnExt()
            {
                Width = 80,
                Header = nameof(IUserDto.TokenValidTime),
                Binding = new Binding()
                {
                    Path = new PropertyPath(nameof(IUserDto.TokenValidTime)),
                    Mode = BindingMode.OneWay,
                    Converter = Converter.LongToDateTimeStringConverter.Instance
                }
            });

            var btnAdd = new Button()
            {
                Content = "Add",
                Width = 75,
                Margin = new Thickness(5)
            };
            grid.CustomMenuItems.Add(btnAdd);
            btnAdd.SetBinding(Button.CommandProperty, new Binding(nameof(SmtWpfClient.ViewModel.SmtUserBaseViewModel<T, T1>.AddCommand)));

            var btnUpdate = new Button()
            {
                Content = "Update",
                Width = 75,
                Margin = new Thickness(5)
            };
            grid.CustomMenuItems.Add(btnUpdate);
            btnUpdate.SetBinding(Button.CommandProperty, new Binding(nameof(SmtWpfClient.ViewModel.SmtUserBaseViewModel<T, T1>.UpdateCommand)));

            var btnDelete = new Button()
            {
                Content = "Delete",
                Width = 75,
                Margin = new Thickness(5)
            };
            grid.CustomMenuItems.Add(btnDelete);
            btnDelete.SetBinding(Button.CommandProperty, new Binding(nameof(SmtWpfClient.ViewModel.SmtUserBaseViewModel<T, T1>.DeleteCommand)));

            var btnLockUser = new Button()
            {
                Width = 75,
                Margin = new Thickness(5)
            };
            grid.CustomMenuItems.Add(btnLockUser);
            btnLockUser.SetBinding(Button.CommandProperty, new Binding(nameof(SmtWpfClient.ViewModel.SmtUserBaseViewModel<T, T1>.LockUserCommand)));
            btnLockUser.SetBinding(Button.ContentProperty, new Binding(nameof(SmtWpfClient.ViewModel.SmtUserBaseViewModel<T, T1>.LockUserButtonContent)));

            Content = grid;
        }
    }
}
