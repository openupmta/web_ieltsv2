using coderush.Areas.Admins.Models.DAO;
using coderush.Areas.Admins.Models.EF;
using coderush.Areas.Admins.Models.EF.ViewModel;
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
        #region["Search"]
        [Authorize]
        public ActionResult Index(int PageNum = 1, int PageSize = 5, string search = null)
        {
            ViewBag.PageSize = PageSize;
            StaffDao dao = new StaffDao();
            var lst = dao.GetAllSearch(PageNum, PageSize, search);

            return View(lst);
        }
        #endregion
        #region["Create"]
        [Authorize]
        public ActionResult Create()
        {
            GroupRoleDao dao = new GroupRoleDao();
            ViewBag.lst_gr = dao.GetAll();
            return View();
        }
        [Authorize]
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
                        var path = Path.Combine(Server.MapPath("~/Areas/Admins/Content/Photo/Staff/"),
                                                System.IO.Path.GetFileName(image));
                        photo.SaveAs(path);

                        sta.sta_image = image;
                        //Mail 
                        string content = System.IO.File.ReadAllText("D:/Kì 2 Năm 3/CNWEB/web_ieltsv2/coderush/Common/Template/sendmail.html");
                        content = content.Replace("{{Username}}", sta.sta_username);
                        content = content.Replace("{{Password}}", sta.sta_password);

                        new MailHelper().SendMail(sta.sta_email, "Thông tin tài khoản", content);
                       
                    }
                    else
                    {
                        sta.sta_image = "tienmta7.png";
                    }
                    sta.sta_created_at = DateTime.Now;
                    dao.Create(sta);
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
        #endregion
        #region["Edit"]
        [Authorize]
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
        [Authorize]
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
                            var image_old = Path.Combine(Server.MapPath("~/Areas/Admins/Content/Photo/Staff/"),
                                                System.IO.Path.GetFileName(exists_sta.sta_image));
                            if (System.IO.File.Exists(image_old))
                            {
                                System.IO.File.Delete(image_old);
                            }
                            var image_new = Path.Combine(Server.MapPath("~/Areas/Admins/Content/Photo/Staff/"),
                                                System.IO.Path.GetFileName(image));


                            photo.SaveAs(image_new);
                        }
                        sta.sta_image = image;
                        sta.sta_update_at = DateTime.Now;
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
        #endregion
        #region["Delete"]
        [Authorize]
        public ActionResult Delete(int id)
        {
            StaffDao dao = new StaffDao();
            staff exists_sta = dao.GetById(id);

            var image_old = Path.Combine(Server.MapPath("~/Areas/Admins/Content/Photo/Staff/"),
                                System.IO.Path.GetFileName(exists_sta.sta_image));
            if (System.IO.File.Exists(image_old))
            {
                System.IO.File.Delete(image_old);
            }
            dao.Delete(id);
            return RedirectToAction("Index");
        }
        #endregion
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