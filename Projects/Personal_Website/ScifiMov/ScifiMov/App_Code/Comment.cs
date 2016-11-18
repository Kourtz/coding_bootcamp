namespace ScifiMov
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Column("Comment")]
        [Required]
        [StringLength(1000)]
        public string Comment1 { get; set; }

        public int? Likes { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual User User { get; set; }
    }
}
