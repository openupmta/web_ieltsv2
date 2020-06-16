using coderush.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coderush.Areas.Client.Controllers
{
    public class GioiThieuController : Controller
    {
        // GET: Client/GioiThieu
        private IeltsDBContext db = new IeltsDBContext();
        // GET: GioiThieu
        public ActionResult Index()
        {
            ViewBag.model = db.introduces.FirstOrDefault();
            return View("~/Views/GioiThieu/Index.cshtml");
        }
    }
}