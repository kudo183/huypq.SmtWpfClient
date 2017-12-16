using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class tChiTietDonHang : IEntity
    {
        public tChiTietDonHang()
        {
            tChiTietChuyenHangDonHangMaChiTietDonHangNavigation = new HashSet<tChiTietChuyenHangDonHang>();
            tChiTietToaHangMaChiTietDonHangNavigation = new HashSet<tChiTietToaHang>();
        }

        public int ID { get; set; }
        public int MaDonHang { get; set; }
        public int MaMatHang { get; set; }
        public int SoLuong { get; set; }
        public bool Xong { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        public tDonHang MaDonHangNavigation { get; set; }
        public tMatHang MaMatHangNavigation { get; set; }
		
		public ICollection<tChiTietChuyenHangDonHang> tChiTietChuyenHangDonHangMaChiTietDonHangNavigation { get; set; }
		public ICollection<tChiTietToaHang> tChiTietToaHangMaChiTietDonHangNavigation { get; set; }
    }
}
