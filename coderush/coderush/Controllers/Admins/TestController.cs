//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using WebShopTav.Areas.Admin.Models.Entites;
//using WebShopTav.Areas.Admin.Models.Dao;
//using System.IO;

//namespace WebShopTav.Areas.Admin.Controllers
//{
//    public class ProductController : Controller
//    {
//        public ActionResult Delete(int id)
//        {
//            ProductDao dao = new ProductDao();
//            dao.Delete(id);
//            return Redirect("~/Admin/Product/Index");
//        }

//        public ActionResult Add()
//        {
//            List<Category> ls = new List<Category>();
//            CategoryDao dao = new CategoryDao();
//            return View(dao.ListCate());
//        }
//        public ActionResult Edit(int id)
//        {
//            List<Category> ls = new List<Category>();
//            CategoryDao dao = new CategoryDao();
//            ProductDao proDao = new ProductDao();
//            ViewBag.cat = dao.ListCate();
//            ViewBag.pro = proDao.getById(id);
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Edit(int id, string idcategory, string description, string name, string amount, string price, HttpPostedFileBase photo)
//        {
//            var img = Path.GetFileName(photo.FileName);
//            ProductDao dao = new ProductDao();
//            Product product = dao.getById(id);
//            product.amount = Int32.Parse(amount);
//            product.price = Int32.Parse(price);
//            product.name = name;
//            product.description = description;
//            product.idcategory = Int32.Parse(idcategory);
//            if (ModelState.IsValid)
//            {
//                if (photo != null && photo.ContentLength > 0)
//                {
//                    var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/Photo/"),
//                                            System.IO.Path.GetFileName(photo.FileName));
//                    photo.SaveAs(path);

//                    product.photo = photo.FileName;
//                    dao.Add(product);
//                }
//                return RedirectToAction("Index");
//            }
//            else
//            {
//                return View(product);
//            }
//        }

//        [HttpPost]
//        public ActionResult Add(string idcategory, string description, string name, string amount, string price, HttpPostedFileBase photo)
//        {
//            var img = Path.GetFileName(photo.FileName);
//            Product product = new Product();
//            product.amount = Int32.Parse(amount);
//            product.price = Int32.Parse(price);
//            product.name = name;
//            product.description = description;
//            product.idcategory = Int32.Parse(idcategory);
//            if (ModelState.IsValid)
//            {
//                if (photo != null && photo.ContentLength > 0)
//                {
//                    var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/Photo/"),
//                                            System.IO.Path.GetFileName(photo.FileName));
//                    photo.SaveAs(path);

//                    product.photo = photo.FileName;
//                    ProductDao dao = new ProductDao();
//                    dao.Add(product);
//                }
//                return RedirectToAction("Index");
//            }
//            else
//            {
//                return View(product);
//            }
//        }


//        //public ActionResult Index(int PageNum=1, int PageSize=5)
//        //{
//        //    ProductDao dao = new ProductDao();
//        //    return View(dao.ListProductPage(PageNum, PageSize));
//        //}

//        public ActionResult Index(int PageNum = 1, int PageSize = 5)
//        {
//            ProductDao dao = new ProductDao();
//            return View(dao.lstjoin(PageNum, PageSize));
//        }
//    }
//}