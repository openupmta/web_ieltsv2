﻿using coderush.Areas.Admins.Models.DAO;
using coderush.Areas.Admins.Models.EF;
using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coderush.Areas.Admins.Controllers
{
    public class StaffsController : Controller
    {
        public ActionResult Delete(int id)
        {
            StaffDao dao = new StaffDao();
            dao.Delete(id);
            return Redirect("~/Admin/Product/Index");
        }

        public ActionResult Create()
        {
            GroupRoleDao dao = new GroupRoleDao();
            ViewBag.lst_gr = dao.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(staff sta, HttpPostedFileBase photo)
        {
            GroupRoleDao grDao = new GroupRoleDao();
            StaffDao dao = new StaffDao();
            
            if (ModelState.IsValid)
            {
                try
                {
                    if (photo != null && photo.ContentLength > 0)
                    {
                        string image = String.Concat(sta.sta_username,photo.FileName);
                        var path = Path.Combine(Server.MapPath("~/Areas/Admins/Content/Photo/"),
                                                System.IO.Path.GetFileName(image));
                        photo.SaveAs(path);

                        sta.sta_image = image;
                        //Mail 
                        string content = System.IO.File.ReadAllText("D:/Ki2Nam3/CNWeb/web_ieltsv2/coderush/Common/Template/sendmail.html");
                        content = content.Replace("{{Username}}", sta.sta_username);
                        content = content.Replace("{{Password}}", sta.sta_password);

                        new MailHelper().SendMail(sta.sta_email, "Thông tin tài khoản", content);
                        dao.Create(sta);
                    }
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return View("Error");
                }
            }
            else
            {
                ViewBag.lst_gr =grDao.GetAll();
                return View(sta);
            }
        }

        public ActionResult Edit(int? id)
        {
            StaffDao staDAo = new StaffDao();
            if (id == null)
            {
                return View("Error");
            }
            staff staff = staDAo.GetById(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            GroupRoleDao grDao = new GroupRoleDao();
            ViewBag.lst_gr = grDao.GetAll();
            return View(staff);
        }

        [HttpPost]
        public ActionResult Edit(staff sta, HttpPostedFileBase photo)
        {
            GroupRoleDao grDao = new GroupRoleDao();
            StaffDao staDao = new StaffDao();
            if (ModelState.IsValid)
            {
                try
                {
                    if (photo != null && photo.ContentLength > 0)
                    {
                        staff exists_sta = staDao.GetById(sta.sta_id);
                        string image = String.Concat(sta.sta_username, photo.FileName);
                        if (!image.Equals(exists_sta.sta_image) )
                        {
                            var image_old = Path.Combine(Server.MapPath("~/Areas/Admins/Content/Photo/"),
                                                System.IO.Path.GetFileName(exists_sta.sta_image));
                            if (System.IO.File.Exists(image_old))
                            {
                                System.IO.File.Delete(image_old);
                            }
                            var image_new = Path.Combine(Server.MapPath("~/Areas/Admins/Content/Photo/"),
                                                System.IO.Path.GetFileName(image));


                            photo.SaveAs(image_new);
                        }
                        sta.sta_image = image;
                        staDao.Update(sta);
                    }
                    else
                    {
                        staff exists_sta = staDao.GetById(sta.sta_id);
                        sta.sta_image = exists_sta.sta_image;
                        staDao.Update(sta);
                    }
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return View("Error");
                }
                
            }
            else
            {
                ViewBag.lst_gr = grDao.GetAll();
                return View(sta);
            }
        }

        public ActionResult Index(int PageNum = 1, int PageSize =10)
        {
            StaffDao dao = new StaffDao();
            return View(dao.GetAllSearch(PageNum,PageSize));
        }
        #region[Check Duplicate]

        public JsonResult ExsitsUserName(string sta_username, int? sta_id)
        {
            StaffDao dao = new StaffDao();
            List<staff> lts_sta = dao.GetAll();
            if (sta_id != null)
            {
                lts_sta.Remove(dao.GetById(sta_id));
            }
            return Json(!lts_sta.Any(x => x.sta_username.Trim().ToLower() == sta_username.Trim().ToLower()), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExsitsEmail(string sta_email, int? sta_id)
        {
            StaffDao dao = new StaffDao();
            List<staff> lts_sta = dao.GetAll();
            if (sta_id != null)
            {
                lts_sta.Remove(dao.GetById(sta_id));
            }
            return Json(!lts_sta.Any(x => x.sta_email.Trim().ToLower() == sta_email.Trim().ToLower()), JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}