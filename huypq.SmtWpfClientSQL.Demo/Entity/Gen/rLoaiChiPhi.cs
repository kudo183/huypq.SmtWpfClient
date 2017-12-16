using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class rLoaiChiPhi : IEntity
    {
        public rLoaiChiPhi()
        {
            tChiPhiMaLoaiChiPhiNavigation = new HashSet<tChiPhi>();
        }

        public int ID { get; set; }
        public string TenLoaiChiPhi { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

		
		public ICollection<tChiPhi> tChiPhiMaLoaiChiPhiNavigation { get; set; }
    }
}
