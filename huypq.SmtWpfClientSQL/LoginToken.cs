using System;
using System.Collections.Generic;

namespace huypq.SmtWpfClientSQL
{
    public class LoginToken
    {
        static LoginToken _instance = new LoginToken();
        public static LoginToken Instance { get { return _instance; } }

        /// <summary>
        /// Tenant Name
        /// </summary>
        public string TenantName { get; set; }

        /// <summary>
        /// User Name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Id of the logged in user if login is user
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// TenantId of the tenant if login is tenant
        /// </summary>
        public int TenantID { get; set; }

        public bool IsTenant { get { return UserID == 0; } }

        /// <summary>
        /// Token creation time
        /// </summary>
        public long CreateTime { get; set; }

        /// <summary>
        /// key: controller, value: list of action
        /// </summary>
        public Dictionary<string, List<string>> Claims { get; set; }

        private LoginToken()
        {
            CreateTime = DateTime.UtcNow.Ticks;
            Claims = new Dictionary<string, List<string>>();
            TenantName = UserName = string.Empty;
        }

        public string ToBase64()
        {
            using (var ms = new System.IO.MemoryStream())
            using (var bw = new System.IO.BinaryWriter(ms))
            {
                bw.Write(TenantID);
                bw.Write(TenantName);
                bw.Write(UserID);
                bw.Write(UserName);
                bw.Write(CreateTime);
                bw.Write(Claims.Count);
                foreach (var claim in Claims)
                {
                    bw.Write(claim.Key);
                    bw.Write(claim.Value.Count);
                    foreach (var item in claim.Value)
                    {
                        bw.Write(item);
                    }
                }
                bw.Flush();
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        public void FromBase64(string str)
        {
            using (var ms = new System.IO.MemoryStream(Convert.FromBase64String(str)))
            using (var br = new System.IO.BinaryReader(ms))
            {
                TenantID = br.ReadInt32();
                TenantName = br.ReadString();
                UserID = br.ReadInt32();
                UserName = br.ReadString();
                CreateTime = br.ReadInt64();
                
                var claimsCount = br.ReadInt32();
                for (var i = 0; i < claimsCount; i++)
                {
                    var items = new List<string>();
                    Claims.Add(br.ReadString(), items);
                    var itemCount = br.ReadInt32();
                    for (var j = 0; j < itemCount; j++)
                    {
                        items.Add(br.ReadString());
                    }
                }
            }
        }
    }
}
