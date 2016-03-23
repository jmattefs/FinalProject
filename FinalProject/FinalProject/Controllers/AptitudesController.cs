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
using System.Web.Routing;

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
        public ActionResult Create([Bind(Include = "ID,UserId,Q1,Q2,Q3,Q4,Q5,TestACompleted")] Aptitude aptitude)
        {
            if (ModelState.IsValid)
            {
                aptitude.TestACompleted = true;
                

                aptitude.UserId = User.Identity.GetUserId();
                var js = db.JobSeeker.Where(x => x.UserId == aptitude.UserId).Select(x => x).FirstOrDefault();
                js.Survey1Complete = true;
                db.Aptitudes.Add(aptitude);
                db.SaveChanges();
                TestResults(aptitude);
            }

            return View(aptitude);
        }

        public ActionResult TestResults(Aptitude apt)
        {
            var user = apt.UserId;
            var name = db.Users.Where(x => x.Id == user).Select(x => x.Name).FirstOrDefault();
            int CorrectAnswers = 0;
            int Q1 = apt.Q1;
            int Q2 = apt.Q2;
            int Q3 = apt.Q3;
            int Q4 = apt.Q4;
            int Q5 = apt.Q5;

            if (Q1 == 4)
            {
                CorrectAnswers = CorrectAnswers + 1;
            }
            if (Q2 == 1)
            {
                CorrectAnswers = CorrectAnswers + 1;
            }
            if (Q3 == 3)
            {
                CorrectAnswers = CorrectAnswers + 1;
            }
            if (Q4 == 2)
            {
                CorrectAnswers = CorrectAnswers + 1;
            }
            if (Q5 == 4)
            {
                CorrectAnswers = CorrectAnswers + 1;
                var person = db.JobSeeker.Where(x => x.UserId == user).Select(x => x).FirstOrDefault();
                person.Survey1Score = CorrectAnswers;
                db.SaveChanges();
            }
            
            int id = db.JobSeeker.Where(x => x.Name == name).Select(x => x.ID).FirstOrDefault();
            return RedirectToAction("Details", new RouteValueDictionary(new { controller = "JobSeekers", action = "Details", id = id }));

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
        public ActionResult Edit([Bind(Include = "ID,UserId,Q1,Q2,Q3,Q4,Q5,TestACompleted")] Aptitude aptitude)
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
