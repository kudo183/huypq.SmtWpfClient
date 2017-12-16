using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class tDonHang : IEntity
    {
        public tDonHang()
        {
            tChiTietDonHangMaDonHangNavigation = new HashSet<tChiTietDonHang>();
            tChuyenHangDonHangMaDonHangNavigation = new HashSet<tChuyenHangDonHang>();
        }

        public int ID { get; set; }
        public int MaKhachHang { get; set; }
        public int? MaChanh { get; set; }
        public System.DateTime Ngay { get; set; }
        public bool Xong { get; set; }
        public int MaKhoHang { get; set; }
        public int TongSoLuong { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        public rKhachHang MaKhachHangNavigation { get; set; }
        public rChanh MaChanhNavigation { get; set; }
        public rKhoHang MaKhoHangNavigation { get; set; }
		
		public ICollection<tChiTietDonHang> tChiTietDonHangMaDonHangNavigation { get; set; }
		public ICollection<tChuyenHangDonHang> tChuyenHangDonHangMaDonHangNavigation { get; set; }
    }
}
