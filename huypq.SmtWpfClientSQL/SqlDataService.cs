using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using huypq.SmtShared;
using huypq.SmtWpfClient.Abstraction;
using huypq.QueryBuilder;
using System.Linq;
using System.IO;
using huypq.SmtShared.Constant;

namespace huypq.SmtWpfClientSQL
{
    public class SqlDataService : IDataService
    {
        public class Options
        {
            public string DbName { get; set; }
            public bool IsTenant { get; set; }
            public string Token { get; set; }
            public int DefaultPageSize { get; set; }
        }

        bool _isTenant;
        string _token;
        string _dbName;
        int _defaultPageSize;

        public SqlDataService(Options options)
        {
            _isTenant = options.IsTenant;
            _token = options.Token;
            _dbName = options.DbName;
            _defaultPageSize = options.DefaultPageSize;
        }

        public bool IsLoggedIn()
        {
            throw new NotImplementedException();
        }

        public bool IsTenant()
        {
            throw new NotImplementedException();
        }

        public string GetBase64ProtectedToken()
        {
            throw new NotImplementedException();
        }

        public string Register(string tenantLoginName, string tenantName)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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

        string IDataService.Save<T, T1>(List<T1> changedItems, string controller)
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

        string IDataService.Add<T, T1>(T1 item, string controller)
        {
            throw new NotImplementedException();
        }

        string IDataService.Update<T, T1>(T1 item, string controller)
        {
            throw new NotImplementedException();
        }

        string IDataService.Delete<T, T1>(T1 item, string controller)
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
    }
}
