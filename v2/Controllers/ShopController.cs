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
                T_Product.productList = db.T_Product.ToList();
            }
            return View();
        }

        public ActionResult Commands()
        { return RedirectToAction("Commands", "Home"); }

        public ActionResult test()
        { return View(); }

        public ActionResult Profil()
        { return RedirectToAction("Profil", "User"); }

        public ActionResult Login()
        { return RedirectToAction("Login", "User"); }


        public static string getPathImg(int? id)
        {
            using (DB_YnovEntities db = new DB_YnovEntities())
            {
                T_Imgproduct path;

                path = db.T_Imgproduct.Where(x => x.id_imgproduct == id).FirstOrDefault();


                return path.path_imgproduct;
            }
        }

        public ActionResult Filtering()
        { return View(); }

        public ActionResult AddProduct()
        { return View(); }
    }
}