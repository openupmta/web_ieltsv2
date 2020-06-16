using coderush.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coderush.Controllers.Clients
{
    public class GioiThieuController : Controller
    {
        private IeltsDBContext db = new IeltsDBContext();
        // GET: GioiThieu
        public ActionResult Index()
        {
            ViewBag.model = db.introduces.FirstOrDefault();
            return View("~/Views/GioiThieu/Index.cshtml");
        }
    }
}