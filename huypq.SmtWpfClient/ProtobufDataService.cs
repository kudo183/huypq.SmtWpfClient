﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using huypq.SmtShared;
using huypq.SmtWpfClient.Abstraction;
using QueryBuilder;
using System.Net;
using System.IO;

namespace huypq.SmtWpfClient
{
    public class ProtobufDataService : IDataService
    {
        public class Options
        {
            public string RootUri { get; set; }
            public string Token { get; set; }
        }

        string _token;
        string _rootUri;

        public ProtobufDataService(Options option)
        {
            _token = option.Token;
            _rootUri = option.RootUri;
        }

        public void SetToken(string token)
        {
            _token = token;
        }
        public void SetRootUri(string rootUri)
        {
            _rootUri = rootUri;
        }

        public PagingResultDto<T> Get<T>(QueryExpression qe, string controller = null) where T : SmtIDto
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T>();
            }
            var uri = GetFullUri(controller, "get");
            var result = FromBytes<PagingResultDto<T>>(Post(uri, ToBytes(qe), "protobuf"));
            foreach (var item in result.Items)
            {
                item.SetCurrentValueAsOriginalValue();
            }
            return result;
        }

        public string Save<T>(List<T> changedItems, string controller = null) where T : SmtIDto
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T>();
            }
            var uri = GetFullUri(controller, "save");

            var result = Post(uri, ToBytes(changedItems));

            return GetStringFromBytes(result);
        }

        public string Add<T>(T item, string controller = null) where T : SmtIDto
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T>();
            }
            var uri = GetFullUri(controller, "add");

            var result = Post(uri, ToBytes(item));

            return GetStringFromBytes(result);
        }

        public string Update<T>(T item, string controller = null) where T : SmtIDto
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T>();
            }
            var uri = GetFullUri(controller, "update");

            var result = Post(uri, ToBytes(item));

            return GetStringFromBytes(result);
        }

        public string Delete<T>(T item, string controller = null) where T : SmtIDto
        {
            if (controller == null)
            {
                controller = NameManager.Instance.GetControllerName<T>();
            }
            var uri = GetFullUri(controller, "delete");

            var result = Post(uri, ToBytes(item));

            return GetStringFromBytes(result);
        }

        public List<T> Report<T>(string reportName, NameValueCollection reportParams)
        {
            return FromBytes<List<T>>(PostValues(GetFullUri("report", reportName), reportParams, "protobuf"));
        }

        public string Register(string tenantLoginName, string tenantName)
        {
            var uri = GetFullUri("smt", "register");

            var data = new NameValueCollection();
            data["user"] = tenantLoginName;
            data["tenantname"] = tenantName;

            //choose json response type because when respone is a string, json is better than protobuf
            var result = PostValues(uri, data, "json");

            return GetStringFromBytes(result);
        }

        public string TenantRequestToken(string email, string purpose)
        {
            var uri = GetFullUri("smt", "tenantrequesttoken");

            var data = new NameValueCollection();
            data["email"] = email;
            data["purpose"] = purpose;

            //choose json response type because when respone is a string, json is better than protobuf
            var result = PostValues(uri, data, "json");

            return GetStringFromBytes(result);
        }

        public string UserRequestToken(string email, string tenantName, string purpose)
        {
            var uri = GetFullUri("smt", "userrequesttoken");

            var data = new NameValueCollection();
            data["email"] = email;
            data["tenantname"] = tenantName;
            data["purpose"] = purpose;

            //choose json response type because when respone is a string, json is better than protobuf
            var result = PostValues(uri, data, "json");

            return GetStringFromBytes(result);
        }

        public string ResetPassword(string token, string pass)
        {
            var uri = GetFullUri("smt", "resetpassword");

            var data = new NameValueCollection();
            data["token"] = token;
            data["pass"] = pass;

            //choose json response type because when respone is a string, json is better than protobuf
            var result = PostValues(uri, data, "json");

            return GetStringFromBytes(result);
        }

        public void TenantLogin(string tenantLoginName, string password)
        {
            var uri = GetFullUri("smt", "tenantlogin");

            var data = new NameValueCollection();
            data["user"] = tenantLoginName;
            data["pass"] = password;

            //choose json response type because when respone is a string, json is better than protobuf
            var result = PostValues(uri, data, "json");

            _token = GetStringFromBytes(result);
        }

        public void UserLogin(string tenantName, string username, string password)
        {
            var uri = GetFullUri("smt", "userlogin");

            var data = new NameValueCollection();
            data["tenant"] = tenantName;
            data["user"] = username;
            data["pass"] = password;

            //choose json response type because when respone is a string, json is better than protobuf
            var result = PostValues(uri, data, "json");

            _token = GetStringFromBytes(result);
        }

        public string LockUser(string username, bool isLocked)
        {
            var uri = GetFullUri("smt", "lockuser");

            var data = new NameValueCollection();
            data["user"] = username;
            data["islocked"] = isLocked.ToString();

            //choose json response type because when respone is a string, json is better than protobuf
            var result = PostValues(uri, data, "json");

            return GetStringFromBytes(result);
        }

        public string ChangePassword(string currentPass, string newPass)
        {
            var uri = GetFullUri("smt", "changepassword");

            var data = new NameValueCollection();
            data["currentpass"] = currentPass;
            data["newpass"] = newPass;

            //choose json response type because when respone is a string, json is better than protobuf
            var result = PostValues(uri, data, "json");

            return GetStringFromBytes(result);
        }

        public void Logout()
        {
            var uri = GetFullUri("smt", "logout");

            var data = new NameValueCollection();

            //choose json response type because when respone is a string, json is better than protobuf
            var result = PostValues(uri, data, "json");
        }

        private byte[] PostValues(string uri, NameValueCollection reportParameters, string responseType)
        {
            var client = new MyWebClient();
            client.Headers["response"] = responseType;
            client.Headers["token"] = _token;

            return client.UploadValues(uri, reportParameters);
        }

        private byte[] Post(string uri, byte[] data, string responseType = "json")
        {
            var client = new MyWebClient();
            client.Headers["request"] = "protobuf";
            client.Headers["response"] = responseType;
            client.Headers["token"] = _token;

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
