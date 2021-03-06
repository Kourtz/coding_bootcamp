﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExEf6.Model
{
    public class Blog
    {
        //Primary Key
        public int Id { get; set; }
        public string Title { get; set; }

        //Navigation Property
        public virtual ICollection<Post> Posts { get; set; }
    }
}
