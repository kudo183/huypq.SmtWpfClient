using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class rLoaiHang : IEntity
    {
        public rLoaiHang()
        {
            tMatHangMaLoaiNavigation = new HashSet<tMatHang>();
        }

        public int ID { get; set; }
        public string TenLoai { get; set; }
        public bool HangNhaLam { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

		
		public ICollection<tMatHang> tMatHangMaLoaiNavigation { get; set; }
    }
}
