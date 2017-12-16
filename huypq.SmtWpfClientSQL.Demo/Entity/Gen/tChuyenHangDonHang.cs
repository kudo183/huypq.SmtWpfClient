using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class tChuyenHangDonHang : IEntity
    {
        public tChuyenHangDonHang()
        {
            tChiTietChuyenHangDonHangMaChuyenHangDonHangNavigation = new HashSet<tChiTietChuyenHangDonHang>();
        }

        public int ID { get; set; }
        public int MaChuyenHang { get; set; }
        public int MaDonHang { get; set; }
        public int TongSoLuongTheoDonHang { get; set; }
        public int TongSoLuongThucTe { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        public tChuyenHang MaChuyenHangNavigation { get; set; }
        public tDonHang MaDonHangNavigation { get; set; }
		
		public ICollection<tChiTietChuyenHangDonHang> tChiTietChuyenHangDonHangMaChuyenHangDonHangNavigation { get; set; }
    }
}
