namespace huypq.SmtWpfClientSQL.Test
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SmtUserClaim")]
    public partial class SmtUserClaim : IEntity
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        [Required]
        [StringLength(256)]
        public string Claim { get; set; }

        public int TenantID { get; set; }

        public long LastUpdateTime { get; set; }

        public long CreateTime { get; set; }

        public virtual SmtTenant SmtTenant { get; set; }

        public virtual SmtUser SmtUser { get; set; }
    }
}
