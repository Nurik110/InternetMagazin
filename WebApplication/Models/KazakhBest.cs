namespace WebApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KazakhBest")]
    public partial class KazakhBest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KazakhBest()
        {
            Apple_iPad_Pro_A2229 = new HashSet<Apple_iPad_Pro_A2229>();
            Apple_Watch_Series_6 = new HashSet<Apple_Watch_Series_6>();
            Nokia_230_DS = new HashSet<Nokia_230_DS>();
            Samsung_Galaxy_S20_Plus = new HashSet<Samsung_Galaxy_S20_Plus>();
            Skyworth_BD_400 = new HashSet<Skyworth_BD_400>();
        }

        [Key]
        public int id_product { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string name_product { get; set; }

        public long? salary { get; set; }

        [Column(TypeName = "text")]
        public string photo { get; set; }

        public int category_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Apple_iPad_Pro_A2229> Apple_iPad_Pro_A2229 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Apple_Watch_Series_6> Apple_Watch_Series_6 { get; set; }

        public virtual category category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nokia_230_DS> Nokia_230_DS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Samsung_Galaxy_S20_Plus> Samsung_Galaxy_S20_Plus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Skyworth_BD_400> Skyworth_BD_400 { get; set; }
    }
}
