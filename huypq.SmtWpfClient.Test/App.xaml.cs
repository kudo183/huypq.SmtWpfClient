using huypq.SmtShared.Test;
using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClient.View;
using System;
using System.Windows;

namespace huypq.SmtWpfClient.Test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Startup += App_Startup;
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var type = assembly.GetTypes();
            ServiceLocator.AddTypeMapping(typeof(IViewModelFactory), typeof(ViewModelFactory), true, new ViewModelFactory.Options()
            {
                ViewModelNamespace = "huypq.SmtWpfClient.Test",
                ViewModelAssembly = System.Reflection.Assembly.GetExecutingAssembly()
            });

            ServiceLocator.AddTypeMapping(typeof(IDataService), typeof(ProtobufDataService), true, new ProtobufDataService.Options()
            {
                RootUri = "http://localhost:5000",
                Token = "CfDJ8HfxzGkcxydGvmXx4q0JI-MS9kb7Gcei7mGxxPjWTA95BUBc-sK7YZYqmdKr1CyCNGOsvKro3oj4aW2hao7C-q17olAJuedGEofem-_MTQnlYvKcumCqDMk1u3IRNymBebvpvgSj4Zy7bJrQZC7vJH1xrqLnKVpBUhdKqSUuW7do"
            });

            //apply Window Style in App.xaml to all Window type
            FrameworkElement.StyleProperty.OverrideMetadata(typeof(Window), new FrameworkPropertyMetadata
            {
                DefaultValue = FindResource(typeof(Window))
            });

            //apply language to all FrameworkElement
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata()
            {
                DefaultValue = System.Windows.Markup.XmlLanguage.GetLanguage(System.Threading.Thread.CurrentThread.CurrentUICulture.Name)
            });

            ReferenceDataManager<TestDataDto>.Instance.SetOrderChecker((p1, p2) =>
            {
                return string.Compare(p1.Data, p2.Data) <= 0;
            });

            StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);
        }
    }
}
