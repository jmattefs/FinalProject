using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using Microsoft.AspNet.Identity;

namespace FinalProject.Controllers
{
    public class JobsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jobs
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var user = db.JobSeeker.Where(x => x.UserId == id).Select(x => x).FirstOrDefault();
            int UserRole = db.Users.Where(x => x.Id == id).Select(x => x.Role).FirstOrDefault();
            if(UserRole == 1)
            {


                return View(db.Jobs.Where(x => x.TestAScore <= user.Survey1Score && x.TestBScore == 0 || x.TestBScore == user.Test2ScoreINT && x.TestCScore == 0 || x.TestCScore <= user.Test3ScoreINT).ToList());
            }
            else if (UserRole == 2)
            {
                return View(db.Jobs.Where(x => x.CompanyID == id).Select(x => x).ToList());
            }
            else
            {
                return View(db.Jobs.ToList());
            }


            
        }

        // GET: Jobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description,TestAScore,TestBScore,TestCScore, CompanyID, Company")] Job job)
        {
            if (ModelState.IsValid)
            {
                var id = User.Identity.GetUserId();
                var user = db.Employer.Where(x => x.UserId == id).Select(x => x.UserId).FirstOrDefault();
                var name = db.Employer.Where(x => x.UserId == id).Select(x => x.Name).FirstOrDefault();
                job.CompanyID = user;
                job.Company = name;

                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(job);
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,TestAScore,TestBScore,TestCScore, CompanyID, Company")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
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
