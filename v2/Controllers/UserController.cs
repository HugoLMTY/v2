using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace v2.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        { return View(); }

        public ActionResult Register()
        { return View(); }

        public ActionResult sef()
        { return View(); }
    }
}