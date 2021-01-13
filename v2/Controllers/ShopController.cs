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

        int minPrice;
        int maxPrice;

        double? height;
        double? lenght;
        double? width;

        string color;

        public ActionResult Index()
        { return RedirectToAction("Index", "Home"); }

        public ActionResult Shop()
        {
            using (DB_YnovEntities db = new DB_YnovEntities())
            {
                T_Product.productList = db.T_Product.ToList();
            }
            return View(T_Product.productList   );
        }

        //#region Filters
        //public ActionResult Shop(int maxPrice, int minPrice)
        //{
        //    using (DB_YnovEntities db = new DB_YnovEntities())
        //    {
        //        T_Product.productList = db.T_Product.Where(x => x.price_product < maxPrice && x.price_product > minPrice).ToList();
        //    }
        //    return View();
        //}

        //public ActionResult Shop(double? height, double? lenght, double? width)
        //{
        //    using (DB_YnovEntities db = new DB_YnovEntities())
        //    {
        //        T_Product.productList = db.T_Product.Where(x => x.height_product < height && x.lenght_product < lenght && x.width_product < width).ToList();
        //    }
        //    return View();
        //}

        //public ActionResult Shop(string color)
        //{
        //    using (DB_YnovEntities db = new DB_YnovEntities())
        //    {
        //        T_Product.productList = db.T_Product.Where(x => x.color_product == color ).ToList();
        //    }
        //    return View();
        //}

        //public ActionResult Shop(int maxPrice, int minPrice, double? height, double? lenght, double? width)
        //{
        //    using (DB_YnovEntities db = new DB_YnovEntities())
        //    {
        //        T_Product.productList = db.T_Product.Where(x => x.price_product < maxPrice && x.price_product > minPrice && x.height_product < height && x.lenght_product < lenght && x.width_product < width).ToList();
        //    }
        //    return View();
        //}

        //public ActionResult Shop(int maxPrice, int minPrice, string color)
        //{
        //    using (DB_YnovEntities db = new DB_YnovEntities())
        //    {
        //        T_Product.productList = db.T_Product.Where(x => x.price_product < maxPrice && x.price_product > minPrice && x.color_product == color).ToList();
        //    }
        //    return View();
        //}

        //public ActionResult Shop(int maxPrice, int minPrice, double? height, double? lenght, double? width, string color)
        //{
        //    using (DB_YnovEntities db = new DB_YnovEntities())
        //    {
        //        T_Product.productList = db.T_Product.Where(x => x.price_product < maxPrice && x.price_product > minPrice && x.height_product < height && x.lenght_product < lenght && x.width_product < width && x.color_product == color).ToList();
        //    }
        //    return View();
        //}

        //public ActionResult Shop(double? height, double? lenght, double? width, string color)
        //{
        //    using (DB_YnovEntities db = new DB_YnovEntities())
        //    {
        //        T_Product.productList = db.T_Product.Where(x => x.height_product < height && x.lenght_product < lenght && x.width_product < width && x.color_product == color).ToList();
        //    }
        //    return View();
        //}

        //#endregion

        //public void Filtering(T_Product model)
        //{
        //    if
        //        (model.maxPrice == null || model.minPrice == null)
        //    {
        //        if (model.color_product == null)
        //            Shop(height, lenght, width);
        //        else if (model.height_product == null || model.lenght_product == null || model.width_product == null)
        //            Shop(color);
        //        else
        //            Shop(height, lenght, width, color);
        //    }
        //    else if
        //        (model.height_product == null || model.lenght_product == null || model.width_product == null)
        //    {
        //        if (model.color_product == null)
        //            Shop(maxPrice, minPrice);
        //        else if (model.maxPrice == null || model.minPrice == null)
        //            Shop(color);
        //        else
        //            Shop(maxPrice, minPrice, color);
        //    }
        //    else if
        //        (model.color_product == null)
        //    {
        //        if (model.maxPrice == null || model.minPrice == null)
        //            Shop(height, lenght, width);
        //        else if (model.height_product == null || model.lenght_product == null || model.width_product == null)
        //            Shop(maxPrice, minPrice);
        //        else
        //            Shop(maxPrice, minPrice, height, lenght, width);
        //    }
        //    else
        //        Shop(maxPrice, minPrice, height, lenght, width, color);



            //minPrice = model.minPrice;
            //maxPrice = model.maxPrice;

            //height = model.height_product;
            //lenght = model.lenght_product;
            //width = model.width_product;

            //color = model.color_product;
        //}

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

        public ActionResult AddProduct()
        { return View(); }
    }
}