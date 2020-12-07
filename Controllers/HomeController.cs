using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var list = db.catagories.ToList();
            return View(list);
        }

        public ActionResult Details(int id)
        {
            var job = db.Jobs.Find(id);
            Session["jobid"] = id;
            if (job == null)
            {
                return HttpNotFound();
            }
            else
            {
                Session["jobid"] = id;
                return View(job);
            }         
        }
        [Authorize]
        public ActionResult Apply()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Apply(string message)
        {
            var userid = User.Identity.GetUserId();
            var jobid = (int)Session["jobid"];
            var job = new ApplyJob();

            var check = db.ApplyJobs.Where(a => a.jobid == jobid && a.userid == userid).ToList();

            if (check.Count < 1)
            {
                job.jobid = jobid;
                job.userid = userid;
                job.message = message;
                job.ApplyTime = DateTime.Now;

                db.ApplyJobs.Add(job);
                db.SaveChanges();

                ViewBag.result = "The Job Added Successfully";

                return View();
            }
            else
            {
                ViewBag.result = "Sorry The Job Added Before";

                return View();
            }        
        }


        [Authorize]
        public ActionResult GetJobsByUser()
        {
            var userid = User.Identity.GetUserId();
            var jobs = db.ApplyJobs.Where(a => a.userid == userid);
            return View(jobs.ToList());
        }
         
        [Authorize]
        public ActionResult GetJobsByPuplisher()
        {
            var userid = User.Identity.GetUserId();
            var jobs = from app in db.ApplyJobs
                       join job in db.Jobs
                       on app.jobid equals job.id
                       where job.user.Id == userid
                       select app;

            var groub = from j in jobs
                        group j by j.job.jobtitle
                        into gr
                        select new JobsViweModel
                        {
                            jobtitle = gr.Key,
                            itemes = gr
                        };

            return View(groub.ToList());
        }

        [Authorize]
        public ActionResult Detailsforjob(int id)
        {
            var job = db.ApplyJobs.Find(id);           
            if (job == null)
            {
                return HttpNotFound();
            }
            else
            {              
                return View(job);
            }
        }
        // GET: Jobs/Edit/5
        public ActionResult Edit(int id)
        {
           
            var job = db.ApplyJobs.Find(id);
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
        public ActionResult Edit(ApplyJob job)
        {
            if (ModelState.IsValid)
            {
                job.ApplyTime = DateTime.Now;
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetJobsByUser");
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
            var job = db.ApplyJobs.Find(id);
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
            var job = db.ApplyJobs.Find(id);
            db.ApplyJobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("GetJobsByUser");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
                
            return View();
        }

        [HttpPost]
        public ActionResult Contact(contactmodel contact)
        {
            var mail = new MailMessage();
            var info = new NetworkCredential("ma906191@gmail.com", "12345hhh");
            mail.From = new MailAddress(contact.email);
            mail.To.Add(new MailAddress("ma906191@gmail.com"));
            mail.Subject = contact.subject;
            mail.IsBodyHtml = true;
            string body = "the name of sender :" + contact.name + "<br/>"
                           + "the Email :" + contact.email + "<br>"
                           + "The subject is :"+contact.subject + "<br>"
                           + "The message is :" + contact.message+ "<br>";
            mail.Body = body;

            var SmtpClient = new SmtpClient("smtp.gmail.com",587);
            SmtpClient.EnableSsl = true;
            SmtpClient.Credentials = info;
            SmtpClient.Send(mail);

            return RedirectToAction("Index");
        }

        public ActionResult search()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult search(string search)
        {
            var result = db.Jobs.Where(a => a.jobtitle.Contains(search) 
            || a.jobdesc.Contains(search)
            || a.catagory.catagoryname.Contains(search)
            || a.catagory.catagorydesc.Contains(search)).ToList();
            return View(result);
        }
    }
}