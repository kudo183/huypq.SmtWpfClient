using huypq.SmtShared;

namespace huypq.SmtWpfClientSQL.Demo.Dto
{
    [Newtonsoft.Json.JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    [ProtoBuf.ProtoContract]
    public partial class tChiTietChuyenHangDonHangDto : IDto
    {
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(1)]
        public int ID { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(2)]
        public int MaChuyenHangDonHang { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(3)]
        public int MaChiTietDonHang { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(4)]
        public int SoLuong { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(5)]
        public int SoLuongTheoDonHang { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(6)]
        public int TenantID { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(7)]
        public long CreateTime { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(8)]
        public long LastUpdateTime { get; set;}

        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(100)]
        public int State { get; set; }
    }
}
