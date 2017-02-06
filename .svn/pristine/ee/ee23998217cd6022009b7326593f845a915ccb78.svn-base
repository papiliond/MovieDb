using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MovieDb.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        [ForeignKey("Genre")]
        public String FavoriteGenre { get; set; }
        public virtual Genre Genre { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }

        public ApplicationUser() { Movies = new HashSet<Movie>(); }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
          
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public override IDbSet<ApplicationUser> Users { get; set; }
        public DbSet<Appearance> Appearances { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


            modelBuilder.Entity<Movie>()
                .HasMany(c => c.Users).WithMany(i => i.Movies)
                .Map(t => t.MapLeftKey("movieid")
                .MapRightKey("userid")
                .ToTable("Favorites"));

        }



        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}