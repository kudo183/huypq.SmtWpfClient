using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class tNhapHang : IEntity
    {
        public tNhapHang()
        {
            tChiTietNhapHangMaNhapHangNavigation = new HashSet<tChiTietNhapHang>();
        }

        public int ID { get; set; }
        public int MaNhanVien { get; set; }
        public int MaKhoHang { get; set; }
        public int MaNhaCungCap { get; set; }
        public System.DateTime Ngay { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        public rNhanVien MaNhanVienNavigation { get; set; }
        public rKhoHang MaKhoHangNavigation { get; set; }
        public rNhaCungCap MaNhaCungCapNavigation { get; set; }
		
		public ICollection<tChiTietNhapHang> tChiTietNhapHangMaNhapHangNavigation { get; set; }
    }
}
