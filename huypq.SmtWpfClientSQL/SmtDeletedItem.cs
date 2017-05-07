namespace huypq.SmtWpfClientSQL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SmtDeletedItem")]
    public partial class SmtDeletedItem
    {
        public int ID { get; set; }

        public int DeletedID { get; set; }

        public int TableID { get; set; }

        public long CreateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }

        public int TenantID { get; set; }
    }
}
