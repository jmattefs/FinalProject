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
                eI.TestCCompleted = true;
                var user = eI.UserId;
                var name = db.Users.Where(x => x.Id == user).Select(x => x.Name).FirstOrDefault();

                eI.UserId = User.Identity.GetUserId();
                var js = db.JobSeeker.Where(x => x.UserId == eI.UserId).Select(x => x).FirstOrDefault();
                js.Survey3Complete = true;                
                db.EIs.Add(eI);
                db.SaveChanges();
                TestResults(eI);

                int id = db.JobSeeker.Where(x => x.Name == name).Select(x => x.ID).FirstOrDefault();
                return RedirectToAction("Details", "JobSeekers", new { id = id });
            }

            return View(eI);
        }
        public ActionResult TestResults(EI ei)
        {
            var user = ei.UserId;
            var name = db.Users.Where(x => x.Id == user).Select(x => x.Name).FirstOrDefault();
            var Result = "";

            int Q1 = ei.Q1;
            int Q2 = ei.Q2;
            int Q3 = ei.Q3;
            int Q4 = ei.Q4;
            int Q5 = ei.Q5;

            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;
            int e = 0;

            Dictionary<string, int> ABCDE = new Dictionary<string, int>();
            ABCDE.Add("a", 0);
            ABCDE.Add("b", 0);
            ABCDE.Add("c", 0);
            ABCDE.Add("d", 0);
            ABCDE.Add("e", 0);

            if(Q1 == 1)
            {
                ABCDE["a"] = a + 1;
            } else if (Q1 == 2)
            {
                ABCDE["b"] = b + 1;                 
            } else if (Q1 == 3)
            {
                ABCDE["c"] = c + 1;
            } else if (Q1 == 4)
            {
                ABCDE["d"] = d + 1;
            } else if (Q1 == 5)
            {
                ABCDE["e"] = e + 1;
            }

                if (Q2 == 1)
                {
                    ABCDE["a"] = a + 1;
                }
                else if (Q2 == 2)
                {
                    ABCDE["b"] = b + 1;
                }
                else if (Q2 == 3)
                {
                    ABCDE["c"] = c + 1;
                }
                else if (Q2 == 4)
                {
                    ABCDE["d"] = d + 1;
                }
                else if (Q2 == 5)
                {
                    ABCDE["e"] = e + 1;
                }

                    if (Q3 == 1)
                    {
                        ABCDE["a"] = a + 1;
                    }
                    else if (Q3 == 2)
                    {
                        ABCDE["b"] = b + 1;
                    }
                    else if (Q3 == 3)
                    {
                        ABCDE["c"] = c + 1;
                    }
                    else if (Q3 == 4)
                    {
                        ABCDE["d"] = d + 1;
                    }
                    else if (Q3 == 5)
                    {
                        ABCDE["e"] = e + 1;
                    }

                        if (Q4 == 1)
                        {
                            ABCDE["a"] = a + 1;
                        }
                        else if (Q4 == 2)
                        {
                            ABCDE["b"] = b + 1;
                        }
                        else if (Q4 == 3)
                        {
                            ABCDE["c"] = c + 1;
                        }
                        else if (Q4 == 4)
                        {
                            ABCDE["d"] = d + 1;
                        }
                        else if (Q4 == 5)
                        {
                            ABCDE["e"] = e + 1;
                        }

                            if (Q5 == 1)
                            {
                                ABCDE["a"] = a + 1;
                            }
                            else if (Q5 == 2)
                            {
                                ABCDE["b"] = b + 1;
                            }
                            else if (Q5 == 3)
                            {
                                ABCDE["c"] = c + 1;
                            }
                            else if (Q5 == 4)
                            {
                                ABCDE["d"] = d + 1;
                            }
                            else if (Q5 == 5)
                            {
                                ABCDE["e"] = e + 1;
                            }

            var max = ABCDE.Values.Max();
            var maxkey = ABCDE.FirstOrDefault(x => x.Value == max).Key;

            if (maxkey == "a")
            {
                Result = "Very Poor EI";
            }
            if (maxkey == "b")
            {
                Result = "Poor EI";
            }
            if (maxkey == "c")
            {
                Result = "Average EI";
            }
            if (maxkey == "d")
            {
                Result = "Good EI";
            }
            if (maxkey == "e")
            {
                Result = "Excellent EI";
            }

            var person = db.JobSeeker.Where(x => x.UserId == user).Select(x => x).FirstOrDefault();
            person.Survey3Score = Result;
            db.SaveChanges();

            return View();
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
