using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace v2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        { return View(); }

        public ActionResult Shop()
        { return View(); }

        public ActionResult Commands()
        { return View(); }

    }
}