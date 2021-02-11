namespace Newproject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Nokia_230_DS
    {
        [Key]
        public int id_product { get; set; }

        public int? cod_product { get; set; }

        public int KazakhBest_id { get; set; }

        public bool? bought { get; set; }

        public virtual KazakhBest KazakhBest { get; set; }
    }
}
