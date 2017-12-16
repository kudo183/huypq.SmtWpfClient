using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class tTonKho : IEntity
    {
        public tTonKho()
        {
        }

        public int ID { get; set; }
        public int MaKhoHang { get; set; }
        public int MaMatHang { get; set; }
        public System.DateTime Ngay { get; set; }
        public int SoLuong { get; set; }
        public int SoLuongCu { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        public rKhoHang MaKhoHangNavigation { get; set; }
        public tMatHang MaMatHangNavigation { get; set; }
		
    }
}
