using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using huypq.SmtShared;
using huypq.SmtWpfClient.Abstraction;
using QueryBuilder;
using System.Linq;

namespace huypq.SmtWpfClientSQL
{
    public class SqlDataService : IDataService
    {
        public PagingResultDto<T> Get<T>(QueryExpression qe, string controller = null) where T : IDto
        {
            var result = CallDataProvierMethod<T>("Get", qe) as PagingResultDto<T>;
            foreach (var item in result.Items)
            {
                item.SetCurrentValueAsOriginalValue();
            }
            return result;
        }

        public PagingResultDto<T> GetAll<T>(List<WhereExpression.IWhereOption> we, string controller = null) where T : IDto
        {
            var qe = new QueryExpression() { WhereOptions = we };
            var result = CallDataProvierMethod<T>("GetAll", qe) as PagingResultDto<T>;
            foreach (var item in result.Items)
            {
                item.SetCurrentValueAsOriginalValue();
            }
            return result;
        }

        public PagingResultDto<T> GetUpdate<T>(List<WhereExpression.IWhereOption> we, string controller = null) where T : IDto
        {
            var qe = new QueryExpression() { WhereOptions = we };
            var result = CallDataProvierMethod<T>("GetUpdate", qe) as PagingResultDto<T>;
            foreach (var item in result.Items)
            {
                item.SetCurrentValueAsOriginalValue();
            }
            return result;
        }

        public string Save<T>(List<T> changedItems, string controller = null) where T : IDto
        {
            var result = CallDataProvierMethod<T>("Save", changedItems) as string;
            return result;
        }

        public string LockUser(string username, bool isLocked)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public string Register(string tenantLoginName, string tenantName)
        {
            throw new NotImplementedException();
        }

        public List<T> Report<T>(string reportName, NameValueCollection reportParams)
        {
            throw new NotImplementedException();
        }

        public string ResetPassword(string token, string pass)
        {
            throw new NotImplementedException();
        }

        public string Add<T>(T item, string controller = null) where T : IDto
        {
            throw new NotImplementedException();
        }

        public string ChangePassword(string currentPass, string newPass)
        {
            throw new NotImplementedException();
        }

        public string Delete<T>(T item, string controller = null) where T : IDto
        {
            throw new NotImplementedException();
        }

        public void TenantLogin(string tenantLoginName, string password)
        {
            throw new NotImplementedException();
        }

        public string TenantRequestToken(string email, string purpose)
        {
            throw new NotImplementedException();
        }

        public string Update<T>(T item, string controller = null) where T : IDto
        {
            throw new NotImplementedException();
        }

        public void UserLogin(string tenantName, string username, string password)
        {
            throw new NotImplementedException();
        }

        public string UserRequestToken(string email, string tenantName, string purpose)
        {
            throw new NotImplementedException();
        }

        private object CallDataProvierMethod<T>(string methodName, params object[] parameters)
        {
            var dataProviderTypeName = typeof(T).Name.Replace("Dto", "DataProvider");
            var dataProviderType = System.Reflection.Assembly.GetEntryAssembly().GetTypes().First(p => p.Name == dataProviderTypeName);
            var methodInfo = dataProviderType.GetMethod(methodName);
            var dataProvider = Activator.CreateInstance(dataProviderType);
            return methodInfo.Invoke(dataProvider, parameters);
        }

        public T GetByID<T>(int ID, string controller = null) where T : IDto
        {
            throw new NotImplementedException();
        }

        public List<T> GetByListInt<T>(string path, List<int> listInt, string controller = null) where T : IDto
        {
            throw new NotImplementedException();
        }

        PagingResultDto<T> IDataService.Report<T>(string reportName, NameValueCollection reportParams)
        {
            throw new NotImplementedException();
        }
    }
}
