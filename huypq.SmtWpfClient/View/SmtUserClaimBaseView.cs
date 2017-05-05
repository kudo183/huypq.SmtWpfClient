using huypq.SmtShared;
using huypq.SmtWpfClient.Abstraction;
using SimpleDataGrid;
using System.Windows;
using System.Windows.Data;

namespace huypq.SmtWpfClient.View
{
    public class SmtUserClaimBaseView<T> : BaseView<T> where T : class, IUserClaimDto, new()
    {
        public SmtUserClaimBaseView()
        {
            var grid = new EditableGridView();
            grid.Columns.Add(new DataGridTextColumnExt()
            {
                Width = 80,
                IsReadOnly = true,
                Header = nameof(IUserClaimDto.UserID),
                Binding = new Binding()
                {
                    Path = new PropertyPath(nameof(IUserClaimDto.UserID)),
                    Mode = BindingMode.OneWay
                }
            });
            grid.Columns.Add(new DataGridTextColumnExt()
            {
                Width = 180,
                Header = nameof(IUserClaimDto.Claim),
                Binding = new Binding()
                {
                    Path = new PropertyPath(nameof(IUserClaimDto.Claim)),
                    Mode = BindingMode.TwoWay,
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                }
            });
            grid.Columns.Add(new DataGridTextColumnExt()
            {
                Width = 80,
                IsReadOnly = true,
                Header = nameof(IUserClaimDto.LastUpdateTime),
                Binding = new Binding()
                {
                    Path = new PropertyPath(nameof(IUserClaimDto.LastUpdateTime)),
                    Mode = BindingMode.OneWay,
                    Converter = Converter.LongToDateTimeStringConverter.Instance
                }
            });

            Content = grid;
        }
    }
}
