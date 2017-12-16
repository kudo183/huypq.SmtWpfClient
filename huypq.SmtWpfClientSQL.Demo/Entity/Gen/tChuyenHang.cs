using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class tChuyenHang : IEntity
    {
        public tChuyenHang()
        {
            tChuyenHangDonHangMaChuyenHangNavigation = new HashSet<tChuyenHangDonHang>();
        }

        public int ID { get; set; }
        public int MaNhanVienGiaoHang { get; set; }
        public System.DateTime Ngay { get; set; }
        public System.TimeSpan? Gio { get; set; }
        public int TongDonHang { get; set; }
        public int TongSoLuongTheoDonHang { get; set; }
        public int TongSoLuongThucTe { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        public rNhanVien MaNhanVienGiaoHangNavigation { get; set; }
		
		public ICollection<tChuyenHangDonHang> tChuyenHangDonHangMaChuyenHangNavigation { get; set; }
    }
}
