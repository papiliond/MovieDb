using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDb.Models
{
    public class Comment
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime date { get; set; }

        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int MovieID { get; set; }
        public virtual Movie Movie { get; set; }
    }
}