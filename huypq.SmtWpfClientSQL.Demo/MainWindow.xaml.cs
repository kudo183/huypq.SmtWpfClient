using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClient.View;
using huypq.SmtWpfClient.ViewModel;
using System.Windows;
using System.Windows.Controls;
using SimpleDataGrid.ViewModel;
using System.Collections.Generic;
using huypq.wpf.Utils;
using Microsoft.Extensions.Logging;
using huypq.Logging;
using System.Reflection;
using huypq.SmtWpfClientSQL.Demo.Entities;
using System.Data.Entity;

namespace huypq.SmtWpfClientSQL.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Init();

            InitializeComponent();
        }

        private void Init()
        {
            LoginToken.Instance.TenantID = 1;

            Database.SetInitializer<SqlDbContext>(null);

            ServiceLocator.AddTypeMapping(typeof(ILoggerProvider), typeof(LoggerProviderWithOptions), true, new LoggerProviderWithOptions.Options()
            {
                Filter = (category, logLevel) => logLevel >= LogLevel.Information,
                IsIncludeScope = true,
                Processor = new LoggerBatchingProcessor(1000, 1024, 1024, @"logs", 31, 20 * 1024 * 1024)
            });

            ServiceLocator.AddTypeMapping(typeof(IViewModelFactory), typeof(ViewModelFactory), true, new ViewModelFactory.Options()
            {
                ViewModelNamespace = "huypq.SmtWpfClientSQL.Demo.ViewModel",
                ViewModelAssembly = System.Reflection.Assembly.GetExecutingAssembly()
            });

            ServiceLocator.AddTypeMapping(typeof(IDbContext), typeof(SqlDbContext), false, null);
            
            Settings.DataControllerNamespacePattern = "huypq.SmtWpfClientSQL.Demo.DataController.{0}Controller";

            Settings.DataControllerAssembly = Assembly.Load(new AssemblyName("huypq.SmtWpfClientSQL.Demo"));

            ServiceLocator.AddTypeMapping(typeof(IDataService), typeof(SqlDataService), true, new SqlDataService.Options()
            {
                Token = ""
            });
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (e.OriginalSource as Button);
            if (button == null)
            {
                return;
            }

            var viewType = button.Tag as System.Type;

            var view = System.Activator.CreateInstance(viewType);

            var w = new Window()
            {
                Title = button.Content.ToString(),
                WindowState = WindowState.Maximized,
                Content = view
            };
            w.Show();
        }
    }
}
