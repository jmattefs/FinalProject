using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Microsoft.AspNet.Identity;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            var ext = Path.GetExtension(file.FileName);
            var pdf = ".pdf";

            if (!file.FileName.Contains(pdf))
            {
                return View("Contact");   /*make this something else*/
            }
            else
            {
                if (file != null && file.ContentLength > 0)
                {
                    var id = User.Identity.GetUserId();
                    var user = db.JobSeeker.Where(x => x.UserId == id).Select(x => x).FirstOrDefault();
                    var fileName = Path.GetFileName(id+".pdf");
                    var path = Path.Combine(Server.MapPath("~/Resumes"), fileName);
                    
                   
                    
                    Models.File aResume = new Models.File();
                    aResume.FileName = user.UserId;
                    
                    
                    db.File.Add(aResume);
                    user.UploadedResume = true;
                    db.SaveChanges();
                    user.ResumeID = aResume.FileID;
                    db.SaveChanges();
                    file.SaveAs(path);
                }
                return RedirectToAction("Index");
            }


        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}