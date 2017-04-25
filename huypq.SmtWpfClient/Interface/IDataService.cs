using huypq.SmtShared;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace huypq.SmtWpfClient.Abstraction
{
    public interface IDataService
    {
        void SetToken(string token);
        void SetRootUri(string rootUri);
        string Register(string tenantLoginName, string tenantName);
        string TenantRequestToken(string email, string purpose);
        string UserRequestToken(string email, string tenantName, string purpose);
        string ResetPassword(string token, string pass);
        void TenantLogin(string tenantLoginName, string password);
        void UserLogin(string tenantName, string username, string password);
        void ResetUserPassword(string username);
        void Logout();
        string ChangePassword(string currentPass, string newPass);
        PagingResultDto<T> Get<T>(QueryBuilder.QueryExpression qe) where T : SmtIDto;
        string Save<T>(List<T> changedItems) where T : SmtIDto;
        string Add<T>(T item) where T : SmtIDto;
        string Update<T>(T item) where T : SmtIDto;
        string Delete<T>(T item) where T : SmtIDto;
        List<T> Report<T>(string reportName, NameValueCollection reportParams);
    }
}
