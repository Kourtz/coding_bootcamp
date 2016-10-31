using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExEf6.Model
{
    public class Post
    {
        ///Primary Key
        public int Id { get; set; }
        [MaxLength(400)]
        public string Title { get; set; }
        public string Content { get; set; }
        public int? Likes { get; set; }

        public int BlogId { get; set; }
        public int UserId { get; set; }

        //Navigation Property
        [ForeignKey("BlogId")]
        public virtual Blog Blog { get; set; }
        //Navigation Property
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
