using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class rMatHangNguyenLieu : IEntity
    {
        public rMatHangNguyenLieu()
        {
        }

        public int ID { get; set; }
        public int MaMatHang { get; set; }
        public int MaNguyenLieu { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        public tMatHang MaMatHangNavigation { get; set; }
        public rNguyenLieu MaNguyenLieuNavigation { get; set; }
		
    }
}
