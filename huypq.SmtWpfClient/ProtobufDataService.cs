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

namespace huypq.SmtWpfClient
{
    public class ProtobufDataService : IDataService
    {
        ILogger _logger = ServiceLocator.Get<ILoggerProvider>().CreateLogger<ProtobufDataService>();

        public class Options
        {
            public string RootUri { get; set; }
            public string Token { get; set; }
            public int DefaultPageSize { get; set; }
        }

        string _token;
        string _rootUri;
        int _defaultPageSize;

        public ProtobufDataService(Options option)
        {
            _token = option.Token;
            _rootUri = option.RootUri;
            _defaultPageSize = option.DefaultPageSize;

            if (_defaultPageSize == 0)
            {
                _defaultPageSize = 30;
            }
        }

        public PagingResultDto<T> Get<T>(QueryExpression qe, string controller = null) where T : IDto
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T>();
            }

            if (qe.PageSize == 0)
            {
                qe.PageSize = _defaultPageSize;
            }

            var uri = GetFullUri(controller, ControllerAction.SmtEntityBase.Get);
            var response = Post(uri, ToBytes(qe), SerializeType.Protobuf);
            var result = FromBytes<PagingResultDto<T>>(response);
            foreach (var item in result.Items)
            {
                item.SetCurrentValueAsOriginalValue();
            }

            _logger.LogInformation("Get {0} {1:N0} bytes {2:N0} Items", controller, response.LongLength, result.Items.Count);

            return result;
        }

        public T GetByID<T>(int ID, string controller = null) where T : IDto
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T>();
            }

            var uri = GetFullUri(controller, ControllerAction.SmtEntityBase.GetByID);
            var data = new NameValueCollection();
            data["id"] = ID.ToString();
            var response = PostValues(uri, data, SerializeType.Protobuf);
            var result = FromBytes<T>(response);

            _logger.LogInformation("GetByID {0} {1:N0} bytes", controller, response.LongLength);

            return result;
        }

        public List<T> GetByListInt<T>(string path, List<int> listInt, string controller = null) where T : IDto
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T>();
            }

            if (listInt == null || listInt.Count == 0)
            {
                return new List<T>();
            }

            var uri = GetFullUri(controller, ControllerAction.SmtEntityBase.Get);
            var qe = new QueryExpression();
            qe.PageSize = _defaultPageSize;
            qe.AddWhereOption<WhereExpression.WhereOptionIntList, List<int>>(
                WhereExpression.In, path, listInt);
            var response = Post(uri, ToBytes(qe), SerializeType.Protobuf);
            var result = FromBytes<PagingResultDto<T>>(response);
            foreach (var item in result.Items)
            {
                item.SetCurrentValueAsOriginalValue();
            }

            _logger.LogInformation("GetByListInt {0} {1:N0} bytes", controller, response.LongLength);

            return result.Items;
        }

        public PagingResultDto<T> GetAll<T>(List<WhereExpression.IWhereOption> we, string controller = null) where T : IDto
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T>();
            }

            var uri = GetFullUri(controller, ControllerAction.SmtEntityBase.GetAll);
            var response = Post(uri, ToBytes(new QueryExpression() { WhereOptions = we }), SerializeType.Protobuf);
            var result = FromBytes<PagingResultDto<T>>(response);
            foreach (var item in result.Items)
            {
                item.SetCurrentValueAsOriginalValue();
            }

            _logger.LogInformation("GetAll {0} {1:N0} bytes {2:N0} Items", controller, response.LongLength, result.Items.Count);

            return result;
        }

        public PagingResultDto<T> GetUpdate<T>(List<WhereExpression.IWhereOption> we, string controller = null) where T : IDto
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T>();
            }

            var uri = GetFullUri(controller, ControllerAction.SmtEntityBase.GetUpdate);
            var response = Post(uri, ToBytes(new QueryExpression() { WhereOptions = we }), SerializeType.Protobuf);
            var result = FromBytes<PagingResultDto<T>>(response);
            foreach (var item in result.Items)
            {
                item.SetCurrentValueAsOriginalValue();
            }

            _logger.LogInformation("GetUpdate {0} {1:N0} bytes {2:N0} Items", controller, response.LongLength, result.Items.Count);

            return result;
        }

        public string Save<T>(List<T> changedItems, string controller = null) where T : IDto
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T>();
            }
            var uri = GetFullUri(controller, ControllerAction.SmtEntityBase.Save);

            var result = Post(uri, ToBytes(changedItems), SerializeType.Json);

            return GetStringFromBytes(result);
        }

        public string Add<T>(T item, string controller = null) where T : IDto
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T>();
            }
            var uri = GetFullUri(controller, ControllerAction.SmtEntityBase.Add);

            var result = Post(uri, ToBytes(item), SerializeType.Json);

            return GetStringFromBytes(result);
        }

        public string Update<T>(T item, string controller = null) where T : IDto
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T>();
            }
            var uri = GetFullUri(controller, ControllerAction.SmtEntityBase.Update);

            var result = Post(uri, ToBytes(item), SerializeType.Json);

            return GetStringFromBytes(result);
        }

        public string Delete<T>(T item, string controller = null) where T : IDto
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T>();
            }
            var uri = GetFullUri(controller, ControllerAction.SmtEntityBase.Delete);

            var result = Post(uri, ToBytes(item), SerializeType.Json);

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
