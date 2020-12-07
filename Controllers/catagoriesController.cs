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

namespace WebApplication1.Controllers
{
    [Authorize(Roles="admins")]
    public class catagoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: catagories
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.catagories.ToList());
        }

        // GET: catagories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            catagory catagory = db.catagories.Find(id);
            if (catagory == null)
            {
                return HttpNotFound();
            }
            return View(catagory);
        }

        // GET: catagories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: catagories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,catagoryname,catagorydesc")] catagory catagory)
        {
            if (ModelState.IsValid)
            {
                db.catagories.Add(catagory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(catagory);
        }

        // GET: catagories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            catagory catagory = db.catagories.Find(id);
            if (catagory == null)
            {
                return HttpNotFound();
            }
            return View(catagory);
        }

        // POST: catagories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,catagoryname,catagorydesc")] catagory catagory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catagory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catagory);
        }

        // GET: catagories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            catagory catagory = db.catagories.Find(id);
            if (catagory == null)
            {
                return HttpNotFound();
            }
            return View(catagory);
        }

        // POST: catagories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            catagory catagory = db.catagories.Find(id);
            db.catagories.Remove(catagory);
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
