using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyThreeProject.Models;
using MyThreeProject.Global;

namespace MyThreeProject.Controllers
{
    [VersionedRoute("Professors/v{version}/{action=Index}/{id?}", 1, Name = "ProfessorsV1")]
    public class ProfessorsV1Controller : Controller
    {
        private ProfessorsV1Context db = new ProfessorsV1Context();

        // GET: ProfessorsV1
        public async Task<ActionResult> Index()
        {
            return View(await db.Professors.ToListAsync());
        }

        // GET: ProfessorsV1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = await db.Professors.FindAsync(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // GET: ProfessorsV1/Details/5/DetailsProfessor
        [Route("ProfessorsV1/Details/{id}/DetailsProfessor")]
        public async Task<ActionResult> DetailsProfessor(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = await db.Professors.FindAsync(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View("Details", professor);
        }

        // GET: ProfessorsV1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfessorsV1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Address,Age")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Professors.Add(professor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(professor);
        }

        // GET: ProfessorsV1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = await db.Professors.FindAsync(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // POST: ProfessorsV1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Address,Age")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(professor);
        }

        // GET: ProfessorsV1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = await db.Professors.FindAsync(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // POST: ProfessorsV1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Professor professor = await db.Professors.FindAsync(id);
            db.Professors.Remove(professor);
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
