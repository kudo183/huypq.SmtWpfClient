using huypq.SmtShared;

namespace huypq.SmtWpfClient.Abstraction
{
    public sealed class NameManager
    {
        private static readonly NameManager _instance = new NameManager();

        public static NameManager Instance
        {
            get { return _instance; }
        }

        public string GetControllerName<T, T1>() where T : IDto where T1 : IDataModel<T>
        {
            return typeof(T1).Name.Replace("DataModel", "").ToLower();
        }

        public string GetViewName<T, T1>() where T : IDto where T1 : IDataModel<T>
        {
            return typeof(T1).Name.Replace("DataModel", "View");
        }

        public string GetViewModelName<T, T1>() where T : IDto where T1 : IDataModel<T>
        {
            return typeof(T1).Name.Replace("DataModel", "ViewModel");
        }
    }
}
