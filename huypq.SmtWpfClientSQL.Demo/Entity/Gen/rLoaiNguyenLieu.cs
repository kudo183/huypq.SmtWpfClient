using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class rLoaiNguyenLieu : IEntity
    {
        public rLoaiNguyenLieu()
        {
            rNguyenLieuMaLoaiNguyenLieuNavigation = new HashSet<rNguyenLieu>();
        }

        public int ID { get; set; }
        public string TenLoai { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

		
		public ICollection<rNguyenLieu> rNguyenLieuMaLoaiNguyenLieuNavigation { get; set; }
    }
}
