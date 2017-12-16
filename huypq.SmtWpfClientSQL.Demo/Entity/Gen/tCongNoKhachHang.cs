using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class tCongNoKhachHang : IEntity
    {
        public tCongNoKhachHang()
        {
        }

        public int ID { get; set; }
        public int MaKhachHang { get; set; }
        public System.DateTime Ngay { get; set; }
        public int SoTien { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        public rKhachHang MaKhachHangNavigation { get; set; }
		
    }
}
