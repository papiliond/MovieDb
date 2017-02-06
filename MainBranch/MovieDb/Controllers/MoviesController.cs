﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieDb.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using MovieDb.ViewModels;

namespace MovieDb.Controllers
{
    public class MoviesController : Controller
    {

        protected ApplicationDbContext db = new ApplicationDbContext();
        protected UserManager<ApplicationUser> um; 

        // GET: Movies
        public async Task<ActionResult> Index()
        {
          
            var movies = db.Movies.Include(m => m.Genre);

            return View(await movies.ToListAsync());

        }

        public ActionResult Search(String searchText)
        {
            List<Movie> movies = new List<Movie>();

            if (!String.IsNullOrEmpty(searchText))
            {

                movies = db.Movies.Include(m => m.Genre)
                     .Where(s => s.Title.Contains(searchText)
                     || s.GenreName.Contains(searchText)
                     ).ToList();

                var actorIds = db.Actors.Where(a => a.Name.Contains(searchText)).Select(s => s.ID);

                List<int> movieIds = new List<int>();
                foreach (int Id in actorIds)
                {
                    var movieId = db.Appearances.Where(a => a.ActorId == Id).Select(s => s.MovieId);
                    movieIds = movieIds.Concat(movieId).ToList();
                }

                List<Movie> moviesByActor = new List<Movie>();
                foreach (int Id in movieIds)
                {
                    moviesByActor = moviesByActor.Concat(db.Movies.Include(m => m.Genre).Where(n => n.ID == Id)).ToList();
                }

                movies = movies.Concat(moviesByActor).Distinct().ToList();
            }

            return View("SearchResult", movies);
        }


        // GET: Movies/Details/5
        public async Task<ActionResult> Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Movie Movie = await db.Movies.FindAsync(id);
            var movie = db.Movies.Include(i => i.Users).Where(u => u.ID == id).First();

            //Getting the actors 
            var actors = await db.Appearances.Include(a => a.Actor).Where(a => a.MovieId == movie.ID).Select(a => a.Actor).ToListAsync();

            MovieActorViewModel movieActorViewModel = new MovieActorViewModel();
            movieActorViewModel.Movie = movie;
            movieActorViewModel.Actors = actors;

            ViewBag.Rating = getMovieRate(id).ToString("0.00");
            ViewBag.NumberOfRatings = getNumberOfRates(id);

            //Checking is the movie at the current user's favorites 
            //and getting the current user's movie rating
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var userid = User.Identity.GetUserId();
                um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                ApplicationUser appuser = await um.FindByIdAsync(User.Identity.GetUserId());
                var user = db.Users.Include(i => i.Movies).Where(u => u.Id == userid).First();

                if (!movie.Users.Any(i => i.Id == user.Id) ||
                    !user.Movies.Any(u => u.ID == movie.ID))
                {
                    ViewBag.Favorited = false;
                }
                else
                {
                    ViewBag.Favorited = true;
                }

