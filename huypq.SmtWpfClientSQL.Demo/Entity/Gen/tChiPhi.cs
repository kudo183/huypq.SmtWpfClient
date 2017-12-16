using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class tChiPhi : IEntity
    {
        public tChiPhi()
        {
        }

        public int ID { get; set; }
        public int MaNhanVienGiaoHang { get; set; }
        public int MaLoaiChiPhi { get; set; }
        public int SoTien { get; set; }
        public System.DateTime Ngay { get; set; }
        public string GhiChu { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        public rNhanVien MaNhanVienGiaoHangNavigation { get; set; }
        public rLoaiChiPhi MaLoaiChiPhiNavigation { get; set; }
		
    }
}
