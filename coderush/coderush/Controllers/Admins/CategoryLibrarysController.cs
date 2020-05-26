using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using coderush.Models;

namespace coderush.Controllers.Admins
{
    public class CategoryLibrarysController : Controller
    {
        private IeltsDBContext db = new IeltsDBContext();

        // GET: CategoryLibrarys
        public ActionResult Index()
        {
            return View(db.category_librarys.ToList());
        }

        // GET: CategoryLibrarys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            category_librarys category_librarys = db.category_librarys.Find(id);
            if (category_librarys == null)
            {
                return HttpNotFound();
            }
            return View(category_librarys);
        }

        // GET: CategoryLibrarys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryLibrarys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ca_id,ca_name,ca_slug,ca_icon,ca_status,ca_created_at,ca_updated_at")] category_librarys category_librarys)
        {
            if (ModelState.IsValid)
            {
                db.category_librarys.Add(category_librarys);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category_librarys);
        }

        // GET: CategoryLibrarys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            category_librarys category_librarys = db.category_librarys.Find(id);
            if (category_librarys == null)
            {
                return HttpNotFound();
            }
            return View(category_librarys);
        }

        // POST: CategoryLibrarys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ca_id,ca_name,ca_slug,ca_icon,ca_status,ca_created_at,ca_updated_at")] category_librarys category_librarys)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category_librarys).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category_librarys);
        }

        // GET: CategoryLibrarys/Delete/5
        public ActionResult Delete(int? id)
        {
            category_librarys category_librarys = db.category_librarys.Find(id);
            db.category_librarys.Remove(category_librarys);
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
