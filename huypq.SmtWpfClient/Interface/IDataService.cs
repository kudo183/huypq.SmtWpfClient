﻿using huypq.SmtShared;
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
        PagingResultDto<T> Get<T>(QueryBuilder.QueryExpression qe, string controller = null) where T : IDto;
        T GetByID<T>(int ID, string controller = null) where T : IDto;
        List<T> GetByListInt<T>(string path, List<int> listInt, string controller = null) where T : IDto;
        PagingResultDto<T> GetAll<T>(List<QueryBuilder.WhereExpression.IWhereOption> we, string controller = null) where T : IDto;
        PagingResultDto<T> GetUpdate<T>(List<QueryBuilder.WhereExpression.IWhereOption> we, string controller = null) where T : IDto;
        string Save<T>(List<T> changedItems, string controller = null) where T : IDto;
        string Add<T>(T item, string controller = null) where T : IDto;
        string Update<T>(T item, string controller = null) where T : IDto;
        string Delete<T>(T item, string controller = null) where T : IDto;
        PagingResultDto<T> Report<T>(string reportName, NameValueCollection reportParams);
        Stream GetFileByID(int id, string controller = null, string action = null);
        string AddFile(string filePath, string controller = null);
        string UpdateFile(int id, string filePath, string controller = null);
        string DeteleFile(int id, string controller = null);
    }
}
