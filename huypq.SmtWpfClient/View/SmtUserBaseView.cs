using huypq.SmtShared;
using huypq.SmtWpfClient.Abstraction;
using SimpleDataGrid;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace huypq.SmtWpfClient.View
{
    public class SmtUserBaseView<T> : BaseView<T> where T : class, SmtIUserDto, new()
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
                Header = nameof(SmtIUserDto.ID),
                Binding = new Binding()
                {
                    Path = new PropertyPath(nameof(SmtIUserDto.ID)),
                    Mode = BindingMode.OneWay
                }
            });
            grid.Columns.Add(new DataGridTextColumnExt()
            {
                Width = 180,
                Header = nameof(SmtIUserDto.Email),
                Binding = new Binding()
                {
                    Path = new PropertyPath(nameof(SmtIUserDto.Email)),
                    Mode = BindingMode.OneWay
                }
            });
            grid.Columns.Add(new DataGridTextColumnExt()
            {
                Width = 120,
                Header = nameof(SmtIUserDto.UserName),
                Binding = new Binding()
                {
                    Path = new PropertyPath(nameof(SmtIUserDto.UserName)),
                    Mode = BindingMode.OneWay
                }
            });
            grid.Columns.Add(new DataGridTextColumnExt()
            {
                Width = 80,
                Header = nameof(SmtIUserDto.IsLocked),
                Binding = new Binding()
                {
                    Path = new PropertyPath(nameof(SmtIUserDto.IsLocked)),
                    Mode = BindingMode.OneWay
                }
            });
            grid.Columns.Add(new DataGridTextColumnExt()
            {
                Width = 80,
                Header = nameof(SmtIUserDto.IsConfirmed),
                Binding = new Binding()
                {
                    Path = new PropertyPath(nameof(SmtIUserDto.IsConfirmed)),
                    Mode = BindingMode.OneWay
                }
            });
            grid.Columns.Add(new DataGridTextColumnExt()
            {
                Width = 80,
                Header = nameof(SmtIUserDto.CreateDate),
                Binding = new Binding()
                {
                    Path = new PropertyPath(nameof(SmtIUserDto.CreateDate)),
                    Mode = BindingMode.OneWay
                }
            });
            grid.Columns.Add(new DataGridTextColumnExt()
            {
                Width = 80,
                Header = nameof(SmtIUserDto.LastUpdateTime),
                Binding = new Binding()
                {
                    Path = new PropertyPath(nameof(SmtIUserDto.LastUpdateTime)),
                    Mode = BindingMode.OneWay,
                    Converter = Converter.LongToDateTimeStringConverter.Instance
                }
            });
            grid.Columns.Add(new DataGridTextColumnExt()
            {
                Width = 80,
                Header = nameof(SmtIUserDto.TokenValidTime),
                Binding = new Binding()
                {
                    Path = new PropertyPath(nameof(SmtIUserDto.TokenValidTime)),
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
            btnAdd.SetBinding(Button.CommandProperty, new Binding(nameof(huypq.SmtWpfClient.ViewModel.SmtUserBaseViewModel<T>.AddCommand)));

            var btnUpdate = new Button()
            {
                Content = "Update",
                Width = 75,
                Margin = new Thickness(5)
            };
            grid.CustomMenuItems.Add(btnUpdate);
            btnUpdate.SetBinding(Button.CommandProperty, new Binding(nameof(huypq.SmtWpfClient.ViewModel.SmtUserBaseViewModel<T>.UpdateCommand)));

            var btnDelete = new Button()
            {
                Content = "Delete",
                Width = 75,
                Margin = new Thickness(5)
            };
            grid.CustomMenuItems.Add(btnDelete);
            btnDelete.SetBinding(Button.CommandProperty, new Binding(nameof(huypq.SmtWpfClient.ViewModel.SmtUserBaseViewModel<T>.DeleteCommand)));

            var btnResetPassword = new Button()
            {
                Content = "ResetPassword",
                Width = 110,
                Margin = new Thickness(5)
            };
            grid.CustomMenuItems.Add(btnResetPassword);
            btnResetPassword.SetBinding(Button.CommandProperty, new Binding(nameof(huypq.SmtWpfClient.ViewModel.SmtUserBaseViewModel<T>.ResetPasswordCommand)));

            Content = grid;
        }
    }
}
