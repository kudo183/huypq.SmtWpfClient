using huypq.SmtShared;

namespace huypq.SmtWpfClient.Abstraction
{
    public interface IViewModelFactory
    {
        object CreateViewModel<T>() where T : IDto;
    }
}
