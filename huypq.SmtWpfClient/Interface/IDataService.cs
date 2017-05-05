using huypq.SmtShared;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace huypq.SmtWpfClient.Abstraction
{
    public interface IDataService
    {
        string Register(string tenantLoginName, string tenantName);
        string TenantRequestToken(string email, string purpose);
        string UserRequestToken(string email, string tenantName, string purpose);
        string ResetPassword(string token, string pass);
        void TenantLogin(string tenantLoginName, string password);
        void UserLogin(string tenantName, string username, string password);
        string LockUser(string username, bool isLocked);
        void Logout();
        string ChangePassword(string currentPass, string newPass);
        PagingResultDto<T> Get<T>(QueryBuilder.QueryExpression qe, string controller = null) where T : IDto;
        PagingResultDto<T> GetAll<T>(List<QueryBuilder.WhereExpression.IWhereOption> we, string controller = null) where T : IDto;
        PagingResultDto<T> GetUpdate<T>(List<QueryBuilder.WhereExpression.IWhereOption> we, string controller = null) where T : IDto;
        string Save<T>(List<T> changedItems, string controller = null) where T : IDto;
        string Add<T>(T item, string controller = null) where T : IDto;
        string Update<T>(T item, string controller = null) where T : IDto;
        string Delete<T>(T item, string controller = null) where T : IDto;
        List<T> Report<T>(string reportName, NameValueCollection reportParams);
    }
}
