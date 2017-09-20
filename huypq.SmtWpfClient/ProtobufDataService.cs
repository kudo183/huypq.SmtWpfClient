using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.IO;
using huypq.SmtShared;
using huypq.SmtShared.Constant;
using huypq.SmtWpfClient.Abstraction;
using huypq.QueryBuilder;
using Microsoft.Extensions.Logging;
using huypq.wpf.Utils;
using System.Linq;

namespace huypq.SmtWpfClient
{
    public class ProtobufDataService : IDataService
    {
        ILogger _logger = ServiceLocator.Get<ILoggerProvider>().CreateLogger<ProtobufDataService>();

        public class Options
        {
            public string RootUri { get; set; }
            public bool IsTenant { get; set; }
            public string Token { get; set; }
            public int DefaultPageSize { get; set; }
        }

        bool _isTenant;
        string _token;
        string _rootUri;
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

        public bool IsTenant()
        {
            return _isTenant;
        }

        public bool IsLoggedIn()
        {
            return string.IsNullOrEmpty(_token) == false;
        }

        public string GetBase64ProtectedToken()
        {
            return ProtectString(_token);
        }

        public ProtobufDataService(Options option)
        {
            _isTenant = option.IsTenant;
            _token = UnprotectString(option.Token);
            _rootUri = option.RootUri;
            _defaultPageSize = option.DefaultPageSize;

            if (_defaultPageSize == 0)
            {
                _defaultPageSize = 30;
            }
        }

        public PagingResultDto<T1> Get<T, T1>(QueryExpression qe, string controller = null) where T : IDto where T1 : IDataModel<T>, new()
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T, T1>();
            }

            if (qe.PageSize == 0)
            {
                qe.PageSize = _defaultPageSize;
            }

            var uri = GetFullUri(controller, ControllerAction.SmtEntityBase.Get);
            var responseBytes = Post(uri, ToBytes(qe), SerializeType.Protobuf);

