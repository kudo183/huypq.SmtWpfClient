using huypq.SmtWpfClient.Abstraction;
using huypq.SmtShared;

namespace huypq.SmtWpfClient
{
    public class ViewModelFactory : IViewModelFactory
    {
        public class Options
        {
            public string ViewModelNamespace { get; set; }
            public System.Reflection.Assembly ViewModelAssembly { get; set; }
        }

        string _viewModelNamespace;
        System.Reflection.Assembly _viewModelAssembly;

        public ViewModelFactory(Options options)
        {
            _viewModelNamespace = options.ViewModelNamespace;
            _viewModelAssembly = options.ViewModelAssembly;
        }

        public object CreateViewModel<T>() where T : IDto
        {
            var vmName = NameManager.Instance.GetViewModelName<T>();
            var viewModelType = _viewModelAssembly.GetType(string.Format("{0}.{1}", _viewModelNamespace, vmName));
            return System.Activator.CreateInstance(viewModelType);
        }
    }
}
