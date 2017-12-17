using huypq.SmtShared;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

namespace huypq.SmtWpfClient.Abstraction
{
    public interface IDataService
    {
        bool IsLoggedIn();
        bool IsTenant();
        string GetBase64ProtectedToken();
        string Register(string tenantLoginName, string tenantName);
        string TenantRequestToken(string email, string purpose);
        string UserRequestToken(string email, string tenantName, string purpose);
        string ResetPassword(string token, string pass);
        void TenantLogin(string tenantLoginName, string password);
        void UserLogin(string tenantName, string username, string password);
        string LockUser(string username, bool isLocked);
        void Logout();
        string ChangePassword(string currentPass, string newPass);

        PagingResultDto<T1> Get<T, T1>(QueryBuilder.QueryExpression qe, string controller = null) where T : IDto where T1 : IDataModel<T>, new();
        T1 GetByID<T, T1>(int ID, string controller = null) where T : IDto where T1 : IDataModel<T>, new();
        List<T1> GetByListInt<T, T1>(string path, List<int> listInt, string controller = null) where T : IDto where T1 : IDataModel<T>, new();
        PagingResultDto<T1> GetAll<T, T1>(List<QueryBuilder.WhereExpression.IWhereOption> we, string controller = null) where T : IDto where T1 : IDataModel<T>, new();
        PagingResultDto<T1> GetUpdate<T, T1>(List<QueryBuilder.WhereExpression.IWhereOption> we, string controller = null) where T : IDto where T1 : IDataModel<T>, new();
        string Save<T, T1>(List<T1> changedItems, string controller = null) where T : IDto where T1 : IDataModel<T>;
        string Add<T, T1>(T1 item, string controller = null) where T : IDto where T1 : IDataModel<T>;
        string Update<T, T1>(T1 item, string controller = null) where T : IDto where T1 : IDataModel<T>;
        string Delete<T, T1>(T1 item, string controller = null) where T : IDto where T1 : IDataModel<T>;

        PagingResultDto<T> Report<T>(string reportName, NameValueCollection reportParams);

        Stream GetFileByID(int id, string controller = null, string action = null);
        string AddFile(string filePath, string controller = null);
        string UpdateFile(int id, string filePath, string controller = null);
        string DeteleFile(int id, string controller = null);
    }
}
