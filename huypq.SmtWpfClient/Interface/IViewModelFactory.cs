using huypq.SmtShared;

namespace huypq.SmtWpfClient.Abstraction
{
    public interface IViewModelFactory
    {
        object CreateViewModel<T, T1>() where T : class, IDto, new() where T1 : class, IDataModel<T>, new();
    }
}
