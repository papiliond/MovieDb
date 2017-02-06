using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDb.Models
{
    public class Rating
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        [Required]
        [Range(1, 5)]
        public int Value { get; set; }


        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }


        public int MovieID { get; set; }
        public virtual Movie Movie { get; set; }


    }
}