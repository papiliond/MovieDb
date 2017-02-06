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
    public class ActorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Actors
        public async Task<ActionResult> Index()
        {
            return View(await db.Actors.ToListAsync());
        }

        // GET: Actors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = await db.Actors.FindAsync(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // GET: Actors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Actors.Add(actor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(actor);
        }

        // GET: Actors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = await db.Actors.FindAsync(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(actor);
        }

        // GET: Actors/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = await db.Actors.FindAsync(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Actor actor = await db.Actors.FindAsync(id);
            db.Actors.Remove(actor);
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
