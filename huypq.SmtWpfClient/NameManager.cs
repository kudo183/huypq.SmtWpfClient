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

        public string GetControllerName<T>() where T : SmtIDto
        {
            return typeof(T).Name.Replace("Dto", "").ToLower();
        }

        public string GetViewName<T>() where T : SmtIDto
        {
            return typeof(T).Name.Replace("Dto", "View");
        }

        public string GetViewModelName<T>() where T : SmtIDto
        {
            return typeof(T).Name.Replace("Dto", "ViewModel");
        }
    }
}
