﻿using huypq.SmtShared;

namespace huypq.SmtWpfClientSQL.Demo.Dto
{
    [Newtonsoft.Json.JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    [ProtoBuf.ProtoContract]
    public partial class rLoaiHangDto : IDto
    {
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(1)]
        public int ID { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(2)]
        public string TenLoai { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(3)]
        public bool HangNhaLam { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(4)]
        public int TenantID { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(5)]
        public long CreateTime { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(6)]
        public long LastUpdateTime { get; set;}

        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(100)]
        public int State { get; set; }
    }
}
