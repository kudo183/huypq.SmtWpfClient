using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class tChiTietNhapHang : IEntity
    {
        public tChiTietNhapHang()
        {
        }

        public int ID { get; set; }
        public int MaNhapHang { get; set; }
        public int MaMatHang { get; set; }
        public int SoLuong { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        public tNhapHang MaNhapHangNavigation { get; set; }
        public tMatHang MaMatHangNavigation { get; set; }
		
    }
}
