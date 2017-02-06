using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDb.Models
{
    public class Actor
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Appearance> Appearances { get; set; }
       

    }
}