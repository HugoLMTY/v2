using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace v2.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Connexion()
        { return View(); }
        public ActionResult CreateAccount()
        { return View(); }
    }
}