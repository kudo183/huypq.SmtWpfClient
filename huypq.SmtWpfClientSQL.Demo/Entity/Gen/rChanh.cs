using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class rChanh : IEntity
    {
        public rChanh()
        {
            rKhachHangChanhMaChanhNavigation = new HashSet<rKhachHangChanh>();
            tDonHangMaChanhNavigation = new HashSet<tDonHang>();
        }

        public int ID { get; set; }
        public int MaBaiXe { get; set; }
        public string TenChanh { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        public rBaiXe MaBaiXeNavigation { get; set; }
		
		public ICollection<rKhachHangChanh> rKhachHangChanhMaChanhNavigation { get; set; }
		public ICollection<tDonHang> tDonHangMaChanhNavigation { get; set; }
    }
}
