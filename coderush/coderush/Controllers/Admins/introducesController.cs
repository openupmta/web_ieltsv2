﻿using System;
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
    public class introducesController : Controller
    {
        private IeltsDBContext db = new IeltsDBContext();

        // GET: introduces
        public ActionResult Index()
        {
            return View(db.introduces.ToList());
        }

        // GET: introduces/Details/5
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

        // GET: introduces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: introduces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "in_id,in_logo,in_address,in_phone,in_email,in_facebook,in_title,in_content,in_created_at,in_updated_at")] introduce introduce)
        {
            if (ModelState.IsValid)
            {
                db.introduces.Add(introduce);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(introduce);
        }

        // GET: introduces/Edit/5
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

        // POST: introduces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "in_id,in_logo,in_address,in_phone,in_email,in_facebook,in_title,in_content,in_created_at,in_updated_at")] introduce introduce)
        {
            if (ModelState.IsValid)
            {
                db.Entry(introduce).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(introduce);
        }

        // GET: introduces/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: introduces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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
