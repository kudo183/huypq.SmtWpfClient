using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace huypq.SmtWpfClient.View
{
    /// <summary>
    /// Interaction logic for DataEditor.xaml
    /// </summary>
    public partial class DataEditor : UserControl
    {
        public enum DataType
        {
            Text,
            Number,
            Date
        }

        private bool DialogResult;

        public DataEditor()
        {
            InitializeComponent();
        }

        public void Add(string propertyName, string propertyPath, DataType dataType)
        {
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            var title = new TextBlock() { Text = propertyName, Margin = new Thickness(5) };
            Grid.SetColumn(title, 0);
            Grid.SetRow(title, grid.RowDefinitions.Count - 1);
            grid.Children.Add(title);
            switch (dataType)
            {
                case DataType.Text:
                    var tb = new TextBox() { Margin = new Thickness(5) };
                    BindingOperations.SetBinding(tb, TextBox.TextProperty, new Binding()
                    {
                        Path = new PropertyPath(propertyPath)
                    });
                    Grid.SetColumn(tb, 1);
                    Grid.SetRow(tb, grid.RowDefinitions.Count - 1);
                    grid.Children.Add(tb);
                    break;
                case DataType.Date:
                    var dp = new DatePicker() { Margin = new Thickness(5) };
                    BindingOperations.SetBinding(dp, DatePicker.SelectedDateProperty, new Binding()
                    {
                        Path = new PropertyPath(propertyPath)
                    });
                    Grid.SetColumn(dp, 1);
                    Grid.SetRow(dp, grid.RowDefinitions.Count - 1);
                    grid.Children.Add(dp);
                    break;
            }
        }

        Window w;
        public bool? ShowDialog(double width, double height)
        {
            if (w == null)
            {
                w = new Window()
                {
                    WindowStartupLocation = WindowStartupLocation.CenterScreen,
                    Content = this,
                    ResizeMode = ResizeMode.NoResize
                };
            }
            w.Width = width;
            w.Height = height;
            w.ShowDialog();
            return DialogResult;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            w.Close();
        }
    }
}
