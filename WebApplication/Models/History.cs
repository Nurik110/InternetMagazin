namespace WebApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("History")]
    public partial class History
    {
        public int id { get; set; }

        public int? id_product { get; set; }

        [StringLength(50)]
        public string operation { get; set; }

        public DateTime createat { get; set; }
    }
}
