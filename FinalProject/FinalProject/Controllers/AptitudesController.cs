using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class AptitudesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Aptitudes
        public ActionResult Index()
        {
            return View(db.Aptitudes.ToList());
        }

        // GET: Aptitudes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aptitude aptitude = db.Aptitudes.Find(id);
            if (aptitude == null)
            {
                return HttpNotFound();
            }
            return View(aptitude);
        }

        // GET: Aptitudes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aptitudes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserId,Q1,Q2,Q3,Q4,Q5")] Aptitude aptitude)
        {
            if (ModelState.IsValid)
            {
                db.Aptitudes.Add(aptitude);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aptitude);
        }

        // GET: Aptitudes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aptitude aptitude = db.Aptitudes.Find(id);
            if (aptitude == null)
            {
                return HttpNotFound();
            }
            return View(aptitude);
        }

        // POST: Aptitudes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserId,Q1,Q2,Q3,Q4,Q5")] Aptitude aptitude)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aptitude).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aptitude);
        }

        // GET: Aptitudes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aptitude aptitude = db.Aptitudes.Find(id);
            if (aptitude == null)
            {
                return HttpNotFound();
            }
            return View(aptitude);
        }

        // POST: Aptitudes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aptitude aptitude = db.Aptitudes.Find(id);
            db.Aptitudes.Remove(aptitude);
            db.SaveChanges();
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
