using huypq.SmtShared;

namespace huypq.SmtWpfClient.Abstraction
{
    public interface IUserClaimDataModel<T> : IUserClaimDto, IDataModel<T> where T : IDto
    {
    }
}
