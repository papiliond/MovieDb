using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDb.Models
{
    [Table("Appearance")]
    public class Appearance
    {

        [ForeignKey("Actor"), Key, Column(Order = 0)]
        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }

        [ForeignKey("Movie"), Key, Column(Order = 1),]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

    }
}