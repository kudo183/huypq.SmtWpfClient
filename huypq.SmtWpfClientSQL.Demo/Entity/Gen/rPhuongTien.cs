using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class rPhuongTien : IEntity
    {
        public rPhuongTien()
        {
            rNhanVienMaPhuongTienNavigation = new HashSet<rNhanVien>();
        }

        public int ID { get; set; }
        public string TenPhuongTien { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

		
		public ICollection<rNhanVien> rNhanVienMaPhuongTienNavigation { get; set; }
    }
}
