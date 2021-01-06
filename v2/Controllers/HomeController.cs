using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using v2.Models;

namespace v2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            ////Conn auto pour les tests
            //Session["CurrentUser"] = 9;
            //T_User.activeUser = 9;
            //T_User.typeUser = 3;

            return View(); 
        }

        public ActionResult Shop()
        { return RedirectToAction("Shop","Shop"); }

        public ActionResult test()
        { return RedirectToAction("test", "Shop"); }

        public ActionResult Profil()
        { return RedirectToAction("Profil","User"); }

        public ActionResult Login()
        { return RedirectToAction("Login","User"); }
    }
}