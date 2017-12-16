using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class tToaHang : IEntity
    {
        public tToaHang()
        {
            tChiTietToaHangMaToaHangNavigation = new HashSet<tChiTietToaHang>();
        }

        public int ID { get; set; }
        public System.DateTime Ngay { get; set; }
        public int MaKhachHang { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        public rKhachHang MaKhachHangNavigation { get; set; }
		
		public ICollection<tChiTietToaHang> tChiTietToaHangMaToaHangNavigation { get; set; }
    }
}
