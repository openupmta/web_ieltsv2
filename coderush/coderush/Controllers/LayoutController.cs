using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coderush.Controllers
{
    public class LayoutController : Controller
    {
        public ActionResult Top()
        {
            return View();
        }

        public ActionResult Boxed()
        {
            return View();
        }

        public ActionResult Fixed()
        {
            return View();
        }

        public ActionResult Collapsed()
        {
            return View();
        }
    }
}