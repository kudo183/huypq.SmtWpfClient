using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class rDiaDiem : IEntity
    {
        public rDiaDiem()
        {
            rKhachHangMaDiaDiemNavigation = new HashSet<rKhachHang>();
        }

        public int ID { get; set; }
        public int MaNuoc { get; set; }
        public string Tinh { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        public rNuoc MaNuocNavigation { get; set; }
		
		public ICollection<rKhachHang> rKhachHangMaDiaDiemNavigation { get; set; }
    }
}
