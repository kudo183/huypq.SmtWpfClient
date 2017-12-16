using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class tChuyenKho : IEntity
    {
        public tChuyenKho()
        {
            tChiTietChuyenKhoMaChuyenKhoNavigation = new HashSet<tChiTietChuyenKho>();
        }

        public int ID { get; set; }
        public int MaNhanVien { get; set; }
        public int MaKhoHangXuat { get; set; }
        public int MaKhoHangNhap { get; set; }
        public System.DateTime Ngay { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        public rNhanVien MaNhanVienNavigation { get; set; }
        public rKhoHang MaKhoHangXuatNavigation { get; set; }
        public rKhoHang MaKhoHangNhapNavigation { get; set; }
		
		public ICollection<tChiTietChuyenKho> tChiTietChuyenKhoMaChuyenKhoNavigation { get; set; }
    }
}
