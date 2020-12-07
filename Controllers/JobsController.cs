using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication2.Models;
using System.IO;
using Microsoft.AspNet.Identity;
using WebApplication1.Models.GetPay;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication1.Controllers
{
    [Authorize]

   
    public class JobsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jobs
        public ActionResult Index()
        {
            var jobs = db.Jobs.Include(j => j.catagory);
            return View(jobs.ToList());
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
            ViewBag.catagoryid = new SelectList(db.catagories, "id", "catagoryname");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Job job , HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/uploads"), upload.FileName);
                upload.SaveAs(path);
                job.jobimage = upload.FileName;
                         

                var userid =  User.Identity.GetUserId();

                job.userid = userid;

                Factory factor = new Factory();
                var user =  db.Users.Where(c => c.Id == userid).Single();
                var joptype = user.usertype;          
                var mony = factor.Employee(joptype);
                if (mony != null)
                {
                    job.bonus = mony.getbonus();
                    job.pay = mony.getpay();
                }
               

                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.catagoryid = new SelectList(db.catagories, "id", "catagoryname", job.catagoryid);
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
            ViewBag.catagoryid = new SelectList(db.catagories, "id", "catagoryname", job.catagoryid);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Job job, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string oldpath = Path.Combine(Server.MapPath("~/uploads"), job.jobimage) ;

                if (upload != null)
                {
                    System.IO.File.Delete(oldpath);
                    string path = Path.Combine(Server.MapPath("~/uploads"), upload.FileName);
                    upload.SaveAs(path);
                    job.jobimage = upload.FileName;
                }
                
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.catagoryid = new SelectList(db.catagories, "id", "catagoryname", job.catagoryid);
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
