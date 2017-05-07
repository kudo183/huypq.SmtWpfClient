namespace huypq.SmtWpfClientSQL.Test
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SmtUser")]
    public partial class SmtUser : IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SmtUser()
        {
            SmtUserClaims = new HashSet<SmtUserClaim>();
        }

        public int ID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(256)]
        public string Email { get; set; }

        [Required]
        [StringLength(128)]
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        public int TenantID { get; set; }

        public long TokenValidTime { get; set; }

        public long LastUpdateTime { get; set; }

        public bool IsConfirmed { get; set; }

        public bool IsLocked { get; set; }

        public long CreateTime { get; set; }

        public virtual SmtTenant SmtTenant { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SmtUserClaim> SmtUserClaims { get; set; }
    }
}
