using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class rNguyenLieu : IEntity
    {
        public rNguyenLieu()
        {
            rMatHangNguyenLieuMaNguyenLieuNavigation = new HashSet<rMatHangNguyenLieu>();
            tNhapNguyenLieuMaNguyenLieuNavigation = new HashSet<tNhapNguyenLieu>();
        }

        public int ID { get; set; }
        public int MaLoaiNguyenLieu { get; set; }
        public int DuongKinh { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        public rLoaiNguyenLieu MaLoaiNguyenLieuNavigation { get; set; }
		
		public ICollection<rMatHangNguyenLieu> rMatHangNguyenLieuMaNguyenLieuNavigation { get; set; }
		public ICollection<tNhapNguyenLieu> tNhapNguyenLieuMaNguyenLieuNavigation { get; set; }
    }
}
