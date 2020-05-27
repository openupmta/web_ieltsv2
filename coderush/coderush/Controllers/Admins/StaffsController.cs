using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using coderush.Models;
using Common;
using Microsoft.AspNet.Identity;

namespace coderush.Controllers.Admins
{
    public class StaffsController : Controller
    {
        private IeltsDBContext db = new IeltsDBContext();
        [Authorize]
        // GET: Staffs
        public ActionResult Index()
        {
            var staffs = db.staffs.Include(s => s.group_role);
            

            return View(staffs.ToList());
        }

        // GET: Staffs/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff staff = db.staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // GET: Staffs/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.group_role_id = new SelectList(db.group_role, "gr_id", "gr_name");
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sta_id,sta_email,sta_username,sta_fullname,sta_password,group_role_id,sta_image,sta_created_at,sta_update_at")] staff staff)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Check_UserName(staff.sta_username,null))
                    {
                        ModelState.AddModelError(string.Empty, "Tên tài khoản không được trùng");
                        ViewBag.group_role_id = new SelectList(db.group_role, "gr_id", "gr_name", staff.group_role_id);
                        return View(staff);
                    }
                    staff.sta_fullname = staff.sta_fullname.Trim();
                    staff.sta_email = staff.sta_email.Trim();
                    staff.sta_created_at = DateTime.Now;
                    db.staffs.Add(staff);
                    string content = System.IO.File.ReadAllText("D:/Ki2Nam3/CNWeb/ASP.NET MVC 5 - Template - AdminLTE/coderush/Common/Template/sendmail.html");
                    content = content.Replace("{{Username}}", staff.sta_username);
                    content = content.Replace("{{Password}}", staff.sta_password);

                    new MailHelper().SendMail(staff.sta_email, "Thông tin tài khoản", content);
                    db.SaveChanges();
                
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return View("Error");
                }
                return RedirectToAction("Index");
            }

            ViewBag.group_role_id = new SelectList(db.group_role, "gr_id", "gr_name", staff.group_role_id);
            return View(staff);
        }

        // GET: Staffs/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff staff = db.staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            ViewBag.group_role_id = new SelectList(db.group_role, "gr_id", "gr_name", staff.group_role_id);
            return View(staff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sta_id,sta_email,sta_username,sta_fullname,sta_password,group_role_id,sta_image,sta_created_at,sta_update_at")] staff staff)
        {
            if (ModelState.IsValid)
            {
                staff.sta_fullname = staff.sta_fullname.Trim();
                staff.sta_email = staff.sta_email.Trim();
                staff.sta_update_at = DateTime.Now;
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.group_role_id = new SelectList(db.group_role, "gr_id", "gr_name", staff.group_role_id);
            return View(staff);
        }

        // GET: Staffs/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            staff staff = db.staffs.Find(id);
            db.staffs.Remove(staff);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #region [Check_Duplicate]
        private bool Check_UserName(string name, int? sta_id = null)
        {
            bool results = true;
            if(sta_id == null)
            {
                var user = db.staffs.Where(x => x.sta_fullname.Trim().ToLower().Equals(name.Trim().ToLower())).FirstOrDefault();
                if (user == null) results =  true;
                else results =  false;
            }
            else
            {
                List<staff> list_staff = db.staffs.ToList();
                staff temp = db.staffs.Find(sta_id);
                list_staff.Remove(temp);
                bool res = list_staff.Exists(x => x.sta_fullname.Trim().ToLower().Equals(name.Trim().ToLower()));
                results = res;
            }
            return results;
        }
        #endregion

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