                int usersRating = getUsersRate(id, userid);
                ViewBag.UsersRating = usersRating;

            }
                if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movieActorViewModel);
        }

        
        public double getMovieRate(int? movieid)
        {
            double value=0;
            var ratings = db.Ratings.Where(m => m.MovieID == movieid).Select(r => r.Value);

            int cnt=0;
            foreach (int val in ratings)
            {
                cnt++;
                value += val; 
            }
            if (cnt!=0) 
            value /= cnt;

            return value;
        }


        public int getNumberOfRates (int? movieid)
        {
            int number = db.Ratings.Where(m => m.MovieID == movieid).Count();
            return number;
        } 


        //Getting the User's rating for the movie
        public int getUsersRate(int? movieid, string userid)
        {
            int value;
            var movie = db.Movies.Include(r => r.Ratings).Where(u => u.ID == movieid).First();
            var user = db.Users.Include(r => r.Ratings).Where(u => u.Id == userid).First();

            if (movie.Ratings.Any(m => m.UserID == userid) || user.Ratings.Any(m => m.MovieID == movieid))
            {
                value = db.Ratings.Where(u => u.UserID == userid).Where(m => m.MovieID == movieid).Select(v => v.Value).First();
            }
                 else
                {
                    return 0;
            }

            return value;
        }


        public async Task<ActionResult> Rate(int value, int id)
        {
            if(User != null && User.Identity != null) { 

                var userid = User.Identity.GetUserId();
                um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                ApplicationUser appuser = await um.FindByIdAsync(User.Identity.GetUserId());
                var movie = db.Movies.Include(r => r.Ratings).Where(u => u.ID == id).First();
                var user = db.Users.Include(r => r.Ratings).Where(u => u.Id == userid).First();

                Rating Rating = new Rating
                {
                    Value = value,
                    UserID = userid,
                    MovieID = id
                };

                if (!movie.Ratings.Any(m => m.UserID == userid) || !user.Ratings.Any(m => m.MovieID == id)) { 
                    db.Ratings.Add(Rating);
                    await db.SaveChangesAsync();
                } else
                {
                    var ratingID = movie.Ratings.Where(m => m.UserID == userid).First().ID;
                    Rating r = db.Ratings.FirstOrDefault(x => x.ID == ratingID);
                    r.Value = value;
                }

            }
            await db.SaveChangesAsync();
            return RedirectToAction("Details", new { id = id });
        }


        //Drop movie from the current user's favorites list
        public async Task<ActionResult> ToFavorites(int id)
        {
            Movie Movie = await db.Movies.FindAsync(id);
            var userid = User.Identity.GetUserId();
            um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            ApplicationUser appuser = await um.FindByIdAsync(User.Identity.GetUserId());

            var movie = db.Movies.Include(i => i.Users).Where(u => u.ID == id).First();
            var user = db.Users.Include(i => i.Movies).Where(u => u.Id == userid).First();

            if (!movie.Users.Any(i => i.Id == user.Id) ||
                !user.Movies.Any(u => u.ID == movie.ID))
            {
                Movie.Users.Add(user);
                appuser.Movies.Add(movie);
                await db.SaveChangesAsync();
                }

            return RedirectToAction("Details", new { id = id });
        }

        //Drop movie from the current user's favorites list
        public async Task<ActionResult> DropFromFavorites(int id)
        {
            Movie Movie = await db.Movies.FindAsync(id);
            var userid = User.Identity.GetUserId();
            um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            ApplicationUser appuser = await um.FindByIdAsync(User.Identity.GetUserId());
          
            var movie = db.Movies.Include(i => i.Users).Where(u => u.ID == id).First();
            var user = db.Users.Include(i => i.Movies).Where(u => u.Id == userid).First();

            if (movie.Users.Any(i => i.Id == user.Id) ||
                user.Movies.Any(u => u.ID == movie.ID))
            {
                Movie.Users.Remove(user);
                appuser.Movies.Remove(movie);
                await db.SaveChangesAsync();
            } 

            return RedirectToAction("Details", new { id = id });
        }


        public async Task<ActionResult> Favorites()
        {
            var userid = User.Identity.GetUserId();
            var movies = db.Movies
                .Where(x => x.Users.Any(c => c.Id == userid))
                ;

            return View(await movies.ToListAsync());
        }


        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.GenreName = new SelectList(db.Genres, "Name", "Name");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Title,ReleaseDate,Description,CoverPicture,GenreName")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.GenreName = new SelectList(db.Genres, "Name", "Name", movie.GenreName);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = await db.Movies.FindAsync(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreName = new SelectList(db.Genres, "Name", "Name", movie.GenreName);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Title,ReleaseDate,Description,CoverPicture,GenreName")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GenreName = new SelectList(db.Genres, "Name", "Name", movie.GenreName);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = await db.Movies.FindAsync(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Movie movie = await db.Movies.FindAsync(id);
            db.Movies.Remove(movie);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

      

    }
}
