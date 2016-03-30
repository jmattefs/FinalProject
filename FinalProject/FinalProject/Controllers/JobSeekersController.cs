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
using System.Net.Mail;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class JobSeekersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();




        public ActionResult Contact(int? id)
        {
            JobSeeker js = db.JobSeeker.Find(id);
            return View(js);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(JobSeeker js)
        {
            if (ModelState.IsValid)
            {
                var id = User.Identity.GetUserId();
                var sender = db.Employer.Where(x => x.UserId == id).Select(x => x).FirstOrDefault();
                var senderEmail = sender.Email;
                var seekerID = js.ID;
                
                var message = new MailMessage();
                message.To.Add(new MailAddress("recipient@gmail.com"));  // replace with valid value 
                message.From = new MailAddress(senderEmail);  // replace with valid value
                message.Subject = "Job Opportunity";
                message.Body = string.Format(js.EmailMessage);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "genericemployer@gmail.com", 
                        Password = "employer123"  
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    JobSeeker jobseeker = db.JobSeeker.Find(seekerID);
                    return RedirectToAction("Sent",jobseeker);
                }
            }
            return View(js);
        }
        public ActionResult Sent()
        {
            return View();
        }

        // GET: JobSeekers
        public ActionResult Index(string sortOrder)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CitySortParm = sortOrder == "City" ? "city_desc" : "City";
            ViewBag.ZipCodeSortParm = sortOrder == "ZipCode" ? "zipcode_desc" : "ZipCode";
            ViewBag.StateSortParm = sortOrder == "State" ? "state_desc" : "State";

            var js = db.JobSeeker.Select(x => x);
            switch (sortOrder)
            {
                case "City":
                    js = js.OrderBy(s => s.City);
                    break;
                case "city_desc":
                    js = js.OrderByDescending(s => s.City);
                    break;
                case "State":
                    js = js.OrderBy(s => s.State);
                    break;
                case "state_desc":
                    js = js.OrderByDescending(s => s.State);
                    break;
                case "ZipCode":
                    js = js.OrderBy(s => s.ZipCode);
                    break;
                case "zipcode_desc":
                    js = js.OrderByDescending(s => s.ZipCode);
                    break;
                case "name_desc":
                    js = js.OrderByDescending(s => s.Name);
                    break;
                default: 
                    js = js.OrderBy(s => s.Name);
                    break;
            }
            return View(js);
        }
        public ActionResult List(string sortOrder)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CitySortParm = sortOrder == "City" ? "city_desc" : "City";
            ViewBag.ZipCodeSortParm = sortOrder == "ZipCode" ? "zipcode_desc" : "ZipCode";
            ViewBag.StateSortParm = sortOrder == "State" ? "state_desc" : "State";
            ViewBag.TestASortParm = sortOrder == "Apt" ? "apt_desc" : "Apt";
            ViewBag.TestBSortParm = sortOrder == "Pers" ? "pers_desc" : "Pers";
            ViewBag.TestCSortParm = sortOrder == "EI" ? "ei_desc" : "EI";
            

            var js = db.JobSeeker.Select(x => x);
            switch (sortOrder)
            {
                case "City":
                    js = js.OrderBy(s => s.City);
                    break;
                case "city_desc":
                    js = js.OrderByDescending(s => s.City);
                    break;
                case "State":
                    js = js.OrderBy(s => s.State);
                    break;
                case "state_desc":
                    js = js.OrderByDescending(s => s.State);
                    break;
                case "ZipCode":
                    js = js.OrderBy(s => s.ZipCode);
                    break;
                case "zipcode_desc":
                    js = js.OrderByDescending(s => s.ZipCode);
                    break;
                case "name_desc":
                    js = js.OrderByDescending(s => s.Name);
                    break;
                case "Apt":
                    js = js.OrderBy(s => s.Survey1Score);
                    break;
                case "apt_desc":
                    js = js.OrderByDescending(s => s.Survey1Score);
                    break;
                case "Pers":
                    js = js.OrderBy(s => s.Survey2Score);
                    break;
                case "pers_desc":
                    js = js.OrderByDescending(s => s.Survey2Score);
                    break;
                case "EI":
                    js = js.OrderBy(s => s.Survey3Score);
                    break;
                case "ei_desc":
                    js = js.OrderByDescending(s => s.Survey3Score);
                    break;
                default:
                    js = js.OrderBy(s => s.Name);
                    break;
            }


            return View(js);
        }
        [AllowAnonymous]
        // GET: JobSeekers/Details/5
        public ActionResult Details(int? id)
        {
            
            var UserID = User.Identity.GetUserId();
            var role = db.Users.Where(x => x.Id == UserID).Select(x => x.Role).FirstOrDefault();
            if(role == 1)
            {
                var user = db.Users.Where(x => x.Id == UserID).Select(x => x).FirstOrDefault();
                JobSeeker js = new JobSeeker();
                js = db.JobSeeker.Where(x => x.UserId == user.Id).Select(x => x).FirstOrDefault();
                return View(js);
            }

                JobSeeker jobseeker = new JobSeeker();
                jobseeker = db.JobSeeker.Where(x => x.ID == id).Select(x => x).FirstOrDefault();


                return View(jobseeker);
        }
            

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //JobSeeker jobSeeker = db.JobSeeker.Find(id);
            //if (jobSeeker == null)
            //{
            //    return HttpNotFound();
            //}
            
        

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
        public ActionResult Create([Bind(Include = "ID,Name,Address,City,State,ZipCode,Info,UserId,ResumeID, UploadedResume, Email")] JobSeeker jobSeeker)
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
        public ActionResult Edit([Bind(Include = "ID,Name,Address,City,State,ZipCode,Info, UserId, ResumeID, UploadedResume, Survey1Complete, Survey2Complete, Survey3Complete, Survey1Score, Survey2Score, Survey3Score, Email")] JobSeeker jobSeeker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobSeeker).State = EntityState.Modified;
                db.SaveChanges();

                
                return RedirectToAction("Details", new { id = jobSeeker.ID });
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
        public ActionResult GetResume(int ID)
        {
            var id = User.Identity.GetUserId();
            var user = db.JobSeeker.Where(x => x.UserId == id).Select(x => x).FirstOrDefault();

            var resume = db.File.Where(x => x.FileID == ID).Select(x => x).FirstOrDefault();

            return Redirect("~/Resumes/" + resume.FileName +".pdf");

        }
    }
}
