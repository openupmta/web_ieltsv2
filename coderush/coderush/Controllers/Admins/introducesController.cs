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
    public class IntroducesController : Controller
    {
        private IeltsDBContext db = new IeltsDBContext();

        // GET: Introduces
        public ActionResult Index()
        {
            return View(db.introduces.ToList());
        }

        // GET: Introduces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            introduce introduce = db.introduces.Find(id);
            if (introduce == null)
            {
                return HttpNotFound();
            }
            return View(introduce);
        }

        // GET: Introduces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Introduces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "in_id,in_logo,in_address,in_phone,in_email,in_facebook,in_title,in_content,in_created_at,in_updated_at")] introduce introduce)
        {
            if (ModelState.IsValid)
            {
                introduce.in_created_at = DateTime.Now;
                db.introduces.Add(introduce);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(introduce);
        }

        // GET: Introduces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            introduce introduce = db.introduces.Find(id);
            if (introduce == null)
            {
                return HttpNotFound();
            }
            return View(introduce);
        }

        // POST: Introduces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "in_id,in_logo,in_address,in_phone,in_email,in_facebook,in_title,in_content,in_created_at,in_updated_at")] introduce introduce)
        {
            if (ModelState.IsValid)
            {
                introduce.in_updated_at = DateTime.Now;
                db.Entry(introduce).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(introduce);
        }

        // GET: Introduces/Delete/5
        public ActionResult Delete(int? id)
        {
            introduce introduce = db.introduces.Find(id);
            db.introduces.Remove(introduce);
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
