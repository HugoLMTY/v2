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
            Session["CurrentUser"] = 9;
            T_User.activeUser = 9;
            return View(); 
        }

        public ActionResult Shop()
        { return RedirectToAction("Shop","Shop"); }

        public ActionResult test()
        {
            using (DB_YnovEntities db = new DB_YnovEntities())
            {
                return View(db.T_User.ToList());
            }
        }
        
        public ActionResult Profil()
        { return RedirectToAction("Profil","User"); }

        public ActionResult Connexion()
        { return RedirectToAction("Connexion","User"); }

        public ActionResult CreateAccount()
        { return RedirectToAction("CreateAccount", "User"); }
    }
}