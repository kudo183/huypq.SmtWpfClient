using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class tChiTietToaHang : IEntity
    {
        public tChiTietToaHang()
        {
        }

        public int ID { get; set; }
        public int MaToaHang { get; set; }
        public int MaChiTietDonHang { get; set; }
        public int GiaTien { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        public tToaHang MaToaHangNavigation { get; set; }
        public tChiTietDonHang MaChiTietDonHangNavigation { get; set; }
		
    }
}
