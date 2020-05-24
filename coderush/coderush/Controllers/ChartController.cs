using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coderush.Controllers
{
    public class ChartController : Controller
    {
        public ActionResult ChartJS()
        {
            return View();
        }

        public ActionResult Morris()
        {
            return View();
        }

        public ActionResult Flot()
        {
            return View();
        }

        public ActionResult Inline()
        {
            return View();
        }
    }
}