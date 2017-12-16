using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class rKhoHang : IEntity
    {
        public rKhoHang()
        {
            rCanhBaoTonKhoMaKhoHangNavigation = new HashSet<rCanhBaoTonKho>();
            tChuyenKhoMaKhoHangNhapNavigation = new HashSet<tChuyenKho>();
            tChuyenKhoMaKhoHangXuatNavigation = new HashSet<tChuyenKho>();
            tDonHangMaKhoHangNavigation = new HashSet<tDonHang>();
            tNhapHangMaKhoHangNavigation = new HashSet<tNhapHang>();
            tTonKhoMaKhoHangNavigation = new HashSet<tTonKho>();
        }

        public int ID { get; set; }
        public string TenKho { get; set; }
        public bool TrangThai { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

		
		public ICollection<rCanhBaoTonKho> rCanhBaoTonKhoMaKhoHangNavigation { get; set; }
		public ICollection<tChuyenKho> tChuyenKhoMaKhoHangNhapNavigation { get; set; }
		public ICollection<tChuyenKho> tChuyenKhoMaKhoHangXuatNavigation { get; set; }
		public ICollection<tDonHang> tDonHangMaKhoHangNavigation { get; set; }
		public ICollection<tNhapHang> tNhapHangMaKhoHangNavigation { get; set; }
		public ICollection<tTonKho> tTonKhoMaKhoHangNavigation { get; set; }
    }
}
