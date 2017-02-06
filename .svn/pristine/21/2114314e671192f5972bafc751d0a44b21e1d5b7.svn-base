using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDb.Models
{
    public class Movie
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string CoverPicture { get; set; }

        public string GenreName { get; set; }
        public virtual Genre Genre { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Appearance> Appearances { get; set; }

        public Movie() { Users = new HashSet<ApplicationUser>(); }

    }

    
}