            return ProcessPagingResult<T, T1>(responseBytes);
        }

        public T1 GetByID<T, T1>(int ID, string controller = null) where T : IDto where T1 : IDataModel<T>, new()
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T, T1>();
            }

            var uri = GetFullUri(controller, ControllerAction.SmtEntityBase.GetByID);
            var data = new NameValueCollection();
            data["id"] = ID.ToString();
            var responseBytes = PostValues(uri, data, SerializeType.Protobuf);

            return ProcessResult<T, T1>(responseBytes);
        }

        public List<T1> GetByListInt<T, T1>(string path, List<int> listInt, string controller = null) where T : IDto where T1 : IDataModel<T>, new()
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T, T1>();
            }

            if (listInt == null || listInt.Count == 0)
            {
                return new List<T1>();
            }

            var uri = GetFullUri(controller, ControllerAction.SmtEntityBase.Get);
            var qe = new QueryExpression();
            qe.PageSize = _defaultPageSize;
            qe.AddWhereOption<WhereExpression.WhereOptionIntList, List<int>>(
                WhereExpression.In, path, listInt.Distinct().ToList());
            var responseBytes = Post(uri, ToBytes(qe), SerializeType.Protobuf);

            return ProcessPagingResult<T, T1>(responseBytes).Items;
        }

        public PagingResultDto<T1> GetAll<T, T1>(List<WhereExpression.IWhereOption> we, string controller = null) where T : IDto where T1 : IDataModel<T>, new()
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T, T1>();
            }

            var uri = GetFullUri(controller, ControllerAction.SmtEntityBase.GetAll);
            var responseBytes = Post(uri, ToBytes(new QueryExpression() { WhereOptions = we }), SerializeType.Protobuf);
            
            return ProcessPagingResult<T, T1>(responseBytes);
        }

        public PagingResultDto<T1> GetUpdate<T, T1>(List<WhereExpression.IWhereOption> we, string controller = null) where T : IDto where T1 : IDataModel<T>, new()
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T, T1>();
            }

            var uri = GetFullUri(controller, ControllerAction.SmtEntityBase.GetUpdate);
            var responseBytes = Post(uri, ToBytes(new QueryExpression() { WhereOptions = we }), SerializeType.Protobuf);

            return ProcessPagingResult<T, T1>(responseBytes);
        }

        public string Save<T, T1>(List<T1> changedItems, string controller = null) where T : class, IDto where T1 : IDataModel<T>
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T, T1>();
            }
            var uri = GetFullUri(controller, ControllerAction.SmtEntityBase.Save);

            var changedDto = new List<T>();

            foreach (var item in changedItems)
            {
                changedDto.Add(item.ToDto());
            }

            var result = Post(uri, ToBytes(changedItems), SerializeType.Json);

            return GetStringFromBytes(result);
        }

        public string Add<T, T1>(T1 item, string controller = null) where T : class, IDto where T1 : IDataModel<T>
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T, T1>();
            }
            var uri = GetFullUri(controller, ControllerAction.SmtEntityBase.Add);

            var result = Post(uri, ToBytes(item.ToDto()), SerializeType.Json);

            return GetStringFromBytes(result);
        }

        public string Update<T, T1>(T1 item, string controller = null) where T : class, IDto where T1 : IDataModel<T>
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T, T1>();
            }
            var uri = GetFullUri(controller, ControllerAction.SmtEntityBase.Update);

            var result = Post(uri, ToBytes(item.ToDto()), SerializeType.Json);

            return GetStringFromBytes(result);
        }

        public string Delete<T, T1>(T1 item, string controller = null) where T : class, IDto where T1 : IDataModel<T>
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T, T1>();
            }
            var uri = GetFullUri(controller, ControllerAction.SmtEntityBase.Delete);

            var result = Post(uri, ToBytes(item.ToDto()), SerializeType.Json);

            return GetStringFromBytes(result);
        }

        public PagingResultDto<T> Report<T>(string reportName, NameValueCollection reportParams)
        {
            var controller = "report";
            var uri = GetFullUri(controller, reportName);
            var response = PostValues(uri, reportParams, SerializeType.Protobuf);
            var result = FromBytes<PagingResultDto<T>>(response);

            _logger.LogInformation("Report {0} {1:N0} bytes {2:N0} Items", controller, response.LongLength, result.Items.Count);

            return result;
        }

        public Stream GetFileByID(int id, string controller = null, string action = null)
        {
            if (controller == null)
            {
                controller = "SmtFile";
            }
            if (action == null)
            {
                action = ControllerAction.SmtFileBase.GetByID;
            }
            var uri = GetFullUri(controller, action);

            var client = new MyWebClient();
            client.Headers["token"] = _token;
            client.QueryString.Add("id", id.ToString());
            var result = client.DownloadData(uri);

            return new MemoryStream(result);
        }

        public string AddFile(string filePath, string controller = null)
        {
            if (controller == null)
            {
                controller = "SmtFile";
            }
            var uri = GetFullUri(controller, ControllerAction.SmtFileBase.Add);

            var client = new MyWebClient();
            client.Headers["response"] = SerializeType.Json;
            client.Headers["token"] = _token;

            var result = client.UploadFile(uri, filePath);

            return GetStringFromBytes(result);
        }

        public string UpdateFile(int id, string filePath, string controller = null)
        {
            if (controller == null)
            {
                controller = "SmtFile";
            }
            var uri = GetFullUri(controller, ControllerAction.SmtFileBase.Update);

            var client = new MyWebClient();
            client.Headers["response"] = SerializeType.Json;
            client.Headers["token"] = _token;
            client.QueryString = new NameValueCollection()
            {
                ["id"] = id.ToString()
            };
            var result = client.UploadFile(uri, filePath);

            return GetStringFromBytes(result);
        }

        public string DeteleFile(int id, string controller = null)
        {
            if (controller == null)
            {
                controller = "SmtFile";
            }
            var uri = GetFullUri(controller, ControllerAction.SmtFileBase.Delete);

            var client = new MyWebClient();
            client.Headers["response"] = SerializeType.Json;
            client.Headers["token"] = _token;

            var data = new NameValueCollection
            {
                ["id"] = id.ToString()
            };

            var response = client.UploadValues(uri, data);

            return GetStringFromBytes(response);
        }

        public string Register(string tenantLoginName, string tenantName)
        {
            var uri = GetFullUri(ControllerAction.Smt.ControllerName, ControllerAction.Smt.Register);

            var data = new NameValueCollection();
            data["user"] = tenantLoginName;
            data["tenantname"] = tenantName;

            //choose json response type because when respone is a string, json is better than protobuf
            var result = PostValues(uri, data, SerializeType.Json);

            return GetStringFromBytes(result);
        }

        public string TenantRequestToken(string email, string purpose)
        {
            var uri = GetFullUri(ControllerAction.Smt.ControllerName, ControllerAction.Smt.TenantRequestToken);

            var data = new NameValueCollection();
            data["email"] = email;
            data["purpose"] = purpose;

            //choose json response type because when respone is a string, json is better than protobuf
            var result = PostValues(uri, data, SerializeType.Json);

            return GetStringFromBytes(result);
        }

        public string UserRequestToken(string email, string tenantName, string purpose)
        {
            var uri = GetFullUri(ControllerAction.Smt.ControllerName, ControllerAction.Smt.UserRequestToken);

            var data = new NameValueCollection();
            data["email"] = email;
            data["tenantname"] = tenantName;
            data["purpose"] = purpose;

            //choose json response type because when respone is a string, json is better than protobuf
            var result = PostValues(uri, data, SerializeType.Json);

            return GetStringFromBytes(result);
        }

        public string ResetPassword(string token, string pass)
        {
            var uri = GetFullUri(ControllerAction.Smt.ControllerName, ControllerAction.Smt.ResetPassword);

            var data = new NameValueCollection();
            data["token"] = token;
            data["pass"] = pass;

            //choose json response type because when respone is a string, json is better than protobuf
            var result = PostValues(uri, data, SerializeType.Json);

            return GetStringFromBytes(result);
        }

        public void TenantLogin(string tenantLoginName, string password)
        {
            var uri = GetFullUri(ControllerAction.Smt.ControllerName, ControllerAction.Smt.TenantLogin);

            var data = new NameValueCollection();
            data["user"] = tenantLoginName;
            data["pass"] = password;

            //choose json response type because when respone is a string, json is better than protobuf
            var result = PostValues(uri, data, SerializeType.Json);

            _token = GetStringFromBytes(result);
            _isTenant = true;
        }

        public void UserLogin(string tenantName, string username, string password)
        {
            var uri = GetFullUri(ControllerAction.Smt.ControllerName, ControllerAction.Smt.UserLogin);

            var data = new NameValueCollection();
            data["tenant"] = tenantName;
            data["user"] = username;
            data["pass"] = password;

            //choose json response type because when respone is a string, json is better than protobuf
            var result = PostValues(uri, data, SerializeType.Json);

            _token = GetStringFromBytes(result);
            _isTenant = false;
        }

        public string LockUser(string username, bool isLocked)
        {
            var uri = GetFullUri(ControllerAction.Smt.ControllerName, ControllerAction.Smt.LockUser);

            var data = new NameValueCollection();
            data["user"] = username;
            data["islocked"] = isLocked.ToString();

            //choose json response type because when respone is a string, json is better than protobuf
            var result = PostValues(uri, data, SerializeType.Json);

            return GetStringFromBytes(result);
        }

        public string ChangePassword(string currentPass, string newPass)
        {
            var uri = GetFullUri(ControllerAction.Smt.ControllerName, ControllerAction.Smt.ChangePassword);

            var data = new NameValueCollection();
            data["currentpass"] = currentPass;
            data["newpass"] = newPass;

            //choose json response type because when respone is a string, json is better than protobuf
            var result = PostValues(uri, data, SerializeType.Json);

            return GetStringFromBytes(result);
        }

        public void Logout()
        {
            var uri = GetFullUri("smt", "logout");

            var data = new NameValueCollection();

            //choose json response type because when respone is a string, json is better than protobuf
            var result = PostValues(uri, data, SerializeType.Json);

            _token = string.Empty;
        }

        private byte[] PostValues(string uri, NameValueCollection reportParameters, string responseType)
        {
            var client = new MyWebClient();
            client.Headers["response"] = responseType;
            client.Headers["token"] = _token;

            int totalRequestLength = 0;
            foreach (var item in reportParameters.AllKeys)
            {
                totalRequestLength = reportParameters[item].Length + item.Length;
            }

            _logger.LogInformation("PostValues {0} {1:N0} bytes", uri, totalRequestLength);

            var response = client.UploadValues(uri, reportParameters);

            return response;
        }

        private byte[] Post(string uri, byte[] data, string responseType)
        {
            var client = new MyWebClient();
            client.Headers["request"] = SerializeType.Protobuf;
            client.Headers["response"] = responseType;
            client.Headers["token"] = _token;

            _logger.LogInformation("Post {0} {1:N0} bytes", uri, data.LongLength);

            var response = client.UploadData(uri, data);

            return response;
        }

        public T FromBytes<T>(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            {
                var r = ProtoBuf.Serializer.Deserialize<T>(ms);

                return r;
            }
        }

        public byte[] ToBytes<T>(T data)
        {
            using (var ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(ms, data);
                return ms.ToArray();
            }
        }

        private string GetStringFromBytes(byte[] bytes)
        {
            //skip begin, end double quote
            return System.Text.Encoding.UTF8.GetString(bytes, 1, bytes.Length - 2);
        }

        private string GetFullUri(string controller, string action)
        {
            var uri = string.Format("{0}/{1}/{2}",
                _rootUri, controller, action);

            return uri;
        }

        private PagingResultDto<T1> ProcessPagingResult<T, T1>(byte[] responseBytes) where T : IDto where T1 : IDataModel<T>, new()
        {
            var response = FromBytes<PagingResultDto<T>>(responseBytes);
            var result = new PagingResultDto<T1>()
            {
                LastUpdateTime = response.LastUpdateTime,
                PageCount = response.PageCount,
                PageIndex = response.PageIndex,
                TotalItemCount = response.TotalItemCount
            };
            foreach (var item in response.Items)
            {
                var dataModel = new T1();
                dataModel.FromDto(item);
                dataModel.SetCurrentValueAsOriginalValue();
                result.Items.Add(dataModel);
            }

            _logger.LogInformation("Get {0} {1:N0} bytes {2:N0} Items", NameManager.Instance.GetControllerName<T, T1>(), responseBytes.LongLength, result.Items.Count);

            return result;
        }

        private T1 ProcessResult<T, T1>(byte[] responseBytes) where T : IDto where T1 : IDataModel<T>, new()
        {
            var response = FromBytes<T>(responseBytes);

            _logger.LogInformation("GetByID {0} {1:N0} bytes", NameManager.Instance.GetControllerName<T, T1>(), responseBytes.LongLength);

            var result = new T1();
            result.FromDto(response);
            result.SetCurrentValueAsOriginalValue();

            return result;
        }

        private class MyWebClient : WebClient
        {
            protected override WebRequest GetWebRequest(Uri address)
            {
                HttpWebRequest request = base.GetWebRequest(address) as HttpWebRequest;
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                return request;
            }
        }
    }
}
