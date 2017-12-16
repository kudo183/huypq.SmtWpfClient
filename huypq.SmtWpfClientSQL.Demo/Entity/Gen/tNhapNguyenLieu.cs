using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class tNhapNguyenLieu : IEntity
    {
        public tNhapNguyenLieu()
        {
        }

        public int ID { get; set; }
        public System.DateTime Ngay { get; set; }
        public int MaNguyenLieu { get; set; }
        public int MaNhaCungCap { get; set; }
        public int SoLuong { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        public rNguyenLieu MaNguyenLieuNavigation { get; set; }
        public rNhaCungCap MaNhaCungCapNavigation { get; set; }
		
    }
}
