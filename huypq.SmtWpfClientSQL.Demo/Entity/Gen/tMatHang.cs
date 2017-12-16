using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class tMatHang : IEntity
    {
        public tMatHang()
        {
            rCanhBaoTonKhoMaMatHangNavigation = new HashSet<rCanhBaoTonKho>();
            rMatHangNguyenLieuMaMatHangNavigation = new HashSet<rMatHangNguyenLieu>();
            tChiTietChuyenKhoMaMatHangNavigation = new HashSet<tChiTietChuyenKho>();
            tChiTietDonHangMaMatHangNavigation = new HashSet<tChiTietDonHang>();
            tChiTietNhapHangMaMatHangNavigation = new HashSet<tChiTietNhapHang>();
            tTonKhoMaMatHangNavigation = new HashSet<tTonKho>();
        }

        public int ID { get; set; }
        public int MaLoai { get; set; }
        public string TenMatHang { get; set; }
        public int SoKy { get; set; }
        public int SoMet { get; set; }
        public string TenMatHangDayDu { get; set; }
        public string TenMatHangIn { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }
        public int MaHinhAnh { get; set; }

        public rLoaiHang MaLoaiNavigation { get; set; }
		
		public ICollection<rCanhBaoTonKho> rCanhBaoTonKhoMaMatHangNavigation { get; set; }
		public ICollection<rMatHangNguyenLieu> rMatHangNguyenLieuMaMatHangNavigation { get; set; }
		public ICollection<tChiTietChuyenKho> tChiTietChuyenKhoMaMatHangNavigation { get; set; }
		public ICollection<tChiTietDonHang> tChiTietDonHangMaMatHangNavigation { get; set; }
		public ICollection<tChiTietNhapHang> tChiTietNhapHangMaMatHangNavigation { get; set; }
		public ICollection<tTonKho> tTonKhoMaMatHangNavigation { get; set; }
    }
}
