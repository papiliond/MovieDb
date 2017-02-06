using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieDb.Models;

namespace MovieDb.Controllers
{
    public class AppearancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Appearances
        public async Task<ActionResult> Index()
        {
            var appearances = db.Appearances.Include(a => a.Actor).Include(a => a.Movie);
            return View(await appearances.ToListAsync());
        }

        // GET: Appearances/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appearance appearance = await db.Appearances.FindAsync(id);
            if (appearance == null)
            {
                return HttpNotFound();
            }
            return View(appearance);
        }

        // GET: Appearances/Create
        public ActionResult Create()
        {
            ViewBag.ActorId = new SelectList(db.Actors, "ID", "Name");
            ViewBag.MovieId = new SelectList(db.Movies, "ID", "Title");
            return View();
        }

        // POST: Appearances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ActorId,MovieId")] Appearance appearance)
        {
            if (ModelState.IsValid)
            {
                db.Appearances.Add(appearance);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ActorId = new SelectList(db.Actors, "ID", "Name", appearance.ActorId);
            ViewBag.MovieId = new SelectList(db.Movies, "ID", "Title", appearance.MovieId);
            return View(appearance);
        }

        // GET: Appearances/Edit/5
        public async Task<ActionResult> Edit(int actorid, int movieid)
        {
            if (actorid == 0 || movieid == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appearance appearance = await db.Appearances.Where(a => a.ActorId.Equals(actorid) && a.MovieId.Equals(movieid)).FirstAsync();
            if (appearance == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActorId = new SelectList(db.Actors, "ID", "Name", appearance.ActorId);
            ViewBag.MovieId = new SelectList(db.Movies, "ID", "Title", appearance.MovieId);
            return View(appearance);
        }

        // POST: Appearances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ActorId,MovieId")] Appearance appearance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appearance).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ActorId = new SelectList(db.Actors, "ID", "Name", appearance.ActorId);
            ViewBag.MovieId = new SelectList(db.Movies, "ID", "Title", appearance.MovieId);
            return View(appearance);
        }

        // GET: Appearances/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appearance appearance = await db.Appearances.FindAsync(id);
            if (appearance == null)
            {
                return HttpNotFound();
            }
            return View(appearance);
        }

        // POST: Appearances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Appearance appearance = await db.Appearances.FindAsync(id);
            db.Appearances.Remove(appearance);
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
