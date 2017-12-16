using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class rKhachHangChanh : IEntity
    {
        public rKhachHangChanh()
        {
        }

        public int ID { get; set; }
        public int MaChanh { get; set; }
        public int MaKhachHang { get; set; }
        public bool LaMacDinh { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        public rChanh MaChanhNavigation { get; set; }
        public rKhachHang MaKhachHangNavigation { get; set; }
		
    }
}
