namespace huypq.SmtWpfClientSQL.Test
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TestChildData")]
    public partial class TestChildData : IEntity
    {
        public int ID { get; set; }

        public int TenantID { get; set; }

        public long LastUpdateTime { get; set; }

        [Required]
        [StringLength(250)]
        public string Data { get; set; }

        public long CreateTime { get; set; }

        public int TestDataID { get; set; }

        public virtual TestData TestData { get; set; }
    }
}
