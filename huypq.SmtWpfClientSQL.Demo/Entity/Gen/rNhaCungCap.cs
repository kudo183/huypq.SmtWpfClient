using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class rNhaCungCap : IEntity
    {
        public rNhaCungCap()
        {
            tNhapHangMaNhaCungCapNavigation = new HashSet<tNhapHang>();
            tNhapNguyenLieuMaNhaCungCapNavigation = new HashSet<tNhapNguyenLieu>();
        }

        public int ID { get; set; }
        public string TenNhaCungCap { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

		
		public ICollection<tNhapHang> tNhapHangMaNhaCungCapNavigation { get; set; }
		public ICollection<tNhapNguyenLieu> tNhapNguyenLieuMaNhaCungCapNavigation { get; set; }
    }
}
