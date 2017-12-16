using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class tChiTietChuyenKho : IEntity
    {
        public tChiTietChuyenKho()
        {
        }

        public int ID { get; set; }
        public int MaChuyenKho { get; set; }
        public int MaMatHang { get; set; }
        public int SoLuong { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        public tChuyenKho MaChuyenKhoNavigation { get; set; }
        public tMatHang MaMatHangNavigation { get; set; }
		
    }
}
