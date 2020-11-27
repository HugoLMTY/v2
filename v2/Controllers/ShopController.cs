using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using v2.Models;

namespace v2.Controllers
{
    public class ShopController : Controller
    {
        public ActionResult Index()
        { return RedirectToAction("Index", "Home"); }

        public ActionResult Shop()
        {
            using (DB_YnovEntities db = new DB_YnovEntities())
            {
                return View(db.T_Product.ToList()); 
            }
        }

        public ActionResult Commands()
        { return RedirectToAction("Commands", "Home"); }

        public ActionResult test()
        { return RedirectToAction("test", "Home"); }


        public ActionResult Profil()
        { return RedirectToAction("Profil", "User"); }

        public ActionResult Connexion()
        { return RedirectToAction("Connexion", "User"); }

        public ActionResult CreateAccount()
        { return RedirectToAction("CreateAccount", "User"); }
    }
}