using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace huypq.SmtWpfClient.View
{
    /// <summary>
    /// Interaction logic for AllView.xaml
    /// </summary>
    public partial class AllView : UserControl
    {
        private Dictionary<string, UserControl> _views = new Dictionary<string, UserControl>();
        public AllView()
        {
            InitializeComponent();

            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject()) == true)
            {
                return;
            }

            var viewTypes = System.Reflection.Assembly.GetEntryAssembly().GetTypes().ToList();

            foreach (var viewType in viewTypes.Where(p => p.Namespace != null && p.Namespace.EndsWith("View") && p.DeclaringType == null).OrderBy(p => p.Name))
            {
                sp.Children.Add(new Button()
                {
                    Content = viewType.Name,
                    Tag = viewType,
                    HorizontalContentAlignment = HorizontalAlignment.Left
                });
            }

            foreach (var viewType in viewTypes.Where(p => p.Namespace != null && p.Namespace.EndsWith("View.Report") && p.DeclaringType == null).OrderBy(p => p.Name))
            {
                sp.Children.Add(new Button()
                {
                    Content = viewType.Name,
                    Tag = viewType,
                    HorizontalContentAlignment = HorizontalAlignment.Left
                });
            }
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            var button = (e.OriginalSource as Button);
            if (button == null)
            {
                return;
            }

            var viewType = button.Tag as System.Type;
            var typeName = viewType.Name;
            if (_views.ContainsKey(typeName) == false)
            {
                _views[typeName] = System.Activator.CreateInstance(viewType) as UserControl;
            }

            brd.Child = _views[typeName];
        }
    }
}
