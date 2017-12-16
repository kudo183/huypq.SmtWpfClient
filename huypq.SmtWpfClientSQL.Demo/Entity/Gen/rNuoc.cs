using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class rNuoc : IEntity
    {
        public rNuoc()
        {
            rDiaDiemMaNuocNavigation = new HashSet<rDiaDiem>();
        }

        public int ID { get; set; }
        public string TenNuoc { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

		
		public ICollection<rDiaDiem> rDiaDiemMaNuocNavigation { get; set; }
    }
}
