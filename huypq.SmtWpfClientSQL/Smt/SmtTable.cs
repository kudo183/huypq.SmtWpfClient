namespace huypq.SmtWpfClientSQL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SmtTable")]
    public partial class SmtTable
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TableName { get; set; }
    }
}
