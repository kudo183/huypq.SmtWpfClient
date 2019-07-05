using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using huypq.SmtShared;
using huypq.SmtWpfClient.Abstraction;
using huypq.QueryBuilder;
using System.Linq;
using System.IO;
using huypq.SmtShared.Constant;
using System.Threading.Tasks;

namespace huypq.SmtWpfClientSQL
{
    public class SqlDataService : IDataService
    {
        public class Options
        {
            public string Token { get; set; }
            public int DefaultPageSize { get; set; }
        }
        
        int _defaultPageSize;

        private string ProtectString(string text)
        {
            if (string.IsNullOrEmpty(text) == true)
            {
                return string.Empty;
            }

            try
            {
                var bytes = System.Text.Encoding.ASCII.GetBytes(text);
                var protectedBytes = System.Security.Cryptography.ProtectedData.Protect(bytes, null, System.Security.Cryptography.DataProtectionScope.CurrentUser);
                return Convert.ToBase64String(protectedBytes);
            }
            catch { }

            return string.Empty;
        }

        private string UnprotectString(string base64)
        {
            if (string.IsNullOrEmpty(base64) == true)
            {
                return string.Empty;
            }

            try
            {
                var bytes = Convert.FromBase64String(base64);
                var unprotectedBytes = System.Security.Cryptography.ProtectedData.Unprotect(bytes, null, System.Security.Cryptography.DataProtectionScope.CurrentUser);
                return System.Text.Encoding.ASCII.GetString(unprotectedBytes);
            }
            catch { }

            return string.Empty;
        }

        public SqlDataService(Options options)
        {
            var token = UnprotectString(options.Token);
            if (string.IsNullOrEmpty(token) == false)
            {
                LoginToken.Instance.FromBase64(token);
            }

            _defaultPageSize = options.DefaultPageSize;

            if (_defaultPageSize == 0)
            {
                _defaultPageSize = 30;
            }
        }

        public bool IsLoggedIn()
        {
            return LoginToken.Instance.TenantID != 0;
        }

        public bool IsTenant()
        {
            return LoginToken.Instance.IsTenant;
        }

        public string GetBase64ProtectedToken()
        {
            return ProtectString(LoginToken.Instance.ToBase64());
        }

        public string Register(string tenantLoginName, string tenantName)
        {
            var data = new NameValueCollection();
            data["user"] = tenantLoginName;
            data["tenantname"] = tenantName;

            var dataProvider = DataServiceUtils.GetDataController(ControllerAction.Smt.ControllerName);

            var result = dataProvider.ActionInvoker(ControllerAction.Smt.Register, data) as string;

            return result;
        }

        public string TenantRequestToken(string email, string purpose)
        {
            throw new NotImplementedException();
        }

        public string UserRequestToken(string email, string tenantName, string purpose)
        {
            throw new NotImplementedException();
        }

        public string ResetPassword(string token, string pass)
        {
            throw new NotImplementedException();
        }

        public void TenantLogin(string tenantLoginName, string password)
        {
            var data = new NameValueCollection();
            data["user"] = tenantLoginName;
            data["pass"] = password;

            var dataProvider = DataServiceUtils.GetDataController(ControllerAction.Smt.ControllerName);

            dataProvider.ActionInvoker(ControllerAction.Smt.TenantLogin, data);
        }

        public void UserLogin(string tenantName, string username, string password)
        {
            throw new NotImplementedException();
        }

        public string LockUser(string username, bool isLocked)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public string ChangePassword(string currentPass, string newPass)
        {
            throw new NotImplementedException();
        }

        public PagingResultDto<T1> Get<T, T1>(QueryExpression qe, string controller = null)
            where T : IDto
            where T1 : IDataModel<T>, new()
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T, T1>();
            }

            if (qe.PageSize == 0)
            {
                qe.PageSize = _defaultPageSize;
            }

            var dataProvider = DataServiceUtils.GetDataController(controller);

            var result = dataProvider.ActionInvoker(ControllerAction.SmtEntityBase.Get, qe) as PagingResultDto<T>;

