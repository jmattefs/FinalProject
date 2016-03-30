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
    public class PersonalitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Personalities
        public ActionResult Index()
        {
            return View(db.Personalities.ToList());
        }

        // GET: Personalities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personality personality = db.Personalities.Find(id);
            if (personality == null)
            {
                return HttpNotFound();
            }
            return View(personality);
        }

        // GET: Personalities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personalities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserId,Q1,Q2,Q3,Q4,Q5,Q6,Q7,TestBCompleted")] Personality personality)
        {
            if (ModelState.IsValid)
            {
                personality.TestBCompleted = true;
                var user = personality.UserId;
                var name = db.Users.Where(x => x.Id == user).Select(x => x.Name).FirstOrDefault();

                personality.UserId = User.Identity.GetUserId();
                var js = db.JobSeeker.Where(x => x.UserId == personality.UserId).Select(x => x).FirstOrDefault();
                js.Survey2Complete = true;

                db.Personalities.Add(personality);
                db.SaveChanges();

                TestResults(personality);

                int id = db.JobSeeker.Where(x => x.Name == name).Select(x => x.ID).FirstOrDefault();
                return RedirectToAction("Details", "JobSeekers", new { id = id });
            }

            return View(personality);
        }
        public ActionResult TestResults(Personality p)
        {
            var user = p.UserId;
            var name = db.Users.Where(x => x.Id == user).Select(x => x.Name).FirstOrDefault();
            var Result = "";
            
            int Q1 = p.Q1;
            int Q2 = p.Q2;
            int Q3 = p.Q3;
            int Q4 = p.Q4;
            int Q5 = p.Q5;
            int Q6 = p.Q6;
            int Q7 = p.Q7;
            int O = 0;
            int C = 0;
            int E = 0;
            int A = 0;
            int N = 0;
          
            Dictionary<string, int> OCEAN = new Dictionary<string, int>();
            OCEAN.Add("O", 0);
            OCEAN.Add("C", 0);
            OCEAN.Add("E", 0);
            OCEAN.Add("A", 0);
            OCEAN.Add("N", 0);

            if (Q1 == 1)
            {
                OCEAN["O"] = O - 2;
                OCEAN["O"] = O - 2;
            } else if (Q1 == 3)
            {
                OCEAN["O"] = O + 2;
            }
            if (Q2 == 1)
            {
                OCEAN["C"] = C - 2;
            }
            else if (Q2 == 3)
            {
                OCEAN["C"] = C + 2;
            }
            if (Q3 == 1)
            {
                OCEAN["E"] = E - 2;
            }
            else if (Q3 == 3)
            {
                OCEAN["E"] = E + 2;
                OCEAN["N"] = N - 1;
            }
            if (Q4 == 1)
            {
                OCEAN["A"] = A - 2;
            }
            else if (Q4 == 3)
            {
                OCEAN["A"] = A + 2;
                OCEAN["E"] = E + 1;
            }
            if (Q5 == 1)
            {
                OCEAN["N"] = N - 2;
                OCEAN["A"] = A + 1;
            }
            else if (Q5 == 3)
            {
                OCEAN["N"] = N + 2;
                OCEAN["A"] = A - 1;
            }
            if (Q6 == 1)
            {
                OCEAN["O"] = O + 1;
            }
            else if (Q6 == 3)
            {
                OCEAN["O"] = O - 1;
                OCEAN["E"] = E + 1;
            }
            if (Q7 == 1)
            {
                OCEAN["C"] = C + 1;
            }
            else if (Q7 == 3)
            {
                OCEAN["C"] = C - 1;
                OCEAN["N"] = N + 1; 
            }

        
            var max3 = OCEAN.Values.Max();
            var value = OCEAN.FirstOrDefault(x => x.Value == max3).Key;

            if(value == "O")
            {
                Result = "Open";
            }
            if (value == "C")
            {
                Result = "Conscientous";
            }
            if (value == "E")
            {
                Result = "Extrovert";
            }
            if (value == "A")
            {
                Result = "Agreeable";
            }
            if (value == "N")
            {
                Result = "Neurotic";
            }

            var person = db.JobSeeker.Where(x => x.UserId == user).Select(x => x).FirstOrDefault();
            person.Survey2Score = Result;

            if(Result == "Open")
            {
                person.Test2ScoreINT = 1;

            } else if (Result == "Conscientous")
            {
                person.Test2ScoreINT = 2;
            }
            else if (Result == "Extrovert")
            {
                person.Test2ScoreINT = 3;
            }
            else if (Result == "Agreeable")
            {
                person.Test2ScoreINT = 4;
            }
            else if (Result == "Neurotic")
            {
                person.Test2ScoreINT = 5;
            }


            db.SaveChanges();

            return View();
       
            

        }
        // GET: Personalities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personality personality = db.Personalities.Find(id);
            if (personality == null)
            {
                return HttpNotFound();
            }
            return View(personality);
        }

        // POST: Personalities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserId,Q1,Q2,Q3,Q4,Q5,Q6,Q7,TestBCompleted")] Personality personality)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personality).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personality);
        }

        // GET: Personalities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personality personality = db.Personalities.Find(id);
            if (personality == null)
            {
                return HttpNotFound();
            }
            return View(personality);
        }

        // POST: Personalities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personality personality = db.Personalities.Find(id);
            db.Personalities.Remove(personality);
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
        public ActionResult TestView()
        {
            return View();
        }
    }
}
