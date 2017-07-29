using System;
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

            var views = new List<Type>();
            var complexViews = new List<Type>();

            foreach (var viewType in viewTypes.Where(p => p.Namespace != null && p.Namespace.EndsWith("View") && p.DeclaringType == null))
            {
                if (viewType.Name.EndsWith("ComplexView"))
                {
                    complexViews.Add(viewType);
                }
                else
                {
                    views.Add(viewType);
                }
            }

            sp.Children.Add(CreateTextBlock("ComplexView"));
            foreach (var item in complexViews.OrderBy(p => p.Name))
            {
                sp.Children.Add(CreateButton(item.Name, item));
            }

            sp.Children.Add(CreateTextBlock("View"));
            foreach (var item in views.OrderBy(p => p.Name))
            {
                sp.Children.Add(CreateButton(item.Name, item));
            }

            sp.Children.Add(CreateTextBlock("Report"));
            foreach (var viewType in viewTypes.Where(p => p.Namespace != null && p.Namespace.EndsWith("View.Report") && p.DeclaringType == null).OrderBy(p => p.Name))
            {
                sp.Children.Add(CreateButton(viewType.Name, viewType));
            }
        }

        private Button CreateButton(string name, object tag)
        {
            return new Button()
            {
                Content = name,
                Tag = tag,
                HorizontalContentAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(2)
            };
        }

        private TextBlock CreateTextBlock(string text)
        {
            return new TextBlock()
            {
                Text = text,
                Foreground = System.Windows.Media.Brushes.Blue,
                HorizontalAlignment = HorizontalAlignment.Center
            };
        }
    }
}
