using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class rCanhBaoTonKho : IEntity
    {
        public rCanhBaoTonKho()
        {
        }

        public int ID { get; set; }
        public int MaMatHang { get; set; }
        public int MaKhoHang { get; set; }
        public int TonCaoNhat { get; set; }
        public int TonThapNhat { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        public tMatHang MaMatHangNavigation { get; set; }
        public rKhoHang MaKhoHangNavigation { get; set; }
		
    }
}
