using System.Collections.Generic;
using huypq.SmtWpfClientSQL;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class rBaiXe : IEntity
    {
        public rBaiXe()
        {
            rChanhMaBaiXeNavigation = new HashSet<rChanh>();
        }

        public int ID { get; set; }
        public string DiaDiemBaiXe { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

		
		public ICollection<rChanh> rChanhMaBaiXeNavigation { get; set; }
    }
}
