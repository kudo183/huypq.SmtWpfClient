namespace huypq.SmtWpfClientSQL.Test
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TestData")]
    public partial class TestData : IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TestData()
        {
            TestChildDatas = new HashSet<TestChildData>();
        }

        public int ID { get; set; }

        public int TenantID { get; set; }

        public long LastUpdateTime { get; set; }

        [Required]
        [StringLength(250)]
        public string Data { get; set; }

        public long CreateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestChildData> TestChildDatas { get; set; }
    }
}
