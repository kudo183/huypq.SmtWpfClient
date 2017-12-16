using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class rNhanVien : IEntity
    {
        public rNhanVien()
        {
            tChiPhiMaNhanVienGiaoHangNavigation = new HashSet<tChiPhi>();
            tChuyenHangMaNhanVienGiaoHangNavigation = new HashSet<tChuyenHang>();
            tChuyenKhoMaNhanVienNavigation = new HashSet<tChuyenKho>();
            tNhapHangMaNhanVienNavigation = new HashSet<tNhapHang>();
        }

        public int ID { get; set; }
        public int MaPhuongTien { get; set; }
        public string TenNhanVien { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        public rPhuongTien MaPhuongTienNavigation { get; set; }
		
		public ICollection<tChiPhi> tChiPhiMaNhanVienGiaoHangNavigation { get; set; }
		public ICollection<tChuyenHang> tChuyenHangMaNhanVienGiaoHangNavigation { get; set; }
		public ICollection<tChuyenKho> tChuyenKhoMaNhanVienNavigation { get; set; }
		public ICollection<tNhapHang> tNhapHangMaNhanVienNavigation { get; set; }
    }
}
