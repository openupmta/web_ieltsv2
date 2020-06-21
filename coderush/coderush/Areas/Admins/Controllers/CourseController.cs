using coderush.Areas.Admins.Models.DAO;
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
    public class CourseController : Controller
    {
        // GET: Admins/Course
        public ActionResult Index(int PageNum = 1, int PageSize = 3, string search = null)
        {
            CourseDao CouDao = new CourseDao();
            var listCou = CouDao.GetAllSearch(PageNum, PageSize, search);

            return View(listCou);
        }

        public ActionResult Create()
        {
            DBIeltsContext db = new DBIeltsContext();
            List<teacher> teacher = db.teachers.ToList();
            SelectList listTe = new SelectList(teacher, "te_id", "te_name");
            ViewBag.list_te = listTe;
            return View();
        }

        [HttpPost]
        public ActionResult Create(course cou, HttpPostedFileBase photo)
        {
            TeacherDao teDao = new TeacherDao();
            CourseDao dao = new CourseDao();

            if (ModelState.IsValid)
            {
                try
                {
                    if (photo != null && photo.ContentLength > 0)
                    {
                        string image = String.Concat(photo.FileName);
                        var path = Path.Combine(Server.MapPath("~/Areas/Admins/Content/Photo/Course/"),
                                                System.IO.Path.GetFileName(image));
                        photo.SaveAs(path);

                        cou.co_image = image;

                        cou.co_created_at = DateTime.Now;

                    //var filename = Path.GetFileName(photo.FileName);
                    //var path = Path.Combine(Server.MapPath("~/Areas/Admins/Content/Photo/Course/"), filename);
                    //photo.SaveAs(path);
                    //// Add avatar reference to model and save   
                    //cou.co_image = string.Concat("~/Areas/Admins/Content/Photo/Course/", filename);

                    dao.Create(cou);
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return View("Error");
                }
            }
            else
            {
                ViewBag.lst_te = teDao.GetAll();
                DBIeltsContext db = new DBIeltsContext();
                var teacher = db.teachers.ToList();
                SelectList listTe = new SelectList(teacher, "te_id", "te_name");
                ViewBag.list_te = listTe;
                return View(cou);
            }
        }

        public ActionResult Edit(int? id)
        {
            CourseDao couDao = new CourseDao();
            if (id == null)
            {
                return View("Error");
            }
            course course = couDao.GetById(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            TeacherDao teDao = new TeacherDao();
            var teacher = teDao.GetAll();
            SelectList list_te = new SelectList(teacher, "te_id", "te_name");
            ViewBag.list_te = list_te;
            return View(course);
        }

        [HttpPost]
        public ActionResult Edit(course cou, HttpPostedFileBase photo)
        {
            TeacherDao teDao = new TeacherDao();
            CourseDao couDao = new CourseDao();
            if (ModelState.IsValid)
            {
                try
                {
                    if (photo != null && photo.ContentLength > 0)
                    {
                        course exists_cou = couDao.GetById(cou.co_id);
                        string image = String.Concat(cou.co_name, photo.FileName); 
                        if (!image.Equals(exists_cou.co_image))
                        {
                            var image_old = Path.Combine(Server.MapPath("~/Areas/Admins/Content/Photo/course/"),
                                                System.IO.Path.GetFileName(exists_cou.co_image));
                            if (System.IO.File.Exists(image_old))
                            {
                                System.IO.File.Delete(image_old);
                            }
                            var image_new = Path.Combine(Server.MapPath("~/Areas/Admins/Content/Photo/course/"),
                                                System.IO.Path.GetFileName(image));


                            photo.SaveAs(image_new);
                        }
                        cou.co_image = image;
                        cou.co_updated_at = DateTime.Now;
                        couDao.Update(cou);
                    }
                    else
                    {
                        course exists_cou = couDao.GetById(cou.co_id);
                        cou.co_image = exists_cou.co_image;
                        couDao.Update(cou);
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return View("Error");
                }

            }
            else
            {
                ViewBag.lst_te = teDao.GetAll();
                var teacher = teDao.GetAll();
                SelectList list_te = new SelectList(teacher, "te_id", "te_name");
                ViewBag.list_te = list_te;
                return View(cou);
            }
        }


        public ActionResult Delete(int id)
        {
            CourseDao dao = new CourseDao();
            course exists_cou = dao.GetById(id);

            var image_old = Path.Combine(Server.MapPath("~/Areas/Admins/Content/Photo/course/"),
                                System.IO.Path.GetFileName(exists_cou.co_image));
            if (System.IO.File.Exists(image_old))
            {
                System.IO.File.Delete(image_old);
            }
            dao.Delete(id);
            return RedirectToAction("Index");
        }
        #region[Check Duplicate]

        public JsonResult ExsitsCourseName(string cou_Coursename, int? cou_id)
        {
            CourseDao dao = new CourseDao();
            List<course> lts_cou = dao.GetAll();
            if (cou_id != null)
            {
                lts_cou.Remove(dao.GetById(cou_id)); //////////////??????????????????????
            }
            return Json(!lts_cou.Any(x => x.co_name.Trim().ToLower() == cou_Coursename.Trim().ToLower()), JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}