using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieDb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MovieDb.ViewModels
{
    public class MovieActorViewModel
    {
        protected ApplicationDbContext db = new ApplicationDbContext();
        protected UserManager<ApplicationUser> um;

        public Movie Movie { get; set; }
        public Genre Genre { set; get; }
        public Rating Rating { get; set; }

        public ICollection<Actor> Actors { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Comment> Comments { get; set; }


    }

    public class MovieActorAppearanceViewModel
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

        public Movie Movie { get; set; }
        public Genre Genre { get; set; }
        public Actor Actor { get; set; }
        public Appearance Appearance { get; set; }

    }

}