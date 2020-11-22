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
        { return View(); }

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


        public static List<T_Product> getProductList()
        {
            using (DB_YnovEntities db = new DB_YnovEntities())
            {
                List<T_Product> productList = new List<T_Product>();
                T_Product productInfos = new T_Product();

                var dbProductList = db.T_Product.Where(x => x.name_product != null);
                
                foreach (var item in dbProductList)
                {
                    productInfos.id_product = item.id_product;
                    productInfos.name_product = item.name_product;
                    productInfos.qty_product = item.qty_product;
                    productInfos.price_product = item.price_product;
                    productInfos.desc_product = item.desc_product;
                    productInfos.id_imgproduct = item.id_imgproduct;
                    productInfos.type_product = item.type_product;
                    productInfos.height_product = item.height_product;
                    productInfos.lenght_product = item.lenght_product;
                    productInfos.width_product = item.width_product;

                    productList.Add(productInfos);
                }
                return productList;
            }
        }
    }
}