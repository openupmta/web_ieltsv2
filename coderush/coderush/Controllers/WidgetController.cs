using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coderush.Controllers
{
    public class WidgetController : Controller
    {
        // GET: Widget
        public ActionResult Index()
        {
            return View();
        }
    }
}