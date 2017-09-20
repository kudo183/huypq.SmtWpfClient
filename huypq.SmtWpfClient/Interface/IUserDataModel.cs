using huypq.SmtShared;

namespace huypq.SmtWpfClient.Abstraction
{
    public interface IUserDataModel<T> : IUserDto, IDataModel<T> where T : IDto
    {
    }
}
