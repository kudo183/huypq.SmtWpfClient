using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class tChiTietChuyenHangDonHang : IEntity
    {
        public tChiTietChuyenHangDonHang()
        {
        }

        public int ID { get; set; }
        public int MaChuyenHangDonHang { get; set; }
        public int MaChiTietDonHang { get; set; }
        public int SoLuong { get; set; }
        public int SoLuongTheoDonHang { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        public tChuyenHangDonHang MaChuyenHangDonHangNavigation { get; set; }
        public tChiTietDonHang MaChiTietDonHangNavigation { get; set; }
		
    }
}
