using MovieDb.Models;
using System.Collections.Generic;



namespace MovieDb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieDb.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieDb.Models.ApplicationDbContext context)
        {

            if (!context.Genres.Any() && !context.Movies.Any() &&
                !context.Actors.Any() && !context.Appearances.Any())
            {

                AddGenres(context);
                addMovies(context);
                addActors(context);
                addAppearances(context);
            }
        }

        private void AddGenres(ApplicationDbContext context)
        {
            var genre = new List<Genre>
            {
                new Genre{Name="Action"},
                new Genre{Name="Adventure"},
                new Genre {Name="Comedy"},
                new Genre {Name="Crime"},
                new Genre {Name="Drama"},
                new Genre {Name="Fantasy"},
                new Genre {Name="Historical"},
                new Genre {Name="Historical Fiction"},
                new Genre {Name="Horror"},
                new Genre {Name="Magical realism"},
                new Genre {Name="Paranoid"},
                new Genre {Name="Philosophical"},
                new Genre {Name="Political"},
                new Genre {Name="Romance"},
                new Genre {Name="Satire"},
                new Genre {Name="Science Fiction"},
                new Genre {Name="Slice of life"},
                new Genre {Name="Speculative"},
                new Genre {Name="Thriller"},
                new Genre {Name="Urban"},
                new Genre {Name="Western"},
                new Genre {Name="Biography"},
                new Genre {Name="Family"},
                new Genre {Name="Music"},
                new Genre {Name="Mystery"},
                new Genre {Name="Sport"},
                new Genre {Name="War"},
                new Genre {Name="Documentary"}
                //new Genre {Name=""}
            };

            genre.ForEach(s => context.Genres.Add(s));
            context.SaveChanges();
        }

        //Movies: Title, ReleaseDate, Description, CoverPicture, GenreName
        private void addMovies(ApplicationDbContext context) {

            var movie = new List<Movie>
            {
                new Movie {
                    Title ="Logan",
                    ReleaseDate =DateTime.Parse("2017-03-03"),
                    Description ="In the near future, the aging Wolverine and Professor X must protect a young female clone of Wolverine from an evil organization led by Nathanial Essex. ",
                    CoverPicture ="/Content/Images/logan.jpg",
                    GenreName ="Science Fiction"
                    },
                new Movie {Title="District 9",
                    ReleaseDate =DateTime.Parse("2009-08-14"),
                    Description =" An extraterrestrial race forced to live in slum-like conditions on Earth suddenly finds a kindred spirit in a government agent who is exposed to their biotechnology. ",
                    CoverPicture ="/Content/Images/district9.jpg",
                    GenreName ="Science Fiction"},
                new Movie {
                Title="Taxi 3",
                ReleaseDate =DateTime.Parse("2003-02-27"),
                Description ="Out to stop a new gang disguised as Santa Claus, Emilien and Daniel must also handle major changes in their personal relationships. ",
                CoverPicture ="/Content/Images/taxi3.jpg",
                GenreName ="Action"}

                /*  new Movie {
                Title="",
                ReleaseDate =DateTime.Parse(""),
                Description ="",
                CoverPicture ="/Context/Images/",
                GenreName =""}  */
            };

            movie.ForEach(s => context.Movies.Add(s));
            context.SaveChanges();
        }

        //Actors: Name
        private void addActors(ApplicationDbContext context)
        {

            var actor = new List<Actor>
            {
                //Logan
                new Actor {Name="Hugh Jackman"},
                new Actor {Name="Boyd Holbrook"},
                new Actor {Name="Doris Morgado"},
                new Actor {Name="Patrick Steward"},
                new Actor {Name="Elizabeth Rodriguez"},
                new Actor {Name="Stephen Merchant"},
                new Actor {Name="Richard E. Grant"},
                new Actor {Name="Dave Davis"},
                new Actor {Name="Julia Holt"},
                new Actor {Name="Juan Gaspard"},
                //District 9
                new Actor {Name="Sharlto Copley"},
                new Actor {Name="Jason Cope"},
                new Actor {Name="Nathalie Boltt"},
                new Actor {Name="John Summer"},
                //Taxi 3
                new Actor {Name="Samy Naceri"},
                new Actor {Name="Frédéric Diefenthal"},
                new Actor {Name="Bernard Farcy"},
                new Actor {Name="Bai Ling"},
                new Actor {Name="Marion Cotillard"},
                new Actor {Name="Jean-Christophe Bouvet"}
                //new Actor {Name=""},
            };

            actor.ForEach(s => context.Actors.Add(s));
            context.SaveChanges();

        }

        //Apearances: MovieID, ActorID
        private void addAppearances(ApplicationDbContext context)
        {
            
            //Logan
            {
                var movie = context.Movies.First(a => a.Title == "Logan");
                context.Appearances.AddOrUpdate(t => t.Movie,
                    new Appearance
                    {
                        MovieId = movie.ID,
                        ActorId = (context.Actors.First(b => b.Name == "Hugh Jackman")).ID
                    },
                    new Appearance
                    {
                        MovieId = movie.ID,
                        ActorId = (context.Actors.First(b => b.Name == "Boyd Holbrook")).ID
                    },
                    new Appearance
                    {
                        MovieId = movie.ID,
                        ActorId = (context.Actors.First(b => b.Name == "Doris Morgado")).ID
                    },
                    new Appearance
                    {
                        MovieId = movie.ID,
                        ActorId = (context.Actors.First(b => b.Name == "Patrick Steward")).ID
                    },
                    new Appearance
                    {
                        MovieId = movie.ID,
                        ActorId = (context.Actors.First(b => b.Name == "Elizabeth Rodriguez")).ID
                    },
                    new Appearance
                    {
                        MovieId = movie.ID,
                        ActorId = (context.Actors.First(b => b.Name == "Stephen Merchant")).ID
                    },
                    new Appearance
                    {
                        MovieId = movie.ID,
                        ActorId = (context.Actors.First(b => b.Name == "Richard E. Grant")).ID
                    },
                    new Appearance
                    {
                        MovieId = movie.ID,
                        ActorId = (context.Actors.First(b => b.Name == "Dave Davis")).ID
                    },
                    new Appearance
                    {
                        MovieId = movie.ID,
                        ActorId = (context.Actors.First(b => b.Name == "Julia Holt")).ID
                    },
                    new Appearance
                    {
                        MovieId = movie.ID,
                        ActorId = (context.Actors.First(b => b.Name == "Juan Gaspard")).ID
                    });
                context.SaveChanges();
            }
            //District 9
            {
                 var movie = context.Movies.First(a => a.Title == "District 9");
                 context.Appearances.AddOrUpdate(t => t.Movie,
                    new Appearance
                    {
                        MovieId = movie.ID,
                        ActorId = (context.Actors.First(b => b.Name == "Sharlto Copley")).ID
                    },
                    new Appearance
                    {
                        MovieId = movie.ID,
                        ActorId = (context.Actors.First(b => b.Name == "Jason Cope")).ID
                    },
                    new Appearance
                    {
                        MovieId = movie.ID,
                        ActorId = (context.Actors.First(b => b.Name == "Nathalie Boltt")).ID
                    },
                    new Appearance
                    {
                        MovieId = movie.ID,
                        ActorId = (context.Actors.First(b => b.Name == "John Summer")).ID
                    }
                    );
                    context.SaveChanges();
            }
            //Taxi 3
            {
                var movie = context.Movies.First(a => a.Title == "Taxi 3");
                context.Appearances.AddOrUpdate(t => t.Movie,
                    new Appearance
                    {
                        MovieId = movie.ID,
                        ActorId = (context.Actors.First(b => b.Name == "Samy Naceri")).ID
                    },
                    new Appearance
                    {
                        MovieId = movie.ID,
                        ActorId = (context.Actors.First(b => b.Name == "Frédéric Diefenthal")).ID
                    },
                    new Appearance
                    {
                        MovieId = movie.ID,
                        ActorId = (context.Actors.First(b => b.Name == "Bernard Farcy")).ID
                    },
                    new Appearance
                    {
                        MovieId = movie.ID,
                        ActorId = (context.Actors.First(b => b.Name == "Bai Ling")).ID
                    },
                    new Appearance
                    {
                        MovieId = movie.ID,
                        ActorId = (context.Actors.First(b => b.Name == "Marion Cotillard")).ID
                    },
                    new Appearance
                    {
                        MovieId = movie.ID,
                        ActorId = (context.Actors.First(b => b.Name == "Jean-Christophe Bouvet")).ID
                    }
                    );
                context.SaveChanges();
            }

            /*            
            {
            var movie = context.Movies.First(a => a.Title == "");
            context.Appearances.AddOrUpdate(t => t.Movie,
                new Appearance
                {
                    MovieId = movie.ID,
                    ActorId = (context.Actors.First(b => b.Name == "")).ID
                },
                new Appearance
                {
                    MovieId = movie.ID,
                    ActorId = (context.Actors.First(b => b.Name == "")).ID
                }
                );
                context.SaveChanges();
             }
            */


        }
        //Ratings

        //Comments

        //Favorites


    }
}


