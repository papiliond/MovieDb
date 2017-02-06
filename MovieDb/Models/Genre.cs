using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDb.Models
{
    public class Genre
    {

        [Required]
        [Key]
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }

    }
}