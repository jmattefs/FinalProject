﻿using System;
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
    public class JobSeekersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JobSeekers
        public ActionResult Index()
        {
            return View(db.JobSeeker.ToList());
        }
        
        
        // GET: JobSeekers/Details/5
        public ActionResult Details(int? id)
        {
            var UserID = User.Identity.GetUserId();
            var user = db.Users.Where(x => x.Id == UserID).Select(x => x.Name).FirstOrDefault();
            JobSeeker js = new JobSeeker();
            js = db.JobSeeker.Where(x => x.Name == user).Select(x => x).FirstOrDefault();

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //JobSeeker jobSeeker = db.JobSeeker.Find(id);
            //if (jobSeeker == null)
            //{
            //    return HttpNotFound();
            //}
            return View(js);
        }

        // GET: JobSeekers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobSeekers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Address,City,State,ZipCode,Info")] JobSeeker jobSeeker)
        {
            if (ModelState.IsValid)
            {
                db.JobSeeker.Add(jobSeeker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobSeeker);
        }

        // GET: JobSeekers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSeeker jobSeeker = db.JobSeeker.Find(id);
            if (jobSeeker == null)
            {
                return HttpNotFound();
            }
            return View(jobSeeker);
        }

        // POST: JobSeekers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address,City,State,ZipCode,Info")] JobSeeker jobSeeker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobSeeker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobSeeker);
        }

        // GET: JobSeekers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSeeker jobSeeker = db.JobSeeker.Find(id);
            if (jobSeeker == null)
            {
                return HttpNotFound();
            }
            return View(jobSeeker);
        }

        // POST: JobSeekers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobSeeker jobSeeker = db.JobSeeker.Find(id);
            db.JobSeeker.Remove(jobSeeker);
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
