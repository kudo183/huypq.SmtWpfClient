using huypq.SmtShared;
using huypq.SmtWpfClient.Abstraction;
using SimpleDataGrid;
using System.Windows;
using System.Windows.Data;

namespace huypq.SmtWpfClient.View
{
    public class SmtUserClaimBaseView<T> : BaseView<T> where T : class, SmtIUserClaimDto, new()
    {
        public SmtUserClaimBaseView()
        {
            var grid = new EditableGridView();
            grid.Columns.Add(new DataGridTextColumnExt()
            {
                Width = 80,
                IsReadOnly = true,
                Header = nameof(SmtIUserClaimDto.UserID),
                Binding = new Binding()
                {
                    Path = new PropertyPath(nameof(SmtIUserClaimDto.UserID)),
                    Mode = BindingMode.OneWay
                }
            });
            grid.Columns.Add(new DataGridTextColumnExt()
            {
                Width = 180,
                Header = nameof(SmtIUserClaimDto.Claim),
                Binding = new Binding()
                {
                    Path = new PropertyPath(nameof(SmtIUserClaimDto.Claim)),
                    Mode = BindingMode.TwoWay,
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                }
            });
            grid.Columns.Add(new DataGridTextColumnExt()
            {
                Width = 80,
                IsReadOnly = true,
                Header = nameof(SmtIUserClaimDto.LastUpdateTime),
                Binding = new Binding()
                {
                    Path = new PropertyPath(nameof(SmtIUserClaimDto.LastUpdateTime)),
                    Mode = BindingMode.OneWay,
                    Converter = Converter.LongToDateTimeStringConverter.Instance
                }
            });

            Content = grid;
        }
    }
}
