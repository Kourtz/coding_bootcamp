namespace ScifiMov
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Movie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Movie()
        {
            Comments = new HashSet<Comment>();
            Rates = new HashSet<Rate>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateRel { get; set; }

        [StringLength(100)]
        public string SubCategory { get; set; }

        [StringLength(255)]
        public string Link1 { get; set; }

        [StringLength(255)]
        public string Link2 { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        [StringLength(50)]
        public string Director { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rate> Rates { get; set; }
    }
}
