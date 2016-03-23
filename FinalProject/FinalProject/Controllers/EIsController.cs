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
    public class EIsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EIs
        public ActionResult Index()
        {
            return View(db.EIs.ToList());
        }

        // GET: EIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EI eI = db.EIs.Find(id);
            if (eI == null)
            {
                return HttpNotFound();
            }
            return View(eI);
        }

        // GET: EIs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EIs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserId,Q1,Q2,Q3,Q4,Q5,TestCCompleted")] EI eI)
        {
            if (ModelState.IsValid)
            {
                db.EIs.Add(eI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eI);
        }

        // GET: EIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EI eI = db.EIs.Find(id);
            if (eI == null)
            {
                return HttpNotFound();
            }
            return View(eI);
        }

        // POST: EIs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserId,Q1,Q2,Q3,Q4,Q5,TestCCompleted")] EI eI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eI);
        }

        // GET: EIs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EI eI = db.EIs.Find(id);
            if (eI == null)
            {
                return HttpNotFound();
            }
            return View(eI);
        }

        // POST: EIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EI eI = db.EIs.Find(id);
            db.EIs.Remove(eI);
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