            return DataServiceUtils.ProcessPagingResult<T, T1>(result);
        }

        public T1 GetByID<T, T1>(int ID, string controller = null)
            where T : IDto
            where T1 : IDataModel<T>, new()
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T, T1>();
            }

            var dataProvider = DataServiceUtils.GetDataController(controller);

            var result = (T)dataProvider.ActionInvoker(ControllerAction.SmtEntityBase.GetByID, ID);

            return DataServiceUtils.ProcessResult<T, T1>(result);
        }

        public List<T1> GetByListInt<T, T1>(string path, List<int> listInt, string controller = null)
            where T : IDto
            where T1 : IDataModel<T>, new()
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T, T1>();
            }

            if (listInt == null || listInt.Count == 0)
            {
                return new List<T1>();
            }

            var qe = new QueryExpression();
            qe.PageSize = _defaultPageSize;
            qe.AddWhereOption<WhereExpression.WhereOptionIntList, List<int>>(
                WhereExpression.In, path, listInt.Distinct().ToList());

            var dataProvider = DataServiceUtils.GetDataController(controller);

            var result = dataProvider.ActionInvoker(ControllerAction.SmtEntityBase.Get, qe) as PagingResultDto<T>;

            return DataServiceUtils.ProcessPagingResult<T, T1>(result).Items;
        }

        public PagingResultDto<T1> GetAll<T, T1>(List<WhereExpression.IWhereOption> we, string controller = null)
            where T : IDto
            where T1 : IDataModel<T>, new()
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T, T1>();
            }

            var dataProvider = DataServiceUtils.GetDataController(controller);

            var result = dataProvider.ActionInvoker(ControllerAction.SmtEntityBase.GetAll, new QueryExpression() { WhereOptions = we }) as PagingResultDto<T>;

            return DataServiceUtils.ProcessPagingResult<T, T1>(result);
        }

        public PagingResultDto<T1> GetUpdate<T, T1>(List<WhereExpression.IWhereOption> we, string controller = null)
            where T : IDto
            where T1 : IDataModel<T>, new()
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T, T1>();
            }

            var dataProvider = DataServiceUtils.GetDataController(controller);

            var result = dataProvider.ActionInvoker(ControllerAction.SmtEntityBase.GetUpdate, new QueryExpression() { WhereOptions = we }) as PagingResultDto<T>;

            return DataServiceUtils.ProcessPagingResult<T, T1>(result);
        }

        public string Save<T, T1>(List<T1> changedItems, string controller) where T : IDto where T1 : IDataModel<T>
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T, T1>();
            }

            var changedDto = new List<T>();

            foreach (var item in changedItems)
            {
                changedDto.Add(item.ToDto());
            }

            var dataProvider = DataServiceUtils.GetDataController(controller);

            return dataProvider.ActionInvoker(ControllerAction.SmtEntityBase.Save, changedDto) as string;
        }

        public string Add<T, T1>(T1 item, string controller) where T : IDto where T1 : IDataModel<T>
        {
            throw new NotImplementedException();
        }

        public string Update<T, T1>(T1 item, string controller) where T : IDto where T1 : IDataModel<T>
        {
            throw new NotImplementedException();
        }

        public string Delete<T, T1>(T1 item, string controller) where T : IDto where T1 : IDataModel<T>
        {
            throw new NotImplementedException();
        }

        public PagingResultDto<T> Report<T>(string reportName, NameValueCollection reportParams)
        {
            throw new NotImplementedException();
        }

        public Stream GetFileByID(int id, string controller = null, string action = null)
        {
            throw new NotImplementedException();
        }

        public string AddFile(string filePath, string controller = null)
        {
            throw new NotImplementedException();
        }

        public string UpdateFile(int id, string filePath, string controller = null)
        {
            throw new NotImplementedException();
        }

        public string DeteleFile(int id, string controller = null)
        {
            throw new NotImplementedException();
        }

        public Task<PagingResultDto<T1>> CustomFormPostActionWithPagingResultAsync<T, T1>(string controller, string action, List<KeyValuePair<string, string>> parameters)
            where T : IDto
            where T1 : IDataModel<T>, new()
        {
            throw new NotImplementedException();
        }
    }
}
